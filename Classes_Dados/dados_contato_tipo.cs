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
    class dados_contato_tipo
    {
        //Tabela
        public const String CONTATO_TIPO_TABELA = "tab_tipo_contato";
        //Campos
        public const String
        CONTATO_TIPO_CODIGO = "cod_tipo_contato_pk",
        CONTATO_TIPO_NOME = "nome_tipo_contato";
        //Campos

        //objetos banco
        MySqlCommand Query = new MySqlCommand();
        MySqlDataReader leitor;
        //objetos banco

        //Selecionar
        public List<tipo_contato> selecionarTodosTipos()
        {
          Query.Dispose();
          Query.Parameters.Clear();
          Query.Connection = conexaoBD.getConexao();
          Query.CommandText = "SELECT * FROM "+CONTATO_TIPO_TABELA+" ORDER BY "+CONTATO_TIPO_NOME+" ASC";
          leitor = Query.ExecuteReader();         
          List<tipo_contato> todosTipos= new List<tipo_contato>();
          while(leitor.Read())
          {
              tipo_contato tipo = new tipo_contato();
              tipo.setCod_tipo_contato_pk(leitor.GetInt32(CONTATO_TIPO_CODIGO));
              tipo.setNome_tipo_contato(leitor.GetString(CONTATO_TIPO_NOME));
              todosTipos.Add(tipo);
          }
          leitor.Close();
          return todosTipos;          
        }
        public tipo_contato selecionarTipo_porCodigo(tipo_contato objeto)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + CONTATO_TIPO_TABELA + " WHERE "+CONTATO_TIPO_CODIGO+" = "+ objeto.getCod_tipo_contato_pk()+" LIMIT 1 ";
            leitor = Query.ExecuteReader();
           tipo_contato tipo = new tipo_contato();
            while (leitor.Read())
            {
                tipo.setCod_tipo_contato_pk(leitor.GetInt32(CONTATO_TIPO_CODIGO));
                tipo.setNome_tipo_contato(leitor.GetString(CONTATO_TIPO_NOME));
            }
            leitor.Close();
            return tipo;
        }
    }
}
