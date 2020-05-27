using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
   
        int x, y;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (cizim == true)
                {
                    var loc = pictureBox1.PointToClient(Cursor.Position);
                    //mouse un picbx uzerindeki konumunu alır
                    //picturebox yerine this button gibi şeylerin uzerindeki konumunuda alabiliriz.
                    //lazım olabilir
                    x = loc.X; y = loc.Y;
                    label1.Text = "x= " + x + " y= " + y;
                    Bitmap bmp = new Bitmap(pictureBox1.Image);
                    int res_x = bmp.Width;//resmin genişliği
                    int res_y = bmp.Height;//resmin yüksekligi
                    int pic_x = pictureBox1.Width;//picboxın genişliği  
                    int pic_y = pictureBox1.Height;//picboxın yüksekliği
                    int fark_x = res_x * x / pic_x; //içler dışlar carpımı
                    int fark_y = res_y * y / pic_y;//içler dıslar caroımı
                    /*            imlecin üstünde durdugu x koord.
                     picturboxın x i 250px  imlecin üstünde durdugu yer 50px olsun
                     * resmin genişliğide 600 px olsun
                     * 250 \/  50
                     * 600 /\  x  tir
                     * x = 120 dir yani imlecin fotograf uzerindeki durdugu yer                    
                    ayni islem y icinde gecerli
                     */

                    //   int fboy=1;   
                    bmp.SetPixel(fark_x, fark_y, Color.Black);                  
                    int[] dizi = { 0, -1, 0, +1, +1, 0, -1, 0, -1, 1, 1, -1, +1, +1, -1, -1 };
                    for (int i = 0; i < dizi.Length; i++)
                    {
                        bmp.SetPixel(fark_x + dizi[i], fark_y + dizi[i + 1], Color.Black);
                        if (i + 1 == 15) break;
                    }
                  //A1 BOLGESİ
                    pictureBox1.Image = bmp;
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
  
       bool cizim = false;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            cizim = true;
        }
    

        //mouse sol click tıkladıktan sonra clickten elini cekince olacaklar
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            cizim = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save(@"C:\Users\sadik\Desktop\" + "asdasd.png");
        }

       
    }
}
//eski kodlar

/* A1 BOLGESİ KODLARI
 * 
  bmp.SetPixel(fark_x, fark_y, Color.Black); //seçilen pixel
bmp.SetPixel(fark_x, fark_y - 1, Color.Black);//sol tarafındaki pixel
bmp.SetPixel(fark_x, fark_y + 1, Color.Black);//sağ tarafındaki   
bmp.SetPixel(fark_x + 1, fark_y, Color.Black);//altındaki
bmp.SetPixel(fark_x - 1, fark_y, Color.Black);//üstündeki
bmp.SetPixel(fark_x - 1, fark_y + 1, Color.Black);//sağ üst çaprazı
bmp.SetPixel(fark_x + 1, fark_y - 1, Color.Black);//sol alt çaprazı
bmp.SetPixel(fark_x + 1, fark_y + 1, Color.Black);//sağ alt çaprazı
bmp.SetPixel(fark_x - 1, fark_y - 1, Color.Black);//sol üst çaprazı
// bunları daha net gorebilmek için büyüttüm 
//fırca boyutları yapıcam orda bu sekil işime yarıyacak (dongu ile yap)*/
 