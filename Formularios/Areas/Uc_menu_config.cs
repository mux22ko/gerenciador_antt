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

namespace gerenciador_antt.Formularios
{
    public partial class Uc_menu_config : UserControl, uc_identificacao
    {
        frm_principal principal = null;
        public Uc_menu_config(frm_principal principal)
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
        private void Uc_menu_config_Load(object sender, EventArgs e)
        {
            this.Width = Parent.Size.Width;
            this.Height = Parent.Size.Height;
            pnl_centro.Location = new Point(((this.Width - pnl_centro.Size.Width) / 2), ((this.Height - pnl_centro.Size.Height) / 2));
            carregarConfigsSalvas();
        }

        #region FUNÇÕES
        private void carregarConfigsSalvas()
        {
            if (Properties.Settings.Default.efeitoInterface)
            {
                chkbx_efeitoSistemaCfg.Checked = true;
            }
            else
            {
                chkbx_efeitoSistemaCfg.Checked = false;
            }
            txt_nomeBd.Text = Properties.Settings.Default.bdNome;
            txt_caminhoBd.Text = Properties.Settings.Default.serverLocal;
            txt_usuarioBd.Text = Properties.Settings.Default.usuario1;
            txt_senhaBd.Text = Properties.Settings.Default.senha1;
            if (txt_senhaBd.Text.Equals(""))
            {
                chk_senha.Checked = true;
            }

        }
        
        private void salvarConfigsAlteradas()
        {
            if (chkbx_efeitoSistemaCfg.Checked)
            {
                Properties.Settings.Default.efeitoInterface = true;
            }
            else
            {
                Properties.Settings.Default.efeitoInterface = false;
            }
            Properties.Settings.Default.bdNome =  txt_nomeBd.Text;
            Properties.Settings.Default.serverLocal = txt_caminhoBd.Text;
            Properties.Settings.Default.usuario1 = txt_usuarioBd.Text;
            Properties.Settings.Default.senha1 = txt_senhaBd.Text;
            Properties.Settings.Default.Save();
        }        
        #endregion 
                
