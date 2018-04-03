using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using gerenciador_antt.Classes_Auxiliares;
using gerenciador_antt.Classes_Objetos;
using gerenciador_antt.Classes_Dados;


namespace gerenciador_antt.Formularios
{
    public partial class Uc_lista_endereco : UserControl, componente_lista
    {
        endereco_cliente endereco_clienteRecebido;
        endereco_cliente endereco_clienteInterno = new endereco_cliente();

        endereco_responsavel endereco_responsavelRecebido;
        endereco_responsavel endereco_responsavelInterno = new endereco_responsavel();

        dados_endereco_tipo dados_endereco_tipo = new dados_endereco_tipo();

        #region INICIALIZADORES
        public Uc_lista_endereco(endereco_cliente endereco_clienteRecebido)
        {
            this.endereco_clienteRecebido = new endereco_cliente();
            this.endereco_clienteRecebido = endereco_clienteRecebido;
            this.endereco_clienteInterno = this.endereco_clienteRecebido.Clone();
            InitializeComponent();
            carregarEndereco_clienteInterno();
        }

        public Uc_lista_endereco(endereco_responsavel endereco_responsavelRecebido)
        {
            this.endereco_responsavelRecebido = new endereco_responsavel();
            this.endereco_responsavelRecebido = endereco_responsavelRecebido;
            this.endereco_responsavelInterno = this.endereco_responsavelRecebido.Clone();
            InitializeComponent();
            carregarEndereco_responsavelInterno();
        }
        #endregion

        #region FUNÇÕES
        public void travarExclusao()
        {
            this.pnl_excluir.Enabled = false;
        }

        public void liberarExclusao()
        {
            this.pnl_excluir.Enabled = true;
        }

        private void copiarConteudo_areaTransferencia()
        {
            Clipboard.SetDataObject(this.lbl_endereco.Text, true);
            MessageBox.Show("Copiado!");
        }

        public endereco_cliente getEndereco_cliente_atual()
        {
            return this.endereco_clienteInterno;
        }

        public endereco_cliente getEndereco_cliente_original()
        {
            return this.endereco_clienteRecebido;
        }

        public endereco_responsavel getEndereco_responsavel_atual()
        {
            return this.endereco_responsavelInterno;
        }

        public endereco_responsavel getEndereco_responsavel_original()
        {
            return this.endereco_responsavelRecebido;
        }

        private void carregarEndereco_clienteInterno()
        {
            if (conexaoBD.abrirConexao())
            {
                tipo_endereco tipo_enderecoNovo = new tipo_endereco();
                tipo_enderecoNovo.setCod_tipo_endereco_pk(this.endereco_clienteInterno.getCod_tipo_endereco_fk());
                lbl_tipo_endereco.Text = (dados_endereco_tipo.selecionarTipo_porCodigo(tipo_enderecoNovo).getNome_tipo_endereco());

                lbl_endereco.Text = this.endereco_clienteInterno.getTexto_endereco_cliente();
            }
        }

        private void carregarEndereco_responsavelInterno()
        {
            if (conexaoBD.abrirConexao())
            {
                tipo_endereco tipo_enderecoNovo = new tipo_endereco();
                tipo_enderecoNovo.setCod_tipo_endereco_pk(this.endereco_responsavelInterno.getCod_tipo_endereco_fk());
                lbl_tipo_endereco.Text = (dados_endereco_tipo.selecionarTipo_porCodigo(tipo_enderecoNovo).getNome_tipo_endereco());

                lbl_endereco.Text = this.endereco_responsavelInterno.getTexto_endereco_responsavel();
            }
        }
        private void carregarTipoEnderecos()
        {
            if (conexaoBD.abrirConexao())
            {
                //completa o combobox de tipos de enderecos!
                List<tipo_endereco> todosTiposContato = dados_endereco_tipo.selecionarTodosTipos();
                DataTable dt_todosTiposContato = new DataTable();
                dt_todosTiposContato.Columns.Add(dados_endereco_tipo.ENDERECO_TIPO_CODIGO, typeof(int));
                dt_todosTiposContato.Columns.Add(dados_endereco_tipo.ENDERECO_TIPO_NOME, typeof(string));
                cbx_alterar_tipo_endereco.DataSource = dt_todosTiposContato;
                int cont = 0;
                while (cont < todosTiposContato.Count)
                {
                    dt_todosTiposContato.Rows.Add(todosTiposContato[cont].getCod_tipo_endereco_pk(), todosTiposContato[cont].getNome_tipo_endereco());
                    cont++;
                }
                cbx_alterar_tipo_endereco.DisplayMember = dados_endereco_tipo.ENDERECO_TIPO_NOME;
                cbx_alterar_tipo_endereco.ValueMember = dados_endereco_tipo.ENDERECO_TIPO_CODIGO;
            }
        }
        #endregion

        #region AÇÕES DE BOTÕES
        private void pnl_excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Deseja remover este item?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        #endregion

        #region ROTINAS COMPONENTES
        private void Uc_lista_endereco_Load(object sender, EventArgs e)
        {
            txt_alterar_endereco.Width = this.Width;
            carregarTipoEnderecos();
            this.Dock = (DockStyle.Top);
        }
        #endregion

