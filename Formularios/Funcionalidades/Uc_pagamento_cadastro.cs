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
using MySql.Data.MySqlClient;

namespace gerenciador_antt.Formularios
{
    public partial class Uc_pagamento_cadastro : UserControl, uc_identificacao, requerimento_atendimento
    {
        //MODO
        //1 = Cadastro, 2=Alteracão, 3=Leitura
        int MODO = 1; //padrao modo cadastro!
        frm_principal principal = null;
        //para o modo 2 e 3!
        pagamento pagamentoAlvo = null;
        atendimento atendimentoSelecionado = null;
        
        #region DADOS
        //dados        
        dados_atendimento dados_atendimento = new dados_atendimento();
        dados_meio_pagamento dados_meio_pagamento = new dados_meio_pagamento();
        dados_cliente dados_cliente = new dados_cliente();
        dados_responsavel dados_responsavel = new dados_responsavel();
        dados_item_atendimento dados_item_atendimento = new dados_item_atendimento();
        dados_pagamento dados_pagamento = new dados_pagamento();
        dados_pagamento_atendimento dados_pagamento_atendimento = new dados_pagamento_atendimento();
        DataTable dt_atendimentos = new DataTable();
        DataTable dt_atendimentosListados = new DataTable();
        DataTable dt_meio_pagamento = new DataTable();
    
        //mensagens
        String mensagem01 = "Deseja realmente efetuar este pagamento?";
        String mensagem02 = "Não foi possível Cadastrar!";
        String mensagem03 = " - Cadastrado com Sucesso!";
        String mensagem04 = "Deseja realmente fechar esta aba?";
        String mensagem05 = "Não foi selecionado um Atendimento!";
        String mensagem06 = "Não é possivel cadastrar o pagamento porque não consta valor em débito!";
        #endregion

        #region inicializadores
        public Uc_pagamento_cadastro(frm_principal principal)
        {
            //util em modo 1 padrao!
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

        public Uc_pagamento_cadastro(frm_principal principal, int modo, pagamento pagamentoAlvo)
        {
            //util em modo 2/3!
            this.principal = principal;
            this.pagamentoAlvo = pagamentoAlvo;
            this.MODO = modo;
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
        
        #region Rotinas de componentes
        private void Uc_pagamento_cadastro_Load(object sender, EventArgs e)
        {
            //base para dados do atendimentos adicionados dtg_resultados!
            dt_atendimentosListados = new DataTable();
            dt_atendimentosListados.Columns.Add(dados_atendimento.ATENDIMENTO_CODIGO, typeof(int));
            dt_atendimentosListados.Columns.Add(dados_atendimento.ATENDIMENTO_CODIGO_CLIENTE, typeof(string));
            dt_atendimentosListados.Columns.Add(dados_atendimento.ATENDIMENTO_CODIGO_RESPONSAVEL, typeof(string));
            dt_atendimentosListados.Columns.Add("total", typeof(string));
            dt_atendimentosListados.Columns.Add("pago", typeof(string));
            dt_atendimentosListados.Columns.Add(dados_atendimento.ATENDIMENTO_ESTADO_PAGO, typeof(string));
            dt_atendimentosListados.Columns.Add(dados_atendimento.ATENDIMENTO_DATA_CRIACAO, typeof(string));
            dt_atendimentosListados.Columns.Add("fatia", typeof(string));
            dtg_resultados.DataSource = dt_atendimentosListados;

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

            carregarMetodosPagamento();
            carregarModo();
        }

        private void dtg_resultados_MouseLeave(object sender, EventArgs e)
        {
            atualizarValorTotalDevido();
        }

        private void chkbx_pagamento_cancelado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_pagamento_cancelado.Checked)
            {
                gbx_pagamento_informacoes.BackColor = Color.LightSlateGray;
            }
            else
            {
                gbx_pagamento_informacoes.BackColor = Color.White;
            }
        }

