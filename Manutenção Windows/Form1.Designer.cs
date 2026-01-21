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
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRelatorio = new System.Windows.Forms.Button();
            this.comboDiscos = new System.Windows.Forms.ComboBox();
            this.btnVerificarDisco = new System.Windows.Forms.Button();
            this.txtCKDOutput = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSfcOutput = new System.Windows.Forms.TextBox();
            this.btnSfc = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnDismReparar = new System.Windows.Forms.Button();
            this.txtDismOutput = new System.Windows.Forms.TextBox();
            this.btnDismVerificar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picAnimacaoRelatorio = new System.Windows.Forms.PictureBox();
            this.picAnimacaoDisk = new System.Windows.Forms.PictureBox();
            this.picAnimacaoSFC = new System.Windows.Forms.PictureBox();
            this.picAnimacaoDISM = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimacaoRelatorio)).BeginInit();
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
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(-3, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(788, 737);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(780, 711);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bem Vindo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(252, 433);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(221, 18);
            this.label10.TabIndex = 6;
            this.label10.Text = "Licensed under the MIT License.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(252, 363);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(222, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "* Ferramenta não oficial da Microsoft";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(252, 415);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(172, 18);
            this.label8.TabIndex = 4;
            this.label8.Text = "Copyright © 2023 - 2026";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(252, 345);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 18);
            this.label7.TabIndex = 3;
            this.label7.Text = "Versão 0.9 Beta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(252, 394);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(264, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Desenvolvido por: Daniel Arantes Telles";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.AliceBlue;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(312, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 42);
            this.label3.TabIndex = 0;
            this.label3.Text = "Windoctor";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btnRelatorio);
            this.tabPage2.Controls.Add(this.comboDiscos);
            this.tabPage2.Controls.Add(this.btnVerificarDisco);
            this.tabPage2.Controls.Add(this.txtCKDOutput);
            this.tabPage2.Controls.Add(this.picAnimacaoRelatorio);
            this.tabPage2.Controls.Add(this.picAnimacaoDisk);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(780, 711);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CheckDisk";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(93, 14);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(627, 72);
            this.label4.TabIndex = 17;
            this.label4.Text = resources.GetString("label4.Text");
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 505);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Selecione a Unidade:";
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.Location = new System.Drawing.Point(79, 562);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(75, 23);
            this.btnRelatorio.TabIndex = 14;
            this.btnRelatorio.Text = "Relatório";
            this.btnRelatorio.UseVisualStyleBackColor = true;
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // comboDiscos
            // 
            this.comboDiscos.BackColor = System.Drawing.SystemColors.Window;
            this.comboDiscos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDiscos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboDiscos.FormattingEnabled = true;
            this.comboDiscos.Location = new System.Drawing.Point(135, 500);
            this.comboDiscos.Name = "comboDiscos";
            this.comboDiscos.Size = new System.Drawing.Size(516, 23);
            this.comboDiscos.TabIndex = 12;
            // 
            // btnVerificarDisco
            // 
            this.btnVerificarDisco.BackColor = System.Drawing.Color.White;
            this.btnVerificarDisco.Location = new System.Drawing.Point(576, 562);
            this.btnVerificarDisco.Name = "btnVerificarDisco";
            this.btnVerificarDisco.Size = new System.Drawing.Size(106, 23);
            this.btnVerificarDisco.TabIndex = 11;
            this.btnVerificarDisco.Text = "Verificar Disco";
            this.btnVerificarDisco.UseVisualStyleBackColor = false;
            this.btnVerificarDisco.Click += new System.EventHandler(this.btnVerificarDisco_Click);
            // 
            // txtCKDOutput
            // 
            this.txtCKDOutput.BackColor = System.Drawing.Color.Black;
            this.txtCKDOutput.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCKDOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCKDOutput.Location = new System.Drawing.Point(3, 97);
            this.txtCKDOutput.Multiline = true;
            this.txtCKDOutput.Name = "txtCKDOutput";
            this.txtCKDOutput.ReadOnly = true;
            this.txtCKDOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCKDOutput.Size = new System.Drawing.Size(774, 386);
            this.txtCKDOutput.TabIndex = 6;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.txtSfcOutput);
            this.tabPage4.Controls.Add(this.btnSfc);
            this.tabPage4.Controls.Add(this.picAnimacaoSFC);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(780, 711);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "SFC";
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
            this.txtSfcOutput.ForeColor = System.Drawing.Color.White;
            this.txtSfcOutput.Location = new System.Drawing.Point(3, 97);
            this.txtSfcOutput.Multiline = true;
            this.txtSfcOutput.Name = "txtSfcOutput";
            this.txtSfcOutput.ReadOnly = true;
            this.txtSfcOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSfcOutput.Size = new System.Drawing.Size(774, 386);
            this.txtSfcOutput.TabIndex = 7;
            // 
            // btnSfc
            // 
            this.btnSfc.Location = new System.Drawing.Point(299, 562);
            this.btnSfc.Name = "btnSfc";
            this.btnSfc.Size = new System.Drawing.Size(117, 23);
            this.btnSfc.TabIndex = 0;
            this.btnSfc.Text = "Executar SFC";
            this.btnSfc.UseVisualStyleBackColor = true;
            this.btnSfc.Click += new System.EventHandler(this.btnSfc_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage3.Controls.Add(this.picAnimacaoDISM);
            this.tabPage3.Controls.Add(this.btnDismReparar);
            this.tabPage3.Controls.Add(this.txtDismOutput);
            this.tabPage3.Controls.Add(this.btnDismVerificar);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(780, 711);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "DISM";
            // 
            // btnDismReparar
            // 
            this.btnDismReparar.BackColor = System.Drawing.Color.Transparent;
            this.btnDismReparar.Location = new System.Drawing.Point(576, 562);
            this.btnDismReparar.Name = "btnDismReparar";
            this.btnDismReparar.Size = new System.Drawing.Size(94, 23);
            this.btnDismReparar.TabIndex = 9;
            this.btnDismReparar.Text = "Reparar DISM";
            this.btnDismReparar.UseVisualStyleBackColor = false;
            this.btnDismReparar.Click += new System.EventHandler(this.btnDismReparar_Click);
            // 
            // txtDismOutput
            // 
            this.txtDismOutput.BackColor = System.Drawing.Color.Black;
            this.txtDismOutput.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDismOutput.ForeColor = System.Drawing.Color.White;
            this.txtDismOutput.Location = new System.Drawing.Point(3, 97);
            this.txtDismOutput.Multiline = true;
            this.txtDismOutput.Name = "txtDismOutput";
            this.txtDismOutput.ReadOnly = true;
            this.txtDismOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDismOutput.Size = new System.Drawing.Size(774, 386);
            this.txtDismOutput.TabIndex = 8;
            // 
            // btnDismVerificar
            // 
            this.btnDismVerificar.Location = new System.Drawing.Point(79, 562);
            this.btnDismVerificar.Name = "btnDismVerificar";
            this.btnDismVerificar.Size = new System.Drawing.Size(105, 23);
            this.btnDismVerificar.TabIndex = 2;
            this.btnDismVerificar.Text = "Verificar DISM";
            this.btnDismVerificar.UseVisualStyleBackColor = true;
            this.btnDismVerificar.Click += new System.EventHandler(this.btnDismVerificar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Manutenção_Windows.Properties.Resources.LogoPrograma;
            this.pictureBox1.Location = new System.Drawing.Point(285, 177);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(179, 110);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // picAnimacaoRelatorio
            // 
            this.picAnimacaoRelatorio.Location = new System.Drawing.Point(32, 32);
            this.picAnimacaoRelatorio.Name = "picAnimacaoRelatorio";
            this.picAnimacaoRelatorio.Size = new System.Drawing.Size(42, 42);
            this.picAnimacaoRelatorio.TabIndex = 15;
            this.picAnimacaoRelatorio.TabStop = false;
            this.picAnimacaoRelatorio.Visible = false;
            // 
            // picAnimacaoDisk
            // 
            this.picAnimacaoDisk.BackColor = System.Drawing.Color.Transparent;
            this.picAnimacaoDisk.Image = global::Manutenção_Windows.Properties.Resources.disco1;
            this.picAnimacaoDisk.Location = new System.Drawing.Point(32, 32);
            this.picAnimacaoDisk.Name = "picAnimacaoDisk";
            this.picAnimacaoDisk.Size = new System.Drawing.Size(42, 42);
            this.picAnimacaoDisk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picAnimacaoDisk.TabIndex = 9;
            this.picAnimacaoDisk.TabStop = false;
            // 
            // picAnimacaoSFC
            // 
            this.picAnimacaoSFC.Image = global::Manutenção_Windows.Properties.Resources.lupa1;
            this.picAnimacaoSFC.Location = new System.Drawing.Point(32, 32);
            this.picAnimacaoSFC.Name = "picAnimacaoSFC";
            this.picAnimacaoSFC.Size = new System.Drawing.Size(32, 32);
            this.picAnimacaoSFC.TabIndex = 8;
            this.picAnimacaoSFC.TabStop = false;
            // 
            // picAnimacaoDISM
            // 
            this.picAnimacaoDISM.Image = global::Manutenção_Windows.Properties.Resources.lupa1;
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
            this.ClientSize = new System.Drawing.Size(780, 635);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windoctor";
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimacaoRelatorio)).EndInit();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picAnimacaoDisk;
        private System.Windows.Forms.Button btnVerificarDisco;
        private System.Windows.Forms.Button btnSfc;
        private System.Windows.Forms.TextBox txtSfcOutput;
        private System.Windows.Forms.PictureBox picAnimacaoSFC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDismVerificar;
        private System.Windows.Forms.TextBox txtDismOutput;
        private System.Windows.Forms.Button btnDismReparar;
        private System.Windows.Forms.PictureBox picAnimacaoDISM;
        private System.Windows.Forms.ComboBox comboDiscos;
        private System.Windows.Forms.Button btnRelatorio;
        private System.Windows.Forms.PictureBox picAnimacaoRelatorio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}