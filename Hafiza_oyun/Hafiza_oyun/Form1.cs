using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hafiza_oyun
{
    public partial class Form1 : Form
    {

        Image[] resimler =
        {
            Properties.Resources.cilek,
            Properties.Resources.elma,
            Properties.Resources.kayisi,
            Properties.Resources.uzum,
            Properties.Resources.muz,
            Properties.Resources.kavun,
            Properties.Resources.karpuz,
            Properties.Resources.portakal
        };

        int[] indeksler = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        PictureBox ilkKutu;
        int ilkIndeks , bulunan, deneme;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            resimleriKaristir();
        }

        private void resimleriKaristir()
        {
            Random rnd = new Random();
            for (int i = 0; i < 16; i++)
            {
                int sayi = rnd.Next(16);
                int gecici = indeksler[i];
                indeksler[i] = indeksler[sayi];
                indeksler[sayi] = gecici;
            }
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            PictureBox kutu = (PictureBox)sender;
            int kutuNo = int.Parse(kutu.Name.Substring(10));
            int indeksNo = indeksler[kutuNo - 1];
            kutu.Image = resimler[indeksNo];
            kutu.Refresh();

            if (ilkKutu== null)
            {
                ilkKutu = kutu;
                ilkIndeks = indeksNo;
                deneme++;
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                ilkKutu.Image = null;
                kutu.Image = null;
                if (ilkIndeks==indeksNo)
                {
                    bulunan++;
                    ilkKutu.Visible = false;
                    kutu.Visible = false;

                    if (bulunan==8)
                    {
                        MessageBox.Show("Tebrikler!!!"+deneme+". denemede kazandınız.");
                        bulunan = 0;
                        deneme = 0;
                        foreach  (Control kontrol in Controls)
                        {
                            kontrol.Visible = true;
                        }
                        resimleriKaristir();
                    }
                }
                ilkKutu = null;
            }
        }
    }
}
