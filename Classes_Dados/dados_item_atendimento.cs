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

    class dados_item_atendimento
    {
        //Tabela
        public const String ITEM_ATENDIMENTO_TABELA = "tab_item_atendimento";
        //Campos
        public const String
        ITEM_ATENDIMENTO_CODIGO = "cod_item_atendimento_pk",
        ITEM_ATENDIMENTO_ID_SERVICO = "cod_servico_fk",
        ITEM_ATENDIMENTO_ID_ATENDENTE = "cod_atendente_fk",
        ITEM_ATENDIMENTO_ID_ATENDIMENTO = "cod_atendimento_fk",
        ITEM_ATENDIMENTO_VALOR = "valor_combinado_item_atendimento",        
        ITEM_ATENDIMENTO_DETALHE = "detalhe_item_atendimento",
        ITEM_ATENDIMENTO_DATA_CRIACAO = "data_criacao_item_atendimento";
        //Campos

        //objetos banco
        MySqlCommand Query = new MySqlCommand();
        MySqlDataReader leitor;
        //objetos banco

        #region CADASTROS SIMPLES
        public Boolean cadastrarUmItem_atendimento(item_atendimento objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "INSERT INTO " + ITEM_ATENDIMENTO_TABELA + " (" +
                ITEM_ATENDIMENTO_ID_SERVICO+ "," +
                ITEM_ATENDIMENTO_ID_ATENDENTE + "," +
                ITEM_ATENDIMENTO_ID_ATENDIMENTO + "," +
                ITEM_ATENDIMENTO_DETALHE + "," +
                ITEM_ATENDIMENTO_VALOR + "," +
                ITEM_ATENDIMENTO_DATA_CRIACAO +
                ") values(@Cod_servico, @Cod_atendente, @Cod_at, @Det, @Valor, NOW() ) ";
            Query.Parameters.AddWithValue("@Cod_servico", objeto.getCod_servico_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_at", objeto.getCod_atendimento_fk().ToString());
            Query.Parameters.AddWithValue("@Det", objeto.getDetalhe_item_atendimento().ToString());
            Query.Parameters.AddWithValue("@Cod_atendente", objeto.getCod_atendente_fk().ToString());
            Query.Parameters.AddWithValue("@Valor", objeto.getValor_combinado_item_atendimento());
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

        #region ALTERAÇÃO
        public Boolean alterarUmItem_atendimento(item_atendimento objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "UPDATE " + ITEM_ATENDIMENTO_TABELA + " SET " +
                ITEM_ATENDIMENTO_ID_SERVICO + " = @Cod_servico, " +
                ITEM_ATENDIMENTO_ID_ATENDENTE + " = @Cod_atendente, " +
                ITEM_ATENDIMENTO_ID_ATENDIMENTO + " = @Cod_at, " +
                ITEM_ATENDIMENTO_DETALHE + " = @Det, " +
                ITEM_ATENDIMENTO_VALOR + " = @Valor " +
                " WHERE " + ITEM_ATENDIMENTO_CODIGO + " = @Cod_pk LIMIT 1";
            Query.Parameters.AddWithValue("@Cod_servico", objeto.getCod_servico_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_at", objeto.getCod_atendimento_fk().ToString());
            Query.Parameters.AddWithValue("@Det", objeto.getDetalhe_item_atendimento().ToString());
            Query.Parameters.AddWithValue("@Cod_atendente", objeto.getCod_atendente_fk().ToString());
            Query.Parameters.AddWithValue("@Valor", objeto.getValor_combinado_item_atendimento());
            Query.Parameters.AddWithValue("@Cod_pk", objeto.getCod_item_atendimento_pk());
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

        #region BUSCA SIMPLES
        public List<item_atendimento> selecionarTodosItem_atendimento()
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + ITEM_ATENDIMENTO_TABELA + " ";
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<item_atendimento> items_atendimento = new List<item_atendimento>();
            while (leitor.Read())
            {
                item_atendimento item_atendimento = new item_atendimento();
                item_atendimento.setCod_item_atendimento_pk(leitor.GetInt32(ITEM_ATENDIMENTO_CODIGO));
                item_atendimento.setCod_atendimento_fk(leitor.GetInt32(ITEM_ATENDIMENTO_ID_ATENDIMENTO));
                item_atendimento.setCod_atendente_fk(leitor.GetInt32(ITEM_ATENDIMENTO_ID_ATENDENTE));
                item_atendimento.setDetalhe_item_atendimento(leitor.GetString(ITEM_ATENDIMENTO_DETALHE));
                item_atendimento.setCod_servico_fk(leitor.GetInt32(ITEM_ATENDIMENTO_ID_SERVICO));
                item_atendimento.setValor_combinado_item_atendimento(leitor.GetDouble(ITEM_ATENDIMENTO_VALOR));
                item_atendimento.setData_criacao_item(leitor.GetString(ITEM_ATENDIMENTO_DATA_CRIACAO));
                items_atendimento.Add(item_atendimento);
            }
            leitor.Close();
            return items_atendimento;
        }

        public item_atendimento selecionarUmItem_atendimento_porCodigo(item_atendimento objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + ITEM_ATENDIMENTO_TABELA + " WHERE "+ 
                ITEM_ATENDIMENTO_CODIGO +" = "+objeto.getCod_item_atendimento_pk()+" LIMIT 1 ";
            Query.Prepare();
            leitor = Query.ExecuteReader();
            item_atendimento item_atendimento = new item_atendimento();            
            while (leitor.Read())
            {                
                item_atendimento.setCod_item_atendimento_pk(leitor.GetInt32(ITEM_ATENDIMENTO_CODIGO));
                item_atendimento.setCod_atendente_fk(leitor.GetInt32(ITEM_ATENDIMENTO_ID_ATENDENTE));
                item_atendimento.setCod_atendimento_fk(leitor.GetInt32(ITEM_ATENDIMENTO_ID_ATENDIMENTO));
                item_atendimento.setDetalhe_item_atendimento(leitor.GetString(ITEM_ATENDIMENTO_DETALHE));
                item_atendimento.setCod_servico_fk(leitor.GetInt32(ITEM_ATENDIMENTO_ID_SERVICO));
                item_atendimento.setValor_combinado_item_atendimento(leitor.GetDouble(ITEM_ATENDIMENTO_VALOR));
                item_atendimento.setData_criacao_item(leitor.GetString(ITEM_ATENDIMENTO_DATA_CRIACAO));
            }
            leitor.Close();
            return item_atendimento;
        }

        public List<item_atendimento> selecionarTodosItem_atendimento_porCodigoAtendimento(item_atendimento objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + ITEM_ATENDIMENTO_TABELA + " WHERE "+ 
                ITEM_ATENDIMENTO_ID_ATENDIMENTO +" = "+objeto.getCod_atendimento_fk()+" ";
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<item_atendimento>  items_atendimento = new List<item_atendimento>();                       
            while (leitor.Read())
            {           
                item_atendimento item_atendimento = new item_atendimento();
                item_atendimento.setCod_item_atendimento_pk(leitor.GetInt32(ITEM_ATENDIMENTO_CODIGO));
                item_atendimento.setCod_atendimento_fk(leitor.GetInt32(ITEM_ATENDIMENTO_ID_ATENDIMENTO));
                item_atendimento.setCod_atendente_fk(leitor.GetInt32(ITEM_ATENDIMENTO_ID_ATENDENTE));
                item_atendimento.setDetalhe_item_atendimento(leitor.GetString(ITEM_ATENDIMENTO_DETALHE));
                item_atendimento.setCod_servico_fk(leitor.GetInt32(ITEM_ATENDIMENTO_ID_SERVICO));
                item_atendimento.setValor_combinado_item_atendimento(leitor.GetDouble(ITEM_ATENDIMENTO_VALOR));
                item_atendimento.setData_criacao_item(leitor.GetString(ITEM_ATENDIMENTO_DATA_CRIACAO));
                items_atendimento.Add(item_atendimento);
            }
            leitor.Close();
            return items_atendimento;
        }

        public List<item_atendimento> selecionarTodosItem_atendimento_porCodigo_servico(item_atendimento objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + ITEM_ATENDIMENTO_TABELA + " WHERE " +
                ITEM_ATENDIMENTO_ID_SERVICO+ " = " + objeto.getCod_servico_fk() + " ";
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<item_atendimento> items_atendimento = new List<item_atendimento>();
            while (leitor.Read())
            {
                item_atendimento item_atendimento = new item_atendimento();
                item_atendimento.setCod_item_atendimento_pk(leitor.GetInt32(ITEM_ATENDIMENTO_CODIGO));
                item_atendimento.setCod_atendimento_fk(leitor.GetInt32(ITEM_ATENDIMENTO_ID_ATENDIMENTO));
                item_atendimento.setCod_atendente_fk(leitor.GetInt32(ITEM_ATENDIMENTO_ID_ATENDENTE));
                item_atendimento.setDetalhe_item_atendimento(leitor.GetString(ITEM_ATENDIMENTO_DETALHE));
                item_atendimento.setCod_servico_fk(leitor.GetInt32(ITEM_ATENDIMENTO_ID_SERVICO));
                item_atendimento.setValor_combinado_item_atendimento(leitor.GetDouble(ITEM_ATENDIMENTO_VALOR));
                item_atendimento.setData_criacao_item(leitor.GetString(ITEM_ATENDIMENTO_DATA_CRIACAO));
                items_atendimento.Add(item_atendimento);
            }
            leitor.Close();
            return items_atendimento;
        }

        public List<item_atendimento> selecionarTodosItem_atendimento_porCodigo_Serviço_somandoValor_agrupadoPorCod_atendimento(item_atendimento objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT " +
                ITEM_ATENDIMENTO_CODIGO + "," +
                ITEM_ATENDIMENTO_ID_ATENDENTE + "," +
                ITEM_ATENDIMENTO_ID_ATENDIMENTO + "," +
                ITEM_ATENDIMENTO_ID_SERVICO + ",SUM(" +
                ITEM_ATENDIMENTO_VALOR + ")," +
                ITEM_ATENDIMENTO_DATA_CRIACAO + "," +
                ITEM_ATENDIMENTO_DETALHE + "," + 
                " FROM " + ITEM_ATENDIMENTO_TABELA + " WHERE " +
                ITEM_ATENDIMENTO_ID_SERVICO + " = " + objeto.getCod_servico_fk() + " GROUP BY "+ITEM_ATENDIMENTO_ID_ATENDIMENTO;
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<item_atendimento> items_atendimento = new List<item_atendimento>();
            while (leitor.Read())
            {
                item_atendimento item_atendimento = new item_atendimento();
                item_atendimento.setCod_item_atendimento_pk(leitor.GetInt32(ITEM_ATENDIMENTO_CODIGO));
                item_atendimento.setCod_atendimento_fk(leitor.GetInt32(ITEM_ATENDIMENTO_ID_ATENDIMENTO));
                item_atendimento.setCod_atendente_fk(leitor.GetInt32(ITEM_ATENDIMENTO_ID_ATENDENTE));
                item_atendimento.setDetalhe_item_atendimento(leitor.GetString(ITEM_ATENDIMENTO_DETALHE));
                item_atendimento.setCod_servico_fk(leitor.GetInt32(ITEM_ATENDIMENTO_ID_SERVICO));
                item_atendimento.setValor_combinado_item_atendimento(leitor.GetDouble(ITEM_ATENDIMENTO_VALOR));
                item_atendimento.setData_criacao_item(leitor.GetString(ITEM_ATENDIMENTO_DATA_CRIACAO));
                items_atendimento.Add(item_atendimento);
            }
            leitor.Close();
            return items_atendimento;
        }

        public item_atendimento selecionarUltimoItem_atendimento_acabouDeCadastrar()
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + ITEM_ATENDIMENTO_TABELA +
                " WHERE " + ITEM_ATENDIMENTO_CODIGO + " = LAST_INSERT_ID() LIMIT 1";            
            Query.Prepare();
            leitor = Query.ExecuteReader();
            item_atendimento item_atendimento = new item_atendimento();
            while (leitor.Read())
            {
                item_atendimento.setCod_item_atendimento_pk(leitor.GetInt32(ITEM_ATENDIMENTO_CODIGO));
                item_atendimento.setCod_atendimento_fk(leitor.GetInt32(ITEM_ATENDIMENTO_ID_ATENDIMENTO));
                item_atendimento.setCod_atendente_fk(leitor.GetInt32(ITEM_ATENDIMENTO_ID_ATENDENTE));
                item_atendimento.setDetalhe_item_atendimento(leitor.GetString(ITEM_ATENDIMENTO_DETALHE));
                item_atendimento.setCod_servico_fk(leitor.GetInt32(ITEM_ATENDIMENTO_ID_SERVICO));
                item_atendimento.setValor_combinado_item_atendimento(leitor.GetDouble(ITEM_ATENDIMENTO_VALOR));
                item_atendimento.setData_criacao_item(leitor.GetString(ITEM_ATENDIMENTO_DATA_CRIACAO));
            }
            leitor.Close();
            return item_atendimento;
        }
        #endregion

        #region DELETAR SIMPLES
        public Boolean deletarTodosItems_atendimento_excetoIds(List<item_atendimento> objetos)
        {
            //extraio os ids!
            List<int> itemsLista = objetos.Select(item_atendimento => item_atendimento.getCod_item_atendimento_pk()).ToList();
            //separo por virgulas!
            var ids = string.Join(",", itemsLista.Select(i => i.ToString()).ToArray());
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "DELETE FROM " + ITEM_ATENDIMENTO_TABELA + " WHERE " +
                ITEM_ATENDIMENTO_CODIGO + " NOT IN(" + ids + ") AND "+ITEM_ATENDIMENTO_ID_ATENDIMENTO+" = @Cod_atendimento";
            Query.Parameters.AddWithValue("@Cod_atendimento", objetos[0].getCod_atendimento_fk().ToString());
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
       
    }
}
