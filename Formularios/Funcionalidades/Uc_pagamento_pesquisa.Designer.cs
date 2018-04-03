namespace gerenciador_antt.Formularios
{
    partial class Uc_pagamento_pesquisa
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnl_centro = new System.Windows.Forms.Panel();
            this.dtg_resultados = new System.Windows.Forms.DataGridView();
            this.cod_pagamento_pk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.atendimentos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor_pagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.troco_pagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_meio_pgto_fk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_criacao_pagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_alteracao_pagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado_ativo_pagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_codigo = new System.Windows.Forms.TextBox();
            this.chkbx_ativar_codigo = new System.Windows.Forms.CheckBox();
            this.gbx_atendimento_valores = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkbx_ativar_meioPagamento = new System.Windows.Forms.CheckBox();
            this.cbx_meios_pagamento = new System.Windows.Forms.ComboBox();
            this.txt_valor_troco = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkbx_ativar_valorTroco = new System.Windows.Forms.CheckBox();
            this.txt_valor_pagamento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkbx_ativar_valorPagamento = new System.Windows.Forms.CheckBox();
            this.gbx_dadosSelecionados = new System.Windows.Forms.GroupBox();
            this.flwpnl_atendimentosSelecionados = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_adicionar = new System.Windows.Forms.Button();
            this.btn_pesquisarAtendimento = new System.Windows.Forms.Button();
            this.cbx_atendimento = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbtn_contem = new System.Windows.Forms.RadioButton();
            this.rdbtn_igual = new System.Windows.Forms.RadioButton();
            this.btn_pesquisar = new System.Windows.Forms.Button();
            this.btn_detalhar = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtn_pagamentos_ativos = new System.Windows.Forms.RadioButton();
            this.rbtn_pagamentos_cancelados = new System.Windows.Forms.RadioButton();
            this.chkbx_alterados = new System.Windows.Forms.CheckBox();
            this.btn_escolher_selecionado = new System.Windows.Forms.Button();
            this.dtpckr_dataCriacao = new System.Windows.Forms.DateTimePicker();
            this.btn_alterar = new System.Windows.Forms.Button();
            this.lbl_data = new System.Windows.Forms.Label();
            this.chkbx_ativar_data = new System.Windows.Forms.CheckBox();
            this.pnl_fechar = new System.Windows.Forms.Panel();
            this.btn_fechar = new System.Windows.Forms.Button();
            this.lbl_fechar = new System.Windows.Forms.Label();
            this.pnl_centro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_resultados)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.gbx_atendimento_valores.SuspendLayout();
            this.gbx_dadosSelecionados.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_fechar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_centro
            // 
            this.pnl_centro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_centro.BackColor = System.Drawing.Color.White;
            this.pnl_centro.Controls.Add(this.dtg_resultados);
            this.pnl_centro.Controls.Add(this.groupBox2);
            this.pnl_centro.Controls.Add(this.gbx_atendimento_valores);
            this.pnl_centro.Controls.Add(this.gbx_dadosSelecionados);
            this.pnl_centro.Controls.Add(this.groupBox1);
            this.pnl_centro.Controls.Add(this.btn_pesquisar);
            this.pnl_centro.Controls.Add(this.btn_detalhar);
            this.pnl_centro.Controls.Add(this.label14);
            this.pnl_centro.Controls.Add(this.groupBox3);
            this.pnl_centro.Controls.Add(this.btn_escolher_selecionado);
            this.pnl_centro.Controls.Add(this.dtpckr_dataCriacao);
            this.pnl_centro.Controls.Add(this.btn_alterar);
            this.pnl_centro.Controls.Add(this.lbl_data);
            this.pnl_centro.Controls.Add(this.chkbx_ativar_data);
            this.pnl_centro.Controls.Add(this.pnl_fechar);
            this.pnl_centro.ForeColor = System.Drawing.Color.Black;
            this.pnl_centro.Location = new System.Drawing.Point(0, 0);
            this.pnl_centro.Name = "pnl_centro";
            this.pnl_centro.Size = new System.Drawing.Size(1000, 665);
            this.pnl_centro.TabIndex = 16;
            // 
            // dtg_resultados
            // 
            this.dtg_resultados.AllowUserToAddRows = false;
            this.dtg_resultados.AllowUserToDeleteRows = false;
            this.dtg_resultados.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dtg_resultados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_resultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtg_resultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtg_resultados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtg_resultados.BackgroundColor = System.Drawing.Color.LightGray;
            this.dtg_resultados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtg_resultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_resultados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod_pagamento_pk,
            this.atendimentos,
            this.valor_pagamento,
            this.troco_pagamento,
            this.cod_meio_pgto_fk,
            this.data_criacao_pagamento,
            this.data_alteracao_pagamento,
            this.estado_ativo_pagamento});
            this.dtg_resultados.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtg_resultados.GridColor = System.Drawing.Color.LightGray;
            this.dtg_resultados.Location = new System.Drawing.Point(9, 330);
            this.dtg_resultados.Name = "dtg_resultados";
            this.dtg_resultados.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_resultados.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dtg_resultados.Size = new System.Drawing.Size(766, 317);
            this.dtg_resultados.TabIndex = 41;
            this.dtg_resultados.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtg_resultados_ColumnHeaderMouseClick);
            this.dtg_resultados.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_resultados_CellContentDoubleClick);
            this.dtg_resultados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_resultados_CellContentDoubleClick);
            // 
            // cod_pagamento_pk
            // 
            this.cod_pagamento_pk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cod_pagamento_pk.DataPropertyName = "cod_pagamento_pk";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cod_pagamento_pk.DefaultCellStyle = dataGridViewCellStyle2;
            this.cod_pagamento_pk.HeaderText = "CODIGO";
            this.cod_pagamento_pk.Name = "cod_pagamento_pk";
            this.cod_pagamento_pk.ReadOnly = true;
            this.cod_pagamento_pk.Width = 74;
            // 
            // atendimentos
            // 
            this.atendimentos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.atendimentos.DataPropertyName = "atendimentos";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.atendimentos.DefaultCellStyle = dataGridViewCellStyle3;
            this.atendimentos.HeaderText = "PEDIDOS ENVOLVIDOS";
            this.atendimentos.Name = "atendimentos";
            this.atendimentos.ReadOnly = true;
            this.atendimentos.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.atendimentos.Width = 139;
            // 
            // valor_pagamento
            // 
            this.valor_pagamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.valor_pagamento.DataPropertyName = "valor_pagamento";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.valor_pagamento.DefaultCellStyle = dataGridViewCellStyle4;
            this.valor_pagamento.HeaderText = "VALOR";
            this.valor_pagamento.Name = "valor_pagamento";
            this.valor_pagamento.ReadOnly = true;
            this.valor_pagamento.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.valor_pagamento.Width = 68;
            // 
            // troco_pagamento
            // 
            this.troco_pagamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.troco_pagamento.DataPropertyName = "troco_pagamento";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.troco_pagamento.DefaultCellStyle = dataGridViewCellStyle5;
            this.troco_pagamento.HeaderText = "TROCO";
            this.troco_pagamento.Name = "troco_pagamento";
            this.troco_pagamento.ReadOnly = true;
            this.troco_pagamento.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.troco_pagamento.Width = 70;
            // 
            // cod_meio_pgto_fk
            // 
            this.cod_meio_pgto_fk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cod_meio_pgto_fk.DataPropertyName = "cod_meio_pgto_fk";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cod_meio_pgto_fk.DefaultCellStyle = dataGridViewCellStyle6;
            this.cod_meio_pgto_fk.HeaderText = "MEIO PAGAMENTO";
            this.cod_meio_pgto_fk.Name = "cod_meio_pgto_fk";
            this.cod_meio_pgto_fk.ReadOnly = true;
            this.cod_meio_pgto_fk.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cod_meio_pgto_fk.Width = 119;
            // 
            // data_criacao_pagamento
            // 
            this.data_criacao_pagamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.data_criacao_pagamento.DataPropertyName = "data_criacao_pagamento";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.data_criacao_pagamento.DefaultCellStyle = dataGridViewCellStyle7;
            this.data_criacao_pagamento.HeaderText = "DATA PAGAMENTO";
            this.data_criacao_pagamento.Name = "data_criacao_pagamento";
            this.data_criacao_pagamento.ReadOnly = true;
            this.data_criacao_pagamento.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // data_alteracao_pagamento
            // 
            this.data_alteracao_pagamento.DataPropertyName = "data_alteracao_pagamento";
            this.data_alteracao_pagamento.HeaderText = "ALTERADO";
            this.data_alteracao_pagamento.Name = "data_alteracao_pagamento";
            this.data_alteracao_pagamento.ReadOnly = true;
            this.data_alteracao_pagamento.Visible = false;
            this.data_alteracao_pagamento.Width = 90;
            // 
            // estado_ativo_pagamento
            // 
            this.estado_ativo_pagamento.DataPropertyName = "estado_ativo_pagamento";
            this.estado_ativo_pagamento.HeaderText = "CANCELADO";
            this.estado_ativo_pagamento.Name = "estado_ativo_pagamento";
            this.estado_ativo_pagamento.ReadOnly = true;
            this.estado_ativo_pagamento.Visible = false;
            this.estado_ativo_pagamento.Width = 97;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txt_codigo);
            this.groupBox2.Controls.Add(this.chkbx_ativar_codigo);
            this.groupBox2.Location = new System.Drawing.Point(8, -14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 50);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(6, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 21);
            this.label16.TabIndex = 32;
            this.label16.Text = "Código:";
            // 
            // txt_codigo
            // 
            this.txt_codigo.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_codigo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_codigo.Enabled = false;
            this.txt_codigo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_codigo.Location = new System.Drawing.Point(69, 21);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(77, 22);
            this.txt_codigo.TabIndex = 31;
            this.txt_codigo.TextChanged += new System.EventHandler(this.txt_codigo_TextChanged);
            // 
            // chkbx_ativar_codigo
            // 
            this.chkbx_ativar_codigo.AutoSize = true;
            this.chkbx_ativar_codigo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkbx_ativar_codigo.ForeColor = System.Drawing.Color.DarkGreen;
            this.chkbx_ativar_codigo.Location = new System.Drawing.Point(152, 21);
            this.chkbx_ativar_codigo.Name = "chkbx_ativar_codigo";
            this.chkbx_ativar_codigo.Size = new System.Drawing.Size(64, 23);
            this.chkbx_ativar_codigo.TabIndex = 33;
            this.chkbx_ativar_codigo.Text = "Ativar";
            this.chkbx_ativar_codigo.UseVisualStyleBackColor = true;
            this.chkbx_ativar_codigo.CheckedChanged += new System.EventHandler(this.chkbx_ativar_codigo_CheckedChanged);
            // 
            // gbx_atendimento_valores
            // 
            this.gbx_atendimento_valores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_atendimento_valores.Controls.Add(this.label4);
            this.gbx_atendimento_valores.Controls.Add(this.chkbx_ativar_meioPagamento);
            this.gbx_atendimento_valores.Controls.Add(this.cbx_meios_pagamento);
            this.gbx_atendimento_valores.Controls.Add(this.txt_valor_troco);
            this.gbx_atendimento_valores.Controls.Add(this.label3);
            this.gbx_atendimento_valores.Controls.Add(this.chkbx_ativar_valorTroco);
            this.gbx_atendimento_valores.Controls.Add(this.txt_valor_pagamento);
            this.gbx_atendimento_valores.Controls.Add(this.label2);
            this.gbx_atendimento_valores.Controls.Add(this.chkbx_ativar_valorPagamento);
            this.gbx_atendimento_valores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbx_atendimento_valores.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbx_atendimento_valores.ForeColor = System.Drawing.Color.DimGray;
            this.gbx_atendimento_valores.Location = new System.Drawing.Point(9, 154);
            this.gbx_atendimento_valores.Name = "gbx_atendimento_valores";
            this.gbx_atendimento_valores.Size = new System.Drawing.Size(483, 151);
            this.gbx_atendimento_valores.TabIndex = 35;
            this.gbx_atendimento_valores.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(11, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 21);
            this.label4.TabIndex = 32;
            this.label4.Text = "Meio de Pagamento:";
            // 
            // chkbx_ativar_meioPagamento
            // 
            this.chkbx_ativar_meioPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkbx_ativar_meioPagamento.AutoSize = true;
            this.chkbx_ativar_meioPagamento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkbx_ativar_meioPagamento.ForeColor = System.Drawing.Color.Green;
            this.chkbx_ativar_meioPagamento.Location = new System.Drawing.Point(381, 108);
            this.chkbx_ativar_meioPagamento.Name = "chkbx_ativar_meioPagamento";
            this.chkbx_ativar_meioPagamento.Size = new System.Drawing.Size(94, 23);
            this.chkbx_ativar_meioPagamento.TabIndex = 31;
            this.chkbx_ativar_meioPagamento.Text = "Considerar";
            this.chkbx_ativar_meioPagamento.UseVisualStyleBackColor = true;
            this.chkbx_ativar_meioPagamento.CheckedChanged += new System.EventHandler(this.chkbx_ativar_meioPagamento_CheckedChanged);
            // 
            // cbx_meios_pagamento
            // 
            this.cbx_meios_pagamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_meios_pagamento.BackColor = System.Drawing.Color.Gainsboro;
            this.cbx_meios_pagamento.DisplayMember = "nome_tipo_contato";
            this.cbx_meios_pagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_meios_pagamento.FormattingEnabled = true;
            this.cbx_meios_pagamento.Location = new System.Drawing.Point(169, 104);
            this.cbx_meios_pagamento.Name = "cbx_meios_pagamento";
            this.cbx_meios_pagamento.Size = new System.Drawing.Size(196, 29);
            this.cbx_meios_pagamento.TabIndex = 30;
            // 
            // txt_valor_troco
            // 
            this.txt_valor_troco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_valor_troco.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_valor_troco.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_valor_troco.Enabled = false;
            this.txt_valor_troco.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_valor_troco.Location = new System.Drawing.Point(130, 66);
            this.txt_valor_troco.Name = "txt_valor_troco";
            this.txt_valor_troco.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_valor_troco.Size = new System.Drawing.Size(235, 22);
            this.txt_valor_troco.TabIndex = 28;
            this.txt_valor_troco.Text = "0,00";
            this.txt_valor_troco.TextChanged += new System.EventHandler(this.txt_valor_troco_TextChanged);
            this.txt_valor_troco.Validated += new System.EventHandler(this.txt_valor_troco_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(9, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 21);
            this.label3.TabIndex = 27;
            this.label3.Text = "Valor do Troco:";
            // 
            // chkbx_ativar_valorTroco
            // 
            this.chkbx_ativar_valorTroco.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkbx_ativar_valorTroco.AutoSize = true;
            this.chkbx_ativar_valorTroco.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkbx_ativar_valorTroco.ForeColor = System.Drawing.Color.Green;
            this.chkbx_ativar_valorTroco.Location = new System.Drawing.Point(381, 66);
            this.chkbx_ativar_valorTroco.Name = "chkbx_ativar_valorTroco";
            this.chkbx_ativar_valorTroco.Size = new System.Drawing.Size(94, 23);
            this.chkbx_ativar_valorTroco.TabIndex = 29;
            this.chkbx_ativar_valorTroco.Text = "Considerar";
            this.chkbx_ativar_valorTroco.UseVisualStyleBackColor = true;
            this.chkbx_ativar_valorTroco.CheckedChanged += new System.EventHandler(this.chkbx_ativar_valorTroco_CheckedChanged);
            // 
            // txt_valor_pagamento
            // 
            this.txt_valor_pagamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_valor_pagamento.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_valor_pagamento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_valor_pagamento.Enabled = false;
            this.txt_valor_pagamento.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_valor_pagamento.Location = new System.Drawing.Point(170, 25);
            this.txt_valor_pagamento.Name = "txt_valor_pagamento";
            this.txt_valor_pagamento.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_valor_pagamento.Size = new System.Drawing.Size(196, 22);
            this.txt_valor_pagamento.TabIndex = 24;
            this.txt_valor_pagamento.Text = "0,00";
            this.txt_valor_pagamento.TextChanged += new System.EventHandler(this.txt_valor_pagamento_TextChanged);
            this.txt_valor_pagamento.Validated += new System.EventHandler(this.txt_valor_pagamento_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 21);
            this.label2.TabIndex = 17;
            this.label2.Text = "Valor do Pagamento:";
            // 
            // chkbx_ativar_valorPagamento
            // 
            this.chkbx_ativar_valorPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkbx_ativar_valorPagamento.AutoSize = true;
            this.chkbx_ativar_valorPagamento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkbx_ativar_valorPagamento.ForeColor = System.Drawing.Color.Green;
            this.chkbx_ativar_valorPagamento.Location = new System.Drawing.Point(381, 25);
            this.chkbx_ativar_valorPagamento.Name = "chkbx_ativar_valorPagamento";
            this.chkbx_ativar_valorPagamento.Size = new System.Drawing.Size(94, 23);
            this.chkbx_ativar_valorPagamento.TabIndex = 26;
            this.chkbx_ativar_valorPagamento.Text = "Considerar";
            this.chkbx_ativar_valorPagamento.UseVisualStyleBackColor = true;
            this.chkbx_ativar_valorPagamento.CheckedChanged += new System.EventHandler(this.chkbx_ativar_valorPagamento_CheckedChanged);
            // 
            // gbx_dadosSelecionados
            // 
            this.gbx_dadosSelecionados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_dadosSelecionados.Controls.Add(this.flwpnl_atendimentosSelecionados);
            this.gbx_dadosSelecionados.Controls.Add(this.btn_adicionar);
            this.gbx_dadosSelecionados.Controls.Add(this.btn_pesquisarAtendimento);
            this.gbx_dadosSelecionados.Controls.Add(this.cbx_atendimento);
            this.gbx_dadosSelecionados.Controls.Add(this.label1);
            this.gbx_dadosSelecionados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbx_dadosSelecionados.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbx_dadosSelecionados.ForeColor = System.Drawing.Color.DimGray;
            this.gbx_dadosSelecionados.Location = new System.Drawing.Point(8, 36);
            this.gbx_dadosSelecionados.Name = "gbx_dadosSelecionados";
            this.gbx_dadosSelecionados.Size = new System.Drawing.Size(985, 112);
            this.gbx_dadosSelecionados.TabIndex = 34;
            this.gbx_dadosSelecionados.TabStop = false;
            this.gbx_dadosSelecionados.Text = "Selecionar";
            // 
            // flwpnl_atendimentosSelecionados
            // 
            this.flwpnl_atendimentosSelecionados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flwpnl_atendimentosSelecionados.AutoScroll = true;
            this.flwpnl_atendimentosSelecionados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flwpnl_atendimentosSelecionados.Location = new System.Drawing.Point(15, 66);
            this.flwpnl_atendimentosSelecionados.Name = "flwpnl_atendimentosSelecionados";
            this.flwpnl_atendimentosSelecionados.Size = new System.Drawing.Size(951, 37);
            this.flwpnl_atendimentosSelecionados.TabIndex = 24;
            // 
            // btn_adicionar
            // 
            this.btn_adicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_adicionar.BackColor = System.Drawing.Color.Green;
            this.btn_adicionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_adicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_adicionar.ForeColor = System.Drawing.Color.Black;
            this.btn_adicionar.Image = global::gerenciador_antt.Properties.Resources.adicionar_micro;
            this.btn_adicionar.Location = new System.Drawing.Point(894, 31);
            this.btn_adicionar.Name = "btn_adicionar";
            this.btn_adicionar.Size = new System.Drawing.Size(72, 29);
            this.btn_adicionar.TabIndex = 23;
            this.btn_adicionar.UseVisualStyleBackColor = false;
            this.btn_adicionar.Click += new System.EventHandler(this.btn_adicionar_Click);
            // 
            // btn_pesquisarAtendimento
            // 
            this.btn_pesquisarAtendimento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_pesquisarAtendimento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(36)))), ((int)(((byte)(60)))));
            this.btn_pesquisarAtendimento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_pesquisarAtendimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pesquisarAtendimento.ForeColor = System.Drawing.Color.White;
            this.btn_pesquisarAtendimento.Image = global::gerenciador_antt.Properties.Resources.procurar_lupa_micro;
            this.btn_pesquisarAtendimento.Location = new System.Drawing.Point(858, 31);
            this.btn_pesquisarAtendimento.Name = "btn_pesquisarAtendimento";
            this.btn_pesquisarAtendimento.Size = new System.Drawing.Size(30, 29);
            this.btn_pesquisarAtendimento.TabIndex = 22;
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
            this.cbx_atendimento.Location = new System.Drawing.Point(121, 31);
            this.cbx_atendimento.Name = "cbx_atendimento";
            this.cbx_atendimento.Size = new System.Drawing.Size(733, 29);
            this.cbx_atendimento.TabIndex = 21;
            this.cbx_atendimento.ValueMember = "cod_tipo_contato_pk";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(18, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 21);
            this.label1.TabIndex = 20;
            this.label1.Text = "Atendimento:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rdbtn_contem);
            this.groupBox1.Controls.Add(this.rdbtn_igual);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox1.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox1.Location = new System.Drawing.Point(498, 154);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(129, 150);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consideração";
            // 
            // rdbtn_contem
            // 
            this.rdbtn_contem.AutoSize = true;
            this.rdbtn_contem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rdbtn_contem.ForeColor = System.Drawing.Color.DarkGreen;
            this.rdbtn_contem.Location = new System.Drawing.Point(20, 88);
            this.rdbtn_contem.Name = "rdbtn_contem";
            this.rdbtn_contem.Size = new System.Drawing.Size(76, 23);
            this.rdbtn_contem.TabIndex = 1;
            this.rdbtn_contem.Text = "Contêm";
            this.rdbtn_contem.UseVisualStyleBackColor = true;
            // 
            // rdbtn_igual
            // 
            this.rdbtn_igual.AutoSize = true;
            this.rdbtn_igual.Checked = true;
            this.rdbtn_igual.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rdbtn_igual.ForeColor = System.Drawing.Color.DarkGreen;
            this.rdbtn_igual.Location = new System.Drawing.Point(20, 52);
            this.rdbtn_igual.Name = "rdbtn_igual";
            this.rdbtn_igual.Size = new System.Drawing.Size(57, 23);
            this.rdbtn_igual.TabIndex = 0;
            this.rdbtn_igual.TabStop = true;
            this.rdbtn_igual.Text = "Igual";
            this.rdbtn_igual.UseVisualStyleBackColor = true;
            // 
            // btn_pesquisar
            // 
            this.btn_pesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_pesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(36)))), ((int)(((byte)(60)))));
            this.btn_pesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pesquisar.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.btn_pesquisar.ForeColor = System.Drawing.Color.White;
            this.btn_pesquisar.Image = global::gerenciador_antt.Properties.Resources.procurar_doc;
            this.btn_pesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_pesquisar.Location = new System.Drawing.Point(781, 165);
            this.btn_pesquisar.Name = "btn_pesquisar";
            this.btn_pesquisar.Size = new System.Drawing.Size(209, 139);
            this.btn_pesquisar.TabIndex = 20;
            this.btn_pesquisar.Text = "Pesquisar";
            this.btn_pesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_pesquisar.UseVisualStyleBackColor = false;
            this.btn_pesquisar.Click += new System.EventHandler(this.btn_pesquisar_Click);
            // 
            // btn_detalhar
            // 
            this.btn_detalhar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_detalhar.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_detalhar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_detalhar.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.btn_detalhar.ForeColor = System.Drawing.Color.White;
            this.btn_detalhar.Image = global::gerenciador_antt.Properties.Resources.privacidade;
            this.btn_detalhar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_detalhar.Location = new System.Drawing.Point(781, 330);
            this.btn_detalhar.Name = "btn_detalhar";
            this.btn_detalhar.Size = new System.Drawing.Size(209, 84);
            this.btn_detalhar.TabIndex = 19;
            this.btn_detalhar.Text = "Detalhe";
            this.btn_detalhar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_detalhar.UseVisualStyleBackColor = false;
            this.btn_detalhar.Click += new System.EventHandler(this.btn_detalhar_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(5, 306);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(154, 21);
            this.label14.TabIndex = 18;
            this.label14.Text = "Resultados da Busca:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.chkbx_alterados);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox3.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox3.Location = new System.Drawing.Point(633, 154);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(142, 151);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Estado";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.rbtn_pagamentos_ativos);
            this.panel1.Controls.Add(this.rbtn_pagamentos_cancelados);
            this.panel1.Location = new System.Drawing.Point(16, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(110, 74);
            this.panel1.TabIndex = 45;
            // 
            // rbtn_pagamentos_ativos
            // 
            this.rbtn_pagamentos_ativos.AutoSize = true;
            this.rbtn_pagamentos_ativos.Checked = true;
            this.rbtn_pagamentos_ativos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbtn_pagamentos_ativos.ForeColor = System.Drawing.Color.DarkGreen;
            this.rbtn_pagamentos_ativos.Location = new System.Drawing.Point(11, 7);
            this.rbtn_pagamentos_ativos.Name = "rbtn_pagamentos_ativos";
            this.rbtn_pagamentos_ativos.Size = new System.Drawing.Size(65, 23);
            this.rbtn_pagamentos_ativos.TabIndex = 44;
            this.rbtn_pagamentos_ativos.TabStop = true;
            this.rbtn_pagamentos_ativos.Text = "Ativos";
            this.rbtn_pagamentos_ativos.UseVisualStyleBackColor = true;
            // 
            // rbtn_pagamentos_cancelados
            // 
            this.rbtn_pagamentos_cancelados.AutoSize = true;
            this.rbtn_pagamentos_cancelados.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbtn_pagamentos_cancelados.ForeColor = System.Drawing.Color.Red;
            this.rbtn_pagamentos_cancelados.Location = new System.Drawing.Point(11, 38);
            this.rbtn_pagamentos_cancelados.Name = "rbtn_pagamentos_cancelados";
            this.rbtn_pagamentos_cancelados.Size = new System.Drawing.Size(96, 23);
            this.rbtn_pagamentos_cancelados.TabIndex = 43;
            this.rbtn_pagamentos_cancelados.Text = "Cancelados";
            this.rbtn_pagamentos_cancelados.UseVisualStyleBackColor = true;
            // 
            // chkbx_alterados
            // 
            this.chkbx_alterados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkbx_alterados.AutoSize = true;
            this.chkbx_alterados.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_alterados.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkbx_alterados.ForeColor = System.Drawing.Color.Green;
            this.chkbx_alterados.Location = new System.Drawing.Point(26, 110);
            this.chkbx_alterados.Name = "chkbx_alterados";
            this.chkbx_alterados.Size = new System.Drawing.Size(86, 23);
            this.chkbx_alterados.TabIndex = 12;
            this.chkbx_alterados.Text = "Alterados";
            this.chkbx_alterados.UseVisualStyleBackColor = false;
            // 
            // btn_escolher_selecionado
            // 
            this.btn_escolher_selecionado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_escolher_selecionado.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_escolher_selecionado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_escolher_selecionado.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.btn_escolher_selecionado.ForeColor = System.Drawing.Color.White;
            this.btn_escolher_selecionado.Image = global::gerenciador_antt.Properties.Resources.user;
            this.btn_escolher_selecionado.Location = new System.Drawing.Point(781, 507);
            this.btn_escolher_selecionado.Name = "btn_escolher_selecionado";
            this.btn_escolher_selecionado.Size = new System.Drawing.Size(209, 140);
            this.btn_escolher_selecionado.TabIndex = 16;
            this.btn_escolher_selecionado.Text = "Escolher Selecionado";
            this.btn_escolher_selecionado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_escolher_selecionado.UseVisualStyleBackColor = false;
            this.btn_escolher_selecionado.Click += new System.EventHandler(this.btn_escolher_selecionado_Click);
            // 
            // dtpckr_dataCriacao
            // 
            this.dtpckr_dataCriacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpckr_dataCriacao.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtpckr_dataCriacao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpckr_dataCriacao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpckr_dataCriacao.Location = new System.Drawing.Point(372, 8);
            this.dtpckr_dataCriacao.Name = "dtpckr_dataCriacao";
            this.dtpckr_dataCriacao.Size = new System.Drawing.Size(91, 25);
            this.dtpckr_dataCriacao.TabIndex = 36;
            this.dtpckr_dataCriacao.Value = new System.DateTime(2014, 11, 18, 0, 0, 0, 0);
            // 
            // btn_alterar
            // 
            this.btn_alterar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_alterar.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_alterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_alterar.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.btn_alterar.ForeColor = System.Drawing.Color.White;
            this.btn_alterar.Image = global::gerenciador_antt.Properties.Resources.editar;
            this.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_alterar.Location = new System.Drawing.Point(781, 417);
            this.btn_alterar.Name = "btn_alterar";
            this.btn_alterar.Size = new System.Drawing.Size(209, 87);
            this.btn_alterar.TabIndex = 10;
            this.btn_alterar.Text = "Alterar";
            this.btn_alterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_alterar.UseVisualStyleBackColor = false;
            this.btn_alterar.Click += new System.EventHandler(this.btn_alterar_Click);
            // 
            // lbl_data
            // 
            this.lbl_data.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_data.AutoSize = true;
            this.lbl_data.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbl_data.ForeColor = System.Drawing.Color.Black;
            this.lbl_data.Location = new System.Drawing.Point(235, 9);
            this.lbl_data.Name = "lbl_data";
            this.lbl_data.Size = new System.Drawing.Size(139, 21);
            this.lbl_data.TabIndex = 37;
            this.lbl_data.Text = "Data de realização:";
            // 
            // chkbx_ativar_data
            // 
            this.chkbx_ativar_data.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkbx_ativar_data.AutoSize = true;
            this.chkbx_ativar_data.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_ativar_data.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkbx_ativar_data.ForeColor = System.Drawing.Color.Green;
            this.chkbx_ativar_data.Location = new System.Drawing.Point(470, 9);
            this.chkbx_ativar_data.Name = "chkbx_ativar_data";
            this.chkbx_ativar_data.Size = new System.Drawing.Size(64, 23);
            this.chkbx_ativar_data.TabIndex = 38;
            this.chkbx_ativar_data.Text = "Ativar";
            this.chkbx_ativar_data.UseVisualStyleBackColor = false;
            this.chkbx_ativar_data.CheckedChanged += new System.EventHandler(this.chkbx_ativar_data_CheckedChanged);
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
            this.btn_fechar.TabIndex = 14;
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
            // Uc_pagamento_pesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnl_centro);
            this.Name = "Uc_pagamento_pesquisa";
            this.Size = new System.Drawing.Size(1146, 665);
            this.Load += new System.EventHandler(this.Uc_pagamento_pesquisa_Load);
            this.pnl_centro.ResumeLayout(false);
            this.pnl_centro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_resultados)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbx_atendimento_valores.ResumeLayout(false);
            this.gbx_atendimento_valores.PerformLayout();
            this.gbx_dadosSelecionados.ResumeLayout(false);
            this.gbx_dadosSelecionados.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_fechar.ResumeLayout(false);
            this.pnl_fechar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_centro;
        private System.Windows.Forms.Button btn_alterar;
        private System.Windows.Forms.Panel pnl_fechar;
        private System.Windows.Forms.Button btn_fechar;
        private System.Windows.Forms.Label lbl_fechar;
        private System.Windows.Forms.Button btn_escolher_selecionado;
        private System.Windows.Forms.Button btn_detalhar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btn_pesquisar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbtn_igual;
        private System.Windows.Forms.RadioButton rdbtn_contem;
        private System.Windows.Forms.CheckBox chkbx_ativar_codigo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_codigo;
        private System.Windows.Forms.CheckBox chkbx_alterados;
        private System.Windows.Forms.GroupBox gbx_atendimento_valores;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_valor_pagamento;
        private System.Windows.Forms.CheckBox chkbx_ativar_valorPagamento;
        private System.Windows.Forms.GroupBox gbx_dadosSelecionados;
        private System.Windows.Forms.CheckBox chkbx_ativar_data;
        private System.Windows.Forms.DateTimePicker dtpckr_dataCriacao;
        private System.Windows.Forms.Label lbl_data;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dtg_resultados;
        private System.Windows.Forms.Button btn_adicionar;
        private System.Windows.Forms.Button btn_pesquisarAtendimento;
        private System.Windows.Forms.ComboBox cbx_atendimento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_valor_troco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkbx_ativar_valorTroco;
        private System.Windows.Forms.FlowLayoutPanel flwpnl_atendimentosSelecionados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkbx_ativar_meioPagamento;
        private System.Windows.Forms.ComboBox cbx_meios_pagamento;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtn_pagamentos_ativos;
        private System.Windows.Forms.RadioButton rbtn_pagamentos_cancelados;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_pagamento_pk;
        private System.Windows.Forms.DataGridViewTextBoxColumn atendimentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor_pagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn troco_pagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_meio_pgto_fk;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_criacao_pagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_alteracao_pagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado_ativo_pagamento;

    }
}
