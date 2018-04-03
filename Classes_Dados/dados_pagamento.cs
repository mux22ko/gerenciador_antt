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

    class dados_pagamento
    {
        #region DADOS
        //Tabela
        public const String PAGAMENTO_TABELA = "tab_pagamento";
        //Campos
        public const String
        PAGAMENTO_CODIGO = "cod_pagamento_pk",
        PAGAMENTO_CODIGO_MEIO_PAGAMENTO = "cod_meio_pgto_fk",
        PAGAMENTO_VALOR = "valor_pagamento", 
        PAGAMENTO_TROCO = "troco_pagamento",
        PAGAMENTO_ATIVO = "estado_ativo_pagamento",
        PAGAMENTO_CODIGO_ATENDENTE = "cod_atendente_fk",
        PAGAMENTO_OBSERVACAO = "observacao_pagamento",
        PAGAMENTO_DATA_CRIACAO = "data_criacao_pagamento",
        PAGAMENTO_DATA_ALTERACAO = "data_alteracao_pagamento";
        //Campos

        //objetos banco
        MySqlCommand Query = new MySqlCommand();
        MySqlDataReader leitor;
        //objetos banco
        #endregion

        #region CADASTROS SIMPLES
        public Boolean cadastrarUmPagamento(pagamento objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "INSERT INTO " + PAGAMENTO_TABELA + " (" +
                PAGAMENTO_CODIGO + "," +
                PAGAMENTO_CODIGO_MEIO_PAGAMENTO + "," +
                PAGAMENTO_CODIGO_ATENDENTE + "," +
                PAGAMENTO_VALOR + "," +
                PAGAMENTO_TROCO + "," +
                PAGAMENTO_OBSERVACAO + "," +                
                PAGAMENTO_DATA_CRIACAO + "," +
                PAGAMENTO_DATA_ALTERACAO +
                ") values(@Cod_pagamento, @Cod_meiopg, @Cod_atendente, @Valor, @Troco, @Obs, NOW(), NOW()) ";
            Query.Parameters.AddWithValue("@Cod_pagamento", objeto.getCod_pagamento_pk().ToString());
            Query.Parameters.AddWithValue("@Cod_meiopg", objeto.getCod_meio_pgto_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_atendente", objeto.getCod_atendente_fk().ToString());
            Query.Parameters.AddWithValue("@Troco", (objeto.getTroco_pagamento()));    
            Query.Parameters.AddWithValue("@Valor", objeto.getValor_pagamento());
            Query.Parameters.AddWithValue("@Obs", objeto.getObservacao_pagamento().ToString());          
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
        public Boolean alterarUmPagamento(pagamento objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "UPDATE " + PAGAMENTO_TABELA + " SET " +
                PAGAMENTO_CODIGO_MEIO_PAGAMENTO + " = @Cod_meiopg, " +
                PAGAMENTO_CODIGO_ATENDENTE + " = @Cod_atendente, " +
                PAGAMENTO_VALOR + " = @Valor, " +
                PAGAMENTO_TROCO + " = @Troco, " +
                PAGAMENTO_OBSERVACAO + " = @Obs, " +
                PAGAMENTO_DATA_ALTERACAO + " = NOW() " +
                " WHERE " + PAGAMENTO_CODIGO + " = @Codigo LIMIT 1";
            Query.Parameters.AddWithValue("@Cod_meiopg", objeto.getCod_meio_pgto_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_atendente", objeto.getCod_atendente_fk().ToString());
            Query.Parameters.AddWithValue("@Troco", (objeto.getTroco_pagamento()));
            Query.Parameters.AddWithValue("@Valor", objeto.getValor_pagamento());
            Query.Parameters.AddWithValue("@Obs", objeto.getObservacao_pagamento().ToString());
            Query.Parameters.AddWithValue("@Codigo", objeto.getCod_pagamento_pk().ToString());
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
        public pagamento selecionarUmPagamento_porCodigo(pagamento objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + PAGAMENTO_TABELA + " WHERE " +
                PAGAMENTO_CODIGO + " = " + objeto.getCod_pagamento_pk() + " LIMIT 1 ";
            Query.Prepare();
            leitor = Query.ExecuteReader();
            pagamento pagamento = new pagamento();            
            while (leitor.Read())
            {                
                pagamento.setCod_pagamento_pk(leitor.GetInt32(PAGAMENTO_CODIGO));
                pagamento.setCod_meio_pgto_fk(leitor.GetInt32(PAGAMENTO_CODIGO_MEIO_PAGAMENTO));
                pagamento.setCod_atendente_fk(leitor.GetInt32(PAGAMENTO_CODIGO_ATENDENTE));
                pagamento.setData_alteracao_pagamento(leitor.GetString(PAGAMENTO_DATA_ALTERACAO));
                pagamento.setData_criacao_pagamento(leitor.GetString(PAGAMENTO_DATA_CRIACAO));
                pagamento.setObservacao_pagamento(leitor.GetString(PAGAMENTO_OBSERVACAO));
                pagamento.setEstado_ativo_pagamento(leitor.GetChar(PAGAMENTO_ATIVO));
                pagamento.setTroco_pagamento(leitor.GetDouble(PAGAMENTO_TROCO));
                pagamento.setValor_pagamento(leitor.GetDouble(PAGAMENTO_VALOR));
            }
            leitor.Close();
            return pagamento;
        }

        public pagamento selecionarUltimoPagamento_acabouDeCadastrar()
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + PAGAMENTO_TABELA + " WHERE "
                + PAGAMENTO_CODIGO + " = LAST_INSERT_ID() LIMIT 1";
            leitor = Query.ExecuteReader();
            pagamento pagamento = new pagamento();            
            while (leitor.Read())
            {
                pagamento.setCod_pagamento_pk(leitor.GetInt32(PAGAMENTO_CODIGO));
                pagamento.setCod_meio_pgto_fk(leitor.GetInt32(PAGAMENTO_CODIGO_MEIO_PAGAMENTO));
                pagamento.setCod_atendente_fk(leitor.GetInt32(PAGAMENTO_CODIGO_ATENDENTE));                    
                pagamento.setObservacao_pagamento(leitor.GetString(PAGAMENTO_OBSERVACAO));
                pagamento.setEstado_ativo_pagamento(leitor.GetChar(PAGAMENTO_ATIVO));
                pagamento.setTroco_pagamento(leitor.GetDouble(PAGAMENTO_TROCO));
                pagamento.setValor_pagamento(leitor.GetDouble(PAGAMENTO_VALOR));
                pagamento.setData_alteracao_pagamento(leitor.GetString(PAGAMENTO_DATA_ALTERACAO));
                pagamento.setData_criacao_pagamento(leitor.GetString(PAGAMENTO_DATA_CRIACAO));
            }           
            leitor.Close();
            return pagamento;
        }
        #endregion

        #region BUSCA DINAMICA POR TERMOS
        public List<pagamento> selecionarTodosPagamentos_ativo_porBusca_igual(pagamento pagamento_obj)
        {            
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + PAGAMENTO_TABELA + " WHERE " + PAGAMENTO_ATIVO + " ='s' ";

            if (pagamento_obj.getCod_pagamento_pk() > 0)
            {
                Query.CommandText += " AND " + PAGAMENTO_CODIGO + " = @Codigo ";
                Query.Parameters.AddWithValue("@Codigo", pagamento_obj.getCod_pagamento_pk().ToString());
            }    
            if (pagamento_obj.getTroco_pagamento() > 0)
            {
                Query.CommandText += " AND " + PAGAMENTO_TROCO + " = @Troco ";
                Query.Parameters.AddWithValue("@Troco", pagamento_obj.getTroco_pagamento());
            }
            if (pagamento_obj.getValor_pagamento() > 0)
            {
                Query.CommandText += " AND " + PAGAMENTO_VALOR + " = @Valor ";
                Query.Parameters.AddWithValue("@Valor", pagamento_obj.getValor_pagamento());
            } 
            if ((pagamento_obj.getData_criacao_pagamento() != String.Empty) && (pagamento_obj.getData_criacao_pagamento() != null))
            {
                Query.CommandText += " AND DATE(" + PAGAMENTO_DATA_CRIACAO + ") = @DataCriacao ";
                Query.Parameters.AddWithValue("@DataCriacao", pagamento_obj.getData_criacao_pagamento());
            }
            if (pagamento_obj.getCod_atendente_fk() > 0)
            {
                Query.CommandText += " AND " + PAGAMENTO_CODIGO_ATENDENTE + " = @Atendente ";
                Query.Parameters.AddWithValue("@Atendente", pagamento_obj.getCod_atendente_fk());
            }
            if (pagamento_obj.getCod_meio_pgto_fk() > 0)
            {
                Query.CommandText += " AND " + PAGAMENTO_CODIGO_MEIO_PAGAMENTO+ " = @Meio ";
                Query.Parameters.AddWithValue("@Meio", pagamento_obj.getCod_meio_pgto_fk());
            }
            if ((pagamento_obj.getObservacao_pagamento() != String.Empty) && (pagamento_obj.getObservacao_pagamento() != null))
            {
                Query.CommandText += " AND " + PAGAMENTO_OBSERVACAO + " = @Obs ";
                Query.Parameters.AddWithValue("@Obs", pagamento_obj.getObservacao_pagamento());
            }
            if ((pagamento_obj.getData_alteracao_pagamento() != String.Empty) && (pagamento_obj.getData_alteracao_pagamento() != null))
            {
                Query.CommandText += " AND " + PAGAMENTO_DATA_ALTERACAO + " != " + PAGAMENTO_DATA_CRIACAO;
            }
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<pagamento> pagamentos = new List<pagamento>();
            while (leitor.Read())
            {
                pagamento pagamento = new pagamento();
                pagamento.setCod_pagamento_pk(leitor.GetInt32(PAGAMENTO_CODIGO));
                pagamento.setCod_meio_pgto_fk(leitor.GetInt32(PAGAMENTO_CODIGO_MEIO_PAGAMENTO));
                pagamento.setCod_atendente_fk(leitor.GetInt32(PAGAMENTO_CODIGO_ATENDENTE));
                pagamento.setData_alteracao_pagamento(leitor.GetString(PAGAMENTO_DATA_ALTERACAO));
                pagamento.setData_criacao_pagamento(leitor.GetString(PAGAMENTO_DATA_CRIACAO));
                pagamento.setObservacao_pagamento(leitor.GetString(PAGAMENTO_OBSERVACAO));
                pagamento.setEstado_ativo_pagamento(leitor.GetChar(PAGAMENTO_ATIVO));
                pagamento.setTroco_pagamento(leitor.GetDouble(PAGAMENTO_TROCO));
                pagamento.setValor_pagamento(leitor.GetDouble(PAGAMENTO_VALOR));
                pagamentos.Add(pagamento);
            }
            leitor.Close();
            return pagamentos;
        }

        public List<pagamento> selecionarTodosPagamentos_desativo_porBusca_igual(pagamento pagamento_obj)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + PAGAMENTO_TABELA + " WHERE " + PAGAMENTO_ATIVO + " ='n' ";

            if (pagamento_obj.getCod_pagamento_pk() > 0)
            {
                Query.CommandText += " AND " + PAGAMENTO_CODIGO + " = @Codigo ";
                Query.Parameters.AddWithValue("@Codigo", pagamento_obj.getCod_pagamento_pk().ToString());
            }
            if (pagamento_obj.getTroco_pagamento() > 0)
            {
                Query.CommandText += " AND " + PAGAMENTO_TROCO + " = @Troco ";
                Query.Parameters.AddWithValue("@Troco", pagamento_obj.getTroco_pagamento());
            }
            if (pagamento_obj.getValor_pagamento() > 0)
            {
                Query.CommandText += " AND " + PAGAMENTO_VALOR + " = @Valor ";
                Query.Parameters.AddWithValue("@Valor", pagamento_obj.getValor_pagamento());
            }
            if ((pagamento_obj.getData_criacao_pagamento() != String.Empty) && (pagamento_obj.getData_criacao_pagamento() != null))
            {
                Query.CommandText += " AND DATE(" + PAGAMENTO_DATA_CRIACAO + ") = @DataCriacao ";
                Query.Parameters.AddWithValue("@DataCriacao", pagamento_obj.getData_criacao_pagamento());
            }
            if (pagamento_obj.getCod_atendente_fk() > 0)
            {
                Query.CommandText += " AND " + PAGAMENTO_CODIGO_ATENDENTE + " = @Atendente ";
                Query.Parameters.AddWithValue("@Atendente", pagamento_obj.getCod_atendente_fk());
            }
            if (pagamento_obj.getCod_meio_pgto_fk() > 0)
            {
                Query.CommandText += " AND " + PAGAMENTO_CODIGO_MEIO_PAGAMENTO + " = @Meio ";
                Query.Parameters.AddWithValue("@Meio", pagamento_obj.getCod_meio_pgto_fk());
            }
            if ((pagamento_obj.getObservacao_pagamento() != String.Empty) && (pagamento_obj.getObservacao_pagamento() != null))
            {
                Query.CommandText += " AND " + PAGAMENTO_OBSERVACAO + " = @Obs ";
                Query.Parameters.AddWithValue("@Obs", pagamento_obj.getObservacao_pagamento());
            }
            if ((pagamento_obj.getData_alteracao_pagamento() != String.Empty) && (pagamento_obj.getData_alteracao_pagamento() != null))
            {
                Query.CommandText += " AND " + PAGAMENTO_DATA_ALTERACAO + " != " + PAGAMENTO_DATA_CRIACAO;
            }
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<pagamento> pagamentos = new List<pagamento>();
            while (leitor.Read())
            {
                pagamento pagamento = new pagamento();
                pagamento.setCod_pagamento_pk(leitor.GetInt32(PAGAMENTO_CODIGO));
                pagamento.setCod_meio_pgto_fk(leitor.GetInt32(PAGAMENTO_CODIGO_MEIO_PAGAMENTO));
                pagamento.setCod_atendente_fk(leitor.GetInt32(PAGAMENTO_CODIGO_ATENDENTE));
                pagamento.setData_alteracao_pagamento(leitor.GetString(PAGAMENTO_DATA_ALTERACAO));
                pagamento.setData_criacao_pagamento(leitor.GetString(PAGAMENTO_DATA_CRIACAO));
                pagamento.setObservacao_pagamento(leitor.GetString(PAGAMENTO_OBSERVACAO));
                pagamento.setEstado_ativo_pagamento(leitor.GetChar(PAGAMENTO_ATIVO));
                pagamento.setTroco_pagamento(leitor.GetDouble(PAGAMENTO_TROCO));
                pagamento.setValor_pagamento(leitor.GetDouble(PAGAMENTO_VALOR));
                pagamentos.Add(pagamento);
            }
            leitor.Close();
            return pagamentos;
        }

        public List<pagamento> selecionarTodosPagamentos_ativo_porBusca_contem(pagamento pagamento_obj)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + PAGAMENTO_TABELA + " WHERE " + PAGAMENTO_ATIVO + " ='s' ";

            if (pagamento_obj.getCod_pagamento_pk() > 0)
            {
                Query.CommandText += " AND " + PAGAMENTO_CODIGO + " LIKE @Codigo ";
                Query.Parameters.AddWithValue("@Codigo", pagamento_obj.getCod_pagamento_pk().ToString() + "%");
            }
            if (pagamento_obj.getTroco_pagamento() > 0)
            {
                Query.CommandText += " AND  @Troco <= " + PAGAMENTO_TROCO;
                Query.Parameters.AddWithValue("@Troco", pagamento_obj.getTroco_pagamento());
            }
            if (pagamento_obj.getValor_pagamento() > 0)
            {
                Query.CommandText += " AND  @Valor <= " + PAGAMENTO_VALOR;
                Query.Parameters.AddWithValue("@Valor", pagamento_obj.getValor_pagamento());
            }
            if ((pagamento_obj.getData_criacao_pagamento() != String.Empty) && (pagamento_obj.getData_criacao_pagamento() != null))
            {
                Query.CommandText += " AND DATE(" + PAGAMENTO_DATA_CRIACAO + ") <= @DataCriacao ";
                Query.Parameters.AddWithValue("@DataCriacao", pagamento_obj.getData_criacao_pagamento());
            }
            if (pagamento_obj.getCod_atendente_fk() > 0)
            {
                Query.CommandText += " AND " + PAGAMENTO_CODIGO_ATENDENTE + " = @Atendente ";
                Query.Parameters.AddWithValue("@Atendente", pagamento_obj.getCod_atendente_fk());
            }
            if (pagamento_obj.getCod_meio_pgto_fk() > 0)
            {
                Query.CommandText += " AND " + PAGAMENTO_CODIGO_MEIO_PAGAMENTO + " = @Meio ";
                Query.Parameters.AddWithValue("@Meio", pagamento_obj.getCod_meio_pgto_fk());
            }
            if ((pagamento_obj.getObservacao_pagamento() != String.Empty) && (pagamento_obj.getObservacao_pagamento() != null))
            {
                Query.CommandText += " AND " + PAGAMENTO_OBSERVACAO + " LIKE @Obs ";
                Query.Parameters.AddWithValue("@Obs", "%"+pagamento_obj.getObservacao_pagamento() + "%");
            }
            if ((pagamento_obj.getData_alteracao_pagamento() != String.Empty) && (pagamento_obj.getData_alteracao_pagamento() != null))
            {
                Query.CommandText += " AND " + PAGAMENTO_DATA_ALTERACAO + " != " + PAGAMENTO_DATA_CRIACAO;
            }
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<pagamento> pagamentos = new List<pagamento>();
            while (leitor.Read())
            {
                pagamento pagamento = new pagamento();
                pagamento.setCod_pagamento_pk(leitor.GetInt32(PAGAMENTO_CODIGO));
                pagamento.setCod_meio_pgto_fk(leitor.GetInt32(PAGAMENTO_CODIGO_MEIO_PAGAMENTO));
                pagamento.setCod_atendente_fk(leitor.GetInt32(PAGAMENTO_CODIGO_ATENDENTE));
                pagamento.setData_alteracao_pagamento(leitor.GetString(PAGAMENTO_DATA_ALTERACAO));
                pagamento.setData_criacao_pagamento(leitor.GetString(PAGAMENTO_DATA_CRIACAO));
                pagamento.setObservacao_pagamento(leitor.GetString(PAGAMENTO_OBSERVACAO));
                pagamento.setEstado_ativo_pagamento(leitor.GetChar(PAGAMENTO_ATIVO));
                pagamento.setTroco_pagamento(leitor.GetDouble(PAGAMENTO_TROCO));
                pagamento.setValor_pagamento(leitor.GetDouble(PAGAMENTO_VALOR));
                pagamentos.Add(pagamento);
            }
            leitor.Close();
            return pagamentos;
        }

        public List<pagamento> selecionarTodosPagamentos_desativo_porBusca_contem(pagamento pagamento_obj)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + PAGAMENTO_TABELA + " WHERE " + PAGAMENTO_ATIVO + " ='n' ";

            if (pagamento_obj.getCod_pagamento_pk() > 0)
            {
                Query.CommandText += " AND " + PAGAMENTO_CODIGO + " LIKE @Codigo ";
                Query.Parameters.AddWithValue("@Codigo", pagamento_obj.getCod_pagamento_pk().ToString()+"%");
            }
            if (pagamento_obj.getTroco_pagamento() > 0)
            {
                Query.CommandText += " AND  @Troco <= "+ PAGAMENTO_TROCO;
                Query.Parameters.AddWithValue("@Troco", pagamento_obj.getTroco_pagamento());
            }
            if (pagamento_obj.getValor_pagamento() > 0)
            {
                Query.CommandText += " AND  @Valor <= "+ PAGAMENTO_VALOR;
                Query.Parameters.AddWithValue("@Valor", pagamento_obj.getValor_pagamento());
            }
            if ((pagamento_obj.getData_criacao_pagamento() != String.Empty) && (pagamento_obj.getData_criacao_pagamento() != null))
            {
                Query.CommandText += " AND DATE(" + PAGAMENTO_DATA_CRIACAO + ") <= @DataCriacao ";
                Query.Parameters.AddWithValue("@DataCriacao", pagamento_obj.getData_criacao_pagamento());
            }
            if (pagamento_obj.getCod_atendente_fk() > 0)
            {
                Query.CommandText += " AND " + PAGAMENTO_CODIGO_ATENDENTE + " = @Atendente ";
                Query.Parameters.AddWithValue("@Atendente", pagamento_obj.getCod_atendente_fk());
            }
            if (pagamento_obj.getCod_meio_pgto_fk() > 0)
            {
                Query.CommandText += " AND " + PAGAMENTO_CODIGO_MEIO_PAGAMENTO + " = @Meio ";
                Query.Parameters.AddWithValue("@Meio", pagamento_obj.getCod_meio_pgto_fk());
            }
            if ((pagamento_obj.getObservacao_pagamento() != String.Empty) && (pagamento_obj.getObservacao_pagamento() != null))
            {
                Query.CommandText += " AND " + PAGAMENTO_OBSERVACAO + " LIKE @Obs ";
                Query.Parameters.AddWithValue("@Obs", "%" + pagamento_obj.getObservacao_pagamento() + "%");
            }
            if ((pagamento_obj.getData_alteracao_pagamento() != String.Empty) && (pagamento_obj.getData_alteracao_pagamento() != null))
            {
                Query.CommandText += " AND " + PAGAMENTO_DATA_ALTERACAO + " != " + PAGAMENTO_DATA_CRIACAO;
            }
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<pagamento> pagamentos = new List<pagamento>();
            while (leitor.Read())
            {
                pagamento pagamento = new pagamento();
                pagamento.setCod_pagamento_pk(leitor.GetInt32(PAGAMENTO_CODIGO));
                pagamento.setCod_meio_pgto_fk(leitor.GetInt32(PAGAMENTO_CODIGO_MEIO_PAGAMENTO));
                pagamento.setCod_atendente_fk(leitor.GetInt32(PAGAMENTO_CODIGO_ATENDENTE));
                pagamento.setData_alteracao_pagamento(leitor.GetString(PAGAMENTO_DATA_ALTERACAO));
                pagamento.setData_criacao_pagamento(leitor.GetString(PAGAMENTO_DATA_CRIACAO));
                pagamento.setObservacao_pagamento(leitor.GetString(PAGAMENTO_OBSERVACAO));
                pagamento.setEstado_ativo_pagamento(leitor.GetChar(PAGAMENTO_ATIVO));
                pagamento.setTroco_pagamento(leitor.GetDouble(PAGAMENTO_TROCO));
                pagamento.setValor_pagamento(leitor.GetDouble(PAGAMENTO_VALOR));
                pagamentos.Add(pagamento);
            }
            leitor.Close();
            return pagamentos;
        }
        #endregion
    }
}
