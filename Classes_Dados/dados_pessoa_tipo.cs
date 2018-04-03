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
    class dados_pessoa_tipo
    {
        //Tabela
        public const String PESSOA_TIPO_TABELA = "tab_tipo_pessoa";
        //Campos
        public const String
        PESSOA_TIPO_CODIGO = "cod_tipo_pessoa_pk",
        PESSOA_TIPO_NOME = "nome_tipo_pessoa";
        //Campos

        //objetos banco
        MySqlCommand Query = new MySqlCommand();
        MySqlDataReader leitor;
        //objetos banco

        //Selecionar
        /*
        public List<tipo_pessoa> selecionarTodosTipos()
        {
          Query.Dispose();
          Query.Parameters.Clear();
          Query.Connection = conexaoBD.getConexao();
          Query.CommandText = "SELECT * FROM "+PESSOA_TIPO_TABELA+" ORDER BY "+PESSOA_TIPO_NOME+" ASC";
          leitor = Query.ExecuteReader();         
          List<tipo_pessoa> todosTipos= new List<tipo_pessoa>();
          while(leitor.Read())
          {
              tipo_pessoa tipo = new tipo_pessoa();
              tipo.setCod_tipo_pessoa_pk(leitor.GetInt32(PESSOA_TIPO_CODIGO));
              tipo.setNome_tipo_pessoa(leitor.GetString(PESSOA_TIPO_NOME));
              todosTipos.Add(tipo);
          }
          leitor.Close();
          return todosTipos;          
        }
        */

        public tipo_pessoa selecionarTipo_porCodigo(tipo_pessoa objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + PESSOA_TIPO_TABELA + " WHERE "+PESSOA_TIPO_CODIGO+" = "+ objeto.getCod_tipo_pessoa_pk()+" LIMIT 1 ";
            leitor = Query.ExecuteReader();
           tipo_pessoa tipo = new tipo_pessoa();
            while (leitor.Read())
            {
                tipo.setCod_tipo_pessoa_pk(leitor.GetInt32(PESSOA_TIPO_CODIGO));
                tipo.setNome_tipo_pessoa(leitor.GetString(PESSOA_TIPO_NOME));
            }
            leitor.Close();
            return tipo;
        }
    }
}
