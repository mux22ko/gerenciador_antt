using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gerenciador_antt.Classes_Objetos;
using gerenciador_antt.Classes_Auxiliares;
using MySql.Data.MySqlClient;
using System.Data;

namespace gerenciador_antt.Classes_Dados
{
    class dados_contato_cliente
    {
        //Tabela
        public const String CONTATO_CLIENTE_TABELA = "tab_contato_cliente";
        //Campos
        public const String
        CONTATO_CLIENTE_CODIGO = "cod_contato_cliente_pk",
        CONTATO_CLIENTE_ID_CLIENTE = "cod_cliente_fk",
        CONTATO_CLIENTE_ID_TIPO = "tipo_contato_fk",
        CONTATO_CLIENTE_ID_ATENDENTE = "cod_atendente_fk",
        CONTATO_CLIENTE_TEXTO = "texto_contato_cliente",
        CONTATO_CLIENTE_DATA_CRIACAO = "data_criacao_contato";
        //Campos

        //objetos banco
        MySqlCommand Query = new MySqlCommand();
        MySqlDataReader leitor;
        //objetos banco

        #region CADASTROS SIMPLES
        public Boolean cadastrarUmContato(contato_cliente objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "INSERT INTO " + CONTATO_CLIENTE_TABELA + " (" +
                CONTATO_CLIENTE_ID_TIPO + "," +
                CONTATO_CLIENTE_ID_ATENDENTE + "," +
                CONTATO_CLIENTE_ID_CLIENTE + "," +
                CONTATO_CLIENTE_TEXTO + "," +
                CONTATO_CLIENTE_DATA_CRIACAO +
                ") values(@Cod_tipo, @Cod_atendente, @Cod_cliente, @Texto, NOW() ) ";
            Query.Parameters.AddWithValue("@Cod_tipo", objeto.getTipo_contato_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_atendente", objeto.getCod_atendente_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_cliente", objeto.getCod_cliente_fk().ToString());
            Query.Parameters.AddWithValue("@Texto", objeto.getTexto_contato_cliente().ToString());
            Query.Prepare();
            if ((leitor = Query.ExecuteReader()).RecordsAffected > 0)
            {
                leitor.Close();
                return true;
            }
            else
            {
                leitor.Close();
                return false;
            }
        }
        #endregion

        #region ALTERAÇÕES SIMPLES
        public Boolean alterarUmContato_porCodigo(contato_cliente objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "UPDATE " + CONTATO_CLIENTE_TABELA + " SET " +
                CONTATO_CLIENTE_ID_TIPO + " = @Cod_tipo," +
                CONTATO_CLIENTE_ID_ATENDENTE + " = @Cod_atendente," +
                CONTATO_CLIENTE_ID_CLIENTE + " = @Cod_cliente," +
                CONTATO_CLIENTE_TEXTO + " = @Texto" +
                " WHERE " + CONTATO_CLIENTE_CODIGO + " = @Cod_contato";
            Query.Parameters.AddWithValue("@Cod_contato", objeto.getCod_contato_cliente_pk().ToString());
            Query.Parameters.AddWithValue("@Cod_tipo", objeto.getTipo_contato_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_atendente", objeto.getCod_atendente_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_cliente", objeto.getCod_cliente_fk().ToString());
            Query.Parameters.AddWithValue("@Texto", objeto.getTexto_contato_cliente().ToString());
            Query.Prepare();
            if ((leitor = Query.ExecuteReader()).RecordsAffected > 0)
            {
                leitor.Close();
                return true;
            }
            else
            {
                leitor.Close();
                return false;
            }
        }
        #endregion

        #region DELETAR SIMPLES
        public Boolean deletarTodosContatos_excetoIds(List<contato_cliente> objetos)
        {
            //extraio os ids!
            List<int> contatosLista = objetos.Select(contato_cliente => contato_cliente.getCod_contato_cliente_pk()).ToList();
            //separo por virgulas!
            var ids = string.Join(",", contatosLista.Select(i => i.ToString()).ToArray());
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "DELETE FROM " + CONTATO_CLIENTE_TABELA + " WHERE " +
                CONTATO_CLIENTE_CODIGO+" NOT IN("+ ids +") AND "+CONTATO_CLIENTE_ID_CLIENTE+" = @Id_cliente ";
            Query.Parameters.AddWithValue("@Id_cliente", objetos[0].getCod_cliente_fk().ToString());
            Query.Prepare();
            if ((leitor = Query.ExecuteReader()).RecordsAffected > 0)
            {
                leitor.Close();
                return true;
            }
            else
            {
                leitor.Close();
                return false;
            }
        }
        #endregion

