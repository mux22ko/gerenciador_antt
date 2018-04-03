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
    public partial class Uc_responsavel_pesquisa : UserControl, uc_identificacao
    {
        //MODO
        //1 = Pesquisa,leitura,alteracao, 2=Seleção

        #region DADOS
        int MODO = 1; //padrao modo Pesquisa,leitura,alteracao!
        frm_principal principal = null;
        dados_contato_tipo dados_contato_tipo = new dados_contato_tipo();
        dados_endereco_tipo dados_endereco_tipo = new dados_endereco_tipo();
        dados_responsavel dados_responsavel = new dados_responsavel();
        dados_responsavel_tipo dados_responsavel_tipo = new dados_responsavel_tipo();
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
        String mensagem04 = "Deseja realmente escolher este responsavel?";
        requerimento_responsavel origemRequisitandoResponsavel = null;
        DataTable dt_resultadosResponsavels_PF = new DataTable();
        DataTable dt_resultadosResponsavels_PJ = new DataTable();
        #endregion

        #region INICIALIZADORES
        public Uc_responsavel_pesquisa(frm_principal principal) //util para modo 1!
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

        public Uc_responsavel_pesquisa(frm_principal principal, object origemRequisitando)//util para modo 2!
        {
            this.MODO = 2;
            //origem padrao
            this.principal = principal;
            //tela que requisita responsavel!
            this.origemRequisitandoResponsavel = (requerimento_responsavel)origemRequisitando;
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
                    if (origemRequisitandoResponsavel != null)
                    {
                        origemRequisitandoResponsavel.sinalizarEscolha_responsavel(false);
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
                if (MessageBox.Show(null, mensagem01 + dtg_resultados.Rows[dtg_resultados.SelectedCells[0].RowIndex].Cells["nome_responsavel"].Value.ToString()+"?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dados_responsavel dadosCL = new dados_responsavel();
                    if (conexaoBD.abrirConexao())
                    {
                        responsavel cli = new responsavel();
                        cli.setCod_responsavel_pk(Convert.ToInt32(dtg_resultados.Rows[dtg_resultados.SelectedCells[0].RowIndex].Cells["cod_responsavel_pk"].Value.ToString()));
                        //inflo na responsavel area!
                        conteudos_dinamicos responsavelArea = (conteudos_dinamicos)Parent.Parent;
                        responsavelArea.carregarConteudo_principal(new Uc_responsavel_cadastro(principal, 3, dadosCL.selecionarUmResponsavel_porCodigo(cli)), false);
                    }
                }
            }
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            if (utilidades.verificarSelecionouUmResultado_dtgvw(dtg_resultados))
            {
                if (MessageBox.Show(null, mensagem02 + dtg_resultados.Rows[dtg_resultados.SelectedCells[0].RowIndex].Cells["nome_responsavel"].Value.ToString() + "?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dados_responsavel dadosCL = new dados_responsavel();
                    if (conexaoBD.abrirConexao())
                    {
                        responsavel cli = new responsavel();
                        cli.setCod_responsavel_pk(Convert.ToInt32(dtg_resultados.Rows[dtg_resultados.SelectedCells[0].RowIndex].Cells["cod_responsavel_pk"].Value.ToString()));
                        //inflo na responsavel area!
                        conteudos_dinamicos responsavelArea = (conteudos_dinamicos)Parent.Parent;
                        responsavelArea.carregarConteudo_principal(new Uc_responsavel_cadastro(principal, 2, dadosCL.selecionarUmResponsavel_porCodigo(cli)), false);
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
                        //responsavel novo para setar o ID nele!
                        responsavel novoResponsavel = new responsavel();
                        novoResponsavel.setCod_responsavel_pk(Convert.ToInt32(dtg_resultados.Rows[dtg_resultados.SelectedCells[0].RowIndex].Cells["cod_responsavel_pk"].Value.ToString()));
                        //origem recebe o responsavel!
                        origemRequisitandoResponsavel.responsavelEscolhido(novoResponsavel);
                        if (novoResponsavel != null)
                        {
                            origemRequisitandoResponsavel.sinalizarEscolha_responsavel(true);
                        }
                        else
                        {
                            origemRequisitandoResponsavel.sinalizarEscolha_responsavel(false);
                        }
                        //fecho esta janela de pesquisa!
                        utilidades.fecharEstaJanela_peloPaiDinamico(this);
                    }
                }
            }
            catch(Exception erro) { MessageBox.Show(erro.Message+"/n"+erro.Data); }            
        }
        #endregion

        #region Rotinas de componentes
        private void Uc_responsavel_pesquisa_Load(object sender, EventArgs e)
        {
            rbtn_pessoaFisica_CheckedChanged(null, null);
            carregarTipoContatos();
            carregarTipoEnderecos();
            carregarTipoResponsaveis();

            dt_resultadosResponsavels_PF.Columns.Add(dados_responsavel.RESPONSAVEL_CODIGO, typeof(int));
            dt_resultadosResponsavels_PF.Columns.Add(dados_responsavel.RESPONSAVEL_NOME, typeof(string));
            dt_resultadosResponsavels_PF.Columns.Add(dados_responsavel.RESPONSAVEL_APELIDO, typeof(string));
            dt_resultadosResponsavels_PF.Columns.Add(dados_responsavel.RESPONSAVEL_CPF_CNPJ, typeof(string));
            dt_resultadosResponsavels_PF.Columns.Add(dados_responsavel.RESPONSAVEL_RG_IE, typeof(string));
            dt_resultadosResponsavels_PF.Columns.Add(dados_responsavel_tipo.RESPONSAVEL_TIPO_NOME, typeof(string));
            dt_resultadosResponsavels_PF.Columns.Add(dados_responsavel.RESPONSAVEL_DATA_NASCIMENTO, typeof(string));

            dt_resultadosResponsavels_PJ.Columns.Add(dados_responsavel.RESPONSAVEL_CODIGO, typeof(int));
            dt_resultadosResponsavels_PJ.Columns.Add(dados_responsavel.RESPONSAVEL_NOME, typeof(string));
            dt_resultadosResponsavels_PJ.Columns.Add(dados_responsavel.RESPONSAVEL_APELIDO, typeof(string));
            dt_resultadosResponsavels_PJ.Columns.Add(dados_responsavel.RESPONSAVEL_CPF_CNPJ, typeof(string));
            dt_resultadosResponsavels_PJ.Columns.Add(dados_responsavel.RESPONSAVEL_RG_IE, typeof(string));
            dt_resultadosResponsavels_PJ.Columns.Add(dados_responsavel_tipo.RESPONSAVEL_TIPO_NOME, typeof(string));
            dt_resultadosResponsavels_PJ.Columns.Add(dados_responsavel.RESPONSAVEL_DATA_NASCIMENTO, typeof(string));
        }

        private void rbtn_pessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_pessoaJuridica.Checked)
            {
                gbx_dadosResponsavel_fisica.Hide();
                gbx_dadosResponsavel_juridica.Show();
                dtg_resultados.Columns[dados_responsavel.RESPONSAVEL_NOME].HeaderText = "RAZÃO SOCIAL";
                dtg_resultados.Columns[dados_responsavel.RESPONSAVEL_APELIDO].HeaderText = "NOME FANTASIA";
                dtg_resultados.Columns[dados_responsavel.RESPONSAVEL_CPF_CNPJ].HeaderText = "CADASTRO PESSOA JURÍDICA";
                dtg_resultados.Columns[dados_responsavel.RESPONSAVEL_RG_IE].HeaderText = "INSCRIÇÃO ESTADUAL";
                dtg_resultados.Columns[dados_responsavel.RESPONSAVEL_DATA_NASCIMENTO].HeaderText = "DATA ABERTURA";
                dtg_resultados.DataSource = dt_resultadosResponsavels_PJ;
            }
            else
            {
                gbx_dadosResponsavel_fisica.Show();
                gbx_dadosResponsavel_juridica.Hide();
            }
        }
        
        private void rbtn_pessoaFisica_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_pessoaFisica.Checked)
            {
                gbx_dadosResponsavel_fisica.Show();
                gbx_dadosResponsavel_juridica.Hide();
                dtg_resultados.Columns[dados_responsavel.RESPONSAVEL_NOME].HeaderText = "NOME";
                dtg_resultados.Columns[dados_responsavel.RESPONSAVEL_APELIDO].HeaderText = "APELIDO";
                dtg_resultados.Columns[dados_responsavel.RESPONSAVEL_CPF_CNPJ].HeaderText = "CADASTRO PESSOA FÍSICA";
                dtg_resultados.Columns[dados_responsavel.RESPONSAVEL_RG_IE].HeaderText = "REGISTRO CIVIL";
                dtg_resultados.Columns[dados_responsavel.RESPONSAVEL_DATA_NASCIMENTO].HeaderText = "DATA NASCIMENTO";
                dtg_resultados.DataSource = dt_resultadosResponsavels_PF;
            }
            else
            {
                gbx_dadosResponsavel_fisica.Hide();
                gbx_dadosResponsavel_juridica.Show();                
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
        }

        private void dtg_resultados_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //seleciona toda a linha quando clico 2x em uma celula!
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

        private void txt_codigo_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_codigo.Text, "[^0-9]"))
            {
                MessageBox.Show("Somente números!");
                txt_codigo.Text="";
            }
        }
        #endregion

        #region FUNÇÕES
        private void pesquisar()
        {
            responsavel responsavel = new responsavel();
            List<responsavel> responsavels_resultados = null;
            if (conexaoBD.abrirConexao())
            {
                try
                {
                    if (chkbx_tipoResponsavel.Checked)
                    {
                        responsavel.setCod_tipo_responsavel_responsavel_fk(Convert.ToInt32(cbx_tipo_responsavel.SelectedValue));
                    }
                    if (chkbx_codigo.Checked)
                    {
                        try
                        {
                            responsavel.setCod_responsavel_pk(Convert.ToInt32(txt_codigo.Text));
                        }
                        catch { }
                    }
                    if (utilidades.verificarTipoPessoa_rbtn(rbtn_pessoaFisica,rbtn_pessoaJuridica) == 'f') //se for pessoa física!
                    {
                        dtg_resultados.DataSource = dt_resultadosResponsavels_PF;
                        responsavel.setCod_tipo_pessoa_fk(COD_PF);
                        if (chkbx_apelido_pf.Checked)
                        {
                            responsavel.setApelido_responsavel(txt_apelido_pf.Text);
                        }
                        if (chkbx_cpf_pf.Checked)
                        {
                            responsavel.setCpfCnpj_responsavel(utilidades.captarValorMascarado_semMascara(msktxt_cpf_pf));
                        }
                        if (chkbx_rg_pf.Checked)
                        {
                            responsavel.setRgIe_responsavel(utilidades.captarValorMascarado_semMascara(msktxt_rg_pf));
                        }
                        if (chkbx_dataNasc_pf.Checked)
                        {
                            responsavel.setData_nascimento_responsavel(utilidades.captarDate_dtpckr(dtpckr_dataNascimento_pf));
                        }
                        if (chkbx_nome_pf.Checked)
                        {
                            responsavel.setNome_responsavel(txt_nome_pf.Text);
                        }                        
                    }
                    else //se for pessoa jurídica!
                    {
                        dtg_resultados.DataSource = dt_resultadosResponsavels_PJ;
                        responsavel.setCod_tipo_pessoa_fk(COD_PJ);
                        if (chkbx_nome_fantasia.Checked)
                        {
                            responsavel.setApelido_responsavel(txt_nomeFantasia_pj.Text);
                        }
                        if (chkbx_cnpj_pj.Checked)
                        {
                            responsavel.setCpfCnpj_responsavel(utilidades.captarValorMascarado_semMascara(msktxt_cnpj_pj));
                        }
                        if (chkbx_ie_pj.Checked)
                        {
                            responsavel.setRgIe_responsavel(utilidades.captarValorMascarado_semMascara(msktxt_ie_pj));
                        }
                        if (chkbx_data_abertura_pj.Checked)
                        {
                            responsavel.setData_nascimento_responsavel(utilidades.captarDate_dtpckr(dtpckr_data_abertura_pj));
                        }
                        if (chkbx_razaoSocial_pj.Checked)
                        {
                            responsavel.setNome_responsavel(txt_razaoSocial_pf.Text);
                        }                       
                    }

                    contato_responsavel contato_responsavel = null; //contato
                    if(chkbx_contato.Checked==true)
                    {
                        contato_responsavel = new contato_responsavel();
                        contato_responsavel.setTipo_contato_fk(Convert.ToInt32(cbx_tipo_contato.SelectedValue));
                        contato_responsavel.setTexto_contato_responsavel(utilidades.captarValorMascarado_semMascara(msktxt_contato).TrimStart().TrimEnd());
                    }

                    endereco_responsavel endereco_responsavel = null;//endereco
                    if (chkbx_cep.Checked)
                    {
                        endereco_responsavel = new endereco_responsavel();
                        endereco_responsavel.setCod_tipo_endereco_fk(Convert.ToInt32(cbx_tipo_endereco.SelectedValue));
                        endereco_responsavel.setTexto_endereco_responsavel(utilidades.captarValorMascarado_semMascara(msktxt_cep).TrimStart().TrimEnd());
                    }

                    //Estilos de Pesquisa!
                    if (rdbtn_igual.Checked)    //igual
                    {
                        responsavels_resultados = dados_responsavel.selecionarTodosResponsavel_ativo_porBusca_igual(responsavel, endereco_responsavel, contato_responsavel);
                    }
                    if (rdbtn_contem.Checked)   //contem
                    {
                        responsavels_resultados = dados_responsavel.selecionarTodosResponsavel_ativo_porBusca_contem(responsavel, endereco_responsavel, contato_responsavel);
                    }
                    if (rdbtn_inicio.Checked)   //inicio
                    {
                        responsavels_resultados = dados_responsavel.selecionarTodosResponsavel_ativo_porBusca_inicio(responsavel, endereco_responsavel, contato_responsavel);
                    }
                    if (rdbtn_final.Checked)   //final
                    {
                        responsavels_resultados = dados_responsavel.selecionarTodosResponsavel_ativo_porBusca_fim(responsavel, endereco_responsavel, contato_responsavel);
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show(null, "Não foi efetuar a pesquisa!\n" + erro, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
                
                if ((responsavels_resultados != null))
                {
                    if (rbtn_pessoaFisica.Checked)
                    {
                        dt_resultadosResponsavels_PF.Clear();
                        if (responsavels_resultados.Count > 0)
                        {
                            int cont = 0;
                            while (cont < responsavels_resultados.Count)
                            {
                                String tipoResp = "";
                                if(conexaoBD.abrirConexao())
                                {
                                    tipo_responsavel novoResp = new tipo_responsavel();
                                    novoResp.setCod_tipo_responsavel_pk(responsavels_resultados[cont].getCod_tipo_responsavel_responsavel_fk());
                                    tipoResp = dados_responsavel_tipo.selecionarUmTipo_porCodigo(novoResp).getNome_tipo_responsavel();
                                }
                                dt_resultadosResponsavels_PF.Rows.Add(
                                    responsavels_resultados[cont].getCod_responsavel_pk(),
                                    responsavels_resultados[cont].getNome_responsavel(),
                                    responsavels_resultados[cont].getApelido_responsavel(),
                                    utilidades.captarCnpjCpfMascarado_confomeTipoPessoa(responsavels_resultados[cont].getCod_tipo_pessoa_fk(),responsavels_resultados[cont].getCpfCnpj_responsavel()),
                                    utilidades.captarIeRgMascarado_confomeTipoPessoa(responsavels_resultados[cont].getCod_tipo_pessoa_fk(),responsavels_resultados[cont].getRgIe_responsavel()),
                                    tipoResp,
                                    responsavels_resultados[cont].getData_nascimento_responsavel().Replace("00:00:00", "")
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
                        dt_resultadosResponsavels_PJ.Clear();
                        if (responsavels_resultados.Count > 0)
                        {
                            int cont = 0;
                            while (cont < responsavels_resultados.Count)
                            {
                                String tipoResp = "";
                                if (conexaoBD.abrirConexao())
                                {
                                    tipo_responsavel novoResp = new tipo_responsavel();
                                    novoResp.setCod_tipo_responsavel_pk(responsavels_resultados[cont].getCod_tipo_responsavel_responsavel_fk());
                                    tipoResp = dados_responsavel_tipo.selecionarUmTipo_porCodigo(novoResp).getNome_tipo_responsavel();
                                }
                                dt_resultadosResponsavels_PJ.Rows.Add(
                                    responsavels_resultados[cont].getCod_responsavel_pk(),
                                    responsavels_resultados[cont].getNome_responsavel(),
                                    responsavels_resultados[cont].getApelido_responsavel(),
                                    utilidades.captarCnpjCpfMascarado_confomeTipoPessoa(responsavels_resultados[cont].getCod_tipo_pessoa_fk(), responsavels_resultados[cont].getCpfCnpj_responsavel()),
                                    utilidades.captarIeRgMascarado_confomeTipoPessoa(responsavels_resultados[cont].getCod_tipo_pessoa_fk(),responsavels_resultados[cont].getRgIe_responsavel()),
                                    tipoResp,
                                    responsavels_resultados[cont].getData_nascimento_responsavel().Replace("00:00:00", "")
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
        }

        private void carregarTipoContatos()
        {
            if (conexaoBD.abrirConexao())
            {
                //completa o combobox de tipos de contatos!
                List<tipo_contato> todosTiposContato = dados_contato_tipo.selecionarTodosTipos();
                DataTable dt_todosTiposContato = new DataTable();
                dt_todosTiposContato.Columns.Add(dados_contato_tipo.CONTATO_TIPO_CODIGO, typeof(int));
                dt_todosTiposContato.Columns.Add(dados_contato_tipo.CONTATO_TIPO_NOME, typeof(string));
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
                dt_todosTiposEndereco.Columns.Add(dados_endereco_tipo.ENDERECO_TIPO_CODIGO, typeof(int));
                dt_todosTiposEndereco.Columns.Add(dados_endereco_tipo.ENDERECO_TIPO_NOME, typeof(string));
                cbx_tipo_endereco.DataSource = dt_todosTiposEndereco;
                while (cont < todosTiposEndereco.Count)
                {
                    dt_todosTiposEndereco.Rows.Add(todosTiposEndereco[cont].getCod_tipo_endereco_pk(), todosTiposEndereco[cont].getNome_tipo_endereco());
                    cont++;
                }
            }
        }

        private void carregarTipoResponsaveis()
        {
            cbx_tipo_responsavel.ValueMember = dados_responsavel_tipo.RESPONSAVEL_TIPO_CODIGO;
            cbx_tipo_responsavel.DisplayMember = dados_responsavel_tipo.RESPONSAVEL_TIPO_NOME;
            if (conexaoBD.abrirConexao())
            {
                int cont = 0;
                //completa o combobox de tipos de responsaveis!
                List<tipo_responsavel> todosTiposResponsavel = dados_responsavel_tipo.selecionarTodosTipos();
                DataTable dt_todosTiposResponsaveis = new DataTable();
                dt_todosTiposResponsaveis.Columns.Add(dados_responsavel_tipo.RESPONSAVEL_TIPO_CODIGO, typeof(int));
                dt_todosTiposResponsaveis.Columns.Add(dados_responsavel_tipo.RESPONSAVEL_TIPO_NOME, typeof(string));
                cbx_tipo_responsavel.DataSource = dt_todosTiposResponsaveis;
                while (cont < todosTiposResponsavel.Count)
                {
                    dt_todosTiposResponsaveis.Rows.Add(todosTiposResponsavel[cont].getCod_tipo_responsavel_pk(), todosTiposResponsavel[cont].getNome_tipo_responsavel());
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
            return "Pesquisar um Responsavel";
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
    }
}


