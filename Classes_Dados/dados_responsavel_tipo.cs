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
    class dados_responsavel_tipo
    {
        //Tabela
        public const String RESPONSAVEL_TIPO_TABELA = "tab_tipo_responsavel";
        //Campos
        public const String
        RESPONSAVEL_TIPO_CODIGO = "cod_tipo_responsavel_pk",
        RESPONSAVEL_TIPO_NOME = "nome_tipo_responsavel";
        //Campos

        //objetos banco
        MySqlCommand Query = new MySqlCommand();
        MySqlDataReader leitor;
        //objetos banco

        //Selecionar
        public List<tipo_responsavel> selecionarTodosTipos()
        {
          Query.Dispose();
          Query.Parameters.Clear();
          Query.Connection = conexaoBD.getConexao();
          Query.CommandText = "SELECT * FROM "+RESPONSAVEL_TIPO_TABELA+" ORDER BY "+RESPONSAVEL_TIPO_NOME+" ASC";
          leitor = Query.ExecuteReader();         
          List<tipo_responsavel> todosTipos= new List<tipo_responsavel>();
          while(leitor.Read())
          {
              tipo_responsavel tipo = new tipo_responsavel();
              tipo.setCod_tipo_responsavel_pk(leitor.GetInt32(RESPONSAVEL_TIPO_CODIGO));
              tipo.setNome_tipo_responsavel(leitor.GetString(RESPONSAVEL_TIPO_NOME));
              todosTipos.Add(tipo);
          }
          leitor.Close();
          return todosTipos;          
        }

        public tipo_responsavel selecionarUmTipo_porCodigo(tipo_responsavel tipo_responsavel)
        {
            Query.Dispose();
            Query.Parameters.Clear();
            Query.Connection = conexaoBD.getConexao();
            Query.CommandText = "SELECT * FROM " + RESPONSAVEL_TIPO_TABELA + " WHERE " + RESPONSAVEL_TIPO_CODIGO + " = " + tipo_responsavel.getCod_tipo_responsavel_pk();
            leitor = Query.ExecuteReader();
            tipo_responsavel tipo = new tipo_responsavel();
            while (leitor.Read())
            {
                
                tipo.setCod_tipo_responsavel_pk(leitor.GetInt32(RESPONSAVEL_TIPO_CODIGO));
                tipo.setNome_tipo_responsavel(leitor.GetString(RESPONSAVEL_TIPO_NOME));
            }
            leitor.Close();
            return tipo;
        }
    }
}
