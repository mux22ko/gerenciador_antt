using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using gerenciador_antt.Classes_Objetos;
using gerenciador_antt.Classes_Auxiliares;
using gerenciador_antt.Formularios;
using Transitions;

namespace gerenciador_antt
{
    public partial class frm_principal : Form, uc_identificacao, conteudos_dinamicos
    {
        #region DADOS
        //codigo do atendente responsavel, que norteia o acesso ao sistema!
        private atendente atendente = null;
        #endregion

        #region Inicializadores
        public frm_principal()
        {
            InitializeComponent();
        }
        #endregion

        #region SESSÃO
        private void deslogarAtendente()
        {
            //remove o responsavel atendente logado!
            this.atendente = null;
            //limpa a área de conteudo carregada!
            this.pnl_conteudo.Controls.Clear();
            //fecha de volta a barrinha de opções!
            this.fecharBarra_lateral_opcoes();
            //volta o titulo inicial!
            alterar_titulo_descricao_tela(getTitulo(),getDescricao());
            //apresenta a tela para o próximo atendente logar!
            logarAtendente();
            //se o responsavel não for valido, ao fechar do login, o programa fecha!
            if (!validarAtendente())
            {
                this.Close();
            }
        }
        private void logarAtendente()
        {
            //tela de login!
            frm_login login = new frm_login(this);
            //apresenta a tela de login!
            login.ShowDialog();
            //se o responsavel não for valido, ao fechar do login, o programa fecha!
            if (!validarAtendente())
            {
                this.Close();
            }            
            //menu recebe o atendente logado!
            Uc_menu_principal menuPricipal = new Uc_menu_principal(this);
            //carrego o conteudo do menu!
            carregarConteudo_principal(menuPricipal,true);
            //carregar titulo da área aberta!
            alterar_titulo_descricao_tela(menuPricipal.getTitulo(), menuPricipal.getDescricao());
        }

        public void setAtendente(atendente responsavel)
        {
            //método público usado pelo formulario de login para setar o responsável logado!
            //sendo o atendente existente pode setar!
            if (responsavel.getCod_atendente_pk() > 0)
            {
                this.atendente = responsavel;
            }
        }

        public atendente getAtendente()
        {
            //método público usado por qualquer formulário que precise do atendente para realizar transações!
            return this.atendente;
        }

        private bool validarAtendente()
        {
            //método que verifica se o responsável está setado ou não!
            if (this.atendente != null)
            {
                if (this.atendente.getCod_atendente_pk() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion
        
        #region ROTINAS
        private void frm_menu_Load(object sender, EventArgs e)
        {
            //requisitar login do atendente!
            logarAtendente();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);

        }

        private void frm_menu_KeyUp(object sender, KeyEventArgs e)
        {
            //Atalhos!
            /*if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show(null,"Deseja realmente sair do sistema?","Atenção!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.Close();
                }
            }*/
            if (e.KeyData == (Keys.Tab | Keys.Control)) 
            {
               alternarEntreConteudosCarregados();
             }           
        }       
        
        private void frm_menu_MouseMove(object sender, MouseEventArgs e)
        {
            //movimento da barra lateral de opções!Inicio
            if ((this.Width - e.X)<=45)
            {
                abrirBarra_lateral_opcoes();
            }
            else if ((this.Width - e.X)<=147)
            {
                fecharBarra_lateral_opcoes();   
            }
            //movimento da barra lateral de opções!Fim
        }
        private void abrirBarra_lateral_opcoes()
        {
            int i = 0;
            for (i = 0; i < 90; i++)
            {
                pnl_lateral_opcao.Location = new Point(pnl_lateral_opcao.Location.X - 1, pnl_lateral_opcao.Location.Y);
            }
        }
        private void fecharBarra_lateral_opcoes()
        {
            int i = 0;
            for (i = 0; i < 90;i++ )
            {
                  pnl_lateral_opcao.Location = new Point(pnl_lateral_opcao.Location.X+1,pnl_lateral_opcao.Location.Y);
            }
        }
        private void pctbx_deslogar_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Deseja realmente fazer encerrar as atividades e fazer Logoff?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.deslogarAtendente();
            }
        }
        private void pctbx_config_Click(object sender, EventArgs e)
        {
            Uc_menu_config menu = new Uc_menu_config(this);
            carregarConteudo_principal(menu, false);
        }

        private void pnl_conteudo_ControlRemoved(object sender, ControlEventArgs e)
        {

            try
            {
                uc_identificacao id = (uc_identificacao)this.pnl_conteudo.Controls[0];
                alterar_titulo_descricao_tela(id.getTitulo(), id.getDescricao());
            }
            catch { }

        }
        #endregion

        #region AÇÕES BOTÕES
        private void pctbx_calculadora_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }
        #endregion

        #region Membros de uc_identificacao

        public string getTitulo()
        {
            return "ANTT";
        }

        public string getDescricao()
        {
            return "Bem Vindo ao Sistema";
        }
        public int getModoAtual()
        {
            throw new NotImplementedException();
        }
        public Object getControleAbas()
        {
            return null;
        }        
        #endregion                  
    
        #region Membros de conteudos_dinamicos
       public void alterar_titulo_descricao_tela(String titulo, String descricao)
        {
            lbl_titulo_tela.Text = titulo;
            lbl_descricao_tela.Text = descricao;
            this.Refresh();
        }

       public void carregarConteudo_principal(Control controle, Boolean permitirDuplicata)
        {
            utilidades.carregarConteudoPrincipal(this, pnl_conteudo, permitirDuplicata, controle);
            this.Refresh();
        }

       public void alternarEntreConteudosCarregados()
        {
            utilidades.alternarConteudosCarregadosPrincipal(this, this.pnl_conteudo);
            this.Refresh();
        }

       public void fecharConteudoCarregado(Control conteudo)
        {
            utilidades.fecharConteudoCarregadoForm(conteudo, this.pnl_conteudo);
            this.Refresh();
        }
       public Panel getPainelConteudos()
       {
           return this.pnl_conteudo;
       }
        #endregion
       
    }
}
