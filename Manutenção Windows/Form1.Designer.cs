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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRelatorio = new System.Windows.Forms.Button();
            this.comboDiscos = new System.Windows.Forms.ComboBox();
            this.btnVerificarDisco = new System.Windows.Forms.Button();
            this.txtCKDOutput = new System.Windows.Forms.TextBox();
            this.picAnimacaoRelatorio = new System.Windows.Forms.PictureBox();
            this.picAnimacaoDisk = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSfcOutput = new System.Windows.Forms.TextBox();
            this.btnSfc = new System.Windows.Forms.Button();
            this.picAnimacaoSFC = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.picAnimacaoDISM = new System.Windows.Forms.PictureBox();
            this.btnDismReparar = new System.Windows.Forms.Button();
            this.txtDismOutput = new System.Windows.Forms.TextBox();
            this.btnDismVerificar = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.picAnaliseBoot = new System.Windows.Forms.PictureBox();
            this.btnFastBoot = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btnAnalisarBoot = new System.Windows.Forms.Button();
            this.tabLimpeza = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.picAnimacaoLimpezaSistema = new System.Windows.Forms.PictureBox();
            this.lblAvisoWinSxS = new System.Windows.Forms.Label();
            this.lblStatusLimpeza = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.lblTotalLimpeza = new System.Windows.Forms.Label();
            this.listViewLimpeza = new System.Windows.Forms.ListView();
            this.Categoria = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Localização = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tamanho = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressLimpeza = new System.Windows.Forms.ProgressBar();
            this.btnAnalisarLimpeza = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btnGerarDumpBoot = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnRelatorioBoot = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimacaoRelatorio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimacaoDisk)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimacaoSFC)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimacaoDISM)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnaliseBoot)).BeginInit();
            this.tabLimpeza.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimacaoLimpezaSistema)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(124, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(836, 89);
            this.label1.TabIndex = 1;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabLimpeza);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(-4, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(10, 4);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1051, 922);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1043, 890);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bem Vindo";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(339, 503);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(294, 23);
            this.label12.TabIndex = 8;
            this.label12.Text = "https://github.com/DanielTelles91";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(339, 476);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(294, 23);
            this.label11.TabIndex = 7;
            this.label11.Text = "Email: daniel.telles91@yahoo.com";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(339, 558);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(283, 23);
            this.label10.TabIndex = 6;
            this.label10.Text = "Licensed under the MIT License.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 709);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(330, 21);
            this.label9.TabIndex = 5;
            this.label9.Text = "* Ferramenta não oficial da Microsoft";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(339, 530);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(219, 23);
            this.label8.TabIndex = 4;
            this.label8.Text = "Copyright © 2023 - 2026";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(453, 388);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 25);
            this.label7.TabIndex = 3;
            this.label7.Text = "Versão 1.0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(339, 448);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(340, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Desenvolvido por: Daniel Arantes Telles";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Manutenção_Windows.Properties.Resources.LogoPrograma;
            this.pictureBox1.Location = new System.Drawing.Point(380, 185);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(239, 135);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.AliceBlue;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(416, 324);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 52);
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
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1043, 890);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CheckDisk";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(124, 17);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(836, 89);
            this.label4.TabIndex = 17;
            this.label4.Text = resources.GetString("label4.Text");
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 622);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Selecione a Unidade:";
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.Location = new System.Drawing.Point(105, 692);
            this.btnRelatorio.Margin = new System.Windows.Forms.Padding(4);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(100, 28);
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
            this.comboDiscos.Location = new System.Drawing.Point(180, 615);
            this.comboDiscos.Margin = new System.Windows.Forms.Padding(4);
            this.comboDiscos.Name = "comboDiscos";
            this.comboDiscos.Size = new System.Drawing.Size(687, 26);
            this.comboDiscos.TabIndex = 12;
            // 
            // btnVerificarDisco
            // 
            this.btnVerificarDisco.BackColor = System.Drawing.Color.White;
            this.btnVerificarDisco.Location = new System.Drawing.Point(768, 692);
            this.btnVerificarDisco.Margin = new System.Windows.Forms.Padding(4);
            this.btnVerificarDisco.Name = "btnVerificarDisco";
            this.btnVerificarDisco.Size = new System.Drawing.Size(141, 28);
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
            this.txtCKDOutput.Location = new System.Drawing.Point(4, 119);
            this.txtCKDOutput.Margin = new System.Windows.Forms.Padding(4);
            this.txtCKDOutput.Multiline = true;
            this.txtCKDOutput.Name = "txtCKDOutput";
            this.txtCKDOutput.ReadOnly = true;
            this.txtCKDOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCKDOutput.Size = new System.Drawing.Size(1031, 474);
            this.txtCKDOutput.TabIndex = 6;
            // 
            // picAnimacaoRelatorio
            // 
            this.picAnimacaoRelatorio.Location = new System.Drawing.Point(43, 39);
            this.picAnimacaoRelatorio.Margin = new System.Windows.Forms.Padding(4);
            this.picAnimacaoRelatorio.Name = "picAnimacaoRelatorio";
            this.picAnimacaoRelatorio.Size = new System.Drawing.Size(56, 52);
            this.picAnimacaoRelatorio.TabIndex = 15;
            this.picAnimacaoRelatorio.TabStop = false;
            this.picAnimacaoRelatorio.Visible = false;
            // 
            // picAnimacaoDisk
            // 
            this.picAnimacaoDisk.BackColor = System.Drawing.Color.Transparent;
            this.picAnimacaoDisk.Image = global::Manutenção_Windows.Properties.Resources.disco1;
            this.picAnimacaoDisk.Location = new System.Drawing.Point(43, 39);
            this.picAnimacaoDisk.Margin = new System.Windows.Forms.Padding(4);
            this.picAnimacaoDisk.Name = "picAnimacaoDisk";
            this.picAnimacaoDisk.Size = new System.Drawing.Size(56, 52);
            this.picAnimacaoDisk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picAnimacaoDisk.TabIndex = 9;
            this.picAnimacaoDisk.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.txtSfcOutput);
            this.tabPage4.Controls.Add(this.btnSfc);
            this.tabPage4.Controls.Add(this.picAnimacaoSFC);
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1043, 890);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "SFC";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(124, 17);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(836, 89);
            this.label6.TabIndex = 9;
            this.label6.Text = resources.GetString("label6.Text");
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSfcOutput
            // 
            this.txtSfcOutput.BackColor = System.Drawing.Color.Black;
            this.txtSfcOutput.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSfcOutput.ForeColor = System.Drawing.Color.White;
            this.txtSfcOutput.Location = new System.Drawing.Point(4, 119);
            this.txtSfcOutput.Margin = new System.Windows.Forms.Padding(4);
            this.txtSfcOutput.Multiline = true;
            this.txtSfcOutput.Name = "txtSfcOutput";
            this.txtSfcOutput.ReadOnly = true;
            this.txtSfcOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSfcOutput.Size = new System.Drawing.Size(1031, 474);
            this.txtSfcOutput.TabIndex = 7;
            // 
            // btnSfc
            // 
            this.btnSfc.Location = new System.Drawing.Point(399, 692);
            this.btnSfc.Margin = new System.Windows.Forms.Padding(4);
            this.btnSfc.Name = "btnSfc";
            this.btnSfc.Size = new System.Drawing.Size(156, 28);
            this.btnSfc.TabIndex = 0;
            this.btnSfc.Text = "Executar SFC";
            this.btnSfc.UseVisualStyleBackColor = true;
            this.btnSfc.Click += new System.EventHandler(this.btnSfc_Click);
            // 
            // picAnimacaoSFC
            // 
            this.picAnimacaoSFC.Image = global::Manutenção_Windows.Properties.Resources.lupa1;
            this.picAnimacaoSFC.Location = new System.Drawing.Point(43, 39);
            this.picAnimacaoSFC.Margin = new System.Windows.Forms.Padding(4);
            this.picAnimacaoSFC.Name = "picAnimacaoSFC";
            this.picAnimacaoSFC.Size = new System.Drawing.Size(43, 39);
            this.picAnimacaoSFC.TabIndex = 8;
            this.picAnimacaoSFC.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage3.Controls.Add(this.picAnimacaoDISM);
            this.tabPage3.Controls.Add(this.btnDismReparar);
            this.tabPage3.Controls.Add(this.txtDismOutput);
            this.tabPage3.Controls.Add(this.btnDismVerificar);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1043, 890);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "DISM";
            // 
            // picAnimacaoDISM
            // 
            this.picAnimacaoDISM.Image = global::Manutenção_Windows.Properties.Resources.lupa1;
            this.picAnimacaoDISM.Location = new System.Drawing.Point(43, 39);
            this.picAnimacaoDISM.Margin = new System.Windows.Forms.Padding(4);
            this.picAnimacaoDISM.Name = "picAnimacaoDISM";
            this.picAnimacaoDISM.Size = new System.Drawing.Size(43, 39);
            this.picAnimacaoDISM.TabIndex = 10;
            this.picAnimacaoDISM.TabStop = false;
            // 
            // btnDismReparar
            // 
            this.btnDismReparar.BackColor = System.Drawing.Color.Transparent;
            this.btnDismReparar.Location = new System.Drawing.Point(768, 692);
            this.btnDismReparar.Margin = new System.Windows.Forms.Padding(4);
            this.btnDismReparar.Name = "btnDismReparar";
            this.btnDismReparar.Size = new System.Drawing.Size(125, 28);
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
            this.txtDismOutput.Location = new System.Drawing.Point(4, 119);
            this.txtDismOutput.Margin = new System.Windows.Forms.Padding(4);
            this.txtDismOutput.Multiline = true;
            this.txtDismOutput.Name = "txtDismOutput";
            this.txtDismOutput.ReadOnly = true;
            this.txtDismOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDismOutput.Size = new System.Drawing.Size(1031, 474);
            this.txtDismOutput.TabIndex = 8;
            // 
            // btnDismVerificar
            // 
            this.btnDismVerificar.Location = new System.Drawing.Point(105, 692);
            this.btnDismVerificar.Margin = new System.Windows.Forms.Padding(4);
            this.btnDismVerificar.Name = "btnDismVerificar";
            this.btnDismVerificar.Size = new System.Drawing.Size(140, 28);
            this.btnDismVerificar.TabIndex = 2;
            this.btnDismVerificar.Text = "Verificar DISM";
            this.btnDismVerificar.UseVisualStyleBackColor = true;
            this.btnDismVerificar.Click += new System.EventHandler(this.btnDismVerificar_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage6.Controls.Add(this.picAnaliseBoot);
            this.tabPage6.Controls.Add(this.btnFastBoot);
            this.tabPage6.Controls.Add(this.label13);
            this.tabPage6.Controls.Add(this.btnAnalisarBoot);
            this.tabPage6.Location = new System.Drawing.Point(4, 28);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage6.Size = new System.Drawing.Size(1043, 890);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Análise de Boot";
            // 
            // picAnaliseBoot
            // 
            this.picAnaliseBoot.Image = global::Manutenção_Windows.Properties.Resources.AnaliseBoot;
            this.picAnaliseBoot.Location = new System.Drawing.Point(43, 39);
            this.picAnaliseBoot.Margin = new System.Windows.Forms.Padding(4);
            this.picAnaliseBoot.Name = "picAnaliseBoot";
            this.picAnaliseBoot.Size = new System.Drawing.Size(43, 39);
            this.picAnaliseBoot.TabIndex = 5;
            this.picAnaliseBoot.TabStop = false;
            // 
            // btnFastBoot
            // 
            this.btnFastBoot.Location = new System.Drawing.Point(759, 222);
            this.btnFastBoot.Margin = new System.Windows.Forms.Padding(4);
            this.btnFastBoot.Name = "btnFastBoot";
            this.btnFastBoot.Size = new System.Drawing.Size(180, 46);
            this.btnFastBoot.TabIndex = 4;
            this.btnFastBoot.Text = "Análise Fast Startup";
            this.btnFastBoot.UseVisualStyleBackColor = true;
            this.btnFastBoot.Click += new System.EventHandler(this.btnFastBoot_Click);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(125, 17);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(836, 122);
            this.label13.TabIndex = 3;
            this.label13.Text = resources.GetString("label13.Text");
            // 
            // btnAnalisarBoot
            // 
            this.btnAnalisarBoot.Location = new System.Drawing.Point(129, 222);
            this.btnAnalisarBoot.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnalisarBoot.Name = "btnAnalisarBoot";
            this.btnAnalisarBoot.Size = new System.Drawing.Size(161, 46);
            this.btnAnalisarBoot.TabIndex = 1;
            this.btnAnalisarBoot.Text = "Análise Performance de Boot";
            this.btnAnalisarBoot.UseVisualStyleBackColor = true;
            this.btnAnalisarBoot.Click += new System.EventHandler(this.btnAnalisarBoot_Click);
            // 
            // tabLimpeza
            // 
            this.tabLimpeza.BackColor = System.Drawing.Color.Gainsboro;
            this.tabLimpeza.Controls.Add(this.label15);
            this.tabLimpeza.Controls.Add(this.picAnimacaoLimpezaSistema);
            this.tabLimpeza.Controls.Add(this.lblAvisoWinSxS);
            this.tabLimpeza.Controls.Add(this.lblStatusLimpeza);
            this.tabLimpeza.Controls.Add(this.btnLimpar);
            this.tabLimpeza.Controls.Add(this.lblTotalLimpeza);
            this.tabLimpeza.Controls.Add(this.listViewLimpeza);
            this.tabLimpeza.Controls.Add(this.progressLimpeza);
            this.tabLimpeza.Controls.Add(this.btnAnalisarLimpeza);
            this.tabLimpeza.Controls.Add(this.label14);
            this.tabLimpeza.Location = new System.Drawing.Point(4, 28);
            this.tabLimpeza.Name = "tabLimpeza";
            this.tabLimpeza.Padding = new System.Windows.Forms.Padding(3);
            this.tabLimpeza.Size = new System.Drawing.Size(1043, 890);
            this.tabLimpeza.TabIndex = 6;
            this.tabLimpeza.Text = "Limpeza do Sistema";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(124, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(844, 129);
            this.label15.TabIndex = 9;
            this.label15.Text = resources.GetString("label15.Text");
            // 
            // picAnimacaoLimpezaSistema
            // 
            this.picAnimacaoLimpezaSistema.Image = global::Manutenção_Windows.Properties.Resources.vassoura_1;
            this.picAnimacaoLimpezaSistema.Location = new System.Drawing.Point(43, 39);
            this.picAnimacaoLimpezaSistema.Name = "picAnimacaoLimpezaSistema";
            this.picAnimacaoLimpezaSistema.Size = new System.Drawing.Size(43, 39);
            this.picAnimacaoLimpezaSistema.TabIndex = 8;
            this.picAnimacaoLimpezaSistema.TabStop = false;
            // 
            // lblAvisoWinSxS
            // 
            this.lblAvisoWinSxS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvisoWinSxS.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblAvisoWinSxS.Location = new System.Drawing.Point(12, 414);
            this.lblAvisoWinSxS.Name = "lblAvisoWinSxS";
            this.lblAvisoWinSxS.Size = new System.Drawing.Size(660, 191);
            this.lblAvisoWinSxS.TabIndex = 7;
            this.lblAvisoWinSxS.Text = "label15";
            this.lblAvisoWinSxS.Visible = false;
            // 
            // lblStatusLimpeza
            // 
            this.lblStatusLimpeza.AutoSize = true;
            this.lblStatusLimpeza.Location = new System.Drawing.Point(182, 617);
            this.lblStatusLimpeza.Name = "lblStatusLimpeza";
            this.lblStatusLimpeza.Size = new System.Drawing.Size(147, 17);
            this.lblStatusLimpeza.TabIndex = 6;
            this.lblStatusLimpeza.Text = "Aguardando análise...";
            // 
            // btnLimpar
            // 
            this.btnLimpar.Enabled = false;
            this.btnLimpar.Location = new System.Drawing.Point(687, 677);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(148, 33);
            this.btnLimpar.TabIndex = 5;
            this.btnLimpar.Text = "Limpar selecionados";
            this.btnLimpar.UseVisualStyleBackColor = true;
            // 
            // lblTotalLimpeza
            // 
            this.lblTotalLimpeza.AutoSize = true;
            this.lblTotalLimpeza.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLimpeza.Location = new System.Drawing.Point(704, 413);
            this.lblTotalLimpeza.Name = "lblTotalLimpeza";
            this.lblTotalLimpeza.Size = new System.Drawing.Size(233, 20);
            this.lblTotalLimpeza.TabIndex = 4;
            this.lblTotalLimpeza.Text = "Espaço selecionado: 0 MB";
            // 
            // listViewLimpeza
            // 
            this.listViewLimpeza.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listViewLimpeza.CheckBoxes = true;
            this.listViewLimpeza.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Categoria,
            this.Localização,
            this.Tamanho,
            this.Status});
            this.listViewLimpeza.FullRowSelect = true;
            this.listViewLimpeza.GridLines = true;
            this.listViewLimpeza.HideSelection = false;
            this.listViewLimpeza.Location = new System.Drawing.Point(4, 149);
            this.listViewLimpeza.Name = "listViewLimpeza";
            this.listViewLimpeza.Scrollable = false;
            this.listViewLimpeza.Size = new System.Drawing.Size(1024, 259);
            this.listViewLimpeza.TabIndex = 3;
            this.listViewLimpeza.UseCompatibleStateImageBehavior = false;
            this.listViewLimpeza.View = System.Windows.Forms.View.Details;
            this.listViewLimpeza.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewLimpeza_ItemChecked);
            // 
            // Categoria
            // 
            this.Categoria.Text = "Categoria";
            this.Categoria.Width = 260;
            // 
            // Localização
            // 
            this.Localização.Text = "Localização";
            this.Localização.Width = 270;
            // 
            // Tamanho
            // 
            this.Tamanho.Text = "Tamanho";
            this.Tamanho.Width = 100;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 140;
            // 
            // progressLimpeza
            // 
            this.progressLimpeza.Location = new System.Drawing.Point(185, 637);
            this.progressLimpeza.Name = "progressLimpeza";
            this.progressLimpeza.Size = new System.Drawing.Size(650, 25);
            this.progressLimpeza.TabIndex = 2;
            // 
            // btnAnalisarLimpeza
            // 
            this.btnAnalisarLimpeza.Location = new System.Drawing.Point(185, 677);
            this.btnAnalisarLimpeza.Name = "btnAnalisarLimpeza";
            this.btnAnalisarLimpeza.Size = new System.Drawing.Size(100, 33);
            this.btnAnalisarLimpeza.TabIndex = 1;
            this.btnAnalisarLimpeza.Text = "Analisar";
            this.btnAnalisarLimpeza.UseVisualStyleBackColor = true;
            this.btnAnalisarLimpeza.Click += new System.EventHandler(this.btnAnalisarLimpeza_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(114, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 20);
            this.label14.TabIndex = 0;
            // 
            // btnGerarDumpBoot
            // 
            this.btnGerarDumpBoot.Location = new System.Drawing.Point(0, 0);
            this.btnGerarDumpBoot.Name = "btnGerarDumpBoot";
            this.btnGerarDumpBoot.Size = new System.Drawing.Size(75, 23);
            this.btnGerarDumpBoot.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            // 
            // btnRelatorioBoot
            // 
            this.btnRelatorioBoot.Location = new System.Drawing.Point(0, 0);
            this.btnRelatorioBoot.Name = "btnRelatorioBoot";
            this.btnRelatorioBoot.Size = new System.Drawing.Size(75, 23);
            this.btnRelatorioBoot.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1040, 782);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windoctor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimacaoRelatorio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimacaoDisk)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimacaoSFC)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimacaoDISM)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAnaliseBoot)).EndInit();
            this.tabLimpeza.ResumeLayout(false);
            this.tabLimpeza.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimacaoLimpezaSistema)).EndInit();
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
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnRelatorioBoot;
        private System.Windows.Forms.Button btnGerarDumpBoot;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button btnAnalisarBoot;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnFastBoot;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.PictureBox picAnaliseBoot;
        private System.Windows.Forms.TabPage tabLimpeza;
        private System.Windows.Forms.ListView listViewLimpeza;
        private System.Windows.Forms.ProgressBar progressLimpeza;
        private System.Windows.Forms.Button btnAnalisarLimpeza;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ColumnHeader Categoria;
        private System.Windows.Forms.ColumnHeader Localização;
        private System.Windows.Forms.ColumnHeader Tamanho;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label lblTotalLimpeza;
        private System.Windows.Forms.Label lblStatusLimpeza;
        private System.Windows.Forms.Label lblAvisoWinSxS;
        private System.Windows.Forms.PictureBox picAnimacaoLimpezaSistema;
        private System.Windows.Forms.Label label15;
    }
}