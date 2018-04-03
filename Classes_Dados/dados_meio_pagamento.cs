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
    class dados_meio_pagamento
    {          
        //Tabela
        public const String MEIO_PAGAMENTO_TABELA = "tab_meio_pgto";
        //Campos
        public const String
        MEIO_PAGAMENTO_CODIGO = "cod_meio_pgto_pk",
        MEIO_PAGAMENTO_NOME = "nome_meio_pgto";
        //Campos

        //objetos banco
        MySqlCommand Query = new MySqlCommand();
        MySqlDataReader leitor;
        //objetos banco

        #region CADASTROS SIMPLES
       /* public Boolean cadastrarUmServico(contato_cliente objeto)
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
        }*/
        #endregion

        #region DELETAR SIMPLES
       /* public Boolean deletarTodosContatos_excetoIds(List<contato_cliente> objetos)
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
        }*/
        #endregion

        #region BUSCAS SIMPLES
        public List<meio_pagamento> selecionarTodosMeiosPagamento()
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + MEIO_PAGAMENTO_TABELA +" ORDER BY " + MEIO_PAGAMENTO_CODIGO + " ASC";
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<meio_pagamento> meios_pagamento = new List<meio_pagamento>();            
            while (leitor.Read())
            {
                meio_pagamento meio_pagamentoNovo = new meio_pagamento();
                meio_pagamentoNovo.setCod_meio_pgto_pk(leitor.GetInt32(MEIO_PAGAMENTO_CODIGO));
                meio_pagamentoNovo.setNome_meio_pgto(leitor.GetString(MEIO_PAGAMENTO_NOME));
                meios_pagamento.Add(meio_pagamentoNovo);
            }
            leitor.Close();
            return meios_pagamento;
        }

        public meio_pagamento selecionarUmServico_porCodigo(meio_pagamento meio_pagamento)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + MEIO_PAGAMENTO_TABELA + " WHERE " + MEIO_PAGAMENTO_CODIGO + " = " + meio_pagamento.getCod_meio_pgto_pk() + " LIMIT 1";
            Query.Prepare();
            leitor = Query.ExecuteReader();
            meio_pagamento meio_pagamentoNovo = new meio_pagamento();
            while (leitor.Read())
            {
                meio_pagamentoNovo.setCod_meio_pgto_pk(leitor.GetInt32(MEIO_PAGAMENTO_CODIGO));
                meio_pagamentoNovo.setNome_meio_pgto(leitor.GetString(MEIO_PAGAMENTO_NOME));
            }
            leitor.Close();
            return meio_pagamentoNovo;
        }

        /*
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
       */
        #endregion
        
        #region BUSCAS DINAMICA POR TERMOS
        /*
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
        }*/
        #endregion
    }
}
