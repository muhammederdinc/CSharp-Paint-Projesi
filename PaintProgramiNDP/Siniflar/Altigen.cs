using System.Drawing;

namespace PaintProgramiNDP.Siniflar
{
    class Altigen : Sekil
    {
        int birlesme = 0;
        Point[] p = new Point[6];
        
        /// <summary>
        /// Altıgen Şeklinin Panel Dışına Taşması Engellenmiştir.
        /// </summary>
        /// <param name="x">Dikey</param>
        /// <param name="y">Yatay</param>
        /// <param name="birlesme"></param>
        /// <returns></returns>
        public byte kontrol(int x, int y, int birlesme)
        {
            p[0] = new Point(x - (birlesme / 4), y - (birlesme / 3));
            p[1] = new Point((x - ((birlesme / 2))), y);//dokunma
            p[2] = new Point(x - (birlesme / 4), y + (birlesme / 3));
            p[3] = new Point(x + (birlesme / 4), (y + (birlesme / 3)));
            p[4] = new Point((x + ((birlesme / 2))), y);//dokunma
            p[5] = new Point(x + (birlesme / 4), y - (birlesme / 3));

            byte sonuc = 0;
            foreach (Point item in p) // Her bir point panel sınırını aşıyormu kontrol et.
            {
                if ((item.X > 0) && (item.X < 600) && (item.Y > 0) && (item.Y < 600)) // 600 ile 600 Panel Boyutu
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
        public Altigen()
        {

        }

        /// <summary>
        /// Altıgen Şeklinin Değerleri Alınıyor.
        /// </summary>
        /// <param name="x">Dikey</param>
        /// <param name="y">Yatay</param>
        /// <param name="birlesme"></param>
        /// <param name="c">Renk</param>
        public Altigen(int x, int y, int birlesme, Color c)
        {
            Renk = c;
            this.X = x;
            this.Y = y;
            this.birlesme = birlesme;
           p[0] = new Point(x - (birlesme / 4), y - (birlesme / 3));
           p[1] = new Point((x - ((birlesme / 2))), y);//dokunma
           p[2] = new Point(x - (birlesme / 4), y + (birlesme / 3));
           p[3] = new Point(x + (birlesme / 4), (y + (birlesme / 3)));
           p[4] = new Point((x + ((birlesme / 2))), y);//dokunma
           p[5] = new Point(x + (birlesme / 4), y - (birlesme / 3));


        }

        /// <summary>
        /// Altıgen Çizme İşlemi Gerçekleştiriliyor.
        /// </summary>
        /// <param name="grp">Graphics Değişkeni</param>
        public override void Ciz(Graphics grp)
        {

            SolidBrush sb = new SolidBrush(Renk);
            grp.FillPolygon(sb, p);

        }
    }
}