        #region Membros de componente_lista
        public int situacao() //1 = inalterado / 2= alterado / 3= novo
        {
            if (endereco_clienteRecebido != null)//se é cliente
            {
                if (endereco_clienteRecebido.Equals(endereco_clienteInterno))
                {
                    if (endereco_clienteRecebido.getCod_endereco_cliente_pk() <= 0)
                    {
                        return 3;
                    }
                    return 1;
                }
                else
                {
                    if (endereco_clienteRecebido.getCod_endereco_cliente_pk() <= 0)
                    {
                        return 3;
                    }
                    return 2;
                }
            }
            else//se é responsavel
            {
                if (endereco_responsavelRecebido.Equals(endereco_responsavelInterno))
                {
                    if (endereco_responsavelRecebido.getCod_endereco_responsavel_pk() <= 0)
                    {
                        return 3;
                    }
                    return 1;
                }
                else
                {
                    if (endereco_responsavelRecebido.getCod_endereco_responsavel_pk() <= 0)
                    {
                        return 3;
                    }
                    return 2;
                }
            }
        }
        #endregion

        private void alterarOTipoDoEndereçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.cbx_alterar_tipo_endereco.Location = new Point((this.lbl_tipo_endereco.Location.X), (this.lbl_tipo_endereco.Location.Y));
            this.cbx_alterar_tipo_endereco.BringToFront();
            this.cbx_alterar_tipo_endereco.Visible = true;
            this.txt_alterar_endereco.Visible = false;
            this.cbx_alterar_tipo_endereco.Focus();
        }

        private void alterarOEndereçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txt_alterar_endereco.Location = new Point((this.lbl_endereco.Location.X), (this.lbl_endereco.Location.Y));
            this.txt_alterar_endereco.BringToFront();
            this.txt_alterar_endereco.Visible = true;
            this.cbx_alterar_tipo_endereco.Visible = false;
            this.txt_alterar_endereco.Focus();
        }

        private void Uc_lista_endereco_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape))
            {
                this.cbx_alterar_tipo_endereco.Visible = false;
                this.txt_alterar_endereco.Visible = false;
                this.lbl_tipo_endereco.Focus();
            }
            if ((e.KeyCode == Keys.Enter))
            {
                if (this.cbx_alterar_tipo_endereco.Visible == true)
                {
                    try
                    {
                        if (!(endereco_responsavelRecebido == null))//responasvel
                        {
                            this.endereco_responsavelInterno.setCod_tipo_endereco_fk(Convert.ToInt32(cbx_alterar_tipo_endereco.SelectedValue));
                            carregarEndereco_responsavelInterno();
                        }
                        else//cliente
                        {
                            this.endereco_clienteInterno.setCod_tipo_endereco_fk(Convert.ToInt32(cbx_alterar_tipo_endereco.SelectedValue));
                            carregarEndereco_clienteInterno();
                        }
                    }
                    catch
                    { }
                    this.cbx_alterar_tipo_endereco.Visible = false;
                    this.lbl_tipo_endereco.Focus();
                }

            }
        }

        private void txt_alterar_endereco_Leave(object sender, EventArgs e)
        {
            if (this.txt_alterar_endereco.Visible == true)
            {
                if (!(endereco_responsavelRecebido == null))//responasvel
                {
                    this.endereco_responsavelInterno.setTexto_endereco_responsavel(this.txt_alterar_endereco.Text);
                    carregarEndereco_responsavelInterno();
                }
                else//cliente
                {
                    this.endereco_clienteInterno.setTexto_endereco_cliente(this.txt_alterar_endereco.Text);
                    carregarEndereco_clienteInterno();
                }
                this.txt_alterar_endereco.Visible = false;
                this.txt_alterar_endereco.Text = "";
            }
        }

        private void lbl_endereco_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                copiarConteudo_areaTransferencia();
            }
        }

        private void txt_alterar_endereco_TextChanged(object sender, EventArgs e)
        {
            txt_alterar_endereco.Height = utilidades.captarAlturaEspacoDoTexto(txt_alterar_endereco.Text, Convert.ToInt32(txt_alterar_endereco.Font.Size));
        }

        private void txt_alterar_endereco_VisibleChanged(object sender, EventArgs e)
        {
            if (txt_alterar_endereco.Visible == true)
            {
                txt_alterar_endereco.Text = lbl_endereco.Text;
            }
        }

        private void Uc_lista_endereco_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.NavajoWhite;
        }

        private void Uc_lista_endereco_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.AntiqueWhite;
        }

        private void pnl_excluir_MouseDown(object sender, MouseEventArgs e)
        {
            pnl_excluir.BackgroundImage = Properties.Resources.fechar_item_click;
        }

        private void pnl_excluir_MouseLeave(object sender, EventArgs e)
        {
            pnl_excluir.BackgroundImage = Properties.Resources.fechar_item;
        }

        private void pnl_excluir_MouseHover(object sender, EventArgs e)
        {
            pnl_excluir.BackgroundImage = Properties.Resources.fechar_item_hover;
        }

        private void txt_alterar_endereco_MouseLeave(object sender, EventArgs e)
        {
            if (this.txt_alterar_endereco.Visible == true)
            {
                if (!(endereco_responsavelRecebido == null))//responasvel
                {
                    this.endereco_responsavelInterno.setTexto_endereco_responsavel(this.txt_alterar_endereco.Text);
                    carregarEndereco_responsavelInterno();
                }
                else//cliente
                {
                    this.endereco_clienteInterno.setTexto_endereco_cliente(this.txt_alterar_endereco.Text);
                    carregarEndereco_clienteInterno();
                }
                this.txt_alterar_endereco.Visible = false;
                this.txt_alterar_endereco.Text = "";
            }
        }
        
    }
}
