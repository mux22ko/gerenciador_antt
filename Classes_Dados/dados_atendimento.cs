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

    class dados_atendimento
    {
        #region DADOS
        //Tabela
        public const String ATENDIMENTO_TABELA = "tab_atendimento";
        //Campos
        public const String
        ATENDIMENTO_CODIGO = "cod_atendimento_pk",
        ATENDIMENTO_CODIGO_CLIENTE = "cod_cliente_fk",
        ATENDIMENTO_CODIGO_RESPONSAVEL = "cod_responsavel_fk",
        ATENDIMENTO_ESTADO_PAGO = "estado_pago_atendimento",
        ATENDIMENTO_ESTADO_FINALIZADO = "estado_finalizado_atendimento",
        ATENDIMENTO_ATIVO = "estado_ativo_atendimento",
        ATENDIMENTO_CODIGO_ATENDENTE = "cod_atendente_fk",
        ATENDIMENTO_OBSERVACAO = "observacao_atendimento",
        ATENDIMENTO_DATA_CRIACAO = "data_criacao_atendimento";
        //Campos

        //objetos banco
        MySqlCommand Query = new MySqlCommand();
        MySqlDataReader leitor;
        //objetos banco
        #endregion

        #region CADASTROS SIMPLES
        public Boolean cadastrarUmAtendimento(atendimento objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "INSERT INTO " + ATENDIMENTO_TABELA + " (" +
                ATENDIMENTO_CODIGO_CLIENTE + "," +
                ATENDIMENTO_CODIGO_RESPONSAVEL + "," +
                ATENDIMENTO_CODIGO_ATENDENTE + "," +
                ATENDIMENTO_OBSERVACAO + "," +
                ATENDIMENTO_ESTADO_PAGO + "," +
                ATENDIMENTO_ESTADO_FINALIZADO + "," +
                ATENDIMENTO_DATA_CRIACAO +
                ") values(@Cod_cliente, @Cod_resp, @Cod_atendente, @Obs, @Pago, @Finalizado, NOW() ) ";
            Query.Parameters.AddWithValue("@Cod_cliente", objeto.getCod_cliente_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_resp", objeto.getCod_responsavel_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_atendente", objeto.getCod_atendente_fk().ToString());
            Query.Parameters.AddWithValue("@Obs", objeto.getObservacao_atendimento().ToString());
            Query.Parameters.AddWithValue("@Pago", objeto.getEstado_pago_atendimento().ToString());
            Query.Parameters.AddWithValue("@Finalizado", objeto.getEstado_finalizado_atendimento().ToString());
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
        public Boolean alterarUmAtendimento(atendimento objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "UPDATE " + ATENDIMENTO_TABELA + " SET " +
                ATENDIMENTO_CODIGO_CLIENTE + " = @Cod_cliente, " +
                ATENDIMENTO_CODIGO_RESPONSAVEL + " = @Cod_resp," +
                ATENDIMENTO_CODIGO_ATENDENTE + " = @Cod_atendente," +
                ATENDIMENTO_OBSERVACAO + " = @Obs," +
                ATENDIMENTO_ESTADO_PAGO + " = @Pago," +
                ATENDIMENTO_ESTADO_FINALIZADO + " = @Finalizado " +
                "WHERE "+
                ATENDIMENTO_CODIGO + " = @Cod_pk LIMIT 1 ";
            Query.Parameters.AddWithValue("@Cod_cliente", objeto.getCod_cliente_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_resp", objeto.getCod_responsavel_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_atendente", objeto.getCod_atendente_fk().ToString());
            Query.Parameters.AddWithValue("@Obs", objeto.getObservacao_atendimento().ToString());
            Query.Parameters.AddWithValue("@Pago", objeto.getEstado_pago_atendimento().ToString());
            Query.Parameters.AddWithValue("@Finalizado", objeto.getEstado_finalizado_atendimento().ToString());
            Query.Parameters.AddWithValue("@Cod_pk", objeto.getCod_atendimento_pk().ToString());
            
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
        public atendimento selecionarUmAtendimento_porCodigo(atendimento objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + ATENDIMENTO_TABELA + " WHERE "+ 
                ATENDIMENTO_CODIGO +" = "+objeto.getCod_atendimento_pk()+" LIMIT 1 ";
            Query.Prepare();
            leitor = Query.ExecuteReader();
            atendimento atendimento = new atendimento();            
            while (leitor.Read())
            {                
                atendimento.setCod_atendimento_pk(leitor.GetInt32(ATENDIMENTO_CODIGO));
                atendimento.setCod_cliente_fk(leitor.GetInt32(ATENDIMENTO_CODIGO_CLIENTE));
                atendimento.setCod_atendente_fk(leitor.GetInt32(ATENDIMENTO_CODIGO_ATENDENTE));
                atendimento.setCod_responsavel_fk(leitor.GetInt32(ATENDIMENTO_CODIGO_RESPONSAVEL));
                atendimento.setObservacao_atendimento(leitor.GetString(ATENDIMENTO_OBSERVACAO));
                atendimento.setEstado_ativo_atendimento(leitor.GetChar(ATENDIMENTO_ATIVO));
                atendimento.setEstado_finalizado_atendimento(leitor.GetChar(ATENDIMENTO_ESTADO_FINALIZADO));
                atendimento.setEstado_pago_atendimento(leitor.GetChar(ATENDIMENTO_ESTADO_PAGO));
                atendimento.setData_criacao_atendimento(leitor.GetString(ATENDIMENTO_DATA_CRIACAO));
            }
            leitor.Close();
            return atendimento;
        }
        public atendimento selecionarUltimoAtendimento_acabouDeCadastrar()
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + ATENDIMENTO_TABELA + " WHERE "
                + ATENDIMENTO_CODIGO + " = LAST_INSERT_ID() LIMIT 1";
            Query.Prepare();
            leitor = Query.ExecuteReader();
            atendimento atendimento = new atendimento();
            while (leitor.Read())
            {
                atendimento.setCod_atendimento_pk(leitor.GetInt32(ATENDIMENTO_CODIGO));
                atendimento.setCod_cliente_fk(leitor.GetInt32(ATENDIMENTO_CODIGO_CLIENTE));
                atendimento.setCod_atendente_fk(leitor.GetInt32(ATENDIMENTO_CODIGO_ATENDENTE));
                atendimento.setCod_responsavel_fk(leitor.GetInt32(ATENDIMENTO_CODIGO_RESPONSAVEL));
                atendimento.setObservacao_atendimento(leitor.GetString(ATENDIMENTO_OBSERVACAO));
                atendimento.setEstado_ativo_atendimento(leitor.GetChar(ATENDIMENTO_ATIVO));
                atendimento.setEstado_finalizado_atendimento(leitor.GetChar(ATENDIMENTO_ESTADO_FINALIZADO));
                atendimento.setEstado_pago_atendimento(leitor.GetChar(ATENDIMENTO_ESTADO_PAGO));
                atendimento.setData_criacao_atendimento(leitor.GetString(ATENDIMENTO_DATA_CRIACAO));
            }
            leitor.Close();
            return atendimento;
        }
        #endregion

        #region BUSCA DINAMICA POR TERMOS
        public List<atendimento> selecionarTodosAtendimentos_ativo_porBusca_igual(atendimento atendimento_obj)
        {            
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + ATENDIMENTO_TABELA + " WHERE " + ATENDIMENTO_ATIVO + " ='s' ";

            if (atendimento_obj.getCod_atendimento_pk() > 0)
            {
                Query.CommandText += " AND " + ATENDIMENTO_CODIGO + " = @Codigo ";
                Query.Parameters.AddWithValue("@Codigo", atendimento_obj.getCod_atendimento_pk().ToString());
            }
            if (atendimento_obj.getCod_cliente_fk() > 0)
            {
                Query.CommandText += " AND " + ATENDIMENTO_CODIGO_CLIENTE + " = @Cliente ";
                Query.Parameters.AddWithValue("@Cliente", atendimento_obj.getCod_cliente_fk().ToString());
            }
            if (atendimento_obj.getCod_responsavel_fk() > 0)
            {
                Query.CommandText += " AND " + ATENDIMENTO_CODIGO_RESPONSAVEL + " = @Resp ";
                Query.Parameters.AddWithValue("@Resp", atendimento_obj.getCod_responsavel_fk().ToString());
            }
            if ((atendimento_obj.getData_criacao_atendimento() != String.Empty) && (atendimento_obj.getData_criacao_atendimento() != null))
            {
                Query.CommandText += " AND DATE(" + ATENDIMENTO_DATA_CRIACAO + ") = @DataCriacao ";
                Query.Parameters.AddWithValue("@DataCriacao", atendimento_obj.getData_criacao_atendimento());
            }
            if (atendimento_obj.getCod_atendente_fk() > 0)
            {
                Query.CommandText += " AND " + ATENDIMENTO_CODIGO_ATENDENTE + " = @Atendente ";
                Query.Parameters.AddWithValue("@Atendente", atendimento_obj.getCod_atendente_fk());
            }
            if ((atendimento_obj.getObservacao_atendimento() != String.Empty) && (atendimento_obj.getObservacao_atendimento() != null))
            {
                Query.CommandText += " AND " + ATENDIMENTO_OBSERVACAO + " = @Obs ";
                Query.Parameters.AddWithValue("@Obs", atendimento_obj.getObservacao_atendimento());
            }
            if ((!(atendimento_obj.getEstado_pago_atendimento().Equals('\0'))))
            {
                Query.CommandText += " AND " +ATENDIMENTO_ESTADO_PAGO + " = @Pago ";
                Query.Parameters.AddWithValue("@Pago", atendimento_obj.getEstado_pago_atendimento());
            }
            if ((!(atendimento_obj.getEstado_finalizado_atendimento().Equals('\0'))))
            {
                Query.CommandText += " AND " + ATENDIMENTO_ESTADO_FINALIZADO + " = @Fim ";
                Query.Parameters.AddWithValue("@Fim", atendimento_obj.getEstado_finalizado_atendimento());
            }                 
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<atendimento> atendimentos = new List<atendimento>();
            while (leitor.Read())
            {
                atendimento atendimento = new atendimento();
                //capto os dados do cliente selecionado!
                atendimento.setCod_atendimento_pk(leitor.GetInt32(ATENDIMENTO_CODIGO));
                atendimento.setCod_cliente_fk(leitor.GetInt32(ATENDIMENTO_CODIGO_CLIENTE));
                atendimento.setCod_atendente_fk(leitor.GetInt32(ATENDIMENTO_CODIGO_ATENDENTE));
                atendimento.setCod_responsavel_fk(leitor.GetInt32(ATENDIMENTO_CODIGO_RESPONSAVEL));
                atendimento.setObservacao_atendimento(leitor.GetString(ATENDIMENTO_OBSERVACAO));
                atendimento.setEstado_ativo_atendimento(leitor.GetChar(ATENDIMENTO_ATIVO));
                atendimento.setEstado_finalizado_atendimento(leitor.GetChar(ATENDIMENTO_ESTADO_FINALIZADO));
                atendimento.setEstado_pago_atendimento(leitor.GetChar(ATENDIMENTO_ESTADO_PAGO));
                atendimento.setData_criacao_atendimento(leitor.GetString(ATENDIMENTO_DATA_CRIACAO));
                //adiciono!
                atendimentos.Add(atendimento);
            }
            leitor.Close();
            return atendimentos;
        }

        public List<atendimento> selecionarTodosAtendimentos_ativo_porBusca_contem(atendimento atendimento_obj)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + ATENDIMENTO_TABELA + " WHERE " + ATENDIMENTO_ATIVO + " ='s' ";

            if (atendimento_obj.getCod_atendimento_pk() > 0)
            {
                Query.CommandText += " AND " + ATENDIMENTO_CODIGO + " LIKE @Codigo ";
                Query.Parameters.AddWithValue("@Codigo", atendimento_obj.getCod_atendimento_pk().ToString());
            }
            if (atendimento_obj.getCod_cliente_fk() > 0)
            {
                Query.CommandText += " AND " + ATENDIMENTO_CODIGO_CLIENTE + " = @Cliente ";
                Query.Parameters.AddWithValue("@Cliente", atendimento_obj.getCod_cliente_fk().ToString());
            }
            if (atendimento_obj.getCod_responsavel_fk() > 0)
            {
                Query.CommandText += " AND " + ATENDIMENTO_CODIGO_RESPONSAVEL + " = @Resp ";
                Query.Parameters.AddWithValue("@Resp", atendimento_obj.getCod_responsavel_fk().ToString());
            }
            if ((atendimento_obj.getData_criacao_atendimento() != String.Empty) && (atendimento_obj.getData_criacao_atendimento() != null))
            {
                Query.CommandText += " AND DATE(" + ATENDIMENTO_DATA_CRIACAO + ") = @DataCriacao ";
                Query.Parameters.AddWithValue("@DataCriacao", atendimento_obj.getData_criacao_atendimento());
            }
            if (atendimento_obj.getCod_atendente_fk() > 0)
            {
                Query.CommandText += " AND " + ATENDIMENTO_CODIGO_ATENDENTE + " = @Atendente ";
                Query.Parameters.AddWithValue("@Atendente", atendimento_obj.getCod_atendente_fk());
            }
            if ((atendimento_obj.getObservacao_atendimento() != String.Empty) && (atendimento_obj.getObservacao_atendimento() != null))
            {
                Query.CommandText += " AND " + ATENDIMENTO_OBSERVACAO + " LIKE @Obs ";
                Query.Parameters.AddWithValue("@Obs", atendimento_obj.getObservacao_atendimento());
            }
            if ((!(atendimento_obj.getEstado_pago_atendimento().Equals('\0'))))
            {
                Query.CommandText += " AND " + ATENDIMENTO_ESTADO_PAGO + " = @Pago ";
                Query.Parameters.AddWithValue("@Pago", atendimento_obj.getEstado_pago_atendimento());
            }
            if ((!(atendimento_obj.getEstado_finalizado_atendimento().Equals('\0'))))
            {
                Query.CommandText += " AND " + ATENDIMENTO_ESTADO_FINALIZADO + " = @Fim ";
                Query.Parameters.AddWithValue("@Fim", atendimento_obj.getEstado_finalizado_atendimento());
            }
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<atendimento> atendimentos = new List<atendimento>();
            while (leitor.Read())
            {
                atendimento atendimento = new atendimento();
                //capto os dados do cliente selecionado!
                atendimento.setCod_atendimento_pk(leitor.GetInt32(ATENDIMENTO_CODIGO));
                atendimento.setCod_cliente_fk(leitor.GetInt32(ATENDIMENTO_CODIGO_CLIENTE));
                atendimento.setCod_atendente_fk(leitor.GetInt32(ATENDIMENTO_CODIGO_ATENDENTE));
                atendimento.setCod_responsavel_fk(leitor.GetInt32(ATENDIMENTO_CODIGO_RESPONSAVEL));
                atendimento.setObservacao_atendimento(leitor.GetString(ATENDIMENTO_OBSERVACAO));
                atendimento.setEstado_ativo_atendimento(leitor.GetChar(ATENDIMENTO_ATIVO));
                atendimento.setEstado_finalizado_atendimento(leitor.GetChar(ATENDIMENTO_ESTADO_FINALIZADO));
                atendimento.setEstado_pago_atendimento(leitor.GetChar(ATENDIMENTO_ESTADO_PAGO));
                atendimento.setData_criacao_atendimento(leitor.GetString(ATENDIMENTO_DATA_CRIACAO));
                //adiciono!
                atendimentos.Add(atendimento);
            }
            leitor.Close();
            return atendimentos;
        }        
        #endregion
    }
}
