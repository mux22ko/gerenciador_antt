namespace gerenciador_antt.Formularios
{
    partial class Uc_tela_carregando
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
            this.pnl_total = new System.Windows.Forms.Panel();
            this.lbl_carregando_dado = new System.Windows.Forms.Label();
            this.pctbx_carregando = new System.Windows.Forms.PictureBox();
            this.pnl_total.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbx_carregando)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_total
            // 
            this.pnl_total.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_total.BackColor = System.Drawing.Color.White;
            this.pnl_total.Controls.Add(this.lbl_carregando_dado);
            this.pnl_total.Controls.Add(this.pctbx_carregando);
            this.pnl_total.Location = new System.Drawing.Point(0, 0);
            this.pnl_total.Name = "pnl_total";
            this.pnl_total.Size = new System.Drawing.Size(800, 600);
            this.pnl_total.TabIndex = 1;
            // 
            // lbl_carregando_dado
            // 
            this.lbl_carregando_dado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_carregando_dado.BackColor = System.Drawing.Color.DarkOrange;
            this.lbl_carregando_dado.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.lbl_carregando_dado.Location = new System.Drawing.Point(0, 298);
            this.lbl_carregando_dado.Name = "lbl_carregando_dado";
            this.lbl_carregando_dado.Size = new System.Drawing.Size(800, 57);
            this.lbl_carregando_dado.TabIndex = 1;
            this.lbl_carregando_dado.Text = "...";
            this.lbl_carregando_dado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_carregando_dado.UseWaitCursor = true;
            // 
            // pctbx_carregando
            // 
            this.pctbx_carregando.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctbx_carregando.BackColor = System.Drawing.Color.White;
            this.pctbx_carregando.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pctbx_carregando.Image = global::gerenciador_antt.Properties.Resources.loading;
            this.pctbx_carregando.ImageLocation = "";
            this.pctbx_carregando.Location = new System.Drawing.Point(344, 182);
            this.pctbx_carregando.Name = "pctbx_carregando";
            this.pctbx_carregando.Size = new System.Drawing.Size(112, 113);
            this.pctbx_carregando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctbx_carregando.TabIndex = 0;
            this.pctbx_carregando.TabStop = false;
            this.pctbx_carregando.UseWaitCursor = true;
            this.pctbx_carregando.Paint += new System.Windows.Forms.PaintEventHandler(this.pctbx_carregando_Paint);
            // 
            // Uc_tela_carregando
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnl_total);
            this.Name = "Uc_tela_carregando";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.Uc_tela_carregando_Load);
            this.pnl_total.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctbx_carregando)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_total;
        private System.Windows.Forms.Label lbl_carregando_dado;
        private System.Windows.Forms.PictureBox pctbx_carregando;
    }
}
