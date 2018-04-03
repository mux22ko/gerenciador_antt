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
    public partial class Uc_responsavel_cadastro : UserControl, uc_identificacao
    {
        //MODO
        //1 = Cadastro, 2=Alteracão, 3=Leitura
        #region DADOS
        int MODO = 1; //padrao modo cadastro!
        frm_principal principal = null;
        responsavel responsavelAlvo = null; //para o modo 2 e 3!
        dados_contato_tipo dados_contato_tipo = new dados_contato_tipo();
        dados_endereco_tipo dados_endereco_tipo = new dados_endereco_tipo();
        dados_endereco_responsavel dados_endereco_responsavel = new dados_endereco_responsavel();
        dados_contato_responsavel dados_contato_responsavel = new dados_contato_responsavel();
        dados_responsavel_tipo dados_responsavel_tipo = new dados_responsavel_tipo();
        dados_responsavel dados_responsavel = new dados_responsavel();
        String mensagem01 = "Deseja realmente Cadastrar esse Responsavel?";
        String mensagem02 = "Não foi possível Cadastrar!";
        String mensagem03 = " - Cadastrado com Sucesso!";
        String mensagem04 = "Deseja realmente fechar esta aba?";
        //CODIGO PF=1 E PJ=2
        int COD_PF = 1, COD_PJ = 2;
        String baseEndereco = 
                "Endereço: " + System.Environment.NewLine +
                "Bairro: " + System.Environment.NewLine +
                "Complemento: " + System.Environment.NewLine +
                "Cidade: " + System.Environment.NewLine +
                "CEP: " + System.Environment.NewLine;
        #endregion

        #region inicializadores
        public Uc_responsavel_cadastro(frm_principal principal)
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

        public Uc_responsavel_cadastro(frm_principal principal, int modo, responsavel responsavelAlvo)
        {
            //util em modo 2/3!
            this.principal = principal;
            this.responsavelAlvo = responsavelAlvo;
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
        private void btn_adicionarContato_Click(object sender, EventArgs e)
        {
            if (utilidades.captarValorMascarado_semMascara(this.msktxt_contato).Equals(""))
            {
                //Valor vazio, faça nada!
            }
            else 
            {
                contato_responsavel contato_responsavelNovo = new contato_responsavel();
                contato_responsavelNovo.setTipo_contato_fk(Convert.ToInt32(this.cbx_tipo_contato.SelectedValue));
                contato_responsavelNovo.setTexto_contato_responsavel(utilidades.captarContatoMascarado_confomeTipoContato(contato_responsavelNovo.getTipo_contato_fk(), this.msktxt_contato.Text));
                Uc_lista_contato novoContato = new Uc_lista_contato(contato_responsavelNovo);
                this.pnl_contatos.Controls.Add(novoContato);
                msktxt_contato.Text = "";
            }
        }
        
        private void btn_adicionarEndereco_Click(object sender, EventArgs e)
        {
            if ((this.txt_endereco.Text.Equals("")) || (this.txt_endereco.Text.Equals(baseEndereco)))
            {
                //Valor vazio, faça nada!
            }
            else 
            {
                endereco_responsavel endereco_responsavelNovo = new endereco_responsavel();
                endereco_responsavelNovo.setCod_tipo_endereco_fk(Convert.ToInt32(this.cbx_tipo_endereco.SelectedValue));
                endereco_responsavelNovo.setTexto_endereco_responsavel(this.txt_endereco.Text);
                Uc_lista_endereco novoEndereco = new Uc_lista_endereco(endereco_responsavelNovo);
                this.pnl_enderecos.Controls.Add(novoEndereco);
                txt_endereco.Text = "";
            }
        }               
        
        private void btn_alterar_responsavel_Click(object sender, EventArgs e)
        {
            alterar_responsavel();
        }

        private void btn_cadastrar_responsavel_Click(object sender, EventArgs e)
        {
            cadastrar_responsavel();
        }     

        private void btn_gerarBaseEndereco_Click(object sender, EventArgs e)
        {
            this.txt_endereco.Text = this.baseEndereco;
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
        #endregion

        #region Rotinas de componentes
        private void Uc_responsavel_cadastro_Load(object sender, EventArgs e)
        {
            carregarTipoEnderecos();
            carregarTipoContatos();
            carregarTipoResponsaveis();
            carregarModo();
        }   

        private void rbtn_pessoaFisica_CheckedChanged(object sender, EventArgs e)
        {
            gbx_dadosResponsavel_fisica.Show();
            gbx_dadosResponsavel_juridica.Hide();
        }
          
        private void rbtn_pessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            gbx_dadosResponsavel_fisica.Hide();
            gbx_dadosResponsavel_juridica.Show();
        }

         private void cbx_tipo_contato_SelectedIndexChanged(object sender, EventArgs e)
         {
             utilidades.selecionarMascara_confomeContato_msktxt(Convert.ToInt32(this.cbx_tipo_contato.SelectedValue),msktxt_contato);
         }

         private void cbx_tipo_contato_DataSourceChanged(object sender, EventArgs e)
         {
             utilidades.selecionarMascara_confomeContato_msktxt(Convert.ToInt32(this.cbx_tipo_contato.SelectedValue), msktxt_contato);
         }
         private void txt_observacao_TextChanged(object sender, EventArgs e)
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

         private void txt_observacao_Validated(object sender, EventArgs e)
         {
             utilidades.colocarTexto_observacoes(txt_observacao);             
         }
        #endregion

        #region Funções
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
            if (conexaoBD.abrirConexao())
            {
                int cont = 0;
                //completa o combobox de tipos de endereços!
                List<tipo_responsavel> todosTiposResponsavel = dados_responsavel_tipo.selecionarTodosTipos();
                DataTable dt_todosTiposResponsavel = new DataTable();
                dt_todosTiposResponsavel.Columns.Add(dados_responsavel_tipo.RESPONSAVEL_TIPO_CODIGO, typeof(int));
                dt_todosTiposResponsavel.Columns.Add(dados_responsavel_tipo.RESPONSAVEL_TIPO_NOME, typeof(string));                
                cbx_tipo_responsavel.ValueMember = dados_responsavel_tipo.RESPONSAVEL_TIPO_CODIGO;
                cbx_tipo_responsavel.DisplayMember = dados_responsavel_tipo.RESPONSAVEL_TIPO_NOME;
                cbx_tipo_responsavel.DataSource = dt_todosTiposResponsavel;
                while (cont < todosTiposResponsavel.Count)
                {
                    dt_todosTiposResponsavel.Rows.Add(todosTiposResponsavel[cont].getCod_tipo_responsavel_pk(), todosTiposResponsavel[cont].getNome_tipo_responsavel());
                    cont++;
                }
            }
        }

        private bool verificarCampos()
        {
            erros.Clear();
            //validar campos: cnpj cpf
            validacaoDocs validar = new validacaoDocs();
            bool existeErros = false;
            //pessoa fisica!
            if (rbtn_pessoaFisica.Checked)
            {
                foreach (Control i in gbx_dadosResponsavel_fisica.Controls)
                {
                    //identifica as caixas de textos e maskeds!
                    if ((i.GetType() == typeof(TextBox)) || i.GetType() == typeof(MaskedTextBox))
                    {
                        TextBoxBase componente = (System.Windows.Forms.TextBoxBase) i;
                        if (componente.Text==String.Empty)
                        {                            
                            erros.SetError(i, "Campo de obrigatório preenchimento!");
                            existeErros = true;
                        }
                        if ((i.GetType() == typeof(MaskedTextBox)))
                        {
                            MaskedTextBox mascarado = (MaskedTextBox)i;
                            if (utilidades.captarValorMascarado_semMascara(mascarado) == String.Empty)
                            {
                                erros.SetError(i, "Campo de obrigatório preenchimento!");
                                existeErros = true;
                            }
                        }
                    }
                }
                if (!(validacaoDocs.validarCPF(utilidades.captarValorMascarado_semMascara(msktxt_cpf_pf))))
                {
                    erros.SetError(msktxt_cpf_pf, "CPF inválido!");
                    existeErros = true;
                }
            }
            //pessoa juridica!
            else
            {
                //caixa de dados superior!
                foreach (Control i in gbx_dadosResponsavel_juridica.Controls)
                {
                    //identifica as caixas de textos e maskeds!
                    if ((i.GetType() == typeof(TextBox)) || i.GetType() == typeof(MaskedTextBox))
                    {
                        TextBoxBase componente = (System.Windows.Forms.TextBoxBase)i;
                        if (componente.Text == String.Empty)
                        {
                            erros.SetError(i, "Campo de obrigatório preenchimento!");
                            existeErros = true;
                        }
                    } 
                    if ((i.GetType() == typeof(MaskedTextBox)))
                    {
                        MaskedTextBox mascarado = (MaskedTextBox)i;
                        if (utilidades.captarValorMascarado_semMascara(mascarado) == String.Empty)
                        {
                            erros.SetError(i, "Campo de obrigatório preenchimento!");
                            existeErros = true;
                        }
                    }
                }
                if (!(validacaoDocs.validarCNPJ(utilidades.captarValorMascarado_semMascara(msktxt_cnpj_pj))))
                {
                    erros.SetError(msktxt_cnpj_pj, "CNPJ inválido!");
                    existeErros = true;
                }
            }
            //caixa de contatos!
            if (pnl_contatos.Controls.Count < 1)
            {
                erros.SetError(pnl_contatos, "Obrigatório ter pelo menos um Contato!");
                existeErros = true;
            }
            //caixa de enderecos!
            if (pnl_enderecos.Controls.Count < 1)
            {
                erros.SetError(pnl_enderecos, "Obrigatório ter pelo menos um Endereço!");
                existeErros = true;
            }
            return existeErros; 
        }
        
        private void renovarFormulario()
        {
            pnl_enderecos.Controls.Clear();
            pnl_contatos.Controls.Clear();            
            foreach (Control i in gbx_dadosResponsavel_fisica.Controls)
            {
                if ((i.GetType() == typeof(TextBox)) || i.GetType() == typeof(MaskedTextBox))
                {
                    i.Text = "";
                }
            }
            foreach (Control i in gbx_dadosResponsavel_juridica.Controls)
            {
                if ((i.GetType() == typeof(TextBox)) || i.GetType() == typeof(MaskedTextBox))
                {
                    i.Text = "";
                }
            }
            msktxt_contato.Text = "";
            txt_observacao.Text = "";
            txt_endereco.Text = "";            
        }

        private void selecionarTipoPessoa(int num)
        {
            if (num == 1)
            {
                rbtn_pessoaFisica.Checked = true;
            }
            else
            {
                rbtn_pessoaJuridica.Checked = true;
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
                    this.btn_cadastrar_responsavel.Text = "Alterar";
                    mensagem01 = "Deseja realmente Alterar esse Responsavel?";
                    mensagem02 = "Não foi possível Alterar!";
                    mensagem03 = " - Alterado com Sucesso!";
                    carregarDados_Responsavel(this.responsavelAlvo);
                    carregarDados_Contatos(this.responsavelAlvo);
                    carregarDados_Enderecos(this.responsavelAlvo);                    
                    this.lbl_codigo_nomenclatura.Visible = true;
                    this.lbl_codigo_numero.Visible = true;
                    btn_cadastrar_responsavel.Click -= btn_cadastrar_responsavel_Click;
                    btn_cadastrar_responsavel.Click -= btn_alterar_responsavel_Click;
                    btn_cadastrar_responsavel.Click += btn_alterar_responsavel_Click;
                    lbl_codigo_numero.Visible = true;
                    lbl_codigo_nomenclatura.Visible = true;
                    break;
                case 3:
                    //Estilo Visualziar
                    renovarFormulario();
                    gbx_dadosResponsavel_juridica.Enabled = false;
                    gbx_dadosResponsavel_fisica.Enabled = false;
                    gbx_obs.Enabled = false;
                    txt_endereco.Enabled = false;
                    btn_adicionarContato.Enabled = false;
                    btn_adicionarEndereco.Enabled = false;
                    carregarDados_Responsavel(this.responsavelAlvo);
                    carregarDados_Contatos(this.responsavelAlvo);
                    carregarDados_Enderecos(this.responsavelAlvo);                    
                    this.btn_cadastrar_responsavel.Text = "Sair";
                    mensagem01 = "Deseja realmente Fechar?";
                    btn_adicionarContato.Visible = false;
                    btn_adicionarEndereco.Visible = false;
                    btn_cadastrar_responsavel.Click -= btn_cadastrar_responsavel_Click;
                    btn_cadastrar_responsavel.Click -= btn_fechar_Click;
                    btn_cadastrar_responsavel.Click += btn_fechar_Click;
                    btn_gerarBaseEndereco.Enabled = false;
                    lbl_codigo_numero.Visible = true;
                    lbl_codigo_nomenclatura.Visible = true;
                    foreach (Uc_lista_contato i in pnl_contatos.Controls)
                    {
                        i.travarExclusao();
                    }
                    foreach (Uc_lista_endereco i in pnl_enderecos.Controls)
                    {
                        i.travarExclusao();
                    }
                    break;
            }
        }

        private void cadastrar_responsavel()
        {
            if (MessageBox.Show(null, mensagem01, "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
                            responsavel responsavel = new responsavel();
                            //campo em comun!
                            responsavel.setObs_responsavel(((!txt_observacao.Text.Equals("Observações..."))) ? txt_observacao.Text : "");
                            responsavel.setCod_tipo_responsavel_responsavel_fk(Convert.ToInt32(this.cbx_tipo_responsavel.SelectedValue));

                            if (utilidades.verificarTipoPessoa_rbtn(rbtn_pessoaFisica, rbtn_pessoaJuridica) == 'f') //se for pessoa física!
                            {
                                responsavel.setApelido_responsavel(txt_apelido_pf.Text);
                                responsavel.setCod_atendente_fk(this.principal.getAtendente().getCod_atendente_pk());
                                responsavel.setCod_tipo_pessoa_fk(COD_PF);
                                responsavel.setCpfCnpj_responsavel(utilidades.captarValorMascarado_semMascara(msktxt_cpf_pf));
                                responsavel.setRgIe_responsavel(utilidades.captarValorMascarado_semMascara(msktxt_rg_pf));
                                responsavel.setData_nascimento_responsavel(utilidades.captarDate_dtpckr(dtpckr_dataNascimento_pf));
                                responsavel.setNome_responsavel(txt_nome_pf.Text);
                            }
                            else //se for pessoa jurídica!
                            {
                                responsavel.setApelido_responsavel(txt_nomeFantasia_pj.Text);
                                responsavel.setCod_atendente_fk(this.principal.getAtendente().getCod_atendente_pk());
                                responsavel.setCod_tipo_pessoa_fk(COD_PJ);
                                responsavel.setCpfCnpj_responsavel(utilidades.captarValorMascarado_semMascara(msktxt_cnpj_pj));
                                responsavel.setRgIe_responsavel(utilidades.captarValorMascarado_semMascara(msktxt_ie_pj));
                                responsavel.setData_nascimento_responsavel(utilidades.captarDate_dtpckr(dtpckr_data_abertura_pj));
                                responsavel.setNome_responsavel(txt_razaoSocial_pf.Text);
                            }
                            if (dados_responsavel.cadastrarUmResponsavel(responsavel)) //se cadastrou responsavel com sucesso!
                            {
                                //recebo os dados do responsavel cadastrado virtaulmetne no banco!
                                responsavel = dados_responsavel.selecionarUltimoResponsavel_acabouDeCadastrar();
                                foreach (Uc_lista_contato i in pnl_contatos.Controls) //cadstrando cada contato!
                                {
                                    contato_responsavel contato_responsavel = new contato_responsavel();
                                    //recebo o atual modificado do item da lista!
                                    contato_responsavel = i.getContato_responsavel_atual();
                                    //coloco os códigos do atendente + responsavel novo recem cadastrado!
                                    contato_responsavel.setCod_atendente_fk(this.principal.getAtendente().getCod_atendente_pk());
                                    contato_responsavel.setCod_responsavel_fk(responsavel.getCod_responsavel_pk());

                                    if (!(dados_contato_responsavel.cadastrarUmContato(contato_responsavel))) //se deu errado solta erro!
                                    {
                                        transacao.Rollback();
                                        transacao.Dispose();
                                        MessageBox.Show(null, mensagem02, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    }
                                }
                                foreach (Uc_lista_endereco i in pnl_enderecos.Controls) //cadstrando cada endereco!
                                {
                                    endereco_responsavel endereco_responsavel = new endereco_responsavel();
                                    //recebo o atual modificado do item da lista!
                                    endereco_responsavel = i.getEndereco_responsavel_atual();
                                    //coloco os códigos do atendente + responsavel novo recem cadastrado!
                                    endereco_responsavel.setCod_atendente_fk(this.principal.getAtendente().getCod_atendente_pk());
                                    endereco_responsavel.setCod_responsavel_fk(responsavel.getCod_responsavel_pk());

                                    if (!(dados_endereco_responsavel.cadastrarUmEndereco(endereco_responsavel))) //se deu errado solta erro!
                                    {
                                        transacao.Rollback();
                                        transacao.Dispose();
                                        MessageBox.Show(null, mensagem02, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    }
                                }
                                transacao.Commit();
                                transacao.Dispose();
                                MessageBox.Show(null, "Responsavel " + responsavel.getNome_responsavel() + mensagem03, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                renovarFormulario();
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
            }
        }

        private void alterar_responsavel()
        {
            if (MessageBox.Show(null, mensagem01, "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
                            //responsavel de dados atualizaveis!
                            responsavel responsavel = new responsavel();
                            //listas de enderecos e contatos alterados!
                            List<contato_responsavel> alteradosContatos = new List<contato_responsavel>();
                            List<endereco_responsavel> alteradosEnderecos = new List<endereco_responsavel>();
                            //listas de enderecos e contatos inalterados!
                            List<contato_responsavel> velhosContatos = new List<contato_responsavel>();
                            List<endereco_responsavel> velhosEnderecos = new List<endereco_responsavel>();
                            //listas de enderecos e contatos novos!
                            List<contato_responsavel> novosContatos = new List<contato_responsavel>();
                            List<endereco_responsavel> novosEnderecos = new List<endereco_responsavel>();
                            //listas de enderecos e contatos movimentados na transacao!
                            List<contato_responsavel> estaveisContatos = new List<contato_responsavel>();
                            List<endereco_responsavel> estaveisEnderecos = new List<endereco_responsavel>();

                            //campos em comun!
                            responsavel.setCod_responsavel_pk(Convert.ToInt32(lbl_codigo_numero.Text));
                            responsavel.setCod_atendente_fk(this.principal.getAtendente().getCod_atendente_pk());
                            responsavel.setObs_responsavel(((!txt_observacao.Text.Equals("Observações..."))) ? txt_observacao.Text : "");
                            responsavel.setCod_tipo_responsavel_responsavel_fk(Convert.ToInt32(this.cbx_tipo_responsavel.SelectedValue));

                            if (utilidades.verificarTipoPessoa_rbtn(rbtn_pessoaFisica, rbtn_pessoaJuridica) == 'f') //se for pessoa física!
                            {
                                responsavel.setApelido_responsavel(txt_apelido_pf.Text);
                                responsavel.setCod_tipo_pessoa_fk(COD_PF);
                                responsavel.setCpfCnpj_responsavel(utilidades.captarValorMascarado_semMascara(msktxt_cpf_pf));
                                responsavel.setRgIe_responsavel(utilidades.captarValorMascarado_semMascara(msktxt_rg_pf));
                                responsavel.setData_nascimento_responsavel(utilidades.captarDate_dtpckr(dtpckr_dataNascimento_pf));
                                responsavel.setNome_responsavel(txt_nome_pf.Text);
                            }
                            else //se for pessoa jurídica!
                            {
                                responsavel.setApelido_responsavel(txt_nomeFantasia_pj.Text);
                                responsavel.setCod_tipo_pessoa_fk(COD_PJ);
                                responsavel.setCpfCnpj_responsavel(utilidades.captarValorMascarado_semMascara(msktxt_cnpj_pj));
                                responsavel.setRgIe_responsavel(utilidades.captarValorMascarado_semMascara(msktxt_ie_pj));
                                responsavel.setData_nascimento_responsavel(utilidades.captarDate_dtpckr(dtpckr_data_abertura_pj));
                                responsavel.setNome_responsavel(txt_razaoSocial_pf.Text);
                            }

                            if (dados_responsavel.alterarUmResponsavelCompleto_porID(responsavel)) //se alterou responsavel com sucesso!
                            {
                                foreach (Uc_lista_contato i in pnl_contatos.Controls)  //passo por cada contato!
                                {
                                    contato_responsavel contato_responsavel = new contato_responsavel();
                                    contato_responsavel = i.getContato_responsavel_atual();
                                    if (i.situacao() == 1)//se nunca foi alterado!
                                    {
                                        //adiciono na lista de velhos inalterados!
                                        velhosContatos.Add(contato_responsavel);
                                    }
                                    else if (i.situacao() == 2)//se já foi alterado!
                                    {
                                        //adiciono na lista dos que precisam alterar!
                                        alteradosContatos.Add(contato_responsavel);
                                    }
                                    else //são novos, vamos cadastrar!
                                    {
                                        //recebe os dados de referencia que não tinham 
                                        contato_responsavel.setCod_atendente_fk(this.principal.getAtendente().getCod_atendente_pk());
                                        contato_responsavel.setCod_responsavel_fk(responsavel.getCod_responsavel_pk());
                                        //adiciono na lista dos novos!
                                        novosContatos.Add(contato_responsavel);
                                    }
                                }

                                foreach (Uc_lista_endereco i in pnl_enderecos.Controls) //passo por cada endereco!
                                {
                                    endereco_responsavel endereco_responsavel = new endereco_responsavel();
                                    endereco_responsavel = i.getEndereco_responsavel_atual();
                                    if (i.situacao() == 1)//se nunca foi alterado!
                                    {
                                        //adiciono na lista de velhos inalterados!
                                        velhosEnderecos.Add(endereco_responsavel);
                                    }
                                    else if (i.situacao() == 2)//se já foi alterado!
                                    {
                                        //o dono do registro muda!
                                        endereco_responsavel.setCod_atendente_fk(this.principal.getAtendente().getCod_atendente_pk());
                                        //adiciono na lista dos que precisam alterar!
                                        alteradosEnderecos.Add(endereco_responsavel);
                                    }
                                    else //são novos, vamos cadastrar!
                                    {
                                        //recebe os dados de referencia que não tinham 
                                        endereco_responsavel.setCod_atendente_fk(this.principal.getAtendente().getCod_atendente_pk());
                                        endereco_responsavel.setCod_responsavel_fk(responsavel.getCod_responsavel_pk());
                                        //adiciono na lista dos novos!
                                        novosEnderecos.Add(endereco_responsavel);
                                    }
                                }
                                //Alteracao / Cadastro - Contatos***********************************
                                for (int cont = 0; cont < novosContatos.Count; cont++)//Passo por cada novo a cadastrar! 3
                                {
                                    if (dados_contato_responsavel.cadastrarUmContato(novosContatos[cont])) //cadastro!
                                    {
                                        //recebo o id do recem cadastrado!
                                        contato_responsavel contatoRecem = dados_contato_responsavel.selecionarUltimoContato_acabouDeCadastrar();
                                        //adiciono na lista de estaveis!
                                        estaveisContatos.Add(contatoRecem);
                                    }
                                    else
                                    {
                                        transacao.Rollback();
                                        transacao.Dispose();
                                        MessageBox.Show(null, mensagem02, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    }
                                }
                                for (int cont = 0; cont < alteradosContatos.Count; cont++)//Passo por cada novo a alterar! 2
                                {
                                    if (dados_contato_responsavel.alterarUmContato_porCodigo(alteradosContatos[cont])) //altero!
                                    {
                                        //adiciono na lista de estaveis!
                                        estaveisContatos.Add(alteradosContatos[cont]);
                                    }
                                    else
                                    {
                                        transacao.Rollback();
                                        transacao.Dispose();
                                        MessageBox.Show(null, mensagem02, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    }
                                }
                                for (int cont = 0; cont < velhosContatos.Count; cont++)//Passo por cada velho coletando na lista de estaveis! 1
                                {
                                    //adiciono na lista de estaveis!
                                    estaveisContatos.Add(velhosContatos[cont]);
                                }

                                //Alteracao / Cadastro - Enderecos****************************************
                                for (int cont = 0; cont < novosEnderecos.Count; cont++)//Passo por cada novo a cadastrar! 3
                                {
                                    if (dados_endereco_responsavel.cadastrarUmEndereco(novosEnderecos[cont])) //cadastro!
                                    {
                                        //recebo o id do recem cadastrado!
                                        endereco_responsavel enderecoRecem = dados_endereco_responsavel.selecionarUltimoEndereco_acabouDeCadastrar();
                                        //adiciono na lista de estaveis!
                                        estaveisEnderecos.Add(enderecoRecem);
                                    }
                                    else
                                    {
                                        transacao.Rollback();
                                        transacao.Dispose();
                                        MessageBox.Show(null, mensagem02, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    }
                                }
                                for (int cont = 0; cont < alteradosEnderecos.Count; cont++)//Passo por cada novo a alterar! 2
                                {
                                    if (dados_endereco_responsavel.alterarUmEndereco_porCodigo(alteradosEnderecos[cont])) //altero!
                                    {
                                        //adiciono na lista de estaveis!
                                        estaveisEnderecos.Add(alteradosEnderecos[cont]);
                                    }
                                    else
                                    {
                                        transacao.Rollback();
                                        transacao.Dispose();
                                        MessageBox.Show(null, mensagem02, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    }
                                }
                                for (int cont = 0; cont < velhosEnderecos.Count; cont++)//Passo por cada velho coletando na lista de estaveis! 1
                                {
                                    //adiciono na lista de estaveis!
                                    estaveisEnderecos.Add(velhosEnderecos[cont]);
                                }

                                //Remove os contatos e enderecos não listados nos estaveis!
                                dados_contato_responsavel.deletarTodosContatos_excetoIds(estaveisContatos);
                                dados_endereco_responsavel.deletarTodosEnderecos_excetoIds(estaveisEnderecos);
                                //Sucesso!
                                transacao.Commit();
                                transacao.Dispose();
                                MessageBox.Show(null, "Cliente " + responsavel.getNome_responsavel() + mensagem03, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        catch (Exception erro)
                        {
                            transacao.Rollback();
                            transacao.Dispose();
                            MessageBox.Show(null, mensagem02 + "\n" + erro, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        public void carregarDados_Contatos(responsavel responsavel)
        {
            if (conexaoBD.abrirConexao())
            {
                //método utilizável caso modo 2/3
                if (responsavel != null)
                {
                    contato_responsavel contato = new contato_responsavel();
                    contato.setCod_responsavel_fk(responsavel.getCod_responsavel_pk());
                    List<contato_responsavel> contatos = dados_contato_responsavel.selecionarTodosContato_porCodigoResponsavel(contato);
                    int cont = 0;
                    for (cont = 0; cont < contatos.Count; cont++)
                    {
                        //novo item da lista!
                        Uc_lista_contato novoContato = new Uc_lista_contato(contatos[cont]);                        
                        this.pnl_contatos.Controls.Add(novoContato);
                    }
                }
            }
        }

        public void carregarDados_Enderecos(responsavel responsavel)
        {
            if (conexaoBD.abrirConexao())
            {
                //método utilizável caso modo 2/3
                if (responsavel != null)
                {
                    endereco_responsavel endereco = new endereco_responsavel();
                    endereco.setCod_responsavel_fk(responsavel.getCod_responsavel_pk());
                    List<endereco_responsavel> enderecos = dados_endereco_responsavel.selecionarTodosEndereco_porCodigoResponsavel(endereco);
                    int cont = 0;
                    for (cont = 0; cont < enderecos.Count; cont++)
                    {
                        //novo item da lista!
                        Uc_lista_endereco novoEndereco = new Uc_lista_endereco(enderecos[cont]); 
                        this.pnl_enderecos.Controls.Add(novoEndereco);
                    }
                }
            }
        }

        public void carregarDados_Responsavel(responsavel responsavel)
        {
            if (conexaoBD.abrirConexao())
            {
                responsavel = dados_responsavel.selecionarUmResponsavel_porCodigo(responsavel);
            }
            //método utilizável caso modo 2/3
            selecionarTipoPessoa(responsavel.getCod_tipo_pessoa_fk());
            lbl_codigo_numero.Text = responsavel.getCod_responsavel_pk().ToString();
            utilidades.selcionarCorrespondente_porValor(cbx_tipo_responsavel,responsavel.getCod_tipo_responsavel_responsavel_fk());
            txt_observacao.Text = responsavel.getObs_responsavel();
            if (responsavel != null)
            {
                if (utilidades.verificarTipoPessoa_rbtn(rbtn_pessoaFisica, rbtn_pessoaJuridica) == 'f') //se for pessoa física!
                {                    
                    txt_apelido_pf.Text = responsavel.getApelido_responsavel();
                    msktxt_cpf_pf.Text = responsavel.getCpfCnpj_responsavel();
                    msktxt_rg_pf.Text = responsavel.getRgIe_responsavel();
                    dtpckr_dataNascimento_pf.Text = utilidades.captarDate_banco(responsavel.getData_nascimento_responsavel());
                    txt_nome_pf.Text = responsavel.getNome_responsavel();
                    rbtn_pessoaJuridica.Enabled = false;
                }
                else //se for pessoa jurídica!
                {
                    txt_nomeFantasia_pj.Text = responsavel.getApelido_responsavel();
                    msktxt_cnpj_pj.Text = responsavel.getCpfCnpj_responsavel();
                    msktxt_ie_pj.Text = responsavel.getRgIe_responsavel();
                    dtpckr_data_abertura_pj.Text = utilidades.captarDate_banco(responsavel.getData_nascimento_responsavel());
                    txt_razaoSocial_pf.Text = responsavel.getNome_responsavel();
                    rbtn_pessoaFisica.Enabled = false;
                }
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
                return "Alterar o Responsavel: "+responsavelAlvo.getNome_responsavel();
            }
            if (MODO == 3)
            {
                return "Verificar um Responsavel Selecionado";
            }
            return "Cadastrar um novo Responsavel";
        }
        public Object getControleAbas()
        {
            return null;
        }
        #endregion
        
    }
}
