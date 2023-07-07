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
    public partial class duyurular : Form
    {
        public HashTable dersler;
        public OgrenciAVL ogrenciListe;
        public OgretimGorevlisiAVL ogretmenListe;

        public duyurular(HashTable dersler, OgrenciAVL ogrenciListe, OgretimGorevlisiAVL ogretmenListe)
        {
            this.dersler = dersler;
            this.ogrenciListe = ogrenciListe;
            this.ogretmenListe = ogretmenListe;
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            etkinlikler c = new etkinlikler(dersler, ogrenciListe, ogretmenListe);
            c.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AnaSayfa v = new AnaSayfa(dersler, ogrenciListe, ogretmenListe);
            v.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Giris s = new Giris(dersler, ogrenciListe, ogretmenListe);
            s.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Red;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Black;
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            label7.ForeColor = Color.Red;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.ForeColor = Color.Black;
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Red;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Black;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            hakkinda x = new hakkinda(dersler, ogrenciListe, ogretmenListe);
            x.Show();
            this.Hide();
        }
    }
}
