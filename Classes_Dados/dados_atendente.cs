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
    class dados_atendente
    {
        //Tabela
        public const String ATENDENTE_TABELA = "tab_atendente";
        //Campos
        public const String
        ATENDENTE_CODIGO = "cod_atendente_pk",
        ATENDENTE_CPF = "cpf_atendente",
        ATENDENTE_RG = "rg_atendente",
        ATENDENTE_NOME = "nome_atendente",
        ATENDENTE_APELIDO = "apelido_atendente",
        ATENDENTE_EMAIL = "email_atendente",
        ATENDENTE_TELEFONE = "tel_atendente",
        ATENDENTE_CELULAR = "cel_atendente",
        ATENDENTE_OBSERVACAO = "observacao_atendente",
        ATENDENTE_USUARIO = "usuario_atendente",
        ATENDENTE_SENHA = "senha_atendente",
        ATENDENTE_ATIVO = "estado_ativo_atendente",
        ATENDENTE_DATA_CRIACAO = "data_criacao_atendente";
        //Campos

        //objetos banco
        MySqlCommand Query = new MySqlCommand();
        MySqlDataReader leitor;
        //objetos banco
                
        public atendente selecionarUmAtendente_porUsuario_Senha(atendente objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM "+ATENDENTE_TABELA+" WHERE " 
                + ATENDENTE_USUARIO + " = @Usuario_atendente AND " 
                + ATENDENTE_SENHA + " = @Senha_atendente limit 1";
            Query.Parameters.AddWithValue("@Usuario_atendente", objeto.getUsuario_atendente());
            Query.Parameters.AddWithValue("@Senha_atendente", objeto.getSenha_atendente());
            Query.Prepare();
            leitor = Query.ExecuteReader();
            atendente atendente = new atendente();
            while (leitor.Read())
            {
                //capto os dados do atendente selecionado!
                atendente.setCod_atendente_pk(leitor.GetInt32(ATENDENTE_CODIGO));
                atendente.setCpf_atendente(leitor.GetString(ATENDENTE_CPF));
                atendente.setRg_atendente(leitor.GetString(ATENDENTE_RG));
                atendente.setNome_atendente(leitor.GetString(ATENDENTE_NOME));
                atendente.setApelido_atendente(leitor.GetString(ATENDENTE_APELIDO));
                atendente.setTel_atendente(leitor.GetString(ATENDENTE_TELEFONE));
                atendente.setCel_atendente(leitor.GetString(ATENDENTE_CELULAR));
                atendente.setObservacao_atendente(leitor.GetString(ATENDENTE_OBSERVACAO));
                atendente.setUsuario_atendente(leitor.GetString(ATENDENTE_USUARIO)); 
                atendente.setSenha_atendente(leitor.GetString(ATENDENTE_SENHA)); 
                atendente.setEstado_ativo_atendente(leitor.GetChar(ATENDENTE_ATIVO)); 
                atendente.setData_criacao_atendente(leitor.GetString(ATENDENTE_DATA_CRIACAO));                 
            }
            leitor.Close();
            return atendente;                      
        }
    }
}
