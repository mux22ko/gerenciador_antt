namespace gerenciador_antt.Formularios
{
    partial class Frm_erro_geral
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
            this.pnl_det = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_erroMensagem = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.txt_det = new System.Windows.Forms.TextBox();
            this.pnl_det.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_det
            // 
            this.pnl_det.BackColor = System.Drawing.Color.Wheat;
            this.pnl_det.Controls.Add(this.label1);
            this.pnl_det.Location = new System.Drawing.Point(12, 92);
            this.pnl_det.MaximumSize = new System.Drawing.Size(360, 200);
            this.pnl_det.MinimumSize = new System.Drawing.Size(360, 200);
            this.pnl_det.Name = "pnl_det";
            this.pnl_det.Size = new System.Drawing.Size(360, 200);
            this.pnl_det.TabIndex = 0;
            this.pnl_det.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pnl_det_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(54, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clique aqui e veja os detalhes técnicos";
            // 
            // lbl_erroMensagem
            // 
            this.lbl_erroMensagem.AutoSize = true;
            this.lbl_erroMensagem.Font = new System.Drawing.Font("Tahoma", 16F);
            this.lbl_erroMensagem.Location = new System.Drawing.Point(12, 6);
            this.lbl_erroMensagem.MaximumSize = new System.Drawing.Size(350, 60);
            this.lbl_erroMensagem.MinimumSize = new System.Drawing.Size(350, 60);
            this.lbl_erroMensagem.Name = "lbl_erroMensagem";
            this.lbl_erroMensagem.Size = new System.Drawing.Size(350, 60);
            this.lbl_erroMensagem.TabIndex = 1;
            this.lbl_erroMensagem.Text = "Erro";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.Location = new System.Drawing.Point(14, 71);
            this.label2.MaximumSize = new System.Drawing.Size(350, 0);
            this.label2.MinimumSize = new System.Drawing.Size(350, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(350, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Detalhes:";
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_ok.Location = new System.Drawing.Point(92, 298);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(199, 52);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "&OK";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // txt_det
            // 
            this.txt_det.Location = new System.Drawing.Point(17, 97);
            this.txt_det.Multiline = true;
            this.txt_det.Name = "txt_det";
            this.txt_det.Size = new System.Drawing.Size(351, 189);
            this.txt_det.TabIndex = 0;
            // 
            // Frm_erro_geral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(384, 362);
            this.Controls.Add(this.pnl_det);
            this.Controls.Add(this.txt_det);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_erroMensagem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Frm_erro_geral";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atenção";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Frm_erro_geral_Load);
            this.pnl_det.ResumeLayout(false);
            this.pnl_det.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_det;
        private System.Windows.Forms.Label lbl_erroMensagem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_det;
    }
}