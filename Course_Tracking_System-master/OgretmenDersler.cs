using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using VeriYapilari;

namespace ders_takip_sistemi
{
    public partial class OgretmenDersler : Form
    {
        public HashTable dersler;
        public OgrenciAVL ogrenciListe;
        public OgretimGorevlisiAVL ogretmenListe;
        OgretimGorevlisi seciliHoca;

        public OgretmenDersler(HashTable dersler, OgrenciAVL ogrenciListe, OgretimGorevlisiAVL ogretmenListe, OgretimGorevlisi seciliHoca)
        {
            this.dersler = dersler;
            this.ogrenciListe = ogrenciListe;
            this.ogretmenListe = ogretmenListe;
            this.seciliHoca = seciliHoca;
            InitializeComponent();

            label1.Text = seciliHoca.adi_soyad;

            int sayi;
            int[] idListesi = new int[10];
            int kapasite = 0;

            for (int i = 0; i < dersler.hkapasite; i++)
            {
                Console.WriteLine("Liste0 " + i);
                sayi = dersler.liste1[i].kapasite;
                Ders seciliDers;
                string donem = "";
             


                for (int j = 0; j < sayi; j++)
                {
                    Console.WriteLine("Liste1 "+ j);
                    if (dersler.liste1[i].dersListe[j].ogretmen_id == seciliHoca.ogretmen_id)
                    {
                        Console.WriteLine("Liste2 " + j);
                        seciliDers = dersler.liste1[i].dersListe[j];

                        if (seciliDers.donem_id/10 == 1)
                        {
                            donem = "Yüksek Lisans ";
                        }

                        else if (seciliDers.donem_id/10 == 2)
                        {
                            donem = "Doktora ";
                        }

                        dataGridView1.Rows.Add( donem + (seciliDers.donem_id%10).ToString(), seciliDers.ders_id.ToString(), seciliDers.ders_adi.ToString(), seciliDers.gun_id.ToString(), seciliDers.saat_id.ToString(), seciliDers.ogretmen_id.ToString());
                        idListesi[kapasite] = seciliDers.ders_id;
                        kapasite ++;
                    }

                }



            }

            
                string connString = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=12345;";
                NpgsqlConnection conn = new NpgsqlConnection(connString);
                conn.Open();
                string sql = "SELECT * FROM donemdersleri";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader reader = cmd.ExecuteReader();

                int ogrenciId, dersId2, donemId;
                Ogrenci bulunan;
                string donem2 = "";

                while (reader.Read())
                {  
                    ogrenciId = reader.GetInt32(0);
                    dersId2 = reader.GetInt32(1);
                    donemId = reader.GetInt32(2);

                    if (idListesi.Contains(dersId2))
                    {

                        if(donemId / 10 == 1)
                        {
                            donem2 = "Yüksek Lisans ";
                        }

                        else if (donemId / 10 == 2)
                        {
                            donem2 = "Doktora ";
                        }

                        bulunan = ogrenciListe.FindOgrenciID(ogrenciId).Ogrenci;
                        dataGridView2.Rows.Add(bulunan.adi_soyad.ToString(), dersId2.ToString(), donem2 + (donemId % 10).ToString());

                    }




                }

                reader.Close();
                conn.Close();




        }

        private void button4_Click(object sender, EventArgs e)
        {
            OgretmenSayfa v = new OgretmenSayfa(dersler, ogrenciListe, ogretmenListe, seciliHoca);
            v.Show();
            this.Hide();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa(dersler, ogrenciListe, ogretmenListe);
            anaSayfa.Show();
                
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
