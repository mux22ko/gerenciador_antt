namespace gerenciador_antt.Formularios
{
    partial class Uc_cliente
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
            System.Windows.Forms.PictureBox pctbx_pesquisar_cliente;
            System.Windows.Forms.PictureBox pctbx_cadastrar_cliente;
            System.Windows.Forms.PictureBox pctbx_cliente;
            this.pnl_cliente_botao = new System.Windows.Forms.Panel();
            this.pnl_cadastrar_cliente_botao = new System.Windows.Forms.Panel();
            this.lbl_cadastrar_cliente_botao = new System.Windows.Forms.Label();
            this.pnl_pesquisar_cliente_botao = new System.Windows.Forms.Panel();
            this.lbl_pesquisar_cliente = new System.Windows.Forms.Label();
            this.pnl_conteudo = new System.Windows.Forms.Panel();
            this.pnl_bordaLateral = new System.Windows.Forms.Panel();
            pctbx_pesquisar_cliente = new System.Windows.Forms.PictureBox();
            pctbx_cadastrar_cliente = new System.Windows.Forms.PictureBox();
            pctbx_cliente = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pctbx_pesquisar_cliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pctbx_cadastrar_cliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pctbx_cliente)).BeginInit();
            this.pnl_cliente_botao.SuspendLayout();
            this.pnl_cadastrar_cliente_botao.SuspendLayout();
            this.pnl_pesquisar_cliente_botao.SuspendLayout();
            this.pnl_bordaLateral.SuspendLayout();
            this.SuspendLayout();
            // 
            // pctbx_pesquisar_cliente
            // 
            pctbx_pesquisar_cliente.Enabled = false;
            pctbx_pesquisar_cliente.Image = global::gerenciador_antt.Properties.Resources.procurar_doc;
            pctbx_pesquisar_cliente.Location = new System.Drawing.Point(23, 22);
            pctbx_pesquisar_cliente.Name = "pctbx_pesquisar_cliente";
            pctbx_pesquisar_cliente.Size = new System.Drawing.Size(76, 76);
            pctbx_pesquisar_cliente.TabIndex = 3;
            pctbx_pesquisar_cliente.TabStop = false;
            pctbx_pesquisar_cliente.Click += new System.EventHandler(this.pnl_pesquisar_cliente_botao_Click);
            // 
            // pctbx_cadastrar_cliente
            // 
            pctbx_cadastrar_cliente.Enabled = false;
            pctbx_cadastrar_cliente.Image = global::gerenciador_antt.Properties.Resources.mais;
            pctbx_cadastrar_cliente.Location = new System.Drawing.Point(21, 21);
            pctbx_cadastrar_cliente.Name = "pctbx_cadastrar_cliente";
            pctbx_cadastrar_cliente.Size = new System.Drawing.Size(76, 76);
            pctbx_cadastrar_cliente.TabIndex = 3;
            pctbx_cadastrar_cliente.TabStop = false;
            pctbx_cadastrar_cliente.Click += new System.EventHandler(this.pnl_cadastrar_cliente_botao_Click);
            // 
            // pctbx_cliente
            // 
            pctbx_cliente.Enabled = false;
            pctbx_cliente.Image = global::gerenciador_antt.Properties.Resources.user;
            pctbx_cliente.Location = new System.Drawing.Point(20, 21);
            pctbx_cliente.Name = "pctbx_cliente";
            pctbx_cliente.Size = new System.Drawing.Size(76, 76);
            pctbx_cliente.TabIndex = 3;
            pctbx_cliente.TabStop = false;
            // 
            // pnl_cliente_botao
            // 
            this.pnl_cliente_botao.BackColor = System.Drawing.Color.Transparent;
            this.pnl_cliente_botao.Controls.Add(pctbx_cliente);
            this.pnl_cliente_botao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnl_cliente_botao.Location = new System.Drawing.Point(8, 24);
            this.pnl_cliente_botao.Name = "pnl_cliente_botao";
            this.pnl_cliente_botao.Size = new System.Drawing.Size(120, 120);
            this.pnl_cliente_botao.TabIndex = 8;
            this.pnl_cliente_botao.MouseLeave += new System.EventHandler(this.pnl_cliente_botao_MouseLeave);
            this.pnl_cliente_botao.Click += new System.EventHandler(this.pnl_cliente_botao_Click);
            this.pnl_cliente_botao.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_cliente_botao_MouseDown);
            this.pnl_cliente_botao.MouseHover += new System.EventHandler(this.pnl_cliente_botao_MouseHover);
            this.pnl_cliente_botao.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnl_cliente_botao_MouseUp);
            this.pnl_cliente_botao.MouseEnter += new System.EventHandler(this.pnl_cliente_botao_MouseEnter);
            // 
            // pnl_cadastrar_cliente_botao
            // 
            this.pnl_cadastrar_cliente_botao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.pnl_cadastrar_cliente_botao.Controls.Add(pctbx_cadastrar_cliente);
            this.pnl_cadastrar_cliente_botao.Controls.Add(this.lbl_cadastrar_cliente_botao);
            this.pnl_cadastrar_cliente_botao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnl_cadastrar_cliente_botao.Location = new System.Drawing.Point(8, 150);
            this.pnl_cadastrar_cliente_botao.Name = "pnl_cadastrar_cliente_botao";
            this.pnl_cadastrar_cliente_botao.Size = new System.Drawing.Size(120, 120);
            this.pnl_cadastrar_cliente_botao.TabIndex = 9;
            this.pnl_cadastrar_cliente_botao.MouseLeave += new System.EventHandler(this.pnl_cadastrar_cliente_botao_MouseLeave);
            this.pnl_cadastrar_cliente_botao.Click += new System.EventHandler(this.pnl_cadastrar_cliente_botao_Click);
            this.pnl_cadastrar_cliente_botao.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_cadastrar_cliente_botao_MouseDown);
            this.pnl_cadastrar_cliente_botao.MouseHover += new System.EventHandler(this.pnl_cadastrar_cliente_botao_MouseHover);
            this.pnl_cadastrar_cliente_botao.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnl_cadastrar_cliente_botao_MouseUp);
            this.pnl_cadastrar_cliente_botao.MouseEnter += new System.EventHandler(this.pnl_cadastrar_cliente_botao_MouseHover);
            // 
            // lbl_cadastrar_cliente_botao
            // 
            this.lbl_cadastrar_cliente_botao.AutoSize = true;
            this.lbl_cadastrar_cliente_botao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_cadastrar_cliente_botao.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_cadastrar_cliente_botao.Location = new System.Drawing.Point(2, 99);
            this.lbl_cadastrar_cliente_botao.Name = "lbl_cadastrar_cliente_botao";
            this.lbl_cadastrar_cliente_botao.Size = new System.Drawing.Size(68, 19);
            this.lbl_cadastrar_cliente_botao.TabIndex = 4;
            this.lbl_cadastrar_cliente_botao.Text = "Cadastrar";
            this.lbl_cadastrar_cliente_botao.Click += new System.EventHandler(this.pnl_cadastrar_cliente_botao_Click);
            // 
            // pnl_pesquisar_cliente_botao
            // 
            this.pnl_pesquisar_cliente_botao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.pnl_pesquisar_cliente_botao.Controls.Add(pctbx_pesquisar_cliente);
            this.pnl_pesquisar_cliente_botao.Controls.Add(this.lbl_pesquisar_cliente);
            this.pnl_pesquisar_cliente_botao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnl_pesquisar_cliente_botao.Location = new System.Drawing.Point(8, 276);
            this.pnl_pesquisar_cliente_botao.Name = "pnl_pesquisar_cliente_botao";
            this.pnl_pesquisar_cliente_botao.Size = new System.Drawing.Size(120, 120);
            this.pnl_pesquisar_cliente_botao.TabIndex = 9;
            this.pnl_pesquisar_cliente_botao.MouseLeave += new System.EventHandler(this.pnl_pesquisar_cliente_botao_MouseLeave);
            this.pnl_pesquisar_cliente_botao.Click += new System.EventHandler(this.pnl_pesquisar_cliente_botao_Click);
            this.pnl_pesquisar_cliente_botao.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_pesquisar_cliente_botao_MouseDown);
            this.pnl_pesquisar_cliente_botao.MouseHover += new System.EventHandler(this.pnl_pesquisar_cliente_botao_MouseHover);
            this.pnl_pesquisar_cliente_botao.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnl_pesquisar_cliente_botao_MouseUp);
            this.pnl_pesquisar_cliente_botao.MouseEnter += new System.EventHandler(this.pnl_pesquisar_cliente_botao_MouseHover);
            // 
            // lbl_pesquisar_cliente
            // 
            this.lbl_pesquisar_cliente.AutoSize = true;
            this.lbl_pesquisar_cliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_pesquisar_cliente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_pesquisar_cliente.Location = new System.Drawing.Point(2, 99);
            this.lbl_pesquisar_cliente.Name = "lbl_pesquisar_cliente";
            this.lbl_pesquisar_cliente.Size = new System.Drawing.Size(67, 19);
            this.lbl_pesquisar_cliente.TabIndex = 4;
            this.lbl_pesquisar_cliente.Text = "Pesquisar";
            this.lbl_pesquisar_cliente.Click += new System.EventHandler(this.pnl_pesquisar_cliente_botao_Click);
            // 
            // pnl_conteudo
            // 
            this.pnl_conteudo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_conteudo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_conteudo.BackColor = System.Drawing.Color.Transparent;
            this.pnl_conteudo.Location = new System.Drawing.Point(136, 0);
            this.pnl_conteudo.Name = "pnl_conteudo";
            this.pnl_conteudo.Size = new System.Drawing.Size(2185, 794);
            this.pnl_conteudo.TabIndex = 21;
            this.pnl_conteudo.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnl_conteudo_ControlRemoved);
            // 
            // pnl_bordaLateral
            // 
            this.pnl_bordaLateral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.pnl_bordaLateral.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_bordaLateral.BackColor = System.Drawing.Color.DarkOrange;
            this.pnl_bordaLateral.Controls.Add(this.pnl_cadastrar_cliente_botao);
            this.pnl_bordaLateral.Controls.Add(this.pnl_pesquisar_cliente_botao);
            this.pnl_bordaLateral.Controls.Add(this.pnl_cliente_botao);
            this.pnl_bordaLateral.Location = new System.Drawing.Point(0, 0);
            this.pnl_bordaLateral.Name = "pnl_bordaLateral";
            this.pnl_bordaLateral.Size = new System.Drawing.Size(139, 794);
            this.pnl_bordaLateral.TabIndex = 22;
            // 
            // Uc_cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnl_conteudo);
            this.Controls.Add(this.pnl_bordaLateral);
            this.Name = "Uc_cliente";
            this.Size = new System.Drawing.Size(2332, 797);
            this.Load += new System.EventHandler(this.Uc_cliente_Load);
            ((System.ComponentModel.ISupportInitialize)(pctbx_pesquisar_cliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pctbx_cadastrar_cliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pctbx_cliente)).EndInit();
            this.pnl_cliente_botao.ResumeLayout(false);
            this.pnl_cadastrar_cliente_botao.ResumeLayout(false);
            this.pnl_cadastrar_cliente_botao.PerformLayout();
            this.pnl_pesquisar_cliente_botao.ResumeLayout(false);
            this.pnl_pesquisar_cliente_botao.PerformLayout();
            this.pnl_bordaLateral.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_cliente_botao;
        private System.Windows.Forms.Panel pnl_cadastrar_cliente_botao;
        private System.Windows.Forms.Label lbl_cadastrar_cliente_botao;
        private System.Windows.Forms.Panel pnl_pesquisar_cliente_botao;
        private System.Windows.Forms.Label lbl_pesquisar_cliente;
        private System.Windows.Forms.Panel pnl_conteudo;
        private System.Windows.Forms.Panel pnl_bordaLateral;
    }
}