        #region AÇÃO BOTÃO
        private void pnl_aplicarCfg_botao_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Deseja realmente aplicar as configurações alteradas?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                salvarConfigsAlteradas();
                utilidades.fecharEstaJanela_peloPaiDinamico(this);
            }
        }

        private void pnl_sairCfg_botao_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Deseja realmente SAIR sem aplicar as configurações alteradas?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Properties.Settings.Default.Reload();
                utilidades.fecharEstaJanela_peloPaiDinamico(this);
            }
        }

        private void pnl_sistemaCfg_botao_Click(object sender, EventArgs e)
        {
            gbx_sistemaCfg.BringToFront();
        }
        private void pnl_conexaoCfg_botao_Click(object sender, EventArgs e)
        {
            gbx_conexaoCfg.BringToFront();
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

        #region ROTINAS
        private void chkbx_local_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_local.Checked)
            {
                txt_caminhoBd.Text = "localhost";
                txt_caminhoBd.Enabled = false;
            }
            else
            {
                txt_caminhoBd.Enabled = true;
                txt_caminhoBd.Text = "";
            }
        }       
        private void chkbx_efeitoSistemaCfg_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_efeitoSistemaCfg.Checked)
            {
                Properties.Settings.Default.efeitoInterface = true;
            }
            else
            {
                Properties.Settings.Default.efeitoInterface = false;
            }
        }
        private void txt_caminhoBd_TextChanged(object sender, EventArgs e)
        {
            if (txt_caminhoBd.Text.Equals("localhost"))
            {
                chkbx_local.Checked = true;
            }
        }
        private void txt_senhaBd_Validated(object sender, EventArgs e)
        {
            if (txt_senhaBd.Text.Equals(""))
            {
                chk_senha.Checked = true;
            }
        }       
        #endregion                             

        private void chk_usuario_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_usuario.Checked)
            {
                txt_usuarioBd.Text = "root";
                txt_usuarioBd.Enabled = false;
            }
            else
            {
                txt_usuarioBd.Enabled = true;
                txt_usuarioBd.Text = "";
            }
        }

        private void chk_senha_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_senha.Checked)
            {
                txt_senhaBd.Text = "";
                txt_senhaBd.Enabled = false;
            }
            else
            {
                txt_senhaBd.Enabled = true;
                txt_senhaBd.Text = "";
            }
        }
        #region EFEITO BOTÃO
        //sistema CFG
        private void pnl_sistemaCfg_botao_MouseHover(object sender, EventArgs e)
        {
            pnl_sistemaCfg_botao.BackColor = Color.FromArgb(29, 61, 63);
        }
        private void pnl_sistemaCfg_botao_MouseLeave(object sender, EventArgs e)
        {
            pnl_sistemaCfg_botao.BackColor = Color.FromArgb(33, 52, 63);
        }
        private void pnl_sistemaCfg_botao_MouseDown(object sender, MouseEventArgs e)
        {
            pnl_sistemaCfg_botao.BackColor = Color.FromArgb(70, 102, 104);
        }
        private void pnl_sistemaCfg_botao_MouseUp(object sender, MouseEventArgs e)
        {
            pnl_sistemaCfg_botao.BackColor = Color.FromArgb(29, 61, 63);
        }
        //conexao CFG
        private void pnl_conexaoCfg_botao_MouseHover(object sender, EventArgs e)
        {
            pnl_conexaoCfg_botao.BackColor = Color.FromArgb(29, 61, 63);
        }
        private void pnl_conexaoCfg_botao_MouseEnter(object sender, EventArgs e)
        {
            pnl_conexaoCfg_botao.BackColor = Color.FromArgb(29, 61, 63);
        }
        private void pnl_conexaoCfg_botao_MouseLeave(object sender, EventArgs e)
        {
            pnl_conexaoCfg_botao.BackColor = Color.FromArgb(33, 52, 63);
        }
        private void pnl_conexaoCfg_botao_MouseDown(object sender, MouseEventArgs e)
        {
            pnl_conexaoCfg_botao.BackColor = Color.FromArgb(70, 102, 104);
        }
        private void pnl_conexaoCfg_botao_MouseUp(object sender, MouseEventArgs e)
        {
            pnl_conexaoCfg_botao.BackColor = Color.FromArgb(29, 61, 63);
        }
        //aplicar CFG
        private void pnl_aplicarCfg_botao_MouseDown(object sender, MouseEventArgs e)
        {
            pnl_aplicarCfg_botao.BackColor = Color.FromArgb(96, 120, 134);
        }
        private void pnl_aplicarCfg_botao_MouseHover(object sender, EventArgs e)
        {
            pnl_aplicarCfg_botao.BackColor = Color.FromArgb(65, 92, 106);
        }
        private void pnl_aplicarCfg_botao_MouseEnter(object sender, EventArgs e)
        {
            pnl_aplicarCfg_botao.BackColor = Color.FromArgb(65, 92, 106);
        }
        private void pnl_aplicarCfg_botao_MouseLeave(object sender, EventArgs e)
        {
            pnl_aplicarCfg_botao.BackColor = Color.FromArgb(33, 52, 63);
        }
        private void pnl_aplicarCfg_botao_MouseUp(object sender, MouseEventArgs e)
        {
            pnl_aplicarCfg_botao.BackColor = Color.FromArgb(65, 92, 106);
        }
        //sair CFG
        private void pnl_sairCfg_botao_MouseDown(object sender, MouseEventArgs e)
        {
            pnl_sairCfg_botao.BackColor = Color.FromArgb(96, 120, 134);
        }
        private void pnl_sairCfg_botao_MouseHover(object sender, EventArgs e)
        {
            pnl_sairCfg_botao.BackColor = Color.FromArgb(65, 92, 106);
        }
        private void pnl_sairCfg_botao_MouseEnter(object sender, EventArgs e)
        {
            pnl_sairCfg_botao.BackColor = Color.FromArgb(65, 92, 106);
        }
        private void pnl_sairCfg_botao_MouseLeave(object sender, EventArgs e)
        {
            pnl_sairCfg_botao.BackColor = Color.FromArgb(33, 52, 63);
        }
        private void pnl_sairCfg_botao_MouseUp(object sender, MouseEventArgs e)
        {
            pnl_sairCfg_botao.BackColor = Color.FromArgb(65, 92, 106);
        }
        #endregion               
    }
}
