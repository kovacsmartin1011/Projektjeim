namespace CSharpBeadando
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            btnCsatornaHozzaadas = new Button();
            btnKategoriaHozzaadas = new Button();
            txtCsatornaNev = new TextBox();
            cmbListak = new ComboBox();
            Kedvenc = new Button();
            btnKategoriaTorles = new Button();
            btnKategoriaModositas = new Button();
            txtKategoriaNev = new TextBox();
            listBoxKategoriak = new ListBox();
            btnExportXML = new Button();
            btnSzures = new Button();
            dateTimePicker = new DateTimePicker();
            comboBoxCsatorna = new ComboBox();
            comboBoxKategoriak = new ComboBox();
            dataGridViewMusorok = new DataGridView();
            Kategoria = new Button();
            Listazas = new Button();
            btnCreateStatistics = new Button();
            panel1 = new Panel();
            chartStatistics = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMusorok).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartStatistics).BeginInit();
            SuspendLayout();
            // 
            // btnCsatornaHozzaadas
            // 
            btnCsatornaHozzaadas.Location = new Point(189, 121);
            btnCsatornaHozzaadas.Name = "btnCsatornaHozzaadas";
            btnCsatornaHozzaadas.Size = new Size(121, 35);
            btnCsatornaHozzaadas.TabIndex = 0;
            btnCsatornaHozzaadas.Text = "Csatorna Hozzaadas";
            btnCsatornaHozzaadas.UseVisualStyleBackColor = true;
            btnCsatornaHozzaadas.Click += btnCsatornaHozzaadas_Click;
            // 
            // btnKategoriaHozzaadas
            // 
            btnKategoriaHozzaadas.Location = new Point(401, 66);
            btnKategoriaHozzaadas.Name = "btnKategoriaHozzaadas";
            btnKategoriaHozzaadas.Size = new Size(75, 23);
            btnKategoriaHozzaadas.TabIndex = 1;
            btnKategoriaHozzaadas.Text = "Hozzáad";
            btnKategoriaHozzaadas.UseVisualStyleBackColor = true;
            btnKategoriaHozzaadas.Click += btnKategoriaHozzaadas_Click;
            // 
            // txtCsatornaNev
            // 
            txtCsatornaNev.Location = new Point(189, 92);
            txtCsatornaNev.Name = "txtCsatornaNev";
            txtCsatornaNev.Size = new Size(100, 23);
            txtCsatornaNev.TabIndex = 2;
            // 
            // cmbListak
            // 
            cmbListak.FormattingEnabled = true;
            cmbListak.Location = new Point(189, 63);
            cmbListak.Name = "cmbListak";
            cmbListak.Size = new Size(121, 23);
            cmbListak.TabIndex = 3;
            // 
            // Kedvenc
            // 
            Kedvenc.Location = new Point(12, 38);
            Kedvenc.Name = "Kedvenc";
            Kedvenc.Size = new Size(112, 32);
            Kedvenc.TabIndex = 5;
            Kedvenc.Text = "Kedvenc";
            Kedvenc.UseVisualStyleBackColor = true;
            Kedvenc.Click += button1_Click;
            // 
            // btnKategoriaTorles
            // 
            btnKategoriaTorles.Location = new Point(401, 97);
            btnKategoriaTorles.Name = "btnKategoriaTorles";
            btnKategoriaTorles.Size = new Size(75, 23);
            btnKategoriaTorles.TabIndex = 6;
            btnKategoriaTorles.Text = "Törlés";
            btnKategoriaTorles.UseVisualStyleBackColor = true;
            btnKategoriaTorles.Click += btnKategoriaTorles_Click;
            // 
            // btnKategoriaModositas
            // 
            btnKategoriaModositas.Location = new Point(401, 133);
            btnKategoriaModositas.Name = "btnKategoriaModositas";
            btnKategoriaModositas.Size = new Size(75, 23);
            btnKategoriaModositas.TabIndex = 7;
            btnKategoriaModositas.Text = "Módosítás";
            btnKategoriaModositas.UseVisualStyleBackColor = true;
            btnKategoriaModositas.Click += btnKategoriaModositas_Click;
            // 
            // txtKategoriaNev
            // 
            txtKategoriaNev.Location = new Point(188, 28);
            txtKategoriaNev.Name = "txtKategoriaNev";
            txtKategoriaNev.PlaceholderText = "Kategória név";
            txtKategoriaNev.Size = new Size(194, 23);
            txtKategoriaNev.TabIndex = 8;
            // 
            // listBoxKategoriak
            // 
            listBoxKategoriak.FormattingEnabled = true;
            listBoxKategoriak.ItemHeight = 15;
            listBoxKategoriak.Location = new Point(188, 57);
            listBoxKategoriak.Name = "listBoxKategoriak";
            listBoxKategoriak.Size = new Size(194, 109);
            listBoxKategoriak.TabIndex = 9;
            // 
            // btnExportXML
            // 
            btnExportXML.Location = new Point(178, 144);
            btnExportXML.Name = "btnExportXML";
            btnExportXML.Size = new Size(102, 36);
            btnExportXML.TabIndex = 10;
            btnExportXML.Text = "XML";
            btnExportXML.UseVisualStyleBackColor = true;
            btnExportXML.Click += btnExportXML_Click;
            // 
            // btnSzures
            // 
            btnSzures.Location = new Point(178, 102);
            btnSzures.Name = "btnSzures";
            btnSzures.Size = new Size(102, 36);
            btnSzures.TabIndex = 11;
            btnSzures.Text = "Szűrés";
            btnSzures.UseVisualStyleBackColor = true;
            btnSzures.Click += btnSzures_Click;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(209, 57);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(209, 23);
            dateTimePicker.TabIndex = 12;
            // 
            // comboBoxCsatorna
            // 
            comboBoxCsatorna.FormattingEnabled = true;
            comboBoxCsatorna.Location = new Point(297, 102);
            comboBoxCsatorna.Name = "comboBoxCsatorna";
            comboBoxCsatorna.Size = new Size(121, 23);
            comboBoxCsatorna.TabIndex = 13;
            // 
            // comboBoxKategoriak
            // 
            comboBoxKategoriak.FormattingEnabled = true;
            comboBoxKategoriak.Location = new Point(297, 152);
            comboBoxKategoriak.Name = "comboBoxKategoriak";
            comboBoxKategoriak.Size = new Size(121, 23);
            comboBoxKategoriak.TabIndex = 14;
            // 
            // dataGridViewMusorok
            // 
            dataGridViewMusorok.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMusorok.GridColor = SystemColors.MenuHighlight;
            dataGridViewMusorok.Location = new Point(164, 204);
            dataGridViewMusorok.Name = "dataGridViewMusorok";
            dataGridViewMusorok.Size = new Size(398, 202);
            dataGridViewMusorok.TabIndex = 15;
            // 
            // Kategoria
            // 
            Kategoria.Location = new Point(12, 92);
            Kategoria.Name = "Kategoria";
            Kategoria.Size = new Size(112, 32);
            Kategoria.TabIndex = 16;
            Kategoria.Text = "Kategória";
            Kategoria.UseVisualStyleBackColor = true;
            Kategoria.Click += Kategoria_Click;
            // 
            // Listazas
            // 
            Listazas.Location = new Point(12, 152);
            Listazas.Name = "Listazas";
            Listazas.Size = new Size(112, 32);
            Listazas.TabIndex = 17;
            Listazas.Text = "Listázás";
            Listazas.UseVisualStyleBackColor = true;
            Listazas.Click += Listazas_Click;
            // 
            // btnCreateStatistics
            // 
            btnCreateStatistics.Location = new Point(12, 213);
            btnCreateStatistics.Name = "btnCreateStatistics";
            btnCreateStatistics.Size = new Size(112, 32);
            btnCreateStatistics.TabIndex = 18;
            btnCreateStatistics.Text = "Diagram";
            btnCreateStatistics.UseVisualStyleBackColor = true;
            btnCreateStatistics.Click += btnCreateStatistics_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(btnCreateStatistics);
            panel1.Controls.Add(Kedvenc);
            panel1.Controls.Add(Listazas);
            panel1.Controls.Add(Kategoria);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(140, 448);
            panel1.TabIndex = 19;
            // 
            // chartStatistics
            // 
            chartArea1.Name = "ChartArea1";
            chartStatistics.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartStatistics.Legends.Add(legend1);
            chartStatistics.Location = new Point(160, 28);
            chartStatistics.Name = "chartStatistics";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartStatistics.Series.Add(series1);
            chartStatistics.Size = new Size(402, 396);
            chartStatistics.TabIndex = 19;
            chartStatistics.Text = "chart1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(576, 447);
            Controls.Add(chartStatistics);
            Controls.Add(panel1);
            Controls.Add(dataGridViewMusorok);
            Controls.Add(comboBoxKategoriak);
            Controls.Add(comboBoxCsatorna);
            Controls.Add(dateTimePicker);
            Controls.Add(btnSzures);
            Controls.Add(btnExportXML);
            Controls.Add(listBoxKategoriak);
            Controls.Add(txtKategoriaNev);
            Controls.Add(btnKategoriaModositas);
            Controls.Add(btnKategoriaTorles);
            Controls.Add(cmbListak);
            Controls.Add(txtCsatornaNev);
            Controls.Add(btnKategoriaHozzaadas);
            Controls.Add(btnCsatornaHozzaadas);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TV Műsorok";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewMusorok).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartStatistics).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCsatornaHozzaadas;
        private Button btnKategoriaHozzaadas;
        private TextBox txtCsatornaNev;
        private ComboBox cmbListak;
        private Button Kedvenc;
        private Button btnKategoriaTorles;
        private Button btnKategoriaModositas;
        private TextBox txtKategoriaNev;
        private ListBox listBoxKategoriak;
        private Button btnExportXML;
        private Button btnSzures;
        private DateTimePicker dateTimePicker;
        private ComboBox comboBoxCsatorna;
        private ComboBox comboBoxKategoriak;
        private DataGridView dataGridViewMusorok;
        private Button Kategoria;
        private Button Listazas;
        private Button btnCreateStatistics;
        private Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStatistics;
    }
}
