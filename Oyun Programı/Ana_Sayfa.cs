using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Oyun_Programı
{
    public partial class Ana_Sayfa : Form
    {
        public Ana_Sayfa()
        {
            InitializeComponent();
        }
        int kalan_kart = 13;
        int oyuncu1, oyuncu2, oyuncu3, oyuncu4;
        string ad1, ad2, ad3, ad4;
        string[,] kartlar = new string[52, 2];
        public string[, ,] oyuncular = new string[4, 13, 2];

        Random rnd = new Random();

        int[,] oyuncu_kartpuan = new int[4, 1];
        int[,] oyuncu_puan_durumu = new int[4, 1];
        int atılan_kart_puan;

        void oyuncu_kart_atma()
        {
            int kart;

            oyuncu_kartpuan[0, 0] = atılan_kart_puan;

            for (; ; )
            {
                kart = rnd.Next(0, 13);
                if (oyuncular[1, kart, 0] != "")
                {
                    int atılan_kart = int.Parse(oyuncular[1, kart, 0]);

                    pbox_atılan_kart2.Image = ımglist_kagitlar.Images[atılan_kart];
                    oyuncu_kartpuan[1, 0] = int.Parse(oyuncular[1, kart, 1]);

                    oyuncular[1, kart, 0] = "";
                    oyuncular[1, kart, 1] = "";

                    break;
                }
            }

            for (; ; )
            {
                kart = rnd.Next(0, 13);
                if (oyuncular[2, kart, 0] != "")
                {
                    int atılan_kart = int.Parse(oyuncular[2, kart, 0]);

                    pbox_atılan_kart3.Image = ımglist_kagitlar.Images[atılan_kart];
                    oyuncu_kartpuan[2, 0] = int.Parse(oyuncular[2, kart, 1]);

                    oyuncular[2, kart, 0] = "";
                    oyuncular[2, kart, 1] = "";

                    break;
                }
            }

            for (; ; )
            {
                kart = rnd.Next(0, 13);
                if (oyuncular[3, kart, 0] != "")
                {
                    int atılan_kart = int.Parse(oyuncular[3, kart, 0]);

                    pbox_atılan_kart4.Image = ımglist_kagitlar.Images[atılan_kart];
                    oyuncu_kartpuan[3, 0] = int.Parse(oyuncular[3, kart, 1]);

                    oyuncular[3, kart, 0] = "";
                    oyuncular[3, kart, 1] = "";

                    break;
                }
            }

            el_kazanan();
        }

        void el_kazanan()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int l = 0; l < 4; l++)
                {
                    if (oyuncu_kartpuan[i, 0] <= oyuncu_kartpuan[l, 0])
                    { }
                    else
                    {
                        oyuncu_puan_durumu[i, 0]++;
                        break;
                    }

                }
            }

            lbl_siz.Text = oyuncu_puan_durumu[0, 0].ToString();
            lbl_oyuncu1.Text = oyuncu_puan_durumu[1, 0].ToString();
            lbl_oyuncu2.Text = oyuncu_puan_durumu[2, 0].ToString();
            lbl_oyuncu3.Text = oyuncu_puan_durumu[3, 0].ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int sayac = 1;
            for (int i = 0; i < 52; i++)
            {
                kartlar[i, 0] = i.ToString();
                kartlar[i, 1] = sayac.ToString();
                if (sayac == 13) sayac = 0;
                sayac++;
            }

            for (int i = 0; i < 4; i++)
            {
                for (int l = 0; l < 13; )
                {
                    int sayı = rnd.Next(0, 52);
                    if (kartlar[sayı, 0] != "")
                    {
                        oyuncular[i, l, 0] = kartlar[sayı, 0];
                        oyuncular[i, l, 1] = kartlar[sayı, 1];

                        kartlar[sayı, 0] = "";
                        kartlar[sayı, 1] = "";

                        l++;
                    }
                }
            }
            int kart = 0;
            foreach (Control pbox_cnt in this.Controls)
            {
                if (pbox_cnt is PictureBox && pbox_cnt.Name != pbox_atılan_kart1.Name && pbox_cnt.Name != pbox_atılan_kart2.Name && pbox_cnt.Name != pbox_atılan_kart3.Name && pbox_cnt.Name != pbox_atılan_kart4.Name)
                {
                    int oyuncunun_kartı = int.Parse(oyuncular[0, kart, 0]);
                    int oyuncunun_kart_puanı = int.Parse(oyuncular[0, kart, 1]);

                    PictureBox pbox = (PictureBox)pbox_cnt;
                    pbox.Image = ımglist_kagitlar.Images[oyuncunun_kartı];
                    pbox.Image.Tag = oyuncunun_kart_puanı;
                    kart++;
                }
            }
        }

        private void pbox_Kart1_Click(object sender, EventArgs e)
        {
            pbox_atılan_kart1.Image = pbox_Kart1.Image;
            atılan_kart_puan = int.Parse(pbox_Kart1.Image.Tag.ToString());

            oyuncu_kart_atma();

            pbox_Kart1.Visible = false;
            pbox_Kart1.Image = null;

            kalan_kart--;
            if (kalan_kart == 0)
            {
                MessageBox.Show("Oyun Bitti");

                ad1 = label1.Text;
                ad2 = label2.Text;
                ad3 = label3.Text;
                ad4 = label4.Text;
                oyuncu1 = int.Parse(lbl_siz.Text);
                oyuncu2 = int.Parse(lbl_oyuncu1.Text);
                oyuncu3 = int.Parse(lbl_oyuncu2.Text);
                oyuncu4 = int.Parse(lbl_oyuncu3.Text);
                if ((oyuncu1 > oyuncu2) && (oyuncu1 > oyuncu3) && (oyuncu1 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad1 + " Kazanmıştır.");
                }
                else if ((oyuncu2 > oyuncu1) && (oyuncu2 > oyuncu3) && (oyuncu2 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad2 + " Kazanmıştır.");
                }
                else if ((oyuncu3 > oyuncu2) && (oyuncu3 > oyuncu1) && (oyuncu3 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad3 + " Kazanmıştır.");
                }
                else if ((oyuncu4 > oyuncu2) && (oyuncu4 > oyuncu3) && (oyuncu4 > oyuncu1))
                {
                    MessageBox.Show("Oyunu " + ad4 + " Kazanmıştır.");
                }
            }
        }

        private void pbox_kart2_Click(object sender, EventArgs e)
        {
            pbox_atılan_kart1.Image = pbox_kart2.Image;
            atılan_kart_puan = int.Parse(pbox_kart2.Image.Tag.ToString());

            oyuncu_kart_atma();

            pbox_kart2.Visible = false;
            pbox_kart2.Image = null;

            kalan_kart--;
            if (kalan_kart == 0)
            {
                MessageBox.Show("Oyun Bitti");

                ad1 = label1.Text;
                ad2 = label2.Text;
                ad3 = label3.Text;
                ad4 = label4.Text;
                oyuncu1 = int.Parse(lbl_siz.Text);
                oyuncu2 = int.Parse(lbl_oyuncu1.Text);
                oyuncu3 = int.Parse(lbl_oyuncu2.Text);
                oyuncu4 = int.Parse(lbl_oyuncu3.Text);
                if ((oyuncu1 > oyuncu2) && (oyuncu1 > oyuncu3) && (oyuncu1 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad1 + " Kazanmıştır.");
                }
                else if ((oyuncu2 > oyuncu1) && (oyuncu2 > oyuncu3) && (oyuncu2 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad2 + " Kazanmıştır.");
                }
                else if ((oyuncu3 > oyuncu2) && (oyuncu3 > oyuncu1) && (oyuncu3 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad3 + " Kazanmıştır.");
                }
                else if ((oyuncu4 > oyuncu2) && (oyuncu4 > oyuncu3) && (oyuncu4 > oyuncu1))
                {
                    MessageBox.Show("Oyunu " + ad4 + " Kazanmıştır.");
                }
            }
        }

        private void pbox_kart3_Click(object sender, EventArgs e)
        {
            pbox_atılan_kart1.Image = pbox_kart3.Image;
            atılan_kart_puan = int.Parse(pbox_kart3.Image.Tag.ToString());

            oyuncu_kart_atma();

            pbox_kart3.Visible = false;
            pbox_kart3.Image = null;

            kalan_kart--;
            if (kalan_kart == 0)
            {
                MessageBox.Show("Oyun Bitti");

                ad1 = label1.Text;
                ad2 = label2.Text;
                ad3 = label3.Text;
                ad4 = label4.Text;
                oyuncu1 = int.Parse(lbl_siz.Text);
                oyuncu2 = int.Parse(lbl_oyuncu1.Text);
                oyuncu3 = int.Parse(lbl_oyuncu2.Text);
                oyuncu4 = int.Parse(lbl_oyuncu3.Text);
                if ((oyuncu1 > oyuncu2) && (oyuncu1 > oyuncu3) && (oyuncu1 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad1 + " Kazanmıştır.");
                }
                else if ((oyuncu2 > oyuncu1) && (oyuncu2 > oyuncu3) && (oyuncu2 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad2 + " Kazanmıştır.");
                }
                else if ((oyuncu3 > oyuncu2) && (oyuncu3 > oyuncu1) && (oyuncu3 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad3 + " Kazanmıştır.");
                }
                else if ((oyuncu4 > oyuncu2) && (oyuncu4 > oyuncu3) && (oyuncu4 > oyuncu1))
                {
                    MessageBox.Show("Oyunu " + ad4 + " Kazanmıştır.");
                }
            }
        }

        private void pbox_kart4_Click(object sender, EventArgs e)
        {
            pbox_atılan_kart1.Image = pbox_kart4.Image;
            atılan_kart_puan = int.Parse(pbox_kart4.Image.Tag.ToString());

            oyuncu_kart_atma();

            pbox_kart4.Visible = false;
            pbox_kart4.Image = null;

            kalan_kart--;
            if (kalan_kart == 0)
            {
                MessageBox.Show("Oyun Bitti");

                ad1 = label1.Text;
                ad2 = label2.Text;
                ad3 = label3.Text;
                ad4 = label4.Text;
                oyuncu1 = int.Parse(lbl_siz.Text);
                oyuncu2 = int.Parse(lbl_oyuncu1.Text);
                oyuncu3 = int.Parse(lbl_oyuncu2.Text);
                oyuncu4 = int.Parse(lbl_oyuncu3.Text);
                if ((oyuncu1 > oyuncu2) && (oyuncu1 > oyuncu3) && (oyuncu1 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad1 + " Kazanmıştır.");
                }
                else if ((oyuncu2 > oyuncu1) && (oyuncu2 > oyuncu3) && (oyuncu2 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad2 + " Kazanmıştır.");
                }
                else if ((oyuncu3 > oyuncu2) && (oyuncu3 > oyuncu1) && (oyuncu3 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad3 + " Kazanmıştır.");
                }
                else if ((oyuncu4 > oyuncu2) && (oyuncu4 > oyuncu3) && (oyuncu4 > oyuncu1))
                {
                    MessageBox.Show("Oyunu " + ad4 + " Kazanmıştır.");
                }
            }
        }

        private void pbox_kart5_Click(object sender, EventArgs e)
        {
            pbox_atılan_kart1.Image = pbox_kart5.Image;
            atılan_kart_puan = int.Parse(pbox_kart5.Image.Tag.ToString());

            oyuncu_kart_atma();

            pbox_kart5.Visible = false;
            pbox_kart5.Image = null;

            kalan_kart--;
            if (kalan_kart == 0)
            {
                MessageBox.Show("Oyun Bitti");

                ad1 = label1.Text;
                ad2 = label2.Text;
                ad3 = label3.Text;
                ad4 = label4.Text;
                oyuncu1 = int.Parse(lbl_siz.Text);
                oyuncu2 = int.Parse(lbl_oyuncu1.Text);
                oyuncu3 = int.Parse(lbl_oyuncu2.Text);
                oyuncu4 = int.Parse(lbl_oyuncu3.Text);
                if ((oyuncu1 > oyuncu2) && (oyuncu1 > oyuncu3) && (oyuncu1 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad1 + " Kazanmıştır.");
                }
                else if ((oyuncu2 > oyuncu1) && (oyuncu2 > oyuncu3) && (oyuncu2 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad2 + " Kazanmıştır.");
                }
                else if ((oyuncu3 > oyuncu2) && (oyuncu3 > oyuncu1) && (oyuncu3 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad3 + " Kazanmıştır.");
                }
                else if ((oyuncu4 > oyuncu2) && (oyuncu4 > oyuncu3) && (oyuncu4 > oyuncu1))
                {
                    MessageBox.Show("Oyunu " + ad4 + " Kazanmıştır.");
                }
            }
        }

        private void pbox_kart6_Click(object sender, EventArgs e)
        {
            pbox_atılan_kart1.Image = pbox_kart6.Image;
            atılan_kart_puan = int.Parse(pbox_kart6.Image.Tag.ToString());

            oyuncu_kart_atma();

            pbox_kart6.Visible = false;
            pbox_kart6.Image = null;

            kalan_kart--;
            if (kalan_kart == 0)
            {
                MessageBox.Show("Oyun Bitti");

                ad1 = label1.Text;
                ad2 = label2.Text;
                ad3 = label3.Text;
                ad4 = label4.Text;
                oyuncu1 = int.Parse(lbl_siz.Text);
                oyuncu2 = int.Parse(lbl_oyuncu1.Text);
                oyuncu3 = int.Parse(lbl_oyuncu2.Text);
                oyuncu4 = int.Parse(lbl_oyuncu3.Text);
                if ((oyuncu1 > oyuncu2) && (oyuncu1 > oyuncu3) && (oyuncu1 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad1 + " Kazanmıştır.");
                }
                else if ((oyuncu2 > oyuncu1) && (oyuncu2 > oyuncu3) && (oyuncu2 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad2 + " Kazanmıştır.");
                }
                else if ((oyuncu3 > oyuncu2) && (oyuncu3 > oyuncu1) && (oyuncu3 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad3 + " Kazanmıştır.");
                }
                else if ((oyuncu4 > oyuncu2) && (oyuncu4 > oyuncu3) && (oyuncu4 > oyuncu1))
                {
                    MessageBox.Show("Oyunu " + ad4 + " Kazanmıştır.");
                }
            }
        }

        private void pbox_kart7_Click(object sender, EventArgs e)
        {
            pbox_atılan_kart1.Image = pbox_kart7.Image;
            atılan_kart_puan = int.Parse(pbox_kart7.Image.Tag.ToString());

            oyuncu_kart_atma();

            pbox_kart7.Visible = false;
            pbox_kart7.Image = null;

            kalan_kart--;
            if (kalan_kart == 0)
            {
                MessageBox.Show("Oyun Bitti");

                ad1 = label1.Text;
                ad2 = label2.Text;
                ad3 = label3.Text;
                ad4 = label4.Text;
                oyuncu1 = int.Parse(lbl_siz.Text);
                oyuncu2 = int.Parse(lbl_oyuncu1.Text);
                oyuncu3 = int.Parse(lbl_oyuncu2.Text);
                oyuncu4 = int.Parse(lbl_oyuncu3.Text);
                if ((oyuncu1 > oyuncu2) && (oyuncu1 > oyuncu3) && (oyuncu1 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad1 + " Kazanmıştır.");
                }
                else if ((oyuncu2 > oyuncu1) && (oyuncu2 > oyuncu3) && (oyuncu2 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad2 + " Kazanmıştır.");
                }
                else if ((oyuncu3 > oyuncu2) && (oyuncu3 > oyuncu1) && (oyuncu3 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad3 + " Kazanmıştır.");
                }
                else if ((oyuncu4 > oyuncu2) && (oyuncu4 > oyuncu3) && (oyuncu4 > oyuncu1))
                {
                    MessageBox.Show("Oyunu " + ad4 + " Kazanmıştır.");
                }
            }
        }

        private void pbox_kart8_Click(object sender, EventArgs e)
        {
            pbox_atılan_kart1.Image = pbox_kart8.Image;
            atılan_kart_puan = int.Parse(pbox_kart8.Image.Tag.ToString());

            oyuncu_kart_atma();

            pbox_kart8.Visible = false;
            pbox_kart8.Image = null;

            kalan_kart--;
            if (kalan_kart == 0)
            {
                MessageBox.Show("Oyun Bitti");

                ad1 = label1.Text;
                ad2 = label2.Text;
                ad3 = label3.Text;
                ad4 = label4.Text;
                oyuncu1 = int.Parse(lbl_siz.Text);
                oyuncu2 = int.Parse(lbl_oyuncu1.Text);
                oyuncu3 = int.Parse(lbl_oyuncu2.Text);
                oyuncu4 = int.Parse(lbl_oyuncu3.Text);
                if ((oyuncu1 > oyuncu2) && (oyuncu1 > oyuncu3) && (oyuncu1 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad1 + " Kazanmıştır.");
                }
                else if ((oyuncu2 > oyuncu1) && (oyuncu2 > oyuncu3) && (oyuncu2 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad2 + " Kazanmıştır.");
                }
                else if ((oyuncu3 > oyuncu2) && (oyuncu3 > oyuncu1) && (oyuncu3 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad3 + " Kazanmıştır.");
                }
                else if ((oyuncu4 > oyuncu2) && (oyuncu4 > oyuncu3) && (oyuncu4 > oyuncu1))
                {
                    MessageBox.Show("Oyunu " + ad4 + " Kazanmıştır.");
                }
            }
        }

        private void pbox_kart9_Click(object sender, EventArgs e)
        {
            pbox_atılan_kart1.Image = pbox_kart9.Image;
            atılan_kart_puan = int.Parse(pbox_kart9.Image.Tag.ToString());

            oyuncu_kart_atma();

            pbox_kart9.Visible = false;
            pbox_kart9.Image = null;

            kalan_kart--;
            if (kalan_kart == 0)
            {
                MessageBox.Show("Oyun Bitti");

                ad1 = label1.Text;
                ad2 = label2.Text;
                ad3 = label3.Text;
                ad4 = label4.Text;
                oyuncu1 = int.Parse(lbl_siz.Text);
                oyuncu2 = int.Parse(lbl_oyuncu1.Text);
                oyuncu3 = int.Parse(lbl_oyuncu2.Text);
                oyuncu4 = int.Parse(lbl_oyuncu3.Text);
                if ((oyuncu1 > oyuncu2) && (oyuncu1 > oyuncu3) && (oyuncu1 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad1 + " Kazanmıştır.");
                }
                else if ((oyuncu2 > oyuncu1) && (oyuncu2 > oyuncu3) && (oyuncu2 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad2 + " Kazanmıştır.");
                }
                else if ((oyuncu3 > oyuncu2) && (oyuncu3 > oyuncu1) && (oyuncu3 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad3 + " Kazanmıştır.");
                }
                else if ((oyuncu4 > oyuncu2) && (oyuncu4 > oyuncu3) && (oyuncu4 > oyuncu1))
                {
                    MessageBox.Show("Oyunu " + ad4 + " Kazanmıştır.");
                }
            }
        }

        private void pbox_kart10_Click(object sender, EventArgs e)
        {
            pbox_atılan_kart1.Image = pbox_kart10.Image;
            atılan_kart_puan = int.Parse(pbox_kart10.Image.Tag.ToString());

            oyuncu_kart_atma();

            pbox_kart10.Visible = false;
            pbox_kart10.Image = null;

            kalan_kart--;
            if (kalan_kart == 0)
            {
                MessageBox.Show("Oyun Bitti");

                ad1 = label1.Text;
                ad2 = label2.Text;
                ad3 = label3.Text;
                ad4 = label4.Text;
                oyuncu1 = int.Parse(lbl_siz.Text);
                oyuncu2 = int.Parse(lbl_oyuncu1.Text);
                oyuncu3 = int.Parse(lbl_oyuncu2.Text);
                oyuncu4 = int.Parse(lbl_oyuncu3.Text);
                if ((oyuncu1 > oyuncu2) && (oyuncu1 > oyuncu3) && (oyuncu1 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad1 + " Kazanmıştır.");
                }
                else if ((oyuncu2 > oyuncu1) && (oyuncu2 > oyuncu3) && (oyuncu2 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad2 + " Kazanmıştır.");
                }
                else if ((oyuncu3 > oyuncu2) && (oyuncu3 > oyuncu1) && (oyuncu3 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad3 + " Kazanmıştır.");
                }
                else if ((oyuncu4 > oyuncu2) && (oyuncu4 > oyuncu3) && (oyuncu4 > oyuncu1))
                {
                    MessageBox.Show("Oyunu " + ad4 + " Kazanmıştır.");
                }
            }
        }

        private void pbox_kart11_Click(object sender, EventArgs e)
        {
            pbox_atılan_kart1.Image = pbox_kart11.Image;
            atılan_kart_puan = int.Parse(pbox_kart11.Image.Tag.ToString());

            oyuncu_kart_atma();

            pbox_kart11.Visible = false;
            pbox_kart11.Image = null;

            kalan_kart--;
            if (kalan_kart == 0)
            {
                MessageBox.Show("Oyun Bitti");

                ad1 = label1.Text;
                ad2 = label2.Text;
                ad3 = label3.Text;
                ad4 = label4.Text;
                oyuncu1 = int.Parse(lbl_siz.Text);
                oyuncu2 = int.Parse(lbl_oyuncu1.Text);
                oyuncu3 = int.Parse(lbl_oyuncu2.Text);
                oyuncu4 = int.Parse(lbl_oyuncu3.Text);
                if ((oyuncu1 > oyuncu2) && (oyuncu1 > oyuncu3) && (oyuncu1 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad1 + " Kazanmıştır.");
                }
                else if ((oyuncu2 > oyuncu1) && (oyuncu2 > oyuncu3) && (oyuncu2 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad2 + " Kazanmıştır.");
                }
                else if ((oyuncu3 > oyuncu2) && (oyuncu3 > oyuncu1) && (oyuncu3 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad3 + " Kazanmıştır.");
                }
                else if ((oyuncu4 > oyuncu2) && (oyuncu4 > oyuncu3) && (oyuncu4 > oyuncu1))
                {
                    MessageBox.Show("Oyunu " + ad4 + " Kazanmıştır.");
                }
            }
        }

        private void pbox_kart12_Click(object sender, EventArgs e)
        {
            pbox_atılan_kart1.Image = pbox_kart12.Image;
            atılan_kart_puan = int.Parse(pbox_kart12.Image.Tag.ToString());

            oyuncu_kart_atma();

            pbox_kart12.Visible = false;
            pbox_kart12.Image = null;

            kalan_kart--;
            if (kalan_kart == 0)
            {
                MessageBox.Show("Oyun Bitti");

                ad1 = label1.Text;
                ad2 = label2.Text;
                ad3 = label3.Text;
                ad4 = label4.Text;
                oyuncu1 = int.Parse(lbl_siz.Text);
                oyuncu2 = int.Parse(lbl_oyuncu1.Text);
                oyuncu3 = int.Parse(lbl_oyuncu2.Text);
                oyuncu4 = int.Parse(lbl_oyuncu3.Text);
                if ((oyuncu1 > oyuncu2) && (oyuncu1 > oyuncu3) && (oyuncu1 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad1 + " Kazanmıştır.");
                }
                else if ((oyuncu2 > oyuncu1) && (oyuncu2 > oyuncu3) && (oyuncu2 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad2 + " Kazanmıştır.");
                }
                else if ((oyuncu3 > oyuncu2) && (oyuncu3 > oyuncu1) && (oyuncu3 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad3 + " Kazanmıştır.");
                }
                else if ((oyuncu4 > oyuncu2) && (oyuncu4 > oyuncu3) && (oyuncu4 > oyuncu1))
                {
                    MessageBox.Show("Oyunu " + ad4 + " Kazanmıştır.");
                }
            }
        }

        private void pbox_kart13_Click(object sender, EventArgs e)
        {
            pbox_atılan_kart1.Image = pbox_kart13.Image;
            atılan_kart_puan = int.Parse(pbox_kart13.Image.Tag.ToString());

            oyuncu_kart_atma();

            pbox_kart13.Visible = false;
            pbox_kart13.Image = null;
            kalan_kart--;
            if (kalan_kart == 0)
            {
                MessageBox.Show("Oyun Bitti");

                ad1 = label1.Text;
                ad2 = label2.Text;
                ad3 = label3.Text;
                ad4 = label4.Text;
                oyuncu1 = int.Parse(lbl_siz.Text);
                oyuncu2 = int.Parse(lbl_oyuncu1.Text);
                oyuncu3 = int.Parse(lbl_oyuncu2.Text);
                oyuncu4 = int.Parse(lbl_oyuncu3.Text);
                if ((oyuncu1 > oyuncu2) && (oyuncu1 > oyuncu3) && (oyuncu1 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad1 + " Kazanmıştır.");
                }
                else if ((oyuncu2 > oyuncu1) && (oyuncu2 > oyuncu3) && (oyuncu2 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad2 + " Kazanmıştır.");
                }
                else if ((oyuncu3 > oyuncu2) && (oyuncu3 > oyuncu1) && (oyuncu3 > oyuncu4))
                {
                    MessageBox.Show("Oyunu " + ad3 + " Kazanmıştır.");
                }
                else if ((oyuncu4 > oyuncu2) && (oyuncu4 > oyuncu3) && (oyuncu4 > oyuncu1))
                {
                    MessageBox.Show("Oyunu " + ad4 + " Kazanmıştır.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sayac = 1;
            for (int i = 0; i < 52; i++)
            {
                kartlar[i, 0] = i.ToString();
                kartlar[i, 1] = sayac.ToString();
                if (sayac == 13) sayac = 0;
                sayac++;
            }

            for (int i = 0; i < 4; i++)
            {
                for (int l = 0; l < 13; )
                {
                    int sayı = rnd.Next(0, 52);
                    if (kartlar[sayı, 0] != "")
                    {
                        oyuncular[i, l, 0] = kartlar[sayı, 0];
                        oyuncular[i, l, 1] = kartlar[sayı, 1];

                        kartlar[sayı, 0] = "";
                        kartlar[sayı, 1] = "";

                        l++;
                    }
                }
            }
            int kart = 0;
            foreach (Control pbox_cnt in this.Controls)
            {
                if (pbox_cnt is PictureBox && pbox_cnt.Name != pbox_atılan_kart1.Name && pbox_cnt.Name != pbox_atılan_kart2.Name && pbox_cnt.Name != pbox_atılan_kart3.Name && pbox_cnt.Name != pbox_atılan_kart4.Name)
                {
                    int oyuncunun_kartı = int.Parse(oyuncular[0, kart, 0]);
                    int oyuncunun_kart_puanı = int.Parse(oyuncular[0, kart, 1]);

                    PictureBox pbox = (PictureBox)pbox_cnt;
                    pbox.Image = ımglist_kagitlar.Images[oyuncunun_kartı];
                    pbox.Image.Tag = oyuncunun_kart_puanı;
                    kart++;
                }
            }
        }
    }
}
