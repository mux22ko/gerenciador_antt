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
    class dados_endereco_responsavel
    {
        //Tabela
        public const String ENDERECO_responsavel_TABELA = "tab_endereco_responsavel";
        //Campos
        public const String
        ENDERECO_RESPONSAVEL_CODIGO = "cod_endereco_responsavel_pk",
        ENDERECO_RESPONSAVEL_ID_TIPO = "cod_tipo_endereco_fk",
        ENDERECO_RESPONSAVEL_ID_ATENDENTE = "cod_atendente_fk",
        ENDERECO_RESPONSAVEL_ID_RESPONSAVEL = "cod_responsavel_fk",
        ENDERECO_RESPONSAVEL_TEXTO = "texto_endereco_responsavel",
        ENDERECO_RESPONSAVEL_DATA_CRIACAO = "data_criacao_endereco";
        //Campos

        //objetos banco
        MySqlCommand Query = new MySqlCommand();
        MySqlDataReader leitor;
        //objetos banco
        
        #region CADASTROS SIMPLES
        public Boolean cadastrarUmEndereco(endereco_responsavel objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "INSERT INTO " + ENDERECO_responsavel_TABELA + " (" +
                ENDERECO_RESPONSAVEL_ID_TIPO + "," +
                ENDERECO_RESPONSAVEL_ID_ATENDENTE + "," +
                ENDERECO_RESPONSAVEL_ID_RESPONSAVEL + "," +
                ENDERECO_RESPONSAVEL_TEXTO + "," +
                ENDERECO_RESPONSAVEL_DATA_CRIACAO +
                ") values(@Cod_tipo, @Cod_atendente, @Cod_responsavel, @Texto, NOW() ) ";
            Query.Parameters.AddWithValue("@Cod_tipo", objeto.getCod_tipo_endereco_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_atendente", objeto.getCod_atendente_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_responsavel", objeto.getCod_responsavel_fk().ToString());
            Query.Parameters.AddWithValue("@Texto", objeto.getTexto_endereco_responsavel().ToString());
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
        public Boolean alterarUmEndereco_porCodigo(endereco_responsavel objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "UPDATE " + ENDERECO_responsavel_TABELA + " SET " +
                ENDERECO_RESPONSAVEL_ID_TIPO + " = @Cod_tipo," +
                ENDERECO_RESPONSAVEL_ID_ATENDENTE + " = @Cod_atendente," +
                ENDERECO_RESPONSAVEL_ID_RESPONSAVEL + " = @Cod_responsavel," +
                ENDERECO_RESPONSAVEL_TEXTO + " = @Texto" +
                " WHERE " + ENDERECO_RESPONSAVEL_CODIGO + " = @Cod_endereco_responsavel";
            Query.Parameters.AddWithValue("@Cod_endereco_responsavel", objeto.getCod_endereco_responsavel_pk().ToString());
            Query.Parameters.AddWithValue("@Cod_tipo", objeto.getCod_tipo_endereco_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_atendente", objeto.getCod_atendente_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_responsavel", objeto.getCod_responsavel_fk().ToString());
            Query.Parameters.AddWithValue("@Texto", objeto.getTexto_endereco_responsavel().ToString());
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
        public Boolean deletarTodosEnderecos_excetoIds(List<endereco_responsavel> objetos)
        {
            //extraio os ids!
            List<int> enderecosLista = objetos.Select(endereco_responsavel => endereco_responsavel.getCod_endereco_responsavel_pk()).ToList();
            //separo por virgulas!
            var ids = string.Join(",", enderecosLista.Select(i => i.ToString()).ToArray());
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "DELETE FROM " + ENDERECO_responsavel_TABELA + " WHERE " +
               ENDERECO_RESPONSAVEL_CODIGO + " NOT IN(" + ids + ") AND " + ENDERECO_RESPONSAVEL_ID_RESPONSAVEL + " = @Id_responsavel ";
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
        public List<endereco_responsavel> selecionarTodosEndereco_porCodigoResponsavel(endereco_responsavel objeto)
        {     
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + ENDERECO_responsavel_TABELA + " WHERE " +
                ENDERECO_RESPONSAVEL_ID_RESPONSAVEL + " = @Cod_obj ORDER BY " + ENDERECO_RESPONSAVEL_CODIGO + " ASC";
            Query.Parameters.AddWithValue("@Cod_obj", objeto.getCod_responsavel_fk().ToString());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<endereco_responsavel> enderecos = new List<endereco_responsavel>();            
            while (leitor.Read())
            {
                endereco_responsavel endereco = new endereco_responsavel();
                endereco.setCod_endereco_responsavel_pk(leitor.GetInt32(ENDERECO_RESPONSAVEL_CODIGO));
                endereco.setCod_responsavel_fk(leitor.GetInt32(ENDERECO_RESPONSAVEL_ID_RESPONSAVEL));
                endereco.setCod_atendente_fk(leitor.GetInt32(ENDERECO_RESPONSAVEL_ID_ATENDENTE));
                endereco.setCod_tipo_endereco_fk(leitor.GetInt32(ENDERECO_RESPONSAVEL_ID_TIPO));
                endereco.setTexto_endereco_responsavel(leitor.GetString(ENDERECO_RESPONSAVEL_TEXTO));
                endereco.setData_criacao_endereco(leitor.GetString(ENDERECO_RESPONSAVEL_DATA_CRIACAO));
                enderecos.Add(endereco);
            }
            leitor.Close();
            return enderecos;
        }
        public endereco_responsavel selecionarUltimoEndereco_acabouDeCadastrar()
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + ENDERECO_responsavel_TABELA + " WHERE " +
                ENDERECO_RESPONSAVEL_CODIGO + " = LAST_INSERT_ID() LIMIT 1";
            leitor = Query.ExecuteReader();
            endereco_responsavel endereco = new endereco_responsavel();
            while (leitor.Read())
            {
                //capto os dados do responsavel selecionado!
                endereco.setCod_endereco_responsavel_pk(leitor.GetInt32(ENDERECO_RESPONSAVEL_CODIGO));
                endereco.setCod_responsavel_fk(leitor.GetInt32(ENDERECO_RESPONSAVEL_ID_RESPONSAVEL));
                endereco.setCod_atendente_fk(leitor.GetInt32(ENDERECO_RESPONSAVEL_ID_ATENDENTE));
                endereco.setCod_tipo_endereco_fk(leitor.GetInt32(ENDERECO_RESPONSAVEL_ID_TIPO));
                endereco.setTexto_endereco_responsavel(leitor.GetString(ENDERECO_RESPONSAVEL_TEXTO));
                endereco.setData_criacao_endereco(leitor.GetString(ENDERECO_RESPONSAVEL_DATA_CRIACAO));
            }
            leitor.Close();
            return endereco;
        }
        #endregion

        #region BUSCAS COMPLEXAS POR TERMOS
        public List<endereco_responsavel> selecionarEndereco_porTexto_contenha(endereco_responsavel objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + ENDERECO_responsavel_TABELA + " WHERE " +
                ENDERECO_RESPONSAVEL_TEXTO + " LIKE @Texto " +
                " AND " + ENDERECO_RESPONSAVEL_ID_TIPO + " = @Tipo " +
                " ORDER BY " + ENDERECO_RESPONSAVEL_CODIGO + " ASC ";
            Query.Parameters.AddWithValue("@Texto", "%"+objeto.getTexto_endereco_responsavel().ToString()+"%");
            Query.Parameters.AddWithValue("@Tipo", objeto.getCod_tipo_endereco_fk().ToString());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<endereco_responsavel> enderecos = new List<endereco_responsavel>();
            while (leitor.Read())
            {
                endereco_responsavel endereco = new endereco_responsavel();
                endereco.setCod_endereco_responsavel_pk(leitor.GetInt32(ENDERECO_RESPONSAVEL_CODIGO));
                endereco.setCod_responsavel_fk(leitor.GetInt32(ENDERECO_RESPONSAVEL_ID_RESPONSAVEL));
                endereco.setCod_atendente_fk(leitor.GetInt32(ENDERECO_RESPONSAVEL_ID_ATENDENTE));
                endereco.setCod_tipo_endereco_fk(leitor.GetInt32(ENDERECO_RESPONSAVEL_ID_TIPO));
                endereco.setTexto_endereco_responsavel(leitor.GetString(ENDERECO_RESPONSAVEL_TEXTO));
                endereco.setData_criacao_endereco(leitor.GetString(ENDERECO_RESPONSAVEL_DATA_CRIACAO));
                enderecos.Add(endereco);
            }
            leitor.Close();
            return enderecos;
        }

        public List<endereco_responsavel> selecionarEndereco_porTexto_igual(endereco_responsavel objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + ENDERECO_responsavel_TABELA + " WHERE " +
                ENDERECO_RESPONSAVEL_TEXTO + " = @Texto " +
                " AND " + ENDERECO_RESPONSAVEL_ID_TIPO + " = @Tipo " +
                " ORDER BY " + ENDERECO_RESPONSAVEL_CODIGO + " ASC ";
            Query.Parameters.AddWithValue("@Texto", objeto.getTexto_endereco_responsavel().ToString());
            Query.Parameters.AddWithValue("@Tipo", objeto.getCod_tipo_endereco_fk().ToString());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<endereco_responsavel> enderecos = new List<endereco_responsavel>();
            while (leitor.Read())
            {
                endereco_responsavel endereco = new endereco_responsavel();
                endereco.setCod_endereco_responsavel_pk(leitor.GetInt32(ENDERECO_RESPONSAVEL_CODIGO));
                endereco.setCod_responsavel_fk(leitor.GetInt32(ENDERECO_RESPONSAVEL_ID_RESPONSAVEL));
                endereco.setCod_atendente_fk(leitor.GetInt32(ENDERECO_RESPONSAVEL_ID_ATENDENTE));
                endereco.setCod_tipo_endereco_fk(leitor.GetInt32(ENDERECO_RESPONSAVEL_ID_TIPO));
                endereco.setTexto_endereco_responsavel(leitor.GetString(ENDERECO_RESPONSAVEL_TEXTO));
                endereco.setData_criacao_endereco(leitor.GetString(ENDERECO_RESPONSAVEL_DATA_CRIACAO));
                enderecos.Add(endereco);
            }
            leitor.Close();
            return enderecos;
        }
        #endregion
    }    
    
}
