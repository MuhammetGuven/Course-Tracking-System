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
    public partial class OgrenciSayfa : Form
    {
        public HashTable dersler;
        public OgrenciAVL ogrenciListe;
        public OgretimGorevlisiAVL ogretmenListe;
        Ogrenci seciliOgrenci;

        public OgrenciSayfa(HashTable dersler, OgrenciAVL ogrenciListe, OgretimGorevlisiAVL ogretmenListe, Ogrenci seciliOgrenci)
        {
            this.dersler = dersler;
            this.ogrenciListe = ogrenciListe;
            this.ogretmenListe = ogretmenListe;
            this.seciliOgrenci = seciliOgrenci;
            InitializeComponent();
            string[] adSoyad = seciliOgrenci.adi_soyad.Split(' ');

            label1.Text  =  seciliOgrenci.adi_soyad;
           
        
            label5.Text = adSoyad[0];
            label11.Text = adSoyad[adSoyad.Length-1];

            label13.Text = seciliOgrenci.cinsiyet;
            label7.Text = seciliOgrenci.bolum;

            label29.Text = seciliOgrenci.ogrenci_id.ToString();
            
            string donem = seciliOgrenci.donem.ToString();

            int donemToplam = (int)donem[1] - '0';
            label9.Text = donemToplam.ToString();
            

            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void OgrenciSayfa_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {
            ogrenciDersler ogrenciDersler = new ogrenciDersler(dersler, ogrenciListe, ogretmenListe, seciliOgrenci);
            ogrenciDersler.Show();
            this.Hide();

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label47_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa(dersler, ogrenciListe, ogretmenListe);
            anaSayfa.Show();
            this.Hide();
        }

        
        private void panel4_Click(object sender, EventArgs e)
        {
            ogrenciDersler ogrenciDersler   = new ogrenciDersler(dersler, ogrenciListe, ogretmenListe, seciliOgrenci);
            ogrenciDersler.Show();
            this.Hide();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            ogrenciDersler ogrenciDersler = new ogrenciDersler(dersler, ogrenciListe, ogretmenListe, seciliOgrenci);
            ogrenciDersler.Show();
            this.Hide();
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            ogrenciDersler ogrenciDersler = new ogrenciDersler(dersler, ogrenciListe, ogretmenListe, seciliOgrenci);
            ogrenciDersler.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
