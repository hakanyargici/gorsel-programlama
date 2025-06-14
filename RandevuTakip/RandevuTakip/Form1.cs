using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RandevuTakip
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RandevuTakipDB;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();

            cmbHizmet.Items.Add("Saç Kesimi");
            cmbHizmet.Items.Add("Cilt Bakımı");
            cmbHizmet.Items.Add("Masaj");

            btnKaydet.Click += BtnKaydet_Click;

            LoadRandevular();
        }

        private void LoadRandevular()
        {
            lstKayitlar.Items.Clear();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT AdSoyad, Hizmet, Tarih, Saat FROM Randevular ORDER BY Tarih";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string kayit = $"{reader["AdSoyad"]} - {reader["Hizmet"]} - {Convert.ToDateTime(reader["Tarih"]).ToShortDateString()} - {reader["Saat"]}";
                    lstKayitlar.Items.Add(kayit);
                }
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            string ad = txtAdSoyad.Text.Trim();
            string hizmet = cmbHizmet.Text;
            string saat = txtSaat.Text;
            DateTime tarih = dtpTarih.Value;

            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(hizmet) || string.IsNullOrEmpty(saat))
            {
                lblDurum.Text = "Lütfen tüm alanları doldurun.";
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string insertQuery = "INSERT INTO Randevular (AdSoyad, Hizmet, Tarih, Saat) VALUES (@ad, @hizmet, @tarih, @saat)";
                SqlCommand cmd = new SqlCommand(insertQuery, con);

                cmd.Parameters.AddWithValue("@ad", ad);
                cmd.Parameters.AddWithValue("@hizmet", hizmet);
                cmd.Parameters.AddWithValue("@tarih", tarih);
                cmd.Parameters.AddWithValue("@saat", saat);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            lblDurum.Text = "Randevu başarıyla kaydedildi.";
            LoadRandevular();

            txtAdSoyad.Text = "";
            cmbHizmet.SelectedIndex = -1;
            txtSaat.Text = "";
            dtpTarih.Value = DateTime.Now;
        }
    }
}