        #region BUSCAS SIMPLES
        public List<contato_cliente> selecionarTodosContato_porCodigoCliente(contato_cliente objeto)
        {     
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " +CONTATO_CLIENTE_TABELA+ " WHERE "+
                CONTATO_CLIENTE_ID_CLIENTE +" = @Cod_obj ORDER BY "+CONTATO_CLIENTE_CODIGO+" ASC";
            Query.Parameters.AddWithValue("@Cod_obj", objeto.getCod_cliente_fk().ToString());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<contato_cliente> contatos = new List<contato_cliente>();            
            while (leitor.Read())
            {
                contato_cliente contato = new contato_cliente();
                contato.setCod_contato_cliente_pk(leitor.GetInt32(CONTATO_CLIENTE_CODIGO));
                contato.setCod_cliente_fk(leitor.GetInt32(CONTATO_CLIENTE_ID_CLIENTE));
                contato.setCod_atendente_fk(leitor.GetInt32(CONTATO_CLIENTE_ID_ATENDENTE));
                contato.setTipo_contato_fk(leitor.GetInt32(CONTATO_CLIENTE_ID_TIPO));
                contato.setTexto_contato_cliente(leitor.GetString(CONTATO_CLIENTE_TEXTO));
                contato.setData_criacao_contato(leitor.GetString(CONTATO_CLIENTE_DATA_CRIACAO));
                contatos.Add(contato);
            }
            leitor.Close();
            return contatos;
        }
        public contato_cliente selecionarUltimoContato_acabouDeCadastrar()
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + CONTATO_CLIENTE_TABELA + " WHERE " +
               CONTATO_CLIENTE_CODIGO + " = LAST_INSERT_ID() LIMIT 1";
            leitor = Query.ExecuteReader();
            contato_cliente contato = new contato_cliente();
            while (leitor.Read())
            {
                contato.setCod_contato_cliente_pk(leitor.GetInt32(CONTATO_CLIENTE_CODIGO));
                contato.setCod_cliente_fk(leitor.GetInt32(CONTATO_CLIENTE_ID_CLIENTE));
                contato.setCod_atendente_fk(leitor.GetInt32(CONTATO_CLIENTE_ID_ATENDENTE));
                contato.setTipo_contato_fk(leitor.GetInt32(CONTATO_CLIENTE_ID_TIPO));
                contato.setTexto_contato_cliente(leitor.GetString(CONTATO_CLIENTE_TEXTO));
                contato.setData_criacao_contato(leitor.GetString(CONTATO_CLIENTE_DATA_CRIACAO));
            }
            leitor.Close();
            return contato;
        }
        #endregion

        #region BUSCAS DINAMICA POR TERMOS
        public List<contato_cliente> selecionarContato_ativos_porTexto_contenha(contato_cliente objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + CONTATO_CLIENTE_TABELA + " WHERE " +
                CONTATO_CLIENTE_TEXTO + " LIKE @Texto "+
                " AND " + CONTATO_CLIENTE_ID_TIPO + " = @Tipo " +
                " ORDER BY " + CONTATO_CLIENTE_CODIGO + " ASC ";
            Query.Parameters.AddWithValue("@Texto", "%"+objeto.getTexto_contato_cliente().ToString()+"%");
            Query.Parameters.AddWithValue("@Tipo", objeto.getTipo_contato_fk().ToString());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<contato_cliente> contatos = new List<contato_cliente>();
            while (leitor.Read())
            {
                contato_cliente contato = new contato_cliente();
                contato.setCod_contato_cliente_pk(leitor.GetInt32(CONTATO_CLIENTE_CODIGO));
                contato.setCod_cliente_fk(leitor.GetInt32(CONTATO_CLIENTE_ID_CLIENTE));
                contato.setCod_atendente_fk(leitor.GetInt32(CONTATO_CLIENTE_ID_ATENDENTE));
                contato.setTipo_contato_fk(leitor.GetInt32(CONTATO_CLIENTE_ID_TIPO));
                contato.setTexto_contato_cliente(leitor.GetString(CONTATO_CLIENTE_TEXTO));
                contato.setData_criacao_contato(leitor.GetString(CONTATO_CLIENTE_DATA_CRIACAO));
                contatos.Add(contato);
            }
            leitor.Close();
            return contatos;
        }

