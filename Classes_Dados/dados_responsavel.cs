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
    class dados_responsavel
    {
        #region CAMPOS BD
        //Tabela
        public const String RESPONSAVEL_TABELA = "tab_responsavel";
        //Campos
        public const String
        RESPONSAVEL_CODIGO = "cod_responsavel_pk",
        RESPONSAVEL_CODIGO_ATENDENTE = "cod_atendente_fk",
        RESPONSAVEL_CODIGO_TIPO_RESPONSAVEL = "cod_tipo_responsavel_fk",
        RESPONSAVEL_NOME = "nome_responsavel",
        RESPONSAVEL_APELIDO = "apelido_responsavel",
        RESPONSAVEL_DATA_CRIACAO = "data_cadastro_responsavel",
        RESPONSAVEL_DATA_NASCIMENTO = "data_nascimento_responsavel",
        RESPONSAVEL_CPF_CNPJ= "cpfCnpj_responsavel",
        RESPONSAVEL_RG_IE = "rgIe_responsavel",
        RESPONSAVEL_CODIGO_TIPO_PESSOA = "cod_tipo_pessoa_fk",
        RESPONSAVEL_OBSERVACAO = "obs_responsavel",
        RESPONSAVEL_ATIVO = "estado_ativo_responsavel";
        //Campos
        #endregion

        //objetos banco
        MySqlCommand Query = new MySqlCommand();
        MySqlDataReader leitor;

        #region CADASTROS SIMPLES
        public Boolean cadastrarUmResponsavel(responsavel objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "INSERT INTO "+RESPONSAVEL_TABELA+" ("+
                RESPONSAVEL_CODIGO_ATENDENTE+","+
                RESPONSAVEL_CODIGO_TIPO_PESSOA + ","+
                RESPONSAVEL_CODIGO_TIPO_RESPONSAVEL + "," +
                RESPONSAVEL_NOME+","+
                RESPONSAVEL_APELIDO+","+
                RESPONSAVEL_CPF_CNPJ+","+
                RESPONSAVEL_RG_IE+","+
                RESPONSAVEL_DATA_NASCIMENTO+","+
                RESPONSAVEL_DATA_CRIACAO+","+  
                RESPONSAVEL_OBSERVACAO+""+
                ") values(@Cod_atend, @Cod_tipo_pessoa, @Resp, @Nome, @Apelido, @Cpf, @Rg, @Nasc, NOW(), @Obs) ";
            Query.Parameters.AddWithValue("@Cod_atend", objeto.getCod_atendente_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_tipo_pessoa", objeto.getCod_tipo_pessoa_fk().ToString());
            Query.Parameters.AddWithValue("@Resp", objeto.getCod_tipo_responsavel_responsavel_fk().ToString());
            Query.Parameters.AddWithValue("@Nome", objeto.getNome_responsavel().ToString());
            Query.Parameters.AddWithValue("@Apelido", objeto.getApelido_responsavel().ToString());
            Query.Parameters.AddWithValue("@Cpf", objeto.getCpfCnpj_responsavel().ToString());
            Query.Parameters.AddWithValue("@Rg", objeto.getRgIe_responsavel().ToString());
            Query.Parameters.AddWithValue("@Nasc", objeto.getData_nascimento_responsavel().ToString());
            Query.Parameters.AddWithValue("@Obs", objeto.getObs_responsavel().ToString());
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
        public Boolean alterarUmResponsavelCompleto_porID(responsavel objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "UPDATE " + RESPONSAVEL_TABELA + " SET " +
                RESPONSAVEL_CODIGO_ATENDENTE + " = @Cod_atend," +
                 RESPONSAVEL_CODIGO_TIPO_RESPONSAVEL +" = @Resp," +
                RESPONSAVEL_NOME + " = @Nome," +
                RESPONSAVEL_APELIDO + " = @Apelido," +
                RESPONSAVEL_CPF_CNPJ + " = @Cpf," +
                RESPONSAVEL_RG_IE + " = @Rg," +
                RESPONSAVEL_DATA_NASCIMENTO + " =  @Nasc," +
                RESPONSAVEL_OBSERVACAO + " = @Obs WHERE "+RESPONSAVEL_CODIGO+" = @Cod_responsavel";
            Query.Parameters.AddWithValue("@Cod_atend", objeto.getCod_atendente_fk().ToString());
            Query.Parameters.AddWithValue("@Nome", objeto.getNome_responsavel().ToString());
            Query.Parameters.AddWithValue("@Apelido", objeto.getApelido_responsavel().ToString());
            Query.Parameters.AddWithValue("@Cpf", objeto.getCpfCnpj_responsavel().ToString());
            Query.Parameters.AddWithValue("@Rg", objeto.getRgIe_responsavel().ToString());
            Query.Parameters.AddWithValue("@Nasc", objeto.getData_nascimento_responsavel().ToString());
            Query.Parameters.AddWithValue("@Resp", objeto.getCod_tipo_responsavel_responsavel_fk().ToString());
            Query.Parameters.AddWithValue("@Obs", objeto.getObs_responsavel().ToString());
            Query.Parameters.AddWithValue("@Cod_responsavel", objeto.getCod_responsavel_pk().ToString());
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
        public responsavel selecionarUmResponsavel_porCodigo(responsavel objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM "+RESPONSAVEL_TABELA+" WHERE " 
                + RESPONSAVEL_CODIGO + " = @Codigo limit 1";
            Query.Parameters.AddWithValue("@Codigo", objeto.getCod_responsavel_pk());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            responsavel responsavel = new responsavel();
            while (leitor.Read())
            {
                //capto os dados do responsavel selecionado!
                responsavel.setCod_responsavel_pk(leitor.GetInt32(RESPONSAVEL_CODIGO));
                responsavel.setCod_atendente_fk(leitor.GetInt32(RESPONSAVEL_CODIGO_ATENDENTE));
                responsavel.setCod_tipo_pessoa_fk(leitor.GetInt32(RESPONSAVEL_CODIGO_TIPO_PESSOA));
                responsavel.setCpfCnpj_responsavel(leitor.GetString(RESPONSAVEL_CPF_CNPJ));
                responsavel.setApelido_responsavel(leitor.GetString(RESPONSAVEL_APELIDO));
                responsavel.setNome_responsavel(leitor.GetString(RESPONSAVEL_NOME));
                responsavel.setData_cadastro_responsavel(leitor.GetString(RESPONSAVEL_DATA_CRIACAO));
                responsavel.setObs_responsavel(leitor.GetString(RESPONSAVEL_OBSERVACAO));
                responsavel.setEstado_ativo_responsavel(leitor.GetChar(RESPONSAVEL_ATIVO)); 
                responsavel.setRgIe_responsavel(leitor.GetString(RESPONSAVEL_RG_IE)); 
                responsavel.setData_nascimento_responsavel(leitor.GetString(RESPONSAVEL_DATA_NASCIMENTO)); 
                responsavel.setCod_tipo_responsavel_responsavel_fk(leitor.GetInt32(RESPONSAVEL_CODIGO_TIPO_RESPONSAVEL));                 
            }
            leitor.Close();
            return responsavel;
        }
        public responsavel selecionarUltimoResponsavel_acabouDeCadastrar()
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + RESPONSAVEL_TABELA + " WHERE "
                + RESPONSAVEL_CODIGO + " = LAST_INSERT_ID() limit 1";
            leitor = Query.ExecuteReader();
            responsavel responsavel = new responsavel();
            while (leitor.Read())
            {
                //capto os dados do responsavel selecionado!
                responsavel.setCod_responsavel_pk(leitor.GetInt32(RESPONSAVEL_CODIGO));
                responsavel.setCod_atendente_fk(leitor.GetInt32(RESPONSAVEL_CODIGO_ATENDENTE));
                responsavel.setCod_tipo_pessoa_fk(leitor.GetInt32(RESPONSAVEL_CODIGO_TIPO_PESSOA));
                responsavel.setCpfCnpj_responsavel(leitor.GetString(RESPONSAVEL_CPF_CNPJ));
                responsavel.setApelido_responsavel(leitor.GetString(RESPONSAVEL_APELIDO));
                responsavel.setNome_responsavel(leitor.GetString(RESPONSAVEL_NOME));
                responsavel.setData_cadastro_responsavel(leitor.GetString(RESPONSAVEL_DATA_CRIACAO));
                responsavel.setObs_responsavel(leitor.GetString(RESPONSAVEL_OBSERVACAO));
                responsavel.setEstado_ativo_responsavel(leitor.GetChar(RESPONSAVEL_ATIVO));
                responsavel.setRgIe_responsavel(leitor.GetString(RESPONSAVEL_RG_IE));
                responsavel.setData_nascimento_responsavel(leitor.GetString(RESPONSAVEL_DATA_NASCIMENTO));
                responsavel.setCod_tipo_responsavel_responsavel_fk(leitor.GetInt32(RESPONSAVEL_CODIGO_TIPO_RESPONSAVEL));
            }
            leitor.Close();
            return responsavel;
        }
        #endregion 

        #region BUSCA DINAMICA POR TERMOS
        public List<responsavel> selecionarTodosResponsavel_ativo_porBusca_igual(responsavel responsavel_obj, endereco_responsavel endereco_obj, contato_responsavel contato_obj)
       {        
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + RESPONSAVEL_TABELA + " WHERE "+ RESPONSAVEL_ATIVO +" ='s' ";

            if ((responsavel_obj.getCod_responsavel_pk() != 0))
            {
                Query.CommandText += " AND " + RESPONSAVEL_CODIGO + " = @Codigo ";
                Query.Parameters.AddWithValue("@Codigo", responsavel_obj.getCod_responsavel_pk().ToString());
            }

            if ((responsavel_obj.getCod_tipo_responsavel_responsavel_fk() > 0))
            {
                Query.CommandText += " AND " + RESPONSAVEL_CODIGO_TIPO_RESPONSAVEL + " = @Resp ";
                Query.Parameters.AddWithValue("@Resp", responsavel_obj.getCod_tipo_responsavel_responsavel_fk().ToString());
            }
            if (responsavel_obj.getCod_tipo_pessoa_fk() == 1) //teste de filtros - PF!
            {
                Query.CommandText += " AND " + RESPONSAVEL_CODIGO_TIPO_PESSOA + " = 1 ";
                if ((responsavel_obj.getNome_responsavel() != String.Empty) && (responsavel_obj.getNome_responsavel() != null))
                {
                    Query.CommandText += " AND UPPER(" + RESPONSAVEL_NOME + ") = @Nome ";
                    Query.Parameters.AddWithValue("@Nome", responsavel_obj.getNome_responsavel().ToString().ToUpper());
                }
                if ((responsavel_obj.getApelido_responsavel() != String.Empty) && (responsavel_obj.getApelido_responsavel() != null))
                {
                    Query.CommandText += " AND UPPER(" + RESPONSAVEL_APELIDO + ") = @Apelido ";
                    Query.Parameters.AddWithValue("@Apelido", responsavel_obj.getApelido_responsavel().ToString().ToUpper());
                }
                if ((responsavel_obj.getCpfCnpj_responsavel() != String.Empty) && (responsavel_obj.getCpfCnpj_responsavel() != null))
                {
                    Query.CommandText += " AND " + RESPONSAVEL_CPF_CNPJ + " = @CPF ";
                    Query.Parameters.AddWithValue("@CPF", responsavel_obj.getCpfCnpj_responsavel());
                }
                if ((responsavel_obj.getData_nascimento_responsavel() != String.Empty) && (responsavel_obj.getData_nascimento_responsavel() != null))
                {
                    Query.CommandText += " AND DATE(" + RESPONSAVEL_DATA_NASCIMENTO + ") = @DataNasc ";
                    Query.Parameters.AddWithValue("@DataNasc", responsavel_obj.getData_nascimento_responsavel());
                }
                if ((responsavel_obj.getRgIe_responsavel() != String.Empty) && (responsavel_obj.getRgIe_responsavel() != null))
                {
                    Query.CommandText += " AND " + RESPONSAVEL_RG_IE + " = @RG ";
                    Query.Parameters.AddWithValue("@RG", responsavel_obj.getRgIe_responsavel());
                }
            }
            else 
            {
                if (responsavel_obj.getCod_tipo_pessoa_fk() == 2) //teste de filtros - PJ!
                {
                    Query.CommandText += " AND " + RESPONSAVEL_CODIGO_TIPO_PESSOA + " = 2 ";
                    if ((responsavel_obj.getNome_responsavel() != String.Empty) && (responsavel_obj.getNome_responsavel() != null))
                    {
                        Query.CommandText += " AND UPPER(" + RESPONSAVEL_NOME + ") = @Nome ";
                        Query.Parameters.AddWithValue("@Nome", responsavel_obj.getNome_responsavel().ToString().ToUpper());
                    }
                    if ((responsavel_obj.getApelido_responsavel() != String.Empty) && (responsavel_obj.getApelido_responsavel() != null))
                    {
                        Query.CommandText += " AND UPPER(" + RESPONSAVEL_APELIDO + ") = @Apelido ";
                        Query.Parameters.AddWithValue("@Apelido", responsavel_obj.getApelido_responsavel().ToString().ToUpper());
                    }
                    if ((responsavel_obj.getCpfCnpj_responsavel() != String.Empty) && (responsavel_obj.getCpfCnpj_responsavel() != null))
                    {
                        Query.CommandText += " AND " + RESPONSAVEL_CPF_CNPJ + " = @CPF ";
                        Query.Parameters.AddWithValue("@CPF", responsavel_obj.getCpfCnpj_responsavel());
                    }
                    if ((responsavel_obj.getData_nascimento_responsavel() != String.Empty) && (responsavel_obj.getData_nascimento_responsavel() != null))
                    {
                        Query.CommandText += " AND DATE(" + RESPONSAVEL_DATA_NASCIMENTO + ") = @DataNasc ";
                        Query.Parameters.AddWithValue("@DataNasc", responsavel_obj.getData_nascimento_responsavel());
                    }
                    if ((responsavel_obj.getRgIe_responsavel() != String.Empty) && (responsavel_obj.getRgIe_responsavel() != null))
                    {
                        Query.CommandText += " AND " + RESPONSAVEL_RG_IE + " = @RG ";
                        Query.Parameters.AddWithValue("@RG", responsavel_obj.getRgIe_responsavel());
                    }
                }
            }
            if (endereco_obj != null)//teste de filtros - Enderecos!
            {
                dados_endereco_responsavel dados_endereco_responsavel = new dados_endereco_responsavel();
                List<int> responsavelsLista = dados_endereco_responsavel.selecionarEndereco_porTexto_igual(endereco_obj).Select(endereco_responsavel => endereco_responsavel.getCod_responsavel_fk()).ToList();
                var ids = string.Join(",", responsavelsLista.Select(i => i.ToString()).ToArray());
                Query.CommandText += " AND " + RESPONSAVEL_CODIGO + " in ('" + ids + "') ";
            }
            if (contato_obj != null)//teste de filtros - Contatos!
            {
                dados_contato_responsavel dados_contato_responsavel = new dados_contato_responsavel();
                List<int> responsavelsLista = dados_contato_responsavel.selecionarContato_ativos_porTexto_igual(contato_obj).Select(contato_responsavel => contato_responsavel.getCod_responsavel_fk()).ToList();
                var ids = string.Join(",", responsavelsLista.Select(i => i.ToString()).ToArray());
                Query.CommandText += " AND " + RESPONSAVEL_CODIGO + " in ('" + ids + "') ";
            }            
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<responsavel> responsavels = new List<responsavel>();            
            while (leitor.Read())
            {
                responsavel responsavel = new responsavel();
                //capto os dados do responsavel selecionado!
                responsavel.setCod_responsavel_pk(leitor.GetInt32(RESPONSAVEL_CODIGO));
                responsavel.setCod_atendente_fk(leitor.GetInt32(RESPONSAVEL_CODIGO_ATENDENTE));
                responsavel.setCod_tipo_pessoa_fk(leitor.GetInt32(RESPONSAVEL_CODIGO_TIPO_PESSOA));
                responsavel.setCpfCnpj_responsavel(leitor.GetString(RESPONSAVEL_CPF_CNPJ));
                responsavel.setApelido_responsavel(leitor.GetString(RESPONSAVEL_APELIDO));
                responsavel.setNome_responsavel(leitor.GetString(RESPONSAVEL_NOME));
                responsavel.setData_cadastro_responsavel(leitor.GetString(RESPONSAVEL_DATA_CRIACAO));
                responsavel.setObs_responsavel(leitor.GetString(RESPONSAVEL_OBSERVACAO));
                responsavel.setEstado_ativo_responsavel(leitor.GetChar(RESPONSAVEL_ATIVO));
                responsavel.setRgIe_responsavel(leitor.GetString(RESPONSAVEL_RG_IE));
                responsavel.setData_nascimento_responsavel(leitor.GetString(RESPONSAVEL_DATA_NASCIMENTO));
                responsavel.setCod_tipo_responsavel_responsavel_fk(leitor.GetInt32(RESPONSAVEL_CODIGO_TIPO_RESPONSAVEL));
                //adiciono!
                responsavels.Add(responsavel);
            }
            leitor.Close();
            return responsavels;    
       }

       public List<responsavel> selecionarTodosResponsavel_ativo_porBusca_contem(responsavel responsavel_obj, endereco_responsavel endereco_obj, contato_responsavel contato_obj)
       {
           Query.Dispose();
           Query.Parameters.Clear();
           Query.Connection = conexaoBD.getConexao();
           Query.CommandText = "SELECT * FROM " + RESPONSAVEL_TABELA + " WHERE " + RESPONSAVEL_ATIVO + " ='s' ";

           if ((responsavel_obj.getCod_responsavel_pk() != 0))
           {
               Query.CommandText += " AND " + RESPONSAVEL_CODIGO + " LIKE @Codigo ";
               Query.Parameters.AddWithValue("@Codigo", "%" + responsavel_obj.getCod_responsavel_pk().ToString() + "%");
           }
           if ((responsavel_obj.getCod_tipo_responsavel_responsavel_fk() > 0))
           {
               Query.CommandText += " AND " + RESPONSAVEL_CODIGO_TIPO_RESPONSAVEL + " = @Resp ";
               Query.Parameters.AddWithValue("@Resp", responsavel_obj.getCod_tipo_responsavel_responsavel_fk().ToString());
           }

           if (responsavel_obj.getCod_tipo_pessoa_fk() == 1) //teste de filtros - PF!
           {
               Query.CommandText += " AND " + RESPONSAVEL_CODIGO_TIPO_PESSOA + " = 1 ";
               if ((responsavel_obj.getNome_responsavel() != String.Empty) && (responsavel_obj.getNome_responsavel() != null))
               {
                   Query.CommandText += " AND UPPER(" + RESPONSAVEL_NOME + ") LIKE @Nome ";
                   Query.Parameters.AddWithValue("@Nome", "%" + responsavel_obj.getNome_responsavel().ToString().ToUpper() + "%");
               }
               if ((responsavel_obj.getApelido_responsavel() != String.Empty) && (responsavel_obj.getApelido_responsavel() != null))
               {
                   Query.CommandText += " AND UPPER(" + RESPONSAVEL_APELIDO + ") LIKE @Apelido ";
                   Query.Parameters.AddWithValue("@Apelido", "%" + responsavel_obj.getApelido_responsavel().ToString().ToUpper() + "%");
               }
               if ((responsavel_obj.getCpfCnpj_responsavel() != String.Empty) && (responsavel_obj.getCpfCnpj_responsavel() != null))
               {
                   Query.CommandText += " AND " + RESPONSAVEL_CPF_CNPJ + " LIKE @CPF ";
                   Query.Parameters.AddWithValue("@CPF", "%" + responsavel_obj.getCpfCnpj_responsavel() + "%");
               }
               if ((responsavel_obj.getData_nascimento_responsavel() != String.Empty) && (responsavel_obj.getData_nascimento_responsavel() != null))
               {
                   Query.CommandText += " AND DATE(" + RESPONSAVEL_DATA_NASCIMENTO + ") = @DataNasc ";
                   Query.Parameters.AddWithValue("@DataNasc", responsavel_obj.getData_nascimento_responsavel());
               }
               if ((responsavel_obj.getRgIe_responsavel() != String.Empty) && (responsavel_obj.getRgIe_responsavel() != null))
               {
                   Query.CommandText += " AND " + RESPONSAVEL_RG_IE + " LIKE @RG ";
                   Query.Parameters.AddWithValue("@RG", "%" + responsavel_obj.getRgIe_responsavel() + "%");
               }
           }
           else if (responsavel_obj.getCod_tipo_pessoa_fk() == 2) //teste de filtros - PJ!
               {
                   Query.CommandText += " AND " + RESPONSAVEL_CODIGO_TIPO_PESSOA + " = 2 ";
                   if ((responsavel_obj.getNome_responsavel() != String.Empty) && (responsavel_obj.getNome_responsavel() != null))
                   {
                       Query.CommandText += " AND UPPER(" + RESPONSAVEL_NOME + ") LIKE @Nome ";
                       Query.Parameters.AddWithValue("@Nome", "%" + responsavel_obj.getNome_responsavel().ToString().ToUpper()+ "%");
                   }
                   if ((responsavel_obj.getApelido_responsavel() != String.Empty) && (responsavel_obj.getApelido_responsavel() != null))
                   {
                       Query.CommandText += " AND UPPER(" + RESPONSAVEL_APELIDO + ") LIKE @Apelido ";
                       Query.Parameters.AddWithValue("@Apelido", "%" + responsavel_obj.getApelido_responsavel().ToString().ToUpper() + "%");
                   }
                   if ((responsavel_obj.getCpfCnpj_responsavel() != String.Empty) && (responsavel_obj.getCpfCnpj_responsavel() != null))
                   {
                       Query.CommandText += " AND " + RESPONSAVEL_CPF_CNPJ + " LIKE @CPF ";
                       Query.Parameters.AddWithValue("@CPF", "%" + responsavel_obj.getCpfCnpj_responsavel() + "%");
                   }
                   if ((responsavel_obj.getData_nascimento_responsavel() != String.Empty) && (responsavel_obj.getData_nascimento_responsavel() != null))
                   {
                       Query.CommandText += " AND DATE(" + RESPONSAVEL_DATA_NASCIMENTO + ") = @DataNasc ";
                       Query.Parameters.AddWithValue("@DataNasc", responsavel_obj.getData_nascimento_responsavel());
                   }
                   if ((responsavel_obj.getRgIe_responsavel() != String.Empty) && (responsavel_obj.getRgIe_responsavel() != null))
                   {
                       Query.CommandText += " AND " + RESPONSAVEL_RG_IE + " LIKE @RG ";
                       Query.Parameters.AddWithValue("@RG", "%" + responsavel_obj.getRgIe_responsavel() + "%");
                   }             
               }
           if (endereco_obj!=null)//teste de filtros - Enderecos!
           {
               dados_endereco_responsavel dados_endereco_responsavel = new dados_endereco_responsavel();
               List<int> responsavelsLista = dados_endereco_responsavel.selecionarEndereco_porTexto_contenha(endereco_obj).Select(endereco_responsavel => endereco_responsavel.getCod_responsavel_fk()).ToList();
               var ids = string.Join(",", responsavelsLista.Select(i => i.ToString()).ToArray());
               Query.CommandText += " AND " + RESPONSAVEL_CODIGO + " in ('" + ids + "') ";
           }
           if (contato_obj != null)//teste de filtros - Contatos!
           {
               dados_contato_responsavel dados_contato_responsavel = new dados_contato_responsavel();               
               List<int> responsavelsLista = dados_contato_responsavel.selecionarContato_ativos_porTexto_contenha(contato_obj).Select(contato_responsavel => contato_responsavel.getCod_responsavel_fk()).ToList();
               var ids = string.Join(",", responsavelsLista.Select(i => i.ToString()).ToArray());               
                   Query.CommandText += " AND " + RESPONSAVEL_CODIGO + " in ('" + ids + "') ";
           }
           Query.Prepare();
           leitor = Query.ExecuteReader();
           List<responsavel> responsavels = new List<responsavel>();
           while (leitor.Read())
           {
               responsavel responsavel = new responsavel();
               //capto os dados do responsavel selecionado!
               responsavel.setCod_responsavel_pk(leitor.GetInt32(RESPONSAVEL_CODIGO));
               responsavel.setCod_atendente_fk(leitor.GetInt32(RESPONSAVEL_CODIGO_ATENDENTE));
               responsavel.setCod_tipo_pessoa_fk(leitor.GetInt32(RESPONSAVEL_CODIGO_TIPO_PESSOA));
               responsavel.setCpfCnpj_responsavel(leitor.GetString(RESPONSAVEL_CPF_CNPJ));
               responsavel.setApelido_responsavel(leitor.GetString(RESPONSAVEL_APELIDO));
               responsavel.setNome_responsavel(leitor.GetString(RESPONSAVEL_NOME));
               responsavel.setData_cadastro_responsavel(leitor.GetString(RESPONSAVEL_DATA_CRIACAO));
               responsavel.setObs_responsavel(leitor.GetString(RESPONSAVEL_OBSERVACAO));
               responsavel.setEstado_ativo_responsavel(leitor.GetChar(RESPONSAVEL_ATIVO));
               responsavel.setRgIe_responsavel(leitor.GetString(RESPONSAVEL_RG_IE));
               responsavel.setData_nascimento_responsavel(leitor.GetString(RESPONSAVEL_DATA_NASCIMENTO));
               responsavel.setCod_tipo_responsavel_responsavel_fk(leitor.GetInt32(RESPONSAVEL_CODIGO_TIPO_RESPONSAVEL));
               //adiciono!
               responsavels.Add(responsavel);
           }
           leitor.Close();
           return responsavels;
       }

       public List<responsavel> selecionarTodosResponsavel_ativo_porBusca_inicio(responsavel responsavel_obj, endereco_responsavel endereco_obj, contato_responsavel contato_obj)
       {
           Query.Dispose();
           Query.Parameters.Clear();
           Query.Connection = conexaoBD.getConexao();
           Query.CommandText = "SELECT * FROM " + RESPONSAVEL_TABELA + " WHERE " + RESPONSAVEL_ATIVO + " ='s' ";

           if ((responsavel_obj.getCod_responsavel_pk() != 0))
           {
               Query.CommandText += " AND " + RESPONSAVEL_CODIGO + " LIKE @Codigo ";
               Query.Parameters.AddWithValue("@Codigo", responsavel_obj.getCod_responsavel_pk().ToString() + "%");
           }
           if ((responsavel_obj.getCod_tipo_responsavel_responsavel_fk() > 0))
           {
               Query.CommandText += " AND " + RESPONSAVEL_CODIGO_TIPO_RESPONSAVEL + " = @Resp ";
               Query.Parameters.AddWithValue("@Resp", responsavel_obj.getCod_tipo_responsavel_responsavel_fk().ToString());
           }

           if (responsavel_obj.getCod_tipo_pessoa_fk() == 1) //teste de filtros - PF!
           {
               Query.CommandText += " AND " + RESPONSAVEL_CODIGO_TIPO_PESSOA + " = 1 ";
               if ((responsavel_obj.getNome_responsavel() != String.Empty) && (responsavel_obj.getNome_responsavel() != null))
               {
                   Query.CommandText += " AND UPPER(" + RESPONSAVEL_NOME + ") LIKE @Nome ";
                   Query.Parameters.AddWithValue("@Nome", "" + responsavel_obj.getNome_responsavel().ToString().ToUpper() + "%");
               }
               if ((responsavel_obj.getApelido_responsavel() != String.Empty) && (responsavel_obj.getApelido_responsavel() != null))
               {
                   Query.CommandText += " AND UPPER(" + RESPONSAVEL_APELIDO + ") LIKE @Apelido ";
                   Query.Parameters.AddWithValue("@Apelido", responsavel_obj.getApelido_responsavel().ToString().ToUpper() + "%");
               }
               if ((responsavel_obj.getCpfCnpj_responsavel() != String.Empty) && (responsavel_obj.getCpfCnpj_responsavel() != null))
               {
                   Query.CommandText += " AND " + RESPONSAVEL_CPF_CNPJ + " LIKE @CPF ";
                   Query.Parameters.AddWithValue("@CPF", responsavel_obj.getCpfCnpj_responsavel() + "%");
               }
               if ((responsavel_obj.getData_nascimento_responsavel() != String.Empty) && (responsavel_obj.getData_nascimento_responsavel() != null))
               {
                   Query.CommandText += " AND DATE(" + RESPONSAVEL_DATA_NASCIMENTO + ") = @DataNasc ";
                   Query.Parameters.AddWithValue("@DataNasc", responsavel_obj.getData_nascimento_responsavel());
               }
               if ((responsavel_obj.getRgIe_responsavel() != String.Empty) && (responsavel_obj.getRgIe_responsavel() != null))
               {
                   Query.CommandText += " AND " + RESPONSAVEL_RG_IE + " LIKE @RG ";
                   Query.Parameters.AddWithValue("@RG", responsavel_obj.getRgIe_responsavel() + "%");
               }
           }
           else if (responsavel_obj.getCod_tipo_pessoa_fk() == 2) //teste de filtros - PJ!
           {
               Query.CommandText += " AND " + RESPONSAVEL_CODIGO_TIPO_PESSOA + " = 2 ";
               if ((responsavel_obj.getNome_responsavel() != String.Empty) && (responsavel_obj.getNome_responsavel() != null))
               {
                   Query.CommandText += " AND UPPER(" + RESPONSAVEL_NOME + ") LIKE @Nome ";
                   Query.Parameters.AddWithValue("@Nome", responsavel_obj.getNome_responsavel().ToString().ToUpper() + "%");
               }
               if ((responsavel_obj.getApelido_responsavel() != String.Empty) && (responsavel_obj.getApelido_responsavel() != null))
               {
                   Query.CommandText += " AND UPPER(" + RESPONSAVEL_APELIDO + ") LIKE @Apelido ";
                   Query.Parameters.AddWithValue("@Apelido", responsavel_obj.getApelido_responsavel().ToString().ToUpper() + "%");
               }
               if ((responsavel_obj.getCpfCnpj_responsavel() != String.Empty) && (responsavel_obj.getCpfCnpj_responsavel() != null))
               {
                   Query.CommandText += " AND " + RESPONSAVEL_CPF_CNPJ + " LIKE @CPF ";
                   Query.Parameters.AddWithValue("@CPF", responsavel_obj.getCpfCnpj_responsavel() + "%");
               }
               if ((responsavel_obj.getData_nascimento_responsavel() != String.Empty) && (responsavel_obj.getData_nascimento_responsavel() != null))
               {
                   Query.CommandText += " AND DATE(" + RESPONSAVEL_DATA_NASCIMENTO + ") = @DataNasc ";
                   Query.Parameters.AddWithValue("@DataNasc", responsavel_obj.getData_nascimento_responsavel());
               }
               if ((responsavel_obj.getRgIe_responsavel() != String.Empty) && (responsavel_obj.getRgIe_responsavel() != null))
               {
                   Query.CommandText += " AND " + RESPONSAVEL_RG_IE + " LIKE @RG ";
                   Query.Parameters.AddWithValue("@RG", responsavel_obj.getRgIe_responsavel() + "%");
               }
           }
           if (endereco_obj != null)//teste de filtros - Enderecos!
           {
               dados_endereco_responsavel dados_endereco_responsavel = new dados_endereco_responsavel();
               List<int> responsavelsLista = dados_endereco_responsavel.selecionarEndereco_porTexto_contenha(endereco_obj).Select(endereco_responsavel => endereco_responsavel.getCod_responsavel_fk()).ToList();
               var ids = string.Join(",", responsavelsLista.Select(i => i.ToString()).ToArray());
               Query.CommandText += " AND " + RESPONSAVEL_CODIGO + " in ('" + ids + "') ";
           }
           if (contato_obj != null)//teste de filtros - Contatos!
           {
               dados_contato_responsavel dados_contato_responsavel = new dados_contato_responsavel();
               List<int> responsavelsLista = dados_contato_responsavel.selecionarContato_ativos_porTexto_inicio(contato_obj).Select(contato_responsavel => contato_responsavel.getCod_responsavel_fk()).ToList();
               var ids = string.Join(",", responsavelsLista.Select(i => i.ToString()).ToArray());
               Query.CommandText += " AND " + RESPONSAVEL_CODIGO + " in ('" + ids + "') ";
           }
           Query.Prepare();
           leitor = Query.ExecuteReader();
           List<responsavel> responsavels = new List<responsavel>();
           while (leitor.Read())
           {
               responsavel responsavel = new responsavel();
               //capto os dados do responsavel selecionado!
               responsavel.setCod_responsavel_pk(leitor.GetInt32(RESPONSAVEL_CODIGO));
               responsavel.setCod_atendente_fk(leitor.GetInt32(RESPONSAVEL_CODIGO_ATENDENTE));
               responsavel.setCod_tipo_pessoa_fk(leitor.GetInt32(RESPONSAVEL_CODIGO_TIPO_PESSOA));
               responsavel.setCpfCnpj_responsavel(leitor.GetString(RESPONSAVEL_CPF_CNPJ));
               responsavel.setApelido_responsavel(leitor.GetString(RESPONSAVEL_APELIDO));
               responsavel.setNome_responsavel(leitor.GetString(RESPONSAVEL_NOME));
               responsavel.setData_cadastro_responsavel(leitor.GetString(RESPONSAVEL_DATA_CRIACAO));
               responsavel.setObs_responsavel(leitor.GetString(RESPONSAVEL_OBSERVACAO));
               responsavel.setEstado_ativo_responsavel(leitor.GetChar(RESPONSAVEL_ATIVO));
               responsavel.setRgIe_responsavel(leitor.GetString(RESPONSAVEL_RG_IE));
               responsavel.setData_nascimento_responsavel(leitor.GetString(RESPONSAVEL_DATA_NASCIMENTO));
               responsavel.setCod_tipo_responsavel_responsavel_fk(leitor.GetInt32(RESPONSAVEL_CODIGO_TIPO_RESPONSAVEL));
               //adiciono!
               responsavels.Add(responsavel);
           }
           leitor.Close();
           return responsavels;
       }

       public List<responsavel> selecionarTodosResponsavel_ativo_porBusca_fim(responsavel responsavel_obj, endereco_responsavel endereco_obj, contato_responsavel contato_obj)
       {
           Query.Dispose();
           Query.Parameters.Clear();
           Query.Connection = conexaoBD.getConexao();
           Query.CommandText = "SELECT * FROM " + RESPONSAVEL_TABELA + " WHERE " + RESPONSAVEL_ATIVO + " ='s' ";
           
           if ((responsavel_obj.getCod_responsavel_pk() != 0))
           {
               Query.CommandText += " AND " + RESPONSAVEL_CODIGO + " LIKE @Codigo ";
               Query.Parameters.AddWithValue("@Codigo", "%" + responsavel_obj.getCod_responsavel_pk().ToString());
           }
           if ((responsavel_obj.getCod_tipo_responsavel_responsavel_fk() > 0))
           {
               Query.CommandText += " AND " + RESPONSAVEL_CODIGO_TIPO_RESPONSAVEL + " = @Resp ";
               Query.Parameters.AddWithValue("@Resp", responsavel_obj.getCod_tipo_responsavel_responsavel_fk().ToString());
           }

           if (responsavel_obj.getCod_tipo_pessoa_fk() == 1) //teste de filtros - PF!
           {
               Query.CommandText += " AND " + RESPONSAVEL_CODIGO_TIPO_PESSOA + " = 1 ";
               if ((responsavel_obj.getNome_responsavel() != String.Empty) && (responsavel_obj.getNome_responsavel() != null))
               {
                   Query.CommandText += " AND UPPER(" + RESPONSAVEL_NOME + ") LIKE @Nome ";
                   Query.Parameters.AddWithValue("@Nome", "%" + responsavel_obj.getNome_responsavel().ToString().ToUpper());
               }
               if ((responsavel_obj.getApelido_responsavel() != String.Empty) && (responsavel_obj.getApelido_responsavel() != null))
               {
                   Query.CommandText += " AND UPPER(" + RESPONSAVEL_APELIDO + ") LIKE @Apelido ";
                   Query.Parameters.AddWithValue("@Apelido", "%" + responsavel_obj.getApelido_responsavel().ToString().ToUpper());
               }
               if ((responsavel_obj.getCpfCnpj_responsavel() != String.Empty) && (responsavel_obj.getCpfCnpj_responsavel() != null))
               {
                   Query.CommandText += " AND " + RESPONSAVEL_CPF_CNPJ + " LIKE @CPF ";
                   Query.Parameters.AddWithValue("@CPF", "%" + responsavel_obj.getCpfCnpj_responsavel());
               }
               if ((responsavel_obj.getData_nascimento_responsavel() != String.Empty) && (responsavel_obj.getData_nascimento_responsavel() != null))
               {
                   Query.CommandText += " AND DATE(" + RESPONSAVEL_DATA_NASCIMENTO + ") = @DataNasc ";
                   Query.Parameters.AddWithValue("@DataNasc", responsavel_obj.getData_nascimento_responsavel());
               }
               if ((responsavel_obj.getRgIe_responsavel() != String.Empty) && (responsavel_obj.getRgIe_responsavel() != null))
               {
                   Query.CommandText += " AND " + RESPONSAVEL_RG_IE + " LIKE @RG ";
                   Query.Parameters.AddWithValue("@RG", "%" + responsavel_obj.getRgIe_responsavel());
               }
           }
           else if (responsavel_obj.getCod_tipo_pessoa_fk() == 2) //teste de filtros - PJ!
           {
               Query.CommandText += " AND " + RESPONSAVEL_CODIGO_TIPO_PESSOA + " = 2 ";
               if ((responsavel_obj.getNome_responsavel() != String.Empty) && (responsavel_obj.getNome_responsavel() != null))
               {
                   Query.CommandText += " AND UPPER(" + RESPONSAVEL_NOME + ") LIKE @Nome ";
                   Query.Parameters.AddWithValue("@Nome", "%" + responsavel_obj.getNome_responsavel().ToString().ToUpper());
               }
               if ((responsavel_obj.getApelido_responsavel() != String.Empty) && (responsavel_obj.getApelido_responsavel() != null))
               {
                   Query.CommandText += " AND UPPER(" + RESPONSAVEL_APELIDO + ") LIKE @Apelido ";
                   Query.Parameters.AddWithValue("@Apelido", "%" + responsavel_obj.getApelido_responsavel().ToString().ToUpper());
               }
               if ((responsavel_obj.getCpfCnpj_responsavel() != String.Empty) && (responsavel_obj.getCpfCnpj_responsavel() != null))
               {
                   Query.CommandText += " AND " + RESPONSAVEL_CPF_CNPJ + " LIKE @CPF ";
                   Query.Parameters.AddWithValue("@CPF", "%" + responsavel_obj.getCpfCnpj_responsavel());
               }
               if ((responsavel_obj.getData_nascimento_responsavel() != String.Empty) && (responsavel_obj.getData_nascimento_responsavel() != null))
               {
                   Query.CommandText += " AND DATE(" + RESPONSAVEL_DATA_NASCIMENTO + ") = @DataNasc ";
                   Query.Parameters.AddWithValue("@DataNasc", responsavel_obj.getData_nascimento_responsavel());
               }
               if ((responsavel_obj.getRgIe_responsavel() != String.Empty) && (responsavel_obj.getRgIe_responsavel() != null))
               {
                   Query.CommandText += " AND " + RESPONSAVEL_RG_IE + " LIKE @RG ";
                   Query.Parameters.AddWithValue("@RG", "%" + responsavel_obj.getRgIe_responsavel());
               }
           }
           if (endereco_obj != null)//teste de filtros - Enderecos!
           {
               dados_endereco_responsavel dados_endereco_responsavel = new dados_endereco_responsavel();
               List<int> responsavelsLista = dados_endereco_responsavel.selecionarEndereco_porTexto_contenha(endereco_obj).Select(endereco_responsavel => endereco_responsavel.getCod_responsavel_fk()).ToList();
               var ids = string.Join(",", responsavelsLista.Select(i => i.ToString()).ToArray());
               Query.CommandText += " AND " + RESPONSAVEL_CODIGO + " in ('" + ids + "') ";
           }
           if (contato_obj != null)//teste de filtros - Contatos!
           {
               dados_contato_responsavel dados_contato_responsavel = new dados_contato_responsavel();
               List<int> responsavelsLista = dados_contato_responsavel.selecionarContato_ativos_porTexto_fim(contato_obj).Select(contato_responsavel => contato_responsavel.getCod_responsavel_fk()).ToList();
               var ids = string.Join(",", responsavelsLista.Select(i => i.ToString()).ToArray());
               Query.CommandText += " AND " + RESPONSAVEL_CODIGO + " in ('" + ids + "') ";
           }
           Query.Prepare();
           leitor = Query.ExecuteReader();
           List<responsavel> responsavels = new List<responsavel>();
           while (leitor.Read())
           {
               responsavel responsavel = new responsavel();
               //capto os dados do responsavel selecionado!
               responsavel.setCod_responsavel_pk(leitor.GetInt32(RESPONSAVEL_CODIGO));
               responsavel.setCod_atendente_fk(leitor.GetInt32(RESPONSAVEL_CODIGO_ATENDENTE));
               responsavel.setCod_tipo_pessoa_fk(leitor.GetInt32(RESPONSAVEL_CODIGO_TIPO_PESSOA));
               responsavel.setCpfCnpj_responsavel(leitor.GetString(RESPONSAVEL_CPF_CNPJ));
               responsavel.setApelido_responsavel(leitor.GetString(RESPONSAVEL_APELIDO));
               responsavel.setNome_responsavel(leitor.GetString(RESPONSAVEL_NOME));
               responsavel.setData_cadastro_responsavel(leitor.GetString(RESPONSAVEL_DATA_CRIACAO));
               responsavel.setObs_responsavel(leitor.GetString(RESPONSAVEL_OBSERVACAO));
               responsavel.setEstado_ativo_responsavel(leitor.GetChar(RESPONSAVEL_ATIVO));
               responsavel.setRgIe_responsavel(leitor.GetString(RESPONSAVEL_RG_IE));
               responsavel.setData_nascimento_responsavel(leitor.GetString(RESPONSAVEL_DATA_NASCIMENTO));
               responsavel.setCod_tipo_responsavel_responsavel_fk(leitor.GetInt32(RESPONSAVEL_CODIGO_TIPO_RESPONSAVEL));
               //adiciono!
               responsavels.Add(responsavel);
           }
           leitor.Close();
           return responsavels;
       }
       #endregion
    }
}