        private void dtg_resultados_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                List<DataRow> deletarLista = new List<DataRow>();
                List<int> idsDeletear = new List<int>();
                if (dtg_resultados.SelectedCells.Count > 0)
                {
                    foreach (DataGridViewCell u in dtg_resultados.SelectedCells)
                    {
                        idsDeletear.Add(Convert.ToInt32(dtg_resultados.Rows[u.RowIndex].Cells[dados_atendimento.ATENDIMENTO_CODIGO].Value));
                    }
                    foreach (DataRow i in dt_atendimentosListados.Rows)
                    {
                        int cont = 0;
                        for (cont = 0; cont < idsDeletear.Count; cont++)
                        {
                            if (Convert.ToInt32(i[dados_atendimento.ATENDIMENTO_CODIGO]) == idsDeletear[cont])
                            {
                                deletarLista.Add(i);
                            }
                        }
                    }
                    foreach (DataRow i in deletarLista)
                    {
                        i.Delete();
                    }
                }
            }
        }

        private void dtg_resultados_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            rbtn_balancear_igual.Checked = false;
            rbtn_balancear_maisAntigo.Checked = false;
            atualizarValorTotalDevido();
        }

        private void dtg_resultados_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            rbtn_balancear_igual.Checked = false;
            rbtn_balancear_maisAntigo.Checked = false;
            atualizarValorTotalDevido();
        }

        private void txt_valor_recebido_TextChanged(object sender, EventArgs e)
        {
            try
            {
                rbtn_balancear_igual.Checked = false;
                rbtn_balancear_maisAntigo.Checked = false;

                Double resultado = utilidades.calcularTroco((Convert.ToDouble(txt_valor_recebido.Text)),(Convert.ToDouble(txt_valor_total_devido.Text)));
               
                if (resultado < 0)
                {
                    txt_valor_troco.BackColor = Color.White;
                    txt_valor_troco.Text = utilidades.captarValorMonetarioValido_paraExibicao("");
                }
                else
                {
                    if (resultado > 0)
                    {
                        txt_valor_troco.BackColor = Color.Green;
                        txt_valor_troco.Text = utilidades.captarValorMonetarioValido_paraExibicao(resultado.ToString());
                    }
                    else
                    {
                        txt_valor_troco.BackColor = Color.White;
                        txt_valor_troco.Text = utilidades.captarValorMonetarioValido_paraExibicao("");
                    }
                }
            }
            catch
            {
                txt_valor_troco.Text = "";
                txt_valor_recebido.Text = "";
                txt_valor_troco.BackColor = Color.White;
            }
        }

        private void rbtn_balancear_igual_CheckedChanged(object sender, EventArgs e)
        {
            /*
            if (rbtn_balancear_igual.Checked)
            {
                if ((!(txt_valor_troco.Text.Equals(String.Empty))) || (!(dt_atendimentosListados.Rows.Count < 1)))
                {
                    foreach (DataGridViewRow i in dtg_resultados.Rows)
                    {
                        try
                        {
                            //fatia livre não cobre o que deve!
                            if ((Math.Round((Convert.ToDouble(txt_valor_recebido.Text) / dt_atendimentosListados.Rows.Count), 2)) < (Convert.ToDouble(i.Cells["total"].Value.ToString().Replace("R$", "")) - (Convert.ToDouble(i.Cells["pago"].Value.ToString().Replace("R$", "")))))
                            {
                                i.Cells["fatia"].Style.BackColor = Color.Red;
                                i.Cells["fatia"].Style.ForeColor = Color.White;
                                i.Cells["fatia"].Value = "R$" + Math.Round((Convert.ToDouble(txt_valor_recebido.Text) / dt_atendimentosListados.Rows.Count), 2);
                            }
                            else
                            {
                                //fatia livre cobre o que deve!
                                if (((Math.Round((Convert.ToDouble(txt_valor_recebido.Text) / dt_atendimentosListados.Rows.Count), 2)) >= (Convert.ToDouble(i.Cells["total"].Value.ToString().Replace("R$", "")) - (Convert.ToDouble(i.Cells["pago"].Value.ToString().Replace("R$", ""))))))
                                {
                                    i.Cells["fatia"].Style.BackColor = Color.Green;
                                    i.Cells["fatia"].Style.ForeColor = Color.White;
                                    i.Cells["fatia"].Value = "R$" + Math.Round((Convert.ToDouble(txt_valor_recebido.Text) / dt_atendimentosListados.Rows.Count), 2);
                                }
                                //fatia livre zerada!
                                else
                                {
                                    i.Cells["fatia"].Style.BackColor = Color.White;
                                    i.Cells["fatia"].Style.ForeColor = Color.Black;
                                    i.Cells["fatia"].Value = "";
                                }
                            }
                        }
                        catch
                        {
                            rbtn_balancear_igual.Checked = false;
                        }
                    }
                }
                else
                {
                    rbtn_balancear_igual.Checked = false;
                }
            }
            else
            {

                foreach (DataGridViewRow i in dtg_resultados.Rows)
                {
                    i.Cells["fatia"].Value = "";
                    i.Cells["fatia"].Style.BackColor = Color.White;
                    i.Cells["fatia"].Style.ForeColor = Color.Black;
                }
            }
             * falta modificar para cota maoir q valor se ajustar ao valor sem excedentes!
             */
        }

        private void rbtn_balancear_maisAntigo_CheckedChanged(object sender, EventArgs e)
        {
            Double fatiaCalculada = 0;
            if (rbtn_balancear_maisAntigo.Checked)
            {               
                    if ((!(txt_valor_troco.Text.Equals(String.Empty))) || (!(dt_atendimentosListados.Rows.Count < 1)))
                    {
                        foreach (DataGridViewRow i in dtg_resultados.Rows)
                        {
                            try
                            {
                                //fatia livre cobre o que deve!
                                if ((Convert.ToDouble(txt_valor_recebido.Text) - fatiaCalculada) >= (Convert.ToDouble(i.Cells["total"].Value.ToString().Replace("R$", "")) - (Convert.ToDouble(i.Cells["pago"].Value.ToString().Replace("R$", "")))))
                                {
                                    i.Cells["fatia"].Value = "R$" + (Convert.ToDouble(i.Cells["total"].Value.ToString().Replace("R$", "")) - (Convert.ToDouble(i.Cells["pago"].Value.ToString().Replace("R$", ""))));
                                    i.Cells["fatia"].Style.BackColor = Color.Green;
                                    i.Cells["fatia"].Style.ForeColor = Color.White;
                                    fatiaCalculada += (Convert.ToDouble(i.Cells["total"].Value.ToString().Replace("R$", "")) - (Convert.ToDouble(i.Cells["pago"].Value.ToString().Replace("R$", ""))));
                                }
                                else
                                {
                                    //fatia livre não cobre o que deve, mas ainda nao é valor zero
                                    if (((Convert.ToDouble(txt_valor_recebido.Text) - fatiaCalculada) < (Convert.ToDouble(i.Cells["total"].Value.ToString().Replace("R$", "")) - (Convert.ToDouble(i.Cells["pago"].Value.ToString().Replace("R$", ""))))) && ((Convert.ToDouble(txt_valor_recebido.Text) - fatiaCalculada) != 0))
                                    {
                                        i.Cells["fatia"].Value = "R$" + (Convert.ToDouble(txt_valor_recebido.Text) - fatiaCalculada);
                                        i.Cells["fatia"].Style.BackColor = Color.Red;
                                        i.Cells["fatia"].Style.ForeColor = Color.White;
                                        fatiaCalculada += (Convert.ToDouble(txt_valor_recebido.Text) - fatiaCalculada);
                                    }
                                    else
                                    {
                                        //fatia livre zerada!
                                        i.Cells["fatia"].Value = "";
                                        i.Cells["fatia"].Style.BackColor = Color.White;
                                        i.Cells["fatia"].Style.ForeColor = Color.Black;
                                    }
                                }
                            }
                            catch { rbtn_balancear_maisAntigo.Checked = false; }
                        }
                    }
                    else
                    {
                        rbtn_balancear_maisAntigo.Checked = false;
                    }
                }
                else
                {

                    foreach (DataGridViewRow i in dtg_resultados.Rows)
                    {
                        i.Cells["fatia"].Value = "";
                        i.Cells["fatia"].Style.BackColor = Color.White;
                        i.Cells["fatia"].Style.ForeColor = Color.Black;
                    }
                }
        }

        private void txt_valor_recebido_Validated(object sender, EventArgs e)
        {
            try
            {
                if ((Convert.ToDouble(utilidades.captarValorMonetarioValido_paraExibicao(txt_valor_recebido.Text))) < 0)
                {
                    txt_valor_recebido.Text = utilidades.captarValorMonetarioValido_paraExibicao(txt_valor_recebido.Text.Replace("-", ""));
                }
                else
                {
                    txt_valor_recebido.Text = utilidades.captarValorMonetarioValido_paraExibicao(txt_valor_recebido.Text);
                }
            }catch
            {
                txt_valor_recebido.Text = "";
            }
        }

        private void rbtn_balancear_maisAntigo_MouseDown(object sender, MouseEventArgs e)
        {
            if (rbtn_balancear_maisAntigo.Checked)
            {
                rbtn_balancear_maisAntigo.Checked = false;
            }
        }

        private void txt_observacao_Leave(object sender, EventArgs e)
        {
            utilidades.colocarTexto_observacoes(txt_observacao);
        }

        private void txt_observacao_Enter(object sender, EventArgs e)
        {
            utilidades.colocarTexto_observacoes(txt_observacao);
        }

        private void txt_observacao_TextChanged(object sender, EventArgs e)
        {
            utilidades.colocarTexto_observacoes(txt_observacao);
        }
        private void txt_observacao_Validated(object sender, EventArgs e)
        {
            utilidades.colocarTexto_observacoes(txt_observacao);
        }
        #endregion  

        #region FUNÇÕES
        private bool verificarAtendimentoJaAdicionado(atendimento atendimento)
        {
            bool encontrou = false;
            foreach (DataRow i in dt_atendimentosListados.Rows)
            {
                if (i[dados_atendimento.ATENDIMENTO_CODIGO].ToString().Equals(atendimento.getCod_atendimento_pk().ToString()))
                {
                    encontrou = true;
                }
                else
                {
                   
                }
            }
            return encontrou;
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

                    //Filtor anti duplicidade no cbx!
                    try
                    {
                        //Capto se tiver linha igual a aquela que ira ser adicionada!
                        DataRow dtr = dt_atendimentos.Select(dados_atendimento.ATENDIMENTO_CODIGO + " = " + atendimentoSelecionado.getCod_atendimento_pk())[0];
                        //se tiver deleto-a!
                        if (dtr != null)
                        {
                            dt_atendimentos.Rows.Remove(dtr);
                        }
                    }
                    catch { }

                    //cliente e responnsavel existem!
                    if ((responsavel.getCod_responsavel_pk() > 0)&&(cliente.getCod_cliente_pk()>0)) 
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

        private void adicionarAtendimentoSelecionado()
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
                    //se for modo 2 ou 3 ele so calcula pagamentos realizados de outros pagamentos excluso este!
                    if (pagamentoAlvo != null)
                    {
                        pagamento_atendimento.setCod_pagamento_fk(pagamentoAlvo.getCod_pagamento_pk());
                    }
                    listaPagamentos = dados_pagamento_atendimento.selecionarTodosPagamento_atendimento_porCodAtendimento_e_excetoDestePagamento(pagamento_atendimento);
                    Double valorTotalPago = 0.0;
                    foreach (pagamento_atendimento i in listaPagamentos)
                    {
                        valorTotalPago += i.getValor_fatia_pagamento();
                    }
                    //cliente e responnsavel existem!
                      
                        //procuro
                        cliente = dados_cliente.selecionarUmCliente_porCodigo(cliente);
                        responsavel = dados_responsavel.selecionarUmResponsavel_porCodigo(responsavel);
                        //completo a composição para o combobox
                        dt_atendimentosListados.Rows.Add(
                        atendimentoSelecionado.getCod_atendimento_pk(),
                        cliente.getNome_cliente(),
                        responsavel.getNome_responsavel(), 
                        "R$" +valorTotal, 
                        "R$" +valorTotalPago,
                        utilidades.verificarTotalmentePagoBanco_paraExibicao(atendimentoSelecionado.getEstado_pago_atendimento()),
                        utilidades.captarDate_banco(atendimentoSelecionado.getData_criacao_atendimento())
                        );                   
                    }                
              }
        }

        private void carregarDados_pagamentoAlvo()
        {
            if (pagamentoAlvo != null)
            {
                pagamento_atendimento pagamento_atendimento = new pagamento_atendimento();
                pagamento_atendimento.setCod_pagamento_fk(this.pagamentoAlvo.getCod_pagamento_pk());
                txt_observacao.Text = this.pagamentoAlvo.getObservacao_pagamento();                
                List<pagamento_atendimento> lista_pa = dados_pagamento_atendimento.selecionarTodosPagamento_atendimento_porCodPagamento(pagamento_atendimento);
                foreach (pagamento_atendimento i in lista_pa)
                {
                    atendimento at = new atendimento();
                    at.setCod_atendimento_pk(i.getCod_atendimento_fk());
                    carregarAtendimentoNaTabela(dados_atendimento.selecionarUmAtendimento_porCodigo(at)); 
                    int posicao = dtg_resultados.Rows.GetLastRow(DataGridViewElementStates.Displayed);
                    String valor = utilidades.captarValorMonetarioValido_paraExibicao(i.getValor_fatia_pagamento().ToString());
                    dtg_resultados.Rows[posicao].Cells["fatia"].Value = "R$" + valor;  
                }
                txt_valor_recebido.Text = utilidades.captarValorMonetarioValido_paraExibicao(this.pagamentoAlvo.getValor_pagamento().ToString());                
                txt_valor_troco.Text = this.pagamentoAlvo.getTroco_pagamento().ToString();
                lbl_codigo_numero.Text = this.pagamentoAlvo.getCod_pagamento_pk().ToString();
            }
        }

        private void carregarAtendimentoNaTabela(atendimento at) 
        {
            try
            {
                if (at.getCod_atendimento_pk() > 0) 
                {                    
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

        private void carregarModo()
        {
            switch (MODO)
            {
                case 1:
                    //Padrão já é tudo liberado para cadastro!
                    break;
                case 2:
                    //Estilo Alterar
                    lbl_codigo_nomenclatura.Visible = true;
                    lbl_codigo_numero.Visible = true;
                    renovarFormulario();
                    this.btn_cadastrar_pagamento.Text = "Alterar";
                    mensagem01 = "Deseja realmente Alterar esse Atendimento?";
                    mensagem02 = "Não foi possível Alterar!";
                    mensagem03 = " - Alterado com Sucesso!";                    
                    carregarDados_pagamentoAlvo();
                    btn_cadastrar_pagamento.Click -= btn_cadastrar_pagamento_Click;
                    btn_cadastrar_pagamento.Click -= btn_alterar_pagamento_Click;
                    btn_cadastrar_pagamento.Click += btn_alterar_pagamento_Click;
                    break;
                case 3:
                    //Estilo Visualziar                    
                    renovarFormulario();                    
                    txt_observacao.Enabled = false;
                    txt_valor_troco.Enabled = false;
                    txt_valor_recebido.Enabled = false;
                    txt_valor_total_devido.Enabled = false;
                    cbx_meios_pagamento.Enabled = false;
                    cbx_atendimento.Enabled = false;
                    lbl_codigo_nomenclatura.Visible = true;
                    lbl_codigo_numero.Visible = true;
                    chkbx_pagamento_cancelado.Enabled = false;
                    btn_adicionar.Enabled = false;
                    btn_pesquisarAtendimento.Enabled = false;
                    rbtn_balancear_maisAntigo.Enabled = false;
                    btn_cadastrar_pagamento.Text = "Sair";
                    mensagem01 = "Deseja realmente Fechar?";
                    carregarDados_pagamentoAlvo();
                    btn_cadastrar_pagamento.Click -= btn_cadastrar_pagamento_Click;
                    btn_cadastrar_pagamento.Click -= btn_fechar_Click;
                    btn_cadastrar_pagamento.Click += btn_fechar_Click;
                    break;
            }
        }

        private void atualizarValorTotalDevido()
        {
            int qtdItems = 0;
            if (dt_atendimentosListados.Rows.Count >= 1)
            {
                Double total = 0, pago = 0;
                foreach (DataRow i in dt_atendimentosListados.Rows)
                {
                    try 
                    {                        
                        total += Convert.ToDouble(i["total"].ToString().Replace("R$",""));
                        pago += Convert.ToDouble(i["pago"].ToString().Replace("R$", ""));
                        qtdItems++;
                    }
                    catch 
                    {}
                }
                txt_valor_total_devido.Text = utilidades.captarValorMonetarioValido_paraExibicao((total-pago).ToString());
                txt_qtd_atendimentos.Text = qtdItems.ToString();
            }
        }

        private bool verificarCampos()
        {
            erros.Clear();
            bool existeErros = false;
            //se tem pelo menos um atendimento na lista pra pagar!
            if (Convert.ToInt32(dtg_resultados.Rows.Count) < 1)
            {               
                erros.SetError(dtg_resultados, "Selecione pelo menos um Antendimento!");                                    
                existeErros = true;                
            }
            else
            {
                //ok pelo menos selecionaram algum atendimento!
                foreach (DataGridViewRow i in dtg_resultados.Rows)
                {
                    try
                    {
                        Convert.ToDouble(i.Cells["fatia"].Value.ToString().Replace("R$", ""));
                        if (Convert.ToDouble(i.Cells["fatia"].Value.ToString().Replace("R$", ""))<=0)
                        {
                            erros.SetError(dtg_resultados, "Necessita o valor decada fatia de pagamento ser positivo, sem exceção!");
                            existeErros = true;
                        }
                    }
                    catch
                    {
                        erros.SetError(dtg_resultados, "Necessita calcular o valor da fatia de pagamento de cada pedido, sem exceção!");                                    
                        existeErros = true;
                    }
                }
            }          
           
            //campos!
            if (txt_valor_total_devido.Text.Equals("")) //se não tem valor total!
            {
                erros.SetError(txt_valor_total_devido, "Adicione algum Antendimento acima!");
                existeErros = true;
            }
            if (txt_valor_recebido.Text.Equals("")) //se não tem valor recebido!
            {
                erros.SetError(txt_valor_recebido, "Adicione o valor de pagamento!");
                existeErros = true;
            } 
            if (txt_valor_troco.Text.Equals("")) //se não tem valor de troco!
            {
                erros.SetError(txt_valor_troco, "Indique o troco voltado neste pagamento!");
                existeErros = true;
            }
            if (cbx_meios_pagamento.SelectedValue.Equals(String.Empty))
            {
                erros.SetError(cbx_meios_pagamento, "Selecione um meio de pagamento!");
                existeErros = true;
            }
            if (!rbtn_balancear_maisAntigo.Checked)
            {
                erros.SetError(rbtn_balancear_maisAntigo, "Balanceie o pagamento entre os atendimentos antes de prosseguir!");
                existeErros = true;
            }
            try
            {// testa se o troco lido é o mesmo do calculavel! senao houve mudaça no vlaor do atendimento e nao deve ser alterado este pagametno sem regularizar isso!
                if(utilidades.calcularTroco((Convert.ToDouble(txt_valor_recebido.Text)),(Convert.ToDouble(txt_valor_total_devido.Text)))!=(Convert.ToDouble(txt_valor_troco.Text)))
                {
                    erros.SetError(txt_valor_troco, "Valor do troco está errado, devido a uma mudança no valor total do atendimento!");
                    existeErros = true;
                }
               
            }
            catch
            {}
            return existeErros; 
        }
        
        private void renovarFormulario()
        {
            dt_atendimentos.Clear();
            dt_atendimentosListados.Clear();
            txt_valor_total_devido.Text = "";
            txt_observacao.Text="";
            txt_valor_recebido.Text="";
            txt_valor_troco.Text = "";             
       }        
        
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

        private void cadastrarNovoPagamento()
        {
            atualizarValorTotalDevido();
            if (MessageBox.Show(null, mensagem01 + "\nNo valor de R$" + txt_valor_recebido.Text, "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //existe campo a preencher!
                if (verificarCampos())
                {
                    //encontrou campos vazios!
                }
                else //tudo preenchido!
                {
                    Double devido = 0.0;

                    try
                    {
                        devido = Convert.ToDouble(txt_valor_total_devido.Text);
                    }
                    catch { }
                    if (devido > 0)
                    {
                        if (conexaoBD.abrirConexao())
                        {
                            //começa transação!
                            MySqlTransaction transacao = conexaoBD.getConexao().BeginTransaction();
                            try
                            {
                                pagamento pagamentoCadastrado = new pagamento();
                                //capto os dados do atendimento!
                                pagamento pagamentoNovo = new pagamento();
                                pagamentoNovo.setCod_atendente_fk(this.principal.getAtendente().getCod_atendente_pk());
                                pagamentoNovo.setCod_meio_pgto_fk(Convert.ToInt32(this.cbx_meios_pagamento.SelectedValue));
                                pagamentoNovo.setValor_pagamento(Convert.ToDouble(utilidades.captarValorMonetarioValido_paraExibicao(txt_valor_recebido.Text)));
                                pagamentoNovo.setObservacao_pagamento(((!txt_observacao.Text.Equals("Observações..."))) ? txt_observacao.Text : "");
                                pagamentoNovo.setTroco_pagamento(Convert.ToDouble(utilidades.captarValorMonetarioValido_paraExibicao(txt_valor_troco.Text)));
                                //se cadastrou com sucesso!
                                if (dados_pagamento.cadastrarUmPagamento(pagamentoNovo))
                                {
                                    //recebo os dados do pagamento cadastrado virtaulmetne no banco!
                                    pagamentoCadastrado = dados_pagamento.selecionarUltimoPagamento_acabouDeCadastrar();
                                    //linkando a cada fatia paga para os atendimentos!
                                    foreach (DataGridViewRow i in dtg_resultados.Rows)
                                    {
                                        pagamento_atendimento pagamento_atendimento = new pagamento_atendimento();
                                        String codAtend = (i.Cells[dados_atendimento.ATENDIMENTO_CODIGO].Value.ToString());
                                        pagamento_atendimento.setCod_atendimento_fk(Convert.ToInt32(codAtend));
                                        pagamento_atendimento.setCod_pagamento_fk(pagamentoCadastrado.getCod_pagamento_pk());
                                        pagamento_atendimento.setValor_fatia_pagamento(Convert.ToDouble(i.Cells["fatia"].Value.ToString().Replace("R$", "")));
                                        if (!(dados_pagamento_atendimento.cadastrarUmPagamento_atendimento(pagamento_atendimento))) //se deu errado solta erro!
                                        {
                                            transacao.Rollback();
                                            transacao.Dispose();
                                            MessageBox.Show(null, mensagem02, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            break;
                                        }
                                    }
                                    transacao.Commit();
                                    transacao.Dispose();
                                    MessageBox.Show(null, "Antendimento CÓD.:" + pagamentoCadastrado.getCod_pagamento_pk() + mensagem03, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    renovarFormulario();
                                    btn_fechar_Click(null, null);
                                }
                                else
                                {
                                    transacao.Rollback();
                                    transacao.Dispose();
                                    MessageBox.Show(null, mensagem02, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            catch (Exception erro)
                            {
                                transacao.Rollback();
                                MessageBox.Show(null, mensagem02 + "\n" + erro, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(null, mensagem06, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }       

        private void alterarNovoPagamento()
        {
            atualizarValorTotalDevido();
            if (MessageBox.Show(null, mensagem01 + "\nNo valor de R$" + txt_valor_recebido.Text, "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //existe campo a preencher!
                if (verificarCampos())
                {
                    //encontrou campos vazios!
                }
                else //tudo preenchido!
                {
                    //Verifico se tem valor devido pra fazer a alteração correta!
                    Double devido = 0.0;
                    try
                    {
                        devido = Convert.ToDouble(txt_valor_total_devido.Text);
                    }
                    catch { }
                    if (devido > 0)
                    {
                        if (conexaoBD.abrirConexao())
                        {
                            //começa transação!
                            MySqlTransaction transacao = conexaoBD.getConexao().BeginTransaction();
                            try
                            {
                                //altero os dados do atendimentoAlvo que foi lido!
                                pagamentoAlvo.setCod_atendente_fk(this.principal.getAtendente().getCod_atendente_pk());
                                pagamentoAlvo.setCod_meio_pgto_fk(Convert.ToInt32(this.cbx_meios_pagamento.SelectedValue));
                                pagamentoAlvo.setValor_pagamento(Convert.ToDouble(utilidades.captarValorMonetarioValido_paraExibicao(txt_valor_recebido.Text)));
                                pagamentoAlvo.setObservacao_pagamento(((!txt_observacao.Text.Equals("Observações..."))) ? txt_observacao.Text : "");
                                pagamentoAlvo.setTroco_pagamento(Convert.ToDouble(utilidades.captarValorMonetarioValido_paraExibicao(txt_valor_troco.Text)));
                                //se alterou com sucesso!
                                if (dados_pagamento.alterarUmPagamento(pagamentoAlvo))
                                {
                                    List<pagamento_atendimento> pagamento_atendimento_lista = new List<pagamento_atendimento>();
                                    //linkando a cada fatia paga para os atendimentos!
                                    foreach (DataGridViewRow i in dtg_resultados.Rows)
                                    {
                                        pagamento_atendimento pagamento_atendimento = new pagamento_atendimento();
                                        String codAtend = (i.Cells[dados_atendimento.ATENDIMENTO_CODIGO].Value.ToString());
                                        pagamento_atendimento.setCod_atendimento_fk(Convert.ToInt32(codAtend));
                                        pagamento_atendimento.setCod_pagamento_fk(pagamentoAlvo.getCod_pagamento_pk());
                                        pagamento_atendimento.setValor_fatia_pagamento(Convert.ToDouble(i.Cells["fatia"].Value.ToString().Replace("R$", "")));                                        
                                        //adiciono na lista
                                        pagamento_atendimento_lista.Add(pagamento_atendimento);
                                    }

                                    //listas de pagamento_atendimento alterados!
                                    List<pagamento_atendimento> pagamento_atendimento_alterados = new List<pagamento_atendimento>();
                                    //listas de pagamento_atendimento novos!
                                    List<pagamento_atendimento> pagamento_atendimento_novos = new List<pagamento_atendimento>();
                                    //listas de pagamento_atendimento inalterados!
                                    List<pagamento_atendimento> pagamento_atendimento_velhos = new List<pagamento_atendimento>();
                                
                                    //checando os pagamento_atendimento referentes ao pagamento!
                                    foreach (pagamento_atendimento i in pagamento_atendimento_lista)
                                    {
                                       //encontrou um com as mesmas referencias!
                                        if (dados_pagamento_atendimento.selecionarUmPagamento_atendimento_porCodigoPagamento_e_CodAtendimento(i).getCod_atendimento_fk() > 0)
                                        {
                                            pagamento_atendimento pagamento_atendimento_localizado = new pagamento_atendimento();
                                            //alem das referencias, encontrou um igual!
                                            if (dados_pagamento_atendimento.selecionarUmPagamento_atendimento_identico(i).getCod_atendimento_fk() > 0)
                                            {
                                                //igual, só capta com codigo_pk!
                                                pagamento_atendimento_localizado = dados_pagamento_atendimento.selecionarUmPagamento_atendimento_identico(i);
                                                pagamento_atendimento_velhos.Add(pagamento_atendimento_localizado);
                                            }
                                            else
                                            {
                                                //altero so o valor da fatia, de um captado com codigo_pk!
                                                pagamento_atendimento_localizado = dados_pagamento_atendimento.selecionarUmPagamento_atendimento_porCodigoPagamento_e_CodAtendimento(i);
                                                pagamento_atendimento_localizado.setValor_fatia_pagamento(i.getValor_fatia_pagamento());
                                                pagamento_atendimento_alterados.Add(pagamento_atendimento_localizado);
                                            }
                                        }
                                        else 
                                        {
                                            pagamento_atendimento_novos.Add(i);
                                        }
                                    }
                                    //capto todos codigos que vao permanecer no bd!
                                    List<pagamento_atendimento> pagamento_atendimento_permanecerao = new List<pagamento_atendimento>();
                                    foreach (pagamento_atendimento i in pagamento_atendimento_velhos)
                                    {
                                        pagamento_atendimento_permanecerao.Add(i);       
                                    }
                                    foreach (pagamento_atendimento i in pagamento_atendimento_alterados)
                                    {
                                        pagamento_atendimento_permanecerao.Add(i);
                                    }
                                    //capto referencia do id do pagamento que esta sendo alterado!
                                    pagamento_atendimento pagamento_atendimento_refPagamento = new pagamento_atendimento();
                                    pagamento_atendimento_refPagamento.setCod_pagamento_fk(this.pagamentoAlvo.getCod_pagamento_pk());
                                    dados_pagamento_atendimento.deletarPagamento_atendimento_porCodPagamento_e_excetoListaCodPagamento_atendimento(pagamento_atendimento_refPagamento, pagamento_atendimento_permanecerao);
                                    
                                    //altero os que precisam!
                                    foreach (pagamento_atendimento i in pagamento_atendimento_alterados)
                                    {
                                        dados_pagamento_atendimento.alterarUmPagamento_atendimento(i);
                                    }
                                    //novos cadastra-se!
                                    foreach (pagamento_atendimento i in pagamento_atendimento_novos)
                                    {
                                        dados_pagamento_atendimento.cadastrarUmPagamento_atendimento(i);
                                    }
                                    transacao.Commit();
                                    transacao.Dispose();
                                    MessageBox.Show(null, "Antendimento CÓD.:" + pagamentoAlvo.getCod_pagamento_pk() + mensagem03, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    renovarFormulario();
                                    utilidades.fecharEstaJanela_peloPaiDinamico(this);
                                }
                                else
                                {
                                    transacao.Rollback();
                                    transacao.Dispose();
                                    MessageBox.Show(null, mensagem02, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            catch (Exception erro)
                            {
                                transacao.Rollback();
                                MessageBox.Show(null, mensagem02 + "\n" + erro, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(null, mensagem06, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        #endregion

        #region AÇÕES DE BOTÕES
        private void btn_fechar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(null, mensagem04, "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    utilidades.fecharEstaJanela_peloPaiDinamico(this);
                }
            }
            catch { }
        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            atendimento at = new atendimento();
            if (Convert.ToInt32(cbx_atendimento.SelectedValue) > 0)
            {
                at.setCod_atendimento_pk(Convert.ToInt32(cbx_atendimento.SelectedValue));
                carregarAtendimentoNaTabela(at);
            }
        }

        private void btn_pesquisarAtendimento_Click(object sender, EventArgs e)
        {
            utilidades.carregar_telaCarregando(this, 3);
            Uc_atendimento_pesquisa pesq = new Uc_atendimento_pesquisa(principal, this);
            conteudos_dinamicos atendimentoArea = (conteudos_dinamicos)Parent.Parent;
            atendimentoArea.carregarConteudo_principal(pesq, true);
        }

        private void btn_cadastrar_pagamento_Click(object sender, EventArgs e)
        {
            cadastrarNovoPagamento();            
        }

        private void btn_alterar_pagamento_Click(object sender, EventArgs e)
        {
            alterarNovoPagamento();
        }
        #endregion
        
        #region Membros de uc_identificacao
        public string getTitulo()
        {
            uc_identificacao pai = (uc_identificacao)Parent.Parent;
            return pai.getTitulo();
        }
        public int getModoAtual()
        {
            return this.MODO;
        }
        public string getDescricao()
        {
            if (MODO == 2)
            {
                return "Alterar o Pagamento de Código: " + pagamentoAlvo.getCod_pagamento_pk();
            }
            if (MODO == 3)
            {
                return "Verificar um Pagamento Selecionado";
            }
            return "Cadastrar um novo Pagamento";
        }
        public Object getControleAbas()
        {
            return null;
        }
        #endregion

        #region Membros de requerimento_atendimento
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
