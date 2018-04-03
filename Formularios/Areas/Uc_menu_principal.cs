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
using System.Drawing.Drawing2D;

namespace gerenciador_antt.Formularios
{
    public partial class Uc_menu_principal : UserControl, uc_identificacao
    {
        #region DADOS
        frm_principal principal = null;
        #endregion

        #region inicializadores
        public Uc_menu_principal(frm_principal principal)
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
        
        #region ROTINAS
        private void Uc_menu_principal_Load(object sender, EventArgs e)
        {
            this.Width = Parent.Size.Width;
            this.Height = Parent.Size.Height;
            pnl_centro.Location = new Point(((this.Width - pnl_centro.Size.Width) / 2), ((this.Height - pnl_centro.Size.Height) / 2));
        }
        #endregion

        #region AÇÕES DO BOTAO
        private void pnl_cliente_botao_Click(object sender, EventArgs e)
        {
            this.principal.carregarConteudo_principal(new Uc_cliente(principal), false);
            this.Refresh();
        }

        private void pnl_atendimento_botao_Click(object sender, EventArgs e)
        {
            principal.carregarConteudo_principal(new Uc_atendimento(principal), false);
            this.Refresh();
        }

        private void pnl_documento_botao_Click(object sender, EventArgs e)
        {

        }

        private void pnl_envio_botao_Click(object sender, EventArgs e)
        {

        }

        private void pnl_alerta_botao_Click(object sender, EventArgs e)
        {

        }

        private void pnl_problema_botao_Click(object sender, EventArgs e)
        {

        }

        private void pnl_mensagem_botao_Click(object sender, EventArgs e)
        {

        }

        private void pnl_tabela_servico_botao_Click(object sender, EventArgs e)
        {

        }

        private void pnl_pagamento_botao_Click(object sender, EventArgs e)
        {
            this.principal.carregarConteudo_principal(new Uc_pagamento(principal),true);
            this.Refresh();
        }

        private void pnl_responsavel_botao_Click(object sender, EventArgs e)
        {
            this.principal.carregarConteudo_principal(new Uc_responsavel(principal), true);
            this.Refresh();
        }
        #endregion

        #region EFEITO BOTÃO
        //CLIENTE
        private void pnl_cliente_botao_MouseHover(object sender, EventArgs e)
        {
            pnl_cliente_botao.BackColor = Color.FromArgb(29, 61, 63);
        }
        private void pnl_cliente_botao_MouseLeave(object sender, EventArgs e)
        {
            pnl_cliente_botao.BackColor = Color.FromArgb(15, 50, 52);
        }
        private void pnl_cliente_botao_MouseDown(object sender, MouseEventArgs e)
        {
            pnl_cliente_botao.BackColor = Color.FromArgb(70, 102, 104);
        }
        private void pnl_cliente_botao_MouseUp(object sender, MouseEventArgs e)
        {
            pnl_cliente_botao.BackColor = Color.FromArgb(29, 61, 63);
        }

        //ATENDIMENTO
        private void pnl_atendimento_botao_MouseHover(object sender, EventArgs e)
        {
            pnl_atendimento_botao.BackColor = Color.FromArgb(73, 73, 197);
        }
        private void pnl_atendimento_botao_MouseLeave(object sender, EventArgs e)
        {
            pnl_atendimento_botao.BackColor = Color.FromArgb(56, 56, 208);
        }       
        private void pnl_atendimento_botao_MouseDown(object sender, MouseEventArgs e)
        {
            pnl_atendimento_botao.BackColor = Color.FromArgb(107, 107, 191);
        }
        private void pnl_atendimento_botao_MouseUp(object sender, MouseEventArgs e)
        {
            pnl_atendimento_botao.BackColor = Color.FromArgb(73, 73, 197);
        }

        //PAGAMENTO
        private void pnl_pagamento_botao_MouseEnter(object sender, EventArgs e)
        {
            pnl_pagamento_botao.BackColor = Color.FromArgb(17, 121, 30);
        }
        private void pnl_pagamento_botao_MouseLeave(object sender, EventArgs e)
        {
            pnl_pagamento_botao.BackColor = Color.FromArgb(7, 97, 18);
        }
        private void pnl_pagamento_botao_MouseUp(object sender, MouseEventArgs e)
        {
            pnl_pagamento_botao.BackColor = Color.FromArgb(17, 121, 30);
        }
        private void pnl_pagamento_botao_MouseDown(object sender, MouseEventArgs e)
        {
            pnl_pagamento_botao.BackColor = Color.FromArgb(29, 167, 46);
        }

