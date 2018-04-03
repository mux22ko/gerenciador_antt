namespace gerenciador_antt.Formularios
{
    partial class Uc_lista_endereco
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
            this.lbl_endereco = new System.Windows.Forms.Label();
            this.lbl_tipo_endereco = new System.Windows.Forms.Label();
            this.tltp_dica = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_excluir = new System.Windows.Forms.Panel();
            this.cbx_alterar_tipo_endereco = new System.Windows.Forms.ComboBox();
            this.ctxmnstp_opcoes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.alterarOTipoDoEndereçoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alterarOEndereçoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_alterar_endereco = new System.Windows.Forms.TextBox();
            this.ctxmnstp_opcoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_endereco
            // 
            this.lbl_endereco.AutoEllipsis = true;
            this.lbl_endereco.AutoSize = true;
            this.lbl_endereco.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_endereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbl_endereco.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_endereco.Location = new System.Drawing.Point(0, 23);
            this.lbl_endereco.MaximumSize = new System.Drawing.Size(265, 900);
            this.lbl_endereco.Name = "lbl_endereco";
            this.lbl_endereco.Size = new System.Drawing.Size(11, 15);
            this.lbl_endereco.TabIndex = 1;
            this.lbl_endereco.Text = "-";
            this.tltp_dica.SetToolTip(this.lbl_endereco, "Clique Botão direito para copiar o conteúdo na Área de transferencia!");
            this.lbl_endereco.MouseLeave += new System.EventHandler(this.Uc_lista_endereco_MouseLeave);
            this.lbl_endereco.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbl_endereco_MouseDoubleClick);
            this.lbl_endereco.MouseHover += new System.EventHandler(this.Uc_lista_endereco_MouseHover);
            // 
            // lbl_tipo_endereco
            // 
            this.lbl_tipo_endereco.BackColor = System.Drawing.Color.Transparent;
            this.lbl_tipo_endereco.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_tipo_endereco.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_tipo_endereco.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_tipo_endereco.Location = new System.Drawing.Point(0, 0);
            this.lbl_tipo_endereco.Name = "lbl_tipo_endereco";
            this.lbl_tipo_endereco.Size = new System.Drawing.Size(320, 23);
            this.lbl_tipo_endereco.TabIndex = 2;
            this.lbl_tipo_endereco.Text = "-";
            this.tltp_dica.SetToolTip(this.lbl_tipo_endereco, "Clique Botão direito para copiar o conteúdo na Área de transferencia!");
            this.lbl_tipo_endereco.MouseLeave += new System.EventHandler(this.Uc_lista_endereco_MouseLeave);
            this.lbl_tipo_endereco.MouseHover += new System.EventHandler(this.Uc_lista_endereco_MouseHover);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(0, 38);
            this.label1.MaximumSize = new System.Drawing.Size(309, 11);
            this.label1.MinimumSize = new System.Drawing.Size(309, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 11);
            this.label1.TabIndex = 18;
            this.tltp_dica.SetToolTip(this.label1, "Clique Botão direito para copiar o conteúdo na Área de transferencia!");
            this.label1.MouseLeave += new System.EventHandler(this.Uc_lista_endereco_MouseLeave);
            this.label1.MouseHover += new System.EventHandler(this.Uc_lista_endereco_MouseHover);
            // 
            // pnl_excluir
            // 
            this.pnl_excluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_excluir.BackColor = System.Drawing.Color.Transparent;
            this.pnl_excluir.BackgroundImage = global::gerenciador_antt.Properties.Resources.fechar_item;
            this.pnl_excluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnl_excluir.Location = new System.Drawing.Point(302, 2);
            this.pnl_excluir.Name = "pnl_excluir";
            this.pnl_excluir.Size = new System.Drawing.Size(15, 15);
            this.pnl_excluir.TabIndex = 0;
            this.tltp_dica.SetToolTip(this.pnl_excluir, "Clique no X para remover este item!");
            this.pnl_excluir.MouseLeave += new System.EventHandler(this.pnl_excluir_MouseLeave);
            this.pnl_excluir.Click += new System.EventHandler(this.pnl_excluir_Click);
            this.pnl_excluir.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_excluir_MouseDown);
            this.pnl_excluir.MouseHover += new System.EventHandler(this.pnl_excluir_MouseHover);
            // 
            // cbx_alterar_tipo_endereco
            // 
            this.cbx_alterar_tipo_endereco.BackColor = System.Drawing.Color.Salmon;
            this.cbx_alterar_tipo_endereco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_alterar_tipo_endereco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbx_alterar_tipo_endereco.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbx_alterar_tipo_endereco.FormattingEnabled = true;
            this.cbx_alterar_tipo_endereco.Location = new System.Drawing.Point(172, 1);
            this.cbx_alterar_tipo_endereco.Name = "cbx_alterar_tipo_endereco";
            this.cbx_alterar_tipo_endereco.Size = new System.Drawing.Size(121, 23);
            this.cbx_alterar_tipo_endereco.TabIndex = 14;
            this.cbx_alterar_tipo_endereco.Visible = false;
            this.cbx_alterar_tipo_endereco.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Uc_lista_endereco_KeyUp);
            // 
            // ctxmnstp_opcoes
            // 
            this.ctxmnstp_opcoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alterarOTipoDoEndereçoToolStripMenuItem,
            this.alterarOEndereçoToolStripMenuItem});
            this.ctxmnstp_opcoes.Name = "ctxmnstp_opcoes";
            this.ctxmnstp_opcoes.Size = new System.Drawing.Size(203, 48);
            // 
            // alterarOTipoDoEndereçoToolStripMenuItem
            // 
            this.alterarOTipoDoEndereçoToolStripMenuItem.Name = "alterarOTipoDoEndereçoToolStripMenuItem";
            this.alterarOTipoDoEndereçoToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.alterarOTipoDoEndereçoToolStripMenuItem.Text = "Alterar o Tipo do Endereço";
            this.alterarOTipoDoEndereçoToolStripMenuItem.Click += new System.EventHandler(this.alterarOTipoDoEndereçoToolStripMenuItem_Click);
            // 
            // alterarOEndereçoToolStripMenuItem
            // 
            this.alterarOEndereçoToolStripMenuItem.Name = "alterarOEndereçoToolStripMenuItem";
            this.alterarOEndereçoToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.alterarOEndereçoToolStripMenuItem.Text = "Alterar o Endereço";
            this.alterarOEndereçoToolStripMenuItem.Click += new System.EventHandler(this.alterarOEndereçoToolStripMenuItem_Click);
            // 
            // txt_alterar_endereco
            // 
            this.txt_alterar_endereco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_alterar_endereco.BackColor = System.Drawing.Color.Salmon;
            this.txt_alterar_endereco.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_alterar_endereco.Location = new System.Drawing.Point(92, 26);
            this.txt_alterar_endereco.Multiline = true;
            this.txt_alterar_endereco.Name = "txt_alterar_endereco";
            this.txt_alterar_endereco.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_alterar_endereco.Size = new System.Drawing.Size(202, 20);
            this.txt_alterar_endereco.TabIndex = 17;
            this.txt_alterar_endereco.Visible = false;
            this.txt_alterar_endereco.VisibleChanged += new System.EventHandler(this.txt_alterar_endereco_VisibleChanged);
            this.txt_alterar_endereco.TextChanged += new System.EventHandler(this.txt_alterar_endereco_TextChanged);
            this.txt_alterar_endereco.MouseLeave += new System.EventHandler(this.txt_alterar_endereco_MouseLeave);
            this.txt_alterar_endereco.Leave += new System.EventHandler(this.txt_alterar_endereco_Leave);
            this.txt_alterar_endereco.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Uc_lista_endereco_KeyUp);
            // 
            // Uc_lista_endereco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ContextMenuStrip = this.ctxmnstp_opcoes;
            this.Controls.Add(this.txt_alterar_endereco);
            this.Controls.Add(this.cbx_alterar_tipo_endereco);
            this.Controls.Add(this.lbl_endereco);
            this.Controls.Add(this.pnl_excluir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_tipo_endereco);
            this.Name = "Uc_lista_endereco";
            this.Size = new System.Drawing.Size(320, 49);
            this.tltp_dica.SetToolTip(this, "Clique duas vezes com o mouse para copiar o endereço na Área de transferencia!");
            this.Load += new System.EventHandler(this.Uc_lista_endereco_Load);
            this.MouseLeave += new System.EventHandler(this.Uc_lista_endereco_MouseLeave);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Uc_lista_endereco_KeyUp);
            this.MouseHover += new System.EventHandler(this.Uc_lista_endereco_MouseHover);
            this.ctxmnstp_opcoes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_excluir;
        private System.Windows.Forms.Label lbl_endereco;
        private System.Windows.Forms.Label lbl_tipo_endereco;
        private System.Windows.Forms.ToolTip tltp_dica;
        private System.Windows.Forms.ComboBox cbx_alterar_tipo_endereco;
        private System.Windows.Forms.ContextMenuStrip ctxmnstp_opcoes;
        private System.Windows.Forms.ToolStripMenuItem alterarOTipoDoEndereçoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alterarOEndereçoToolStripMenuItem;
        private System.Windows.Forms.TextBox txt_alterar_endereco;
        private System.Windows.Forms.Label label1;
    }
}
