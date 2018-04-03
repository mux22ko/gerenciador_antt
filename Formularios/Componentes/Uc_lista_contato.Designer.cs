namespace gerenciador_antt.Formularios
{
    partial class Uc_lista_contato
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
            this.lbl_tipo_contato = new System.Windows.Forms.Label();
            this.lbl_contato = new System.Windows.Forms.Label();
            this.cbx_alterar_tipo_contato = new System.Windows.Forms.ComboBox();
            this.ctxmnstp_opcoes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.alterarTipoDoContatoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alterarOContatoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msktxt_alterar_contato = new System.Windows.Forms.MaskedTextBox();
            this.tltp_dicas = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_excluir = new System.Windows.Forms.Panel();
            this.ctxmnstp_opcoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_tipo_contato
            // 
            this.lbl_tipo_contato.BackColor = System.Drawing.Color.Transparent;
            this.lbl_tipo_contato.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_tipo_contato.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_tipo_contato.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_tipo_contato.Location = new System.Drawing.Point(0, 0);
            this.lbl_tipo_contato.Name = "lbl_tipo_contato";
            this.lbl_tipo_contato.Size = new System.Drawing.Size(320, 19);
            this.lbl_tipo_contato.TabIndex = 2;
            this.lbl_tipo_contato.Text = "-";
            this.lbl_tipo_contato.MouseLeave += new System.EventHandler(this.Uc_lista_contato_MouseLeave);
            this.lbl_tipo_contato.MouseHover += new System.EventHandler(this.Uc_lista_contato_MouseHover);
            // 
            // lbl_contato
            // 
            this.lbl_contato.AutoEllipsis = true;
            this.lbl_contato.AutoSize = true;
            this.lbl_contato.BackColor = System.Drawing.Color.Transparent;
            this.lbl_contato.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_contato.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_contato.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_contato.Location = new System.Drawing.Point(0, 19);
            this.lbl_contato.MaximumSize = new System.Drawing.Size(265, 900);
            this.lbl_contato.Name = "lbl_contato";
            this.lbl_contato.Size = new System.Drawing.Size(15, 19);
            this.lbl_contato.TabIndex = 2;
            this.lbl_contato.Text = "-";
            this.tltp_dicas.SetToolTip(this.lbl_contato, "Clique duas vezes com o mouse para copiar o contato na Área de transferencia!");
            this.lbl_contato.MouseLeave += new System.EventHandler(this.Uc_lista_contato_MouseLeave);
            this.lbl_contato.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbl_contato_MouseDoubleClick);
            this.lbl_contato.MouseHover += new System.EventHandler(this.Uc_lista_contato_MouseHover);
            // 
            // cbx_alterar_tipo_contato
            // 
            this.cbx_alterar_tipo_contato.BackColor = System.Drawing.Color.Salmon;
            this.cbx_alterar_tipo_contato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_alterar_tipo_contato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbx_alterar_tipo_contato.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbx_alterar_tipo_contato.FormattingEnabled = true;
            this.cbx_alterar_tipo_contato.Location = new System.Drawing.Point(174, 3);
            this.cbx_alterar_tipo_contato.Name = "cbx_alterar_tipo_contato";
            this.cbx_alterar_tipo_contato.Size = new System.Drawing.Size(121, 23);
            this.cbx_alterar_tipo_contato.TabIndex = 10;
            this.cbx_alterar_tipo_contato.Visible = false;
            this.cbx_alterar_tipo_contato.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Uc_lista_contato_KeyUp);
            // 
            // ctxmnstp_opcoes
            // 
            this.ctxmnstp_opcoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alterarTipoDoContatoToolStripMenuItem,
            this.alterarOContatoToolStripMenuItem});
            this.ctxmnstp_opcoes.Name = "ctxmnstp_opcoes";
            this.ctxmnstp_opcoes.Size = new System.Drawing.Size(200, 48);
            // 
            // alterarTipoDoContatoToolStripMenuItem
            // 
            this.alterarTipoDoContatoToolStripMenuItem.Name = "alterarTipoDoContatoToolStripMenuItem";
            this.alterarTipoDoContatoToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.alterarTipoDoContatoToolStripMenuItem.Text = "Alterar Tipo do Contato";
            this.alterarTipoDoContatoToolStripMenuItem.Click += new System.EventHandler(this.alterarTipoDoContatoToolStripMenuItem_Click);
            // 
            // alterarOContatoToolStripMenuItem
            // 
            this.alterarOContatoToolStripMenuItem.Name = "alterarOContatoToolStripMenuItem";
            this.alterarOContatoToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.alterarOContatoToolStripMenuItem.Text = "Alterar o Contato";
            this.alterarOContatoToolStripMenuItem.Click += new System.EventHandler(this.alterarOContatoToolStripMenuItem_Click);
            // 
            // msktxt_alterar_contato
            // 
            this.msktxt_alterar_contato.BackColor = System.Drawing.Color.Salmon;
            this.msktxt_alterar_contato.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.msktxt_alterar_contato.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.msktxt_alterar_contato.Location = new System.Drawing.Point(174, 32);
            this.msktxt_alterar_contato.Name = "msktxt_alterar_contato";
            this.msktxt_alterar_contato.Size = new System.Drawing.Size(121, 18);
            this.msktxt_alterar_contato.TabIndex = 13;
            this.msktxt_alterar_contato.Visible = false;
            this.msktxt_alterar_contato.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Uc_lista_contato_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(0, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 11);
            this.label1.TabIndex = 14;
            this.label1.MouseLeave += new System.EventHandler(this.Uc_lista_contato_MouseLeave);
            this.label1.MouseHover += new System.EventHandler(this.Uc_lista_contato_MouseHover);
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
            this.pnl_excluir.MouseLeave += new System.EventHandler(this.pnl_excluir_MouseLeave);
            this.pnl_excluir.Click += new System.EventHandler(this.pnl_excluir_Click);
            this.pnl_excluir.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_excluir_MouseDown);
            this.pnl_excluir.MouseHover += new System.EventHandler(this.pnl_excluir_MouseHover);
            // 
            // Uc_lista_contato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ContextMenuStrip = this.ctxmnstp_opcoes;
            this.Controls.Add(this.msktxt_alterar_contato);
            this.Controls.Add(this.cbx_alterar_tipo_contato);
            this.Controls.Add(this.pnl_excluir);
            this.Controls.Add(this.lbl_contato);
            this.Controls.Add(this.lbl_tipo_contato);
            this.Controls.Add(this.label1);
            this.Name = "Uc_lista_contato";
            this.Size = new System.Drawing.Size(320, 53);
            this.Load += new System.EventHandler(this.UC_lista_contato_Load);
            this.MouseLeave += new System.EventHandler(this.Uc_lista_contato_MouseLeave);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Uc_lista_contato_KeyUp);
            this.MouseHover += new System.EventHandler(this.Uc_lista_contato_MouseHover);
            this.ctxmnstp_opcoes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_excluir;
        private System.Windows.Forms.Label lbl_tipo_contato;
        private System.Windows.Forms.Label lbl_contato;
        private System.Windows.Forms.ComboBox cbx_alterar_tipo_contato;
        private System.Windows.Forms.ContextMenuStrip ctxmnstp_opcoes;
        private System.Windows.Forms.ToolStripMenuItem alterarTipoDoContatoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alterarOContatoToolStripMenuItem;
        private System.Windows.Forms.MaskedTextBox msktxt_alterar_contato;
        private System.Windows.Forms.ToolTip tltp_dicas;
        private System.Windows.Forms.Label label1;
    }
}
