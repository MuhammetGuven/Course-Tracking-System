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
    public partial class AnaSayfa : Form
    {
        public HashTable dersler;
        public OgrenciAVL ogrenciListe;
        public OgretimGorevlisiAVL ogretmenListe;

        public AnaSayfa(HashTable dersler, OgrenciAVL ogrenciListe, OgretimGorevlisiAVL ogretmenListe)
        {
            this.dersler = dersler;
            this.ogrenciListe = ogrenciListe;
            this.ogretmenListe = ogretmenListe;
            InitializeComponent();
        }

        
        private void label6_Click(object sender, EventArgs e)
        {
            duyurular x = new duyurular(dersler, ogrenciListe, ogretmenListe);
            x.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Giris s = new Giris(dersler, ogrenciListe, ogretmenListe);
            s.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;

                pictureBox2.ImageLocation = string.Format(@"images\2.jpg");

            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;

                pictureBox2.ImageLocation = string.Format(@"images\3.jpg");

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;

                pictureBox2.ImageLocation = string.Format(@"images\1.jpg");

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = true;
                checkBox1.Checked = false;
                checkBox3.Checked = false;

                pictureBox2.ImageLocation = string.Format(@"images\2.jpg");
            }
            else if (checkBox2.Checked)
            {
                checkBox2.Checked = false;
                checkBox1.Checked = false;
                checkBox3.Checked = true;

                pictureBox2.ImageLocation = string.Format(@"images\3.jpg");

            }
            else {


                checkBox2.Checked = false;
                checkBox1.Checked = true;
                checkBox3.Checked = false;

                pictureBox2.ImageLocation = string.Format(@"images\1.jpg");


            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox3.Checked = true;
                checkBox1.Checked = false;
                checkBox2.Checked = false;

                pictureBox2.ImageLocation = string.Format(@"images\3.jpg");
            }
            else if (checkBox2.Checked)
            {
                checkBox2.Checked = false;
                checkBox1.Checked = true;
                checkBox3.Checked = false;

                pictureBox2.ImageLocation = string.Format(@"images\1.jpg");

            }
            else
            {


                checkBox2.Checked = true;
                checkBox1.Checked = false;
                checkBox3.Checked = false;

                pictureBox2.ImageLocation = string.Format(@"images\2.jpg");


            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            etkinlikler c = new etkinlikler(dersler, ogrenciListe, ogretmenListe);
            c.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            
            label6.ForeColor = Color.Red;

        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
           
            label6.ForeColor = Color.Black;
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

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
