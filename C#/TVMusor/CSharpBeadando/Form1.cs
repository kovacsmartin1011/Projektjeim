using CSharpBeadando.model;
using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CSharpBeadando
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\musorok.mdf;Integrated Security=True;Connect Timeout=30";
        public Form1()
        {
            InitializeComponent();
            KategoriakBetoltese();
            LoadComboboxData();
            LoadCombobox2Data();
            dateTimePicker.Value = DateTime.Today;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Show();
            //1. feladat
            cmbListak.Hide();
            txtCsatornaNev.Hide();
            btnCsatornaHozzaadas.Hide();

            //2. feladat
            listBoxKategoriak.Hide();
            btnKategoriaHozzaadas.Hide();
            btnKategoriaTorles.Hide();
            btnKategoriaModositas.Hide();
            txtKategoriaNev.Hide();

            //3. feladat
            dateTimePicker.Hide();
            btnSzures.Hide();
            btnExportXML.Hide();
            comboBoxCsatorna.Hide();
            comboBoxKategoriak.Hide();
            dataGridViewMusorok.Hide();

            //4. feladat
            chartStatistics.Hide();

            List<string> csatornaNevek = GetCsatornaNevekFromDatabase();

            foreach (string nev in csatornaNevek)
            {
                cmbListak.Items.Add(nev);
                LoadComboboxData();
            }
        }

        private void LoadComboboxData()
        {
            comboBoxCsatorna.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Azonosito, Nev FROM Csatornak";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string nev = reader.GetString(1);
                        comboBoxCsatorna.Items.Add(nev);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba történt az adatbázisból való betöltés során: " + ex.Message);
                }
            }

            comboBoxCsatorna.DisplayMember = "Nev";
            comboBoxCsatorna.ValueMember = "Azonosito";
        }

        private void LoadCombobox2Data()
        {
            comboBoxKategoriak.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Azonosito, Megnevezes FROM Kategoriak";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string nev = reader.GetString(1);
                        comboBoxKategoriak.Items.Add(nev);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba történt az adatbázisból való betöltés során: " + ex.Message);
                }
            }
        }

        private List<string> GetCsatornaNevekFromDatabase()
        {
            List<string> csatornaNevek = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Nev FROM Csatornak";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string nev = reader.GetString(0);
                        csatornaNevek.Add(nev);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba történt az adatbázis lekérdezése során: " + ex.Message);
                }
            }

            return csatornaNevek;
        }

        private void btnCsatornaHozzaadas_Click(object sender, EventArgs e)
        {
            string csatornaNev = txtCsatornaNev.Text;
            string listaNev = cmbListak.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Kedvencek (CsatornaNev, ListaNev) VALUES (@CsatornaNev, @ListaNev)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CsatornaNev", csatornaNev);
                command.Parameters.AddWithValue("@ListaNev", listaNev);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show($"{rowsAffected} sor hozzáadva.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba történt az adatbázisba történő beszúrás közben: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chartStatistics.Hide();
            listBoxKategoriak.Hide();
            btnKategoriaHozzaadas.Hide();
            btnKategoriaTorles.Hide();
            btnKategoriaModositas.Hide();
            txtKategoriaNev.Hide();
            dateTimePicker.Hide();
            btnSzures.Hide();
            btnExportXML.Hide();
            comboBoxCsatorna.Hide();
            comboBoxKategoriak.Hide();
            dataGridViewMusorok.Hide();
            cmbListak.Show();
            txtCsatornaNev.Show();
            btnCsatornaHozzaadas.Show();
        }

        private void KategoriakBetoltese()
        {
            listBoxKategoriak.Items.Clear();

            using (SqlConnection kapcsolat = new SqlConnection(connectionString))
            {
                string lekerdezes = "SELECT Megnevezes FROM Kategoriak";
                SqlCommand parancs = new SqlCommand(lekerdezes, kapcsolat);

                try
                {
                    kapcsolat.Open();
                    SqlDataReader olvaso = parancs.ExecuteReader();
                    while (olvaso.Read())
                    {
                        string megnevezes = olvaso.GetString(0);
                        listBoxKategoriak.Items.Add(megnevezes);
                    }
                    olvaso.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba tortent az adatbazis lekerdezes soran: " + ex.Message);
                }
            }
        }

        private void btnKategoriaHozzaadas_Click(object sender, EventArgs e)
        {
            string kategoria = txtKategoriaNev.Text;

            if (kategoria.Length < 3)
            {
                MessageBox.Show("A kategórianévnek legalább három karakter hosszúnak kell lennie!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection kapcsolat = new SqlConnection(connectionString))
            {
                string lekerdezes = "INSERT INTO Kategoriak (Megnevezes) VALUES (@Megnevezes)";
                SqlCommand parancs = new SqlCommand(lekerdezes, kapcsolat);
                parancs.Parameters.AddWithValue("@Megnevezes", kategoria);

                try
                {
                    kapcsolat.Open();
                    int erintettSorok = parancs.ExecuteNonQuery();
                    MessageBox.Show($"{erintettSorok} kategoria hozzaadva.");
                    KategoriakBetoltese();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba tortent az adatbazisba torteno beszuras kozben: " + ex.Message);
                }
            }
        }

        private void btnKategoriaTorles_Click(object sender, EventArgs e)
        {
            string kategoria = listBoxKategoriak.SelectedItem?.ToString();

            if (kategoria != null)
            {
                if (MessageBox.Show($"Biztosan torolni szeretned a(z) '{kategoria}' kategoriat?", "Kategoria torlese", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection kapcsolat = new SqlConnection(connectionString))
                    {
                        string lekerdezes = "DELETE FROM Kategoriak WHERE Megnevezes = @Megnevezes";
                        SqlCommand parancs = new SqlCommand(lekerdezes, kapcsolat);
                        parancs.Parameters.AddWithValue("@Megnevezes", kategoria);

                        try
                        {
                            kapcsolat.Open();
                            int erintettSorok = parancs.ExecuteNonQuery();
                            MessageBox.Show($"{erintettSorok} kategoria torolve.");
                            KategoriakBetoltese();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hiba tortent az adatbazisbol torteno torles soran: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Valassz ki egy kategoriat a torleshez.", "Nincs kivalasztott kategoria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnKategoriaModositas_Click(object sender, EventArgs e)
        {
            string kivalasztottKategoria = listBoxKategoriak.SelectedItem?.ToString();
            string modositottKategoria = txtKategoriaNev.Text;

            if (!string.IsNullOrWhiteSpace(kivalasztottKategoria) && !string.IsNullOrWhiteSpace(modositottKategoria))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Kategoriak SET Megnevezes = @ModositottKategoria WHERE Megnevezes = @KivalasztottKategoria";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ModositottKategoria", modositottKategoria);
                    command.Parameters.AddWithValue("@KivalasztottKategoria", kivalasztottKategoria);

                    try
                    {
                        connection.Open();
                        MessageBox.Show($"Kategória sikeresen módosítva.", "Sikeres módosítás", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        KategoriakBetoltese();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hiba történt az adatbázisban történő módosítás során: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Válassz ki egy kategóriát és adj meg egy módosított nevet a módosításhoz.", "Hiányzó adat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MusorokBetoltese()
        {
            DateTime kivalasztottDatum = dateTimePicker.Value.Date;
            int kivalasztottCsatornaId = 4;

            using (SqlConnection kapcsolat = new SqlConnection(connectionString))
            {
                string lekerdezes = @"
            SELECT M.Cim, M.KezdetiIdopont, M.Hossz, K.Megnevezes AS Kategoria
            FROM Musorok M
            JOIN Csatornak C ON M.CsatornaAzonosito = C.Azonosito
            JOIN Kategoriak K ON M.KategoriaAzonosito = K.Azonosito
            WHERE C.Azonosito = @CsatornaAzonosito AND CONVERT(date, M.KezdetiIdopont) = @Datum";

                if (!string.IsNullOrWhiteSpace(comboBoxKategoriak.Text))
                {
                    lekerdezes += " AND K.Azonosito = @KategoriaAzonosito";
                }

                SqlCommand parancs = new SqlCommand(lekerdezes, kapcsolat);
                parancs.Parameters.AddWithValue("@CsatornaAzonosito", kivalasztottCsatornaId);
                parancs.Parameters.AddWithValue("@Datum", kivalasztottDatum);

                if (!string.IsNullOrWhiteSpace(comboBoxKategoriak.Text))
                {
                    parancs.Parameters.AddWithValue("@KategoriaAzonosito", comboBoxKategoriak.SelectedValue);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(parancs);
                DataTable adatTabla = new DataTable();
                adapter.Fill(adatTabla);
                dataGridViewMusorok.DataSource = adatTabla;
            }
        }

        private void btnExportXML_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridViewMusorok.DataSource;
            if (dt != null)
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "XML|*.xml" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        dt.WriteXml(sfd.FileName);
                    }
                }
            }
        }

        private void btnSzures_Click(object sender, EventArgs e)
        {
            MusorokBetoltese();
        }

        private void Kategoria_Click(object sender, EventArgs e)
        {
            chartStatistics.Hide();
            cmbListak.Hide();
            txtCsatornaNev.Hide();
            btnCsatornaHozzaadas.Hide();
            dateTimePicker.Hide();
            btnSzures.Hide();
            btnExportXML.Hide();
            comboBoxCsatorna.Hide();
            comboBoxKategoriak.Hide();
            dataGridViewMusorok.Hide();
            listBoxKategoriak.Show();
            btnKategoriaHozzaadas.Show();
            btnKategoriaTorles.Show();
            btnKategoriaModositas.Show();
            txtKategoriaNev.Show();
        }

        private void Listazas_Click(object sender, EventArgs e)
        {
            chartStatistics.Hide();
            cmbListak.Hide();
            txtCsatornaNev.Hide();
            btnCsatornaHozzaadas.Hide();
            listBoxKategoriak.Hide();
            btnKategoriaHozzaadas.Hide();
            btnKategoriaTorles.Hide();
            btnKategoriaModositas.Hide();
            txtKategoriaNev.Hide();
            dateTimePicker.Show();
            btnSzures.Show();
            btnExportXML.Show();
            comboBoxCsatorna.Show();
            comboBoxKategoriak.Show();
            dataGridViewMusorok.Show();
        }

        private DataTable GetProgramStatistics(DateTime date)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT " +
                               "CASE WHEN DATEPART(dw, KezdetiIdopont) IN (1, 7) THEN 'Hétvége' ELSE 'Hétköznap' END AS Nap, " +
                               "K.Megnevezes AS Kategoria, " +
                               "COUNT(*) AS Mennyiseg " +
                               "FROM Musorok M " +
                               "JOIN Kategoriak K ON M.KategoriaAzonosito = K.Azonosito " +
                               "WHERE CONVERT(date, KezdetiIdopont) = @Datum " +
                               "GROUP BY CASE WHEN DATEPART(dw, KezdetiIdopont) IN (1, 7) THEN 'Hétvége' ELSE 'Hétköznap' END, K.Megnevezes";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Datum", date.Date);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }
            return dataTable;
        }

        private void ShowStatisticsChart(DataTable statisticsData)
        {
            chartStatistics.Series.Clear();
            chartStatistics.Titles.Clear();
            chartStatistics.Titles.Add("Műsorok kategóriák szerint");

            foreach (DataRow row in statisticsData.Rows)
            {
                string kategoria = row["Kategoria"].ToString();
                int db = Convert.ToInt32(row["Mennyiseg"]);
                chartStatistics.Series.Add(kategoria);
                chartStatistics.Series[kategoria].Points.AddXY(kategoria, db);
            }

            if (chartStatistics.Series.Count == 0)
            {
                chartStatistics.Series.Add("Kategoria");
            }

            chartStatistics.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartStatistics.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartStatistics.Series[0].ChartType = SeriesChartType.Pie;
            chartStatistics.Legends[0].Enabled = true;
        }
        private void btnCreateStatistics_Click(object sender, EventArgs e)
        {
            chartStatistics.Show();
            DateTime selectedDate = dateTimePicker.Value;
            DataTable statisticsData = GetProgramStatistics(selectedDate);
            ShowStatisticsChart(statisticsData);
        }
    }
}