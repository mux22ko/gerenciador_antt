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
    public partial class Uc_atendimento_pesquisa : UserControl, uc_identificacao, requerimento_cliente, requerimento_responsavel
    {
        /*MODO
            1 = Pesquisa,leitura,alteracao; 2=Seleção;
        */

        #region DADOS
        //Padrao modo: 1 !
        int MODO = 1; 

        //Referencia ao principal!
        frm_principal principal = null;

        //Uso provindo de seleção dos cbxs!
        responsavel responsavelSelecionado = new responsavel();
        cliente clienteSelecionado = new cliente();

        //Dados
        dados_atendimento dados_atendimento = new dados_atendimento();
        dados_cliente dados_cliente = new dados_cliente();
        dados_responsavel dados_responsavel = new dados_responsavel();
        dados_servico dados_servico = new dados_servico();
        dados_item_atendimento dados_item_atendimento = new dados_item_atendimento();
        dados_pagamento_atendimento dados_pagamento_atendimento = new dados_pagamento_atendimento();
        dados_pessoa_tipo dados_pessoa_tipo = new dados_pessoa_tipo();
        dados_responsavel_tipo dados_responsavel_tipo = new dados_responsavel_tipo();

        //Provê serviço requesição de enviar um atendimento selecionado!
        requerimento_atendimento origemRequisitandoAtendimento = null;         

        //Mensagens padroes!
        String mensagem01 = "Deseja Ver os dados do Atendimento: COD.: ";
        String mensagem02 = "Deseja Alterar os dados do Antendimento: ";
        String mensagem03 = "Deseja realmente fechar esta aba?";
        String mensagem04 = "Deseja realmente escolher este cliente?";
        String mensagem05 = "Não foi selecionado um Cliente!";
        String mensagem06 = "Não foi selecionado um Responsável!";
        String mensagem07 = "Esteja logado para acessar esta área!";
        String mensagem08 = "Não foram econtrados resultados!";
        String mensagem09 = "Não foi possível efetuar a pesquisa!";
        
        //tables
        DataTable dt_resultadosAtendimentos = new DataTable();
        DataTable dt_servicos = new DataTable();
        #endregion

        #region INICIALIZADORES
        public Uc_atendimento_pesquisa(frm_principal principal) //util para modo 1!
        {
            //Padrao modo: 1 !
            this.MODO = 1;

            //Recebe a referencia ao principal!
            this.principal = principal;

            //Trava anti-acesso nao autorizado!     
            if (principal.getAtendente() != null)
            {
                InitializeComponent();
                carregarModo();
            }
            else
            {
                MessageBox.Show(mensagem07);
            }
        }

        public Uc_atendimento_pesquisa(frm_principal principal, object origemRequisitando)//util para modo 2!
        {
            //Modo: 2 !
            this.MODO = 2;

            //Recebe a referencia ao principal!
            this.principal = principal;

            //Recebe a referencia que está requisitando um Atendimento!
            this.origemRequisitandoAtendimento = (requerimento_atendimento)origemRequisitando;
            
            //Trava anti-acesso nao autorizado! 
            if (principal.getAtendente() != null)
            {
                InitializeComponent();
                carregarModo();
            }
            else
            {
                MessageBox.Show(mensagem07);
            }
        }
        #endregion

        #region AÇÕES DE BOTÕES
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

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            try
           {
                if (MessageBox.Show(null, mensagem03, "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    //Avisa a origem(se houver) que espera um atendimento que nao selecionaram nada!
                    if (origemRequisitandoAtendimento != null)
                    {
                        origemRequisitandoAtendimento.sinalizarEscolha_atendimento(false);
                    }
                    //Fecha!
                    utilidades.fecharEstaJanela_peloPaiDinamico(this);
                }
            }
            catch { }
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            pesquisar();
            pintarTabela();
        }        

        private void btn_detalhar_Click(object sender, EventArgs e)
        {
            //Tendo algo selecionado!           
            if (utilidades.verificarSelecionouUmResultado_dtgvw(dtg_resultados))
            {
                //Questiona
                if (MessageBox.Show(null, mensagem01 + dtg_resultados.Rows[dtg_resultados.SelectedCells[0].RowIndex].Cells[dados_atendimento.ATENDIMENTO_CODIGO].Value.ToString() + "?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    //Carrega o detalhamento!
                    if (conexaoBD.abrirConexao())
                    {
                        atendimento atendimento = new atendimento();
                        atendimento.setCod_atendimento_pk(Convert.ToInt32(dtg_resultados.Rows[dtg_resultados.SelectedCells[0].RowIndex].Cells[dados_atendimento.ATENDIMENTO_CODIGO].Value.ToString()));
                        //inflo na atendimento area!
                        conteudos_dinamicos atendimentoArea = (conteudos_dinamicos)Parent.Parent;
                        atendimentoArea.carregarConteudo_principal(new Uc_atendimento_cadastro(principal, 3, dados_atendimento.selecionarUmAtendimento_porCodigo(atendimento)), false);
                    }
                }
            }            
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            //Tendo algo selecionado! 
            if (utilidades.verificarSelecionouUmResultado_dtgvw(dtg_resultados))
            {
                //Questiono
                if (MessageBox.Show(null, mensagem02 + dtg_resultados.Rows[dtg_resultados.SelectedCells[0].RowIndex].Cells[dados_atendimento.ATENDIMENTO_CODIGO].Value.ToString() + "?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    //Carrega o detalhamento para alteração!
                    if (conexaoBD.abrirConexao())
                    {
                        atendimento atendimento = new atendimento();
                        atendimento.setCod_atendimento_pk(Convert.ToInt32(dtg_resultados.Rows[dtg_resultados.SelectedCells[0].RowIndex].Cells[dados_atendimento.ATENDIMENTO_CODIGO].Value.ToString()));
                        //inflo na atendimento area!
                        conteudos_dinamicos atendimentoArea = (conteudos_dinamicos)Parent.Parent;
                        atendimentoArea.carregarConteudo_principal(new Uc_atendimento_cadastro(principal, 2, dados_atendimento.selecionarUmAtendimento_porCodigo(atendimento)), false);
                    }
                }
            }
        }

        private void btn_pesquisarResponsavel_Click(object sender, EventArgs e)
        {
            //Abre tela de carregando!
            utilidades.carregar_telaCarregando(this, 2);
            //Abre o pesquisar responsavel!
            Uc_responsavel_pesquisa pesq = new Uc_responsavel_pesquisa(principal, this);
            conteudos_dinamicos clienteArea = (conteudos_dinamicos)Parent.Parent;
            clienteArea.carregarConteudo_principal(pesq, true);
        }

        private void btn_pesquisarCliente_Click(object sender, EventArgs e)
        {
            //Abre tela de carregando!
            utilidades.carregar_telaCarregando(this, 1);
            //Abre o pesquisar cliente!
            Uc_cliente_pesquisa pesq = new Uc_cliente_pesquisa(principal, this);
            conteudos_dinamicos clienteArea = (conteudos_dinamicos)Parent.Parent;
            clienteArea.carregarConteudo_principal(pesq, true);
        }

        private void btn_escolher_selecionado_Click(object sender, EventArgs e)
        {
            try
            {
                //Tendo algo selecionado! 
                if (utilidades.verificarSelecionouUmResultado_dtgvw(dtg_resultados))
                {
                    //Questiono
                    if (MessageBox.Show(null, mensagem04, "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        //Carrega o atendimento selecionado!
                        atendimento novoAtendimento = new atendimento();
                        novoAtendimento.setCod_atendimento_pk(Convert.ToInt32(dtg_resultados.Rows[dtg_resultados.SelectedCells[0].RowIndex].Cells[dados_atendimento.ATENDIMENTO_CODIGO].Value.ToString()));
                        //origem recebe o atendimento!
                        origemRequisitandoAtendimento.atendimentoEscolhido(novoAtendimento);
                        if (novoAtendimento != null)
                        {
                            origemRequisitandoAtendimento.sinalizarEscolha_atendimento(true);
                        }
                        else
                        {
                            origemRequisitandoAtendimento.sinalizarEscolha_atendimento(false);
                        }
                        //fecho esta janela de pesquisa!
                        utilidades.fecharEstaJanela_peloPaiDinamico(this);
                    }
                }
            }
            catch(Exception erro) { MessageBox.Show(erro.Message+"/n"+erro.Data); 
            }
        
        }
        #endregion

        #region Rotinas de componentes
        private void Uc_cliente_pesquisa_Load(object sender, EventArgs e)
        {
            //base do dtg_resultado!
            dt_resultadosAtendimentos.Columns.Add(dados_atendimento.ATENDIMENTO_CODIGO, typeof(int));
            dt_resultadosAtendimentos.Columns.Add(dados_atendimento.ATENDIMENTO_CODIGO_CLIENTE, typeof(string));
            dt_resultadosAtendimentos.Columns.Add(dados_atendimento.ATENDIMENTO_CODIGO_RESPONSAVEL, typeof(string));
            dt_resultadosAtendimentos.Columns.Add("valor", typeof(string));
            dt_resultadosAtendimentos.Columns.Add("pago", typeof(string));
            dt_resultadosAtendimentos.Columns.Add(dados_atendimento.ATENDIMENTO_ESTADO_PAGO, typeof(string));
            dt_resultadosAtendimentos.Columns.Add(dados_atendimento.ATENDIMENTO_DATA_CRIACAO, typeof(string));            
            
            //base do dtg_serviços
            dt_servicos.Columns.Add(dados_servico.SERVICO_CODIGO, typeof(int));
            dt_servicos.Columns.Add(dados_servico.SERVICO_NOME, typeof(string));
            dt_servicos.Columns.Add(dados_servico.SERVICO_VALOR, typeof(string));
            dt_servicos.Columns.Add(dados_servico.SERVICO_DESCRICAO, typeof(string));
            carregarServicos();

            //atualizar hora do dtpckr
            dtpckr_dataCriacao.Value = DateTime.Now;

            #region coloracao componentes
            btn_receberPreco.BackColor = Properties.Settings.Default.botoes_001;
            btn_pesquisar.BackColor = Properties.Settings.Default.botoes_001;
            btn_detalhar.BackColor = Properties.Settings.Default.botoes_002;
            btn_alterar.BackColor = Properties.Settings.Default.botoes_002;
            btn_escolher_selecionado.BackColor = Properties.Settings.Default.botoes_002;            
            btn_fechar.BackColor = Properties.Settings.Default.botoes_002;
            lbl_fechar.ForeColor = Properties.Settings.Default.botoes_002;

            cbx_cliente.BackColor = Properties.Settings.Default.campos_001;
            cbx_responsavel.BackColor = Properties.Settings.Default.campos_001;
            cbx_servico.BackColor = Properties.Settings.Default.campos_001;
            txt_descricao_servico.BackColor = Properties.Settings.Default.campos_001;
            txt_codigo.BackColor = Properties.Settings.Default.campos_001;
            txt_valor_servico.BackColor = Properties.Settings.Default.campos_001;           
            #endregion
        }        

        #region Ativações/Considerações
        private void chkbx_ativar_precoServico_CheckedChanged(object sender, EventArgs e)
        {
            //efeito de ativar/desativar o preço do serviço escolhido!
            if (chkbx_ativar_precoServico.Checked)
            {
                txt_valor_servico.Enabled = true;
                txt_valor_servico.ReadOnly = false;
                txt_valor_servico.Focus();
            }
            else
            {
                txt_valor_servico.Enabled = false;
                txt_valor_servico.ReadOnly = true;
            }
        }

        private void chkbx_ativar_servico_CheckedChanged(object sender, EventArgs e)
        {
            //efeito de ativar/desativar a area de dados de serviço!
            if (chkbx_ativar_servico.Checked)
            {
                btn_receberPreco.Enabled = true;
                cbx_servico.Enabled = true;
                chkbx_ativar_precoServico.Visible = true;
                cbx_servico.Focus();
            }
            else
            {
                btn_receberPreco.Enabled = false;
                cbx_servico.Enabled = false;
                chkbx_ativar_precoServico.Checked = false;
                chkbx_ativar_precoServico.Visible = false;
            }
        }

        private void chkbx_ativar_data_CheckedChanged(object sender, EventArgs e)
        {
            //efeito de ativar/desativar o dtpckr data criacao do atendimento
            if (chkbx_ativar_data.Checked)
            {
                dtpckr_dataCriacao.Enabled = true;
                dtpckr_dataCriacao.Focus();
            }
            else
            {
                dtpckr_dataCriacao.Enabled = false;
            }
        }

        private void chkbx__ativar_codigo_CheckedChanged(object sender, EventArgs e)
        {
            //efeito de ativar/desativar o txt codigo atendimento!
            if (chkbx__ativar_codigo.Checked)
            {
                txt_codigo.Enabled = true;
                txt_codigo.Focus();
            }
            else
            {
                txt_codigo.Enabled = false;
            }
        }

        private void chkbx_ativarResponsavel_CheckedChanged(object sender, EventArgs e)
        {
            //efeito de ativar/desativar o btn pesquisar Responsavel!
            if (chkbx_ativarResponsavel.Checked)
            {
                btn_pesquisarResponsavel.Enabled = true;
                btn_pesquisarResponsavel.BackColor = Properties.Settings.Default.botoes_003;
            }
            else
            {
                btn_pesquisarResponsavel.Enabled = false;
                cbx_responsavel.DataSource = null;
                btn_pesquisarResponsavel.BackColor = Properties.Settings.Default.botoes_004;
            }            
        }

        private void chkbx_ativarCliente_CheckedChanged(object sender, EventArgs e)
        {
            //Efeito de ativar/desativar btn pesquisar Cliente!
            if (chkbx_ativarCliente.Checked)
            {
                btn_pesquisarCliente.Enabled = true;
                btn_pesquisarCliente.BackColor = Properties.Settings.Default.botoes_003;
            }
            else
            {
                btn_pesquisarCliente.Enabled = false;
                cbx_cliente.DataSource = null;
                btn_pesquisarCliente.BackColor = Properties.Settings.Default.botoes_004;
            }
        }
        #endregion

        #region adaptação de tamanhos para resoluções
        private void cbx_servico_SizeChanged(object sender, EventArgs e)
        {
            if (this.cbx_servico.Size.Width < 10)
            {
                this.btn_receberPreco.Size = new Size(30, this.btn_receberPreco.Size.Height);
                this.cbx_servico.Location = new Point(this.btn_receberPreco.Location.X + 35, this.btn_receberPreco.Location.Y);
                this.cbx_servico.Size = new Size(gbx_atendimento_servico.Size.Width - ((chkbx_ativar_servico.Size.Width + this.btn_receberPreco.Size.Width + 30)), this.cbx_servico.Size.Height);
            }
        }
        #endregion

        private void txt_codigo_TextChanged(object sender, EventArgs e)
        {
            //Deixa colocar somente numeros!
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_codigo.Text, "[^0-9]"))
            {
                MessageBox.Show("Somente números!");
                txt_codigo.Text = "";
            }
        }

        private void dtg_resultados_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Seleciona toda a linha quando clico 2x em uma celula!
            int cont = 0;
            for (cont = 0; cont < 7; cont++)
            {
                try
                {
                    dtg_resultados.Rows[e.RowIndex].Cells[cont].Selected = true;
                }
                catch { }
            }
        }

        private void dtg_resultados_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            pintarTabela();

        }
        #endregion

        #region FUNÇÕES
        private void pintarTabela()
        {
            //Pinta de acordo com valor "Devendo" / "Pago", usando referencia às linhas visualizadas no datagtrid!
            foreach (DataGridViewRow i in dtg_resultados.Rows)
            {
                if (i.Cells["estado_pago_atendimento"].Value.ToString().Equals("Devendo"))
                {
                    i.DefaultCellStyle.BackColor = Color.Red;
                    i.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    i.DefaultCellStyle.BackColor = Color.Green;
                    i.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private void carregarServicos()
        {             
            if (conexaoBD.abrirConexao())
            {
                //Completa o combobox de servicos! 
                cbx_servico.DataSource = dt_servicos;

                //Carrega os dados de serviços ativos!
                List<servico> listaServicos = dados_servico.selecionarTodosServicos_ativos();

                //adicionando resultados
                int cont = 0;
                for (cont = 0; cont < listaServicos.Count; cont++)
                {
                    dt_servicos.Rows.Add(listaServicos[cont].getCod_tab_servico_pk(),
                        listaServicos[cont].getNome_servico(),
                        listaServicos[cont].getValor_servico(),
                        listaServicos[cont].getDescricao_servico()
                        );
                }

                //Configurando cbx
                cbx_servico.DisplayMember = dados_servico.SERVICO_NOME;
                cbx_servico.ValueMember = dados_servico.SERVICO_CODIGO;
            }
        }

        private void pesquisar()
        {
            //Componentes principais
            atendimento atendimento = new atendimento();
            List<atendimento> atendimento_resultados = null;
            //Configurando dtg_resultados
            dtg_resultados.DataSource = dt_resultadosAtendimentos;

            //Pesquisando conforme solicitações
            if (conexaoBD.abrirConexao())
            {
                try
                {
                    if (chkbx__ativar_codigo.Checked)
                    {
                        try
                        {
                            atendimento.setCod_atendimento_pk(Convert.ToInt32(txt_codigo.Text));
                        }
                        catch { }
                    }
                    if (chkbx_ativarResponsavel.Checked)
                    {
                        atendimento.setCod_responsavel_fk(Convert.ToInt32(cbx_responsavel.SelectedValue));
                    }
                    if (chkbx_ativarCliente.Checked)
                    {
                        atendimento.setCod_cliente_fk(Convert.ToInt32(cbx_cliente.SelectedValue));
                    }
                    if (chkbx_ativar_data.Checked)
                    {
                        atendimento.setData_criacao_atendimento(utilidades.captarDate_dtpckr(dtpckr_dataCriacao));
                    }
                    if (chkbx_totalmenteFinalizado.Checked)
                    {
                        atendimento.setEstado_finalizado_atendimento('s');
                    }
                    if (chkbx_totalmentePago.Checked)
                    {
                        atendimento.setEstado_pago_atendimento('s');
                    }      
              
                    //Estilos de Pesquisa!
                    
                    //Igual
                    if (rdbtn_igual.Checked)    
                    {
                        atendimento_resultados = dados_atendimento.selecionarTodosAtendimentos_ativo_porBusca_igual(atendimento);
                        List<atendimento> atendimentos_filtrados = new List<atendimento>();
                        //Filtrar quem ja fez o serviço escolhido
                        if (chkbx_ativar_servico.Checked)
                        {
                            item_atendimento item_atendimento_interno = new item_atendimento();
                            item_atendimento_interno.setCod_servico_fk(Convert.ToInt32(cbx_servico.SelectedValue));
                            if (chkbx_ativar_precoServico.Checked)
                            {
                                try
                                {
                                    item_atendimento_interno.setValor_combinado_item_atendimento(Convert.ToDouble(utilidades.captarValorMonetarioValido_paraExibicao(txt_valor_servico.Text)));
                                }
                                catch { }
                            }
                            List<item_atendimento> listaItems = new List<item_atendimento>();
                            //pego todos items de atendimento de um serviço escolhido
                            listaItems = dados_item_atendimento.selecionarTodosItem_atendimento();
                            //percorro cada atendimento e vejo se ele ja fezo serviço escolhido
                            foreach (atendimento at in atendimento_resultados)
                            {
                                bool atendimento_contemItem_noServicoEscolhido = false;
                                int quantasVezesAdquiriu = 0;
                                foreach (item_atendimento ia in listaItems)
                                {
                                    //se algum atendimento contiver esse serviço
                                    if (ia.getCod_atendimento_fk() == at.getCod_atendimento_pk())
                                    {
                                        //se achar um item no atendimento que fuja do serviço procurado!
                                        if (ia.getCod_servico_fk() != item_atendimento_interno.getCod_servico_fk())
                                        {
                                            //digo que atendimento nao serve e saio!
                                            atendimento_contemItem_noServicoEscolhido = false;
                                            break;
                                        }
                                        //com filtro de valor
                                        if (chkbx_ativar_precoServico.Checked)
                                        {
                                            //se for igual ao valor escolhido
                                            if (ia.getValor_combinado_item_atendimento() == item_atendimento_interno.getValor_combinado_item_atendimento())
                                            {
                                                atendimento_contemItem_noServicoEscolhido = true;
                                                quantasVezesAdquiriu++;
                                            }
                                        }
                                        //sem fltro de valor
                                        else
                                        {
                                            atendimento_contemItem_noServicoEscolhido = true;
                                            quantasVezesAdquiriu++;
                                        }
                                    }
                                }
                                //ser contiver ele 
                                if (atendimento_contemItem_noServicoEscolhido)
                                {
                                    //jogo na lista dos filtrados se ele teve uma aquisição exclusiva do serviço escolhido!
                                    if (quantasVezesAdquiriu == 1)
                                    {
                                        atendimentos_filtrados.Add(at);
                                    }
                                }
                            }
                            atendimento_resultados = atendimentos_filtrados;
                        }
                    }
                    //Contem
                    if (rdbtn_contem.Checked)   
                    {
                        atendimento_resultados = dados_atendimento.selecionarTodosAtendimentos_ativo_porBusca_contem(atendimento);
                        List<atendimento> atendimentos_filtrados = new List<atendimento>();
                        //Filtrar quem ja fez o serviço escolhido
                        if (chkbx_ativar_servico.Checked)
                        {
                            item_atendimento item_atendimento_interno = new item_atendimento();
                            item_atendimento_interno.setCod_servico_fk(Convert.ToInt32(cbx_servico.SelectedValue));
                            if (chkbx_ativar_precoServico.Checked)
                            {
                                try
                                {
                                    item_atendimento_interno.setValor_combinado_item_atendimento(Convert.ToDouble(utilidades.captarValorMonetarioValido_paraExibicao(txt_valor_servico.Text)));
                                }
                                catch { }
                            }
                            List<item_atendimento> listaItems = new List<item_atendimento>();
                            //pego todos items de atendimento de um serviço escolhido
                            listaItems = dados_item_atendimento.selecionarTodosItem_atendimento_porCodigo_servico(item_atendimento_interno);
                            //percorro cada atendimento e vejo se ele ja fezo serviço escolhido
                            foreach (atendimento at in atendimento_resultados)
                            {
                                bool atendimento_contemItem_noServicoEscolhido = false;
                                foreach (item_atendimento ia in listaItems)
                                {
                                    //se algum atendimento contiver esse serviço
                                    if (ia.getCod_atendimento_fk() == at.getCod_atendimento_pk())
                                    {
                                        //com filtro de valor
                                        if (chkbx_ativar_precoServico.Checked)
                                        {
                                            //se for igual ao valor escolhido
                                            if (ia.getValor_combinado_item_atendimento() == item_atendimento_interno.getValor_combinado_item_atendimento())
                                            {
                                                atendimento_contemItem_noServicoEscolhido = true;
                                            }
                                        }
                                        //sem fltro de valor
                                        else
                                        {
                                            atendimento_contemItem_noServicoEscolhido = true;
                                        }
                                    }
                                }
                                //ser contiver ele 
                                if (atendimento_contemItem_noServicoEscolhido)
                                {
                                    //jogo na lista dos filtrados
                                    atendimentos_filtrados.Add(at);
                                }
                            }
                            atendimento_resultados = atendimentos_filtrados;
                        }
                    }
                    //Pesquisando
                    if ((atendimento_resultados != null))
                    {
                        dt_resultadosAtendimentos.Clear();
                        if (atendimento_resultados.Count > 0)
                        {
                            int cont = 0;
                            while (cont < atendimento_resultados.Count)
                            {
                                //cliente e resposnavel envolvidos
                                cliente cliente = new cliente();
                                cliente.setCod_cliente_pk(atendimento_resultados[cont].getCod_cliente_fk());
                                responsavel responsavel = new responsavel();
                                responsavel.setCod_responsavel_pk(atendimento_resultados[cont].getCod_responsavel_fk());

                                //dados do valor total
                                item_atendimento item_atendimento = new item_atendimento();
                                item_atendimento.setCod_atendimento_fk(atendimento_resultados[cont].getCod_atendimento_pk());
                                List<item_atendimento> listaItems = new List<item_atendimento>();
                                listaItems = dados_item_atendimento.selecionarTodosItem_atendimento_porCodigoAtendimento(item_atendimento);
                                Double valorTotal = 0.0;
                                foreach (item_atendimento i in listaItems)
                                {
                                    valorTotal += i.getValor_combinado_item_atendimento();
                                }
                                //dados do valor pago
                                pagamento_atendimento pagamento_atendimento = new pagamento_atendimento();
                                pagamento_atendimento.setCod_atendimento_fk(atendimento_resultados[cont].getCod_atendimento_pk());
                                List<pagamento_atendimento> listaPagamentos = new List<pagamento_atendimento>();
                                listaPagamentos = dados_pagamento_atendimento.selecionarTodosPagamento_atendimento_porCodAtendimento(pagamento_atendimento);
                                Double valorTotalPago = 0.0;
                                foreach (pagamento_atendimento i in listaPagamentos)
                                {
                                    valorTotalPago += i.getValor_fatia_pagamento();
                                }
                                //adicionando resultado!
                                dt_resultadosAtendimentos.Rows.Add(
                                atendimento_resultados[cont].getCod_atendimento_pk(),
                                dados_cliente.selecionarUmCliente_porCodigo(cliente).getNome_cliente(),
                                dados_responsavel.selecionarUmResponsavel_porCodigo(responsavel).getNome_responsavel(),                                
                                "R$"+utilidades.captarValorMonetarioValido_paraExibicao(valorTotal.ToString()),
                                "R$" + utilidades.captarValorMonetarioValido_paraExibicao(valorTotalPago.ToString()),
                                utilidades.verificarTotalmentePagoBanco_paraExibicao(atendimento_resultados[cont].getEstado_pago_atendimento()),
                                atendimento_resultados[cont].getData_criacao_atendimento().Replace("00:00:00", "-")
                                );
                                cont++;
                            }
                        }
                        else
                        {
                            MessageBox.Show(null, mensagem08 +"\n", "INFORMAÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }                        
                    }

                }
                catch (Exception erro)
                {
                    MessageBox.Show(null, mensagem09 +"\n" + erro, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void carregarClienteSelecionado()
        {
            //usando quando é selecionado um cliente na janela de pesquisa!
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
                    "CÓD.:" + this.clienteSelecionado.getCod_cliente_pk() + ": " +
                    this.clienteSelecionado.getNome_cliente() + " - " +
                    this.clienteSelecionado.getApelido_cliente() + " - " +
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

                dt_responsavelSelecionado.Rows.Add(this.responsavelSelecionado.getCod_responsavel_pk(),
                    "CÓD.:" + this.responsavelSelecionado.getCod_responsavel_pk() + ": " +
                    this.responsavelSelecionado.getNome_responsavel() + " : " +
                    this.responsavelSelecionado.getApelido_responsavel() + " - " +
                    utilidades.captarCnpjCpfMascarado_confomeTipoPessoa(this.responsavelSelecionado.getCod_tipo_pessoa_fk(), this.responsavelSelecionado.getCpfCnpj_responsavel()) + " - " +
                    dados_pessoa_tipo.selecionarTipo_porCodigo(pessoa_tipo).getNome_tipo_pessoa() + " - " +
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

        public string getDescricao()
        {
            return "Pesquisar Atendimentos";
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

        private void cbx_servico_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //Capto o valor e a descricao do servico no proprio datatable do combobox que foi selecionado o serviço!
                DataTable dt_servicos = (DataTable)cbx_servico.DataSource;
                //Expressão de seleção por codigo!
                DataRow[] dr = dt_servicos.Select(dados_servico.SERVICO_CODIGO + " = " + cbx_servico.SelectedValue.ToString());
                //Capto a descicao do resultado!
                txt_descricao_servico.Text = dr[0][dados_servico.SERVICO_DESCRICAO].ToString();
                //Capto o valor do resultado!
                txt_valor_servico.Text = utilidades.captarValorMonetarioValido_paraExibicao(dr[0][dados_servico.SERVICO_VALOR].ToString());
            }
            catch
            {

                //limpo os textos quando mudar o serviço, a fim de não confundir!
                txt_valor_servico.Text = "";
                txt_descricao_servico.Text = "";
            }
        }
        
    }
}
