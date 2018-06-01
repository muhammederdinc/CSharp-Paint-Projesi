using System.Drawing;

namespace PaintProgramiNDP.Siniflar
{
    public class Ucgen : Sekil
    {
        int birlesme = 0;
        Point[] p = new Point[3];
        

        /// <summary>
        /// Bu Metod Üçgen Şeklinin Panel Dışına Taşmasını Engeller.
        /// </summary>
        /// <param name="x"> Dikey Değer</param>
        /// <param name="y">Yatay Değer</param>
        /// <param name="birlesme"></param>
        /// <returns></returns>
        public byte kontrol(int x, int y, int birlesme) 
        {
            p[0] = new Point(x, y - birlesme);
            p[1] = new Point(x + birlesme, y + birlesme);
            p[2] = new Point(x - birlesme, y + birlesme);
          
            byte sonuc=0;
            foreach (Point item in p)
            { // X Dikey Y Yatay
                if ((item.X > 0) && (item.X < 600) && (item.Y > 0) && (item.Y < 600)) // Her Bir Point Panel Boyunu Aşıyormu Kontrol Et.
                {
                    sonuc++;
                }
                else
                {
                    sonuc--;
                }
            }
            return sonuc;

        }
        public Ucgen()
        {

        }

        /// <summary>
        /// Üçgen Şeklinin Değerleri Çekilmek İçin Kullanılan Metod.
        /// </summary>
        /// <param name="x">Dikey</param>
        /// <param name="y">Yükseklik</param>
        /// <param name="birlesme"></param>
        /// <param name="c">Renk</param>
        public Ucgen(int x, int y, int birlesme, Color c)
        {
          
            Renk = c;
            this.X = x;
            this.Y = y;
           this.birlesme = birlesme;

            p[0] = new Point(x, y - birlesme);
            p[1] = new Point(x + birlesme, y + birlesme);
            p[2] = new Point(x - birlesme, y + birlesme);

          
           
              

        }
        /// <summary>
        /// Üçgen Şeklini Çizmek İçin Kullanılır.
        /// </summary>
        /// <param name="cizimAraci">Graphics Değişkeni</param>
        public override void Ciz(Graphics cizimAraci)
        {

            SolidBrush sb = new SolidBrush(Renk);

            cizimAraci.FillPolygon(sb, p);
            
          




        }
    }
}
