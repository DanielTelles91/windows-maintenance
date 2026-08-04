namespace Manutenção_Windows.Forms
{
    partial class AnalisarPerfBoot
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalisarPerfBoot));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBoots = new System.Windows.Forms.ComboBox();
            this.pnlResumo = new System.Windows.Forms.Panel();
            this.lblDiagnostico = new System.Windows.Forms.Label();
            this.lblResumoTempo = new System.Windows.Forms.Label();
            this.lblTituloBoot = new System.Windows.Forms.Label();
            this.chartBoot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAplicativos = new System.Windows.Forms.TabPage();
            this.gridAplicativos = new System.Windows.Forms.DataGridView();
            this.colNomeAplicativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTempoAplicativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabDrivers = new System.Windows.Forms.TabPage();
            this.gridDrivers = new System.Windows.Forms.DataGridView();
            this.colNomeDriver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTempoDriver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabServicos = new System.Windows.Forms.TabPage();
            this.gridServicos = new System.Windows.Forms.DataGridView();
            this.colNomeServico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTempoServico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlResumo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBoot)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabAplicativos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAplicativos)).BeginInit();
            this.tabDrivers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDrivers)).BeginInit();
            this.tabServicos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridServicos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Período";
            // 
            // cmbBoots
            // 
            this.cmbBoots.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoots.FormattingEnabled = true;
            this.cmbBoots.Location = new System.Drawing.Point(63, 21);
            this.cmbBoots.Name = "cmbBoots";
            this.cmbBoots.Size = new System.Drawing.Size(231, 21);
            this.cmbBoots.TabIndex = 1;
            this.cmbBoots.SelectedIndexChanged += new System.EventHandler(this.cmbBoots_SelectedIndexChanged);
            // 
            // pnlResumo
            // 
            this.pnlResumo.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlResumo.Controls.Add(this.lblDiagnostico);
            this.pnlResumo.Controls.Add(this.lblResumoTempo);
            this.pnlResumo.Controls.Add(this.lblTituloBoot);
            this.pnlResumo.Location = new System.Drawing.Point(0, 48);
            this.pnlResumo.Name = "pnlResumo";
            this.pnlResumo.Size = new System.Drawing.Size(799, 140);
            this.pnlResumo.TabIndex = 3;
            // 
            // lblDiagnostico
            // 
            this.lblDiagnostico.AutoSize = true;
            this.lblDiagnostico.BackColor = System.Drawing.Color.Black;
            this.lblDiagnostico.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiagnostico.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDiagnostico.Location = new System.Drawing.Point(9, 96);
            this.lblDiagnostico.Name = "lblDiagnostico";
            this.lblDiagnostico.Size = new System.Drawing.Size(175, 21);
            this.lblDiagnostico.TabIndex = 2;
            this.lblDiagnostico.Text = "Carregando Análise ...";
            // 
            // lblResumoTempo
            // 
            this.lblResumoTempo.AutoSize = true;
            this.lblResumoTempo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResumoTempo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblResumoTempo.Location = new System.Drawing.Point(10, 47);
            this.lblResumoTempo.Name = "lblResumoTempo";
            this.lblResumoTempo.Size = new System.Drawing.Size(94, 21);
            this.lblResumoTempo.TabIndex = 1;
            this.lblResumoTempo.Text = "Tempo total:";
            // 
            // lblTituloBoot
            // 
            this.lblTituloBoot.AutoSize = true;
            this.lblTituloBoot.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloBoot.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTituloBoot.Location = new System.Drawing.Point(9, 10);
            this.lblTituloBoot.Name = "lblTituloBoot";
            this.lblTituloBoot.Size = new System.Drawing.Size(78, 23);
            this.lblTituloBoot.TabIndex = 0;
            this.lblTituloBoot.Text = "Boot em";
            // 
            // chartBoot
            // 
            this.chartBoot.BackColor = System.Drawing.Color.Gainsboro;
            this.chartBoot.BorderlineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.Name = "ChartArea1";
            this.chartBoot.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartBoot.Legends.Add(legend1);
            this.chartBoot.Location = new System.Drawing.Point(0, 194);
            this.chartBoot.Name = "chartBoot";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartBoot.Series.Add(series1);
            this.chartBoot.Size = new System.Drawing.Size(799, 262);
            this.chartBoot.TabIndex = 4;
            this.chartBoot.Text = "chart1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAplicativos);
            this.tabControl1.Controls.Add(this.tabDrivers);
            this.tabControl1.Controls.Add(this.tabServicos);
            this.tabControl1.Location = new System.Drawing.Point(0, 462);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(799, 192);
            this.tabControl1.TabIndex = 5;
            // 
            // tabAplicativos
            // 
            this.tabAplicativos.Controls.Add(this.gridAplicativos);
            this.tabAplicativos.Location = new System.Drawing.Point(4, 22);
            this.tabAplicativos.Name = "tabAplicativos";
            this.tabAplicativos.Padding = new System.Windows.Forms.Padding(3);
            this.tabAplicativos.Size = new System.Drawing.Size(791, 166);
            this.tabAplicativos.TabIndex = 0;
            this.tabAplicativos.Text = "Aplicativos";
            this.tabAplicativos.UseVisualStyleBackColor = true;
            // 
            // gridAplicativos
            // 
            this.gridAplicativos.AllowUserToAddRows = false;
            this.gridAplicativos.AllowUserToDeleteRows = false;
            this.gridAplicativos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAplicativos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAplicativos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNomeAplicativo,
            this.colTempoAplicativo});
            this.gridAplicativos.Location = new System.Drawing.Point(0, 0);
            this.gridAplicativos.Name = "gridAplicativos";
            this.gridAplicativos.ReadOnly = true;
            this.gridAplicativos.RowHeadersVisible = false;
            this.gridAplicativos.Size = new System.Drawing.Size(791, 229);
            this.gridAplicativos.TabIndex = 0;
            // 
            // colNomeAplicativo
            // 
            this.colNomeAplicativo.HeaderText = "Nome";
            this.colNomeAplicativo.Name = "colNomeAplicativo";
            this.colNomeAplicativo.ReadOnly = true;
            // 
            // colTempoAplicativo
            // 
            this.colTempoAplicativo.HeaderText = "Tempo";
            this.colTempoAplicativo.Name = "colTempoAplicativo";
            this.colTempoAplicativo.ReadOnly = true;
            // 
            // tabDrivers
            // 
            this.tabDrivers.Controls.Add(this.gridDrivers);
            this.tabDrivers.Location = new System.Drawing.Point(4, 22);
            this.tabDrivers.Name = "tabDrivers";
            this.tabDrivers.Padding = new System.Windows.Forms.Padding(3);
            this.tabDrivers.Size = new System.Drawing.Size(791, 166);
            this.tabDrivers.TabIndex = 1;
            this.tabDrivers.Text = "Drivers";
            this.tabDrivers.UseVisualStyleBackColor = true;
            // 
            // gridDrivers
            // 
            this.gridDrivers.AllowUserToAddRows = false;
            this.gridDrivers.AllowUserToDeleteRows = false;
            this.gridDrivers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDrivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDrivers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNomeDriver,
            this.colTempoDriver});
            this.gridDrivers.Location = new System.Drawing.Point(0, 0);
            this.gridDrivers.Name = "gridDrivers";
            this.gridDrivers.ReadOnly = true;
            this.gridDrivers.RowHeadersVisible = false;
            this.gridDrivers.Size = new System.Drawing.Size(791, 229);
            this.gridDrivers.TabIndex = 0;
            // 
            // colNomeDriver
            // 
            this.colNomeDriver.HeaderText = "Nome";
            this.colNomeDriver.Name = "colNomeDriver";
            this.colNomeDriver.ReadOnly = true;
            // 
            // colTempoDriver
            // 
            this.colTempoDriver.HeaderText = "Tempo";
            this.colTempoDriver.Name = "colTempoDriver";
            this.colTempoDriver.ReadOnly = true;
            // 
            // tabServicos
            // 
            this.tabServicos.Controls.Add(this.gridServicos);
            this.tabServicos.Location = new System.Drawing.Point(4, 22);
            this.tabServicos.Name = "tabServicos";
            this.tabServicos.Padding = new System.Windows.Forms.Padding(3);
            this.tabServicos.Size = new System.Drawing.Size(791, 166);
            this.tabServicos.TabIndex = 2;
            this.tabServicos.Text = "Serviços";
            this.tabServicos.UseVisualStyleBackColor = true;
            // 
            // gridServicos
            // 
            this.gridServicos.AllowUserToAddRows = false;
            this.gridServicos.AllowUserToDeleteRows = false;
            this.gridServicos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridServicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridServicos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNomeServico,
            this.colTempoServico});
            this.gridServicos.Location = new System.Drawing.Point(0, 0);
            this.gridServicos.Name = "gridServicos";
            this.gridServicos.ReadOnly = true;
            this.gridServicos.RowHeadersVisible = false;
            this.gridServicos.Size = new System.Drawing.Size(791, 229);
            this.gridServicos.TabIndex = 0;
            // 
            // colNomeServico
            // 
            this.colNomeServico.HeaderText = "Nome";
            this.colNomeServico.Name = "colNomeServico";
            this.colNomeServico.ReadOnly = true;
            // 
            // colTempoServico
            // 
            this.colTempoServico.HeaderText = "Tempo";
            this.colTempoServico.Name = "colTempoServico";
            this.colTempoServico.ReadOnly = true;
            // 
            // AnalisarPerfBoot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(800, 652);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.chartBoot);
            this.Controls.Add(this.pnlResumo);
            this.Controls.Add(this.cmbBoots);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AnalisarPerfBoot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Análise Performance de Boot";
            this.pnlResumo.ResumeLayout(false);
            this.pnlResumo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBoot)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabAplicativos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAplicativos)).EndInit();
            this.tabDrivers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDrivers)).EndInit();
            this.tabServicos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridServicos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBoots;
        private System.Windows.Forms.Panel pnlResumo;
        private System.Windows.Forms.Label lblTituloBoot;
        private System.Windows.Forms.Label lblResumoTempo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBoot;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAplicativos;
        private System.Windows.Forms.TabPage tabDrivers;
        private System.Windows.Forms.TabPage tabServicos;
        private System.Windows.Forms.DataGridView gridAplicativos;
        private System.Windows.Forms.DataGridView gridDrivers;
        private System.Windows.Forms.DataGridView gridServicos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomeAplicativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTempoAplicativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomeDriver;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTempoDriver;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomeServico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTempoServico;
        private System.Windows.Forms.Label lblDiagnostico;
    }
}