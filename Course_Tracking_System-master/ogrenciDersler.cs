using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using VeriYapilari;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ders_takip_sistemi
{
    public partial class ogrenciDersler : Form
    {
        public HashTable dersler;
        public OgrenciAVL ogrenciListe;
        public OgretimGorevlisiAVL ogretmenListe;
        Ogrenci seciliOgrenci;
        IkiYonluBagliListe liste = new IkiYonluBagliListe();
        public int sqlKapa = 0;
        public ogrenciDersler(HashTable dersler, OgrenciAVL ogrenciListe, OgretimGorevlisiAVL ogretmenListe, Ogrenci seciliOgrenci)
        {
            this.dersler = dersler;
            this.ogrenciListe = ogrenciListe;
            this.ogretmenListe = ogretmenListe;
            this.seciliOgrenci = seciliOgrenci;
            InitializeComponent();

            

            Liste uygunDersler = dersler.ListBul(seciliOgrenci.donem);

            label1.Text = seciliOgrenci.adi_soyad;

            for (int i = 0; i < uygunDersler.kapasite; i++)
            {
                
                

                dataGridView1.Rows.Add(false, uygunDersler.dersListe[i].ders_id, uygunDersler.dersListe[i].ders_adi.ToString(), uygunDersler.dersListe[i].ders_kredi, uygunDersler.dersListe[i].gun_id.ToString(), uygunDersler.dersListe[i].saat_id.ToString(), (uygunDersler.dersListe[i].donem_id % 10).ToString(), uygunDersler.dersListe[i].ders_turu.ToString(), ogretmenListe.FindGorevliID(uygunDersler.dersListe[i].ogretmen_id).OgretimGorevlisi.adi_soyad.ToString());
            }

            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            

            void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            {
                
                if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                    DataGridViewCheckBoxCell checkBoxCell = dataGridView1.Rows[e.RowIndex].Cells[0] as DataGridViewCheckBoxCell;
                    bool isChecked = (bool)checkBoxCell.Value;
                    int satir = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);


                    if (isChecked)
                    {
                        if (!liste.GunVeSaatCakisiyorMu(dersler.HashBul(seciliOgrenci.donem, satir).gun_id, dersler.HashBul(seciliOgrenci.donem, satir).saat_id))
                        {
                            liste.Ekle(dersler.HashBul(seciliOgrenci.donem, satir));
                            MessageBox.Show("Satır işaretlendi! Değer: " + satir);
                        }

                        else
                        {
                            checkBoxCell.Value = false;
                            MessageBox.Show("Dersler Çakışıyor!");
                        }
                    }
                    else
                    { 
                        liste.Sil(satir);
                        MessageBox.Show("Satır işaret kaldırıldı!");
                    }

                    

                }
            }


            string connString = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=12345;";
            NpgsqlConnection conn = new NpgsqlConnection(connString);
            conn.Open();
            string sql = "SELECT * FROM donemdersleri";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            int ogrenciId;
            int dersId;
            Ders secilenDers;


            while (reader.Read())
            {
                
                ogrenciId = reader.GetInt32(0);

                if (seciliOgrenci.ogrenci_id == ogrenciId)
                {
                    dersId = reader.GetInt32(1);

                    secilenDers = dersler.HashBul(seciliOgrenci.donem, dersId);
                    dataGridView2.Rows.Add(secilenDers.ders_id, secilenDers.ders_adi, secilenDers.ders_kredi, secilenDers.gun_id, secilenDers.saat_id, secilenDers.donem_id, secilenDers.ders_turu, secilenDers.ogretmen_id);
                }
                
            }

            reader.Close();
            conn.Close();




        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OgrenciSayfa x= new OgrenciSayfa(dersler, ogrenciListe, ogretmenListe, seciliOgrenci);
            x.Show();
            this.Hide();
        }

  

        private void button3_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa(dersler, ogrenciListe, ogretmenListe);
            anaSayfa.Show();
            this.Hide();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ogrenciDersler_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (liste.ToplamKredi() < 30)
            {
                string connString = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=12345;";
                NpgsqlConnection conn = new NpgsqlConnection(connString);

                conn.Open();
                string SqlQuery = "DELETE FROM donemdersleri WHERE ogrenci_id=@ogrenci_id";
                NpgsqlCommand command = new NpgsqlCommand(SqlQuery, conn);
                command.Parameters.AddWithValue("@ogrenci_id", seciliOgrenci.ogrenci_id);
                command.ExecuteNonQuery();

                NpgsqlConnection connection = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=12345;");
                conn.Close();
                connection.Open();

                while(liste.baslangic != null)
                {
                    string SqlQuery2 = "INSERT INTO donemdersleri (ogrenci_id, ders_id, donem_id) VALUES (@ogrenciId, @dersId, @donemId)";
                    NpgsqlCommand command2 = new NpgsqlCommand(SqlQuery2, connection);
                    command2.Parameters.AddWithValue("@ogrenciId", seciliOgrenci.ogrenci_id);
                    command2.Parameters.AddWithValue("@dersId", liste.baslangic.ders_id);
                    command2.Parameters.AddWithValue("@donemId", liste.baslangic.donem_id);
                    command2.ExecuteNonQuery();

                    liste.baslangic = liste.baslangic.sonraki;
                }

                connection.Close();
                ogrenciDersler ogrenciDersler = new ogrenciDersler(dersler, ogrenciListe, ogretmenListe, seciliOgrenci);
                ogrenciDersler.Show();
                this.Hide();

            }

            else
            {
                MessageBox.Show("Kredinizi aştınız!");
            }


            


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
