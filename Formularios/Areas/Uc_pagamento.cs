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
    public partial class Uc_pagamento : UserControl, uc_identificacao, conteudos_dinamicos
    {
        #region DADOS
        public frm_principal principal = null;
        #endregion

        #region inicializadores
        public Uc_pagamento(frm_principal principal)
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
        #endregion

        #region ROTINAS
        private void Uc_atendimento_Load(object sender, EventArgs e)
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
        private void pnl_cadastrar_atendimento_botao_Click(object sender, EventArgs e)
        {
            utilidades.carregarConteudoUControle(this,this.pnl_conteudo,false,new Uc_pagamento_cadastro(principal));
        }
        private void pnl_pagamento_botao_Click(object sender, EventArgs e)
        {
            alternarEntreConteudosCarregados();
        }
        private void pnl_atendimento_botao_Click(object sender, EventArgs e)
        {
            alternarEntreConteudosCarregados();
        }

        private void pnl_pesquisar_atendimento_botao_Click(object sender, EventArgs e)
        {
            utilidades.carregarConteudoUControle(this, this.pnl_conteudo, false, new Uc_pagamento_pesquisa(principal));
        }
        #endregion

        #region Membros de uc_identificacao
        public String getTitulo()
        {
            return "Pagamento";
        }
        public String getDescricao()
        {
            return "Área de gerenciamento de Pagamentos";
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
        private void pnl_cadastrar_atendimento_botao_MouseUp(object sender, MouseEventArgs e)
        {
            pnl_cadastrar_atendimento_botao.BackColor = Color.FromArgb(17, 121, 30);
        }
        private void pnl_cadastrar_atendimento_botao_MouseHover(object sender, EventArgs e)
        {
            pnl_cadastrar_atendimento_botao.BackColor = Color.FromArgb(17, 121, 30);
        }
        private void pnl_cadastrar_atendimento_botao_MouseLeave(object sender, EventArgs e)
        {
            pnl_cadastrar_atendimento_botao.BackColor = Color.FromArgb(7, 97, 18);
        }
        private void pnl_cadastrar_atendimento_botao_MouseDown(object sender, MouseEventArgs e)
        {
            pnl_cadastrar_atendimento_botao.BackColor = Color.FromArgb(29, 167, 46);
        }
        private void pnl_pesquisar_atendimento_botao_MouseUp(object sender, MouseEventArgs e)
        {
            pnl_pesquisar_atendimento_botao.BackColor = Color.FromArgb(17, 121, 30);
        }
        private void pnl_pesquisar_atendimento_botao_MouseDown(object sender, MouseEventArgs e)
        {
            pnl_pesquisar_atendimento_botao.BackColor = Color.FromArgb(29, 167, 46);
        }
        private void pnl_pesquisar_atendimento_botao_MouseHover(object sender, EventArgs e)
        {
            pnl_pesquisar_atendimento_botao.BackColor = Color.FromArgb(17, 121, 30);
        }
        private void pnl_pesquisar_atendimento_botao_MouseLeave(object sender, EventArgs e)
        {
            pnl_pesquisar_atendimento_botao.BackColor = Color.FromArgb(7, 97, 18);
        }
        private void pnl_pagamento_botao_MouseUp(object sender, MouseEventArgs e)
        {
            pnl_pagamento_botao.BackColor = Color.Orange;
        }
        private void pnl_pagamento_botao_MouseLeave(object sender, EventArgs e)
        {
            pnl_pagamento_botao.BackColor = Color.Transparent;
        }
        private void pnl_pagamento_botao_MouseHover(object sender, EventArgs e)
        {
            pnl_pagamento_botao.BackColor = Color.Orange;
        }
        private void pnl_pagamento_botao_MouseEnter(object sender, EventArgs e)
        {
            pnl_pagamento_botao.BackColor = Color.Orange;
        }
        private void pnl_pagamento_botao_MouseDown(object sender, MouseEventArgs e)
        {
            pnl_pagamento_botao.BackColor = Color.Goldenrod;
        }
        #endregion
    }        
}
