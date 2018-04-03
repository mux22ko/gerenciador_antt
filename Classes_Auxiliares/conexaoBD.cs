
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Threading;

namespace gerenciador_antt.Classes_Auxiliares
{
    class conexaoBD
    {
        static String conexaoString;
        static MySqlConnection conexao;
 
        public conexaoBD()
        {
            setar();
        }
        private static void setar()
        {
            conexaoString = "Server=" + Properties.Settings.Default.serverLocal.ToString() + ";"
            + "Database=" + Properties.Settings.Default.bdNome + ";"
            + "Uid=" + Properties.Settings.Default.usuario1 +
            ";Pwd=" + Properties.Settings.Default.senha1 + ";";
            conexao = new MySqlConnection(conexaoString);
        }
        public static Boolean abrirConexao()
        {            
            try
            {
                setar();   
                if (conexao.State == ConnectionState.Open)
                {
                    //aberta Conexão!
                    return true;
                }
                else
                {
                    conexao.Open();
                    if (conexao.State == ConnectionState.Open)
                    {
                        //aberta Conexao!
                        return true;
                    }
                    //Não conseguiu abrir!
                    return false;
                }                
            }catch(Exception e)
            {
                MessageBox.Show("Não foi possível Conectar!\n" + e.Message);
                return false;
            }            
        }
        public static void fecharConexao()
        {
            if (conexao.State == ConnectionState.Open)
            {
                //fecha a Conexão!
                conexao.Close();
            }
            else
            {
                //faça nada!
            }
        }
        public static MySqlConnection getConexao()
        {
            return conexao;
        }
        public static void aguardarUsoBdParalelo()
        {
            int count = 0;
            while (conexaoBD.getConexao().State == ConnectionState.Fetching)
            {
                Thread.Sleep(1000);
                count++;
                if (count == 10)
                {
                    break;
                }
            }
        }
    }
}
