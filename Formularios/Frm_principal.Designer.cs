namespace gerenciador_antt
{
    partial class frm_principal
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_principal));
            this.pnl_lateral_opcao = new System.Windows.Forms.Panel();
            this.pctbx_config = new System.Windows.Forms.PictureBox();
            this.pctbx_calculadora = new System.Windows.Forms.PictureBox();
            this.pctbx_deslogar = new System.Windows.Forms.PictureBox();
            this.pnl_conteudo = new System.Windows.Forms.Panel();
            this.lbl_titulo_tela = new System.Windows.Forms.Label();
            this.lbl_descricao_tela = new System.Windows.Forms.Label();
            this.pnl_titulo = new System.Windows.Forms.Panel();
            this.pnl_lateral_opcao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbx_config)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbx_calculadora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbx_deslogar)).BeginInit();
            this.pnl_titulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_lateral_opcao
            // 
            this.pnl_lateral_opcao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_lateral_opcao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnl_lateral_opcao.Controls.Add(this.pctbx_config);
            this.pnl_lateral_opcao.Controls.Add(this.pctbx_calculadora);
            this.pnl_lateral_opcao.Controls.Add(this.pctbx_deslogar);
            this.pnl_lateral_opcao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnl_lateral_opcao.Location = new System.Drawing.Point(1282, 0);
            this.pnl_lateral_opcao.Name = "pnl_lateral_opcao";
            this.pnl_lateral_opcao.Size = new System.Drawing.Size(90, 738);
            this.pnl_lateral_opcao.TabIndex = 4;
            // 
            // pctbx_config
            // 
            this.pctbx_config.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pctbx_config.BackgroundImage = global::gerenciador_antt.Properties.Resources.configurar1;
            this.pctbx_config.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctbx_config.Location = new System.Drawing.Point(13, 640);
            this.pctbx_config.Name = "pctbx_config";
            this.pctbx_config.Size = new System.Drawing.Size(65, 65);
            this.pctbx_config.TabIndex = 5;
            this.pctbx_config.TabStop = false;
            this.pctbx_config.Click += new System.EventHandler(this.pctbx_config_Click);
            // 
            // pctbx_calculadora
            // 
            this.pctbx_calculadora.BackgroundImage = global::gerenciador_antt.Properties.Resources.calculadora;
            this.pctbx_calculadora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctbx_calculadora.Location = new System.Drawing.Point(13, 225);
            this.pctbx_calculadora.Name = "pctbx_calculadora";
            this.pctbx_calculadora.Size = new System.Drawing.Size(65, 65);
            this.pctbx_calculadora.TabIndex = 4;
            this.pctbx_calculadora.TabStop = false;
            this.pctbx_calculadora.Click += new System.EventHandler(this.pctbx_calculadora_Click);
            // 
            // pctbx_deslogar
            // 
            this.pctbx_deslogar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pctbx_deslogar.BackgroundImage")));
            this.pctbx_deslogar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctbx_deslogar.Location = new System.Drawing.Point(13, 129);
            this.pctbx_deslogar.Name = "pctbx_deslogar";
            this.pctbx_deslogar.Size = new System.Drawing.Size(65, 65);
            this.pctbx_deslogar.TabIndex = 3;
            this.pctbx_deslogar.TabStop = false;
            this.pctbx_deslogar.DoubleClick += new System.EventHandler(this.pctbx_deslogar_DoubleClick);
            // 
            // pnl_conteudo
            // 
            this.pnl_conteudo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_conteudo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_conteudo.BackColor = System.Drawing.Color.Transparent;
            this.pnl_conteudo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnl_conteudo.Location = new System.Drawing.Point(-3, 129);
            this.pnl_conteudo.Name = "pnl_conteudo";
            this.pnl_conteudo.Size = new System.Drawing.Size(1164, 590);
            this.pnl_conteudo.TabIndex = 13;
            this.pnl_conteudo.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnl_conteudo_ControlRemoved);
            // 
            // lbl_titulo_tela
            // 
            this.lbl_titulo_tela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_titulo_tela.BackColor = System.Drawing.Color.Transparent;
            this.lbl_titulo_tela.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo_tela.ForeColor = System.Drawing.SystemColors.Info;
            this.lbl_titulo_tela.Location = new System.Drawing.Point(10, 20);
            this.lbl_titulo_tela.Name = "lbl_titulo_tela";
            this.lbl_titulo_tela.Size = new System.Drawing.Size(1277, 66);
            this.lbl_titulo_tela.TabIndex = 0;
            this.lbl_titulo_tela.Text = "ANTT";
            this.lbl_titulo_tela.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lbl_descricao_tela
            // 
            this.lbl_descricao_tela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_descricao_tela.BackColor = System.Drawing.Color.Transparent;
            this.lbl_descricao_tela.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_descricao_tela.ForeColor = System.Drawing.SystemColors.Info;
            this.lbl_descricao_tela.Location = new System.Drawing.Point(3, 88);
            this.lbl_descricao_tela.Name = "lbl_descricao_tela";
            this.lbl_descricao_tela.Size = new System.Drawing.Size(1277, 41);
            this.lbl_descricao_tela.TabIndex = 1;
            this.lbl_descricao_tela.Text = "Bem Vindo ao Sistema";
            this.lbl_descricao_tela.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnl_titulo
            // 
            this.pnl_titulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_titulo.BackColor = System.Drawing.Color.DarkOrange;
            this.pnl_titulo.Controls.Add(this.lbl_descricao_tela);
            this.pnl_titulo.Controls.Add(this.lbl_titulo_tela);
            this.pnl_titulo.Location = new System.Drawing.Point(-3, 0);
            this.pnl_titulo.Name = "pnl_titulo";
            this.pnl_titulo.Size = new System.Drawing.Size(1283, 130);
            this.pnl_titulo.TabIndex = 12;
            // 
            // frm_principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.pnl_lateral_opcao);
            this.Controls.Add(this.pnl_titulo);
            this.Controls.Add(this.pnl_conteudo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1024, 720);
            this.Name = "frm_principal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciador - ANTT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_menu_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_menu_KeyUp);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frm_menu_MouseMove);
            this.pnl_lateral_opcao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctbx_config)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbx_calculadora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbx_deslogar)).EndInit();
            this.pnl_titulo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctbx_deslogar;
        private System.Windows.Forms.Panel pnl_lateral_opcao;
        private System.Windows.Forms.PictureBox pctbx_config;
        private System.Windows.Forms.PictureBox pctbx_calculadora;
        private System.Windows.Forms.Panel pnl_conteudo;
        private System.Windows.Forms.Label lbl_titulo_tela;
        private System.Windows.Forms.Label lbl_descricao_tela;
        private System.Windows.Forms.Panel pnl_titulo;

    }
}