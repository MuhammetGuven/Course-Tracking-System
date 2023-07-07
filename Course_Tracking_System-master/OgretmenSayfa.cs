using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeriYapilari;

namespace ders_takip_sistemi
{
    public partial class OgretmenSayfa : Form
    {
        public HashTable dersler;
        public OgrenciAVL ogrenciListe;
        public OgretimGorevlisiAVL ogretmenListe;
        OgretimGorevlisi seciliHoca;

        public OgretmenSayfa(HashTable dersler, OgrenciAVL ogrenciListe, OgretimGorevlisiAVL ogretmenListe, OgretimGorevlisi seciliHoca)
        {
            this.dersler = dersler;
            this.ogrenciListe = ogrenciListe;
            this.ogretmenListe = ogretmenListe;
            this.seciliHoca = seciliHoca;
            InitializeComponent();

            string[] adSoyad = seciliHoca.adi_soyad.Split(' ');


            label20.Text = adSoyad[0];
            label14.Text = adSoyad[adSoyad.Length-1];

            label29.Text = seciliHoca.ogretmen_id.ToString();

            label10.Text = seciliHoca.cinsiyet;

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

     
       
        private void button3_Click(object sender, EventArgs e)
        {
            AnaSayfa x= new AnaSayfa(dersler, ogrenciListe, ogretmenListe);
            x.Show();
            this.Hide();
        }

        private void label33_Click(object sender, EventArgs e)
        {
            OgretmenDersler d = new OgretmenDersler(dersler, ogrenciListe, ogretmenListe, seciliHoca);
            d.Show();
            this.Hide();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            OgretmenDersler ogretmenDersler = new OgretmenDersler(dersler, ogrenciListe, ogretmenListe, seciliHoca);
            ogretmenDersler.Show();
            this.Hide();
        }

        private void label47_Click(object sender, EventArgs e)
        {

        }

       

        private void panel5_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OgretmenDersler x = new OgretmenDersler(dersler, ogrenciListe, ogretmenListe, seciliHoca);
            x.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
