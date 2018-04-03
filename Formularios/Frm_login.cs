using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using gerenciador_antt.Classes_Auxiliares;
using gerenciador_antt.Classes_Dados;
using gerenciador_antt.Classes_Objetos;

namespace gerenciador_antt
{
    public partial class frm_login : Form
    {       
        //objeto interno do menu!
        frm_principal principal = new frm_principal();
        //dados!
        dados_atendente dadosAtendente = new dados_atendente();

        public frm_login(frm_principal principal)
        {
            //se não receber o objeto menu ele fecha o login!
            this.principal = principal;
            if (principal == null)
            {
                this.Close();
            }
            else
            {
                InitializeComponent();
            }
        }

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            //desliga o botao entrar!
            this.btn_entrar.Visible = false;
            //se não estiver rodando outra thread de confirmação de login ele inicia uma!
            if (!bgwk_acessar.IsBusy)
            {
                bgwk_acessar.RunWorkerAsync();
            }
        }

        private void bgwk_acessar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //ao completar a confirmaçãod e login ele volta o botao e volta o texto de status original!
           this.btn_entrar.Visible = true;               
           alterarTexto("Liberando acesso, Aguarde...");
        }

        private void bgwk_acessar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //altera o progresso da barra toda vez quando o processo da thread for setado!
            this.pgbar_acessando.Value = e.ProgressPercentage;
        }

        //método de alterar o texto de status com metodologia publica entre threads! 
        public void alterarTexto(String texto)
        {
            if (this.InvokeRequired)
            {
                this.Invoke
                (
                (MethodInvoker) delegate {alterarTexto(texto);}
                );                
                return;
            }
            this.lbl_liberando_acesso.Text = texto;
        }

        //método de fechar o formulario com metodologia publica entre threads!
        public void fechar()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(this.fechar));
                return;
            }
            this.Close();
        }

        private void bgwk_acessar_DoWork(object sender, DoWorkEventArgs e)
        {  
            //método de realização da thread!
            //inicio com 15%!
            try
            {
                bgwk_acessar.ReportProgress(15);
                if (conexaoBD.abrirConexao())
                {
                    int i = 10;
                    for (i = 0; i <= 40; i++)
                    {
                        //espera 10mls!
                        Thread.Sleep(5);
                        //seto o progresso!
                        bgwk_acessar.ReportProgress(i);
                    }
                    bgwk_acessar.ReportProgress(5);
                    //
                    atendente atendente = new atendente();
                    atendente.setUsuario_atendente(txt_login.Text);
                    atendente.setSenha_atendente(txt_senha.Text);
                    //
                    bgwk_acessar.ReportProgress(5);
                    if (conexaoBD.abrirConexao())
                    {
                        //atendente recebe os dados de um possivel atendente encontrado!
                        atendente = (dadosAtendente.selecionarUmAtendente_porUsuario_Senha(atendente));
                    }
                    //se o codigo de atendente é maior que zero entao encontrou um!
                    if (atendente.getCod_atendente_pk() > 0)
                    {
                        for (i = 50; i <= 100; i++)
                        {
                            Thread.Sleep(5);
                            bgwk_acessar.ReportProgress(i);
                        }
                        //o responsavel em Menu recebe esses dados do atendente encontrado e logado!
                        this.principal.setAtendente(atendente);
                        //mensagem de bmvindo!
                        alterarTexto("Bem vindo: " + atendente.getNome_atendente() + " - " + DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString());
                        Thread.Sleep(500);
                        //fecho o formulario de login!                   
                        this.fechar();
                    }
                    else
                    {
                        //caso nao logar, ele cancela!
                        for (i = 50; i <= 100; i++)
                        {
                            Thread.Sleep(1);
                            bgwk_acessar.ReportProgress(i);
                        }
                        alterarTexto("Usuário não Encontrado!");
                        Thread.Sleep(2000);
                        bgwk_acessar.CancelAsync();
                    }
                }
                else
                {
                    //caso nao conectar no BD ele cancela
                    bgwk_acessar.CancelAsync();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Ops, ocorreu um erro em: " + erro.Source);
            }
        }

        private void frm_login_KeyUp(object sender, KeyEventArgs e)
        {
            //automação de tarefas ao precionar algumas teclas!
            if(e.KeyCode==Keys.Escape)
            {
                if (MessageBox.Show(null, "Deseja realmente fechar o sistema?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            if((e.KeyCode==Keys.Enter)&&!(txt_login.Text == String.Empty)&&!(txt_senha.Text == String.Empty))
            {
                btn_entrar_Click(this,null);
            }
        }

        private void frm_login_Load(object sender, EventArgs e)
        {

        }           
    }
}
