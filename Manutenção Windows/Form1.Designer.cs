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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAgendar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnPegaRelatorio = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtSfcOutput = new System.Windows.Forms.TextBox();
            this.btnSfc = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnDismReparar = new System.Windows.Forms.Button();
            this.txtDismOutput = new System.Windows.Forms.TextBox();
            this.btnDismVerificar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(633, 94);
            this.label1.TabIndex = 1;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(752, 677);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bem Vindo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(343, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Selecione ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
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
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAgendar);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtOutput);
            this.tabPage2.Controls.Add(this.btnPegaRelatorio);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.pictureBox1);
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
            this.btnAgendar.Location = new System.Drawing.Point(529, 136);
            this.btnAgendar.Name = "btnAgendar";
            this.btnAgendar.Size = new System.Drawing.Size(75, 23);
            this.btnAgendar.TabIndex = 11;
            this.btnAgendar.Text = "&Agendar";
            this.btnAgendar.UseVisualStyleBackColor = true;
            this.btnAgendar.Click += new System.EventHandler(this.btnAgendar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(400, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Agendar CheckDisk:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.Color.Black;
            this.txtOutput.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtOutput.Location = new System.Drawing.Point(0, 165);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(749, 507);
            this.txtOutput.TabIndex = 6;
            // 
            // btnPegaRelatorio
            // 
            this.btnPegaRelatorio.Location = new System.Drawing.Point(140, 136);
            this.btnPegaRelatorio.Name = "btnPegaRelatorio";
            this.btnPegaRelatorio.Size = new System.Drawing.Size(75, 23);
            this.btnPegaRelatorio.TabIndex = 7;
            this.btnPegaRelatorio.Text = "&Exibir";
            this.btnPegaRelatorio.UseVisualStyleBackColor = true;
            this.btnPegaRelatorio.Click += new System.EventHandler(this.btnPegaRelatorio_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Relatório Check Disk:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Manutenção_Windows.Properties.Resources.tumblr_6f41690f782d77e9b463d52b66a8ec54_0f726df2_5401;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.pictureBox2);
            this.tabPage4.Controls.Add(this.txtSfcOutput);
            this.tabPage4.Controls.Add(this.btnSfc);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(752, 677);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "SFC";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(95, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(633, 94);
            this.label6.TabIndex = 9;
            this.label6.Text = resources.GetString("label6.Text");
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Click += new System.EventHandler(this.label6_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Manutenção_Windows.Properties.Resources.sfcIcon1;
            this.pictureBox2.Location = new System.Drawing.Point(17, 24);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 60);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // txtSfcOutput
            // 
            this.txtSfcOutput.BackColor = System.Drawing.Color.Black;
            this.txtSfcOutput.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSfcOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtSfcOutput.Location = new System.Drawing.Point(0, 115);
            this.txtSfcOutput.Multiline = true;
            this.txtSfcOutput.Name = "txtSfcOutput";
            this.txtSfcOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSfcOutput.Size = new System.Drawing.Size(746, 386);
            this.txtSfcOutput.TabIndex = 7;
            // 
            // btnSfc
            // 
            this.btnSfc.Location = new System.Drawing.Point(283, 507);
            this.btnSfc.Name = "btnSfc";
            this.btnSfc.Size = new System.Drawing.Size(117, 23);
            this.btnSfc.TabIndex = 0;
            this.btnSfc.Text = "Executar SFC";
            this.btnSfc.UseVisualStyleBackColor = true;
            this.btnSfc.Click += new System.EventHandler(this.btnSfc_Click);
            // 
            // tabPage3
            // 
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
            this.txtDismOutput.Location = new System.Drawing.Point(6, 97);
            this.txtDismOutput.Multiline = true;
            this.txtDismOutput.Name = "txtDismOutput";
            this.txtDismOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDismOutput.Size = new System.Drawing.Size(746, 386);
            this.txtDismOutput.TabIndex = 8;
            this.txtDismOutput.TextChanged += new System.EventHandler(this.txtDismOutput_TextChanged);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnPegaRelatorio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAgendar;
        private System.Windows.Forms.Button btnSfc;
        private System.Windows.Forms.TextBox txtSfcOutput;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDismVerificar;
        private System.Windows.Forms.TextBox txtDismOutput;
        private System.Windows.Forms.Button btnDismReparar;
    }
}

