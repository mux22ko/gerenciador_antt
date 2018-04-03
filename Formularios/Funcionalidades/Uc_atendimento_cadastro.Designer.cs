namespace gerenciador_antt.Formularios
{
    partial class Uc_atendimento_cadastro
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.gbx_dadosSelecionados = new System.Windows.Forms.GroupBox();
            this.chkbx_ativarCliente = new System.Windows.Forms.CheckBox();
            this.btn_pesquisarCliente = new System.Windows.Forms.Button();
            this.cbx_cliente = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkbx_ativarResponsavel = new System.Windows.Forms.CheckBox();
            this.btn_pesquisarResponsavel = new System.Windows.Forms.Button();
            this.cbx_responsavel = new System.Windows.Forms.ComboBox();
            this.gbx_atendimento_servico = new System.Windows.Forms.GroupBox();
            this.txt_descricao_servico = new System.Windows.Forms.TextBox();
            this.btn_alterarValor = new System.Windows.Forms.Button();
            this.txt_descontado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_valor_servico = new System.Windows.Forms.TextBox();
            this.btn_receberPreco = new System.Windows.Forms.Button();
            this.btn_adicionarServico = new System.Windows.Forms.Button();
            this.gbx_items_servicosAdicionados = new System.Windows.Forms.GroupBox();
            this.txt_qtd_items_adicionados = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_valor_total = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnl_servicos_prestados = new System.Windows.Forms.Panel();
            this.cbx_servico = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_observacao = new System.Windows.Forms.TextBox();
            this.gbx_obs = new System.Windows.Forms.GroupBox();
            this.erros = new System.Windows.Forms.ErrorProvider(this.components);
            this.btn_cadastrar_atendimento = new System.Windows.Forms.Button();
            this.pnl_centro = new System.Windows.Forms.Panel();
            this.gbx_opcoes = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkbx_totalmenteFinalizado = new System.Windows.Forms.CheckBox();
            this.chkbx_totalmentePago = new System.Windows.Forms.CheckBox();
            this.pnl_fechar = new System.Windows.Forms.Panel();
            this.btn_fechar = new System.Windows.Forms.Button();
            this.lbl_fechar = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_codigo_nomenclatura = new System.Windows.Forms.Label();
            this.lbl_codigo_numero = new System.Windows.Forms.Label();
            this.gbx_dadosSelecionados.SuspendLayout();
            this.gbx_atendimento_servico.SuspendLayout();
            this.gbx_items_servicosAdicionados.SuspendLayout();
            this.gbx_obs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erros)).BeginInit();
            this.pnl_centro.SuspendLayout();
            this.gbx_opcoes.SuspendLayout();
            this.pnl_fechar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Responsável:";
            // 
            // gbx_dadosSelecionados
            // 
            this.gbx_dadosSelecionados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_dadosSelecionados.Controls.Add(this.chkbx_ativarCliente);
            this.gbx_dadosSelecionados.Controls.Add(this.btn_pesquisarCliente);
            this.gbx_dadosSelecionados.Controls.Add(this.cbx_cliente);
            this.gbx_dadosSelecionados.Controls.Add(this.label4);
            this.gbx_dadosSelecionados.Controls.Add(this.chkbx_ativarResponsavel);
            this.gbx_dadosSelecionados.Controls.Add(this.btn_pesquisarResponsavel);
            this.gbx_dadosSelecionados.Controls.Add(this.cbx_responsavel);
            this.gbx_dadosSelecionados.Controls.Add(this.label1);
            this.gbx_dadosSelecionados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbx_dadosSelecionados.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbx_dadosSelecionados.ForeColor = System.Drawing.Color.DimGray;
            this.erros.SetIconPadding(this.gbx_dadosSelecionados, -100);
            this.gbx_dadosSelecionados.Location = new System.Drawing.Point(9, 36);
            this.gbx_dadosSelecionados.Name = "gbx_dadosSelecionados";
            this.gbx_dadosSelecionados.Size = new System.Drawing.Size(985, 114);
            this.gbx_dadosSelecionados.TabIndex = 0;
            this.gbx_dadosSelecionados.TabStop = false;
            this.gbx_dadosSelecionados.Text = "Selecionar";
            // 
            // chkbx_ativarCliente
            // 
            this.chkbx_ativarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkbx_ativarCliente.AutoSize = true;
            this.chkbx_ativarCliente.ForeColor = System.Drawing.Color.Green;
            this.chkbx_ativarCliente.Location = new System.Drawing.Point(888, 69);
            this.chkbx_ativarCliente.Name = "chkbx_ativarCliente";
            this.chkbx_ativarCliente.Size = new System.Drawing.Size(70, 25);
            this.chkbx_ativarCliente.TabIndex = 1;
            this.chkbx_ativarCliente.Text = "Ativar";
            this.chkbx_ativarCliente.UseVisualStyleBackColor = true;
            this.chkbx_ativarCliente.CheckedChanged += new System.EventHandler(this.chkbx_ativarCliente_CheckedChanged);
            // 
            // btn_pesquisarCliente
            // 
            this.btn_pesquisarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_pesquisarCliente.BackColor = System.Drawing.Color.Gray;
            this.btn_pesquisarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_pesquisarCliente.Enabled = false;
            this.btn_pesquisarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pesquisarCliente.ForeColor = System.Drawing.Color.White;
            this.btn_pesquisarCliente.Image = global::gerenciador_antt.Properties.Resources.procurar_lupa_micro;
            this.btn_pesquisarCliente.Location = new System.Drawing.Point(851, 67);
            this.btn_pesquisarCliente.Name = "btn_pesquisarCliente";
            this.btn_pesquisarCliente.Size = new System.Drawing.Size(30, 29);
            this.btn_pesquisarCliente.TabIndex = 14;
            this.btn_pesquisarCliente.TabStop = false;
            this.btn_pesquisarCliente.UseVisualStyleBackColor = false;
            this.btn_pesquisarCliente.Click += new System.EventHandler(this.btn_pesquisarCliente_Click);
            // 
            // cbx_cliente
            // 
            this.cbx_cliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_cliente.BackColor = System.Drawing.Color.Gainsboro;
            this.cbx_cliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_cliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbx_cliente.FormattingEnabled = true;
            this.cbx_cliente.Location = new System.Drawing.Point(114, 67);
            this.cbx_cliente.Name = "cbx_cliente";
            this.cbx_cliente.Size = new System.Drawing.Size(733, 29);
            this.cbx_cliente.TabIndex = 13;
            this.cbx_cliente.TabStop = false;
            this.cbx_cliente.Validated += new System.EventHandler(this.cbx_cliente_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(50, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 21);
            this.label4.TabIndex = 12;
            this.label4.Text = "Cliente:";
            // 
            // chkbx_ativarResponsavel
            // 
            this.chkbx_ativarResponsavel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkbx_ativarResponsavel.AutoSize = true;
            this.chkbx_ativarResponsavel.ForeColor = System.Drawing.Color.Green;
            this.chkbx_ativarResponsavel.Location = new System.Drawing.Point(888, 33);
            this.chkbx_ativarResponsavel.Name = "chkbx_ativarResponsavel";
            this.chkbx_ativarResponsavel.Size = new System.Drawing.Size(70, 25);
            this.chkbx_ativarResponsavel.TabIndex = 0;
            this.chkbx_ativarResponsavel.Text = "Ativar";
            this.chkbx_ativarResponsavel.UseVisualStyleBackColor = true;
            this.chkbx_ativarResponsavel.CheckedChanged += new System.EventHandler(this.chkbx_ativarResponsavel_CheckedChanged);
            // 
            // btn_pesquisarResponsavel
            // 
            this.btn_pesquisarResponsavel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_pesquisarResponsavel.BackColor = System.Drawing.Color.Gray;
            this.btn_pesquisarResponsavel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_pesquisarResponsavel.Enabled = false;
            this.btn_pesquisarResponsavel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pesquisarResponsavel.ForeColor = System.Drawing.Color.White;
            this.btn_pesquisarResponsavel.Image = global::gerenciador_antt.Properties.Resources.procurar_lupa_micro;
            this.btn_pesquisarResponsavel.Location = new System.Drawing.Point(851, 31);
            this.btn_pesquisarResponsavel.Name = "btn_pesquisarResponsavel";
            this.btn_pesquisarResponsavel.Size = new System.Drawing.Size(30, 29);
            this.btn_pesquisarResponsavel.TabIndex = 10;
            this.btn_pesquisarResponsavel.TabStop = false;
            this.btn_pesquisarResponsavel.UseVisualStyleBackColor = false;
            this.btn_pesquisarResponsavel.Click += new System.EventHandler(this.btn_pesquisarResponsavel_Click);
            // 
            // cbx_responsavel
            // 
            this.cbx_responsavel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_responsavel.BackColor = System.Drawing.Color.Gainsboro;
            this.cbx_responsavel.DisplayMember = "nome_tipo_contato";
            this.cbx_responsavel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_responsavel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbx_responsavel.FormattingEnabled = true;
            this.cbx_responsavel.Location = new System.Drawing.Point(114, 31);
            this.cbx_responsavel.Name = "cbx_responsavel";
            this.cbx_responsavel.Size = new System.Drawing.Size(733, 29);
            this.cbx_responsavel.TabIndex = 5;
            this.cbx_responsavel.TabStop = false;
            this.cbx_responsavel.ValueMember = "cod_tipo_contato_pk";
            this.cbx_responsavel.Validated += new System.EventHandler(this.cbx_responsavel_Validated);
            // 
            // gbx_atendimento_servico
            // 
            this.gbx_atendimento_servico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_atendimento_servico.Controls.Add(this.txt_descricao_servico);
            this.gbx_atendimento_servico.Controls.Add(this.btn_alterarValor);
            this.gbx_atendimento_servico.Controls.Add(this.txt_descontado);
            this.gbx_atendimento_servico.Controls.Add(this.label3);
            this.gbx_atendimento_servico.Controls.Add(this.txt_valor_servico);
            this.gbx_atendimento_servico.Controls.Add(this.btn_receberPreco);
            this.gbx_atendimento_servico.Controls.Add(this.btn_adicionarServico);
            this.gbx_atendimento_servico.Controls.Add(this.gbx_items_servicosAdicionados);
            this.gbx_atendimento_servico.Controls.Add(this.cbx_servico);
            this.gbx_atendimento_servico.Controls.Add(this.label2);
            this.gbx_atendimento_servico.Controls.Add(this.label5);
            this.gbx_atendimento_servico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbx_atendimento_servico.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbx_atendimento_servico.ForeColor = System.Drawing.Color.DimGray;
            this.gbx_atendimento_servico.Location = new System.Drawing.Point(9, 156);
            this.gbx_atendimento_servico.Name = "gbx_atendimento_servico";
            this.gbx_atendimento_servico.Size = new System.Drawing.Size(663, 492);
            this.gbx_atendimento_servico.TabIndex = 10;
            this.gbx_atendimento_servico.TabStop = false;
            this.gbx_atendimento_servico.Text = "Serviço";
            // 
            // txt_descricao_servico
            // 
            this.txt_descricao_servico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_descricao_servico.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_descricao_servico.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_descricao_servico.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_descricao_servico.Location = new System.Drawing.Point(15, 69);
            this.txt_descricao_servico.Multiline = true;
            this.txt_descricao_servico.Name = "txt_descricao_servico";
            this.txt_descricao_servico.ReadOnly = true;
            this.txt_descricao_servico.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_descricao_servico.Size = new System.Drawing.Size(634, 46);
            this.txt_descricao_servico.TabIndex = 22;
            this.txt_descricao_servico.TabStop = false;
            // 
            // btn_alterarValor
            // 
            this.btn_alterarValor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_alterarValor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(36)))), ((int)(((byte)(60)))));
            this.btn_alterarValor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_alterarValor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_alterarValor.ForeColor = System.Drawing.Color.White;
            this.btn_alterarValor.Image = global::gerenciador_antt.Properties.Resources.certo_micro;
            this.btn_alterarValor.Location = new System.Drawing.Point(285, 122);
            this.btn_alterarValor.Name = "btn_alterarValor";
            this.btn_alterarValor.Size = new System.Drawing.Size(30, 29);
            this.btn_alterarValor.TabIndex = 5;
            this.btn_alterarValor.UseVisualStyleBackColor = false;
            this.btn_alterarValor.Click += new System.EventHandler(this.btn_alterarValor_Click);
            // 
            // txt_descontado
            // 
            this.txt_descontado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_descontado.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_descontado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_descontado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_descontado.Location = new System.Drawing.Point(110, 125);
            this.txt_descontado.Name = "txt_descontado";
            this.txt_descontado.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_descontado.Size = new System.Drawing.Size(170, 22);
            this.txt_descontado.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(11, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 21);
            this.label3.TabIndex = 19;
            this.label3.Text = "Desconto: R$";
            // 
            // txt_valor_servico
            // 
            this.txt_valor_servico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_valor_servico.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_valor_servico.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_valor_servico.Enabled = false;
            this.txt_valor_servico.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_valor_servico.Location = new System.Drawing.Point(495, 125);
            this.txt_valor_servico.Name = "txt_valor_servico";
            this.txt_valor_servico.ReadOnly = true;
            this.txt_valor_servico.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_valor_servico.Size = new System.Drawing.Size(154, 22);
            this.txt_valor_servico.TabIndex = 16;
            this.txt_valor_servico.TabStop = false;
            // 
            // btn_receberPreco
            // 
            this.btn_receberPreco.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_receberPreco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(36)))), ((int)(((byte)(60)))));
            this.btn_receberPreco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_receberPreco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_receberPreco.ForeColor = System.Drawing.Color.White;
            this.btn_receberPreco.Image = global::gerenciador_antt.Properties.Resources.preco_micro;
            this.btn_receberPreco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_receberPreco.Location = new System.Drawing.Point(512, 35);
            this.btn_receberPreco.Name = "btn_receberPreco";
            this.btn_receberPreco.Size = new System.Drawing.Size(137, 29);
            this.btn_receberPreco.TabIndex = 3;
            this.btn_receberPreco.Text = "Receber Preço";
            this.btn_receberPreco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_receberPreco.UseVisualStyleBackColor = false;
            this.btn_receberPreco.Click += new System.EventHandler(this.btn_receberPreco_Click);
            // 
            // btn_adicionarServico
            // 
            this.btn_adicionarServico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_adicionarServico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(36)))), ((int)(((byte)(60)))));
            this.btn_adicionarServico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_adicionarServico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_adicionarServico.ForeColor = System.Drawing.Color.White;
            this.btn_adicionarServico.Location = new System.Drawing.Point(12, 158);
            this.btn_adicionarServico.Name = "btn_adicionarServico";
            this.btn_adicionarServico.Size = new System.Drawing.Size(637, 51);
            this.btn_adicionarServico.TabIndex = 9;
            this.btn_adicionarServico.Text = "Adicionar Serviço↴";
            this.btn_adicionarServico.UseVisualStyleBackColor = false;
            this.btn_adicionarServico.Click += new System.EventHandler(this.btn_adicionarServico_Click);
            // 
            // gbx_items_servicosAdicionados
            // 
            this.gbx_items_servicosAdicionados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_items_servicosAdicionados.Controls.Add(this.txt_qtd_items_adicionados);
            this.gbx_items_servicosAdicionados.Controls.Add(this.label7);
            this.gbx_items_servicosAdicionados.Controls.Add(this.txt_valor_total);
            this.gbx_items_servicosAdicionados.Controls.Add(this.label6);
            this.gbx_items_servicosAdicionados.Controls.Add(this.pnl_servicos_prestados);
            this.gbx_items_servicosAdicionados.ForeColor = System.Drawing.Color.DimGray;
            this.gbx_items_servicosAdicionados.Location = new System.Drawing.Point(12, 215);
            this.gbx_items_servicosAdicionados.Name = "gbx_items_servicosAdicionados";
            this.gbx_items_servicosAdicionados.Size = new System.Drawing.Size(637, 277);
            this.gbx_items_servicosAdicionados.TabIndex = 8;
            this.gbx_items_servicosAdicionados.TabStop = false;
            this.gbx_items_servicosAdicionados.Text = "Lista de Serviços Prestados";
            // 
            // txt_qtd_items_adicionados
            // 
            this.txt_qtd_items_adicionados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_qtd_items_adicionados.BackColor = System.Drawing.Color.Honeydew;
            this.txt_qtd_items_adicionados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_qtd_items_adicionados.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txt_qtd_items_adicionados.ForeColor = System.Drawing.Color.DarkGreen;
            this.txt_qtd_items_adicionados.Location = new System.Drawing.Point(549, 247);
            this.txt_qtd_items_adicionados.Name = "txt_qtd_items_adicionados";
            this.txt_qtd_items_adicionados.ReadOnly = true;
            this.txt_qtd_items_adicionados.Size = new System.Drawing.Size(72, 24);
            this.txt_qtd_items_adicionados.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label7.ForeColor = System.Drawing.Color.DarkGreen;
            this.label7.Location = new System.Drawing.Point(462, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 21);
            this.label7.TabIndex = 14;
            this.label7.Text = "Qtd Items:";
            // 
            // txt_valor_total
            // 
            this.txt_valor_total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_valor_total.BackColor = System.Drawing.Color.Honeydew;
            this.txt_valor_total.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_valor_total.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txt_valor_total.ForeColor = System.Drawing.Color.DarkGreen;
            this.txt_valor_total.Location = new System.Drawing.Point(119, 247);
            this.txt_valor_total.Name = "txt_valor_total";
            this.txt_valor_total.ReadOnly = true;
            this.txt_valor_total.Size = new System.Drawing.Size(149, 24);
            this.txt_valor_total.TabIndex = 12;
            this.txt_valor_total.Click += new System.EventHandler(this.txt_valor_total_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.ForeColor = System.Drawing.Color.DarkGreen;
            this.label6.Location = new System.Drawing.Point(9, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 21);
            this.label6.TabIndex = 13;
            this.label6.Text = "Valor Total: R$";
            // 
            // pnl_servicos_prestados
            // 
            this.pnl_servicos_prestados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_servicos_prestados.AutoScroll = true;
            this.pnl_servicos_prestados.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_servicos_prestados.ForeColor = System.Drawing.Color.Black;
            this.erros.SetIconAlignment(this.pnl_servicos_prestados, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.pnl_servicos_prestados.Location = new System.Drawing.Point(9, 27);
            this.pnl_servicos_prestados.Name = "pnl_servicos_prestados";
            this.pnl_servicos_prestados.Size = new System.Drawing.Size(612, 207);
            this.pnl_servicos_prestados.TabIndex = 1;
            this.pnl_servicos_prestados.MouseLeave += new System.EventHandler(this.pnl_servicos_prestados_MouseLeave);
            this.pnl_servicos_prestados.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.pnl_servicos_prestados_ControlAdded);
            this.pnl_servicos_prestados.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnl_servicos_prestados_ControlRemoved);
            // 
            // cbx_servico
            // 
            this.cbx_servico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_servico.BackColor = System.Drawing.Color.Gainsboro;
            this.cbx_servico.DisplayMember = "nome_tipo_endereco";
            this.cbx_servico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_servico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbx_servico.FormattingEnabled = true;
            this.cbx_servico.Location = new System.Drawing.Point(15, 35);
            this.cbx_servico.Name = "cbx_servico";
            this.cbx_servico.Size = new System.Drawing.Size(491, 29);
            this.cbx_servico.TabIndex = 2;
            this.cbx_servico.ValueMember = "cod_tipo_endereco_pk";
            this.cbx_servico.SelectedValueChanged += new System.EventHandler(this.cbx_servico_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(345, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 21);
            this.label2.TabIndex = 17;
            this.label2.Text = "Preço do Serviço: R$";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(322, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 21);
            this.label5.TabIndex = 21;
            this.label5.Text = ">";
            // 
            // txt_observacao
            // 
            this.txt_observacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_observacao.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_observacao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_observacao.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_observacao.ForeColor = System.Drawing.Color.DarkGray;
            this.txt_observacao.Location = new System.Drawing.Point(9, 27);
            this.txt_observacao.Multiline = true;
            this.txt_observacao.Name = "txt_observacao";
            this.txt_observacao.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_observacao.Size = new System.Drawing.Size(293, 123);
            this.txt_observacao.TabIndex = 8;
            this.txt_observacao.Text = "Observações...";
            this.txt_observacao.TextChanged += new System.EventHandler(this.txt_observacao_TextChanged);
            this.txt_observacao.Validated += new System.EventHandler(this.txt_observacao_Validated);
            this.txt_observacao.Leave += new System.EventHandler(this.txt_observacao_Leave);
            this.txt_observacao.Enter += new System.EventHandler(this.txt_observacao_Enter);
            // 
            // gbx_obs
            // 
            this.gbx_obs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_obs.Controls.Add(this.txt_observacao);
            this.gbx_obs.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbx_obs.ForeColor = System.Drawing.Color.DimGray;
            this.gbx_obs.Location = new System.Drawing.Point(684, 274);
            this.gbx_obs.Name = "gbx_obs";
            this.gbx_obs.Size = new System.Drawing.Size(310, 159);
            this.gbx_obs.TabIndex = 13;
            this.gbx_obs.TabStop = false;
            this.gbx_obs.Text = "Observações";
            // 
            // erros
            // 
            this.erros.BlinkRate = 500;
            this.erros.ContainerControl = this;
            // 
            // btn_cadastrar_atendimento
            // 
            this.btn_cadastrar_atendimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cadastrar_atendimento.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_cadastrar_atendimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadastrar_atendimento.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.btn_cadastrar_atendimento.ForeColor = System.Drawing.Color.White;
            this.erros.SetIconAlignment(this.btn_cadastrar_atendimento, System.Windows.Forms.ErrorIconAlignment.TopLeft);
            this.btn_cadastrar_atendimento.Image = global::gerenciador_antt.Properties.Resources.atendimento;
            this.btn_cadastrar_atendimento.Location = new System.Drawing.Point(684, 433);
            this.btn_cadastrar_atendimento.Name = "btn_cadastrar_atendimento";
            this.btn_cadastrar_atendimento.Size = new System.Drawing.Size(310, 215);
            this.btn_cadastrar_atendimento.TabIndex = 9;
            this.btn_cadastrar_atendimento.Text = "Cadastrar";
            this.btn_cadastrar_atendimento.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_cadastrar_atendimento.UseVisualStyleBackColor = false;
            this.btn_cadastrar_atendimento.Click += new System.EventHandler(this.btn_cadastrar_atendimento_Click);
            // 
            // pnl_centro
            // 
            this.pnl_centro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_centro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_centro.BackColor = System.Drawing.Color.White;
            this.pnl_centro.Controls.Add(this.gbx_dadosSelecionados);
            this.pnl_centro.Controls.Add(this.gbx_opcoes);
            this.pnl_centro.Controls.Add(this.btn_cadastrar_atendimento);
            this.pnl_centro.Controls.Add(this.pnl_fechar);
            this.pnl_centro.Controls.Add(this.gbx_atendimento_servico);
            this.pnl_centro.Controls.Add(this.gbx_obs);
            this.pnl_centro.Controls.Add(this.groupBox1);
            this.pnl_centro.ForeColor = System.Drawing.Color.Black;
            this.pnl_centro.Location = new System.Drawing.Point(0, 0);
            this.pnl_centro.Name = "pnl_centro";
            this.pnl_centro.Size = new System.Drawing.Size(1000, 665);
            this.pnl_centro.TabIndex = 15;
            // 
            // gbx_opcoes
            // 
            this.gbx_opcoes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_opcoes.Controls.Add(this.checkBox1);
            this.gbx_opcoes.Controls.Add(this.chkbx_totalmenteFinalizado);
            this.gbx_opcoes.Controls.Add(this.chkbx_totalmentePago);
            this.gbx_opcoes.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbx_opcoes.ForeColor = System.Drawing.Color.DimGray;
            this.gbx_opcoes.Location = new System.Drawing.Point(684, 153);
            this.gbx_opcoes.Name = "gbx_opcoes";
            this.gbx_opcoes.Size = new System.Drawing.Size(310, 120);
            this.gbx_opcoes.TabIndex = 16;
            this.gbx_opcoes.TabStop = false;
            this.gbx_opcoes.Text = "Opções";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBox1.ForeColor = System.Drawing.Color.Red;
            this.checkBox1.Location = new System.Drawing.Point(20, 85);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(126, 23);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "Cancelar Pedido";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // chkbx_totalmenteFinalizado
            // 
            this.chkbx_totalmenteFinalizado.AutoSize = true;
            this.chkbx_totalmenteFinalizado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkbx_totalmenteFinalizado.ForeColor = System.Drawing.Color.Green;
            this.chkbx_totalmenteFinalizado.Location = new System.Drawing.Point(20, 59);
            this.chkbx_totalmenteFinalizado.Name = "chkbx_totalmenteFinalizado";
            this.chkbx_totalmenteFinalizado.Size = new System.Drawing.Size(246, 23);
            this.chkbx_totalmenteFinalizado.TabIndex = 7;
            this.chkbx_totalmenteFinalizado.Text = "Marcar como Totalmente Finalizado";
            this.chkbx_totalmenteFinalizado.UseVisualStyleBackColor = true;
            // 
            // chkbx_totalmentePago
            // 
            this.chkbx_totalmentePago.AutoSize = true;
            this.chkbx_totalmentePago.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkbx_totalmentePago.ForeColor = System.Drawing.Color.Green;
            this.chkbx_totalmentePago.Location = new System.Drawing.Point(20, 34);
            this.chkbx_totalmentePago.Name = "chkbx_totalmentePago";
            this.chkbx_totalmentePago.Size = new System.Drawing.Size(217, 23);
            this.chkbx_totalmentePago.TabIndex = 6;
            this.chkbx_totalmentePago.Text = "Marcar como Totalmente Pago";
            this.chkbx_totalmentePago.UseVisualStyleBackColor = true;
            // 
            // pnl_fechar
            // 
            this.pnl_fechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_fechar.BackColor = System.Drawing.Color.Transparent;
            this.pnl_fechar.Controls.Add(this.btn_fechar);
            this.pnl_fechar.Controls.Add(this.lbl_fechar);
            this.pnl_fechar.Location = new System.Drawing.Point(902, 0);
            this.pnl_fechar.Name = "pnl_fechar";
            this.pnl_fechar.Size = new System.Drawing.Size(98, 32);
            this.pnl_fechar.TabIndex = 15;
            this.pnl_fechar.Click += new System.EventHandler(this.btn_fechar_Click);
            // 
            // btn_fechar
            // 
            this.btn_fechar.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_fechar.BackgroundImage = global::gerenciador_antt.Properties.Resources.excluir;
            this.btn_fechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_fechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_fechar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_fechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_fechar.Location = new System.Drawing.Point(66, 4);
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(25, 25);
            this.btn_fechar.TabIndex = 10;
            this.btn_fechar.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btn_fechar.UseVisualStyleBackColor = false;
            this.btn_fechar.Click += new System.EventHandler(this.btn_fechar_Click);
            // 
            // lbl_fechar
            // 
            this.lbl_fechar.AutoSize = true;
            this.lbl_fechar.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lbl_fechar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbl_fechar.Location = new System.Drawing.Point(0, 1);
            this.lbl_fechar.Name = "lbl_fechar";
            this.lbl_fechar.Size = new System.Drawing.Size(69, 28);
            this.lbl_fechar.TabIndex = 15;
            this.lbl_fechar.Text = "Fechar";
            this.lbl_fechar.Click += new System.EventHandler(this.btn_fechar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.lbl_codigo_nomenclatura);
            this.groupBox1.Controls.Add(this.lbl_codigo_numero);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(9, -33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 68);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // lbl_codigo_nomenclatura
            // 
            this.lbl_codigo_nomenclatura.AutoSize = true;
            this.lbl_codigo_nomenclatura.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbl_codigo_nomenclatura.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_codigo_nomenclatura.Location = new System.Drawing.Point(5, 39);
            this.lbl_codigo_nomenclatura.Name = "lbl_codigo_nomenclatura";
            this.lbl_codigo_nomenclatura.Size = new System.Drawing.Size(63, 21);
            this.lbl_codigo_nomenclatura.TabIndex = 16;
            this.lbl_codigo_nomenclatura.Text = "Código:";
            this.lbl_codigo_nomenclatura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_codigo_nomenclatura.Visible = false;
            // 
            // lbl_codigo_numero
            // 
            this.lbl_codigo_numero.AutoSize = true;
            this.lbl_codigo_numero.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbl_codigo_numero.ForeColor = System.Drawing.Color.Black;
            this.lbl_codigo_numero.Location = new System.Drawing.Point(63, 39);
            this.lbl_codigo_numero.Name = "lbl_codigo_numero";
            this.lbl_codigo_numero.Size = new System.Drawing.Size(19, 21);
            this.lbl_codigo_numero.TabIndex = 17;
            this.lbl_codigo_numero.Text = "0";
            this.lbl_codigo_numero.Visible = false;
            // 
            // Uc_atendimento_cadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnl_centro);
            this.Name = "Uc_atendimento_cadastro";
            this.Size = new System.Drawing.Size(1146, 665);
            this.Load += new System.EventHandler(this.Uc_responsavel_cadastro_Load);
            this.gbx_dadosSelecionados.ResumeLayout(false);
            this.gbx_dadosSelecionados.PerformLayout();
            this.gbx_atendimento_servico.ResumeLayout(false);
            this.gbx_atendimento_servico.PerformLayout();
            this.gbx_items_servicosAdicionados.ResumeLayout(false);
            this.gbx_items_servicosAdicionados.PerformLayout();
            this.gbx_obs.ResumeLayout(false);
            this.gbx_obs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erros)).EndInit();
            this.pnl_centro.ResumeLayout(false);
            this.gbx_opcoes.ResumeLayout(false);
            this.gbx_opcoes.PerformLayout();
            this.pnl_fechar.ResumeLayout(false);
            this.pnl_fechar.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_cadastrar_atendimento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbx_dadosSelecionados;
        private System.Windows.Forms.GroupBox gbx_atendimento_servico;
        private System.Windows.Forms.Button btn_adicionarServico;
        private System.Windows.Forms.GroupBox gbx_items_servicosAdicionados;
        private System.Windows.Forms.ComboBox cbx_servico;
        private System.Windows.Forms.TextBox txt_observacao;
        private System.Windows.Forms.GroupBox gbx_obs;
        private System.Windows.Forms.ErrorProvider erros;
        private System.Windows.Forms.Button btn_fechar;
        private System.Windows.Forms.Panel pnl_servicos_prestados;
        private System.Windows.Forms.Panel pnl_centro;
        private System.Windows.Forms.Panel pnl_fechar;
        private System.Windows.Forms.Label lbl_fechar;
        private System.Windows.Forms.Button btn_pesquisarResponsavel;
        private System.Windows.Forms.ComboBox cbx_responsavel;
        private System.Windows.Forms.CheckBox chkbx_ativarCliente;
        private System.Windows.Forms.Button btn_pesquisarCliente;
        private System.Windows.Forms.ComboBox cbx_cliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkbx_ativarResponsavel;
        private System.Windows.Forms.GroupBox gbx_opcoes;
        private System.Windows.Forms.CheckBox chkbx_totalmenteFinalizado;
        private System.Windows.Forms.CheckBox chkbx_totalmentePago;
        private System.Windows.Forms.Button btn_receberPreco;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_valor_servico;
        private System.Windows.Forms.Button btn_alterarValor;
        private System.Windows.Forms.TextBox txt_descontado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_descricao_servico;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_codigo_nomenclatura;
        private System.Windows.Forms.Label lbl_codigo_numero;
        private System.Windows.Forms.TextBox txt_valor_total;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txt_qtd_items_adicionados;
        private System.Windows.Forms.Label label7;
    }
}
