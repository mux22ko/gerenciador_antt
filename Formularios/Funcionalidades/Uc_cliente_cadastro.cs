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
    public partial class Uc_cliente_cadastro : UserControl, uc_identificacao
    {
        //MODO
        //1 = Cadastro, 2=Alteracão, 3=Leitura
        #region DADOS
        int MODO = 1; //padrao modo cadastro!
        frm_principal principal = null;
        //para o modo 2 e 3!
        cliente clienteAlvo = null; 
        dados_contato_tipo dados_contato_tipo = new dados_contato_tipo();
        dados_endereco_tipo dados_endereco_tipo = new dados_endereco_tipo();
        dados_endereco_cliente dados_endereco_cliente = new dados_endereco_cliente();
        dados_contato_cliente dados_contato_cliente = new dados_contato_cliente();
        dados_cliente dados_cliente = new dados_cliente();
        String mensagem01 = "Deseja realmente Cadastrar esse Cliente?";
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
        public Uc_cliente_cadastro(frm_principal principal)
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
       
        public Uc_cliente_cadastro(frm_principal principal, int modo, cliente clienteAlvo)
        {
            //util em modo 2/3!
            this.principal = principal;
            this.clienteAlvo = clienteAlvo;
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
                contato_cliente contato_clienteNovo = new contato_cliente();
                contato_clienteNovo.setCod_atendente_fk(principal.getAtendente().getCod_atendente_pk());
                contato_clienteNovo.setTexto_contato_cliente(utilidades.captarValorMascarado_semMascara(msktxt_contato));
                contato_clienteNovo.setTipo_contato_fk(Convert.ToInt32(cbx_tipo_contato.SelectedValue));

                Uc_lista_contato novoContato = new Uc_lista_contato(contato_clienteNovo);                
               // novoContato.encaixarComponente(this.pnl_contatos);
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
                endereco_cliente endereco_clienteNovo = new endereco_cliente();
                endereco_clienteNovo.setCod_atendente_fk(principal.getAtendente().getCod_atendente_pk());
                endereco_clienteNovo.setTexto_endereco_cliente(txt_endereco.Text);
                endereco_clienteNovo.setCod_tipo_endereco_fk(Convert.ToInt32(cbx_tipo_endereco.SelectedValue));

                Uc_lista_endereco novoEndereco = new Uc_lista_endereco(endereco_clienteNovo);
                this.pnl_enderecos.Controls.Add(novoEndereco);
                txt_endereco.Text = "";
            }
        }               
        
        private void btn_alterar_cliente_Click(object sender, EventArgs e)
        {
            alterar_cliente();
        }

        private void btn_cadastrar_cliente_Click(object sender, EventArgs e)
        {
            cadastrar_cliente();
        }     

        private void btn_gerarBaseEndereco_Click(object sender, EventArgs e)
        {
            //gero a base de escrita do endereço!
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
        private void Uc_cliente_cadastro_Load(object sender, EventArgs e)
        {
            carregarTipoEnderecos(); //encho de dados os tipos de enderecos!
            carregarTipoContatos(); //encho de dados os tipos de contatos!
            carregarModo(); //carrego do modo que ele foi setado!
        }

        private void rbtn_pessoaFisica_CheckedChanged(object sender, EventArgs e)
        {
            //mostrar os dados condizentes ao tipo físico!
            gbx_dadosCliente_fisica.Show();
            gbx_dadosCliente_juridica.Hide();
        }

        private void rbtn_pessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            //mostrar os dados condizentes ao tipo juridico!
            gbx_dadosCliente_fisica.Hide();
            gbx_dadosCliente_juridica.Show();
        }

         private void cbx_tipo_contato_SelectedIndexChanged(object sender, EventArgs e)
         {
             //Carregar a mascara do contato conforme o tipo é selecionado!
             utilidades.selecionarMascara_confomeContato_msktxt(Convert.ToInt32(this.cbx_tipo_contato.SelectedValue),msktxt_contato);
         }

         private void cbx_tipo_contato_DataSourceChanged(object sender, EventArgs e)
         {
             //Carregar a mascara do contato conforme o tipo, este é um método para fazer isso quando já recebe dados!
             utilidades.selecionarMascara_confomeContato_msktxt(Convert.ToInt32(this.cbx_tipo_contato.SelectedValue), msktxt_contato);
         } 

        private void msktxt_rntrc_Validated(object sender, EventArgs e)
        {
            MaskedTextBox msktxt = (MaskedTextBox)sender;
            msktxt.Text = msktxt.Text.ToUpper();
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

        private bool verificarCampos()
        {
            erros.Clear();
            //validar campos: cnpj cpf
            validacaoDocs validar = new validacaoDocs();
            bool existeErros = false;
            //pessoa fisica!
            if (rbtn_pessoaFisica.Checked)
            {
                foreach (Control i in gbx_dadosCliente_fisica.Controls)
                {
                    //identifica as caixas de textos e maskeds!
                    if ((i.GetType() == typeof(TextBox)) || i.GetType() == typeof(MaskedTextBox))
                    {
                        TextBoxBase componente = (System.Windows.Forms.TextBoxBase)i;
                        if (componente.Text == String.Empty)
                        {
                            //exclusao de verificar tal campo!
                            if (componente != txt_apelido_pf)
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
                }
                if (!(validacaoDocs.validarCPF(utilidades.captarValorMascarado_semMascara(msktxt_cpf_pf))))
                {
                    erros.SetError(msktxt_cpf_pf, "CPF inválido!");
                    existeErros = true;
                }
                else //verificar se ja tem cadastro ativo nesse cpf/cnpj
                {
                    //se nao for modo 3 nem 2 realiza a trava de cadastro de cpf
                    if (!((MODO == 3) ||(MODO == 2)))
                    {
                        if (conexaoBD.abrirConexao())
                        {
                            try
                            {
                                //cliente de dados comparaveis!
                                cliente cliente = new cliente();
                                cliente.setCpfCnpj_cliente(utilidades.captarValorMascarado_semMascara(msktxt_cpf_pf));
                                cliente = dados_cliente.selecionarUmCliente_porCpfCnpj(cliente);
                                if (cliente.getCod_cliente_pk() != 0) //identificando algo
                                {
                                    erros.SetError(msktxt_cpf_pf, "CPF já cadastrado! - " + cliente.getNome_cliente() + " : Cód.:" + cliente.getCod_cliente_pk());
                                    existeErros = true;
                                }
                            }
                            catch (Exception erro)
                            {
                                MessageBox.Show(null, mensagem02 + "\n" + erro, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            //pessoa juridica!
            else
            {
                //caixa de dados superior!
                foreach (Control i in gbx_dadosCliente_juridica.Controls)
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
                else //verificar se ja tem cadastro ativo nesse cpf/cnpj
                {
                    if (conexaoBD.abrirConexao())
                    {
                        try
                        {
                            //cliente de dados comparaveis!
                            cliente cliente = new cliente();
                            cliente.setCpfCnpj_cliente(utilidades.captarValorMascarado_semMascara(msktxt_cnpj_pj));
                            cliente = dados_cliente.selecionarUmCliente_porCpfCnpj(cliente);
                            if (cliente.getCod_cliente_pk() != 0) //identificando algo
                            {
                                erros.SetError(msktxt_cnpj_pj, "CPF já cadastrado! - " + cliente.getNome_cliente() + " : Cód.:" + cliente.getCod_cliente_pk());
                                existeErros = true;
                            }
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show(null, mensagem02 + "\n" + erro, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
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

        private void cadastrar_cliente()
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
                            cliente cliente = new cliente();
                            if (utilidades.verificarTipoPessoa_rbtn(rbtn_pessoaFisica, rbtn_pessoaJuridica) == 'f') //se for pessoa física!
                            {
                                cliente.setApelido_cliente(txt_apelido_pf.Text);
                                cliente.setCod_atendente_fk(this.principal.getAtendente().getCod_atendente_pk());
                                cliente.setCod_tipo_pessoa_fk(COD_PF);
                                cliente.setCpfCnpj_cliente(utilidades.captarValorMascarado_semMascara(msktxt_cpf_pf));
                                cliente.setRgIe_cliente(utilidades.captarValorMascarado_semMascara(msktxt_rg_pf));
                                cliente.setData_nascimento_cliente(utilidades.captarDate_dtpckr(dtpckr_dataNascimento_pf));
                                cliente.setNome_cliente(txt_nome_pf.Text);
                                cliente.setRntrc_cliente(utilidades.captarValorMascarado_semMascara(msktxt_rntrc_pf));
                            }
                            else //se for pessoa jurídica!
                            {
                                cliente.setApelido_cliente(txt_nomeFantasia_pj.Text);
                                cliente.setCod_atendente_fk(this.principal.getAtendente().getCod_atendente_pk());
                                cliente.setCod_tipo_pessoa_fk(COD_PJ);
                                cliente.setCpfCnpj_cliente(utilidades.captarValorMascarado_semMascara(msktxt_cnpj_pj));
                                cliente.setRgIe_cliente(utilidades.captarValorMascarado_semMascara(msktxt_ie_pj));
                                cliente.setData_nascimento_cliente(utilidades.captarDate_dtpckr(dtpckr_data_abertura_pj));
                                cliente.setNome_cliente(txt_razaoSocial_pf.Text);
                                cliente.setRntrc_cliente(utilidades.captarValorMascarado_semMascara(msktxt_rntrc_pj));
                            }
                            cliente.setObs_cliente(((!txt_observacao.Text.Equals("Observações..."))) ? txt_observacao.Text : ""); //campo em comun!
                            if (dados_cliente.cadastrarUmCliente(cliente)) //se cadastrou cliente com sucesso!
                            {
                                //recebo os dados do cliente cadastrado virtaulmetne no banco!
                                cliente = dados_cliente.selecionarUltimoCliente_acabouDeCadastrar();

                                foreach (Uc_lista_contato i in pnl_contatos.Controls) //cadastrando cada contato novo!
                                {
                                    contato_cliente contato_cliente = new contato_cliente();
                                    //recebo o atual modificado do item da lista!
                                    contato_cliente = i.getContato_cliente_atual();
                                    //coloco os códigos do atendente + cliente novo recem cadastrado!
                                    contato_cliente.setCod_atendente_fk(this.principal.getAtendente().getCod_atendente_pk());
                                    contato_cliente.setCod_cliente_fk(cliente.getCod_cliente_pk());

                                    if (!(dados_contato_cliente.cadastrarUmContato(contato_cliente))) //se deu errado cadastrar solta erro e cancela tudo!
                                    {
                                        transacao.Rollback();
                                        transacao.Dispose();
                                        MessageBox.Show(null, mensagem02, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    }
                                }
                                foreach (Uc_lista_endereco i in pnl_enderecos.Controls) //cadstrando cada endereco!
                                {
                                    endereco_cliente endereco_cliente = new endereco_cliente();
                                    //recebo o atual modificado do item da lista!
                                    endereco_cliente = i.getEndereco_cliente_atual();
                                    //coloco os códigos do atendente + cliente novo recem cadastrado!
                                    endereco_cliente.setCod_atendente_fk(this.principal.getAtendente().getCod_atendente_pk());
                                    endereco_cliente.setCod_cliente_fk(cliente.getCod_cliente_pk());

                                    if (!(dados_endereco_cliente.cadastrarUmEndereco(endereco_cliente))) //se deu errado cadastrar solta erro e cancela tudo!
                                    {
                                        transacao.Rollback();
                                        transacao.Dispose();
                                        MessageBox.Show(null, mensagem02, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    }
                                }
                                transacao.Commit();
                                transacao.Dispose();
                                MessageBox.Show(null, "Cliente " + cliente.getNome_cliente() + mensagem03, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void alterar_cliente() 
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
                            //cliente de dados atualizaveis!
                            cliente cliente = new cliente();
                            //listas de enderecos e contatos alterados!
                            List<contato_cliente> alteradosContatos = new List<contato_cliente>();
                            List<endereco_cliente> alteradosEnderecos = new List<endereco_cliente>();
                            //listas de enderecos e contatos inalterados!
                            List<contato_cliente> velhosContatos = new List<contato_cliente>();
                            List<endereco_cliente> velhosEnderecos = new List<endereco_cliente>();
                            //listas de enderecos e contatos novos!
                            List<contato_cliente> novosContatos = new List<contato_cliente>();
                            List<endereco_cliente> novosEnderecos = new List<endereco_cliente>();
                            //listas de enderecos e contatos movimentados na transacao!
                            List<contato_cliente> estaveisContatos = new List<contato_cliente>();
                            List<endereco_cliente> estaveisEnderecos = new List<endereco_cliente>();
                            //campos em comun!
                            cliente.setCod_cliente_pk(Convert.ToInt32(lbl_codigo_numero.Text));
                            cliente.setCod_atendente_fk(this.principal.getAtendente().getCod_atendente_pk());
                            cliente.setObs_cliente(((!txt_observacao.Text.Equals("Observações..."))) ? txt_observacao.Text : "");

                            if (utilidades.verificarTipoPessoa_rbtn(rbtn_pessoaFisica, rbtn_pessoaJuridica) == 'f') //se for pessoa física!
                            {
                                cliente.setApelido_cliente(txt_apelido_pf.Text);
                                cliente.setCod_tipo_pessoa_fk(COD_PF);
                                cliente.setCpfCnpj_cliente(utilidades.captarValorMascarado_semMascara(msktxt_cpf_pf));
                                cliente.setRgIe_cliente(utilidades.captarValorMascarado_semMascara(msktxt_rg_pf));
                                cliente.setData_nascimento_cliente(utilidades.captarDate_dtpckr(dtpckr_dataNascimento_pf));
                                cliente.setNome_cliente(txt_nome_pf.Text);
                                cliente.setRntrc_cliente(utilidades.captarValorMascarado_semMascara(msktxt_rntrc_pf));
                            }
                            else //se for pessoa jurídica!
                            {
                                cliente.setApelido_cliente(txt_nomeFantasia_pj.Text);
                                cliente.setCod_tipo_pessoa_fk(COD_PJ);
                                cliente.setCpfCnpj_cliente(utilidades.captarValorMascarado_semMascara(msktxt_cnpj_pj));
                                cliente.setRgIe_cliente(utilidades.captarValorMascarado_semMascara(msktxt_ie_pj));
                                cliente.setData_nascimento_cliente(utilidades.captarDate_dtpckr(dtpckr_data_abertura_pj));
                                cliente.setNome_cliente(txt_razaoSocial_pf.Text);
                                cliente.setRntrc_cliente(utilidades.captarValorMascarado_semMascara(msktxt_rntrc_pj));
                            }

                            if (dados_cliente.alterarUmClienteCompleto_porID(cliente)) //se alterou cliente com sucesso!
                            {
                                foreach (Uc_lista_contato i in pnl_contatos.Controls) //passo por cada contato!
                                {
                                    contato_cliente contato_cliente = new contato_cliente();
                                    contato_cliente = i.getContato_cliente_atual();
                                    if (i.situacao() == 1)//se nunca foi alterado!
                                    {
                                        //adiciono na lista de velhos inalterados!
                                        velhosContatos.Add(contato_cliente);
                                    }
                                    else if (i.situacao() == 2)//se já foi alterado!
                                    {
                                        //adiciono na lista dos que precisam alterar!
                                        alteradosContatos.Add(contato_cliente);
                                    }
                                    else //são novos, vamos cadastrar!
                                    {
                                        //recebe os dados de referencia que não tinham 
                                        contato_cliente.setCod_atendente_fk(this.principal.getAtendente().getCod_atendente_pk());
                                        contato_cliente.setCod_cliente_fk(cliente.getCod_cliente_pk());
                                        //adiciono na lista dos novos!
                                        novosContatos.Add(contato_cliente);
                                    }
                                }

                                foreach (Uc_lista_endereco i in pnl_enderecos.Controls) //cadstrando cada endereco!
                                {
                                    endereco_cliente endereco_cliente = new endereco_cliente();
                                    endereco_cliente = i.getEndereco_cliente_atual();
                                    if (i.situacao() == 1)//se nunca foi alterado!
                                    {
                                        //adiciono na lista de velhos inalterados!
                                        velhosEnderecos.Add(endereco_cliente);
                                    }
                                    else if (i.situacao() == 2)//se já foi alterado!
                                    {
                                        //o dono do registro muda!
                                        endereco_cliente.setCod_atendente_fk(this.principal.getAtendente().getCod_atendente_pk());
                                        //adiciono na lista dos que precisam alterar!
                                        alteradosEnderecos.Add(endereco_cliente);
                                    }
                                    else //são novos, vamos cadastrar!
                                    {
                                        //recebe os dados de referencia que não tinham 
                                        endereco_cliente.setCod_atendente_fk(this.principal.getAtendente().getCod_atendente_pk());
                                        endereco_cliente.setCod_cliente_fk(cliente.getCod_cliente_pk());
                                        //adiciono na lista dos novos!
                                        novosEnderecos.Add(endereco_cliente);
                                    }
                                }
                                //Alteracao / Cadastro - Contatos***********************************
                                for (int cont = 0; cont < novosContatos.Count; cont++)//Passo por cada novo a cadastrar! 3
                                {
                                    if (dados_contato_cliente.cadastrarUmContato(novosContatos[cont])) //cadastro!
                                    {
                                        //recebo o id do recem cadastrado!
                                        contato_cliente contatoRecem = dados_contato_cliente.selecionarUltimoContato_acabouDeCadastrar();
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
                                    if (dados_contato_cliente.alterarUmContato_porCodigo(alteradosContatos[cont])) //altero!
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
                                    if (dados_endereco_cliente.cadastrarUmEndereco(novosEnderecos[cont])) //cadastro!
                                    {
                                        //recebo o id do recem cadastrado!
                                        endereco_cliente enderecoRecem = dados_endereco_cliente.selecionarUltimoEndereco_acabouDeCadastrar();
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
                                    if (dados_endereco_cliente.alterarUmEndereco_porCodigo(alteradosEnderecos[cont])) //altero!
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
                                dados_contato_cliente.deletarTodosContatos_excetoIds(estaveisContatos);
                                dados_endereco_cliente.deletarTodosEnderecos_excetoIds(estaveisEnderecos);
                                //Sucesso!
                                transacao.Commit();
                                transacao.Dispose();
                                MessageBox.Show(null, "Cliente " + cliente.getNome_cliente() + mensagem03, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void renovarFormulario()
        {
            pnl_enderecos.Controls.Clear();
            pnl_contatos.Controls.Clear();            
            foreach (Control i in gbx_dadosCliente_fisica.Controls)
            {
                if ((i.GetType() == typeof(TextBox)) || i.GetType() == typeof(MaskedTextBox))
                {
                    i.Text = "";
                }
            }
            foreach (Control i in gbx_dadosCliente_juridica.Controls)
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
                    this.btn_cadastrar_cliente.Text = "Alterar";
                    mensagem01 = "Deseja realmente Alterar esse Cliente?";
                    mensagem02 = "Não foi possível Alterar!";
                    mensagem03 = " - Alterado com Sucesso!";
                    carregarDados_Cliente(this.clienteAlvo);
                    carregarDados_Contatos(this.clienteAlvo);
                    carregarDados_Enderecos(this.clienteAlvo);
                    this.lbl_codigo_nomenclatura.Visible = true;
                    this.lbl_codigo_numero.Visible = true;
                    btn_cadastrar_cliente.Click -= btn_cadastrar_cliente_Click;
                    btn_cadastrar_cliente.Click -= btn_alterar_cliente_Click;
                    btn_cadastrar_cliente.Click += btn_alterar_cliente_Click;
                    lbl_codigo_numero.Visible = true;
                    lbl_codigo_nomenclatura.Visible = true;
                    break;
                case 3:
                    //Estilo Visualziar
                    gbx_dadosCliente_juridica.Enabled = false;
                    gbx_dadosCliente_fisica.Enabled = false;
                    gbx_obs.Enabled = false;
                    txt_endereco.Enabled = false;
                    btn_adicionarContato.Enabled = false;
                    btn_adicionarEndereco.Enabled = false;                    
                    carregarDados_Cliente(this.clienteAlvo);
                    carregarDados_Contatos(this.clienteAlvo);
                    carregarDados_Enderecos(this.clienteAlvo);
                    this.btn_cadastrar_cliente.Text = "Sair";
                    mensagem01 = "Deseja realmente Fechar?";
                    btn_adicionarContato.Visible = false;
                    btn_adicionarEndereco.Visible = false;
                    btn_cadastrar_cliente.Click -= btn_cadastrar_cliente_Click;
                    btn_cadastrar_cliente.Click -= btn_fechar_Click;
                    btn_cadastrar_cliente.Click += btn_fechar_Click;
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

        public void carregarDados_Contatos(cliente cliente)
        {
            if (conexaoBD.abrirConexao())
            {
                //método utilizável caso modo 2/3
                if (cliente != null)
                {
                    contato_cliente contato = new contato_cliente();
                    contato.setCod_cliente_fk(cliente.getCod_cliente_pk());
                    List<contato_cliente> contatos = dados_contato_cliente.selecionarTodosContato_porCodigoCliente(contato);
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

        public void carregarDados_Enderecos(cliente cliente)
        {
            if (conexaoBD.abrirConexao())
            {
                //método utilizável caso modo 2/3
                if (cliente != null)
                {
                    endereco_cliente endereco = new endereco_cliente();
                    endereco.setCod_cliente_fk(cliente.getCod_cliente_pk());
                    List<endereco_cliente> enderecos = dados_endereco_cliente.selecionarTodosEndereco_porCodigoCliente(endereco);
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

        public void carregarDados_Cliente(cliente cliente)
        {
            if (conexaoBD.abrirConexao())
            {
                cliente = dados_cliente.selecionarUmCliente_porCodigo(cliente);
            }
            selecionarTipoPessoa(cliente.getCod_tipo_pessoa_fk());
            lbl_codigo_numero.Text = cliente.getCod_cliente_pk().ToString();
            txt_observacao.Text = cliente.getObs_cliente();
            //método utilizável caso modo 2/3
            if (cliente != null)
            {
                if (utilidades.verificarTipoPessoa_rbtn(rbtn_pessoaFisica, rbtn_pessoaJuridica) == 'f') //se for pessoa física!
                {                    
                    txt_apelido_pf.Text = cliente.getApelido_cliente();
                    msktxt_cpf_pf.Text = cliente.getCpfCnpj_cliente();
                    msktxt_rg_pf.Text = cliente.getRgIe_cliente();
                    dtpckr_dataNascimento_pf.Text = utilidades.captarDate_banco(cliente.getData_nascimento_cliente());
                    txt_nome_pf.Text = cliente.getNome_cliente();
                    msktxt_rntrc_pf.Text = cliente.getRntrc_cliente();
                    rbtn_pessoaJuridica.Enabled = false;
                }
                else //se for pessoa jurídica!
                {
                    txt_nomeFantasia_pj.Text = cliente.getApelido_cliente();
                    msktxt_cnpj_pj.Text = cliente.getCpfCnpj_cliente();
                    msktxt_ie_pj.Text = cliente.getRgIe_cliente();
                    dtpckr_data_abertura_pj.Text = utilidades.captarDate_banco(cliente.getData_nascimento_cliente());
                    txt_razaoSocial_pf.Text = cliente.getNome_cliente();
                    msktxt_rntrc_pj.Text = cliente.getRntrc_cliente();
                    rbtn_pessoaFisica.Enabled = false;
                }
            }
        }

        public int getModoAtual()
        {
            return this.MODO;
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
            if (MODO == 2)
            {
                return "Alterar o Cliente: "+clienteAlvo.getNome_cliente();
            }
            if (MODO == 3)
            {
                return "Verificar um Cliente Selecionado";
            }
            return "Cadastrar um novo Cliente";
        }
        public Object getControleAbas()
        {
            return null;
        }
        #endregion                 

        private void gbx_contatoCliente_SizeChanged(object sender, EventArgs e)
        {
            if (this.gbx_contatoCliente.Size.Width < 176)
            {
                this.gbx_contatoCliente.Size = new Size(176,this.gbx_contatoCliente.Size.Height);
                this.gbx_enderecos.Size = new Size(205,gbx_enderecos.Size.Height);
                int primeiroComponente = (this.gbx_contatoCliente.Location.X + this.gbx_contatoCliente.Size.Width);
                this.gbx_enderecos.Location = new Point(primeiroComponente+15, this.gbx_contatoCliente.Location.Y);
            }
        }
    }
}
