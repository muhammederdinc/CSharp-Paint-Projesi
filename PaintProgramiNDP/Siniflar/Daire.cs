using System.Drawing;

namespace PaintProgramiNDP.Siniflar
{
    public class Daire : Sekil
    {
        int yaricap = 0;
        byte sonuc = 0;

        /// <summary>
        /// Daire Şeklinin Panel Dışına Taşması Engellenmiştir.
        /// </summary>
        /// <param name="x">Dikey</param>
        /// <param name="y">Yatay</param>
        /// <param name="yaricap">Genişlik</param>
        /// <returns></returns>
        public byte kontrol(int x, int y, int yaricap)
        {
            this.X = x - yaricap / 2;
            this.Y = y - yaricap / 2;
            int pozX = x + yaricap / 2;
            int pozY = y + yaricap / 2;
            if ((X > 0) && (Y > 0) && (pozX < 600) && (pozY < 600))
            {
                sonuc++; // Kontrol amacı 1 sayısı döndürülüyor.
            }
            return sonuc;
        }
        public Daire()
        {

        }
    
        /// <summary>
        /// Daire Çiziminde Kullanılacak Parametreler Çekiliyor.
        /// </summary>
        /// <param name="x">Dikey</param>
        /// <param name="y">Yatay</param>
        /// <param name="yaricap">Genişlik</param>
        /// <param name="c">Renk</param>
        public Daire(int x, int y, int yaricap, Color c)
        {
            Renk = c;
            this.X = x - yaricap / 2;
            this.Y = y - yaricap / 2;
            this.yaricap = yaricap;


        }

        /// <summary>
        /// Daire Şeklinin Çiziminde Kullanılır.
        /// </summary>
        /// <param name="cizimAraci">Graphics Değişkeni</param>
        public override void Ciz(Graphics cizimAraci)
        {

            SolidBrush sb = new SolidBrush(Renk);

            cizimAraci.FillEllipse(sb, X, Y, yaricap, yaricap);
           

        }
    }
}
