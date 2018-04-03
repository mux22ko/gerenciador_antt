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
    public partial class Uc_lista_item_atendimento : UserControl, componente_lista
    {
        item_atendimento item_atendimentoRecebido = null;
        item_atendimento item_atendimentoInterno = new item_atendimento();
        dados_servico dados_servico = new dados_servico();

        #region INICIALIZADORES
        public Uc_lista_item_atendimento(item_atendimento item_atendimento)
        {
            this.item_atendimentoRecebido = item_atendimento;
            this.item_atendimentoInterno = this.item_atendimentoRecebido.Clone();
                InitializeComponent();
            carregarDadosItem_atendimentoInterno();
        }
        #endregion

        #region FUNÇÕES
        private void carregarDadosItem_atendimentoInterno()
        {
            lbl_valorCombinado_item.Text = utilidades.captarValorMonetarioValido_paraExibicao(this.item_atendimentoInterno.getValor_combinado_item_atendimento().ToString());
            servico servico = new servico();
            servico.setCod_tab_servico_pk(this.item_atendimentoInterno.getCod_servico_fk());
            lbl_nome_servico.Text = dados_servico.selecionarUmServico_porCodigo(servico).getNome_servico();
            if (!(this.item_atendimentoInterno.getDetalhe_item_atendimento()==null))
            {
                lbl_detalhe_item.Text = this.item_atendimentoInterno.getDetalhe_item_atendimento();
            }
        }

        public item_atendimento getItem_atendimento_original()
        {
            return this.item_atendimentoRecebido;
        }

        public item_atendimento getItem_atendimento_atual()
        {
            return this.item_atendimentoInterno;
        }

        public void travarExclusao()
        {
            this.pnl_excluir.Enabled = false;
            this.ContextMenuStrip = null;
        }

        public void liberarExclusao()
        {
            this.pnl_excluir.Enabled = true;
            this.ContextMenuStrip = ctxmxnstp_opcoes;
        }

        private void carregarServicos()
        {
            //completa o combobox de servicos!  
            if (conexaoBD.abrirConexao())
            {
                //completa o combobox de cliente!         
                DataTable dt_servicos = new DataTable();
                dt_servicos.Columns.Add(dados_servico.SERVICO_CODIGO, typeof(int));
                dt_servicos.Columns.Add(dados_servico.SERVICO_NOME, typeof(string));
                dt_servicos.Columns.Add(dados_servico.SERVICO_VALOR, typeof(string));
                dt_servicos.Columns.Add(dados_servico.SERVICO_DESCRICAO, typeof(string));
                cbx_alterar_servico.DataSource = dt_servicos;
                List<servico> listaServicos = dados_servico.selecionarTodosServicos_ativos();

                int cont = 0;
                for (cont = 0; cont < listaServicos.Count; cont++)
                {
                    dt_servicos.Rows.Add(listaServicos[cont].getCod_tab_servico_pk(),
                        listaServicos[cont].getNome_servico(),
                        listaServicos[cont].getValor_servico(),
                        listaServicos[cont].getDescricao_servico()
                        );
                }
                cbx_alterar_servico.DisplayMember = dados_servico.SERVICO_NOME;
                cbx_alterar_servico.ValueMember = dados_servico.SERVICO_CODIGO;
            }
        }
        private void copiarConteudo_areaTransferencia()
        {
            Clipboard.SetDataObject(this.lbl_nome_servico.Text + " : " + this.lbl_detalhe_item.Text + " - " + this.lbl_valorCombinado_item.Text, true);
            MessageBox.Show("Copiado!");
        }
        #endregion

        #region ROTINA DE COMPONENTES
        private void UC_lista_contato_Load(object sender, EventArgs e)
        {
            txt_alterar_detalhes.Width = this.Width;
            this.Dock = (DockStyle.Top);
            carregarServicos();
        }
        private void txt_alterar_detalhes_VisibleChanged(object sender, EventArgs e)
        {
            txt_alterar_detalhes.Text = lbl_detalhe_item.Text;
        }
        private void lbl_valorCombinado_item_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                copiarConteudo_areaTransferencia();
            }
        }
        #endregion

        #region AÇÃO DE BOTAO
        private void pnl_excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Deseja remover este item?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }        

        private void alterarValorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txt_alterar_valor.Location = new Point((lbl_valorCombinado_item.Location.X), (lbl_valorCombinado_item.Location.Y));
            txt_alterar_valor.Visible = true;
            txt_alterar_detalhes.Visible = false;
            cbx_alterar_servico.Visible = false;
            txt_alterar_valor.Focus();
        }

        private void alterarServicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbx_alterar_servico.Location = new Point((lbl_nome_servico.Location.X), (lbl_nome_servico.Location.Y));
            cbx_alterar_servico.Visible = true;
            txt_alterar_detalhes.Visible = false;
            txt_alterar_valor.Visible = false;
            cbx_alterar_servico.Focus();
        }
        private void Uc_lista_item_atendimento_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape))
            {
                txt_alterar_valor.Visible =false;
                txt_alterar_detalhes.Visible =false;
                cbx_alterar_servico.Visible = false;
                lbl_nome_servico.Focus();
            }
            if ((e.KeyCode == Keys.Enter))
            {
                if(txt_alterar_valor.Visible == true)
                {
                    try
                    {
                        if (!(utilidades.captarValorMonetarioValido_paraExibicao(txt_alterar_valor.Text).Equals(String.Empty)))
                        {
                            if(Convert.ToDouble(utilidades.captarValorMonetarioValido_paraExibicao(txt_alterar_valor.Text))<0)
                            {
                                this.item_atendimentoInterno.setValor_combinado_item_atendimento(Convert.ToDouble(utilidades.captarValorMonetarioValido_paraExibicao("0,00")));
                            }
                            else
                            {
                                this.item_atendimentoInterno.setValor_combinado_item_atendimento(Convert.ToDouble(utilidades.captarValorMonetarioValido_paraExibicao(txt_alterar_valor.Text)));
                            }
                        }
                    }
                    catch { }
                    txt_alterar_valor.Text = "";
                    txt_alterar_valor.Visible = false;
                    carregarDadosItem_atendimentoInterno();
                }
                if(txt_alterar_detalhes.Visible == true)
                {
                    this.item_atendimentoInterno.setDetalhe_item_atendimento(txt_alterar_detalhes.Text);
                    txt_alterar_detalhes.Visible = false;
                    txt_alterar_detalhes.Text = "";
                    carregarDadosItem_atendimentoInterno();
                }
                if (cbx_alterar_servico.Visible == true)
                {
                    try
                    {
                        this.item_atendimentoInterno.setCod_servico_fk(Convert.ToInt32(cbx_alterar_servico.SelectedValue));
                    }
                    catch
                    { }
                    cbx_alterar_servico.Visible = false;
                    carregarDadosItem_atendimentoInterno();
                }
                lbl_nome_servico.Focus();
            }            
        } 

        private void alterarDetalhesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txt_alterar_detalhes.Location = new Point((lbl_detalhe_item.Location.X), (lbl_detalhe_item.Location.Y));
            txt_alterar_detalhes.Visible = true;
            cbx_alterar_servico.Visible = false;
            txt_alterar_valor.Visible = false;
            txt_alterar_detalhes.Focus();
        }

        private void Uc_lista_item_atendimento_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.NavajoWhite;
        }

        private void Uc_lista_item_atendimento_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.AntiqueWhite;
        }

        private void pnl_excluir_MouseDown(object sender, MouseEventArgs e)
        {
            pnl_excluir.BackgroundImage = Properties.Resources.fechar_item_click;
        }

        private void pnl_excluir_MouseHover(object sender, EventArgs e)
        {
            pnl_excluir.BackgroundImage = Properties.Resources.fechar_item_hover;
        }

        private void pnl_excluir_MouseLeave(object sender, EventArgs e)
        {
            pnl_excluir.BackgroundImage = Properties.Resources.fechar_item;
        }
        #endregion        
               
        #region Membros de componente_lista
        public int situacao() //1 = inalterado / 2= alterado / 3= novo
        {
            if (item_atendimentoRecebido != null)//se é cliente
            {
                if (item_atendimentoRecebido.Equals(item_atendimentoInterno))
                {
                    if (item_atendimentoRecebido.getCod_item_atendimento_pk() <= 0)
                    {
                        return 3;
                    }
                    return 1;
                }
                else
                {
                    if (item_atendimentoRecebido.getCod_item_atendimento_pk() <= 0)
                    {
                        return 3;
                    }
                    return 2;
                }
            }
            else
            {
                return 3;
            }
        }
        #endregion           

    }
}
