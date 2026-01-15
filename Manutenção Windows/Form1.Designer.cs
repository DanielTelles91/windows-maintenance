namespace Manutenção_Windows
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAgendar = new System.Windows.Forms.Button();
            this.txtCKDOutput = new System.Windows.Forms.TextBox();
            this.btnPegaRelatorio = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSfcOutput = new System.Windows.Forms.TextBox();
            this.btnSfc = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnDismReparar = new System.Windows.Forms.Button();
            this.txtDismOutput = new System.Windows.Forms.TextBox();
            this.btnDismVerificar = new System.Windows.Forms.Button();
            this.picAnimacaoDisk = new System.Windows.Forms.PictureBox();
            this.picAnimacaoSFC = new System.Windows.Forms.PictureBox();
            this.picAnimacaoDISM = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimacaoDisk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimacaoSFC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimacaoDISM)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(627, 72);
            this.label1.TabIndex = 1;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 46);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 703);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(752, 677);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bem Vindo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.AliceBlue;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(5, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(741, 42);
            this.label3.TabIndex = 0;
            this.label3.Text = "Bem-Vindo ao Gerenciamento de Manutenção do Windows";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAgendar);
            this.tabPage2.Controls.Add(this.txtCKDOutput);
            this.tabPage2.Controls.Add(this.btnPegaRelatorio);
            this.tabPage2.Controls.Add(this.picAnimacaoDisk);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(752, 677);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CheckDisk";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAgendar
            // 
            this.btnAgendar.Location = new System.Drawing.Point(545, 545);
            this.btnAgendar.Name = "btnAgendar";
            this.btnAgendar.Size = new System.Drawing.Size(75, 23);
            this.btnAgendar.TabIndex = 11;
            this.btnAgendar.Text = "&Agendar";
            this.btnAgendar.UseVisualStyleBackColor = true;
            this.btnAgendar.Click += new System.EventHandler(this.btnAgendar_Click);
            // 
            // txtCKDOutput
            // 
            this.txtCKDOutput.BackColor = System.Drawing.Color.Black;
            this.txtCKDOutput.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCKDOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtCKDOutput.Location = new System.Drawing.Point(3, 97);
            this.txtCKDOutput.Multiline = true;
            this.txtCKDOutput.Name = "txtCKDOutput";
            this.txtCKDOutput.ReadOnly = true;
            this.txtCKDOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCKDOutput.Size = new System.Drawing.Size(746, 386);
            this.txtCKDOutput.TabIndex = 6;
            // 
            // btnPegaRelatorio
            // 
            this.btnPegaRelatorio.Location = new System.Drawing.Point(93, 545);
            this.btnPegaRelatorio.Name = "btnPegaRelatorio";
            this.btnPegaRelatorio.Size = new System.Drawing.Size(89, 23);
            this.btnPegaRelatorio.TabIndex = 7;
            this.btnPegaRelatorio.Text = "Exibe Relatório";
            this.btnPegaRelatorio.UseVisualStyleBackColor = true;
            this.btnPegaRelatorio.Click += new System.EventHandler(this.btnPegaRelatorio_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.txtSfcOutput);
            this.tabPage4.Controls.Add(this.btnSfc);
            this.tabPage4.Controls.Add(this.picAnimacaoSFC);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(752, 677);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "SFC";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(93, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(627, 72);
            this.label6.TabIndex = 9;
            this.label6.Text = resources.GetString("label6.Text");
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSfcOutput
            // 
            this.txtSfcOutput.BackColor = System.Drawing.Color.Black;
            this.txtSfcOutput.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSfcOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtSfcOutput.Location = new System.Drawing.Point(3, 97);
            this.txtSfcOutput.Multiline = true;
            this.txtSfcOutput.Name = "txtSfcOutput";
            this.txtSfcOutput.ReadOnly = true;
            this.txtSfcOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSfcOutput.Size = new System.Drawing.Size(746, 386);
            this.txtSfcOutput.TabIndex = 7;
            // 
            // btnSfc
            // 
            this.btnSfc.Location = new System.Drawing.Point(303, 535);
            this.btnSfc.Name = "btnSfc";
            this.btnSfc.Size = new System.Drawing.Size(117, 23);
            this.btnSfc.TabIndex = 0;
            this.btnSfc.Text = "Executar SFC";
            this.btnSfc.UseVisualStyleBackColor = true;
            this.btnSfc.Click += new System.EventHandler(this.btnSfc_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.picAnimacaoDISM);
            this.tabPage3.Controls.Add(this.btnDismReparar);
            this.tabPage3.Controls.Add(this.txtDismOutput);
            this.tabPage3.Controls.Add(this.btnDismVerificar);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(752, 677);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "DISM";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnDismReparar
            // 
            this.btnDismReparar.Location = new System.Drawing.Point(546, 540);
            this.btnDismReparar.Name = "btnDismReparar";
            this.btnDismReparar.Size = new System.Drawing.Size(94, 23);
            this.btnDismReparar.TabIndex = 9;
            this.btnDismReparar.Text = "Reparar DISM";
            this.btnDismReparar.UseVisualStyleBackColor = true;
            this.btnDismReparar.Click += new System.EventHandler(this.btnDismReparar_Click);
            // 
            // txtDismOutput
            // 
            this.txtDismOutput.BackColor = System.Drawing.Color.Black;
            this.txtDismOutput.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDismOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtDismOutput.Location = new System.Drawing.Point(3, 97);
            this.txtDismOutput.Multiline = true;
            this.txtDismOutput.Name = "txtDismOutput";
            this.txtDismOutput.ReadOnly = true;
            this.txtDismOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDismOutput.Size = new System.Drawing.Size(746, 386);
            this.txtDismOutput.TabIndex = 8;
            // 
            // btnDismVerificar
            // 
            this.btnDismVerificar.Location = new System.Drawing.Point(96, 540);
            this.btnDismVerificar.Name = "btnDismVerificar";
            this.btnDismVerificar.Size = new System.Drawing.Size(105, 23);
            this.btnDismVerificar.TabIndex = 2;
            this.btnDismVerificar.Text = "Verificar DISM";
            this.btnDismVerificar.UseVisualStyleBackColor = true;
            this.btnDismVerificar.Click += new System.EventHandler(this.btnDismVerificar_Click);
            // 
            // picAnimacaoDisk
            // 
            this.picAnimacaoDisk.BackColor = System.Drawing.Color.Transparent;
            this.picAnimacaoDisk.BackgroundImage = global::Manutenção_Windows.Properties.Resources._1;
            this.picAnimacaoDisk.Location = new System.Drawing.Point(32, 32);
            this.picAnimacaoDisk.Name = "picAnimacaoDisk";
            this.picAnimacaoDisk.Size = new System.Drawing.Size(42, 42);
            this.picAnimacaoDisk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picAnimacaoDisk.TabIndex = 9;
            this.picAnimacaoDisk.TabStop = false;
            // 
            // picAnimacaoSFC
            // 
            this.picAnimacaoSFC.Image = ((System.Drawing.Image)(resources.GetObject("picAnimacaoSFC.Image")));
            this.picAnimacaoSFC.Location = new System.Drawing.Point(32, 32);
            this.picAnimacaoSFC.Name = "picAnimacaoSFC";
            this.picAnimacaoSFC.Size = new System.Drawing.Size(32, 32);
            this.picAnimacaoSFC.TabIndex = 8;
            this.picAnimacaoSFC.TabStop = false;
            // 
            // picAnimacaoDISM
            // 
            this.picAnimacaoDISM.Image = ((System.Drawing.Image)(resources.GetObject("picAnimacaoDISM.Image")));
            this.picAnimacaoDISM.Location = new System.Drawing.Point(32, 32);
            this.picAnimacaoDISM.Name = "picAnimacaoDISM";
            this.picAnimacaoDISM.Size = new System.Drawing.Size(32, 32);
            this.picAnimacaoDISM.TabIndex = 10;
            this.picAnimacaoDISM.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manutenção Windows";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimacaoDisk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimacaoSFC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimacaoDISM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txtCKDOutput;
        private System.Windows.Forms.Button btnPegaRelatorio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picAnimacaoDisk;
        private System.Windows.Forms.Button btnAgendar;
        private System.Windows.Forms.Button btnSfc;
        private System.Windows.Forms.TextBox txtSfcOutput;
        private System.Windows.Forms.PictureBox picAnimacaoSFC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDismVerificar;
        private System.Windows.Forms.TextBox txtDismOutput;
        private System.Windows.Forms.Button btnDismReparar;
        private System.Windows.Forms.PictureBox picAnimacaoDISM;
    }
}