        public List<contato_cliente> selecionarContato_ativos_porTexto_inicio(contato_cliente objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + CONTATO_CLIENTE_TABELA + " WHERE " +
                CONTATO_CLIENTE_TEXTO + " LIKE @Texto " +
                " AND " + CONTATO_CLIENTE_ID_TIPO + " = @Tipo " +
                " ORDER BY " + CONTATO_CLIENTE_CODIGO + " ASC ";
            Query.Parameters.AddWithValue("@Texto", objeto.getTexto_contato_cliente().ToString() + "%");
            Query.Parameters.AddWithValue("@Tipo", objeto.getTipo_contato_fk().ToString());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<contato_cliente> contatos = new List<contato_cliente>();
            while (leitor.Read())
            {
                contato_cliente contato = new contato_cliente();
                contato.setCod_contato_cliente_pk(leitor.GetInt32(CONTATO_CLIENTE_CODIGO));
                contato.setCod_cliente_fk(leitor.GetInt32(CONTATO_CLIENTE_ID_CLIENTE));
                contato.setCod_atendente_fk(leitor.GetInt32(CONTATO_CLIENTE_ID_ATENDENTE));
                contato.setTipo_contato_fk(leitor.GetInt32(CONTATO_CLIENTE_ID_TIPO));
                contato.setTexto_contato_cliente(leitor.GetString(CONTATO_CLIENTE_TEXTO));
                contato.setData_criacao_contato(leitor.GetString(CONTATO_CLIENTE_DATA_CRIACAO));
                contatos.Add(contato);
            }
            leitor.Close();
            return contatos;
        }

        public List<contato_cliente> selecionarContato_ativos_porTexto_fim(contato_cliente objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + CONTATO_CLIENTE_TABELA + " WHERE " +
                CONTATO_CLIENTE_TEXTO + " LIKE @Texto " +
                " AND " + CONTATO_CLIENTE_ID_TIPO + " = @Tipo " +
                " ORDER BY " + CONTATO_CLIENTE_CODIGO + " ASC ";
            Query.Parameters.AddWithValue("@Texto", "%"+objeto.getTexto_contato_cliente().ToString());
            Query.Parameters.AddWithValue("@Tipo", objeto.getTipo_contato_fk().ToString());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<contato_cliente> contatos = new List<contato_cliente>();
            while (leitor.Read())
            {
                contato_cliente contato = new contato_cliente();
                contato.setCod_contato_cliente_pk(leitor.GetInt32(CONTATO_CLIENTE_CODIGO));
                contato.setCod_cliente_fk(leitor.GetInt32(CONTATO_CLIENTE_ID_CLIENTE));
                contato.setCod_atendente_fk(leitor.GetInt32(CONTATO_CLIENTE_ID_ATENDENTE));
                contato.setTipo_contato_fk(leitor.GetInt32(CONTATO_CLIENTE_ID_TIPO));
                contato.setTexto_contato_cliente(leitor.GetString(CONTATO_CLIENTE_TEXTO));
                contato.setData_criacao_contato(leitor.GetString(CONTATO_CLIENTE_DATA_CRIACAO));
                contatos.Add(contato);
            }
            leitor.Close();
            return contatos;
        }

        public List<contato_cliente> selecionarContato_ativos_porTexto_igual(contato_cliente objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + CONTATO_CLIENTE_TABELA + " WHERE " +
                CONTATO_CLIENTE_TEXTO + " = @Texto " +
                " AND " + CONTATO_CLIENTE_ID_TIPO + " = @Tipo " +
                " ORDER BY " + CONTATO_CLIENTE_CODIGO + " ASC ";
            Query.Parameters.AddWithValue("@Texto", objeto.getTexto_contato_cliente().ToString());
            Query.Parameters.AddWithValue("@Tipo", objeto.getTipo_contato_fk().ToString());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<contato_cliente> contatos = new List<contato_cliente>();
            while (leitor.Read())
            {
                contato_cliente contato = new contato_cliente();
                contato.setCod_contato_cliente_pk(leitor.GetInt32(CONTATO_CLIENTE_CODIGO));
                contato.setCod_cliente_fk(leitor.GetInt32(CONTATO_CLIENTE_ID_CLIENTE));
                contato.setCod_atendente_fk(leitor.GetInt32(CONTATO_CLIENTE_ID_ATENDENTE));
                contato.setTipo_contato_fk(leitor.GetInt32(CONTATO_CLIENTE_ID_TIPO));
                contato.setTexto_contato_cliente(leitor.GetString(CONTATO_CLIENTE_TEXTO));
                contato.setData_criacao_contato(leitor.GetString(CONTATO_CLIENTE_DATA_CRIACAO));
                contatos.Add(contato);
            }
            leitor.Close();
            return contatos;
        }
        #endregion
    }
}
