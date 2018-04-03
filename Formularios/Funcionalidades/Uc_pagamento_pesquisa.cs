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
    public partial class Uc_pagamento_pesquisa : UserControl, uc_identificacao, requerimento_atendimento
    {
        //MODO
        //1 = Pesquisa,leitura,alteracao, 2=Seleção

        #region DADOS
        int MODO = 1; //padrao modo Pesquisa,leitura,alteracao!
        frm_principal principal = null;
        atendimento atendimentoSelecionado = null;

        //dados
        dados_atendimento dados_atendimento = new dados_atendimento();
        dados_meio_pagamento dados_meio_pagamento = new dados_meio_pagamento();
        dados_cliente dados_cliente = new dados_cliente();
        dados_responsavel dados_responsavel = new dados_responsavel();
        dados_item_atendimento dados_item_atendimento = new dados_item_atendimento();
        dados_pagamento dados_pagamento = new dados_pagamento();
        dados_pagamento_atendimento dados_pagamento_atendimento = new dados_pagamento_atendimento();
        DataTable dt_atendimentos = new DataTable();
        DataTable dt_resultados = new DataTable();
        DataTable dt_meio_pagamento = new DataTable();    

        //origem de requerente
        requerimento_pagamento origemRequisitandoPagamento;

        //mensagens
        String mensagem01 = "Deseja Ver os dados de ";
        String mensagem02 = "Deseja Alterar os dados do Pagamento: ";
        String mensagem03 = "Deseja realmente fechar esta aba?";
        String mensagem05 = "Não foi selecionado um Atendimento!";
        #endregion

        #region INICIALIZADORES
        public Uc_pagamento_pesquisa(frm_principal principal) //util para modo 1!
        {
            this.MODO = 1;
            //origem padrao
            this.principal = principal;            
            if (principal.getAtendente() != null)//trava anti-acesso nao autorizado!
            {
                InitializeComponent();
                carregarModo();
            }
            else
            {
                MessageBox.Show("Esteja logado para acessar esta área!");
            }
        }

        public Uc_pagamento_pesquisa(frm_principal principal, object origemRequisitando)//util para modo 2!
        {
            this.MODO = 2;
            //origem padrao
            this.principal = principal;
            //tela que requisita cliente!
            this.origemRequisitandoPagamento= (requerimento_pagamento)origemRequisitando;
            if (principal.getAtendente() != null)//trava anti-acesso nao autorizado!
            {
                InitializeComponent();
                carregarModo();
            }
            else
            {
                MessageBox.Show("Esteja logado para acessar esta área!");
            }
        }
        #endregion

        #region AÇÕES DE BOTÕES
        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            pesquisar();
            pintarTabela();
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            try
           {
                if (MessageBox.Show(null, mensagem03, "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (origemRequisitandoPagamento != null)
                    {
                        //se fechar avisa quenao escolheram o pagamento!
                        origemRequisitandoPagamento.sinalizarEscolha_pagamento(false);
                    }
                    utilidades.fecharEstaJanela_peloPaiDinamico(this);
                }
            }
            catch { }
        }        

        private void btn_detalhar_Click(object sender, EventArgs e)
        {
            if (utilidades.verificarSelecionouUmResultado_dtgvw(dtg_resultados))
            {
                if (utilidades.verificarSelecionouUmResultado_dtgvw(dtg_resultados))
                {
                    if (MessageBox.Show(null, mensagem01 + dtg_resultados.Rows[dtg_resultados.SelectedCells[0].RowIndex].Cells[dados_pagamento.PAGAMENTO_CODIGO].Value.ToString() + "?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        if (conexaoBD.abrirConexao())
                        {
                            pagamento pagamento = new pagamento();
                            pagamento.setCod_pagamento_pk(Convert.ToInt32(dtg_resultados.Rows[dtg_resultados.SelectedCells[0].RowIndex].Cells[dados_pagamento.PAGAMENTO_CODIGO].Value));
                            //inflo na pagamento area!
                            conteudos_dinamicos pagamentoArea = (conteudos_dinamicos)Parent.Parent;
                            pagamentoArea.carregarConteudo_principal(new Uc_pagamento_cadastro(principal, 3, dados_pagamento.selecionarUmPagamento_porCodigo(pagamento)), false);
                        }
                    }
                }
            }
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            if (utilidades.verificarSelecionouUmResultado_dtgvw(dtg_resultados))
            {
                if (MessageBox.Show(null, mensagem02 + dtg_resultados.Rows[dtg_resultados.SelectedCells[0].RowIndex].Cells[dados_pagamento.PAGAMENTO_CODIGO].Value.ToString() + "?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (conexaoBD.abrirConexao())
                    {
                        pagamento pagamento = new pagamento();
                        pagamento.setCod_pagamento_pk(Convert.ToInt32(dtg_resultados.Rows[dtg_resultados.SelectedCells[0].RowIndex].Cells[dados_pagamento.PAGAMENTO_CODIGO].Value.ToString()));
                        //inflo na pagamento area!
                        conteudos_dinamicos pagamentoArea = (conteudos_dinamicos)Parent.Parent;
                        pagamentoArea.carregarConteudo_principal((new Uc_pagamento_cadastro(principal, 2, dados_pagamento.selecionarUmPagamento_porCodigo(pagamento))), false);
                    }
                }
            }
        }

        private void btn_pesquisarAtendimento_Click(object sender, EventArgs e)
        {
            utilidades.carregar_telaCarregando(this, 3);
            Uc_atendimento_pesquisa pesq = new Uc_atendimento_pesquisa(principal, this);
            conteudos_dinamicos pagamentoArea = (conteudos_dinamicos)Parent.Parent;
            pagamentoArea.carregarConteudo_principal(pesq, true);
        }

        private void btn_escolher_selecionado_Click(object sender, EventArgs e)
        {
            //nao implementado ainda por falta de uso! seria a funçãod e enviar um pagamento como selecionado!
            /*
            try
            {
                if (utilidades.verificarSelecionouUmResultado_dtgvw(dtg_resultados))
                {
                    if (MessageBox.Show(null, mensagem04, "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        //atendimento novo para setar o ID nele!
                        pagamento novoAtendimento = new pagamento();
                        novoAtendimento.setCod_atendimento_pk(Convert.ToInt32(dtg_resultados.Rows[dtg_resultados.SelectedCells[0].RowIndex].Cells[dados_atendimento.ATENDIMENTO_CODIGO].Value.ToString()));
                        //origem recebe o atendimento!
                        origemRequisitandoPagamento.atendimentoEscolhido(novoAtendimento);
                        if (novoAtendimento != null)
                        {
                            origemRequisitandoPagamento.sinalizarEscolha_atendimento(true);
                        }
                        else
                        {
                            origemRequisitandoPagamento.sinalizarEscolha_atendimento(false);
                        }
                        //fecho esta janela de pesquisa!
                        utilidades.fecharEstaJanela_peloPaiDinamico(this);
                    }
                }
            }
            catch(Exception erro) { MessageBox.Show(erro.Message+"/n"+erro.Data); 
            }*/
        
        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cbx_atendimento.SelectedValue) > 0)
                {
                    atendimento at = new atendimento();
                    at.setCod_atendimento_pk(Convert.ToInt32(cbx_atendimento.SelectedValue));
                    atendimentoSelecionado = at;
                    if (!(verificarAtendimentoJaAdicionado(at)))
                    {
                        adicionarAtendimentoSelecionado();
                    }
                    else
                    {
                        MessageBox.Show(null, "Atendimento já adicionado a lista!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch { }
        }
        #endregion

        #region Rotinas de componentes
        private void Uc_pagamento_pesquisa_Load(object sender, EventArgs e)
        {
            //base do dtg_resultado!
            dt_resultados.Columns.Add(dados_pagamento.PAGAMENTO_CODIGO, typeof(int));
            dt_resultados.Columns.Add("atendimentos", typeof(string));
            dt_resultados.Columns.Add(dados_pagamento.PAGAMENTO_VALOR, typeof(string));
            dt_resultados.Columns.Add(dados_pagamento.PAGAMENTO_TROCO, typeof(string));
            dt_resultados.Columns.Add(dados_pagamento.PAGAMENTO_CODIGO_MEIO_PAGAMENTO, typeof(string));
            dt_resultados.Columns.Add(dados_pagamento.PAGAMENTO_DATA_CRIACAO, typeof(string));
            dt_resultados.Columns.Add(dados_pagamento.PAGAMENTO_DATA_ALTERACAO, typeof(string));
            dt_resultados.Columns.Add(dados_pagamento.PAGAMENTO_ATIVO, typeof(string));

            //base para dados do atendimento retornado como selecionado!
            dt_atendimentos = new DataTable();
            dt_atendimentos.Columns.Add(dados_atendimento.ATENDIMENTO_CODIGO, typeof(int));
            dt_atendimentos.Columns.Add("nome", typeof(string));
            cbx_atendimento.DisplayMember = "nome";
            cbx_atendimento.ValueMember = dados_atendimento.ATENDIMENTO_CODIGO;
            cbx_atendimento.DataSource = dt_atendimentos;

            //base para dados dos meios de pagamento!
            dt_meio_pagamento.Columns.Add(dados_meio_pagamento.MEIO_PAGAMENTO_CODIGO, typeof(int));
            dt_meio_pagamento.Columns.Add(dados_meio_pagamento.MEIO_PAGAMENTO_NOME, typeof(string));

            dtpckr_dataCriacao.Value = DateTime.Now;
            carregarMetodosPagamento();
        }

        private void txt_valor_pagamento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(txt_valor_pagamento.Text);
                Double resultado = Math.Round((Convert.ToDouble(txt_valor_pagamento.Text)));
                if (resultado < 0)
                {
                    txt_valor_pagamento.BackColor = Color.Red;
                    txt_valor_pagamento.ForeColor = Color.White;
                }
                else
                {
                    if (resultado > 0)
                    {
                        txt_valor_pagamento.BackColor = Color.Green;
                        txt_valor_pagamento.ForeColor = Color.White;
                    }
                    else
                    {
                        txt_valor_pagamento.BackColor = Color.Gainsboro;
                        txt_valor_pagamento.ForeColor = Color.Black;
                    }
                }
            }
            catch
            {
                chkbx_ativar_valorPagamento.Checked = false;
            }
        }

        private void txt_valor_pagamento_Validated(object sender, EventArgs e)
        {
            txt_valor_pagamento.Text = utilidades.captarValorMonetarioValido_paraExibicao(txt_valor_pagamento.Text.ToString());
        }

        private void txt_valor_troco_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(txt_valor_troco.Text);
                Double resultado = Math.Round((Convert.ToDouble(txt_valor_troco.Text)));
                if (resultado < 0)
                {
                    txt_valor_troco.BackColor = Color.Red;
                    txt_valor_troco.ForeColor = Color.White;
                }
                else
                {
                    if (resultado > 0)
                    {
                        txt_valor_troco.BackColor = Color.Green;
                        txt_valor_troco.ForeColor = Color.White;
                    }
                    else
                    {
                        txt_valor_troco.BackColor = Color.Gainsboro;
                        txt_valor_troco.ForeColor = Color.Black;
                    }
                }
            }
            catch
            {
                chkbx_ativar_valorTroco.Checked = false;
            }
        }

        private void txt_valor_troco_Validated(object sender, EventArgs e)
        {
            txt_valor_troco.Text = utilidades.captarValorMonetarioValido_paraExibicao(txt_valor_troco.Text.ToString());
        }

        private void chkbx_ativar_data_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_ativar_data.Checked)
            {
                dtpckr_dataCriacao.Enabled = true;
            }
            else
            {
                dtpckr_dataCriacao.Enabled = false;
            }
        }

        private void chkbx_ativar_codigo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_ativar_codigo.Checked)
            {
                txt_codigo.Enabled = true;
            }
            else
            {
                txt_codigo.Enabled = false;
            }
        }

        private void chkbx_ativar_valorTroco_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_ativar_valorTroco.Checked)
            {
                txt_valor_troco.Enabled = true;
                if (txt_valor_troco.Text.Equals(""))
                {
                    txt_valor_troco.Text = "0,00";
                }
            }
            else
            {
                txt_valor_troco.Enabled = false;
            }
        }

        private void chkbx_ativar_valorPagamento_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_ativar_valorPagamento.Checked)
            {
                txt_valor_pagamento.Enabled = true;
                if (txt_valor_pagamento.Text.Equals(""))
                {
                    txt_valor_pagamento.Text = "0,00";
                }
            }
            else
            {
                txt_valor_pagamento.Enabled = false;
            }
        }

        private void chkbx_ativar_meioPagamento_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_ativar_meioPagamento.Checked)
            {
                cbx_meios_pagamento.Enabled = true;
            }
            else
            {
                cbx_meios_pagamento.Enabled = false;
            }
        }  

        private void dtg_resultados_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //seleciona toda a linha quando clico 2x em uma celula!
            int cont = 0;
            for (cont = 0; cont < 6; cont++)
            {
                try
                {
                    dtg_resultados.Rows[e.RowIndex].Cells[cont].Selected = true;
                }
                catch { }
            }
        }

        private void txt_codigo_TextChanged(object sender, EventArgs e)
        {
            //deixa colocar somente numeros!
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_codigo.Text, "[^0-9]"))
            {
                MessageBox.Show("Somente números!");
                txt_codigo.Text = "";
            }
        }

        private void dtg_resultados_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            pintarTabela();
        } 
        #endregion

        #region FUNÇÕES
        private void carregarMetodosPagamento()
        {
            //completa o combobox de metodos!  
            if (conexaoBD.abrirConexao())
            {
                //completa o combobox de metodos de pagamento!                
                List<meio_pagamento> listaMetodosPg = dados_meio_pagamento.selecionarTodosMeiosPagamento();
                //monta a fonte de dados
                int cont = 0;
                for (cont = 0; cont < listaMetodosPg.Count; cont++)
                {
                    dt_meio_pagamento.Rows.Add(listaMetodosPg[cont].getCod_meio_pgto_pk(),
                    listaMetodosPg[cont].getNome_meio_pgto()
                    );
                }
                cbx_meios_pagamento.DataSource = dt_meio_pagamento;
                cbx_meios_pagamento.DisplayMember = dados_meio_pagamento.MEIO_PAGAMENTO_NOME;
                cbx_meios_pagamento.ValueMember = dados_meio_pagamento.MEIO_PAGAMENTO_CODIGO;
            }
        }
        private void pintarTabela()
        {
            foreach (DataGridViewRow i in dtg_resultados.Rows)
            {
                try
                {
                    //se a data de criacao e alteração nao forem a mesma ele pinta de amarelo destacando!
                    if (!utilidades.captarDatetime_banco_paraDatetime(i.Cells[dados_pagamento.PAGAMENTO_DATA_CRIACAO].Value.ToString()).Equals(utilidades.captarDatetime_banco_paraDatetime(i.Cells[dados_pagamento.PAGAMENTO_DATA_ALTERACAO].Value.ToString())))
                    {
                        i.DefaultCellStyle.BackColor = Color.Khaki;
                        i.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        if (!(i.Cells[dados_pagamento.PAGAMENTO_ATIVO].Value.ToString()).Equals("s"))
                        {
                            i.DefaultCellStyle.BackColor = Color.DarkRed;
                            i.DefaultCellStyle.ForeColor = Color.White;
                        }
                        else 
                        {
                            i.DefaultCellStyle.BackColor = Color.White;
                            i.DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                }
                catch { }
            }
        }

        private void pesquisar()
        {
            //componentes principais
            pagamento pagamento = new pagamento();
            List<pagamento> pagamento_resultados = null;
            dtg_resultados.DataSource = dt_resultados;
            //variaveis de filtragem!
            List<atendimento> atendimentos = new List<atendimento>(); 

            //pesquisando conforme solicitações
            if (conexaoBD.abrirConexao())
            {
                try
                {
                    if (chkbx_ativar_codigo.Checked)
                    {
                        try
                        {
                            pagamento.setCod_pagamento_pk(Convert.ToInt32(txt_codigo.Text));
                        }
                        catch { }
                    }
                    if (chkbx_ativar_meioPagamento.Checked)
                    {
                        pagamento.setCod_meio_pgto_fk(Convert.ToInt32(cbx_meios_pagamento.SelectedValue));
                    }
                    if (chkbx_ativar_valorPagamento.Checked)
                    {
                       pagamento.setValor_pagamento(Convert.ToDouble(utilidades.captarValorMonetarioValido_paraExibicao(txt_valor_pagamento.Text)));
                    }                    
                    if (chkbx_ativar_valorTroco.Checked)
                    {
                       pagamento.setTroco_pagamento(Convert.ToDouble(utilidades.captarValorMonetarioValido_paraExibicao(txt_valor_troco.Text)));
                    }
                    if (chkbx_ativar_data.Checked)
                    {
                        pagamento.setData_criacao_pagamento(utilidades.captarDate_dtpckr(dtpckr_dataCriacao));
                    }
                    if (rbtn_pagamentos_cancelados.Checked)
                    {
                        pagamento.setEstado_ativo_pagamento('n');
                    }
                    if (chkbx_alterados.Checked)
                    {
                        //necessita só de um valor qualquer para vir só os alterados!
                        pagamento.setData_alteracao_pagamento(utilidades.captarDate_dtpckr(dtpckr_dataCriacao));
                    }    
                    if(flwpnl_atendimentosSelecionados.Controls.Count>0)
                    {
                        foreach (Button i in flwpnl_atendimentosSelecionados.Controls)
                        {
                            try
                            {
                            atendimentos.Add((atendimento)i.Tag);
                            }catch{}
                        }
                    }
                    //Estilos de Pesquisa!
                    if (rdbtn_igual.Checked)    //igual
                    {
                        if (pagamento.getEstado_ativo_pagamento().Equals('n'))
                        {
                            pagamento_resultados = dados_pagamento.selecionarTodosPagamentos_desativo_porBusca_igual(pagamento);
                        }
                        else 
                        {
                            pagamento_resultados = dados_pagamento.selecionarTodosPagamentos_ativo_porBusca_igual(pagamento);
                        }
                        if ((atendimentos.Count>0)&&(pagamento_resultados.Count>0))
                        {
                            List<pagamento_atendimento> pagamento_atendimento_lista = new List<pagamento_atendimento>();
                            //capto todos ids de atendimentos listados para filtra a busca!
                            foreach (atendimento i in atendimentos)
                            {
                                pagamento_atendimento pagamento_atendimento_novo = new pagamento_atendimento();
                                pagamento_atendimento_novo.setCod_atendimento_fk(i.getCod_atendimento_pk());
                                pagamento_atendimento_lista.Add(pagamento_atendimento_novo);
                            }
                            if (pagamento_atendimento_lista.Count > 0)
                            {
                                //recebo a lista de relacionamentos de pagamentos que contenham os atendimentos filtrados!
                                List<pagamento_atendimento> pagamento_atendimento_listaRecebida = dados_pagamento_atendimento.selecionarTodosPagamento_atendimento_porCodAtendimentos(pagamento_atendimento_lista);
                                List<int> pagamentos_ids = pagamento_atendimento_listaRecebida.Select(pagamento_atendimento => pagamento_atendimento.getCod_pagamento_fk()).ToList();
                                List<pagamento> pagamentos_aSeremRemovidos = new List<pagamento>();
                                foreach (pagamento i in pagamento_resultados)
                                {
                                    //se nao estiver na lista sera removido!
                                    if (!pagamentos_ids.Contains(i.getCod_pagamento_pk()))
                                    {
                                        pagamentos_aSeremRemovidos.Add(i);
                                    }
                                }
                                foreach (pagamento i in pagamentos_aSeremRemovidos)
                                {
                                    pagamento_resultados.Remove(i);
                                }
                            }
                        }
                    //Pesquisando
                    if ((pagamento_resultados != null))
                    {
                        dt_resultados.Clear();
                        if (pagamento_resultados.Count > 0)
                        {
                            int cont = 0;
                            while (cont < pagamento_resultados.Count)
                            {
                                pagamento_atendimento pagamento_atendimento = new pagamento_atendimento();
                                pagamento_atendimento.setCod_pagamento_fk(pagamento_resultados[cont].getCod_pagamento_pk());
                                List<int> atendimentos_ids = new List<int>();
                                List<pagamento_atendimento> atendimentos_recebidos = dados_pagamento_atendimento.selecionarTodosPagamento_atendimento_porCodPagamento(pagamento_atendimento);
                                foreach (pagamento_atendimento i in atendimentos_recebidos)
                                {
                                    if (!atendimentos_ids.Contains(i.getCod_atendimento_fk()))
                                    {
                                        atendimentos_ids.Add(i.getCod_atendimento_fk());
                                    }
                                }
                                String atendimentos_ids_envolvidos = "";
                                int contInicio = 0;
                                foreach (int i in atendimentos_ids)
                                {
                                    if (contInicio == 0)
                                    {
                                        atendimentos_ids_envolvidos += i;

                                    }
                                    else
                                    {
                                        atendimentos_ids_envolvidos += ",";
                                        atendimentos_ids_envolvidos += i;
                                    }
                                    contInicio++;
                                    
                                }
                                    dt_resultados.Rows.Add(
                                    pagamento_resultados[cont].getCod_pagamento_pk(),
                                    atendimentos_ids_envolvidos,
                                    "R$" + utilidades.captarValorMonetarioValido_paraExibicao(pagamento_resultados[cont].getValor_pagamento().ToString()),
                                    "R$" + utilidades.captarValorMonetarioValido_paraExibicao(pagamento_resultados[cont].getTroco_pagamento().ToString()),
                                    pagamento_resultados[cont].getCod_meio_pgto_fk(),
                                    pagamento_resultados[cont].getData_criacao_pagamento(),
                                    pagamento_resultados[cont].getData_alteracao_pagamento(),
                                    pagamento_resultados[cont].getEstado_ativo_pagamento()
                                );
                                cont++;
                            }
                        }
                        else
                        {
                            MessageBox.Show(null, "Não foram econtrados resultados!\n", "INFORMAÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }                        
                    }

                }

                    //Estilos de Pesquisa!
                    if (rdbtn_contem.Checked)    //contem
                    {
                        if (pagamento.getEstado_ativo_pagamento().Equals('n'))
                        {
                            pagamento_resultados = dados_pagamento.selecionarTodosPagamentos_desativo_porBusca_contem(pagamento);
                        }
                        else
                        {
                            pagamento_resultados = dados_pagamento.selecionarTodosPagamentos_ativo_porBusca_contem(pagamento);
                        }
                        if ((atendimentos.Count > 0) && (pagamento_resultados.Count > 0))
                        {
                            List<pagamento_atendimento> pagamento_atendimento_lista = new List<pagamento_atendimento>();
                            //capto todos ids de atendimentos listados para filtra a busca!
                            foreach (atendimento i in atendimentos)
                            {
                                pagamento_atendimento pagamento_atendimento_novo = new pagamento_atendimento();
                                pagamento_atendimento_novo.setCod_atendimento_fk(i.getCod_atendimento_pk());
                                pagamento_atendimento_lista.Add(pagamento_atendimento_novo);
                            }
                            if (pagamento_atendimento_lista.Count > 0)
                            {
                                //recebo a lista de relacionamentos de pagamentos que contenham os atendimentos filtrados!
                                List<pagamento_atendimento> pagamento_atendimento_listaRecebida = dados_pagamento_atendimento.selecionarTodosPagamento_atendimento_porCodAtendimentos(pagamento_atendimento_lista);
                                List<int> pagamentos_ids = pagamento_atendimento_listaRecebida.Select(pagamento_atendimento => pagamento_atendimento.getCod_pagamento_fk()).ToList();
                                List<pagamento> pagamentos_aSeremRemovidos = new List<pagamento>();
                                foreach (pagamento i in pagamento_resultados)
                                {
                                    //se nao estiver na lista sera removido!
                                    if (!pagamentos_ids.Contains(i.getCod_pagamento_pk()))
                                    {
                                        pagamentos_aSeremRemovidos.Add(i);
                                    }
                                }
                                foreach (pagamento i in pagamentos_aSeremRemovidos)
                                {
                                    pagamento_resultados.Remove(i);
                                }
                            }
                        }
                        //Pesquisando
                        if ((pagamento_resultados != null))
                        {
                            dt_resultados.Clear();
                            if (pagamento_resultados.Count > 0)
                            {
                                int cont = 0;
                                while (cont < pagamento_resultados.Count)
                                {
                                    pagamento_atendimento pagamento_atendimento = new pagamento_atendimento();
                                    pagamento_atendimento.setCod_pagamento_fk(pagamento_resultados[cont].getCod_pagamento_pk());
                                    List<int> atendimentos_ids = new List<int>();
                                    List<pagamento_atendimento> atendimentos_recebidos = dados_pagamento_atendimento.selecionarTodosPagamento_atendimento_porCodPagamento(pagamento_atendimento);
                                    foreach (pagamento_atendimento i in atendimentos_recebidos)
                                    {
                                        if (!atendimentos_ids.Contains(i.getCod_atendimento_fk()))
                                        {
                                            atendimentos_ids.Add(i.getCod_atendimento_fk());
                                        }
                                    }
                                    String atendimentos_ids_envolvidos = "";
                                    int contInicio = 0;
                                    foreach (int i in atendimentos_ids)
                                    {
                                        if (contInicio == 0)
                                        {
                                            atendimentos_ids_envolvidos += i;

                                        }
                                        else
                                        {
                                            atendimentos_ids_envolvidos += ",";
                                            atendimentos_ids_envolvidos += i;
                                        }
                                        contInicio++;

                                    }
                                    dt_resultados.Rows.Add(
                                    pagamento_resultados[cont].getCod_pagamento_pk(),
                                    atendimentos_ids_envolvidos,
                                    "R$" + utilidades.captarValorMonetarioValido_paraExibicao(pagamento_resultados[cont].getValor_pagamento().ToString()),
                                    "R$" + utilidades.captarValorMonetarioValido_paraExibicao(pagamento_resultados[cont].getTroco_pagamento().ToString()),
                                    pagamento_resultados[cont].getCod_meio_pgto_fk(),
                                    pagamento_resultados[cont].getData_criacao_pagamento(),
                                    pagamento_resultados[cont].getData_alteracao_pagamento(),
                                    pagamento_resultados[cont].getEstado_ativo_pagamento()
                                );
                                    cont++;
                                }
                            }
                            else
                            {
                                MessageBox.Show(null, "Não foram econtrados resultados!\n", "INFORMAÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }

                    }

                }
                catch (Exception erro)
                {
                    MessageBox.Show(null, "Não foi possivel efetuar a pesquisa!\n" + erro, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }        
        }                 

        private void carregarModo()
        {
            switch (MODO)
            {
                case 1:
                    btn_escolher_selecionado.Enabled = false;
                    break;
                case 2:
                    //Estilo Seleção!
                    btn_alterar.Enabled = false;
                    break;
            }
        }      

        private void carregarAtendimentoSelecionado()
        {
            //seleciono o atendimento
            if (atendimentoSelecionado != null)
            {
                if (conexaoBD.abrirConexao())
                {
                    atendimentoSelecionado = dados_atendimento.selecionarUmAtendimento_porCodigo(atendimentoSelecionado);
                    //dados
                    cliente cliente = new cliente();
                    responsavel responsavel = new responsavel();
                    //seto
                    cliente.setCod_cliente_pk(atendimentoSelecionado.getCod_cliente_fk());
                    responsavel.setCod_responsavel_pk(atendimentoSelecionado.getCod_responsavel_fk());
                    //dados do valor e valor pago
                    item_atendimento item_atendimento = new item_atendimento();
                    item_atendimento.setCod_atendimento_fk(atendimentoSelecionado.getCod_atendimento_pk());
                    List<item_atendimento> listaItems = new List<item_atendimento>();
                    listaItems = dados_item_atendimento.selecionarTodosItem_atendimento_porCodigoAtendimento(item_atendimento);
                    Double valorTotal = 0.0;
                    foreach (item_atendimento i in listaItems)
                    {
                        valorTotal += i.getValor_combinado_item_atendimento();
                    }
                    pagamento_atendimento pagamento_atendimento = new pagamento_atendimento();
                    pagamento_atendimento.setCod_atendimento_fk(atendimentoSelecionado.getCod_atendimento_pk());
                    List<pagamento_atendimento> listaPagamentos = new List<pagamento_atendimento>();
                    listaPagamentos = dados_pagamento_atendimento.selecionarTodosPagamento_atendimento_porCodAtendimento(pagamento_atendimento);
                    Double valorTotalPago = 0.0;
                    foreach (pagamento_atendimento i in listaPagamentos)
                    {
                        valorTotalPago += i.getValor_fatia_pagamento();
                    }
                    //cliente e responnsavel existem!
                    if ((responsavel.getCod_responsavel_pk() > 0) && (cliente.getCod_cliente_pk() > 0))
                    {
                        //procuro
                        cliente = dados_cliente.selecionarUmCliente_porCodigo(cliente);
                        responsavel = dados_responsavel.selecionarUmResponsavel_porCodigo(responsavel);
                        //completo a composição para o combobox
                        dt_atendimentos.Rows.Add(
                        atendimentoSelecionado.getCod_atendimento_pk(),
                        atendimentoSelecionado.getCod_atendimento_pk() + " - " +
                        cliente.getNome_cliente() + " : " +
                        responsavel.getNome_responsavel() + " - R$" +
                        valorTotalPago + "/R$" +
                        valorTotal + " - " + utilidades.captarDate_banco(atendimentoSelecionado.getData_criacao_atendimento())
                        );
                    }
                    //Ou cliente Ou responnsavel nao existem!
                    else
                    {
                        //existe só o responsavel!
                        if (responsavel.getCod_responsavel_pk() > 0)
                        {
                            //procuro
                            responsavel = dados_responsavel.selecionarUmResponsavel_porCodigo(responsavel);
                            //completo a composição para o combobox
                            dt_atendimentos.Rows.Add(
                            atendimentoSelecionado.getCod_atendimento_pk(),
                            atendimentoSelecionado.getCod_atendimento_pk() + " - " +
                           "|S/C| : " +
                            responsavel.getNome_responsavel() + " - R$" +
                            valorTotalPago + "/R$" +
                            valorTotal + " - " + utilidades.captarDate_banco(atendimentoSelecionado.getData_criacao_atendimento())
                            );
                        }
                        //existe só o cliente!
                        else
                        {
                            //procuro
                            cliente = dados_cliente.selecionarUmCliente_porCodigo(cliente);
                            //completo a composição para o combobox
                            dt_atendimentos.Rows.Add(
                            atendimentoSelecionado.getCod_atendimento_pk(),
                            atendimentoSelecionado.getCod_atendimento_pk() + " - " +
                            cliente.getNome_cliente() + " : " +
                            "|S/R|  -  R$" +
                            valorTotalPago + "/R$" +
                            valorTotal + " - " + utilidades.captarDate_banco(atendimentoSelecionado.getData_criacao_atendimento())
                        );
                        }
                    }
                    dt_atendimentos.DefaultView.Sort = dados_atendimento.ATENDIMENTO_CODIGO + " asc";
                }
            }     
        }

        private bool verificarAtendimentoJaAdicionado(atendimento at) 
        {
            bool encontrou = false;
            foreach (Button i in flwpnl_atendimentosSelecionados.Controls)
            {
                atendimento atendimento = new atendimento();
                try
                {
                    atendimento = (atendimento)(i.Tag);
                    if (atendimento.getCod_atendimento_pk() == at.getCod_atendimento_pk())
                    {
                        encontrou = true;
                    }
                }
                catch{}
            }
            return encontrou;
        }

        private void adicionarAtendimentoSelecionado()
        {
            //seleciono o atendimento
            if (atendimentoSelecionado != null)
            {
                if (conexaoBD.abrirConexao())
                {
                    atendimentoSelecionado = dados_atendimento.selecionarUmAtendimento_porCodigo(atendimentoSelecionado);

                    try
                    {
                        Button btn = new Button();
                        btn.Tag = atendimentoSelecionado;
                        btn.Text = atendimentoSelecionado.getCod_atendimento_pk().ToString();
                        if (utilidades.verificarTotalmentePagoBanco_paraExibicao(atendimentoSelecionado.getEstado_pago_atendimento()).Equals("Devendo"))
                        {
                            btn.BackColor = Color.Red;
                            btn.ForeColor = Color.White;
                        }
                        else
                        {
                            btn.BackColor = Color.Green;
                            btn.ForeColor = Color.White;
                        }
                        btn.TextAlign = ContentAlignment.MiddleCenter;
                        flwpnl_atendimentosSelecionados.Controls.Add(btn);
                        btn.Height = flwpnl_atendimentosSelecionados.Height-10;
                        btn.Click += btn_atendimentosAdicionadosALista_Click;
                    }
                    catch
                    { }
                }
            }
        }

        private void btn_atendimentosAdicionadosALista_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                if (MessageBox.Show(null, "Deseja remover este atendimento da lista?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    flwpnl_atendimentosSelecionados.Controls.Remove(btn);
                }
            }
            catch { }
        }
        #endregion       

        #region Membros de uc_identificacao
        public string getTitulo()
        {
            uc_identificacao pai = (uc_identificacao)Parent.Parent;
            return pai.getTitulo();
        }

        public string getDescricao()
        {
            return "Pesquisar Pagamentos";
        }

        public int getModoAtual()
        {
            return this.MODO;
        }

        public Object getControleAbas()
        {
            return null;
        }
        #endregion                             

        #region Membros de requerimento_pagamento
        public void atendimentoEscolhido(atendimento atendimento)
        {
            this.atendimentoSelecionado = atendimento;
        }
        public void sinalizarEscolha_atendimento(bool escolhido)
        {
            utilidades.remover_telaCarregando(this);
            if (escolhido)
            {
                carregarAtendimentoSelecionado();
            }
            else
            {
                MessageBox.Show(mensagem05);
            }
        }
        #endregion                                        
        
    }
}