        //RESPONSAVEL
        private void pnl_responsavel_botao_MouseEnter(object sender, EventArgs e)
        {
            pnl_responsavel_botao.BackColor = Color.FromArgb(16, 118, 137);
        }
        private void pnl_responsavel_botao_MouseLeave(object sender, EventArgs e)
        {
            pnl_responsavel_botao.BackColor = Color.FromArgb(11, 100, 117);
        }
        private void pnl_responsavel_botao_MouseUp(object sender, MouseEventArgs e)
        {
            pnl_responsavel_botao.BackColor = Color.FromArgb(16, 118, 137);
        }
        private void pnl_responsavel_botao_MouseDown(object sender, MouseEventArgs e)
        {
            pnl_responsavel_botao.BackColor = Color.FromArgb(51, 133, 148);
        }

        //SERVIÇO
        private void pnl_tabela_servico_botao_MouseEnter(object sender, EventArgs e)
        {
            pnl_tabela_servico_botao.BackColor = Color.FromArgb(29, 65, 148);
        }
        private void pnl_tabela_servico_botao_MouseLeave(object sender, EventArgs e)
        {
            pnl_tabela_servico_botao.BackColor = Color.FromArgb(21, 53, 128);
        }
        private void pnl_tabela_servico_botao_MouseUp(object sender, MouseEventArgs e)
        {
            pnl_tabela_servico_botao.BackColor = Color.FromArgb(29, 65, 148);
        }
        private void pnl_tabela_servico_botao_MouseDown(object sender, MouseEventArgs e)
        {
            pnl_tabela_servico_botao.BackColor = Color.FromArgb(64, 93, 161);
        }
        
        //ALERTA
        private void pnl_alerta_botao_MouseEnter(object sender, EventArgs e)
        {
            pnl_alerta_botao.BackColor = Color.FromArgb(222, 76, 22);
        }
        private void pnl_alerta_botao_MouseLeave(object sender, EventArgs e)
        {
            pnl_alerta_botao.BackColor = Color.FromArgb(191, 61, 13);
        }
        private void pnl_alerta_botao_MouseUp(object sender, MouseEventArgs e)
        {
            pnl_alerta_botao.BackColor = Color.FromArgb(222, 76, 22);
        }
        private void pnl_alerta_botao_MouseDown(object sender, MouseEventArgs e)
        {
            pnl_alerta_botao.BackColor = Color.FromArgb(241, 123, 79);
        }
        
        //PROBLEMA
        private void pnl_problema_botao_MouseEnter(object sender, EventArgs e)
        {
            pnl_problema_botao.BackColor = Color.FromArgb(172, 47, 0);
        }
        private void pnl_problema_botao_MouseLeave(object sender, EventArgs e)
        {
            pnl_problema_botao.BackColor = Color.FromArgb(144, 39, 0);
        }
        private void pnl_problema_botao_MouseUp(object sender, MouseEventArgs e)
        {
            pnl_problema_botao.BackColor = Color.FromArgb(172, 47, 0);
        }
        private void pnl_problema_botao_MouseDown(object sender, MouseEventArgs e)
        {
            pnl_problema_botao.BackColor = Color.FromArgb(234, 63, 0);
        }

        //MENSAGEM
        private void pnl_mensagem_botao_MouseEnter(object sender, EventArgs e)
        {
            pnl_mensagem_botao.BackColor = Color.FromArgb(168, 160, 0);
        }
        private void pnl_mensagem_botao_MouseLeave(object sender, EventArgs e)
        {
            pnl_mensagem_botao.BackColor = Color.FromArgb(145, 138, 0);
        }
        private void pnl_mensagem_botao_MouseDown(object sender, MouseEventArgs e)
        {
            pnl_mensagem_botao.BackColor = Color.FromArgb(215, 204, 0);
        }
        private void pnl_mensagem_botao_MouseUp(object sender, MouseEventArgs e)
        {
            pnl_mensagem_botao.BackColor = Color.FromArgb(168, 160, 0);  
        }

        //ENVIO
        private void pnl_envio_botao_MouseEnter(object sender, EventArgs e)
        {
            pnl_envio_botao.BackColor = Color.FromArgb(115, 99, 68);
        }
        private void pnl_envio_botao_MouseLeave(object sender, EventArgs e)
        {
            pnl_envio_botao.BackColor = Color.FromArgb(99, 83, 49);
        }
        private void pnl_envio_botao_MouseUp(object sender, MouseEventArgs e)
        {
            pnl_envio_botao.BackColor = Color.FromArgb(115, 99, 68);
        }
        private void pnl_envio_botao_MouseDown(object sender, MouseEventArgs e)
        {
            pnl_envio_botao.BackColor = Color.FromArgb(169, 148, 105);
        }
        #endregion

        #region uc_identificacao
        public String getTitulo()
        {
            return "Menu";
        }
        public String getDescricao()
        {
            return "Gerenciador ANTT";
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

        

        

        

        

        

        

     

        

      

       
        
    }
}
