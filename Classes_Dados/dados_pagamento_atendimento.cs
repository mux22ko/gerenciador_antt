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

    class dados_pagamento_atendimento
    {
        #region DADOS
        //Tabela
        public const String PAGAMENTO_ATENDIMENTO_TABELA = "tab_pagamento_atendimento";
        //Campos
        public const String
        PAGAMENTO_ATENDIMENTO_CODIGO = "cod_pagamento_atendimento_pk",
        PAGAMENTO_ATENDIMENTO_CODIGO_PAGAMENTO = "cod_pagamento_fk",
        PAGAMENTO_ATENDIMENTO_CODIGO_ATENDIMENTO = "cod_atendimento_fk",
        PAGAMENTO_ATENDIMENTO_VALOR_FATIA = "valor_fatia_pagamento";
        //Campos

        //objetos banco
        MySqlCommand Query = new MySqlCommand();
        MySqlDataReader leitor;
        //objetos banco
        #endregion

        #region CADASTROS SIMPLES
        public Boolean cadastrarUmPagamento_atendimento(pagamento_atendimento objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "INSERT INTO " + PAGAMENTO_ATENDIMENTO_TABELA + " (" +
                PAGAMENTO_ATENDIMENTO_CODIGO_ATENDIMENTO + "," +
                PAGAMENTO_ATENDIMENTO_CODIGO_PAGAMENTO + "," +
                PAGAMENTO_ATENDIMENTO_VALOR_FATIA + 
                ") values( @Cod_atendimento, @Cod_pagamento, @Valor_fatia) ";
            Query.Parameters.AddWithValue("@Cod_atendimento", objeto.getCod_atendimento_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_pagamento", objeto.getCod_pagamento_fk().ToString());
            Query.Parameters.AddWithValue("@Valor_fatia", objeto.getValor_fatia_pagamento());
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
        public Boolean alterarUmPagamento_atendimento(pagamento_atendimento objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "UPDATE " + PAGAMENTO_ATENDIMENTO_TABELA + " SET " +
                PAGAMENTO_ATENDIMENTO_CODIGO_ATENDIMENTO + " = @Cod_atendimento, " +
                PAGAMENTO_ATENDIMENTO_CODIGO_PAGAMENTO + " = @Cod_pagamento, " +
                PAGAMENTO_ATENDIMENTO_VALOR_FATIA + " = @Valor_fatia " +
                " WHERE " + PAGAMENTO_ATENDIMENTO_CODIGO + " = @Codigo LIMIT 1";
            Query.Parameters.AddWithValue("@Cod_atendimento", objeto.getCod_atendimento_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_pagamento", objeto.getCod_pagamento_fk().ToString());
            Query.Parameters.AddWithValue("@Valor_fatia", objeto.getValor_fatia_pagamento());
            Query.Parameters.AddWithValue("@Codigo", objeto.getCod_pagamento_atendimento_pk());
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
        public Boolean deletarPagamento_atendimento_porCodPagamento_e_excetoListaCodPagamento_atendimento(pagamento_atendimento pagamento_atendimento_obj, List<pagamento_atendimento> pagamento_atendimento_objs)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "DELETE FROM " + PAGAMENTO_ATENDIMENTO_TABELA + " WHERE " +
                PAGAMENTO_ATENDIMENTO_CODIGO_PAGAMENTO + " = @Cod_pagamento ";
            Query.Parameters.AddWithValue("@Cod_pagamento", pagamento_atendimento_obj.getCod_pagamento_fk());
            Query.CommandText += " AND " + PAGAMENTO_ATENDIMENTO_CODIGO + " NOT IN ( ";
            int posicao = 1;
            if (pagamento_atendimento_objs.Count > 0)
            {
                foreach (pagamento_atendimento i in pagamento_atendimento_objs)
                {
                    if (posicao > 1)
                    {
                        Query.CommandText += ", ";
                    }
                    Query.CommandText += i.getCod_pagamento_atendimento_pk();
                    posicao++;
                }
                Query.CommandText += "  ) ";
            }
            else 
            {
                Query.CommandText += " '' ) ";
            }
            
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
        public pagamento_atendimento selecionarUmPagamento_atendimento_porCodigoPagamento_e_CodAtendimento(pagamento_atendimento objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + PAGAMENTO_ATENDIMENTO_TABELA + " WHERE (" +
                PAGAMENTO_ATENDIMENTO_CODIGO_ATENDIMENTO + " = @Cod_at )" +
                " AND (" +
                 PAGAMENTO_ATENDIMENTO_CODIGO_PAGAMENTO + " = @Cod_pag )" +
                " LIMIT 1 ";
            Query.Parameters.AddWithValue("@Cod_at", objeto.getCod_atendimento_fk());
            Query.Parameters.AddWithValue("@Cod_pag", objeto.getCod_pagamento_fk());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            pagamento_atendimento pagamento_atendimento = new pagamento_atendimento();            
            while (leitor.Read())
            {
                pagamento_atendimento.setCod_pagamento_atendimento_pk(leitor.GetInt32(PAGAMENTO_ATENDIMENTO_CODIGO));
                pagamento_atendimento.setCod_pagamento_fk(leitor.GetInt32(PAGAMENTO_ATENDIMENTO_CODIGO_PAGAMENTO));
                pagamento_atendimento.setCod_atendimento_fk(leitor.GetInt32(PAGAMENTO_ATENDIMENTO_CODIGO_ATENDIMENTO));
                pagamento_atendimento.setValor_fatia_pagamento(leitor.GetDouble(PAGAMENTO_ATENDIMENTO_VALOR_FATIA));
            }
            leitor.Close();
            return pagamento_atendimento;
        }

        public pagamento_atendimento selecionarUltimoPagamento_atendimento_acabouDeCadastrar()
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + PAGAMENTO_ATENDIMENTO_TABELA + " WHERE "
                + PAGAMENTO_ATENDIMENTO_CODIGO + " = LAST_INSERT_ID() LIMIT 1";
            Query.Prepare();
            leitor = Query.ExecuteReader();
            pagamento_atendimento pagamento_atendimento = new pagamento_atendimento(); 
            while (leitor.Read())
            {
                pagamento_atendimento.setCod_pagamento_atendimento_pk(leitor.GetInt32(PAGAMENTO_ATENDIMENTO_CODIGO));
                pagamento_atendimento.setCod_pagamento_fk(leitor.GetInt32(PAGAMENTO_ATENDIMENTO_CODIGO_PAGAMENTO));
                pagamento_atendimento.setCod_atendimento_fk(leitor.GetInt32(PAGAMENTO_ATENDIMENTO_CODIGO_ATENDIMENTO));
                pagamento_atendimento.setValor_fatia_pagamento(leitor.GetInt32(PAGAMENTO_ATENDIMENTO_VALOR_FATIA));
            }
            leitor.Close();
            return pagamento_atendimento;
        }

        public pagamento_atendimento selecionarUmPagamento_atendimento_identico(pagamento_atendimento objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + PAGAMENTO_ATENDIMENTO_TABELA + " WHERE " +
                PAGAMENTO_ATENDIMENTO_CODIGO_ATENDIMENTO + " = @Cod_atendimento AND " +
                PAGAMENTO_ATENDIMENTO_CODIGO_PAGAMENTO + " = @Cod_pagamento AND " +
                PAGAMENTO_ATENDIMENTO_VALOR_FATIA + " = @Valor_fatia LIMIT 1";
            Query.Parameters.AddWithValue("@Cod_atendimento", objeto.getCod_atendimento_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_pagamento", objeto.getCod_pagamento_fk().ToString());
            Query.Parameters.AddWithValue("@Valor_fatia", objeto.getValor_fatia_pagamento());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            pagamento_atendimento pagamento_atendimento = new pagamento_atendimento();
            while (leitor.Read())
            {
                pagamento_atendimento.setCod_pagamento_atendimento_pk(leitor.GetInt32(PAGAMENTO_ATENDIMENTO_CODIGO));
                pagamento_atendimento.setCod_pagamento_fk(leitor.GetInt32(PAGAMENTO_ATENDIMENTO_CODIGO_PAGAMENTO));
                pagamento_atendimento.setCod_atendimento_fk(leitor.GetInt32(PAGAMENTO_ATENDIMENTO_CODIGO_ATENDIMENTO));
                pagamento_atendimento.setValor_fatia_pagamento(leitor.GetDouble(PAGAMENTO_ATENDIMENTO_VALOR_FATIA));
            }
            leitor.Close();
            return pagamento_atendimento;
        }
        #endregion

        #region BUSCA DINAMICA POR TERMOS
       
        public List<pagamento_atendimento> selecionarTodosPagamento_atendimento_porCodPagamento(pagamento_atendimento pagamento_atendimento_obj)
        {            
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + PAGAMENTO_ATENDIMENTO_TABELA + " WHERE " + PAGAMENTO_ATENDIMENTO_CODIGO_PAGAMENTO + " = @Cod_pagamento ";
            Query.Parameters.AddWithValue("@Cod_pagamento", pagamento_atendimento_obj.getCod_pagamento_fk().ToString());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<pagamento_atendimento> pagamento_atendimentos = new List<pagamento_atendimento>();
            while (leitor.Read())
            {
                pagamento_atendimento pagamento_atendimento = new pagamento_atendimento();
                //capto os dados do pagamento_atendimento selecionado!
                pagamento_atendimento.setCod_pagamento_atendimento_pk(leitor.GetInt32(PAGAMENTO_ATENDIMENTO_CODIGO));
                pagamento_atendimento.setCod_pagamento_fk(leitor.GetInt32(PAGAMENTO_ATENDIMENTO_CODIGO_PAGAMENTO));
                pagamento_atendimento.setCod_atendimento_fk(leitor.GetInt32(PAGAMENTO_ATENDIMENTO_CODIGO_ATENDIMENTO));
                pagamento_atendimento.setValor_fatia_pagamento(leitor.GetDouble(PAGAMENTO_ATENDIMENTO_VALOR_FATIA));
                //adiciono!
                pagamento_atendimentos.Add(pagamento_atendimento);
            }
            leitor.Close();
            return pagamento_atendimentos;
        }

        public List<pagamento_atendimento> selecionarTodosPagamento_atendimento_porCodAtendimento(pagamento_atendimento pagamento_atendimento_obj)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + PAGAMENTO_ATENDIMENTO_TABELA + " WHERE " + PAGAMENTO_ATENDIMENTO_CODIGO_ATENDIMENTO + " = @Cod_atendimento ";
            Query.Parameters.AddWithValue("@Cod_atendimento", pagamento_atendimento_obj.getCod_atendimento_fk().ToString());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<pagamento_atendimento> pagamento_atendimentos = new List<pagamento_atendimento>();
            while (leitor.Read())
            {
                pagamento_atendimento pagamento_atendimento = new pagamento_atendimento();
                //capto os dados do pagamento_atendimento selecionado!
                pagamento_atendimento.setCod_pagamento_atendimento_pk(leitor.GetInt32(PAGAMENTO_ATENDIMENTO_CODIGO));
                pagamento_atendimento.setCod_pagamento_fk(leitor.GetInt32(PAGAMENTO_ATENDIMENTO_CODIGO_PAGAMENTO));
                pagamento_atendimento.setCod_atendimento_fk(leitor.GetInt32(PAGAMENTO_ATENDIMENTO_CODIGO_ATENDIMENTO));
                pagamento_atendimento.setValor_fatia_pagamento(leitor.GetDouble(PAGAMENTO_ATENDIMENTO_VALOR_FATIA));
                //adiciono!
                pagamento_atendimentos.Add(pagamento_atendimento);
            }
            leitor.Close();
            return pagamento_atendimentos;
        }

        public List<pagamento_atendimento> selecionarTodosPagamento_atendimento_porCodAtendimentos(List<pagamento_atendimento> pagamento_atendimento_objs)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + PAGAMENTO_ATENDIMENTO_TABELA + " WHERE " + PAGAMENTO_ATENDIMENTO_CODIGO + " = " + PAGAMENTO_ATENDIMENTO_CODIGO;
            if (pagamento_atendimento_objs != null)//teste de filtros - Atendimentos!
            {
                List<int> atendimentoLista = pagamento_atendimento_objs.Select(pagamento_atendimento => pagamento_atendimento.getCod_atendimento_fk()).ToList();
                var ids = string.Join(",", atendimentoLista.Select(i => i.ToString()).ToArray());
                Query.CommandText += " AND " + PAGAMENTO_ATENDIMENTO_CODIGO_ATENDIMENTO + " IN (" + ids + ") ";
            }
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<pagamento_atendimento> pagamento_atendimentos = new List<pagamento_atendimento>();
            while (leitor.Read())
            {
                pagamento_atendimento pagamento_atendimento = new pagamento_atendimento();
                //capto os dados do pagamento_atendimento selecionado!
                pagamento_atendimento.setCod_pagamento_atendimento_pk(leitor.GetInt32(PAGAMENTO_ATENDIMENTO_CODIGO));
                pagamento_atendimento.setCod_pagamento_fk(leitor.GetInt32(PAGAMENTO_ATENDIMENTO_CODIGO_PAGAMENTO));
                pagamento_atendimento.setCod_atendimento_fk(leitor.GetInt32(PAGAMENTO_ATENDIMENTO_CODIGO_ATENDIMENTO));
                pagamento_atendimento.setValor_fatia_pagamento(leitor.GetDouble(PAGAMENTO_ATENDIMENTO_VALOR_FATIA));
                //adiciono!
                pagamento_atendimentos.Add(pagamento_atendimento);
            }
            leitor.Close();
            return pagamento_atendimentos;
        }

        public List<pagamento_atendimento> selecionarTodosPagamento_atendimento_porCodAtendimento_e_excetoDestePagamento(pagamento_atendimento pagamento_atendimento_obj)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + PAGAMENTO_ATENDIMENTO_TABELA + " WHERE " +
                PAGAMENTO_ATENDIMENTO_CODIGO_ATENDIMENTO + " = @Cod_atendimento " +
                " AND " + PAGAMENTO_ATENDIMENTO_CODIGO_PAGAMENTO + " NOT IN ( @Cod_pagamento ) ";
            Query.Parameters.AddWithValue("@Cod_atendimento", pagamento_atendimento_obj.getCod_atendimento_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_pagamento", pagamento_atendimento_obj.getCod_pagamento_fk().ToString());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<pagamento_atendimento> pagamento_atendimentos = new List<pagamento_atendimento>();
            while (leitor.Read())
            {
                pagamento_atendimento pagamento_atendimento = new pagamento_atendimento();
                //capto os dados do pagamento_atendimento selecionado!
                pagamento_atendimento.setCod_pagamento_atendimento_pk(leitor.GetInt32(PAGAMENTO_ATENDIMENTO_CODIGO));
                pagamento_atendimento.setCod_pagamento_fk(leitor.GetInt32(PAGAMENTO_ATENDIMENTO_CODIGO_PAGAMENTO));
                pagamento_atendimento.setCod_atendimento_fk(leitor.GetInt32(PAGAMENTO_ATENDIMENTO_CODIGO_ATENDIMENTO));
                pagamento_atendimento.setValor_fatia_pagamento(leitor.GetDouble(PAGAMENTO_ATENDIMENTO_VALOR_FATIA));
                //adiciono!
                pagamento_atendimentos.Add(pagamento_atendimento);
            }
            leitor.Close();
            return pagamento_atendimentos;
        }
        #endregion
    }
}
