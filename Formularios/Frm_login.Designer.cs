namespace gerenciador_antt
{
    partial class frm_login
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
            this.btn_entrar = new System.Windows.Forms.Button();
            this.lbl_login = new System.Windows.Forms.Label();
            this.pnl_login = new System.Windows.Forms.Panel();
            this.lbl_senha = new System.Windows.Forms.Label();
            this.txt_senha = new System.Windows.Forms.TextBox();
            this.txt_login = new System.Windows.Forms.TextBox();
            this.bgwk_acessar = new System.ComponentModel.BackgroundWorker();
            this.pgbar_acessando = new System.Windows.Forms.ProgressBar();
            this.pnl_barra = new System.Windows.Forms.Panel();
            this.lbl_liberando_acesso = new System.Windows.Forms.Label();
            this.pnl_login.SuspendLayout();
            this.pnl_barra.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_entrar
            // 
            this.btn_entrar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_entrar.FlatAppearance.BorderSize = 0;
            this.btn_entrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_entrar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_entrar.Location = new System.Drawing.Point(5, 129);
            this.btn_entrar.Name = "btn_entrar";
            this.btn_entrar.Size = new System.Drawing.Size(379, 57);
            this.btn_entrar.TabIndex = 3;
            this.btn_entrar.Text = "ENTRAR";
            this.btn_entrar.UseVisualStyleBackColor = false;
            this.btn_entrar.Click += new System.EventHandler(this.btn_entrar_Click);
            // 
            // lbl_login
            // 
            this.lbl_login.AutoSize = true;
            this.lbl_login.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_login.Location = new System.Drawing.Point(3, 2);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(52, 21);
            this.lbl_login.TabIndex = 1;
            this.lbl_login.Text = "Login:";
            // 
            // pnl_login
            // 
            this.pnl_login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_login.Controls.Add(this.lbl_senha);
            this.pnl_login.Controls.Add(this.txt_senha);
            this.pnl_login.Controls.Add(this.txt_login);
            this.pnl_login.Controls.Add(this.lbl_login);
            this.pnl_login.Location = new System.Drawing.Point(5, 4);
            this.pnl_login.Name = "pnl_login";
            this.pnl_login.Size = new System.Drawing.Size(379, 121);
            this.pnl_login.TabIndex = 2;
            // 
            // lbl_senha
            // 
            this.lbl_senha.AutoSize = true;
            this.lbl_senha.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbl_senha.Location = new System.Drawing.Point(3, 54);
            this.lbl_senha.Name = "lbl_senha";
            this.lbl_senha.Size = new System.Drawing.Size(56, 21);
            this.lbl_senha.TabIndex = 6;
            this.lbl_senha.Text = "Senha:";
            // 
            // txt_senha
            // 
            this.txt_senha.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_senha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_senha.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_senha.Location = new System.Drawing.Point(14, 77);
            this.txt_senha.Name = "txt_senha";
            this.txt_senha.Size = new System.Drawing.Size(348, 26);
            this.txt_senha.TabIndex = 2;
            this.txt_senha.Text = "12345";
            this.txt_senha.UseSystemPasswordChar = true;
            // 
            // txt_login
            // 
            this.txt_login.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_login.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_login.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_login.Location = new System.Drawing.Point(14, 26);
            this.txt_login.Name = "txt_login";
            this.txt_login.Size = new System.Drawing.Size(348, 26);
            this.txt_login.TabIndex = 1;
            this.txt_login.Text = "matheus";
            // 
            // bgwk_acessar
            // 
            this.bgwk_acessar.WorkerReportsProgress = true;
            this.bgwk_acessar.WorkerSupportsCancellation = true;
            this.bgwk_acessar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwk_acessar_DoWork);
            this.bgwk_acessar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwk_acessar_RunWorkerCompleted);
            this.bgwk_acessar.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwk_acessar_ProgressChanged);
            // 
            // pgbar_acessando
            // 
            this.pgbar_acessando.Location = new System.Drawing.Point(110, 9);
            this.pgbar_acessando.Name = "pgbar_acessando";
            this.pgbar_acessando.Size = new System.Drawing.Size(163, 28);
            this.pgbar_acessando.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgbar_acessando.TabIndex = 3;
            // 
            // pnl_barra
            // 
            this.pnl_barra.Controls.Add(this.lbl_liberando_acesso);
            this.pnl_barra.Controls.Add(this.pgbar_acessando);
            this.pnl_barra.Location = new System.Drawing.Point(5, 126);
            this.pnl_barra.Name = "pnl_barra";
            this.pnl_barra.Size = new System.Drawing.Size(379, 63);
            this.pnl_barra.TabIndex = 4;
            // 
            // lbl_liberando_acesso
            // 
            this.lbl_liberando_acesso.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_liberando_acesso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_liberando_acesso.Location = new System.Drawing.Point(0, 39);
            this.lbl_liberando_acesso.Name = "lbl_liberando_acesso";
            this.lbl_liberando_acesso.Size = new System.Drawing.Size(379, 19);
            this.lbl_liberando_acesso.TabIndex = 7;
            this.lbl_liberando_acesso.Text = "Liberando acesso, Aguarde...";
            this.lbl_liberando_acesso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(389, 193);
            this.Controls.Add(this.btn_entrar);
            this.Controls.Add(this.pnl_barra);
            this.Controls.Add(this.pnl_login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_login";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ENTRAR NO SISTEMA";
            this.Load += new System.EventHandler(this.frm_login_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_login_KeyUp);
            this.pnl_login.ResumeLayout(false);
            this.pnl_login.PerformLayout();
            this.pnl_barra.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_entrar;
        private System.Windows.Forms.Label lbl_login;
        private System.Windows.Forms.Panel pnl_login;
        private System.Windows.Forms.TextBox txt_senha;
        private System.Windows.Forms.TextBox txt_login;
        private System.ComponentModel.BackgroundWorker bgwk_acessar;
        private System.Windows.Forms.ProgressBar pgbar_acessando;
        private System.Windows.Forms.Panel pnl_barra;
        private System.Windows.Forms.Label lbl_senha;
        private System.Windows.Forms.Label lbl_liberando_acesso;
    }
}