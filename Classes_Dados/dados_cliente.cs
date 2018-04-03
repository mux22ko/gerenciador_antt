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
    class dados_cliente
    {
        #region CAMPOS BD
        //Tabela
        public const String CLIENTE_TABELA = "tab_cliente";
        //Campos
        public const String
        CLIENTE_CODIGO = "cod_cliente_pk",
        CLIENTE_CODIGO_ATENDENTE = "cod_atendente_fk",
        CLIENTE_DATA_CRIACAO = "data_cadastro_cliente",
        CLIENTE_DATA_NASCIMENTO = "data_nascimento_cliente",
        CLIENTE_CPF_CNPJ= "cpfCnpj_cliente",
        CLIENTE_RG_IE = "rgIe_cliente",
        CLIENTE_RNTRC = "rntrc_cliente",
        CLIENTE_CODIGO_TIPO_PESSOA = "cod_tipo_pessoa_fk",
        CLIENTE_OBSERVACAO = "obs_cliente",
        CLIENTE_NOME = "nome_cliente",
        CLIENTE_APELIDO = "apelido_cliente",
        CLIENTE_ATIVO = "estado_ativo_cliente";
        //Campos
        #endregion

        //objetos banco
        MySqlCommand Query = new MySqlCommand();
        MySqlDataReader leitor;

        #region CADASTROS SIMPLES
        public Boolean cadastrarUmCliente(cliente objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "INSERT INTO "+CLIENTE_TABELA+" ("+
                CLIENTE_CODIGO_ATENDENTE+","+
                CLIENTE_CODIGO_TIPO_PESSOA+","+
                CLIENTE_NOME+","+
                CLIENTE_APELIDO+","+
                CLIENTE_CPF_CNPJ+","+
                CLIENTE_RG_IE+","+
                CLIENTE_DATA_NASCIMENTO+","+
                CLIENTE_RNTRC+","+
                CLIENTE_DATA_CRIACAO+","+  
                CLIENTE_OBSERVACAO+""+
                ") values(@Cod_atend, @Cod_tipo_pessoa, @Nome, @Apelido, @Cpf, @Rg, @Nasc, @Rntrc, NOW(), @Obs) ";
            Query.Parameters.AddWithValue("@Cod_atend", objeto.getCod_atendente_fk().ToString());
            Query.Parameters.AddWithValue("@Cod_tipo_pessoa", objeto.getCod_tipo_pessoa_fk().ToString());
            Query.Parameters.AddWithValue("@Nome", objeto.getNome_cliente().ToString());
            Query.Parameters.AddWithValue("@Apelido", objeto.getApelido_cliente().ToString());
            Query.Parameters.AddWithValue("@Cpf", objeto.getCpfCnpj_cliente().ToString());
            Query.Parameters.AddWithValue("@Rg", objeto.getRgIe_cliente().ToString());
            Query.Parameters.AddWithValue("@Nasc", objeto.getData_nascimento_cliente().ToString());
            Query.Parameters.AddWithValue("@Rntrc", objeto.getRntrc_cliente().ToString());
            Query.Parameters.AddWithValue("@Obs", objeto.getObs_cliente().ToString());
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
        public Boolean alterarUmClienteCompleto_porID(cliente objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "UPDATE " + CLIENTE_TABELA + " SET " +
                CLIENTE_CODIGO_ATENDENTE + " = @Cod_atend," +
                CLIENTE_NOME + " = @Nome," +
                CLIENTE_APELIDO + " = @Apelido," +
                CLIENTE_CPF_CNPJ + " = @Cpf," +
                CLIENTE_RG_IE + " = @Rg," +
                CLIENTE_DATA_NASCIMENTO + " =  @Nasc," +
                CLIENTE_RNTRC + " = @Rntrc," +
                CLIENTE_OBSERVACAO + " = @Obs WHERE "+CLIENTE_CODIGO+" = @Cod_cliente";
            Query.Parameters.AddWithValue("@Cod_atend", objeto.getCod_atendente_fk().ToString());
            Query.Parameters.AddWithValue("@Nome", objeto.getNome_cliente().ToString());
            Query.Parameters.AddWithValue("@Apelido", objeto.getApelido_cliente().ToString());
            Query.Parameters.AddWithValue("@Cpf", objeto.getCpfCnpj_cliente().ToString());
            Query.Parameters.AddWithValue("@Rg", objeto.getRgIe_cliente().ToString());
            Query.Parameters.AddWithValue("@Nasc", objeto.getData_nascimento_cliente().ToString());
            Query.Parameters.AddWithValue("@Rntrc", objeto.getRntrc_cliente().ToString());
            Query.Parameters.AddWithValue("@Obs", objeto.getObs_cliente().ToString());
            Query.Parameters.AddWithValue("@Cod_cliente", objeto.getCod_cliente_pk().ToString());
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
        public cliente selecionarUmCliente_porCodigo(cliente objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM "+CLIENTE_TABELA+" WHERE " 
                + CLIENTE_CODIGO + " = @Codigo limit 1";
            Query.Parameters.AddWithValue("@Codigo", objeto.getCod_cliente_pk());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            cliente cliente = new cliente();
            while (leitor.Read())
            {
                //capto os dados do cliente selecionado!
                cliente.setCod_cliente_pk(leitor.GetInt32(CLIENTE_CODIGO));
                cliente.setCod_atendente_fk(leitor.GetInt32(CLIENTE_CODIGO_ATENDENTE));
                cliente.setCod_tipo_pessoa_fk(leitor.GetInt32(CLIENTE_CODIGO_TIPO_PESSOA));
                cliente.setCpfCnpj_cliente(leitor.GetString(CLIENTE_CPF_CNPJ));
                cliente.setApelido_cliente(leitor.GetString(CLIENTE_APELIDO));
                cliente.setNome_cliente(leitor.GetString(CLIENTE_NOME));
                cliente.setData_cadastro_cliente(leitor.GetString(CLIENTE_DATA_CRIACAO));
                cliente.setObs_cliente(leitor.GetString(CLIENTE_OBSERVACAO));
                cliente.setEstado_ativo_cliente(leitor.GetChar(CLIENTE_ATIVO)); 
                cliente.setRgIe_cliente(leitor.GetString(CLIENTE_RG_IE)); 
                cliente.setData_nascimento_cliente(leitor.GetString(CLIENTE_DATA_NASCIMENTO)); 
                cliente.setRntrc_cliente(leitor.GetString(CLIENTE_RNTRC));                 
            }
            leitor.Close();
            return cliente;
        }
        public cliente selecionarUltimoCliente_acabouDeCadastrar()
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + CLIENTE_TABELA + " WHERE "
                + CLIENTE_CODIGO + " = LAST_INSERT_ID() LIMIT 1";
            leitor = Query.ExecuteReader();
            cliente cliente = new cliente();
            while (leitor.Read())
            {
                //capto os dados do cliente selecionado!
                cliente.setCod_cliente_pk(leitor.GetInt32(CLIENTE_CODIGO));
                cliente.setCod_atendente_fk(leitor.GetInt32(CLIENTE_CODIGO_ATENDENTE));
                cliente.setCod_tipo_pessoa_fk(leitor.GetInt32(CLIENTE_CODIGO_TIPO_PESSOA));
                cliente.setCpfCnpj_cliente(leitor.GetString(CLIENTE_CPF_CNPJ));
                cliente.setApelido_cliente(leitor.GetString(CLIENTE_APELIDO));
                cliente.setNome_cliente(leitor.GetString(CLIENTE_NOME));
                cliente.setData_cadastro_cliente(leitor.GetString(CLIENTE_DATA_CRIACAO));
                cliente.setObs_cliente(leitor.GetString(CLIENTE_OBSERVACAO));
                cliente.setEstado_ativo_cliente(leitor.GetChar(CLIENTE_ATIVO));
                cliente.setRgIe_cliente(leitor.GetString(CLIENTE_RG_IE));
                cliente.setData_nascimento_cliente(leitor.GetString(CLIENTE_DATA_NASCIMENTO));
                cliente.setRntrc_cliente(leitor.GetString(CLIENTE_RNTRC));
            }
            leitor.Close();
            return cliente;
        }
        public cliente selecionarUmCliente_porCpfCnpj(cliente objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + CLIENTE_TABELA + " WHERE "
                + CLIENTE_CPF_CNPJ + " = @CpfCnpj limit 1";
            Query.Parameters.AddWithValue("@CpfCnpj", objeto.getCpfCnpj_cliente());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            cliente cliente = new cliente();
            while (leitor.Read())
            {
                //capto os dados do cliente selecionado!
                cliente.setCod_cliente_pk(leitor.GetInt32(CLIENTE_CODIGO));
                cliente.setCod_atendente_fk(leitor.GetInt32(CLIENTE_CODIGO_ATENDENTE));
                cliente.setCod_tipo_pessoa_fk(leitor.GetInt32(CLIENTE_CODIGO_TIPO_PESSOA));
                cliente.setCpfCnpj_cliente(leitor.GetString(CLIENTE_CPF_CNPJ));
                cliente.setApelido_cliente(leitor.GetString(CLIENTE_APELIDO));
                cliente.setNome_cliente(leitor.GetString(CLIENTE_NOME));
                cliente.setData_cadastro_cliente(leitor.GetString(CLIENTE_DATA_CRIACAO));
                cliente.setObs_cliente(leitor.GetString(CLIENTE_OBSERVACAO));
                cliente.setEstado_ativo_cliente(leitor.GetChar(CLIENTE_ATIVO));
                cliente.setRgIe_cliente(leitor.GetString(CLIENTE_RG_IE));
                cliente.setData_nascimento_cliente(leitor.GetString(CLIENTE_DATA_NASCIMENTO));
                cliente.setRntrc_cliente(leitor.GetString(CLIENTE_RNTRC));
            }
            leitor.Close();
            return cliente;
        }
        #endregion 

       #region BUSCA DINAMICA POR TERMOS
       public List<cliente> selecionarTodosCliente_ativo_porBusca_igual(cliente cliente_obj, endereco_cliente endereco_obj, contato_cliente contato_obj)
       {        
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + CLIENTE_TABELA + " WHERE "+ CLIENTE_ATIVO +" ='s' ";

            if ((cliente_obj.getCod_cliente_pk() > 0))
            {
                Query.CommandText += " AND " + CLIENTE_CODIGO + " = @Codigo ";
                Query.Parameters.AddWithValue("@Codigo", cliente_obj.getCod_cliente_pk().ToString());
            }            
            if (cliente_obj.getCod_tipo_pessoa_fk() == 1) //teste de filtros - PF!
            {                
                Query.CommandText += " AND " + CLIENTE_CODIGO_TIPO_PESSOA + " = 1 ";
                if ((cliente_obj.getNome_cliente() != String.Empty) && (cliente_obj.getNome_cliente() != null))
                {
                    Query.CommandText += " AND UPPER(" + CLIENTE_NOME + ") = @Nome ";
                    Query.Parameters.AddWithValue("@Nome", cliente_obj.getNome_cliente().ToString().ToUpper());
                }
                if ((cliente_obj.getApelido_cliente() != String.Empty) && (cliente_obj.getApelido_cliente() != null))
                {
                    Query.CommandText += " AND UPPER(" + CLIENTE_APELIDO + ") = @Apelido ";
                    Query.Parameters.AddWithValue("@Apelido", cliente_obj.getApelido_cliente().ToString().ToUpper());
                }
                if ((cliente_obj.getCpfCnpj_cliente() != String.Empty) && (cliente_obj.getCpfCnpj_cliente() != null))
                {
                    Query.CommandText += " AND " + CLIENTE_CPF_CNPJ + " = @CPF ";
                    Query.Parameters.AddWithValue("@CPF", cliente_obj.getCpfCnpj_cliente());
                }
                if ((cliente_obj.getData_nascimento_cliente() != String.Empty) && (cliente_obj.getData_nascimento_cliente() != null))
                {
                    Query.CommandText += " AND DATE(" + CLIENTE_DATA_NASCIMENTO + ") = @DataNasc ";
                    Query.Parameters.AddWithValue("@DataNasc", cliente_obj.getData_nascimento_cliente());
                }
                if ((cliente_obj.getRgIe_cliente() != String.Empty) && (cliente_obj.getRgIe_cliente() != null))
                {
                    Query.CommandText += " AND " + CLIENTE_RG_IE + " = @RG ";
                    Query.Parameters.AddWithValue("@RG", cliente_obj.getRgIe_cliente());
                }
                if ((cliente_obj.getRntrc_cliente() != String.Empty) && (cliente_obj.getRntrc_cliente() != null))
                {
                    Query.CommandText += " AND UPPER(" + CLIENTE_RNTRC + ") = @Rntrc ";
                    Query.Parameters.AddWithValue("@Rntrc", cliente_obj.getRntrc_cliente().ToString().ToUpper());
                }
            }
            else 
            {
                if (cliente_obj.getCod_tipo_pessoa_fk() == 2) //teste de filtros - PJ!
                {
                    Query.CommandText += " AND " + CLIENTE_CODIGO_TIPO_PESSOA + " = 2 ";
                    if ((cliente_obj.getNome_cliente() != String.Empty) && (cliente_obj.getNome_cliente() != null))
                    {
                        Query.CommandText += " AND UPPER(" + CLIENTE_NOME + ") = @Nome ";
                        Query.Parameters.AddWithValue("@Nome", cliente_obj.getNome_cliente().ToString().ToUpper());
                    }
                    if ((cliente_obj.getApelido_cliente() != String.Empty) && (cliente_obj.getApelido_cliente() != null))
                    {
                        Query.CommandText += " AND UPPER(" + CLIENTE_APELIDO + ") = @Apelido ";
                        Query.Parameters.AddWithValue("@Apelido", cliente_obj.getApelido_cliente().ToString().ToUpper());
                    }
                    if ((cliente_obj.getCpfCnpj_cliente() != String.Empty) && (cliente_obj.getCpfCnpj_cliente() != null))
                    {
                        Query.CommandText += " AND " + CLIENTE_CPF_CNPJ + " = @CPF ";
                        Query.Parameters.AddWithValue("@CPF", cliente_obj.getCpfCnpj_cliente());
                    }
                    if ((cliente_obj.getData_nascimento_cliente() != String.Empty) && (cliente_obj.getData_nascimento_cliente() != null))
                    {
                        Query.CommandText += " AND DATE(" + CLIENTE_DATA_NASCIMENTO + ") = @DataNasc ";
                        Query.Parameters.AddWithValue("@DataNasc", cliente_obj.getData_nascimento_cliente());
                    }
                    if ((cliente_obj.getRgIe_cliente() != String.Empty) && (cliente_obj.getRgIe_cliente() != null))
                    {
                        Query.CommandText += " AND " + CLIENTE_RG_IE + " = @RG ";
                        Query.Parameters.AddWithValue("@RG", cliente_obj.getRgIe_cliente());
                    }
                    if ((cliente_obj.getRntrc_cliente() != String.Empty) && (cliente_obj.getRntrc_cliente() != null))
                    {
                        Query.CommandText += " AND UPPER(" + CLIENTE_RNTRC + ") = @Rntrc ";
                        Query.Parameters.AddWithValue("@Rntrc", cliente_obj.getRntrc_cliente().ToString().ToUpper());
                    }
                }
            }
            if (endereco_obj != null)//teste de filtros - Enderecos!
            {
                dados_endereco_cliente dados_endereco_cliente = new dados_endereco_cliente();
                List<int> clientesLista = dados_endereco_cliente.selecionarEndereco_porTexto_igual(endereco_obj).Select(endereco_cliente => endereco_cliente.getCod_cliente_fk()).ToList();
                var ids = string.Join(",", clientesLista.Select(i => i.ToString()).ToArray());
                Query.CommandText += " AND " + CLIENTE_CODIGO + " in (" + ids + ") ";
            }
            if (contato_obj != null)//teste de filtros - Contatos!
            {
                dados_contato_cliente dados_contato_cliente = new dados_contato_cliente();
                List<int> clientesLista = dados_contato_cliente.selecionarContato_ativos_porTexto_igual(contato_obj).Select(contato_cliente => contato_cliente.getCod_cliente_fk()).ToList();
                var ids = string.Join(",", clientesLista.Select(i => i.ToString()).ToArray());
                Query.CommandText += " AND " + CLIENTE_CODIGO + " in (" + ids + ") ";
            }
            Query.Prepare();
            leitor = Query.ExecuteReader();
            List<cliente> clientes = new List<cliente>();            
            while (leitor.Read())
            {
                cliente cliente = new cliente();
                //capto os dados do cliente selecionado!
                cliente.setCod_cliente_pk(leitor.GetInt32(CLIENTE_CODIGO));
                cliente.setCod_atendente_fk(leitor.GetInt32(CLIENTE_CODIGO_ATENDENTE));
                cliente.setCod_tipo_pessoa_fk(leitor.GetInt32(CLIENTE_CODIGO_TIPO_PESSOA));
                cliente.setCpfCnpj_cliente(leitor.GetString(CLIENTE_CPF_CNPJ));
                cliente.setApelido_cliente(leitor.GetString(CLIENTE_APELIDO));
                cliente.setNome_cliente(leitor.GetString(CLIENTE_NOME));
                cliente.setData_cadastro_cliente(leitor.GetString(CLIENTE_DATA_CRIACAO));
                cliente.setObs_cliente(leitor.GetString(CLIENTE_OBSERVACAO));
                cliente.setEstado_ativo_cliente(leitor.GetChar(CLIENTE_ATIVO));
                cliente.setRgIe_cliente(leitor.GetString(CLIENTE_RG_IE));
                cliente.setData_nascimento_cliente(leitor.GetString(CLIENTE_DATA_NASCIMENTO));
                cliente.setRntrc_cliente(leitor.GetString(CLIENTE_RNTRC));
                //adiciono!
                clientes.Add(cliente);
            }
            leitor.Close();
            return clientes;    
       }

       public List<cliente> selecionarTodosCliente_ativo_porBusca_contem(cliente cliente_obj, endereco_cliente endereco_obj, contato_cliente contato_obj)
       {
           Query.Dispose();
           Query.Parameters.Clear();
           Query.Connection = conexaoBD.getConexao();
           Query.CommandText = "SELECT * FROM " + CLIENTE_TABELA + " WHERE " + CLIENTE_ATIVO + " ='s' ";

           if ((cliente_obj.getCod_cliente_pk() > 0))
           {
               Query.CommandText += " AND " + CLIENTE_CODIGO + " LIKE @Codigo ";
               Query.Parameters.AddWithValue("@Codigo", "%" + cliente_obj.getCod_cliente_pk().ToString() + "%");
           }

           if (cliente_obj.getCod_tipo_pessoa_fk() == 1) //teste de filtros - PF!
           {
               Query.CommandText += " AND " + CLIENTE_CODIGO_TIPO_PESSOA + " = 1 ";
               if ((cliente_obj.getNome_cliente() != String.Empty) && (cliente_obj.getNome_cliente() != null))
               {
                   Query.CommandText += " AND UPPER(" + CLIENTE_NOME + ") LIKE @Nome ";
                   Query.Parameters.AddWithValue("@Nome", "%" + cliente_obj.getNome_cliente().ToString().ToUpper() + "%");
               }
               if ((cliente_obj.getApelido_cliente() != String.Empty) && (cliente_obj.getApelido_cliente() != null))
               {
                   Query.CommandText += " AND UPPER(" + CLIENTE_APELIDO + ") LIKE @Apelido ";
                   Query.Parameters.AddWithValue("@Apelido", "%" + cliente_obj.getApelido_cliente().ToString().ToUpper() + "%");
               }
               if ((cliente_obj.getCpfCnpj_cliente() != String.Empty) && (cliente_obj.getCpfCnpj_cliente() != null))
               {
                   Query.CommandText += " AND " + CLIENTE_CPF_CNPJ + " LIKE @CPF ";
                   Query.Parameters.AddWithValue("@CPF", "%" + cliente_obj.getCpfCnpj_cliente() + "%");
               }
               if ((cliente_obj.getData_nascimento_cliente() != String.Empty) && (cliente_obj.getData_nascimento_cliente() != null))
               {
                   Query.CommandText += " AND DATE(" + CLIENTE_DATA_NASCIMENTO + ") = @DataNasc ";
                   Query.Parameters.AddWithValue("@DataNasc", cliente_obj.getData_nascimento_cliente());
               }
               if ((cliente_obj.getRgIe_cliente() != String.Empty) && (cliente_obj.getRgIe_cliente() != null))
               {
                   Query.CommandText += " AND " + CLIENTE_RG_IE + " LIKE @RG ";
                   Query.Parameters.AddWithValue("@RG", "%" + cliente_obj.getRgIe_cliente() + "%");
               }
               if ((cliente_obj.getRntrc_cliente() != String.Empty) && (cliente_obj.getRntrc_cliente() != null))
               {
                   Query.CommandText += " AND UPPER(" + CLIENTE_RNTRC + ") LIKE @Rntrc ";
                   Query.Parameters.AddWithValue("@Rntrc", "%" + cliente_obj.getRntrc_cliente().ToString().ToUpper() + "%");
               }
           }
           else if (cliente_obj.getCod_tipo_pessoa_fk() == 2) //teste de filtros - PJ!
               {
                   Query.CommandText += " AND " + CLIENTE_CODIGO_TIPO_PESSOA + " = 2 ";
                   if ((cliente_obj.getNome_cliente() != String.Empty) && (cliente_obj.getNome_cliente() != null))
                   {
                       Query.CommandText += " AND UPPER(" + CLIENTE_NOME + ") LIKE @Nome ";
                       Query.Parameters.AddWithValue("@Nome", "%" + cliente_obj.getNome_cliente().ToString().ToUpper()+ "%");
                   }
                   if ((cliente_obj.getApelido_cliente() != String.Empty) && (cliente_obj.getApelido_cliente() != null))
                   {
                       Query.CommandText += " AND UPPER(" + CLIENTE_APELIDO + ") LIKE @Apelido ";
                       Query.Parameters.AddWithValue("@Apelido", "%" + cliente_obj.getApelido_cliente().ToString().ToUpper() + "%");
                   }
                   if ((cliente_obj.getCpfCnpj_cliente() != String.Empty) && (cliente_obj.getCpfCnpj_cliente() != null))
                   {
                       Query.CommandText += " AND " + CLIENTE_CPF_CNPJ + " LIKE @CPF ";
                       Query.Parameters.AddWithValue("@CPF", "%" + cliente_obj.getCpfCnpj_cliente() + "%");
                   }
                   if ((cliente_obj.getData_nascimento_cliente() != String.Empty) && (cliente_obj.getData_nascimento_cliente() != null))
                   {
                       Query.CommandText += " AND DATE(" + CLIENTE_DATA_NASCIMENTO + ") = @DataNasc ";
                       Query.Parameters.AddWithValue("@DataNasc", cliente_obj.getData_nascimento_cliente());
                   }
                   if ((cliente_obj.getRgIe_cliente() != String.Empty) && (cliente_obj.getRgIe_cliente() != null))
                   {
                       Query.CommandText += " AND " + CLIENTE_RG_IE + " LIKE @RG ";
                       Query.Parameters.AddWithValue("@RG", "%" + cliente_obj.getRgIe_cliente() + "%");
                   }
                   if ((cliente_obj.getRntrc_cliente() != String.Empty) && (cliente_obj.getRntrc_cliente() != null))
                   {
                       Query.CommandText += " AND UPPER(" + CLIENTE_RNTRC + ") LIKE @Rntrc ";
                       Query.Parameters.AddWithValue("@Rntrc", "%" + cliente_obj.getRntrc_cliente().ToString().ToUpper() + "%");
                   }               
               }
           if (endereco_obj!=null)//teste de filtros - Enderecos!
           {
               dados_endereco_cliente dados_endereco_cliente = new dados_endereco_cliente();
               List<int> clientesLista = dados_endereco_cliente.selecionarEndereco_porTexto_contenha(endereco_obj).Select(endereco_cliente => endereco_cliente.getCod_cliente_fk()).ToList();
               var ids = string.Join(",", clientesLista.Select(i => i.ToString()).ToArray());
               Query.CommandText += " AND " + CLIENTE_CODIGO + " in (" + ids + ") ";
           }
           if (contato_obj != null)//teste de filtros - Contatos!
           {
               dados_contato_cliente dados_contato_cliente = new dados_contato_cliente();               
               List<int> clientesLista = dados_contato_cliente.selecionarContato_ativos_porTexto_contenha(contato_obj).Select(contato_cliente => contato_cliente.getCod_cliente_fk()).ToList();
               var ids = string.Join(",", clientesLista.Select(i => i.ToString()).ToArray());               
                   Query.CommandText += " AND " + CLIENTE_CODIGO + " in (" + ids + ") ";
           }
           Query.Prepare();
           leitor = Query.ExecuteReader();
           List<cliente> clientes = new List<cliente>();
           while (leitor.Read())
           {
               cliente cliente = new cliente();
               //capto os dados do cliente selecionado!
               cliente.setCod_cliente_pk(leitor.GetInt32(CLIENTE_CODIGO));
               cliente.setCod_atendente_fk(leitor.GetInt32(CLIENTE_CODIGO_ATENDENTE));
               cliente.setCod_tipo_pessoa_fk(leitor.GetInt32(CLIENTE_CODIGO_TIPO_PESSOA));
               cliente.setCpfCnpj_cliente(leitor.GetString(CLIENTE_CPF_CNPJ));
               cliente.setApelido_cliente(leitor.GetString(CLIENTE_APELIDO));
               cliente.setNome_cliente(leitor.GetString(CLIENTE_NOME));
               cliente.setData_cadastro_cliente(leitor.GetString(CLIENTE_DATA_CRIACAO));
               cliente.setObs_cliente(leitor.GetString(CLIENTE_OBSERVACAO));
               cliente.setEstado_ativo_cliente(leitor.GetChar(CLIENTE_ATIVO));
               cliente.setRgIe_cliente(leitor.GetString(CLIENTE_RG_IE));
               cliente.setData_nascimento_cliente(leitor.GetString(CLIENTE_DATA_NASCIMENTO));
               cliente.setRntrc_cliente(leitor.GetString(CLIENTE_RNTRC));
               //adiciono!
               clientes.Add(cliente);
           }
           leitor.Close();
           return clientes;
       }

       public List<cliente> selecionarTodosCliente_ativo_porBusca_inicio(cliente cliente_obj, endereco_cliente endereco_obj, contato_cliente contato_obj)
       {
           Query.Dispose();
           Query.Parameters.Clear();
           Query.Connection = conexaoBD.getConexao();
           Query.CommandText = "SELECT * FROM " + CLIENTE_TABELA + " WHERE " + CLIENTE_ATIVO + " ='s' ";

           if ((cliente_obj.getCod_cliente_pk() > 0))
           {
               Query.CommandText += " AND " + CLIENTE_CODIGO + " LIKE @Codigo ";
               Query.Parameters.AddWithValue("@Codigo", cliente_obj.getCod_cliente_pk().ToString() + "%");
           }

           if (cliente_obj.getCod_tipo_pessoa_fk() == 1) //teste de filtros - PF!
           {
               Query.CommandText += " AND " + CLIENTE_CODIGO_TIPO_PESSOA + " = 1 ";
               if ((cliente_obj.getNome_cliente() != String.Empty) && (cliente_obj.getNome_cliente() != null))
               {
                   Query.CommandText += " AND UPPER(" + CLIENTE_NOME + ") LIKE @Nome ";
                   Query.Parameters.AddWithValue("@Nome", "" + cliente_obj.getNome_cliente().ToString().ToUpper() + "%");
               }
               if ((cliente_obj.getApelido_cliente() != String.Empty) && (cliente_obj.getApelido_cliente() != null))
               {
                   Query.CommandText += " AND UPPER(" + CLIENTE_APELIDO + ") LIKE @Apelido ";
                   Query.Parameters.AddWithValue("@Apelido", cliente_obj.getApelido_cliente().ToString().ToUpper() + "%");
               }
               if ((cliente_obj.getCpfCnpj_cliente() != String.Empty) && (cliente_obj.getCpfCnpj_cliente() != null))
               {
                   Query.CommandText += " AND " + CLIENTE_CPF_CNPJ + " LIKE @CPF ";
                   Query.Parameters.AddWithValue("@CPF", cliente_obj.getCpfCnpj_cliente() + "%");
               }
               if ((cliente_obj.getData_nascimento_cliente() != String.Empty) && (cliente_obj.getData_nascimento_cliente() != null))
               {
                   Query.CommandText += " AND DATE(" + CLIENTE_DATA_NASCIMENTO + ") = @DataNasc ";
                   Query.Parameters.AddWithValue("@DataNasc", cliente_obj.getData_nascimento_cliente());
               }
               if ((cliente_obj.getRgIe_cliente() != String.Empty) && (cliente_obj.getRgIe_cliente() != null))
               {
                   Query.CommandText += " AND " + CLIENTE_RG_IE + " LIKE @RG ";
                   Query.Parameters.AddWithValue("@RG", cliente_obj.getRgIe_cliente() + "%");
               }
               if ((cliente_obj.getRntrc_cliente() != String.Empty) && (cliente_obj.getRntrc_cliente() != null))
               {
                   Query.CommandText += " AND UPPER(" + CLIENTE_RNTRC + ") LIKE @Rntrc ";
                   Query.Parameters.AddWithValue("@Rntrc", cliente_obj.getRntrc_cliente().ToString().ToUpper() + "%");
               }
           }
           else if (cliente_obj.getCod_tipo_pessoa_fk() == 2) //teste de filtros - PJ!
           {
               Query.CommandText += " AND " + CLIENTE_CODIGO_TIPO_PESSOA + " = 2 ";
               if ((cliente_obj.getNome_cliente() != String.Empty) && (cliente_obj.getNome_cliente() != null))
               {
                   Query.CommandText += " AND UPPER(" + CLIENTE_NOME + ") LIKE @Nome ";
                   Query.Parameters.AddWithValue("@Nome", cliente_obj.getNome_cliente().ToString().ToUpper() + "%");
               }
               if ((cliente_obj.getApelido_cliente() != String.Empty) && (cliente_obj.getApelido_cliente() != null))
               {
                   Query.CommandText += " AND UPPER(" + CLIENTE_APELIDO + ") LIKE @Apelido ";
                   Query.Parameters.AddWithValue("@Apelido", cliente_obj.getApelido_cliente().ToString().ToUpper() + "%");
               }
               if ((cliente_obj.getCpfCnpj_cliente() != String.Empty) && (cliente_obj.getCpfCnpj_cliente() != null))
               {
                   Query.CommandText += " AND " + CLIENTE_CPF_CNPJ + " LIKE @CPF ";
                   Query.Parameters.AddWithValue("@CPF", cliente_obj.getCpfCnpj_cliente() + "%");
               }
               if ((cliente_obj.getData_nascimento_cliente() != String.Empty) && (cliente_obj.getData_nascimento_cliente() != null))
               {
                   Query.CommandText += " AND DATE(" + CLIENTE_DATA_NASCIMENTO + ") = @DataNasc ";
                   Query.Parameters.AddWithValue("@DataNasc", cliente_obj.getData_nascimento_cliente());
               }
               if ((cliente_obj.getRgIe_cliente() != String.Empty) && (cliente_obj.getRgIe_cliente() != null))
               {
                   Query.CommandText += " AND " + CLIENTE_RG_IE + " LIKE @RG ";
                   Query.Parameters.AddWithValue("@RG", cliente_obj.getRgIe_cliente() + "%");
               }
               if ((cliente_obj.getRntrc_cliente() != String.Empty) && (cliente_obj.getRntrc_cliente() != null))
               {
                   Query.CommandText += " AND UPPER(" + CLIENTE_RNTRC + ") LIKE @Rntrc ";
                   Query.Parameters.AddWithValue("@Rntrc", cliente_obj.getRntrc_cliente().ToString().ToUpper() + "%");
               }
           }
           if (endereco_obj != null)//teste de filtros - Enderecos!
           {
               dados_endereco_cliente dados_endereco_cliente = new dados_endereco_cliente();
               List<int> clientesLista = dados_endereco_cliente.selecionarEndereco_porTexto_contenha(endereco_obj).Select(endereco_cliente => endereco_cliente.getCod_cliente_fk()).ToList();
               var ids = string.Join(",", clientesLista.Select(i => i.ToString()).ToArray());
               Query.CommandText += " AND " + CLIENTE_CODIGO + " in (" + ids + ") ";
           }
           if (contato_obj != null)//teste de filtros - Contatos!
           {
               dados_contato_cliente dados_contato_cliente = new dados_contato_cliente();
               List<int> clientesLista = dados_contato_cliente.selecionarContato_ativos_porTexto_inicio(contato_obj).Select(contato_cliente => contato_cliente.getCod_cliente_fk()).ToList();
               var ids = string.Join(",", clientesLista.Select(i => i.ToString()).ToArray());
               Query.CommandText += " AND " + CLIENTE_CODIGO + " in (" + ids + ") ";
           }
           Query.Prepare();
           leitor = Query.ExecuteReader();
           List<cliente> clientes = new List<cliente>();
           while (leitor.Read())
           {
               cliente cliente = new cliente();
               //capto os dados do cliente selecionado!
               cliente.setCod_cliente_pk(leitor.GetInt32(CLIENTE_CODIGO));
               cliente.setCod_atendente_fk(leitor.GetInt32(CLIENTE_CODIGO_ATENDENTE));
               cliente.setCod_tipo_pessoa_fk(leitor.GetInt32(CLIENTE_CODIGO_TIPO_PESSOA));
               cliente.setCpfCnpj_cliente(leitor.GetString(CLIENTE_CPF_CNPJ));
               cliente.setApelido_cliente(leitor.GetString(CLIENTE_APELIDO));
               cliente.setNome_cliente(leitor.GetString(CLIENTE_NOME));
               cliente.setData_cadastro_cliente(leitor.GetString(CLIENTE_DATA_CRIACAO));
               cliente.setObs_cliente(leitor.GetString(CLIENTE_OBSERVACAO));
               cliente.setEstado_ativo_cliente(leitor.GetChar(CLIENTE_ATIVO));
               cliente.setRgIe_cliente(leitor.GetString(CLIENTE_RG_IE));
               cliente.setData_nascimento_cliente(leitor.GetString(CLIENTE_DATA_NASCIMENTO));
               cliente.setRntrc_cliente(leitor.GetString(CLIENTE_RNTRC));
               //adiciono!
               clientes.Add(cliente);
           }
           leitor.Close();
           return clientes;
       }

       public List<cliente> selecionarTodosCliente_ativo_porBusca_fim(cliente cliente_obj, endereco_cliente endereco_obj, contato_cliente contato_obj)
       {
           Query.Dispose();
           Query.Parameters.Clear();
           Query.Connection = conexaoBD.getConexao();
           Query.CommandText = "SELECT * FROM " + CLIENTE_TABELA + " WHERE " + CLIENTE_ATIVO + " ='s' ";

           if ((cliente_obj.getCod_cliente_pk() > 0))
           {
               Query.CommandText += " AND " + CLIENTE_CODIGO + " LIKE @Codigo ";
               Query.Parameters.AddWithValue("@Codigo", "%" + cliente_obj.getCod_cliente_pk().ToString());
           }

           if (cliente_obj.getCod_tipo_pessoa_fk() == 1) //teste de filtros - PF!
           {
               Query.CommandText += " AND " + CLIENTE_CODIGO_TIPO_PESSOA + " = 1 ";
               if ((cliente_obj.getNome_cliente() != String.Empty) && (cliente_obj.getNome_cliente() != null))
               {
                   Query.CommandText += " AND UPPER(" + CLIENTE_NOME + ") LIKE @Nome ";
                   Query.Parameters.AddWithValue("@Nome", "%" + cliente_obj.getNome_cliente().ToString().ToUpper());
               }
               if ((cliente_obj.getApelido_cliente() != String.Empty) && (cliente_obj.getApelido_cliente() != null))
               {
                   Query.CommandText += " AND UPPER(" + CLIENTE_APELIDO + ") LIKE @Apelido ";
                   Query.Parameters.AddWithValue("@Apelido", "%" + cliente_obj.getApelido_cliente().ToString().ToUpper());
               }
               if ((cliente_obj.getCpfCnpj_cliente() != String.Empty) && (cliente_obj.getCpfCnpj_cliente() != null))
               {
                   Query.CommandText += " AND " + CLIENTE_CPF_CNPJ + " LIKE @CPF ";
                   Query.Parameters.AddWithValue("@CPF", "%" + cliente_obj.getCpfCnpj_cliente());
               }
               if ((cliente_obj.getData_nascimento_cliente() != String.Empty) && (cliente_obj.getData_nascimento_cliente() != null))
               {
                   Query.CommandText += " AND DATE(" + CLIENTE_DATA_NASCIMENTO + ") = @DataNasc ";
                   Query.Parameters.AddWithValue("@DataNasc", cliente_obj.getData_nascimento_cliente());
               }
               if ((cliente_obj.getRgIe_cliente() != String.Empty) && (cliente_obj.getRgIe_cliente() != null))
               {
                   Query.CommandText += " AND " + CLIENTE_RG_IE + " LIKE @RG ";
                   Query.Parameters.AddWithValue("@RG", "%" + cliente_obj.getRgIe_cliente());
               }
               if ((cliente_obj.getRntrc_cliente() != String.Empty) && (cliente_obj.getRntrc_cliente() != null))
               {
                   Query.CommandText += " AND UPPER(" + CLIENTE_RNTRC + ") LIKE @Rntrc ";
                   Query.Parameters.AddWithValue("@Rntrc", "%" + cliente_obj.getRntrc_cliente().ToString().ToUpper());
               }
           }
           else if (cliente_obj.getCod_tipo_pessoa_fk() == 2) //teste de filtros - PJ!
           {
               Query.CommandText += " AND " + CLIENTE_CODIGO_TIPO_PESSOA + " = 2 ";
               if ((cliente_obj.getNome_cliente() != String.Empty) && (cliente_obj.getNome_cliente() != null))
               {
                   Query.CommandText += " AND UPPER(" + CLIENTE_NOME + ") LIKE @Nome ";
                   Query.Parameters.AddWithValue("@Nome", "%" + cliente_obj.getNome_cliente().ToString().ToUpper());
               }
               if ((cliente_obj.getApelido_cliente() != String.Empty) && (cliente_obj.getApelido_cliente() != null))
               {
                   Query.CommandText += " AND UPPER(" + CLIENTE_APELIDO + ") LIKE @Apelido ";
                   Query.Parameters.AddWithValue("@Apelido", "%" + cliente_obj.getApelido_cliente().ToString().ToUpper());
               }
               if ((cliente_obj.getCpfCnpj_cliente() != String.Empty) && (cliente_obj.getCpfCnpj_cliente() != null))
               {
                   Query.CommandText += " AND " + CLIENTE_CPF_CNPJ + " LIKE @CPF ";
                   Query.Parameters.AddWithValue("@CPF", "%" + cliente_obj.getCpfCnpj_cliente());
               }
               if ((cliente_obj.getData_nascimento_cliente() != String.Empty) && (cliente_obj.getData_nascimento_cliente() != null))
               {
                   Query.CommandText += " AND DATE(" + CLIENTE_DATA_NASCIMENTO + ") = @DataNasc ";
                   Query.Parameters.AddWithValue("@DataNasc", cliente_obj.getData_nascimento_cliente());
               }
               if ((cliente_obj.getRgIe_cliente() != String.Empty) && (cliente_obj.getRgIe_cliente() != null))
               {
                   Query.CommandText += " AND " + CLIENTE_RG_IE + " LIKE @RG ";
                   Query.Parameters.AddWithValue("@RG", "%" + cliente_obj.getRgIe_cliente());
               }
               if ((cliente_obj.getRntrc_cliente() != String.Empty) && (cliente_obj.getRntrc_cliente() != null))
               {
                   Query.CommandText += " AND UPPER(" + CLIENTE_RNTRC + ") LIKE @Rntrc ";
                   Query.Parameters.AddWithValue("@Rntrc", "%" + cliente_obj.getRntrc_cliente().ToString().ToUpper());
               }
           }
           if (endereco_obj != null)//teste de filtros - Enderecos!
           {
               dados_endereco_cliente dados_endereco_cliente = new dados_endereco_cliente();
               List<int> clientesLista = dados_endereco_cliente.selecionarEndereco_porTexto_contenha(endereco_obj).Select(endereco_cliente => endereco_cliente.getCod_cliente_fk()).ToList();
               var ids = string.Join(",", clientesLista.Select(i => i.ToString()).ToArray());
               Query.CommandText += " AND " + CLIENTE_CODIGO + " in (" + ids + ") ";
           }
           if (contato_obj != null)//teste de filtros - Contatos!
           {
               dados_contato_cliente dados_contato_cliente = new dados_contato_cliente();
               List<int> clientesLista = dados_contato_cliente.selecionarContato_ativos_porTexto_fim(contato_obj).Select(contato_cliente => contato_cliente.getCod_cliente_fk()).ToList();
               var ids = string.Join(",", clientesLista.Select(i => i.ToString()).ToArray());
               Query.CommandText += " AND " + CLIENTE_CODIGO + " IN (" + ids + ") ";
           }
           Query.Prepare();
           leitor = Query.ExecuteReader();
           List<cliente> clientes = new List<cliente>();
           while (leitor.Read())
           {
               cliente cliente = new cliente();
               //capto os dados do cliente selecionado!
               cliente.setCod_cliente_pk(leitor.GetInt32(CLIENTE_CODIGO));
               cliente.setCod_atendente_fk(leitor.GetInt32(CLIENTE_CODIGO_ATENDENTE));
               cliente.setCod_tipo_pessoa_fk(leitor.GetInt32(CLIENTE_CODIGO_TIPO_PESSOA));
               cliente.setCpfCnpj_cliente(leitor.GetString(CLIENTE_CPF_CNPJ));
               cliente.setApelido_cliente(leitor.GetString(CLIENTE_APELIDO));
               cliente.setNome_cliente(leitor.GetString(CLIENTE_NOME));
               cliente.setData_cadastro_cliente(leitor.GetString(CLIENTE_DATA_CRIACAO));
               cliente.setObs_cliente(leitor.GetString(CLIENTE_OBSERVACAO));
               cliente.setEstado_ativo_cliente(leitor.GetChar(CLIENTE_ATIVO));
               cliente.setRgIe_cliente(leitor.GetString(CLIENTE_RG_IE));
               cliente.setData_nascimento_cliente(leitor.GetString(CLIENTE_DATA_NASCIMENTO));
               cliente.setRntrc_cliente(leitor.GetString(CLIENTE_RNTRC));
               //adiciono!
               clientes.Add(cliente);
           }
           leitor.Close();
           return clientes;
       }
       #endregion
    }
}
