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
    class dados_endereco_tipo
    {
        //Tabela
        public const String ENDERECO_TIPO_TABELA = "tab_tipo_endereco";
        //Campos
        public const String
        ENDERECO_TIPO_CODIGO = "cod_tipo_endereco_pk",
        ENDERECO_TIPO_NOME = "nome_tipo_endereco";
        //Campos

        //objetos banco
        MySqlCommand Query = new MySqlCommand();
        MySqlDataReader leitor;
        //objetos banco

        //Selecionar
        public List<tipo_endereco> selecionarTodosTipos()
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + ENDERECO_TIPO_TABELA + " ORDER BY " + ENDERECO_TIPO_NOME + " ASC";
            leitor = Query.ExecuteReader();
            List<tipo_endereco> todosTipos = new List<tipo_endereco>();
            while (leitor.Read())
            {
                tipo_endereco tipo = new tipo_endereco();
                tipo.setCod_tipo_endereco_pk(leitor.GetInt32(ENDERECO_TIPO_CODIGO));
                tipo.setNome_tipo_endereco(leitor.GetString(ENDERECO_TIPO_NOME));
                todosTipos.Add(tipo);
            }
            leitor.Close();
            return todosTipos;
        }
        public tipo_endereco selecionarTipo_porCodigo(tipo_endereco objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + ENDERECO_TIPO_TABELA + " WHERE " + ENDERECO_TIPO_CODIGO + " = "+objeto.getCod_tipo_endereco_pk()+" LIMIT 1";
            leitor = Query.ExecuteReader();
            tipo_endereco tipo = new tipo_endereco();
            while (leitor.Read())
            {
                tipo.setCod_tipo_endereco_pk(leitor.GetInt32(ENDERECO_TIPO_CODIGO));
                tipo.setNome_tipo_endereco(leitor.GetString(ENDERECO_TIPO_NOME));
            }
            leitor.Close();
            return tipo;
        }
    }        
}
