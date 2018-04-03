namespace gerenciador_antt.Formularios
{
    partial class Uc_atendimento_pesquisa
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
            this.cod_atendimento_pk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_cliente_fk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_responsavel_fk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado_pago_atendimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_criacao_atendimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_codigo = new System.Windows.Forms.TextBox();
            this.chkbx__ativar_codigo = new System.Windows.Forms.CheckBox();
            this.gbx_atendimento_servico = new System.Windows.Forms.GroupBox();
            this.txt_descricao_servico = new System.Windows.Forms.TextBox();
            this.txt_valor_servico = new System.Windows.Forms.TextBox();
            this.btn_receberPreco = new System.Windows.Forms.Button();
            this.cbx_servico = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkbx_ativar_precoServico = new System.Windows.Forms.CheckBox();
            this.chkbx_ativar_servico = new System.Windows.Forms.CheckBox();
            this.gbx_dadosSelecionados = new System.Windows.Forms.GroupBox();
            this.chkbx_ativarCliente = new System.Windows.Forms.CheckBox();
            this.btn_pesquisarCliente = new System.Windows.Forms.Button();
            this.cbx_cliente = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkbx_ativarResponsavel = new System.Windows.Forms.CheckBox();
            this.btn_pesquisarResponsavel = new System.Windows.Forms.Button();
            this.cbx_responsavel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbtn_contem = new System.Windows.Forms.RadioButton();
            this.rdbtn_igual = new System.Windows.Forms.RadioButton();
            this.btn_pesquisar = new System.Windows.Forms.Button();
            this.btn_detalhar = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkbx_totalmenteFinalizado = new System.Windows.Forms.CheckBox();
            this.chkbx_totalmentePago = new System.Windows.Forms.CheckBox();
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
            this.gbx_atendimento_servico.SuspendLayout();
            this.gbx_dadosSelecionados.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.pnl_centro.Controls.Add(this.gbx_atendimento_servico);
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
            this.cod_atendimento_pk,
            this.cod_cliente_fk,
            this.cod_responsavel_fk,
            this.pago,
            this.valor,
            this.estado_pago_atendimento,
            this.data_criacao_atendimento});
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
            this.dtg_resultados.TabIndex = 11;
            this.dtg_resultados.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtg_resultados_ColumnHeaderMouseClick);
            this.dtg_resultados.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_resultados_CellContentDoubleClick);
            this.dtg_resultados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_resultados_CellContentDoubleClick);
            // 
            // cod_atendimento_pk
            // 
            this.cod_atendimento_pk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cod_atendimento_pk.DataPropertyName = "cod_atendimento_pk";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cod_atendimento_pk.DefaultCellStyle = dataGridViewCellStyle2;
            this.cod_atendimento_pk.HeaderText = "CODIGO";
            this.cod_atendimento_pk.Name = "cod_atendimento_pk";
            this.cod_atendimento_pk.ReadOnly = true;
            this.cod_atendimento_pk.Width = 74;
            // 
            // cod_cliente_fk
            // 
            this.cod_cliente_fk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cod_cliente_fk.DataPropertyName = "cod_cliente_fk";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cod_cliente_fk.DefaultCellStyle = dataGridViewCellStyle3;
            this.cod_cliente_fk.HeaderText = "CLIENTE";
            this.cod_cliente_fk.Name = "cod_cliente_fk";
            this.cod_cliente_fk.ReadOnly = true;
            this.cod_cliente_fk.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cod_cliente_fk.Width = 77;
            // 
            // cod_responsavel_fk
            // 
            this.cod_responsavel_fk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cod_responsavel_fk.DataPropertyName = "cod_responsavel_fk";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cod_responsavel_fk.DefaultCellStyle = dataGridViewCellStyle4;
            this.cod_responsavel_fk.HeaderText = "RESPONSÁVEL";
            this.cod_responsavel_fk.Name = "cod_responsavel_fk";
            this.cod_responsavel_fk.ReadOnly = true;
            this.cod_responsavel_fk.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cod_responsavel_fk.Width = 111;
            // 
            // pago
            // 
            this.pago.DataPropertyName = "pago";
            this.pago.HeaderText = "VALOR PAGO";
            this.pago.Name = "pago";
            this.pago.ReadOnly = true;
            this.pago.Width = 93;
            // 
            // valor
            // 
            this.valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.valor.DataPropertyName = "valor";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.valor.DefaultCellStyle = dataGridViewCellStyle5;
            this.valor.HeaderText = "VALOR TOTAL";
            this.valor.Name = "valor";
            this.valor.ReadOnly = true;
            this.valor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.valor.Width = 97;
            // 
            // estado_pago_atendimento
            // 
            this.estado_pago_atendimento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.estado_pago_atendimento.DataPropertyName = "estado_pago_atendimento";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estado_pago_atendimento.DefaultCellStyle = dataGridViewCellStyle6;
            this.estado_pago_atendimento.HeaderText = "ESTADO PAGAMENTO";
            this.estado_pago_atendimento.Name = "estado_pago_atendimento";
            this.estado_pago_atendimento.ReadOnly = true;
            this.estado_pago_atendimento.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.estado_pago_atendimento.Width = 134;
            // 
            // data_criacao_atendimento
            // 
            this.data_criacao_atendimento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.data_criacao_atendimento.DataPropertyName = "data_criacao_atendimento";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.data_criacao_atendimento.DefaultCellStyle = dataGridViewCellStyle7;
            this.data_criacao_atendimento.HeaderText = "DATA ATENDIMENTO";
            this.data_criacao_atendimento.Name = "data_criacao_atendimento";
            this.data_criacao_atendimento.ReadOnly = true;
            this.data_criacao_atendimento.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txt_codigo);
            this.groupBox2.Controls.Add(this.chkbx__ativar_codigo);
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
            this.txt_codigo.TabStop = false;
            this.txt_codigo.TextChanged += new System.EventHandler(this.txt_codigo_TextChanged);
            // 
            // chkbx__ativar_codigo
            // 
            this.chkbx__ativar_codigo.AutoSize = true;
            this.chkbx__ativar_codigo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkbx__ativar_codigo.ForeColor = System.Drawing.Color.DarkGreen;
            this.chkbx__ativar_codigo.Location = new System.Drawing.Point(152, 21);
            this.chkbx__ativar_codigo.Name = "chkbx__ativar_codigo";
            this.chkbx__ativar_codigo.Size = new System.Drawing.Size(64, 23);
            this.chkbx__ativar_codigo.TabIndex = 0;
            this.chkbx__ativar_codigo.Text = "Ativar";
            this.chkbx__ativar_codigo.UseVisualStyleBackColor = true;
            this.chkbx__ativar_codigo.CheckedChanged += new System.EventHandler(this.chkbx__ativar_codigo_CheckedChanged);
            // 
            // gbx_atendimento_servico
            // 
            this.gbx_atendimento_servico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_atendimento_servico.Controls.Add(this.txt_descricao_servico);
            this.gbx_atendimento_servico.Controls.Add(this.txt_valor_servico);
            this.gbx_atendimento_servico.Controls.Add(this.btn_receberPreco);
            this.gbx_atendimento_servico.Controls.Add(this.cbx_servico);
            this.gbx_atendimento_servico.Controls.Add(this.label2);
            this.gbx_atendimento_servico.Controls.Add(this.chkbx_ativar_precoServico);
            this.gbx_atendimento_servico.Controls.Add(this.chkbx_ativar_servico);
            this.gbx_atendimento_servico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbx_atendimento_servico.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbx_atendimento_servico.ForeColor = System.Drawing.Color.DimGray;
            this.gbx_atendimento_servico.Location = new System.Drawing.Point(9, 154);
            this.gbx_atendimento_servico.Name = "gbx_atendimento_servico";
            this.gbx_atendimento_servico.Size = new System.Drawing.Size(529, 151);
            this.gbx_atendimento_servico.TabIndex = 35;
            this.gbx_atendimento_servico.TabStop = false;
            this.gbx_atendimento_servico.Text = "Serviço";
            // 
            // txt_descricao_servico
            // 
            this.txt_descricao_servico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_descricao_servico.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_descricao_servico.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_descricao_servico.Enabled = false;
            this.txt_descricao_servico.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_descricao_servico.Location = new System.Drawing.Point(14, 65);
            this.txt_descricao_servico.Multiline = true;
            this.txt_descricao_servico.Name = "txt_descricao_servico";
            this.txt_descricao_servico.ReadOnly = true;
            this.txt_descricao_servico.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_descricao_servico.Size = new System.Drawing.Size(498, 46);
            this.txt_descricao_servico.TabIndex = 25;
            this.txt_descricao_servico.TabStop = false;
            // 
            // txt_valor_servico
            // 
            this.txt_valor_servico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_valor_servico.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_valor_servico.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_valor_servico.Enabled = false;
            this.txt_valor_servico.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_valor_servico.Location = new System.Drawing.Point(91, 118);
            this.txt_valor_servico.Name = "txt_valor_servico";
            this.txt_valor_servico.ReadOnly = true;
            this.txt_valor_servico.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_valor_servico.Size = new System.Drawing.Size(332, 22);
            this.txt_valor_servico.TabIndex = 24;
            this.txt_valor_servico.TabStop = false;
            // 
            // btn_receberPreco
            // 
            this.btn_receberPreco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_receberPreco.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_receberPreco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(36)))), ((int)(((byte)(60)))));
            this.btn_receberPreco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_receberPreco.Enabled = false;
            this.btn_receberPreco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_receberPreco.ForeColor = System.Drawing.Color.White;
            this.btn_receberPreco.Image = global::gerenciador_antt.Properties.Resources.preco_micro;
            this.btn_receberPreco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_receberPreco.Location = new System.Drawing.Point(14, 30);
            this.btn_receberPreco.Name = "btn_receberPreco";
            this.btn_receberPreco.Size = new System.Drawing.Size(152, 29);
            this.btn_receberPreco.TabIndex = 5;
            this.btn_receberPreco.TabStop = false;
            this.btn_receberPreco.Text = "Receber Preço";
            this.btn_receberPreco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_receberPreco.UseVisualStyleBackColor = false;
            this.btn_receberPreco.Click += new System.EventHandler(this.btn_receberPreco_Click);
            // 
            // cbx_servico
            // 
            this.cbx_servico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_servico.BackColor = System.Drawing.Color.Gainsboro;
            this.cbx_servico.DisplayMember = "nome_tipo_endereco";
            this.cbx_servico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_servico.Enabled = false;
            this.cbx_servico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbx_servico.FormattingEnabled = true;
            this.cbx_servico.Location = new System.Drawing.Point(172, 30);
            this.cbx_servico.Name = "cbx_servico";
            this.cbx_servico.Size = new System.Drawing.Size(257, 29);
            this.cbx_servico.TabIndex = 4;
            this.cbx_servico.TabStop = false;
            this.cbx_servico.ValueMember = "cod_tipo_endereco_pk";
            this.cbx_servico.SizeChanged += new System.EventHandler(this.cbx_servico_SizeChanged);
            this.cbx_servico.SelectedValueChanged += new System.EventHandler(this.cbx_servico_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 17;
            this.label2.Text = "Preço: R$";
            // 
            // chkbx_ativar_precoServico
            // 
            this.chkbx_ativar_precoServico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkbx_ativar_precoServico.AutoSize = true;
            this.chkbx_ativar_precoServico.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkbx_ativar_precoServico.ForeColor = System.Drawing.Color.Green;
            this.chkbx_ativar_precoServico.Location = new System.Drawing.Point(429, 117);
            this.chkbx_ativar_precoServico.Name = "chkbx_ativar_precoServico";
            this.chkbx_ativar_precoServico.Size = new System.Drawing.Size(94, 23);
            this.chkbx_ativar_precoServico.TabIndex = 5;
            this.chkbx_ativar_precoServico.Text = "Considerar";
            this.chkbx_ativar_precoServico.UseVisualStyleBackColor = true;
            this.chkbx_ativar_precoServico.CheckedChanged += new System.EventHandler(this.chkbx_ativar_precoServico_CheckedChanged);
            // 
            // chkbx_ativar_servico
            // 
            this.chkbx_ativar_servico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkbx_ativar_servico.AutoSize = true;
            this.chkbx_ativar_servico.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_ativar_servico.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkbx_ativar_servico.ForeColor = System.Drawing.Color.Green;
            this.chkbx_ativar_servico.Location = new System.Drawing.Point(435, 35);
            this.chkbx_ativar_servico.Name = "chkbx_ativar_servico";
            this.chkbx_ativar_servico.Size = new System.Drawing.Size(94, 23);
            this.chkbx_ativar_servico.TabIndex = 4;
            this.chkbx_ativar_servico.Text = "Considerar";
            this.chkbx_ativar_servico.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkbx_ativar_servico.UseVisualStyleBackColor = false;
            this.chkbx_ativar_servico.CheckedChanged += new System.EventHandler(this.chkbx_ativar_servico_CheckedChanged);
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
            this.gbx_dadosSelecionados.Location = new System.Drawing.Point(8, 36);
            this.gbx_dadosSelecionados.Name = "gbx_dadosSelecionados";
            this.gbx_dadosSelecionados.Size = new System.Drawing.Size(985, 114);
            this.gbx_dadosSelecionados.TabIndex = 34;
            this.gbx_dadosSelecionados.TabStop = false;
            this.gbx_dadosSelecionados.Text = "Selecionar";
            // 
            // chkbx_ativarCliente
            // 
            this.chkbx_ativarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkbx_ativarCliente.AutoSize = true;
            this.chkbx_ativarCliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkbx_ativarCliente.ForeColor = System.Drawing.Color.Green;
            this.chkbx_ativarCliente.Location = new System.Drawing.Point(902, 71);
            this.chkbx_ativarCliente.Name = "chkbx_ativarCliente";
            this.chkbx_ativarCliente.Size = new System.Drawing.Size(64, 23);
            this.chkbx_ativarCliente.TabIndex = 3;
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
            this.btn_pesquisarCliente.Location = new System.Drawing.Point(865, 67);
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
            this.cbx_cliente.Size = new System.Drawing.Size(745, 29);
            this.cbx_cliente.TabIndex = 13;
            this.cbx_cliente.TabStop = false;
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
            this.chkbx_ativarResponsavel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkbx_ativarResponsavel.ForeColor = System.Drawing.Color.Green;
            this.chkbx_ativarResponsavel.Location = new System.Drawing.Point(902, 36);
            this.chkbx_ativarResponsavel.Name = "chkbx_ativarResponsavel";
            this.chkbx_ativarResponsavel.Size = new System.Drawing.Size(64, 23);
            this.chkbx_ativarResponsavel.TabIndex = 2;
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
            this.btn_pesquisarResponsavel.Location = new System.Drawing.Point(865, 31);
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
            this.cbx_responsavel.Size = new System.Drawing.Size(745, 29);
            this.cbx_responsavel.TabIndex = 5;
            this.cbx_responsavel.TabStop = false;
            this.cbx_responsavel.ValueMember = "cod_tipo_contato_pk";
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rdbtn_contem);
            this.groupBox1.Controls.Add(this.rdbtn_igual);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox1.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox1.Location = new System.Drawing.Point(544, 154);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 150);
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
            this.rdbtn_contem.TabIndex = 7;
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
            this.rdbtn_igual.TabIndex = 6;
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
            this.btn_pesquisar.TabIndex = 10;
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
            this.btn_detalhar.TabIndex = 12;
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
            this.groupBox3.Controls.Add(this.chkbx_totalmenteFinalizado);
            this.groupBox3.Controls.Add(this.chkbx_totalmentePago);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox3.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox3.Location = new System.Drawing.Point(667, 154);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(108, 151);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Estado";
            // 
            // chkbx_totalmenteFinalizado
            // 
            this.chkbx_totalmenteFinalizado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkbx_totalmenteFinalizado.AutoSize = true;
            this.chkbx_totalmenteFinalizado.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_totalmenteFinalizado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkbx_totalmenteFinalizado.ForeColor = System.Drawing.Color.Green;
            this.chkbx_totalmenteFinalizado.Location = new System.Drawing.Point(13, 53);
            this.chkbx_totalmenteFinalizado.Name = "chkbx_totalmenteFinalizado";
            this.chkbx_totalmenteFinalizado.Size = new System.Drawing.Size(88, 23);
            this.chkbx_totalmenteFinalizado.TabIndex = 8;
            this.chkbx_totalmenteFinalizado.Text = "Finalizado";
            this.chkbx_totalmenteFinalizado.UseVisualStyleBackColor = false;
            // 
            // chkbx_totalmentePago
            // 
            this.chkbx_totalmentePago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkbx_totalmentePago.AutoSize = true;
            this.chkbx_totalmentePago.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_totalmentePago.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkbx_totalmentePago.ForeColor = System.Drawing.Color.Green;
            this.chkbx_totalmentePago.Location = new System.Drawing.Point(13, 88);
            this.chkbx_totalmentePago.Name = "chkbx_totalmentePago";
            this.chkbx_totalmentePago.Size = new System.Drawing.Size(59, 23);
            this.chkbx_totalmentePago.TabIndex = 9;
            this.chkbx_totalmentePago.Text = "Pago";
            this.chkbx_totalmentePago.UseVisualStyleBackColor = false;
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
            this.btn_escolher_selecionado.TabIndex = 14;
            this.btn_escolher_selecionado.Text = "Escolher Selecionado";
            this.btn_escolher_selecionado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_escolher_selecionado.UseVisualStyleBackColor = false;
            this.btn_escolher_selecionado.Click += new System.EventHandler(this.btn_escolher_selecionado_Click);
            // 
            // dtpckr_dataCriacao
            // 
            this.dtpckr_dataCriacao.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtpckr_dataCriacao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpckr_dataCriacao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpckr_dataCriacao.Location = new System.Drawing.Point(372, 8);
            this.dtpckr_dataCriacao.Name = "dtpckr_dataCriacao";
            this.dtpckr_dataCriacao.Size = new System.Drawing.Size(91, 25);
            this.dtpckr_dataCriacao.TabIndex = 36;
            this.dtpckr_dataCriacao.TabStop = false;
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
            this.btn_alterar.TabIndex = 13;
            this.btn_alterar.Text = "Alterar";
            this.btn_alterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_alterar.UseVisualStyleBackColor = false;
            this.btn_alterar.Click += new System.EventHandler(this.btn_alterar_Click);
            // 
            // lbl_data
            // 
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
            this.chkbx_ativar_data.AutoSize = true;
            this.chkbx_ativar_data.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_ativar_data.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkbx_ativar_data.ForeColor = System.Drawing.Color.Green;
            this.chkbx_ativar_data.Location = new System.Drawing.Point(470, 9);
            this.chkbx_ativar_data.Name = "chkbx_ativar_data";
            this.chkbx_ativar_data.Size = new System.Drawing.Size(64, 23);
            this.chkbx_ativar_data.TabIndex = 1;
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
            this.btn_fechar.TabIndex = 15;
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
            // Uc_atendimento_pesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnl_centro);
            this.Name = "Uc_atendimento_pesquisa";
            this.Size = new System.Drawing.Size(1146, 665);
            this.Load += new System.EventHandler(this.Uc_cliente_pesquisa_Load);
            this.pnl_centro.ResumeLayout(false);
            this.pnl_centro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_resultados)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbx_atendimento_servico.ResumeLayout(false);
            this.gbx_atendimento_servico.PerformLayout();
            this.gbx_dadosSelecionados.ResumeLayout(false);
            this.gbx_dadosSelecionados.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.CheckBox chkbx__ativar_codigo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_codigo;
        private System.Windows.Forms.CheckBox chkbx_totalmenteFinalizado;
        private System.Windows.Forms.CheckBox chkbx_totalmentePago;
        private System.Windows.Forms.GroupBox gbx_atendimento_servico;
        private System.Windows.Forms.ComboBox cbx_servico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_descricao_servico;
        private System.Windows.Forms.TextBox txt_valor_servico;
        private System.Windows.Forms.Button btn_receberPreco;
        private System.Windows.Forms.CheckBox chkbx_ativar_precoServico;
        private System.Windows.Forms.GroupBox gbx_dadosSelecionados;
        private System.Windows.Forms.CheckBox chkbx_ativarCliente;
        private System.Windows.Forms.Button btn_pesquisarCliente;
        private System.Windows.Forms.ComboBox cbx_cliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkbx_ativarResponsavel;
        private System.Windows.Forms.Button btn_pesquisarResponsavel;
        private System.Windows.Forms.ComboBox cbx_responsavel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkbx_ativar_data;
        private System.Windows.Forms.DateTimePicker dtpckr_dataCriacao;
        private System.Windows.Forms.Label lbl_data;
        private System.Windows.Forms.CheckBox chkbx_ativar_servico;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dtg_resultados;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_atendimento_pk;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_cliente_fk;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_responsavel_fk;
        private System.Windows.Forms.DataGridViewTextBoxColumn pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado_pago_atendimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_criacao_atendimento;

    }
}
