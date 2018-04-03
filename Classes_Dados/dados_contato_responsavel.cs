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
    class dados_contato_responsavel
    {
        #region DADOS BD
        //Tabela
        public const String CONTATO_responsavel_TABELA = "tab_contato_responsavel";
        //Campos
        public const String
        CONTATO_RESPONSAVEL_CODIGO = "cod_contato_responsavel_pk",
        CONTATO_RESPONSAVEL_ID_RESPONSAVEL = "cod_responsavel_fk",
        CONTATO_RESPONSAVEL_ID_TIPO = "tipo_contato_fk",
        CONTATO_RESPONSAVEL_ID_ATENDENTE = "cod_atendente_fk",
        CONTATO_RESPONSAVEL_TEXTO = "texto_contato_responsavel",
        CONTATO_RESPONSAVEL_DATA_CRIACAO = "data_criacao_contato";
        //Campos
        #endregion

        //objetos banco
        MySqlCommand Query = new MySqlCommand();
        MySqlDataReader leitor;
        //objetos banco

        #region CADASTROS SIMPLES
        public Boolean cadastrarUmContato(contato_responsavel objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "INSERT INTO " + CONTATO_responsavel_TABELA + " (" +
                CONTATO_RESPONSAVEL_ID_TIPO + "," +
                CONTATO_RESPONSAVEL_ID_ATENDENTE + "," +
                CONTATO_RESPONSAVEL_ID_RESPONSAVEL + "," +
                CONTATO_RESPONSAVEL_TEXTO + "," +
                CONTATO_RESPONSAVEL_DATA_CRIACAO +
                ") values(@Cod_tipo, @Cod_atendente, @Cod_responsavel, @Texto, NOW() ) ";
            Query.Parameters.AddWithValue("@Cod_tipo", objeto.getTipo_contato_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_atendente", objeto.getCod_atendente_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_responsavel", objeto.getCod_responsavel_fk().ToString());
            Query.Parameters.AddWithValue("@Texto", objeto.getTexto_contato_responsavel().ToString());
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

        #region ALTERAR SIMPLES
        public Boolean alterarUmContato_porCodigo(contato_responsavel objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "UPDATE " + CONTATO_responsavel_TABELA + " SET " +
                CONTATO_RESPONSAVEL_ID_TIPO + " = @Cod_tipo," +
                CONTATO_RESPONSAVEL_ID_ATENDENTE + " = @Cod_atendente," +
                CONTATO_RESPONSAVEL_ID_RESPONSAVEL + " = @Cod_responsavel," +
                CONTATO_RESPONSAVEL_TEXTO + " = @Texto" +
                " WHERE " + CONTATO_RESPONSAVEL_CODIGO + " = @Cod_contato_responsavel";
            Query.Parameters.AddWithValue("@Cod_contato_responsavel", objeto.getCod_contato_responsavel_pk().ToString());
            Query.Parameters.AddWithValue("@Cod_tipo", objeto.getTipo_contato_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_atendente", objeto.getCod_atendente_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_responsavel", objeto.getCod_responsavel_fk().ToString());
            Query.Parameters.AddWithValue("@Texto", objeto.getTexto_contato_responsavel().ToString());
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
        public Boolean deletarTodosContatos_excetoIds(List<contato_responsavel> objetos)
        {
            //extraio os ids!
            List<int> contatosLista = objetos.Select(contato_responsavel => contato_responsavel.getCod_contato_responsavel_pk()).ToList();
            //separo por virgulas!
            var ids = string.Join(",", contatosLista.Select(i => i.ToString()).ToArray());
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "DELETE FROM " + CONTATO_responsavel_TABELA + " WHERE " +
                CONTATO_RESPONSAVEL_CODIGO+" NOT IN("+ ids +") AND "+CONTATO_RESPONSAVEL_ID_RESPONSAVEL+" = @Id_responsavel ";
            Query.Parameters.AddWithValue("@Id_responsavel", objetos[0].getCod_responsavel_fk().ToString());
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
        public List<contato_responsavel> selecionarTodosContato_porCodigoResponsavel(contato_responsavel objeto)
        {     
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " +CONTATO_responsavel_TABELA+ " WHERE "+
                CONTATO_RESPONSAVEL_ID_RESPONSAVEL +" = @Cod_obj ORDER BY "+CONTATO_RESPONSAVEL_CODIGO+" ASC";
            Query.Parameters.AddWithValue("@Cod_obj", objeto.getCod_responsavel_fk().ToString());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<contato_responsavel> contatos = new List<contato_responsavel>();            
            while (leitor.Read())
            {
                contato_responsavel contato = new contato_responsavel();
                contato.setCod_contato_responsavel_pk(leitor.GetInt32(CONTATO_RESPONSAVEL_CODIGO));
                contato.setCod_responsavel_fk(leitor.GetInt32(CONTATO_RESPONSAVEL_ID_RESPONSAVEL));
                contato.setCod_atendente_fk(leitor.GetInt32(CONTATO_RESPONSAVEL_ID_ATENDENTE));
                contato.setTipo_contato_fk(leitor.GetInt32(CONTATO_RESPONSAVEL_ID_TIPO));
                contato.setTexto_contato_responsavel(leitor.GetString(CONTATO_RESPONSAVEL_TEXTO));
                contato.setData_criacao_contato(leitor.GetString(CONTATO_RESPONSAVEL_DATA_CRIACAO));
                contatos.Add(contato);
            }
            leitor.Close();
            return contatos;
        }
        public contato_responsavel selecionarUltimoContato_acabouDeCadastrar()
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + CONTATO_responsavel_TABELA + " WHERE " +
               CONTATO_RESPONSAVEL_CODIGO + " = LAST_INSERT_ID() LIMIT 1";
            leitor = Query.ExecuteReader();
            contato_responsavel contato = new contato_responsavel();
            while (leitor.Read())
            {
                contato.setCod_contato_responsavel_pk(leitor.GetInt32(CONTATO_RESPONSAVEL_CODIGO));
                contato.setCod_responsavel_fk(leitor.GetInt32(CONTATO_RESPONSAVEL_ID_RESPONSAVEL));
                contato.setCod_atendente_fk(leitor.GetInt32(CONTATO_RESPONSAVEL_ID_ATENDENTE));
                contato.setTipo_contato_fk(leitor.GetInt32(CONTATO_RESPONSAVEL_ID_TIPO));
                contato.setTexto_contato_responsavel(leitor.GetString(CONTATO_RESPONSAVEL_TEXTO));
                contato.setData_criacao_contato(leitor.GetString(CONTATO_RESPONSAVEL_DATA_CRIACAO));
            }
            leitor.Close();
            return contato;
        }
        #endregion

        #region BUSCAS DINAMICA POR TERMOS
        public List<contato_responsavel> selecionarContato_ativos_porTexto_contenha(contato_responsavel objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + CONTATO_responsavel_TABELA + " WHERE " +
                CONTATO_RESPONSAVEL_TEXTO + " LIKE @Texto "+
                " AND " + CONTATO_RESPONSAVEL_ID_TIPO + " = @Tipo " +
                " ORDER BY " + CONTATO_RESPONSAVEL_CODIGO + " ASC ";
            Query.Parameters.AddWithValue("@Texto", "%"+objeto.getTexto_contato_responsavel().ToString()+"%");
            Query.Parameters.AddWithValue("@Tipo", objeto.getTipo_contato_fk().ToString());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<contato_responsavel> contatos = new List<contato_responsavel>();
            while (leitor.Read())
            {
                contato_responsavel contato = new contato_responsavel();
                contato.setCod_contato_responsavel_pk(leitor.GetInt32(CONTATO_RESPONSAVEL_CODIGO));
                contato.setCod_responsavel_fk(leitor.GetInt32(CONTATO_RESPONSAVEL_ID_RESPONSAVEL));
                contato.setCod_atendente_fk(leitor.GetInt32(CONTATO_RESPONSAVEL_ID_ATENDENTE));
                contato.setTipo_contato_fk(leitor.GetInt32(CONTATO_RESPONSAVEL_ID_TIPO));
                contato.setTexto_contato_responsavel(leitor.GetString(CONTATO_RESPONSAVEL_TEXTO));
                contato.setData_criacao_contato(leitor.GetString(CONTATO_RESPONSAVEL_DATA_CRIACAO));
                contatos.Add(contato);
            }
            leitor.Close();
            return contatos;
        }

        public List<contato_responsavel> selecionarContato_ativos_porTexto_inicio(contato_responsavel objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + CONTATO_responsavel_TABELA + " WHERE " +
                CONTATO_RESPONSAVEL_TEXTO + " LIKE @Texto " +
                " AND " + CONTATO_RESPONSAVEL_ID_TIPO + " = @Tipo " +
                " ORDER BY " + CONTATO_RESPONSAVEL_CODIGO + " ASC ";
            Query.Parameters.AddWithValue("@Texto", objeto.getTexto_contato_responsavel().ToString() + "%");
            Query.Parameters.AddWithValue("@Tipo", objeto.getTipo_contato_fk().ToString());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<contato_responsavel> contatos = new List<contato_responsavel>();
            while (leitor.Read())
            {
                contato_responsavel contato = new contato_responsavel();
                contato.setCod_contato_responsavel_pk(leitor.GetInt32(CONTATO_RESPONSAVEL_CODIGO));
                contato.setCod_responsavel_fk(leitor.GetInt32(CONTATO_RESPONSAVEL_ID_RESPONSAVEL));
                contato.setCod_atendente_fk(leitor.GetInt32(CONTATO_RESPONSAVEL_ID_ATENDENTE));
                contato.setTipo_contato_fk(leitor.GetInt32(CONTATO_RESPONSAVEL_ID_TIPO));
                contato.setTexto_contato_responsavel(leitor.GetString(CONTATO_RESPONSAVEL_TEXTO));
                contato.setData_criacao_contato(leitor.GetString(CONTATO_RESPONSAVEL_DATA_CRIACAO));
                contatos.Add(contato);
            }
            leitor.Close();
            return contatos;
        }

        public List<contato_responsavel> selecionarContato_ativos_porTexto_fim(contato_responsavel objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + CONTATO_responsavel_TABELA + " WHERE " +
                CONTATO_RESPONSAVEL_TEXTO + " LIKE @Texto " +
                " AND " + CONTATO_RESPONSAVEL_ID_TIPO + " = @Tipo " +
                " ORDER BY " + CONTATO_RESPONSAVEL_CODIGO + " ASC ";
            Query.Parameters.AddWithValue("@Texto", "%"+objeto.getTexto_contato_responsavel().ToString());
            Query.Parameters.AddWithValue("@Tipo", objeto.getTipo_contato_fk().ToString());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<contato_responsavel> contatos = new List<contato_responsavel>();
            while (leitor.Read())
            {
                contato_responsavel contato = new contato_responsavel();
                contato.setCod_contato_responsavel_pk(leitor.GetInt32(CONTATO_RESPONSAVEL_CODIGO));
                contato.setCod_responsavel_fk(leitor.GetInt32(CONTATO_RESPONSAVEL_ID_RESPONSAVEL));
                contato.setCod_atendente_fk(leitor.GetInt32(CONTATO_RESPONSAVEL_ID_ATENDENTE));
                contato.setTipo_contato_fk(leitor.GetInt32(CONTATO_RESPONSAVEL_ID_TIPO));
                contato.setTexto_contato_responsavel(leitor.GetString(CONTATO_RESPONSAVEL_TEXTO));
                contato.setData_criacao_contato(leitor.GetString(CONTATO_RESPONSAVEL_DATA_CRIACAO));
                contatos.Add(contato);
            }
            leitor.Close();
            return contatos;
        }

        public List<contato_responsavel> selecionarContato_ativos_porTexto_igual(contato_responsavel objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + CONTATO_responsavel_TABELA + " WHERE " +
                CONTATO_RESPONSAVEL_TEXTO + " = @Texto " +
                " AND " + CONTATO_RESPONSAVEL_ID_TIPO + " = @Tipo " +
                " ORDER BY " + CONTATO_RESPONSAVEL_CODIGO + " ASC ";
            Query.Parameters.AddWithValue("@Texto", objeto.getTexto_contato_responsavel().ToString());
            Query.Parameters.AddWithValue("@Tipo", objeto.getTipo_contato_fk().ToString());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<contato_responsavel> contatos = new List<contato_responsavel>();
            while (leitor.Read())
            {
                contato_responsavel contato = new contato_responsavel();
                contato.setCod_contato_responsavel_pk(leitor.GetInt32(CONTATO_RESPONSAVEL_CODIGO));
                contato.setCod_responsavel_fk(leitor.GetInt32(CONTATO_RESPONSAVEL_ID_RESPONSAVEL));
                contato.setCod_atendente_fk(leitor.GetInt32(CONTATO_RESPONSAVEL_ID_ATENDENTE));
                contato.setTipo_contato_fk(leitor.GetInt32(CONTATO_RESPONSAVEL_ID_TIPO));
                contato.setTexto_contato_responsavel(leitor.GetString(CONTATO_RESPONSAVEL_TEXTO));
                contato.setData_criacao_contato(leitor.GetString(CONTATO_RESPONSAVEL_DATA_CRIACAO));
                contatos.Add(contato);
            }
            leitor.Close();
            return contatos;
        }
        #endregion
    }
}
