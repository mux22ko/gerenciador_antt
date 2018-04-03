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
    class dados_endereco_cliente
    {
        //Tabela
        public const String ENDERECO_CLIENTE_TABELA = "tab_endereco_cliente";
        //Campos
        public const String
        ENDERECO_CLIENTE_CODIGO = "cod_endereco_cliente_pk",
        ENDERECO_CLIENTE_ID_TIPO = "cod_tipo_endereco_fk",
        ENDERECO_CLIENTE_ID_ATENDENTE = "cod_atendente_fk",
        ENDERECO_CLIENTE_ID_CLIENTE = "cod_cliente_fk",
        ENDERECO_CLIENTE_TEXTO = "texto_endereco_cliente",
        ENDERECO_CLIENTE_DATA_CRIACAO = "data_criacao_endereco";
        //Campos

        //objetos banco
        MySqlCommand Query = new MySqlCommand();
        MySqlDataReader leitor;
        //objetos banco
        
        #region CADASTROS SIMPLES
        public Boolean cadastrarUmEndereco(endereco_cliente objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "INSERT INTO " + ENDERECO_CLIENTE_TABELA + " (" +
                ENDERECO_CLIENTE_ID_TIPO + "," +
                ENDERECO_CLIENTE_ID_ATENDENTE + "," +
                ENDERECO_CLIENTE_ID_CLIENTE + "," +
                ENDERECO_CLIENTE_TEXTO + "," +
                ENDERECO_CLIENTE_DATA_CRIACAO +
                ") values(@Cod_tipo, @Cod_atendente, @Cod_cliente, @Texto, NOW() ) ";
            Query.Parameters.AddWithValue("@Cod_tipo", objeto.getCod_tipo_endereco_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_atendente", objeto.getCod_atendente_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_cliente", objeto.getCod_cliente_fk().ToString());
            Query.Parameters.AddWithValue("@Texto", objeto.getTexto_endereco_cliente().ToString());
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

       #region ALTERAÇÃO SIMPLES
        public Boolean alterarUmEndereco_porCodigo(endereco_cliente objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "UPDATE " + ENDERECO_CLIENTE_TABELA + " SET " +
                ENDERECO_CLIENTE_ID_TIPO + " = @Cod_tipo," +
                ENDERECO_CLIENTE_ID_ATENDENTE + " = @Cod_atendente," +
                ENDERECO_CLIENTE_ID_CLIENTE + " = @Cod_cliente," +
                ENDERECO_CLIENTE_TEXTO + " = @Texto" +
                " WHERE " + ENDERECO_CLIENTE_CODIGO + " = @Cod_endereco ";
            Query.Parameters.AddWithValue("@Cod_endereco", objeto.getCod_endereco_cliente_pk().ToString());
            Query.Parameters.AddWithValue("@Cod_tipo", objeto.getCod_tipo_endereco_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_atendente", objeto.getCod_atendente_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_cliente", objeto.getCod_cliente_fk().ToString());
            Query.Parameters.AddWithValue("@Texto", objeto.getTexto_endereco_cliente().ToString());
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
        public Boolean deletarTodosEnderecos_excetoIds(List<endereco_cliente> objetos)
        {
            //extraio os ids!
            List<int> enderecosLista = objetos.Select(endereco_cliente => endereco_cliente.getCod_endereco_cliente_pk()).ToList();
            //separo por virgulas!
            var ids = string.Join(",", enderecosLista.Select(i => i.ToString()).ToArray());
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "DELETE FROM " + ENDERECO_CLIENTE_TABELA + " WHERE " +
               ENDERECO_CLIENTE_CODIGO + " NOT IN(" + ids + ") AND " + ENDERECO_CLIENTE_ID_CLIENTE + " = @Id_cliente ";
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
        public List<endereco_cliente> selecionarTodosEndereco_porCodigoCliente(endereco_cliente objeto)
        {     
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + ENDERECO_CLIENTE_TABELA + " WHERE " +
                ENDERECO_CLIENTE_ID_CLIENTE + " = @Cod_obj ORDER BY " + ENDERECO_CLIENTE_CODIGO + " ASC";
            Query.Parameters.AddWithValue("@Cod_obj", objeto.getCod_cliente_fk().ToString());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<endereco_cliente> enderecos = new List<endereco_cliente>();            
            while (leitor.Read())
            {
                endereco_cliente endereco = new endereco_cliente();
                endereco.setCod_endereco_cliente_pk(leitor.GetInt32(ENDERECO_CLIENTE_CODIGO));
                endereco.setCod_cliente_fk(leitor.GetInt32(ENDERECO_CLIENTE_ID_CLIENTE));
                endereco.setCod_atendente_fk(leitor.GetInt32(ENDERECO_CLIENTE_ID_ATENDENTE));
                endereco.setCod_tipo_endereco_fk(leitor.GetInt32(ENDERECO_CLIENTE_ID_TIPO));
                endereco.setTexto_endereco_cliente(leitor.GetString(ENDERECO_CLIENTE_TEXTO));
                endereco.setData_criacao_endereco(leitor.GetString(ENDERECO_CLIENTE_DATA_CRIACAO));
                enderecos.Add(endereco);
            }
            leitor.Close();
            return enderecos;
        }
        public endereco_cliente selecionarUltimoEndereco_acabouDeCadastrar()
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + ENDERECO_CLIENTE_TABELA + " WHERE " +
                ENDERECO_CLIENTE_CODIGO + " = LAST_INSERT_ID() LIMIT 1";
            leitor = Query.ExecuteReader();
            endereco_cliente endereco = new endereco_cliente();
            while (leitor.Read())
            {
                //capto os dados do cliente selecionado!
                endereco.setCod_endereco_cliente_pk(leitor.GetInt32(ENDERECO_CLIENTE_CODIGO));
                endereco.setCod_cliente_fk(leitor.GetInt32(ENDERECO_CLIENTE_ID_CLIENTE));
                endereco.setCod_atendente_fk(leitor.GetInt32(ENDERECO_CLIENTE_ID_ATENDENTE));
                endereco.setCod_tipo_endereco_fk(leitor.GetInt32(ENDERECO_CLIENTE_ID_TIPO));
                endereco.setTexto_endereco_cliente(leitor.GetString(ENDERECO_CLIENTE_TEXTO));
                endereco.setData_criacao_endereco(leitor.GetString(ENDERECO_CLIENTE_DATA_CRIACAO));
            }
            leitor.Close();
            return endereco;
        }
        #endregion

        #region BUSCAS COMPLEXAS POR TERMOS
        public List<endereco_cliente> selecionarEndereco_porTexto_contenha(endereco_cliente objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + ENDERECO_CLIENTE_TABELA + " WHERE " +
                ENDERECO_CLIENTE_TEXTO + " LIKE @Texto " +
                " AND " + ENDERECO_CLIENTE_ID_TIPO + " = @Tipo " +
                " ORDER BY " + ENDERECO_CLIENTE_CODIGO + " ASC ";
            Query.Parameters.AddWithValue("@Texto", "%"+objeto.getTexto_endereco_cliente().ToString()+"%");
            Query.Parameters.AddWithValue("@Tipo", objeto.getCod_tipo_endereco_fk().ToString());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<endereco_cliente> enderecos = new List<endereco_cliente>();
            while (leitor.Read())
            {
                endereco_cliente endereco = new endereco_cliente();
                endereco.setCod_endereco_cliente_pk(leitor.GetInt32(ENDERECO_CLIENTE_CODIGO));
                endereco.setCod_cliente_fk(leitor.GetInt32(ENDERECO_CLIENTE_ID_CLIENTE));
                endereco.setCod_atendente_fk(leitor.GetInt32(ENDERECO_CLIENTE_ID_ATENDENTE));
                endereco.setCod_tipo_endereco_fk(leitor.GetInt32(ENDERECO_CLIENTE_ID_TIPO));
                endereco.setTexto_endereco_cliente(leitor.GetString(ENDERECO_CLIENTE_TEXTO));
                endereco.setData_criacao_endereco(leitor.GetString(ENDERECO_CLIENTE_DATA_CRIACAO));
                enderecos.Add(endereco);
            }
            leitor.Close();
            return enderecos;
        }

        public List<endereco_cliente> selecionarEndereco_porTexto_igual(endereco_cliente objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + ENDERECO_CLIENTE_TABELA + " WHERE " +
                ENDERECO_CLIENTE_TEXTO + " = @Texto " +
                " AND " + ENDERECO_CLIENTE_ID_TIPO + " = @Tipo " +
                " ORDER BY " + ENDERECO_CLIENTE_CODIGO + " ASC ";
            Query.Parameters.AddWithValue("@Texto", objeto.getTexto_endereco_cliente().ToString());
            Query.Parameters.AddWithValue("@Tipo", objeto.getCod_tipo_endereco_fk().ToString());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<endereco_cliente> enderecos = new List<endereco_cliente>();
            while (leitor.Read())
            {
                endereco_cliente endereco = new endereco_cliente();
                endereco.setCod_endereco_cliente_pk(leitor.GetInt32(ENDERECO_CLIENTE_CODIGO));
                endereco.setCod_cliente_fk(leitor.GetInt32(ENDERECO_CLIENTE_ID_CLIENTE));
                endereco.setCod_atendente_fk(leitor.GetInt32(ENDERECO_CLIENTE_ID_ATENDENTE));
                endereco.setCod_tipo_endereco_fk(leitor.GetInt32(ENDERECO_CLIENTE_ID_TIPO));
                endereco.setTexto_endereco_cliente(leitor.GetString(ENDERECO_CLIENTE_TEXTO));
                endereco.setData_criacao_endereco(leitor.GetString(ENDERECO_CLIENTE_DATA_CRIACAO));
                enderecos.Add(endereco);
            }
            leitor.Close();
            return enderecos;
        }
        #endregion
    }    
    
}
