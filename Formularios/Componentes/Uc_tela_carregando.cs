using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace gerenciador_antt.Formularios
{
    public partial class Uc_tela_carregando : UserControl
    {
        public Uc_tela_carregando(int mensagemOpcao)
        {            
            InitializeComponent();
            escolherMensagem(mensagemOpcao);
        }

        int cont = 1;

        private void Uc_tela_carregando_Load(object sender, EventArgs e)
        {   
            this.Size = Parent.Size;
            this.BringToFront();
            this.Location = new Point(0, 0);
        }

        private void setCarregandoDados(String texto)
        {
            this.lbl_carregando_dado.Text = texto;
            this.lbl_carregando_dado.Visible = true;
        }
        private void escolherMensagem(int opcao)
        {
            switch(opcao)
            {
                case 1:
                    setCarregandoDados("Aguadando você selecionar um Cliente");
                    break;
                case 2:
                    setCarregandoDados("Aguadando você selecionar um Responsável");
                    break;
                case 3:
                    setCarregandoDados("Aguadando você selecionar um Atendimento");
                    break;
            }
        }
        private void pctbx_carregando_Paint(object sender, PaintEventArgs e)
        {
           if (cont == 5)
            {
                lbl_carregando_dado.Text = lbl_carregando_dado.Text + ".";
            } 
            if(cont > 5)
            {
                cont = 1;
                if ((lbl_carregando_dado.Text.Substring(lbl_carregando_dado.Text.Length - 3, 3)).Equals("..."))
                {
                    lbl_carregando_dado.Text = lbl_carregando_dado.Text.Substring(0, lbl_carregando_dado.Text.Length - 3);
                }
            }
            cont++;
        }       
    }
}
