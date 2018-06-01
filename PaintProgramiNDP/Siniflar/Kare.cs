using System.Drawing;
namespace PaintProgramiNDP
{
    class Kare : Sekil
    {

       
        int kenar = 0;
        byte sonuc = 0;
        /// <summary>
        /// Bu Metod Dikdörtgen Şeklinin Panel Dışına Taşmasını Engeller.
        /// </summary>
        /// <param name="x">Dikey Değer</param>
        /// <param name="y">Yatay Değer</param>
        /// <param name="kenar">Kenar Değerleri</param>
        /// <returns></returns>
        public byte kontrol(int x, int y,int kenar) // Çizilen Dikdörtgen Panel Boyutunu Aşmasın
        {
            if (x < 600 && x>0 && y<600 && y>0 /*&& height < 600*/) // Panel Dışına Taşmayı Engelleme (Panel Boyutu 600X600)
            {
                sonuc = 2; // Anapencerede Çizim Öncesi Kontrol İçin sonuc = 2 döndürülüyor.
            }
            return sonuc;
        }
        public Kare()
        {

        }
        /// <summary>
        /// Kare Şeklinin Değerleri Çekilmek Amacıyla Yazılmış Metod.
        /// </summary>
        /// <param name="x">Dikey Değerler</param>
        /// <param name="y">Yatay Değerler</param>
        /// <param name="kenar">Kenar Değerleri</param>
        /// <param name="c">Renk</param>
        public Kare(int x, int y, int kenar, Color c)
        {
            Renk = c;
            this.X = x;
            this.Y = y;
           
            this.kenar = kenar;
          
        }
       /// <summary>
       /// Çiz Metodu Override Edilmiştir.KAre Çİzmek İçin Kullanılan Metod
       /// </summary>
       /// <param name="grp">Graphics Değişkeni</param>
        public override void Ciz(Graphics grp)
        {
           
            SolidBrush sb = new SolidBrush(Renk); // Karenin Boyama İşlemi Yapılıyor.
            grp.FillRectangle(sb, X, Y, kenar, kenar); // Yukarıdan Çekiliyor.
        }
       
    }
}
