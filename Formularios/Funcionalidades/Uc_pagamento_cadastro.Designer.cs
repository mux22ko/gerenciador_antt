namespace gerenciador_antt.Formularios
{
    partial class Uc_pagamento_cadastro
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.erros = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnl_selecionar = new System.Windows.Forms.GroupBox();
            this.txt_qtd_atendimentos = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rbtn_balancear_igual = new System.Windows.Forms.RadioButton();
            this.rbtn_balancear_maisAntigo = new System.Windows.Forms.RadioButton();
            this.btn_adicionar = new System.Windows.Forms.Button();
            this.dtg_resultados = new System.Windows.Forms.DataGridView();
            this.cod_atendimento_pk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_cliente_fk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_responsavel_fk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado_pago_atendimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_criacao_atendimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fatia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_pesquisarAtendimento = new System.Windows.Forms.Button();
            this.cbx_atendimento = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_cadastrar_pagamento = new System.Windows.Forms.Button();
            this.chkbx_pagamento_cancelado = new System.Windows.Forms.CheckBox();
            this.pnl_centro = new System.Windows.Forms.Panel();
            this.gbx_pagamento_informacoes = new System.Windows.Forms.GroupBox();
            this.gbx_meios_pg = new System.Windows.Forms.GroupBox();
            this.cbx_meios_pagamento = new System.Windows.Forms.ComboBox();
            this.txt_observacao = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txt_valor_troco = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_valor_recebido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_valor_total_devido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_fechar = new System.Windows.Forms.Panel();
            this.btn_fechar = new System.Windows.Forms.Button();
            this.lbl_fechar = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_codigo_nomenclatura = new System.Windows.Forms.Label();
            this.lbl_codigo_numero = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.erros)).BeginInit();
            this.pnl_selecionar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_resultados)).BeginInit();
            this.pnl_centro.SuspendLayout();
            this.gbx_pagamento_informacoes.SuspendLayout();
            this.gbx_meios_pg.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pnl_fechar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // erros
            // 
            this.erros.BlinkRate = 500;
            this.erros.ContainerControl = this;
            // 
            // pnl_selecionar
            // 
            this.pnl_selecionar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_selecionar.Controls.Add(this.txt_qtd_atendimentos);
            this.pnl_selecionar.Controls.Add(this.label7);
            this.pnl_selecionar.Controls.Add(this.rbtn_balancear_igual);
            this.pnl_selecionar.Controls.Add(this.rbtn_balancear_maisAntigo);
            this.pnl_selecionar.Controls.Add(this.btn_adicionar);
            this.pnl_selecionar.Controls.Add(this.dtg_resultados);
            this.pnl_selecionar.Controls.Add(this.btn_pesquisarAtendimento);
            this.pnl_selecionar.Controls.Add(this.cbx_atendimento);
            this.pnl_selecionar.Controls.Add(this.label1);
            this.pnl_selecionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pnl_selecionar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnl_selecionar.ForeColor = System.Drawing.Color.DimGray;
            this.erros.SetIconPadding(this.pnl_selecionar, -100);
            this.pnl_selecionar.Location = new System.Drawing.Point(9, 36);
            this.pnl_selecionar.Name = "pnl_selecionar";
            this.pnl_selecionar.Size = new System.Drawing.Size(985, 391);
            this.pnl_selecionar.TabIndex = 0;
            this.pnl_selecionar.TabStop = false;
            this.pnl_selecionar.Text = "Selecionar";
            // 
            // txt_qtd_atendimentos
            // 
            this.txt_qtd_atendimentos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_qtd_atendimentos.BackColor = System.Drawing.Color.Honeydew;
            this.txt_qtd_atendimentos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_qtd_atendimentos.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txt_qtd_atendimentos.ForeColor = System.Drawing.Color.DarkGreen;
            this.txt_qtd_atendimentos.Location = new System.Drawing.Point(917, 349);
            this.txt_qtd_atendimentos.Name = "txt_qtd_atendimentos";
            this.txt_qtd_atendimentos.ReadOnly = true;
            this.txt_qtd_atendimentos.Size = new System.Drawing.Size(42, 24);
            this.txt_qtd_atendimentos.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label7.ForeColor = System.Drawing.Color.DarkGreen;
            this.label7.Location = new System.Drawing.Point(771, 349);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 21);
            this.label7.TabIndex = 16;
            this.label7.Text = "Qtd Atendimentos:";
            // 
            // rbtn_balancear_igual
            // 
            this.rbtn_balancear_igual.AutoSize = true;
            this.rbtn_balancear_igual.Location = new System.Drawing.Point(224, 347);
            this.rbtn_balancear_igual.Name = "rbtn_balancear_igual";
            this.rbtn_balancear_igual.Size = new System.Drawing.Size(161, 25);
            this.rbtn_balancear_igual.TabIndex = 23;
            this.rbtn_balancear_igual.Text = "Balancear por igual";
            this.rbtn_balancear_igual.UseVisualStyleBackColor = true;
            this.rbtn_balancear_igual.Visible = false;
            this.rbtn_balancear_igual.CheckedChanged += new System.EventHandler(this.rbtn_balancear_igual_CheckedChanged);
            // 
            // rbtn_balancear_maisAntigo
            // 
            this.rbtn_balancear_maisAntigo.AutoSize = true;
            this.rbtn_balancear_maisAntigo.Location = new System.Drawing.Point(16, 347);
            this.rbtn_balancear_maisAntigo.Name = "rbtn_balancear_maisAntigo";
            this.rbtn_balancear_maisAntigo.Size = new System.Drawing.Size(166, 25);
            this.rbtn_balancear_maisAntigo.TabIndex = 22;
            this.rbtn_balancear_maisAntigo.Text = "Balancear na ordem";
            this.rbtn_balancear_maisAntigo.UseVisualStyleBackColor = true;
            this.rbtn_balancear_maisAntigo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rbtn_balancear_maisAntigo_MouseDown);
            this.rbtn_balancear_maisAntigo.CheckedChanged += new System.EventHandler(this.rbtn_balancear_maisAntigo_CheckedChanged);
            // 
            // btn_adicionar
            // 
            this.btn_adicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_adicionar.BackColor = System.Drawing.Color.Green;
            this.btn_adicionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_adicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_adicionar.ForeColor = System.Drawing.Color.Black;
            this.btn_adicionar.Image = global::gerenciador_antt.Properties.Resources.adicionar_micro;
            this.btn_adicionar.Location = new System.Drawing.Point(887, 31);
            this.btn_adicionar.Name = "btn_adicionar";
            this.btn_adicionar.Size = new System.Drawing.Size(72, 29);
            this.btn_adicionar.TabIndex = 2;
            this.btn_adicionar.UseVisualStyleBackColor = false;
            this.btn_adicionar.Click += new System.EventHandler(this.btn_adicionar_Click);
            // 
            // dtg_resultados
            // 
            this.dtg_resultados.AllowUserToAddRows = false;
            this.dtg_resultados.AllowUserToDeleteRows = false;
            this.dtg_resultados.AllowUserToOrderColumns = true;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            this.dtg_resultados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dtg_resultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtg_resultados.BackgroundColor = System.Drawing.Color.LightGray;
            this.dtg_resultados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtg_resultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_resultados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod_atendimento_pk,
            this.cod_cliente_fk,
            this.cod_responsavel_fk,
            this.total,
            this.pago,
            this.estado_pago_atendimento,
            this.data_criacao_atendimento,
            this.fatia});
            this.dtg_resultados.GridColor = System.Drawing.Color.LightGray;
            this.dtg_resultados.Location = new System.Drawing.Point(15, 74);
            this.dtg_resultados.Name = "dtg_resultados";
            this.dtg_resultados.ReadOnly = true;
            this.dtg_resultados.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtg_resultados.Size = new System.Drawing.Size(944, 268);
            this.dtg_resultados.TabIndex = 3;
            this.dtg_resultados.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtg_resultados_RowsAdded);
            this.dtg_resultados.MouseLeave += new System.EventHandler(this.dtg_resultados_MouseLeave);
            this.dtg_resultados.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtg_resultados_RowsRemoved);
            this.dtg_resultados.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtg_resultados_KeyUp);
            // 
            // cod_atendimento_pk
            // 
            this.cod_atendimento_pk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cod_atendimento_pk.DataPropertyName = "cod_atendimento_pk";
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cod_atendimento_pk.DefaultCellStyle = dataGridViewCellStyle10;
            this.cod_atendimento_pk.Frozen = true;
            this.cod_atendimento_pk.HeaderText = "CODIGO";
            this.cod_atendimento_pk.Name = "cod_atendimento_pk";
            this.cod_atendimento_pk.ReadOnly = true;
            this.cod_atendimento_pk.Width = 95;
            // 
            // cod_cliente_fk
            // 
            this.cod_cliente_fk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cod_cliente_fk.DataPropertyName = "cod_cliente_fk";
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cod_cliente_fk.DefaultCellStyle = dataGridViewCellStyle11;
            this.cod_cliente_fk.HeaderText = "NOME CLIENTE";
            this.cod_cliente_fk.Name = "cod_cliente_fk";
            this.cod_cliente_fk.ReadOnly = true;
            this.cod_cliente_fk.Width = 131;
            // 
            // cod_responsavel_fk
            // 
            this.cod_responsavel_fk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cod_responsavel_fk.DataPropertyName = "cod_responsavel_fk";
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cod_responsavel_fk.DefaultCellStyle = dataGridViewCellStyle12;
            this.cod_responsavel_fk.HeaderText = "NOME RESPONSAVEL";
            this.cod_responsavel_fk.Name = "cod_responsavel_fk";
            this.cod_responsavel_fk.ReadOnly = true;
            this.cod_responsavel_fk.Width = 173;
            // 
            // total
            // 
            this.total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.total.DataPropertyName = "total";
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.total.DefaultCellStyle = dataGridViewCellStyle13;
            this.total.HeaderText = "VALOR TOTAL";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 124;
            // 
            // pago
            // 
            this.pago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pago.DataPropertyName = "pago";
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pago.DefaultCellStyle = dataGridViewCellStyle14;
            this.pago.HeaderText = "VALOR PAGO";
            this.pago.Name = "pago";
            this.pago.ReadOnly = true;
            this.pago.Width = 120;
            // 
            // estado_pago_atendimento
            // 
            this.estado_pago_atendimento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.estado_pago_atendimento.DataPropertyName = "estado_pago_atendimento";
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.estado_pago_atendimento.DefaultCellStyle = dataGridViewCellStyle15;
            this.estado_pago_atendimento.HeaderText = "TOTALMENTE PAGO";
            this.estado_pago_atendimento.Name = "estado_pago_atendimento";
            this.estado_pago_atendimento.ReadOnly = true;
            this.estado_pago_atendimento.Width = 161;
            // 
            // data_criacao_atendimento
            // 
            this.data_criacao_atendimento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.data_criacao_atendimento.DataPropertyName = "data_criacao_atendimento";
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.data_criacao_atendimento.DefaultCellStyle = dataGridViewCellStyle16;
            this.data_criacao_atendimento.HeaderText = "DATA ATENDIMENTO";
            this.data_criacao_atendimento.Name = "data_criacao_atendimento";
            this.data_criacao_atendimento.ReadOnly = true;
            // 
            // fatia
            // 
            this.fatia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fatia.DataPropertyName = "fatia";
            this.fatia.HeaderText = "PAGANDO";
            this.fatia.Name = "fatia";
            this.fatia.ReadOnly = true;
            this.fatia.Width = 110;
            // 
            // btn_pesquisarAtendimento
            // 
            this.btn_pesquisarAtendimento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_pesquisarAtendimento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(36)))), ((int)(((byte)(60)))));
            this.btn_pesquisarAtendimento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_pesquisarAtendimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pesquisarAtendimento.ForeColor = System.Drawing.Color.White;
            this.btn_pesquisarAtendimento.Image = global::gerenciador_antt.Properties.Resources.procurar_lupa_micro;
            this.btn_pesquisarAtendimento.Location = new System.Drawing.Point(851, 31);
            this.btn_pesquisarAtendimento.Name = "btn_pesquisarAtendimento";
            this.btn_pesquisarAtendimento.Size = new System.Drawing.Size(30, 29);
            this.btn_pesquisarAtendimento.TabIndex = 0;
            this.btn_pesquisarAtendimento.UseVisualStyleBackColor = false;
            this.btn_pesquisarAtendimento.Click += new System.EventHandler(this.btn_pesquisarAtendimento_Click);
            // 
            // cbx_atendimento
            // 
            this.cbx_atendimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_atendimento.BackColor = System.Drawing.Color.Gainsboro;
            this.cbx_atendimento.DisplayMember = "nome_tipo_contato";
            this.cbx_atendimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_atendimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbx_atendimento.FormattingEnabled = true;
            this.cbx_atendimento.Location = new System.Drawing.Point(114, 31);
            this.cbx_atendimento.Name = "cbx_atendimento";
            this.cbx_atendimento.Size = new System.Drawing.Size(733, 29);
            this.cbx_atendimento.TabIndex = 1;
            this.cbx_atendimento.ValueMember = "cod_tipo_contato_pk";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Atendimento:";
            // 
            // btn_cadastrar_pagamento
            // 
            this.btn_cadastrar_pagamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cadastrar_pagamento.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_cadastrar_pagamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadastrar_pagamento.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.btn_cadastrar_pagamento.ForeColor = System.Drawing.Color.White;
            this.erros.SetIconAlignment(this.btn_cadastrar_pagamento, System.Windows.Forms.ErrorIconAlignment.TopLeft);
            this.btn_cadastrar_pagamento.Image = global::gerenciador_antt.Properties.Resources.atendimento;
            this.btn_cadastrar_pagamento.Location = new System.Drawing.Point(684, 433);
            this.btn_cadastrar_pagamento.Name = "btn_cadastrar_pagamento";
            this.btn_cadastrar_pagamento.Size = new System.Drawing.Size(310, 215);
            this.btn_cadastrar_pagamento.TabIndex = 7;
            this.btn_cadastrar_pagamento.Text = "Cadastrar";
            this.btn_cadastrar_pagamento.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_cadastrar_pagamento.UseVisualStyleBackColor = false;
            this.btn_cadastrar_pagamento.Click += new System.EventHandler(this.btn_cadastrar_pagamento_Click);
            // 
            // chkbx_pagamento_cancelado
            // 
            this.chkbx_pagamento_cancelado.AutoSize = true;
            this.chkbx_pagamento_cancelado.Enabled = false;
            this.chkbx_pagamento_cancelado.ForeColor = System.Drawing.Color.Red;
            this.chkbx_pagamento_cancelado.Location = new System.Drawing.Point(43, 38);
            this.chkbx_pagamento_cancelado.Name = "chkbx_pagamento_cancelado";
            this.chkbx_pagamento_cancelado.Size = new System.Drawing.Size(184, 25);
            this.chkbx_pagamento_cancelado.TabIndex = 22;
            this.chkbx_pagamento_cancelado.TabStop = false;
            this.chkbx_pagamento_cancelado.Text = "Pagamento Cancelado";
            this.chkbx_pagamento_cancelado.UseVisualStyleBackColor = true;
            this.chkbx_pagamento_cancelado.CheckedChanged += new System.EventHandler(this.chkbx_pagamento_cancelado_CheckedChanged);
            // 
            // pnl_centro
            // 
            this.pnl_centro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_centro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_centro.BackColor = System.Drawing.Color.White;
            this.pnl_centro.Controls.Add(this.gbx_pagamento_informacoes);
            this.pnl_centro.Controls.Add(this.btn_cadastrar_pagamento);
            this.pnl_centro.Controls.Add(this.pnl_fechar);
            this.pnl_centro.Controls.Add(this.pnl_selecionar);
            this.pnl_centro.Controls.Add(this.groupBox1);
            this.pnl_centro.ForeColor = System.Drawing.Color.Black;
            this.pnl_centro.Location = new System.Drawing.Point(0, 0);
            this.pnl_centro.Name = "pnl_centro";
            this.pnl_centro.Size = new System.Drawing.Size(1000, 665);
            this.pnl_centro.TabIndex = 15;
            // 
            // gbx_pagamento_informacoes
            // 
            this.gbx_pagamento_informacoes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_pagamento_informacoes.Controls.Add(this.chkbx_pagamento_cancelado);
            this.gbx_pagamento_informacoes.Controls.Add(this.gbx_meios_pg);
            this.gbx_pagamento_informacoes.Controls.Add(this.txt_observacao);
            this.gbx_pagamento_informacoes.Controls.Add(this.groupBox5);
            this.gbx_pagamento_informacoes.Controls.Add(this.groupBox4);
            this.gbx_pagamento_informacoes.Controls.Add(this.groupBox3);
            this.gbx_pagamento_informacoes.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbx_pagamento_informacoes.Location = new System.Drawing.Point(9, 433);
            this.gbx_pagamento_informacoes.Name = "gbx_pagamento_informacoes";
            this.gbx_pagamento_informacoes.Size = new System.Drawing.Size(669, 215);
            this.gbx_pagamento_informacoes.TabIndex = 26;
            this.gbx_pagamento_informacoes.TabStop = false;
            this.gbx_pagamento_informacoes.Text = "Informações de Pagamento";
            // 
            // gbx_meios_pg
            // 
            this.gbx_meios_pg.BackColor = System.Drawing.Color.Transparent;
            this.gbx_meios_pg.Controls.Add(this.cbx_meios_pagamento);
            this.gbx_meios_pg.ForeColor = System.Drawing.Color.Black;
            this.gbx_meios_pg.Location = new System.Drawing.Point(9, 77);
            this.gbx_meios_pg.Name = "gbx_meios_pg";
            this.gbx_meios_pg.Size = new System.Drawing.Size(254, 63);
            this.gbx_meios_pg.TabIndex = 32;
            this.gbx_meios_pg.TabStop = false;
            this.gbx_meios_pg.Text = "Forma de Pagamento";
            // 
            // cbx_meios_pagamento
            // 
            this.cbx_meios_pagamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_meios_pagamento.BackColor = System.Drawing.Color.White;
            this.cbx_meios_pagamento.DisplayMember = "nome_tipo_contato";
            this.cbx_meios_pagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_meios_pagamento.FormattingEnabled = true;
            this.cbx_meios_pagamento.Location = new System.Drawing.Point(9, 25);
            this.cbx_meios_pagamento.Name = "cbx_meios_pagamento";
            this.cbx_meios_pagamento.Size = new System.Drawing.Size(239, 29);
            this.cbx_meios_pagamento.TabIndex = 4;
            // 
            // txt_observacao
            // 
            this.txt_observacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_observacao.BackColor = System.Drawing.Color.White;
            this.txt_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_observacao.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_observacao.ForeColor = System.Drawing.Color.DarkGray;
            this.txt_observacao.Location = new System.Drawing.Point(9, 146);
            this.txt_observacao.Multiline = true;
            this.txt_observacao.Name = "txt_observacao";
            this.txt_observacao.Size = new System.Drawing.Size(254, 63);
            this.txt_observacao.TabIndex = 5;
            this.txt_observacao.Text = "Observações...";
            this.txt_observacao.TextChanged += new System.EventHandler(this.txt_observacao_TextChanged);
            this.txt_observacao.Validated += new System.EventHandler(this.txt_observacao_Validated);
            this.txt_observacao.Leave += new System.EventHandler(this.txt_observacao_Leave);
            this.txt_observacao.Enter += new System.EventHandler(this.txt_observacao_Enter);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.txt_valor_troco);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.ForeColor = System.Drawing.Color.DarkGreen;
            this.groupBox5.Location = new System.Drawing.Point(281, 141);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(366, 68);
            this.groupBox5.TabIndex = 28;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Valor Troco";
            // 
            // txt_valor_troco
            // 
            this.txt_valor_troco.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_valor_troco.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_valor_troco.Location = new System.Drawing.Point(188, 23);
            this.txt_valor_troco.Name = "txt_valor_troco";
            this.txt_valor_troco.ReadOnly = true;
            this.txt_valor_troco.Size = new System.Drawing.Size(160, 29);
            this.txt_valor_troco.TabIndex = 21;
            this.txt_valor_troco.TabStop = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(153, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 21);
            this.label5.TabIndex = 24;
            this.label5.Text = "R$";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txt_valor_recebido);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.ForeColor = System.Drawing.Color.Green;
            this.groupBox4.Location = new System.Drawing.Point(281, 78);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(366, 60);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Valor Recebido";
            // 
            // txt_valor_recebido
            // 
            this.txt_valor_recebido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_valor_recebido.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_valor_recebido.Location = new System.Drawing.Point(188, 19);
            this.txt_valor_recebido.Name = "txt_valor_recebido";
            this.txt_valor_recebido.Size = new System.Drawing.Size(160, 29);
            this.txt_valor_recebido.TabIndex = 6;
            this.txt_valor_recebido.TextChanged += new System.EventHandler(this.txt_valor_recebido_TextChanged);
            this.txt_valor_recebido.Validated += new System.EventHandler(this.txt_valor_recebido_Validated);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(153, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 21);
            this.label3.TabIndex = 24;
            this.label3.Text = "R$";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txt_valor_total_devido);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox3.Location = new System.Drawing.Point(281, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(366, 57);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Valor Total Devido";
            // 
            // txt_valor_total_devido
            // 
            this.txt_valor_total_devido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_valor_total_devido.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_valor_total_devido.Location = new System.Drawing.Point(188, 19);
            this.txt_valor_total_devido.Name = "txt_valor_total_devido";
            this.txt_valor_total_devido.ReadOnly = true;
            this.txt_valor_total_devido.Size = new System.Drawing.Size(160, 29);
            this.txt_valor_total_devido.TabIndex = 20;
            this.txt_valor_total_devido.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(153, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 21);
            this.label2.TabIndex = 23;
            this.label2.Text = "R$";
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
            this.btn_fechar.TabIndex = 8;
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
            // Uc_pagamento_cadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnl_centro);
            this.Name = "Uc_pagamento_cadastro";
            this.Size = new System.Drawing.Size(1146, 665);
            this.Load += new System.EventHandler(this.Uc_pagamento_cadastro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.erros)).EndInit();
            this.pnl_selecionar.ResumeLayout(false);
            this.pnl_selecionar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_resultados)).EndInit();
            this.pnl_centro.ResumeLayout(false);
            this.gbx_pagamento_informacoes.ResumeLayout(false);
            this.gbx_pagamento_informacoes.PerformLayout();
            this.gbx_meios_pg.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.pnl_fechar.ResumeLayout(false);
            this.pnl_fechar.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_cadastrar_pagamento;
        private System.Windows.Forms.ErrorProvider erros;
        private System.Windows.Forms.Button btn_fechar;
        private System.Windows.Forms.Panel pnl_centro;
        private System.Windows.Forms.Panel pnl_fechar;
        private System.Windows.Forms.Label lbl_fechar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_codigo_nomenclatura;
        private System.Windows.Forms.Label lbl_codigo_numero;
        private System.Windows.Forms.GroupBox pnl_selecionar;
        private System.Windows.Forms.Button btn_pesquisarAtendimento;
        private System.Windows.Forms.ComboBox cbx_atendimento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_adicionar;
        private System.Windows.Forms.DataGridView dtg_resultados;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_valor_recebido;
        private System.Windows.Forms.TextBox txt_valor_total_devido;
        private System.Windows.Forms.GroupBox gbx_pagamento_informacoes;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txt_valor_troco;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_observacao;
        private System.Windows.Forms.CheckBox chkbx_pagamento_cancelado;
        private System.Windows.Forms.GroupBox gbx_meios_pg;
        private System.Windows.Forms.ComboBox cbx_meios_pagamento;
        private System.Windows.Forms.RadioButton rbtn_balancear_igual;
        private System.Windows.Forms.RadioButton rbtn_balancear_maisAntigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_atendimento_pk;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_cliente_fk;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_responsavel_fk;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado_pago_atendimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_criacao_atendimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn fatia;
        private System.Windows.Forms.TextBox txt_qtd_atendimentos;
        private System.Windows.Forms.Label label7;
    }
}
