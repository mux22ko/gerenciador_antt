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
    class dados_alerta
    {
        //Tabela
        public const String ALERTA_TABELA = "tab_alerta";
        //Campos
        public const String 
        ALERTA_CODIGO = "cod_alerta_pk", 
        ALERTA_CODIGO_CLIENTE = "cod_cli_fk",
        ALERTA_DESCRICAO = "descricao_alerta",
        ALERTA_OBSERVACAO = "observacao_alerta",
        ALERTA_ESTADO = "status_alerta",
        ALERTA_TIPO = "tipo_alerta";
        //Campos

        //objetos banco
        MySqlCommand Query = new MySqlCommand();
        MySqlDataReader leitor;
        //objetos banco

        //Cadastrar
        public Boolean cadastrarUmAlerta(alerta objeto)
        {
            /*Query.Connection = ConexaoBD.getConexao();
            Query.CommandText = "INSERT INTO @Tabela ("+ALERTA_CODIGO_CLIENTE+","+
                ALERTA_DESCRICAO+","+
                ALERTA_OBSERVACAO+","+
                ALERTA_ESTADO+","+
                ALERTA_TIPO+")"+
                "values(@Cod_Cli, @Des, @Obs, @Est, @Tip)";
            Query.Parameters.AddWithValue("@Tabela", ALERTA_TABELA);
            Query.Parameters.AddWithValue("@Cod_Cli", objeto.getCod_cliente().ToString());
            Query.Parameters.AddWithValue("@Des", objeto.getDescricao().ToString());
            Query.Parameters.AddWithValue("@Obs", objeto.getObservacao().ToString());
            Query.Parameters.AddWithValue("@Est", objeto.getEstado().ToString());
            Query.Parameters.AddWithValue("@Tip", objeto.getTipo().ToString());
            Query.Prepare();
            Query.ExecuteNonQuery();
            if ((leitor = Query.ExecuteReader()).RecordsAffected > 0)
            {
                return true;
            }
            else 
            {
                return false;
            }*/
            return true;
            
        }
        //Selecionar
        public List<alerta> selecionarTodosAlertas()
        {
         /* Query.CommandText = "SELECT * FROM @Tabela";
          Query.Parameters.AddWithValue("@Tabela", ALERTA_TABELA);
          Query.Prepare();
          Query.ExecuteNonQuery();
          leitor = Query.ExecuteReader();
          alerta alerta = new alerta();
          List<alerta> todosAlertas= new List<alerta>();
          while(leitor.Read())
          {
              alerta.setCod_alerta(leitor.GetInt32(ALERTA_CODIGO));
              alerta.setCod_cliente(leitor.GetInt32(ALERTA_CODIGO_CLIENTE));
              alerta.setDescricao(leitor.GetString(ALERTA_DESCRICAO));
              alerta.setObservacao(leitor.GetString(ALERTA_OBSERVACAO));
              alerta.setEstado(leitor.GetChar(ALERTA_ESTADO));
              alerta.setTipo(leitor.GetChar(ALERTA_TIPO));
              todosAlertas.Add(alerta);
          }         */ List<alerta> todosAlertas= new List<alerta>();  
          return todosAlertas;          
        }
        public alerta selecionarUmAlerta_porCodigo(alerta objeto)
        {            
          /*  Query.CommandText = "SELECT * FROM @Tabela WHERE @Cod = @Cod_obj limit 1";
            Query.Parameters.AddWithValue("@Tabela", ALERTA_TABELA);
            Query.Parameters.AddWithValue("@Cod", ALERTA_CODIGO);
            Query.Parameters.AddWithValue("@Cod_obj", objeto.getCod_alerta().ToString());
            Query.Prepare();
            Query.ExecuteNonQuery();
            leitor = Query.ExecuteReader();
                       
            while (leitor.Read())
            {
                alerta.setCod_alerta(leitor.GetInt32(ALERTA_CODIGO));
                alerta.setCod_cliente(leitor.GetInt32(ALERTA_CODIGO_CLIENTE));
                alerta.setDescricao(leitor.GetString(ALERTA_DESCRICAO));
                alerta.setObservacao(leitor.GetString(ALERTA_OBSERVACAO));
                alerta.setEstado(leitor.GetChar(ALERTA_ESTADO));
                alerta.setTipo(leitor.GetChar(ALERTA_TIPO));   */             
            
            alerta alertas = new alerta(); 
            return alertas;}
        //}
    }
}
