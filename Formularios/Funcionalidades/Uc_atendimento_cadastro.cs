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
    public partial class Uc_atendimento_cadastro : UserControl, uc_identificacao, requerimento_cliente, requerimento_responsavel
    {
        //MODO
        //1 = Cadastro, 2=Alteracão, 3=Leitura

        #region DADOS
        int MODO = 1; //padrao modo cadastro!
        frm_principal principal = null;
        //para o modo 2 e 3!
        atendimento atendimentoAlvo = null; 
        responsavel responsavelSelecionado = null;
        cliente clienteSelecionado = null;

        //dados
        dados_servico dados_servico = new dados_servico();
        dados_cliente dados_cliente = new dados_cliente();
        dados_pessoa_tipo dados_pessoa_tipo = new dados_pessoa_tipo();
        dados_responsavel_tipo dados_responsavel_tipo = new dados_responsavel_tipo();
        dados_responsavel dados_responsavel = new dados_responsavel();
        dados_atendimento dados_atendimento = new dados_atendimento();
        dados_item_atendimento dados_item_atendimento = new dados_item_atendimento();
    
        //mensagens
        String mensagem01 = "Deseja realmente Cadastrar esse Atendimento?";
        String mensagem02 = "Não foi possível Cadastrar!";
        String mensagem03 = " - Cadastrado com Sucesso!";
        String mensagem04 = "Deseja realmente fechar esta aba?";
        String mensagem05 = "Não foi selecionado um Cliente!";
        String mensagem06 = "Não foi selecionado um Responsável!";
        String mensagem07 = "Deseja realizar o pagamento deste pedido?";
        #endregion 

        #region inicializadores
        public Uc_atendimento_cadastro(frm_principal principal)
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

        public Uc_atendimento_cadastro(frm_principal principal, int modo, atendimento atendimentoAlvo)
        {
            //util em modo 2/3!
            this.principal = principal;
            this.atendimentoAlvo = atendimentoAlvo;
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
   
        #region Ações de Botões
        private void btn_pesquisarCliente_Click(object sender, EventArgs e)
        {
            utilidades.carregar_telaCarregando(this,1);
            Uc_cliente_pesquisa pesq = new Uc_cliente_pesquisa(principal, this);
            conteudos_dinamicos clienteArea = (conteudos_dinamicos)Parent.Parent;
            clienteArea.carregarConteudo_principal(pesq, true);
        }
        
        private void btn_pesquisarResponsavel_Click(object sender, EventArgs e)
        {
            utilidades.carregar_telaCarregando(this, 2);
            Uc_responsavel_pesquisa pesq = new Uc_responsavel_pesquisa(principal, this);
            conteudos_dinamicos clienteArea = (conteudos_dinamicos)Parent.Parent;
            clienteArea.carregarConteudo_principal(pesq, true);
        }

        private void btn_receberPreco_Click(object sender, EventArgs e)
        {
            try
            {
                //Capto Codigo do servico no proprio datatable do combobox que foi selecionado o serviço!
                DataTable dt_servicos = (DataTable)cbx_servico.DataSource;
                DataRow[] dr = dt_servicos.Select(dados_servico.SERVICO_CODIGO + " = " + cbx_servico.SelectedValue.ToString());
                servico servico = new servico();
                servico.setCod_tab_servico_pk(Convert.ToInt32(dr[0][dados_servico.SERVICO_CODIGO].ToString()));
                //Busco pelo valor atualizado do serviço!
                servico = dados_servico.selecionarUmServico_porCodigo(servico);
                //Exibindo resultados!
                txt_descricao_servico.Text = servico.getDescricao_servico();
                txt_valor_servico.Text = utilidades.captarValorMonetarioValido_paraExibicao(servico.getValor_servico().ToString());
            }
            catch
            {
                txt_valor_servico.Text = "";
            }
        }


        private void btn_alterarValor_Click(object sender, EventArgs e)
        {
            String backup = txt_valor_servico.Text;
            try
            {
                //tenta alterar se não retornar vazio, ou seja se for valido!
                if (!(utilidades.captarValorMonetarioValido_paraExibicao(txt_descontado.Text).Equals(String.Empty)))
                {
                    if (Convert.ToDouble(utilidades.captarValorMonetarioValido_paraExibicao((Convert.ToDouble(utilidades.captarValorMonetarioValido_paraExibicao(txt_valor_servico.Text)) - Convert.ToDouble(utilidades.captarValorMonetarioValido_paraExibicao(txt_descontado.Text))).ToString())) < 0)
                    {
                        txt_valor_servico.Text = utilidades.captarValorMonetarioValido_paraExibicao("0,00");
                    }
                    else
                    {
                        txt_valor_servico.Text = utilidades.captarValorMonetarioValido_paraExibicao((Convert.ToDouble(utilidades.captarValorMonetarioValido_paraExibicao(txt_valor_servico.Text)) - Convert.ToDouble(utilidades.captarValorMonetarioValido_paraExibicao(txt_descontado.Text))).ToString());
                    }
                }
            }
            catch 
            {                
                txt_valor_servico.Text = backup;
            }
            txt_descontado.Text = "";
        }

        private void btn_adicionarServico_Click(object sender, EventArgs e)
        {
            //adiciona serviço prestado se as informações forem validas!
           if ((Convert.ToInt32(cbx_servico.SelectedValue)<1)||(txt_valor_servico.Text.Equals("")))
            {
                //Valor vazio, faça nada!
            }
            else 
            {
                //coleto todas informações
                item_atendimento item_atendimento = new item_atendimento();
                item_atendimento.setCod_atendente_fk(principal.getAtendente().getCod_atendente_pk());
                item_atendimento.setCod_servico_fk(Convert.ToInt32(cbx_servico.SelectedValue));
                item_atendimento.setDetalhe_item_atendimento(Convert.ToString(txt_descricao_servico.Text));
                item_atendimento.setValor_combinado_item_atendimento(Convert.ToDouble(txt_valor_servico.Text));
                Uc_lista_item_atendimento novoItem_atendimento = new Uc_lista_item_atendimento(item_atendimento);
               //adiciono na lista de servicos prestados!
                this.pnl_servicos_prestados.Controls.Add(novoItem_atendimento);
            }
        }     
        
        private void btn_alterar_atendimento_Click(object sender, EventArgs e)        
        {
            alterar_atendimento();      
        }

        private void btn_cadastrar_atendimento_Click(object sender, EventArgs e)
        {
            cadastrar_atendimento();
        }

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

        private void txt_valor_total_Click(object sender, EventArgs e)
        {
            atualizarValorTotal();
        }

        private void pnl_servicos_prestados_MouseLeave(object sender, EventArgs e)
        {
            atualizarValorTotal();
        }
        #endregion

        #region Rotinas de componentes
        private void Uc_responsavel_cadastro_Load(object sender, EventArgs e)
        {
            carregarServicos();
            carregarModo();
            #region coloracao componentes
            btn_receberPreco.BackColor = Properties.Settings.Default.botoes_001;
            btn_alterarValor.BackColor = Properties.Settings.Default.botoes_001;
            btn_adicionarServico.BackColor = Properties.Settings.Default.botoes_001;
            btn_cadastrar_atendimento.BackColor = Properties.Settings.Default.botoes_002;            
            btn_fechar.BackColor = Properties.Settings.Default.botoes_002;
            lbl_fechar.ForeColor = Properties.Settings.Default.botoes_002;
            cbx_cliente.BackColor = Properties.Settings.Default.campos_001;
            cbx_responsavel.BackColor = Properties.Settings.Default.campos_001;
            cbx_servico.BackColor = Properties.Settings.Default.campos_001;
            txt_descricao_servico.BackColor = Properties.Settings.Default.campos_001;
            txt_descontado.BackColor = Properties.Settings.Default.campos_001;
            txt_valor_servico.BackColor = Properties.Settings.Default.campos_001;
            txt_observacao.BackColor = Properties.Settings.Default.campos_001;
            #endregion
        }
        private void chkbx_ativarCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_ativarCliente.Checked)
            {
                btn_pesquisarCliente.Enabled = true;
                btn_pesquisarCliente.BackColor = Color.Green;
                btn_pesquisarCliente.Focus();
            }
            else
            {
                btn_pesquisarCliente.Enabled = false;
                cbx_cliente.DataSource = null;
                btn_pesquisarCliente.BackColor = Color.Gray;
            }
        }
       
        private void txt_observacao_TextChanged(object sender, EventArgs e)
        {
            utilidades.colocarTexto_observacoes(txt_observacao);
        }
        private void txt_observacao_Validated(object sender, EventArgs e)
        {
            utilidades.colocarTexto_observacoes(txt_observacao);
        }
        private void txt_observacao_Leave(object sender, EventArgs e)
        {
            utilidades.colocarTexto_observacoes(txt_observacao);
        }

        private void txt_observacao_Enter(object sender, EventArgs e)
        {
            utilidades.colocarTexto_observacoes(txt_observacao);
        }

        private void cbx_responsavel_Validated(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cbx_responsavel.SelectedValue) <= 0)
                {
                    chkbx_ativarResponsavel.Checked = false;
                }
            }
            catch { }
        }
        private void cbx_cliente_Validated(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cbx_cliente.SelectedValue) <= 0)
                {
                    chkbx_ativarCliente.Checked = false;
                }
            }
            catch { }
        }
        private void chkbx_ativarResponsavel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_ativarResponsavel.Checked)
            {
                btn_pesquisarResponsavel.Enabled = true;
                btn_pesquisarResponsavel.BackColor = Color.Green;
                btn_pesquisarResponsavel.Focus();
            }
            else
            {
                btn_pesquisarResponsavel.Enabled = false;
                cbx_responsavel.DataSource = null;
                btn_pesquisarResponsavel.BackColor = Color.Gray;
            }
        }
        private void cbx_servico_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //Capto o valor e a descricao do servico no proprio datatable do combobox que foi selecionado o serviço!
                DataTable dt_servicos = (DataTable)cbx_servico.DataSource;
                //Expressão de seleção por codigo!
                DataRow[] dr = dt_servicos.Select(dados_servico.SERVICO_CODIGO + " = " + cbx_servico.SelectedValue.ToString());
                //Capto a descicao do resultado!
                this.txt_descricao_servico.Text = dr[0][dados_servico.SERVICO_DESCRICAO].ToString();
                //Capto o valor do resultado!
                this.txt_valor_servico.Text = utilidades.captarValorMonetarioValido_paraExibicao(dr[0][dados_servico.SERVICO_VALOR].ToString());
            }
            catch
            {
                //limpo os textos quando mudar o serviço, a fim de não confundir!
                txt_valor_servico.Text = "";
                txt_descricao_servico.Text = "";
            }
        }
        private void pnl_servicos_prestados_ControlAdded(object sender, ControlEventArgs e)
        {
            atualizarValorTotal();
        }
        private void pnl_servicos_prestados_ControlRemoved(object sender, ControlEventArgs e)
        {
            atualizarValorTotal();
        }
        
        #endregion

        #region Funções
        private void atualizarValorTotal()
        {
            int qtdItems = 0;
            if (pnl_servicos_prestados.Controls.Count >= 1)
            {                
                Double total = 0;
                foreach (Control i in pnl_servicos_prestados.Controls)
                {
                    try 
                    {
                        Uc_lista_item_atendimento item = (Uc_lista_item_atendimento)i;
                        total += item.getItem_atendimento_atual().getValor_combinado_item_atendimento();
                    }
                    catch 
                    {}
                    qtdItems++;
                }
                txt_valor_total.Text = utilidades.captarValorMonetarioValido_paraExibicao(total.ToString());
            }
            txt_qtd_items_adicionados.Text = qtdItems.ToString();
        }

        private bool verificarCampos()
        {
            erros.Clear();
            bool existeErros = false;
            if (Convert.ToInt32(cbx_cliente.SelectedValue) < 1) //se cliente nao foi selecionado!
            {
                if (Convert.ToInt32(cbx_responsavel.SelectedValue) < 1)//se responsavel tbm nao foi selecionado!
                {
                    erros.SetError(chkbx_ativarCliente, "Selecione pelo menos um Cliente OU Responsável!");
                    erros.SetError(chkbx_ativarResponsavel, "Selecione pelo menos um Cliente OU Responsável!");                    
                    existeErros = true;
                }
                else 
                { 
                    //ok pelo menos selecionaram um responsavel!
                }
            }
            else
            {
                //ok pelo menos selecionaram o cliente!
            }          
           
            //lista de servicos prestados!
            if (pnl_servicos_prestados.Controls.Count < 1) //se tem nenhum na lista!
            {
                erros.SetError(pnl_servicos_prestados, "Obrigatório ter pelo menos um item na lista!");
                existeErros = true;
            }
            if (Convert.ToDouble(utilidades.captarValorMonetarioValido_paraExibicao(txt_valor_total.Text)) <= 0)
            {
                erros.SetError(txt_valor_total, "O Total deste atendimento deve ser positivo!");
                existeErros = true; 
            }
            return existeErros; 
        }
        
        private void renovarFormulario()
        {
            //limpar os campos do form!
            pnl_servicos_prestados.Controls.Clear();
            txt_observacao.Text = "";
            chkbx_ativarCliente.Checked=false;
            chkbx_ativarResponsavel.Checked=false;
            chkbx_totalmenteFinalizado.Checked = false;
            chkbx_totalmentePago.Checked = false;
            txt_valor_servico.Text = "";
            txt_descricao_servico.Text = "";
            txt_descontado.Text = "";
            txt_valor_total.Text = "";
        }

        private void cadastrar_atendimento()
        {
            atualizarValorTotal();
            if (MessageBox.Show(null, mensagem01 + "\nNo valor de R$" + utilidades.captarValorMonetarioValido_paraExibicao(txt_valor_total.Text), "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //existe campo a preencher!
                if (verificarCampos())
                {
                    //encontrou campos vazios!
                }
                else //tudo preenchido!
                {
                    if (conexaoBD.abrirConexao())
                    {
                        //começa transação!
                        MySqlTransaction transacao = conexaoBD.getConexao().BeginTransaction();
                        try
                        {
                            //capto os dados do atendimento!
                            atendimento atendimentoNovo = new atendimento();
                            atendimentoNovo.setCod_atendente_fk(this.principal.getAtendente().getCod_atendente_pk());
                            atendimentoNovo.setCod_cliente_fk(Convert.ToInt32(this.cbx_cliente.SelectedValue));
                            atendimentoNovo.setCod_responsavel_fk(Convert.ToInt32(this.cbx_responsavel.SelectedValue));
                            atendimentoNovo.setEstado_finalizado_atendimento((chkbx_totalmenteFinalizado.Checked == true) ? 's' : 'n');
                            atendimentoNovo.setEstado_pago_atendimento((chkbx_totalmentePago.Checked == true) ? 's' : 'n');
                            atendimentoNovo.setObservacao_atendimento(((!txt_observacao.Text.Equals("Observações..."))) ? txt_observacao.Text : "");
                            if (dados_atendimento.cadastrarUmAtendimento(atendimentoNovo)) //se cadastrou com sucesso!
                            {
                                //recebo os dados do atendimento recem cadastrado virtaulmetne no banco!
                                atendimentoNovo = dados_atendimento.selecionarUltimoAtendimento_acabouDeCadastrar();
                                foreach (Uc_lista_item_atendimento i in pnl_servicos_prestados.Controls) //cadstrando cada item!
                                {
                                    //novo item_atendimento!
                                    item_atendimento item_atendimentoNovo = new item_atendimento();
                                    item_atendimentoNovo = i.getItem_atendimento_atual();
                                    //seto o que falta nele!
                                    item_atendimentoNovo.setCod_atendente_fk(this.principal.getAtendente().getCod_atendente_pk());
                                    item_atendimentoNovo.setCod_atendimento_fk(atendimentoNovo.getCod_atendimento_pk());
                                    if (!(dados_item_atendimento.cadastrarUmItem_atendimento(item_atendimentoNovo))) //se deu errado solta erro!
                                    {
                                        transacao.Rollback();
                                        transacao.Dispose();
                                        MessageBox.Show(null, mensagem02, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    }
                                }
                                transacao.Commit();
                                transacao.Dispose();
                                MessageBox.Show(null, "Antendimento CÓD.:" + atendimentoNovo.getCod_atendimento_pk() + mensagem03, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                renovarFormulario();
                                if (MessageBox.Show(null, mensagem07, "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                {
                                    Uc_pagamento_cadastro pesq = new Uc_pagamento_cadastro(principal);
                                    conteudos_dinamicos atendimentoArea = (conteudos_dinamicos)Parent.Parent;
                                    atendimentoArea.carregarConteudo_principal(pesq, false);
                                    this.Refresh();
                                    pesq.atendimentoEscolhido(atendimentoNovo);
                                    pesq.sinalizarEscolha_atendimento(true);
                                }
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
                            try
                            {
                                transacao.Rollback();
                            }
                            catch { }
                            MessageBox.Show(null, mensagem02 + "\n" + erro, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void alterar_atendimento() 
        {
            //listas de items alterados!
            List<item_atendimento> alteradosItems = new List<item_atendimento>();
            //listas de items  inalterados!
            List<item_atendimento> velhosItems = new List<item_atendimento>();
            //listas de items  novos!
            List<item_atendimento> novosItems = new List<item_atendimento>();
            //listas de items  movimentados na transacao!
            List<item_atendimento> estaveisItems = new List<item_atendimento>();

            atualizarValorTotal();
            if (MessageBox.Show(null, mensagem01 + "\nNo valor de R$" + utilidades.captarValorMonetarioValido_paraExibicao(txt_valor_total.Text), "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //existe campo a preencher!
                if (verificarCampos())
                {
                    //encontrou campos vazios!
                }
                else //tudo preenchido!
                {
                    if (conexaoBD.abrirConexao())
                    {
                        //começa transação!
                        MySqlTransaction transacao = conexaoBD.getConexao().BeginTransaction();
                        try
                        {
                            //capto os dados do atendimento!
                            atendimento atendimentoNovo = new atendimento();
                            //idAntigo
                            atendimentoNovo.setCod_atendimento_pk(atendimentoAlvo.getCod_atendimento_pk());
                            //dados
                            atendimentoNovo.setCod_atendente_fk(this.principal.getAtendente().getCod_atendente_pk());
                            atendimentoNovo.setCod_cliente_fk(Convert.ToInt32(this.cbx_cliente.SelectedValue));
                            atendimentoNovo.setCod_responsavel_fk(Convert.ToInt32(this.cbx_responsavel.SelectedValue));
                            atendimentoNovo.setEstado_finalizado_atendimento((chkbx_totalmenteFinalizado.Checked) ? 's' : 'n');
                            atendimentoNovo.setEstado_pago_atendimento((chkbx_totalmentePago.Checked) ? 's' : 'n');
                            atendimentoNovo.setObservacao_atendimento(txt_observacao.Text);
                            //altero o pedido usando o mesmo id do atendimentoAlvo! 
                            if (dados_atendimento.alterarUmAtendimento(atendimentoNovo))
                            {
                                foreach (Uc_lista_item_atendimento i in pnl_servicos_prestados.Controls) //passo por cada item!
                                {
                                    //recebo o item_atendimento que tiver na lista!
                                    item_atendimento item_atendimento = new item_atendimento();
                                    item_atendimento = i.getItem_atendimento_atual();
                                    if (i.situacao() == 1)//se nunca foi alterado!
                                    {
                                        item_atendimento.setCod_atendente_fk(this.principal.getAtendente().getCod_atendente_pk());
                                        //adiciono na lista de velhos inalterados!
                                        velhosItems.Add(item_atendimento);
                                    }
                                    else if (i.situacao() == 2)//se já foi alterado!
                                    {
                                        item_atendimento.setCod_atendente_fk(this.principal.getAtendente().getCod_atendente_pk());
                                        //adiciono na lista dos que precisam alterar!
                                        alteradosItems.Add(item_atendimento);
                                    }
                                    else //são novos, vamos cadastrar!
                                    {
                                        //recebe os dados de referencia que não tinham 
                                        item_atendimento.setCod_atendente_fk(this.principal.getAtendente().getCod_atendente_pk());
                                        item_atendimento.setCod_atendimento_fk(atendimentoAlvo.getCod_atendimento_pk());
                                        //adiciono na lista dos novos!
                                        novosItems.Add(item_atendimento);
                                    }
                                }
                                //Alteracao / Cadastro - Items ***********************************
                                for (int cont = 0; cont < novosItems.Count; cont++)//Passo por cada novo a cadastrar! 3
                                {
                                    if (dados_item_atendimento.cadastrarUmItem_atendimento(novosItems[cont])) //cadastro!
                                    {
                                        //recebo o id do recem cadastrado!
                                        item_atendimento itemRecem = dados_item_atendimento.selecionarUltimoItem_atendimento_acabouDeCadastrar();
                                        estaveisItems.Add(itemRecem);
                                    }
                                    else
                                    {
                                        transacao.Rollback();
                                        transacao.Dispose();
                                        MessageBox.Show(null, mensagem02, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    }
                                }
                                for (int cont = 0; cont < alteradosItems.Count; cont++)//Passo por cada novo a alterar! 2
                                {
                                    if (dados_item_atendimento.alterarUmItem_atendimento(alteradosItems[cont])) //altero!
                                    {
                                        //adiciono na lista de estaveis!
                                        estaveisItems.Add(alteradosItems[cont]);
                                    }
                                    else
                                    {
                                        transacao.Rollback();
                                        transacao.Dispose();
                                        MessageBox.Show(null, mensagem02, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    }
                                }
                                for (int cont = 0; cont < velhosItems.Count; cont++)//Passo por cada velho coletando na lista de estaveis! 1
                                {
                                    //adiciono na lista de estaveis!
                                    estaveisItems.Add(velhosItems[cont]);
                                }
                                //Remove os items não listados nos estaveis!
                                dados_item_atendimento.deletarTodosItems_atendimento_excetoIds(estaveisItems);
                                //Sucesso!
                                transacao.Commit();
                                transacao.Dispose();
                                MessageBox.Show(null, "Atendimento " + atendimentoAlvo.getCod_atendimento_pk().ToString() + mensagem03, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btn_fechar_Click(null, null);
                                renovarFormulario();
                                carregarModo();
                            }
                            else
                            {
                                transacao.Rollback();
                                transacao.Dispose();
                                MessageBox.Show(null, mensagem02, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch
                        {
                            transacao.Rollback();
                            transacao.Dispose();
                            MessageBox.Show(null, mensagem02, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            } 
        }

        private void carregarDadosClienteResponsavelSelecionados()
        {
            //seleciono o cliente
            if (this.atendimentoAlvo.getCod_cliente_fk() > 0)
            {
                cliente cliente = new cliente();
                cliente.setCod_cliente_pk(this.atendimentoAlvo.getCod_cliente_fk());
                clienteEscolhido(dados_cliente.selecionarUmCliente_porCodigo(cliente));
                if (clienteSelecionado == null)
                {
                    sinalizarEscolha_cliente(false);
                }

            }
            //selciono o resposnavel
            if (this.atendimentoAlvo.getCod_responsavel_fk() > 0)
            {
                responsavel responsavel = new responsavel();
                responsavel.setCod_responsavel_pk(this.atendimentoAlvo.getCod_responsavel_fk());
                responsavelEscolhido(dados_responsavel.selecionarUmResponsavel_porCodigo(responsavel));
                if (responsavelSelecionado == null)
                {
                    sinalizarEscolha_responsavel(false);
                }
            }
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
                    renovarFormulario();
                    this.btn_cadastrar_atendimento.Text = "Alterar";
                    mensagem01 = "Deseja realmente Alterar esse Atendimento?";
                    mensagem02 = "Não foi possível Alterar!";
                    mensagem03 = " - Alterado com Sucesso!";
                    carregarServicos();
                    carregarDados_atendimento();
                    lbl_codigo_numero.Visible = true;
                    lbl_codigo_nomenclatura.Visible = true;
                    btn_cadastrar_atendimento.Click -= btn_cadastrar_atendimento_Click;
                    btn_cadastrar_atendimento.Click -= btn_alterar_atendimento_Click;
                    btn_cadastrar_atendimento.Click += btn_alterar_atendimento_Click;
                    break;
                case 3:
                    //Estilo Visualziar
                    renovarFormulario();
                    gbx_obs.Enabled = false;
                    btn_adicionarServico.Enabled=false;
                    btn_alterarValor.Enabled=false;
                    txt_descontado.Enabled=false;
                    chkbx_totalmentePago.Enabled=false;
                    chkbx_totalmenteFinalizado.Enabled=false;
                    chkbx_ativarResponsavel.Enabled = false;
                    btn_pesquisarCliente.Enabled = false;
                    btn_pesquisarResponsavel.Enabled = false;
                    lbl_codigo_numero.Visible = true;
                    lbl_codigo_nomenclatura.Visible = true;
                    chkbx_ativarCliente.Enabled = false;
                    btn_cadastrar_atendimento.Text = "Sair";
                    mensagem01 = "Deseja realmente Fechar?";
                    btn_cadastrar_atendimento.Click -= btn_cadastrar_atendimento_Click;
                    btn_cadastrar_atendimento.Click -= btn_fechar_Click;
                    btn_cadastrar_atendimento.Click += btn_fechar_Click;
                    carregarServicos();
                    carregarDados_atendimento();  
                    foreach (Uc_lista_item_atendimento i in pnl_servicos_prestados.Controls)
                    {
                        i.travarExclusao();
                    }
                    break;
            }
        }

        public void carregarDados_atendimento()
        {
           if (conexaoBD.abrirConexao())
            {
                txt_observacao.Text = this.atendimentoAlvo.getObservacao_atendimento();

                if (this.atendimentoAlvo.getEstado_pago_atendimento() == 's')
                {
                    chkbx_totalmentePago.Checked = true;
                }
                if (this.atendimentoAlvo.getEstado_finalizado_atendimento() == 's')
                {
                    chkbx_totalmenteFinalizado.Checked = true;
                }

                //método utilizável caso modo 2/3
                if (atendimentoAlvo != null)
                {
                    atendimentoAlvo = dados_atendimento.selecionarUmAtendimento_porCodigo(this.atendimentoAlvo);
                    item_atendimento item_atendimentoNovo = new item_atendimento();
                    item_atendimentoNovo.setCod_atendimento_fk(this.atendimentoAlvo.getCod_atendimento_pk());
                    //carregando os item_atendimentos na lista
                    List<item_atendimento> items_atendimento = dados_item_atendimento.selecionarTodosItem_atendimento_porCodigoAtendimento(item_atendimentoNovo);
                    int cont = 0;
                    for (cont = 0; cont < items_atendimento.Count; cont++)
                    {
                        //novo item da lista!
                        Uc_lista_item_atendimento novoItem_atendimento = new Uc_lista_item_atendimento(items_atendimento[cont]);
                        this.pnl_servicos_prestados.Controls.Add(novoItem_atendimento);
                    }
                    try
                    {
                        cliente cliente = new cliente();
                        cliente.setCod_cliente_pk(atendimentoAlvo.getCod_cliente_fk());
                        clienteEscolhido(dados_cliente.selecionarUmCliente_porCodigo(cliente));
                        carregarClienteSelecionado();
                    }
                    catch { }
                    try
                    {
                        responsavel responsavel = new responsavel();
                        responsavel.setCod_responsavel_pk(atendimentoAlvo.getCod_responsavel_fk());
                        responsavelEscolhido(dados_responsavel.selecionarUmResponsavel_porCodigo(responsavel));
                        carregarResponsavelSelecionado();
                    }
                    catch
                    {

                    }
                    if (atendimentoAlvo.getEstado_finalizado_atendimento() == 's')
                    {
                        chkbx_totalmenteFinalizado.Checked = true;
                    } 
                    if (atendimentoAlvo.getEstado_pago_atendimento() == 's')
                    {
                        chkbx_totalmentePago.Checked = true;
                    }
                    lbl_codigo_numero.Text = atendimentoAlvo.getCod_atendimento_pk().ToString();
                }
                carregarDadosClienteResponsavelSelecionados();
            }
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
                cbx_servico.DataSource = dt_servicos;
                List<servico> listaServicos = dados_servico.selecionarTodosServicos_ativos();

                int cont=0;
                for (cont = 0; cont < listaServicos.Count;cont++ )
                {
                    dt_servicos.Rows.Add(listaServicos[cont].getCod_tab_servico_pk(),
                        listaServicos[cont].getNome_servico(),
                        listaServicos[cont].getValor_servico(),
                        listaServicos[cont].getDescricao_servico()
                        );
                }
                cbx_servico.DisplayMember = dados_servico.SERVICO_NOME;
                cbx_servico.ValueMember = dados_servico.SERVICO_CODIGO;
            }
        }

        private void carregarClienteSelecionado()
        {
            //Métodos de carregar dados quando é selecionado um cliente na janela de pesquisa!
             if (conexaoBD.abrirConexao())
            {
                //completa o combobox de cliente!                
                DataTable dt_clienteSelecionado = new DataTable();
                dt_clienteSelecionado.Columns.Add(dados_cliente.CLIENTE_CODIGO, typeof(int));
                dt_clienteSelecionado.Columns.Add(dados_cliente.CLIENTE_NOME, typeof(string));                
                cbx_cliente.DataSource = dt_clienteSelecionado;
                
                this.clienteSelecionado = dados_cliente.selecionarUmCliente_porCodigo(this.clienteSelecionado);

                tipo_pessoa pessoa = new tipo_pessoa();
                pessoa.setCod_tipo_pessoa_pk(this.clienteSelecionado.getCod_tipo_pessoa_fk());
                
                dt_clienteSelecionado.Rows.Add(this.clienteSelecionado.getCod_cliente_pk(),
                    "CÓD.:"+this.clienteSelecionado.getCod_cliente_pk()+": "+
                    this.clienteSelecionado.getNome_cliente()+" - "+
                    this.clienteSelecionado.getApelido_cliente()+" - "+
                    utilidades.captarCnpjCpfMascarado_confomeTipoPessoa(this.clienteSelecionado.getCod_tipo_pessoa_fk(), this.clienteSelecionado.getCpfCnpj_cliente()) + " - " +
                    dados_pessoa_tipo.selecionarTipo_porCodigo(pessoa).getNome_tipo_pessoa() + "."
                    );
                cbx_cliente.DisplayMember = dados_cliente.CLIENTE_NOME;
                cbx_cliente.ValueMember = dados_cliente.CLIENTE_CODIGO;
             }
             if (Convert.ToInt32(cbx_cliente.SelectedValue) <= 0)
             {
                 chkbx_ativarCliente.Checked = false;
                 chkbx_ativarCliente_CheckedChanged(null, null);
             }
             else
             {
                 chkbx_ativarCliente.Checked = true;
                 chkbx_ativarCliente_CheckedChanged(null, null);
             }
        }

        private void carregarResponsavelSelecionado()
        {
            //usando quando é selecionado um Responsavel na janela de pesquisa!
            if (conexaoBD.abrirConexao())
            {
                //completa o combobox de cliente!                
                DataTable dt_responsavelSelecionado = new DataTable();
                dt_responsavelSelecionado.Columns.Add(dados_responsavel.RESPONSAVEL_CODIGO, typeof(int));
                dt_responsavelSelecionado.Columns.Add(dados_responsavel.RESPONSAVEL_NOME, typeof(string));
                cbx_responsavel.DataSource = dt_responsavelSelecionado;
                
                this.responsavelSelecionado = dados_responsavel.selecionarUmResponsavel_porCodigo(this.responsavelSelecionado);

                tipo_pessoa pessoa_tipo = new tipo_pessoa();
                pessoa_tipo.setCod_tipo_pessoa_pk(this.responsavelSelecionado.getCod_tipo_pessoa_fk());
                tipo_responsavel responsavel_tipo = new tipo_responsavel();
                responsavel_tipo.setCod_tipo_responsavel_pk(this.responsavelSelecionado.getCod_tipo_responsavel_responsavel_fk());
                responsavel_tipo = dados_responsavel_tipo.selecionarUmTipo_porCodigo(responsavel_tipo);

                dt_responsavelSelecionado.Rows.Add(
                    this.responsavelSelecionado.getCod_responsavel_pk(),
                    "CÓD.:" + this.responsavelSelecionado.getCod_responsavel_pk() + ": " +
                    this.responsavelSelecionado.getNome_responsavel() + " : " +
                    this.responsavelSelecionado.getApelido_responsavel() + " - " +
                    utilidades.captarCnpjCpfMascarado_confomeTipoPessoa(this.responsavelSelecionado.getCod_tipo_pessoa_fk(), this.responsavelSelecionado.getCpfCnpj_responsavel()) + " - " +
                    dados_pessoa_tipo.selecionarTipo_porCodigo(pessoa_tipo).getNome_tipo_pessoa() + " - "+
                    responsavel_tipo.getNome_tipo_responsavel() + "."
                    );
                cbx_responsavel.DisplayMember = dados_responsavel.RESPONSAVEL_NOME;
                cbx_responsavel.ValueMember = dados_responsavel.RESPONSAVEL_CODIGO;
            }
            if (Convert.ToInt32(cbx_responsavel.SelectedValue) <= 0)
            {
                chkbx_ativarResponsavel.Checked = false;
                chkbx_ativarResponsavel_CheckedChanged(null, null);
            }
            else
            {
                chkbx_ativarResponsavel.Checked = true;
                chkbx_ativarResponsavel_CheckedChanged(null, null);
            }
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
                return "Alterar o Atendimento de Código: "+atendimentoAlvo.getCod_atendimento_pk();
            }
            if (MODO == 3)
            {
                return "Verificar um Atendimento Selecionado";
            }
            return "Cadastrar um novo Atendimento";
        }
        public Object getControleAbas()
        {
            return null;
        }
        #endregion        

        #region Membros de requerimento_responsavel
        public void responsavelEscolhido(responsavel responsavel)
        {
            this.responsavelSelecionado = responsavel;
        }

        public void sinalizarEscolha_responsavel(bool escolhido)
        {
            utilidades.remover_telaCarregando(this);
            if (escolhido)
            {
                carregarResponsavelSelecionado();
            }
            else
            {
                MessageBox.Show(mensagem06);
            }
        }

        #endregion

        #region Membros de requerimento_cliente
        public void clienteEscolhido(cliente cliente)
        {
            this.clienteSelecionado = cliente;
        }
        public void sinalizarEscolha_cliente(bool escolhido)
        {
            utilidades.remover_telaCarregando(this);
            if (escolhido)
            {
                carregarClienteSelecionado();
            }
            else
            {
                MessageBox.Show(mensagem05);
            }
        }
        #endregion                                            
        
    }
}