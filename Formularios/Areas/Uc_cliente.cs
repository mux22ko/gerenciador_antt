using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using gerenciador_antt.Classes_Objetos;
using gerenciador_antt.Classes_Dados;
using gerenciador_antt.Classes_Auxiliares;
using Transitions;
using System.Threading;

namespace gerenciador_antt.Formularios
{
    public partial class Uc_cliente : UserControl, uc_identificacao, conteudos_dinamicos
    {
        #region DADOS
        public frm_principal principal = null;
        #endregion

        #region inicializadores
        public Uc_cliente(frm_principal principal)
        {
            this.principal = principal;
            if (principal.getAtendente() != null)
            {
                InitializeComponent();
            }
            else
            {
                MessageBox.Show("Esteja logado para acessar esta área!");
            }
        }       
        #endregion

        #region FUNÇÕES

        private Control verificarExistenciaControle_mesmoTipo(Control controle)
        {
            foreach (Control i in this.pnl_conteudo.Controls)
            {
                if (i.GetType() == controle.GetType())
                {
                    try
                    {
                        uc_identificacao atual = (uc_identificacao)i;
                        uc_identificacao novoComparado = (uc_identificacao)controle;
                        if (atual.getModoAtual() == novoComparado.getModoAtual())
                        {
                            return i;
                        }                        
                    }
                    catch
                    {
                        return i;
                    }
                    
                }
            }
            return null;
        }        
        
        #endregion

        #region ROTINAS
        private void Uc_cliente_Load(object sender, EventArgs e)
        {
            this.Size = this.Parent.Size;            
            if (conexaoBD.abrirConexao())
            {
                //adiciona items alertas/problemas na lista!
            }
        }
        private void pnl_conteudo_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (this.pnl_conteudo.Controls.Count < 1)
            {
                principal.fecharConteudoCarregado(this);
            }
            else
            {
            try
            {
                uc_identificacao id = (uc_identificacao)this.pnl_conteudo.Controls[0];
                alterar_titulo_descricao_tela(id.getTitulo(), id.getDescricao());
            }
            catch { }
            }
        }                
        #endregion                  

        #region AÇÕES DE BOTÕES
        private void pnl_cadastrar_cliente_botao_Click(object sender, EventArgs e)
        {
           utilidades.carregarConteudoUControle(this,this.pnl_conteudo,false,new Uc_cliente_cadastro(principal));
           this.Refresh();
        }        
        private void pnl_pesquisar_cliente_botao_Click(object sender, EventArgs e)
        {
            utilidades.carregarConteudoUControle(this,this.pnl_conteudo,false,new Uc_cliente_pesquisa(principal));
            this.Refresh();
        }
        private void pnl_cliente_botao_Click(object sender, EventArgs e)
        {
            alternarEntreConteudosCarregados();
        }
        #endregion

        #region Membros de uc_identificacao
        public String getTitulo()
        {
            return "Cliente";
        }
        public String getDescricao()
        {
            return "Área de gerenciamento de Clientes";
        }
        public int getModoAtual()
        {
            throw new NotImplementedException();
        }
        public Object getControleAbas()
        {
            return this.pnl_conteudo;
        }
        #endregion

        #region Membros de conteudos_dinamicos
        public void alterar_titulo_descricao_tela(String titulo, String descricao)
        {
            //captar a instancia de tela que o painel em que sera inserido essa área pertence!
            //partindo do principio de painel sendo filho da tela.
            conteudos_dinamicos cd = (conteudos_dinamicos)this.Parent.Parent;
            //alterar com a referencia do pai!
            cd.alterar_titulo_descricao_tela(titulo, descricao);
        }
        public void carregarConteudo_principal(Control controle, Boolean permitirDuplicata)
        {
            utilidades.carregarConteudoUControle(this, pnl_conteudo, permitirDuplicata, controle);
            this.Refresh();
        }
        public void alternarEntreConteudosCarregados()
        {
            utilidades.alternarConteudosCarregadosUC(this, this.pnl_conteudo);
            this.Refresh();
        }
        public void fecharConteudoCarregado(Control controle)
        {
            utilidades.fecharConteudoCarregadoUC(controle, this.pnl_conteudo);
            this.Refresh();
        }
        public Panel getPainelConteudos()
        {
            return this.pnl_conteudo;
        }
        #endregion

        #region EFEITO BOTÕES
        private void pnl_cadastrar_cliente_botao_MouseLeave(object sender, EventArgs e)
        {
            pnl_cadastrar_cliente_botao.BackColor = Color.FromArgb(15, 50, 52);
        }
        private void pnl_cadastrar_cliente_botao_MouseHover(object sender, EventArgs e)
        {
            pnl_cadastrar_cliente_botao.BackColor = Color.FromArgb(29, 61, 63);
        }
        private void pnl_cadastrar_cliente_botao_MouseDown(object sender, MouseEventArgs e)
        {
            pnl_cadastrar_cliente_botao.BackColor = Color.FromArgb(70, 102, 104);
        }
        private void pnl_cadastrar_cliente_botao_MouseUp(object sender, MouseEventArgs e)
        {
            pnl_cadastrar_cliente_botao.BackColor = Color.FromArgb(29, 61, 63);
        }
        private void pnl_pesquisar_cliente_botao_MouseDown(object sender, MouseEventArgs e)
        {
            pnl_pesquisar_cliente_botao.BackColor = Color.FromArgb(70, 102, 104);
        }
        private void pnl_pesquisar_cliente_botao_MouseHover(object sender, EventArgs e)
        {
            pnl_pesquisar_cliente_botao.BackColor = Color.FromArgb(29, 61, 63);
        }
        private void pnl_pesquisar_cliente_botao_MouseLeave(object sender, EventArgs e)
        {
            pnl_pesquisar_cliente_botao.BackColor = Color.FromArgb(15, 50, 52);
        }
        private void pnl_pesquisar_cliente_botao_MouseUp(object sender, MouseEventArgs e)
        {
            pnl_pesquisar_cliente_botao.BackColor = Color.FromArgb(29, 61, 63);
        }
        private void pnl_cliente_botao_MouseUp(object sender, MouseEventArgs e)
        {
            pnl_cliente_botao.BackColor = Color.Orange;
        }
        private void pnl_cliente_botao_MouseLeave(object sender, EventArgs e)
        {
            pnl_cliente_botao.BackColor = Color.Transparent;
        }
        private void pnl_cliente_botao_MouseHover(object sender, EventArgs e)
        {
            pnl_cliente_botao.BackColor = Color.Orange;
        }
        private void pnl_cliente_botao_MouseEnter(object sender, EventArgs e)
        {
            pnl_cliente_botao.BackColor = Color.Orange;
        }
        private void pnl_cliente_botao_MouseDown(object sender, MouseEventArgs e)
        {
            pnl_cliente_botao.BackColor = Color.Goldenrod;
        }
        #endregion
                
    }        
}
