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
    public partial class Uc_lista_contato : UserControl, componente_lista
    {
        contato_cliente contato_clienteRecebido;
        contato_cliente contato_clienteInterno = new contato_cliente();

        contato_responsavel contato_responsavelRecebido;
        contato_responsavel contato_responsavelInterno = new contato_responsavel();
        
        dados_contato_tipo dados_contato_tipo = new dados_contato_tipo();

        #region INICIALIZADORES
        public Uc_lista_contato(contato_cliente contato_clienteRecebido)
        {
            this.contato_clienteRecebido = new contato_cliente();
            this.contato_clienteRecebido = contato_clienteRecebido;
            this.contato_clienteInterno = this.contato_clienteRecebido.Clone();
            InitializeComponent();
            carregarContato_clienteInterno();
        }

        public Uc_lista_contato(contato_responsavel contato_responsavelRecebido)
        {
            this.contato_responsavelRecebido = new contato_responsavel();
            this.contato_responsavelRecebido = contato_responsavelRecebido;
            this.contato_responsavelInterno = this.contato_responsavelRecebido.Clone();
            InitializeComponent();
            carregarContato_responsavelInterno();
        }
        #endregion

        #region ROTINAS DOS COMPONENTES
        private void UC_lista_contato_Load(object sender, EventArgs e)
        {
            carregarTiposContatos();
            this.Dock = (DockStyle.Top);
        }
        #endregion

        #region FUNÇÕES
        public contato_cliente getContato_cliente_atual()
        {
            return this.contato_clienteInterno;
        }

        public contato_cliente getContato_cliente_original()
        {
            return this.contato_clienteRecebido;
        }

        public contato_responsavel getContato_responsavel_atual()
        {
            return this.contato_responsavelInterno;
        }

        public contato_responsavel getContato_responsavel_original()
        {
            return this.contato_responsavelRecebido;
        }

        public void carregarContato_clienteInterno()
        {
            if(conexaoBD.abrirConexao())
            {
                tipo_contato tipo_contatoNovo = new tipo_contato();
                tipo_contatoNovo.setCod_tipo_contato_pk(this.contato_clienteInterno.getTipo_contato_fk());
                lbl_tipo_contato.Text = (dados_contato_tipo.selecionarTipo_porCodigo(tipo_contatoNovo).getNome_tipo_contato());

                lbl_contato.Text = (utilidades.captarContatoMascarado_confomeTipoContato(tipo_contatoNovo.getCod_tipo_contato_pk(), this.contato_clienteInterno.getTexto_contato_cliente()));
            }
        }

        public void carregarContato_responsavelInterno()
        {
            if (conexaoBD.abrirConexao())
            {
                tipo_contato tipo_contatoNovo = new tipo_contato();
                tipo_contatoNovo.setCod_tipo_contato_pk(this.contato_responsavelInterno.getTipo_contato_fk());
                lbl_tipo_contato.Text = (dados_contato_tipo.selecionarTipo_porCodigo(tipo_contatoNovo).getNome_tipo_contato());

                lbl_contato.Text = (utilidades.captarContatoMascarado_confomeTipoContato(tipo_contatoNovo.getCod_tipo_contato_pk(), this.contato_responsavelInterno.getTexto_contato_responsavel()));
            }
        } 
    
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
          Clipboard.SetDataObject(this.lbl_contato.Text, true);
          MessageBox.Show("Copiado!");
        }

        private void carregarTiposContatos()
        {
                if (conexaoBD.abrirConexao())
                {
                    //completa o combobox de tipos de contatos!
                    List<tipo_contato> todosTiposContato = dados_contato_tipo.selecionarTodosTipos();
                    DataTable dt_todosTiposContato = new DataTable();
                    dt_todosTiposContato.Columns.Add(dados_contato_tipo.CONTATO_TIPO_CODIGO, typeof(int));
                    dt_todosTiposContato.Columns.Add(dados_contato_tipo.CONTATO_TIPO_NOME, typeof(string));
                    cbx_alterar_tipo_contato.DataSource = dt_todosTiposContato;                
                    int cont = 0;
                    while (cont < todosTiposContato.Count)
                    {
                        dt_todosTiposContato.Rows.Add(todosTiposContato[cont].getCod_tipo_contato_pk(), todosTiposContato[cont].getNome_tipo_contato());
                        cont++;
                    }
                    cbx_alterar_tipo_contato.DisplayMember = dados_contato_tipo.CONTATO_TIPO_NOME;
                    cbx_alterar_tipo_contato.ValueMember = dados_contato_tipo.CONTATO_TIPO_CODIGO;
                }
         }
        #endregion

        #region AÇÕES DE BOTÕES 
        private void pnl_excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null,"Deseja remover este item?","Atenção!",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void lbl_contato_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                copiarConteudo_areaTransferencia();
            }
        }

        private void Uc_lista_contato_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape))
            {
                this.cbx_alterar_tipo_contato.Visible = false;
                this.msktxt_alterar_contato.Visible = false;
                this.lbl_tipo_contato.Focus();
            }
            if ((e.KeyCode == Keys.Enter))
            {
                if (this.msktxt_alterar_contato.Visible == true)
                {
                    if (!(contato_responsavelRecebido == null))//responasvel
                    {
                        this.contato_responsavelInterno.setTexto_contato_responsavel(this.msktxt_alterar_contato.Text);
                        carregarContato_responsavelInterno();
                    }
                    else//cliente
                    {
                        this.contato_clienteInterno.setTexto_contato_cliente(this.msktxt_alterar_contato.Text);
                        carregarContato_clienteInterno();
                    }
                    this.msktxt_alterar_contato.Visible = false;
                    this.msktxt_alterar_contato.Text = "";
                }
                if (this.cbx_alterar_tipo_contato.Visible == true)
                {
                    try
                    {
                        if (!(contato_responsavelRecebido == null))//responasvel
                        {
                            this.contato_responsavelInterno.setTipo_contato_fk(Convert.ToInt32(cbx_alterar_tipo_contato.SelectedValue));
                            carregarContato_responsavelInterno();
                        }
                        else//cliente
                        {
                            this.contato_clienteInterno.setTipo_contato_fk(Convert.ToInt32(cbx_alterar_tipo_contato.SelectedValue));
                            carregarContato_clienteInterno();
                        }
                    }
                    catch
                    { }
                    this.cbx_alterar_tipo_contato.Visible = false;
                    
                }
                this.lbl_tipo_contato.Focus();
            }
        }

        private void alterarTipoDoContatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.cbx_alterar_tipo_contato.Location = new Point((this.lbl_tipo_contato.Location.X), (this.lbl_tipo_contato.Location.Y));
            this.cbx_alterar_tipo_contato.BringToFront();
            this.cbx_alterar_tipo_contato.Visible = true;
            this.msktxt_alterar_contato.Visible = false;
            this.cbx_alterar_tipo_contato.Focus();
        }

        private void alterarOContatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.msktxt_alterar_contato.Location = new Point((this.lbl_contato.Location.X), (this.lbl_contato.Location.Y));
            this.msktxt_alterar_contato.BringToFront();
            this.msktxt_alterar_contato.Visible = true;
            this.cbx_alterar_tipo_contato.Visible = false;
            this.msktxt_alterar_contato.Focus();
            if (!(this.contato_clienteInterno.getTipo_contato_fk()<=0))
            {
                utilidades.selecionarMascara_confomeContato_msktxt(this.contato_clienteInterno.getTipo_contato_fk(),this.msktxt_alterar_contato);
            }
            else 
            {
                utilidades.selecionarMascara_confomeContato_msktxt(this.contato_responsavelInterno.getTipo_contato_fk(), this.msktxt_alterar_contato);
            }
        }
        private void Uc_lista_contato_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.NavajoWhite;
        }

        private void Uc_lista_contato_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.AntiqueWhite;
        }

        private void pnl_excluir_MouseHover(object sender, EventArgs e)
        {
            pnl_excluir.BackgroundImage = Properties.Resources.fechar_item_hover;
        }

        private void pnl_excluir_MouseLeave(object sender, EventArgs e)
        {
            pnl_excluir.BackgroundImage = Properties.Resources.fechar_item;
        }

        private void pnl_excluir_MouseDown(object sender, MouseEventArgs e)
        {
            pnl_excluir.BackgroundImage = Properties.Resources.fechar_item_click;
        }        
        #endregion

        #region Membros de componente_lista
        public int situacao() //1 = inalterado / 2= alterado / 3= novo
        {
            if (contato_clienteRecebido != null)//se é cliente
            {
                if (contato_clienteRecebido.Equals(contato_clienteInterno))
                {
                    if (contato_clienteRecebido.getCod_contato_cliente_pk() <= 0)
                    {
                            return 3;
                    }
                    return 1;
                }
                else
                {                      
                    if (contato_clienteRecebido.getCod_contato_cliente_pk() <= 0)
                    {
                            return 3;
                    }
                    return 2;
                }
            }
            else//se é responsavel
            {
                if (contato_responsavelRecebido.Equals(contato_responsavelInterno))
                {
                    if (contato_responsavelRecebido.getCod_contato_responsavel_pk() <= 0)
                    {
                        return 3;
                    }
                    return 1;
                }
                else
                {
                     if (contato_responsavelRecebido.getCod_contato_responsavel_pk() <= 0)
                     {
                        return 3;
                     }
                     return 2;
                }
            }
        }
        #endregion               
    }
}
