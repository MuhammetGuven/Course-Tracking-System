using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using VeriYapilari;

namespace ders_takip_sistemi
{
    public partial class Giris : Form
    {
        public HashTable dersler;
        public OgrenciAVL ogrenciListe;
        public OgretimGorevlisiAVL ogretmenListe;
        NodeOgr hedefOgr;
        Ogrenci seciliOgrenci;
        NodeGorevli hedefHoca;
        OgretimGorevlisi seciliHoca;

        public Giris(HashTable dersler, OgrenciAVL ogrenciListe, OgretimGorevlisiAVL ogretmenListe)
        {
            this.dersler = dersler;
            this.ogrenciListe = ogrenciListe;
            this.ogretmenListe = ogretmenListe;
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text == "Numara")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Numara";
                textBox1.ForeColor = Color.DimGray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Şifre")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Şifre";
                textBox2.ForeColor = Color.DimGray;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox3.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox2.Checked = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            AnaSayfa v = new AnaSayfa(dersler, ogrenciListe, ogretmenListe);
            v.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "" && textBox1.Text != "Numara") && (textBox2.Text != "" && textBox2.Text != "Şifre") && checkBox2.Checked)
            {
                hedefOgr = ogrenciListe.SearchTree(textBox1.Text);
                if (hedefOgr == null)
                    MessageBox.Show("Ogrenci bulunamadi...");
                else
                {
                    seciliOgrenci = hedefOgr.Ogrenci;
                    if (seciliOgrenci.sifre==textBox2.Text)
                    {
                        OgrenciSayfa z = new OgrenciSayfa(dersler, ogrenciListe, ogretmenListe, seciliOgrenci);
                        z.Show();
                        this.Hide();
                    }
                    else
                    {
                       MessageBox.Show("Yanlis sifre");
                    }
                    
                }
                

            }
            
            else if ((textBox1.Text != "" && textBox1.Text != "Numara") && (textBox2.Text != "" && textBox2.Text != "Şifre") && checkBox3.Checked)
            {
                hedefHoca = ogretmenListe.SearchTree(textBox1.Text);
                if (hedefHoca == null)
                    MessageBox.Show("Öğretmen bulunamadi...");
                else
                {
                    seciliHoca = hedefHoca.OgretimGorevlisi;
                    if (seciliHoca.sifre == textBox2.Text)
                    {
                        OgretmenSayfa y = new OgretmenSayfa(dersler, ogrenciListe, ogretmenListe, seciliHoca);
                        y.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Yanlis sifre");
                    }

                }
                
            }
            else if (textBox1.Text == "Numara" || textBox2.Text == "Şifre" || (!checkBox3.Checked && !checkBox2.Checked))
                MessageBox.Show("Gereken bilgileri doldurunuz");


           


        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
