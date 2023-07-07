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
    public partial class hakkinda : Form
    {
        public HashTable dersler;
        public OgrenciAVL ogrenciListe;
        public OgretimGorevlisiAVL ogretmenListe;

        public hakkinda(HashTable dersler, OgrenciAVL ogrenciListe, OgretimGorevlisiAVL ogretmenListe)
        {
            this.dersler = dersler;
            this.ogrenciListe = ogrenciListe;
            this.ogretmenListe = ogretmenListe;
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            duyurular x = new duyurular(dersler, ogrenciListe, ogretmenListe);
            x.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            etkinlikler x = new etkinlikler(dersler, ogrenciListe, ogretmenListe);
            x.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa(dersler, ogrenciListe, ogretmenListe);
            anaSayfa.Show();
            this.Hide();
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            label7.ForeColor = Color.Red;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.ForeColor = Color.Black;
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Red;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Black;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Red;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris(dersler, ogrenciListe, ogretmenListe);  
            giris.Show();
            this.Hide();
        }
    }
}
