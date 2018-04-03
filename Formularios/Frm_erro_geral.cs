using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gerenciador_antt.Formularios
{
    public partial class Frm_erro_geral : Form
    {
        public Frm_erro_geral()
        {
            InitializeComponent();
        }

        private void Frm_erro_geral_Load(object sender, EventArgs e)
        {
            
        }
        public void setMensagem(String mensagem)
        {
            lbl_erroMensagem.Text = mensagem;
        }
        public void setDetalhe(Exception e)
        {
            txt_det.Text = "Partes envolvidas: "+e.StackTrace.ToString()+Environment.NewLine+
                "Provindo de: "+e.Data.ToString()+Environment.NewLine+
                "Método: "+e.TargetSite.ToString();
        }
        public void setTitulo(String mensagem)
        {
            this.Text = mensagem;
        }
        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnl_det_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.pnl_det.Visible = false;
        }        
    }
}
