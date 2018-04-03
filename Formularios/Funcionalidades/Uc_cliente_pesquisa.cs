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
    public partial class Uc_cliente_pesquisa : UserControl, uc_identificacao
    {
        //MODO
        //1 = Pesquisa,leitura,alteracao, 2=Seleção
        #region DADOS
        int MODO = 1; //padrao modo Pesquisa,leitura,alteracao!
        frm_principal principal = null;
        dados_contato_tipo dados_contato_tipo = new dados_contato_tipo();
        dados_endereco_tipo dados_endereco_tipo = new dados_endereco_tipo();
        dados_cliente dados_cliente = new dados_cliente();
        //CODIGO PF=1 E PJ=2
        int COD_PF = 1, COD_PJ = 2;
        String baseEndereco = "Endereço: " + System.Environment.NewLine +
                "Bairro: " + System.Environment.NewLine +
                "Complemento: " + System.Environment.NewLine +
                "Cidade: " + System.Environment.NewLine +
                "CEP: " + System.Environment.NewLine;
        String mensagem01 = "Deseja Ver os dados de ";
        String mensagem02 = "Deseja Alterar os dados de ";
        String mensagem03 = "Deseja realmente fechar esta aba?";
        String mensagem04 = "Deseja realmente escolher este cliente?";
        requerimento_cliente origemRequisitandoCliente = null;
        DataTable dt_resultadosClientes_PF = new DataTable();
        DataTable dt_resultadosClientes_PJ = new DataTable();
        #endregion

        #region INICIALIZADORES
        public Uc_cliente_pesquisa(frm_principal principal) //util para modo 1!
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

        public Uc_cliente_pesquisa(frm_principal principal, object origemRequisitando)//util para modo 2!
        {
            this.MODO = 2;
            //origem padrao
            this.principal = principal;
            //tela que requisita cliente!
            this.origemRequisitandoCliente = (requerimento_cliente)origemRequisitando;
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
        private void btn_fechar_Click(object sender, EventArgs e)
        {
            try
           {
                if (MessageBox.Show(null, mensagem03, "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (origemRequisitandoCliente != null)
                    {
                        origemRequisitandoCliente.sinalizarEscolha_cliente(false);
                    }
                    utilidades.fecharEstaJanela_peloPaiDinamico(this);
                }
            }
            catch { }
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            pesquisar();
        }

        private void btn_detalhar_Click(object sender, EventArgs e)
        {
            if (utilidades.verificarSelecionouUmResultado_dtgvw(dtg_resultados))
            {
                if (MessageBox.Show(null, mensagem01 + dtg_resultados.Rows[dtg_resultados.SelectedCells[0].RowIndex].Cells["nome_cliente"].Value.ToString()+"?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dados_cliente dadosCL = new dados_cliente();
                    if (conexaoBD.abrirConexao())
                    {
                        cliente cli = new cliente();
                        cli.setCod_cliente_pk(Convert.ToInt32(dtg_resultados.Rows[dtg_resultados.SelectedCells[0].RowIndex].Cells["cod_cliente_pk"].Value.ToString()));
                        //inflo na cliente area!
                     conteudos_dinamicos clienteArea = (conteudos_dinamicos)Parent.Parent;
                        clienteArea.carregarConteudo_principal(new Uc_cliente_cadastro(principal, 3, dadosCL.selecionarUmCliente_porCodigo(cli)), false);
                    }
                }
            }
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            if (utilidades.verificarSelecionouUmResultado_dtgvw(dtg_resultados))
            {
                if (MessageBox.Show(null, mensagem02 + dtg_resultados.Rows[dtg_resultados.SelectedCells[0].RowIndex].Cells["nome_cliente"].Value.ToString() + "?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dados_cliente dadosCL = new dados_cliente();
                    if (conexaoBD.abrirConexao())
                    {
                        cliente cli = new cliente();
                        cli.setCod_cliente_pk(Convert.ToInt32(dtg_resultados.Rows[dtg_resultados.SelectedCells[0].RowIndex].Cells["cod_cliente_pk"].Value.ToString()));
                        //inflo na cliente area!
                        conteudos_dinamicos clienteArea = (conteudos_dinamicos)Parent.Parent;
                        clienteArea.carregarConteudo_principal(new Uc_cliente_cadastro(principal, 2, dadosCL.selecionarUmCliente_porCodigo(cli)), false);
                    }
                }
            }
        }

        private void btn_escolher_selecionado_Click(object sender, EventArgs e)
        {
            try
            {
                if (utilidades.verificarSelecionouUmResultado_dtgvw(dtg_resultados))
                {
                    if (MessageBox.Show(null, mensagem04, "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        //cliente novo para setar o ID nele!
                        cliente novoCliente = new cliente();
                        novoCliente.setCod_cliente_pk(Convert.ToInt32(dtg_resultados.Rows[dtg_resultados.SelectedCells[0].RowIndex].Cells["cod_cliente_pk"].Value.ToString()));
                        //origem recebe o cliente!
                        origemRequisitandoCliente.clienteEscolhido(novoCliente);
                        if (novoCliente != null)
                        {
                            origemRequisitandoCliente.sinalizarEscolha_cliente(true);
                        }
                        else
                        {
                            origemRequisitandoCliente.sinalizarEscolha_cliente(false);
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
            rbtn_pessoaFisica_CheckedChanged(null, null);
            carregarTipoContatos();
            carregarTipoEnderecos();

            dt_resultadosClientes_PF.Columns.Add("cod_cliente_pk", typeof(int));
            dt_resultadosClientes_PF.Columns.Add("nome_cliente", typeof(string));
            dt_resultadosClientes_PF.Columns.Add("cpfCnpj_cliente", typeof(string));
            dt_resultadosClientes_PF.Columns.Add("rgIe_cliente", typeof(string));
            dt_resultadosClientes_PF.Columns.Add("rntrc_cliente", typeof(string));
            dt_resultadosClientes_PF.Columns.Add("data_nascimento_cliente", typeof(string));

            dt_resultadosClientes_PJ.Columns.Add("cod_cliente_pk", typeof(int));
            dt_resultadosClientes_PJ.Columns.Add("nome_cliente", typeof(string));
            dt_resultadosClientes_PJ.Columns.Add("cpfCnpj_cliente", typeof(string));
            dt_resultadosClientes_PJ.Columns.Add("rgIe_cliente", typeof(string));
            dt_resultadosClientes_PJ.Columns.Add("rntrc_cliente", typeof(string));
            dt_resultadosClientes_PJ.Columns.Add("data_nascimento_cliente", typeof(string));

            #region coloracao componentes
            btn_pesquisar.BackColor = Properties.Settings.Default.botoes_001;
            btn_detalhar.BackColor = Properties.Settings.Default.botoes_002;
            btn_alterar.BackColor = Properties.Settings.Default.botoes_002;
            btn_fechar.BackColor = Properties.Settings.Default.botoes_002;
            lbl_fechar.ForeColor = Properties.Settings.Default.botoes_002;
            btn_escolher_selecionado.BackColor = Properties.Settings.Default.botoes_002;
            txt_apelido_pf.BackColor = Properties.Settings.Default.campos_001;
            txt_codigo.BackColor = Properties.Settings.Default.campos_001;
            txt_nome_pf.BackColor = Properties.Settings.Default.campos_001;
            txt_razaoSocial_pf.BackColor = Properties.Settings.Default.campos_001;
            txt_nomeFantasia_pj.BackColor = Properties.Settings.Default.campos_001;
            msktxt_cep.BackColor = Properties.Settings.Default.campos_001;
            msktxt_cnpj_pj.BackColor = Properties.Settings.Default.campos_001;
            msktxt_contato.BackColor = Properties.Settings.Default.campos_001;
            msktxt_cpf_pf.BackColor = Properties.Settings.Default.campos_001;
            msktxt_ie_pj.BackColor = Properties.Settings.Default.campos_001;
            msktxt_rg_pf.BackColor = Properties.Settings.Default.campos_001;
            msktxt_rntrc_pf.BackColor = Properties.Settings.Default.campos_001;
            msktxt_rntrc_pj.BackColor = Properties.Settings.Default.campos_001;
            #endregion
        }

        private void rbtn_pessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_pessoaJuridica.Checked)
            {
                gbx_dadosCliente_fisica.Hide();
                gbx_dadosCliente_juridica.Show();
                dtg_resultados.Columns["nome_cliente"].HeaderText = "RAZÃO SOCIAL";
                dtg_resultados.Columns["cpfCnpj_cliente"].HeaderText = "CADASTRO PESSOA JURÍDICA";
                dtg_resultados.Columns["rgIe_cliente"].HeaderText = "INSCRIÇÃO ESTADUAL";
                dtg_resultados.Columns["data_nascimento_cliente"].HeaderText = "DATA ABERTURA";
                dtg_resultados.DataSource = dt_resultadosClientes_PJ;
            }
            else
            {
                gbx_dadosCliente_fisica.Show();
                gbx_dadosCliente_juridica.Hide();
            }
        }
        
        private void rbtn_pessoaFisica_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_pessoaFisica.Checked)
            {
                gbx_dadosCliente_fisica.Show();
                gbx_dadosCliente_juridica.Hide();
                dtg_resultados.Columns["nome_cliente"].HeaderText = "NOME";
                dtg_resultados.Columns["cpfCnpj_cliente"].HeaderText = "CADASTRO PESSOA FÍSICA";
                dtg_resultados.Columns["rgIe_cliente"].HeaderText = "REGISTRO CIVIL";
                dtg_resultados.Columns["data_nascimento_cliente"].HeaderText = "DATA NASCIMENTO";
                dtg_resultados.DataSource = dt_resultadosClientes_PF;
            }
            else
            {
                gbx_dadosCliente_fisica.Hide();
                gbx_dadosCliente_juridica.Show();                
            }              
        }

        private void msktxt_rntrc_Validated(object sender, EventArgs e)
        {
            MaskedTextBox msktxt = (MaskedTextBox)sender;
            msktxt.Text = msktxt.Text.ToUpper();
        }

        private void cbx_tipo_contato_DataSourceChanged(object sender, EventArgs e)
        {
            utilidades.selecionarMascara_confomeContato_msktxt(Convert.ToInt32(this.cbx_tipo_contato.SelectedValue), msktxt_contato);
        }

        private void cbx_tipo_contato_SelectedIndexChanged(object sender, EventArgs e)
        {
            utilidades.selecionarMascara_confomeContato_msktxt(Convert.ToInt32(this.cbx_tipo_contato.SelectedValue), msktxt_contato);
            msktxt_contato.Focus();
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
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_codigo.Text, "[^0-9]"))
            {
                MessageBox.Show("Somente números!");
                txt_codigo.Text = "";
            }
        }

        private void chkbx_codigo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_codigo.Checked)
            {
                txt_codigo.Enabled = true;
                txt_codigo.Focus();
            }
            else
            {
                txt_codigo.Enabled = false;
            }
        }

        //PF
        private void chkbx_nome_pf_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_nome_pf.Checked)
            {
                txt_nome_pf.Enabled = true;
                txt_nome_pf.Focus();
            }
            else
            {
                txt_nome_pf.Enabled = false;
            }
        }

        private void chkbx_apelido_pf_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_apelido_pf.Checked)
            {
                txt_apelido_pf.Enabled = true;
                txt_apelido_pf.Focus();
            }
            else
            {
                txt_apelido_pf.Enabled = false;
            }
        }

        private void chkbx_dataNasc_pf_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_dataNasc_pf.Checked)
            {
                dtpckr_dataNascimento_pf.Enabled = true;
                dtpckr_dataNascimento_pf.Focus();
            }
            else
            {
                dtpckr_dataNascimento_pf.Enabled = false;
            }
        }

        private void chkbx_cpf_pf_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_cpf_pf.Checked)
            {
                msktxt_cpf_pf.Enabled = true;
                msktxt_cpf_pf.Focus();
            }
            else
            {
                msktxt_cpf_pf.Enabled = false;
            }
        }

        private void chkbx_rntrc_pf_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_rntrc_pf.Checked)
            {
                msktxt_rntrc_pf.Enabled = true;
                msktxt_rntrc_pf.Focus();
            }
            else
            {
                msktxt_rntrc_pf.Enabled = false;
            }
        }

        private void chkbx_contato_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_contato.Checked)
            {
                cbx_tipo_contato.Enabled = true;
                msktxt_contato.Enabled = true;
                cbx_tipo_contato.Focus();
            }
            else
            {
                cbx_tipo_contato.Enabled = false;
                msktxt_contato.Enabled = false;
            }
        }

        private void chkbx_cep_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_cep.Checked)
            {
                cbx_tipo_endereco.Enabled = true;
                msktxt_cep.Enabled = true;
                cbx_tipo_endereco.Focus();
            }
            else
            {
                cbx_tipo_endereco.Enabled = false;
                msktxt_cep.Enabled = false;
            }
        }
        
        //PJ
        private void chkbx_razaoSocial_pj_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_razaoSocial_pj.Checked)
            {
                txt_razaoSocial_pf.Enabled = true;
                txt_razaoSocial_pf.Focus();
            }
            else
            {
                txt_razaoSocial_pf.Enabled = false;
            }
        }

        private void chkbx_nome_fantasia_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_nome_fantasia.Checked)
            {
                txt_nomeFantasia_pj.Enabled = true;
                txt_nomeFantasia_pj.Focus();

            }
            else
            {
                txt_nomeFantasia_pj.Enabled = false;
            }
        }

        private void chkbx_rntrc_pj_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_rntrc_pj.Checked)
            {
                msktxt_rntrc_pj.Enabled = true;
                msktxt_rntrc_pj.Focus();
            }
            else
            {
                msktxt_rntrc_pj.Enabled = false;
            }
        }

        private void chkbx_data_abertura_pj_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_data_abertura_pj.Checked)
            {
                dtpckr_data_abertura_pj.Enabled = true;
                chkbx_data_abertura_pj.Focus();
            }
            else
            {
                dtpckr_data_abertura_pj.Enabled = false;
            }
        }

        private void chkbx_ie_pj_CheckedChanged(object sender, EventArgs e)
        {
            if(chkbx_ie_pj.Checked)
            {
                msktxt_ie_pj.Enabled = true;
                msktxt_ie_pj.Focus();
            }
            else
            {
                msktxt_ie_pj.Enabled = false;
            }
        }

        private void chkbx_cnpj_pj_CheckedChanged(object sender, EventArgs e)
        {
            if(chkbx_cnpj_pj.Checked)
            {
                msktxt_cnpj_pj.Enabled=true;
                msktxt_cnpj_pj.Focus();
            }
            else
            {
                msktxt_cnpj_pj.Enabled=false;
            }
        }
        #endregion

        #region FUNÇÕES
        private void pesquisar()
        {
            cliente cliente = new cliente();
            List<cliente> clientes_resultados = null;
            if (conexaoBD.abrirConexao())
            {
                try
                {
                    if (chkbx_codigo.Checked)
                    {
                        try
                        {
                            cliente.setCod_cliente_pk(Convert.ToInt32(txt_codigo.Text));
                        }
                        catch { }
                    }
                    if (utilidades.verificarTipoPessoa_rbtn(rbtn_pessoaFisica,rbtn_pessoaJuridica) == 'f') //se for pessoa física!
                    {
                        dtg_resultados.DataSource = dt_resultadosClientes_PF;
                        cliente.setCod_tipo_pessoa_fk(COD_PF);
                        if (chkbx_apelido_pf.Checked)
                        {
                            cliente.setApelido_cliente(txt_apelido_pf.Text);
                        }
                        if (chkbx_cpf_pf.Checked)
                        {
                            cliente.setCpfCnpj_cliente(utilidades.captarValorMascarado_semMascara(msktxt_cpf_pf));
                        }
                        if (chkbx_rg_pf.Checked)
                        {
                            cliente.setRgIe_cliente(utilidades.captarValorMascarado_semMascara(msktxt_rg_pf));
                        }
                        if (chkbx_dataNasc_pf.Checked)
                        {
                            cliente.setData_nascimento_cliente(utilidades.captarDate_dtpckr(dtpckr_dataNascimento_pf));
                        }
                        if (chkbx_nome_pf.Checked)
                        {
                            cliente.setNome_cliente(txt_nome_pf.Text);
                        }
                        if (chkbx_rntrc_pf.Checked)
                        {
                            cliente.setRntrc_cliente(utilidades.captarValorMascarado_semMascara(msktxt_rntrc_pf));
                        }
                    }
                    else //se for pessoa jurídica!
                    {
                        dtg_resultados.DataSource = dt_resultadosClientes_PJ;
                        cliente.setCod_tipo_pessoa_fk(COD_PJ);
                        if (chkbx_nome_fantasia.Checked)
                        {
                            cliente.setApelido_cliente(txt_nomeFantasia_pj.Text);
                        }
                        if (chkbx_cnpj_pj.Checked)
                        {
                            cliente.setCpfCnpj_cliente(utilidades.captarValorMascarado_semMascara(msktxt_cnpj_pj));
                        }
                        if (chkbx_ie_pj.Checked)
                        {
                            cliente.setRgIe_cliente(utilidades.captarValorMascarado_semMascara(msktxt_ie_pj));
                        }
                        if (chkbx_data_abertura_pj.Checked)
                        {
                            cliente.setData_nascimento_cliente(utilidades.captarDate_dtpckr(dtpckr_data_abertura_pj));
                        }
                        if (chkbx_razaoSocial_pj.Checked)
                        {
                            cliente.setNome_cliente(txt_razaoSocial_pf.Text);
                        }
                        if (chkbx_rntrc_pj.Checked)
                        {
                            cliente.setRntrc_cliente(utilidades.captarValorMascarado_semMascara(msktxt_rntrc_pj));
                        }
                    }

                    contato_cliente contato_cliente = null; //contato
                    if(chkbx_contato.Checked==true)
                    {
                        contato_cliente = new contato_cliente();
                        contato_cliente.setTipo_contato_fk(Convert.ToInt32(cbx_tipo_contato.SelectedValue));
                        contato_cliente.setTexto_contato_cliente(utilidades.captarValorMascarado_semMascara(msktxt_contato).TrimStart().TrimEnd());
                    }

                    endereco_cliente endereco_cliente = null;//endereco
                    if (chkbx_cep.Checked)
                    {
                        endereco_cliente = new endereco_cliente();
                        endereco_cliente.setCod_tipo_endereco_fk(Convert.ToInt32(cbx_tipo_endereco.SelectedValue));
                        endereco_cliente.setTexto_endereco_cliente(utilidades.captarValorMascarado_semMascara(msktxt_cep).TrimStart().TrimEnd());
                    }

                    //Estilos de Pesquisa!
                    if (rdbtn_igual.Checked)    //igual
                    {
                        clientes_resultados = dados_cliente.selecionarTodosCliente_ativo_porBusca_igual(cliente, endereco_cliente, contato_cliente);
                    }
                    if (rdbtn_contem.Checked)   //contem
                    {
                        clientes_resultados = dados_cliente.selecionarTodosCliente_ativo_porBusca_contem(cliente, endereco_cliente, contato_cliente);
                    }
                    if (rdbtn_inicio.Checked)   //inicio
                    {
                        clientes_resultados = dados_cliente.selecionarTodosCliente_ativo_porBusca_inicio(cliente, endereco_cliente, contato_cliente);
                    }
                    if (rdbtn_final.Checked)   //final
                    {
                        clientes_resultados = dados_cliente.selecionarTodosCliente_ativo_porBusca_fim(cliente, endereco_cliente, contato_cliente);
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show(null, "Não foi efetuar a pesquisa!\n" + erro, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
                
                if ((clientes_resultados != null))
                {
                    if (rbtn_pessoaFisica.Checked)
                    {
                        dt_resultadosClientes_PF.Clear();
                        if (clientes_resultados.Count > 0)
                        {
                            int cont = 0;
                            while (cont < clientes_resultados.Count)
                            {
                                dt_resultadosClientes_PF.Rows.Add(
                                    clientes_resultados[cont].getCod_cliente_pk(),
                                    clientes_resultados[cont].getNome_cliente(),
                                    utilidades.captarCnpjCpfMascarado_confomeTipoPessoa(clientes_resultados[cont].getCod_tipo_pessoa_fk(), clientes_resultados[cont].getCpfCnpj_cliente()),
                                    utilidades.captarIeRgMascarado_confomeTipoPessoa(clientes_resultados[cont].getCod_tipo_pessoa_fk(),clientes_resultados[cont].getRgIe_cliente()),
                                    utilidades.captarRntrcMascarado(clientes_resultados[cont].getRntrc_cliente()),
                                    clientes_resultados[cont].getData_nascimento_cliente().Replace("00:00:00", "")
                                    );
                                cont++;
                            }
                        }
                        else
                        {
                            MessageBox.Show(null, "Não foram econtrados resultados!\n", "INFORMAÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        dt_resultadosClientes_PJ.Clear();
                        if (clientes_resultados.Count > 0)
                        {
                            int cont = 0;
                            while (cont < clientes_resultados.Count)
                            {
                                dt_resultadosClientes_PJ.Rows.Add(
                                    clientes_resultados[cont].getCod_cliente_pk(),
                                    clientes_resultados[cont].getNome_cliente(),
                                    utilidades.captarCnpjCpfMascarado_confomeTipoPessoa(clientes_resultados[cont].getCod_tipo_pessoa_fk(), clientes_resultados[cont].getCpfCnpj_cliente()),
                                    utilidades.captarIeRgMascarado_confomeTipoPessoa(clientes_resultados[cont].getCod_tipo_pessoa_fk(),clientes_resultados[cont].getRgIe_cliente()),
                                    utilidades.captarRntrcMascarado(clientes_resultados[cont].getRntrc_cliente()),
                                    clientes_resultados[cont].getData_nascimento_cliente().Replace("00:00:00", "")
                                    );
                                cont++;
                            }
                        }
                        else
                        {
                            MessageBox.Show(null, "Não foram econtrados resultados!\n", "INFORMAÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation
                                );
                        }
                    }
                    
                }
                          
           }
        }

        private void carregarTipoContatos()
        {
            if (conexaoBD.abrirConexao())
            {
                //completa o combobox de tipos de contatos!
                List<tipo_contato> todosTiposContato = dados_contato_tipo.selecionarTodosTipos();
                DataTable dt_todosTiposContato = new DataTable();
                dt_todosTiposContato.Columns.Add("cod_tipo_contato_pk", typeof(int));
                dt_todosTiposContato.Columns.Add("nome_tipo_contato", typeof(string));
                cbx_tipo_contato.DataSource = dt_todosTiposContato;
                int cont = 0;
                while (cont < todosTiposContato.Count)
                {
                    dt_todosTiposContato.Rows.Add(todosTiposContato[cont].getCod_tipo_contato_pk(), todosTiposContato[cont].getNome_tipo_contato());
                    cont++;
                }
            }
        }

        private void carregarTipoEnderecos()
        {
            if (conexaoBD.abrirConexao())
            {
                int cont = 0;
                //completa o combobox de tipos de endereços!
                List<tipo_endereco> todosTiposEndereco = dados_endereco_tipo.selecionarTodosTipos();
                DataTable dt_todosTiposEndereco = new DataTable();
                dt_todosTiposEndereco.Columns.Add("cod_tipo_endereco_pk", typeof(int));
                dt_todosTiposEndereco.Columns.Add("nome_tipo_endereco", typeof(string));
                cbx_tipo_endereco.DataSource = dt_todosTiposEndereco;
                while (cont < todosTiposEndereco.Count)
                {
                    dt_todosTiposEndereco.Rows.Add(todosTiposEndereco[cont].getCod_tipo_endereco_pk(), todosTiposEndereco[cont].getNome_tipo_endereco());
                    cont++;
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
        #endregion       

        #region Membros de uc_identificacao
        public string getTitulo()
        {
            uc_identificacao pai = (uc_identificacao)Parent.Parent;
            return pai.getTitulo();
        }

        public string getDescricao()
        {
            return "Pesquisar um Cliente";
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

        private void gbx_contatoCliente_SizeChanged(object sender, EventArgs e)
        {
            gbx_enderecos.Location = new Point(gbx_contatoCliente.Location.X+gbx_contatoCliente.Width+10,gbx_enderecos.Location.Y);
        }


     

       

        

       

        

       
        
        
    }
}
