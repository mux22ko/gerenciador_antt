namespace gerenciador_antt.Formularios
{
    partial class Uc_lista_item_atendimento
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
            this.pnl_excluir = new System.Windows.Forms.Panel();
            this.lbl_nome_servico = new System.Windows.Forms.Label();
            this.lbl_valorCombinado_item = new System.Windows.Forms.Label();
            this.lbl_detalhe_item = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_alterar_detalhes = new System.Windows.Forms.TextBox();
            this.cbx_alterar_servico = new System.Windows.Forms.ComboBox();
            this.ctxmxnstp_opcoes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.alterarServicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alterarValorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alterarDetalhesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_alterar_valor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctxmxnstp_opcoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_excluir
            // 
            this.pnl_excluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_excluir.BackColor = System.Drawing.Color.Transparent;
            this.pnl_excluir.BackgroundImage = global::gerenciador_antt.Properties.Resources.fechar_item;
            this.pnl_excluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnl_excluir.Location = new System.Drawing.Point(302, 1);
            this.pnl_excluir.Name = "pnl_excluir";
            this.pnl_excluir.Size = new System.Drawing.Size(15, 15);
            this.pnl_excluir.TabIndex = 0;
            this.pnl_excluir.MouseLeave += new System.EventHandler(this.pnl_excluir_MouseLeave);
            this.pnl_excluir.Click += new System.EventHandler(this.pnl_excluir_Click);
            this.pnl_excluir.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_excluir_MouseDown);
            this.pnl_excluir.MouseHover += new System.EventHandler(this.pnl_excluir_MouseHover);
            // 
            // lbl_nome_servico
            // 
            this.lbl_nome_servico.BackColor = System.Drawing.Color.Transparent;
            this.lbl_nome_servico.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_nome_servico.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_nome_servico.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_nome_servico.Location = new System.Drawing.Point(0, 0);
            this.lbl_nome_servico.Name = "lbl_nome_servico";
            this.lbl_nome_servico.Size = new System.Drawing.Size(320, 21);
            this.lbl_nome_servico.TabIndex = 2;
            this.lbl_nome_servico.Text = "-";
            this.lbl_nome_servico.MouseLeave += new System.EventHandler(this.Uc_lista_item_atendimento_MouseLeave);
            this.lbl_nome_servico.MouseHover += new System.EventHandler(this.Uc_lista_item_atendimento_MouseHover);
            // 
            // lbl_valorCombinado_item
            // 
            this.lbl_valorCombinado_item.BackColor = System.Drawing.Color.Transparent;
            this.lbl_valorCombinado_item.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_valorCombinado_item.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_valorCombinado_item.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_valorCombinado_item.Location = new System.Drawing.Point(25, 21);
            this.lbl_valorCombinado_item.Name = "lbl_valorCombinado_item";
            this.lbl_valorCombinado_item.Size = new System.Drawing.Size(295, 19);
            this.lbl_valorCombinado_item.TabIndex = 3;
            this.lbl_valorCombinado_item.Text = "-";
            this.lbl_valorCombinado_item.MouseLeave += new System.EventHandler(this.Uc_lista_item_atendimento_MouseLeave);
            this.lbl_valorCombinado_item.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbl_valorCombinado_item_MouseDoubleClick);
            this.lbl_valorCombinado_item.MouseHover += new System.EventHandler(this.Uc_lista_item_atendimento_MouseHover);
            // 
            // lbl_detalhe_item
            // 
            this.lbl_detalhe_item.AutoEllipsis = true;
            this.lbl_detalhe_item.AutoSize = true;
            this.lbl_detalhe_item.BackColor = System.Drawing.Color.Transparent;
            this.lbl_detalhe_item.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_detalhe_item.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_detalhe_item.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_detalhe_item.Location = new System.Drawing.Point(25, 40);
            this.lbl_detalhe_item.Name = "lbl_detalhe_item";
            this.lbl_detalhe_item.Size = new System.Drawing.Size(71, 19);
            this.lbl_detalhe_item.TabIndex = 4;
            this.lbl_detalhe_item.Text = "Detalhes...";
            this.lbl_detalhe_item.MouseLeave += new System.EventHandler(this.Uc_lista_item_atendimento_MouseLeave);
            this.lbl_detalhe_item.MouseHover += new System.EventHandler(this.Uc_lista_item_atendimento_MouseHover);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(0, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "R$";
            this.label2.MouseLeave += new System.EventHandler(this.Uc_lista_item_atendimento_MouseLeave);
            this.label2.MouseHover += new System.EventHandler(this.Uc_lista_item_atendimento_MouseHover);
            // 
            // txt_alterar_detalhes
            // 
            this.txt_alterar_detalhes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_alterar_detalhes.BackColor = System.Drawing.Color.Salmon;
            this.txt_alterar_detalhes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_alterar_detalhes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_alterar_detalhes.Location = new System.Drawing.Point(173, 64);
            this.txt_alterar_detalhes.Name = "txt_alterar_detalhes";
            this.txt_alterar_detalhes.Size = new System.Drawing.Size(123, 18);
            this.txt_alterar_detalhes.TabIndex = 6;
            this.txt_alterar_detalhes.Visible = false;
            this.txt_alterar_detalhes.VisibleChanged += new System.EventHandler(this.txt_alterar_detalhes_VisibleChanged);
            this.txt_alterar_detalhes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Uc_lista_item_atendimento_KeyUp);
            // 
            // cbx_alterar_servico
            // 
            this.cbx_alterar_servico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_alterar_servico.BackColor = System.Drawing.Color.Salmon;
            this.cbx_alterar_servico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_alterar_servico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbx_alterar_servico.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbx_alterar_servico.FormattingEnabled = true;
            this.cbx_alterar_servico.Location = new System.Drawing.Point(173, 4);
            this.cbx_alterar_servico.Name = "cbx_alterar_servico";
            this.cbx_alterar_servico.Size = new System.Drawing.Size(123, 23);
            this.cbx_alterar_servico.TabIndex = 7;
            this.cbx_alterar_servico.Visible = false;
            this.cbx_alterar_servico.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Uc_lista_item_atendimento_KeyUp);
            // 
            // ctxmxnstp_opcoes
            // 
            this.ctxmxnstp_opcoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alterarServicoToolStripMenuItem,
            this.alterarValorToolStripMenuItem,
            this.alterarDetalhesToolStripMenuItem});
            this.ctxmxnstp_opcoes.Name = "ctxmxnstp_opcoes";
            this.ctxmxnstp_opcoes.Size = new System.Drawing.Size(153, 70);
            // 
            // alterarServicoToolStripMenuItem
            // 
            this.alterarServicoToolStripMenuItem.Name = "alterarServicoToolStripMenuItem";
            this.alterarServicoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.alterarServicoToolStripMenuItem.Text = "Alterar Serviço";
            this.alterarServicoToolStripMenuItem.Click += new System.EventHandler(this.alterarServicoToolStripMenuItem_Click);
            // 
            // alterarValorToolStripMenuItem
            // 
            this.alterarValorToolStripMenuItem.Name = "alterarValorToolStripMenuItem";
            this.alterarValorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.alterarValorToolStripMenuItem.Text = "Alterar Valor";
            this.alterarValorToolStripMenuItem.Click += new System.EventHandler(this.alterarValorToolStripMenuItem_Click);
            // 
            // alterarDetalhesToolStripMenuItem
            // 
            this.alterarDetalhesToolStripMenuItem.Name = "alterarDetalhesToolStripMenuItem";
            this.alterarDetalhesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.alterarDetalhesToolStripMenuItem.Text = "Alterar Detalhes";
            this.alterarDetalhesToolStripMenuItem.Click += new System.EventHandler(this.alterarDetalhesToolStripMenuItem_Click);
            // 
            // txt_alterar_valor
            // 
            this.txt_alterar_valor.BackColor = System.Drawing.Color.Salmon;
            this.txt_alterar_valor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_alterar_valor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_alterar_valor.Location = new System.Drawing.Point(173, 33);
            this.txt_alterar_valor.Name = "txt_alterar_valor";
            this.txt_alterar_valor.Size = new System.Drawing.Size(121, 18);
            this.txt_alterar_valor.TabIndex = 8;
            this.txt_alterar_valor.Visible = false;
            this.txt_alterar_valor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Uc_lista_item_atendimento_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(96, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 25);
            this.label1.TabIndex = 9;
            this.label1.MouseLeave += new System.EventHandler(this.Uc_lista_item_atendimento_MouseLeave);
            this.label1.MouseHover += new System.EventHandler(this.Uc_lista_item_atendimento_MouseHover);
            // 
            // Uc_lista_item_atendimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ContextMenuStrip = this.ctxmxnstp_opcoes;
            this.Controls.Add(this.txt_alterar_valor);
            this.Controls.Add(this.cbx_alterar_servico);
            this.Controls.Add(this.txt_alterar_detalhes);
            this.Controls.Add(this.pnl_excluir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_detalhe_item);
            this.Controls.Add(this.lbl_valorCombinado_item);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_nome_servico);
            this.Name = "Uc_lista_item_atendimento";
            this.Size = new System.Drawing.Size(320, 85);
            this.Load += new System.EventHandler(this.UC_lista_contato_Load);
            this.MouseLeave += new System.EventHandler(this.Uc_lista_item_atendimento_MouseLeave);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Uc_lista_item_atendimento_KeyUp);
            this.MouseHover += new System.EventHandler(this.Uc_lista_item_atendimento_MouseHover);
            this.ctxmxnstp_opcoes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_excluir;
        private System.Windows.Forms.Label lbl_nome_servico;
        private System.Windows.Forms.Label lbl_valorCombinado_item;
        private System.Windows.Forms.Label lbl_detalhe_item;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_alterar_detalhes;
        private System.Windows.Forms.ComboBox cbx_alterar_servico;
        private System.Windows.Forms.ContextMenuStrip ctxmxnstp_opcoes;
        private System.Windows.Forms.ToolStripMenuItem alterarValorToolStripMenuItem;
        private System.Windows.Forms.TextBox txt_alterar_valor;
        private System.Windows.Forms.ToolStripMenuItem alterarServicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alterarDetalhesToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}
