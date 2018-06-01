/*
 G161210307 Muhammed ERDİNÇ
 */
using PaintProgramiNDP.Siniflar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace PaintProgramiNDP
{
  
    public partial class AnaPencere : Form
    {

        int width = 0;
        int height = 0;
        int ek = 0;
        int kontrolek = 0;
        int kontrolTerimi = 0;
        int x = 0;
        int y = 0;
        bool CizimAktfimi = false;
        Graphics cizarac;
        public Sekil sekil = null;
        List<Sekil> Sekiller = new List<Sekil>();
        Button btnSekil;
        Color SecilenRenk = Color.Blue;
        private Bitmap bitmap2;
        


        public AnaPencere()
        {
            InitializeComponent();
            CizimAlani.MouseDown += CizimAlani_MouseDown_1;
            CizimAlani.MouseUp += CizimAlani_MouseUp_1;
            
            CizimAktfimi = false;
            
               
          

        }




        


        void AnaPencere_Paint(object sender, PaintEventArgs e)
        {
            
            if (CizimAktfimi == true)
            {
                cizarac = e.Graphics;
                foreach (Sekil item in Sekiller)
                {
                    item.Ciz(cizarac);
                }

                if (btnSekil.Name == "Daire")
                {
                    sekil = new Daire(x, y, width, SecilenRenk);

                }
                else if (btnSekil.Name == "Kare")
                {

                    sekil = new Kare(x, y,height, SecilenRenk);

                }
                else if (btnSekil.Name == "Altigen")
                {
                    sekil = new Altigen(x, y, ek, SecilenRenk);

                }
                else if (btnSekil.Name == "Ucgen")
                {
                    sekil = new Ucgen(x, y, ek, SecilenRenk);

                }
                sekil.Ciz(cizarac);

            }
         

        }
        private void CizimAlani_MouseDown_1(object sender, MouseEventArgs e)
        {
          
            CizimAlani.MouseMove += CizimAlani_MouseMove_1;
            x = e.X;
            y = e.Y;
            CizimAlani.Refresh();
        }

        private void CizimAlani_MouseMove_1(object sender, MouseEventArgs e)
        {
           

            if (CizimAktfimi == true)
            {
                byte sonuc = 0;
                if (((e.X - x) >= 0) && ((e.Y - y) >= 0))
                {
                    kontrolek = (e.X - x) + (e.Y - y);
                    if (kontrolTerimi == 3)
                    {//Ucgen
                        sonuc = new Ucgen().kontrol(x, y, kontrolek);
                    }
                    else if (kontrolTerimi == 6)
                    {//Altigen
                        sonuc = new Altigen().kontrol(x, y, kontrolek);
                    }
                    else if (kontrolTerimi == 1)
                    {//Daire
                        int widthknt = e.X - x;
                        sonuc = new Daire().kontrol(x, y, widthknt);
                        if (sonuc == kontrolTerimi) // Daire sınıfındaki sonuc ile kontrol terimi eşitse alttaki işlemler yapılır.
                        {
                            width = e.X - x;
                           
                        }
                    }
                    else if (kontrolTerimi == 2)
                    {//Kare
                        sonuc = new Kare().kontrol(x, y,height);
                        if (sonuc == kontrolTerimi) // Kare Sınıfındaki sonuc ile burdaki sonuç eşitse işlemler yapılıyor.
                        {
                            width = e.X - x;
                            height = e.Y - y;
                        }

                    }

                    if ((sonuc == kontrolTerimi) && (kontrolTerimi == 3 || kontrolTerimi == 6))
                    {
                        ek = (e.X - x) + (e.Y - y);
                    }

                }
            }
            CizimAlani.Refresh();
        }
        private void CizimAlani_MouseUp_1(object sender, MouseEventArgs e)
        {
           
            CizimAlani.MouseMove -= CizimAlani_MouseMove_1;
            width = 0;
            height = 0;
            x = 100;
            y = 100;
            ek = 0;
            if (CizimAktfimi == true)
            {
                Sekiller.Add(sekil);
            }
        }

        private void Sekil_Click(object sender, EventArgs e)
        {
          
            Paint += AnaPencere_Paint;
            CizimAktfimi = true;
            btnSekil = (Button)sender; // Tıklanan şeklin özellikleri btnSekile atanıyor.(Örn: Name özelliği.)
            if (btnSekil.Name == "Ucgen")
            {
                kontrolTerimi = 3;
            }
            else if (btnSekil.Name == "Altigen")
            {

                kontrolTerimi = 6;
               
            }
            else if (btnSekil.Name == "Daire")
            {

                kontrolTerimi = 1;
              
            }
            else if (btnSekil.Name == "Kare")
            {
                kontrolTerimi = 2;
            
            }
        }

       
    

    

        private void PKirmizi_Click(object sender, EventArgs e)
        {
            SecilenRenk = Color.Red;
        }


        private void PMavi_Click_1(object sender, EventArgs e)
        {
            SecilenRenk = Color.Blue;
        }

        private void PYesil_Click(object sender, EventArgs e)
        {
            SecilenRenk = Color.Green;
        }

        private void PTuruncu_Click(object sender, EventArgs e)
        {
            SecilenRenk = Color.Orange;
        }

        private void PSiyah_Click(object sender, EventArgs e)
        {
            SecilenRenk = Color.Black;
        }

        private void PSari_Click(object sender, EventArgs e)
        {
            SecilenRenk = Color.Yellow;
        }

        private void PMor_Click(object sender, EventArgs e)
        {
            SecilenRenk = Color.Purple;
        }

        private void PKahverengi_Click(object sender, EventArgs e)
        {
            SecilenRenk = Color.Brown;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SecilenRenk = Color.White;
        }

        private void Kare_Click(object sender, EventArgs e)
        {
            kontrolTerimi = 2;
            
        }

        private void PDosyaAc_Click(object sender, EventArgs e)
        {
            try { 
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Png Dosyası|*.png|jpeg Dosyası|*.jpg|bitmaps|*.bmp";
            if (dosya.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap ebitmap = bitmap2;
                bitmap2 = new Bitmap(dosya.FileName);
                ebitmap.Dispose();
               
            }
            }

            catch(Exception ex)
            {
                MessageBox.Show("Dosya Yüklenemedi..." + ex.Message);
            }

           



        }

        private void pictureBox2_Click(object senoder, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(CizimAlani.Width, CizimAlani.Height);
            Graphics cizimler = Graphics.FromImage(bitmap);
            Rectangle ekranikaydet = CizimAlani.RectangleToScreen(CizimAlani.ClientRectangle);
            cizimler.CopyFromScreen(ekranikaydet.Location, Point.Empty, CizimAlani.Size);
            cizimler.Dispose();
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Png Dosyası|*.png|jpeg Dosyası|*.jpg|bitmaps|*.bmp";

            if (save.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(save.FileName))
                {
                    File.Delete(save.FileName);
                }
                if (save.FileName.Contains(".jpg"))
                {
                    bitmap.Save(save.FileName, ImageFormat.Jpeg);

                }
                else if (save.FileName.Contains(".png"))
                {
                    bitmap.Save(save.FileName, ImageFormat.Png);
                }
                else if (save.FileName.Contains("bmp"))
                {
                    bitmap.Save(save.FileName, ImageFormat.Bmp);
                }

            }

        }

        private void AnaPencere_Load(object sender, EventArgs e)
        {




        }
    }
}
