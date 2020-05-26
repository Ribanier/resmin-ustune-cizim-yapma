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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {


        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (cizim == true)
                {
                    label1.Text = pictureBox1.PointToClient(Cursor.Position).ToString();
                    //mouse un picbx uzerindeki konumunu alır
                    //picturebox yerine this button gibi şeylerin uzerindeki konumunuda alabiliriz.
                    //lazım olabilir
                    string[] dizi = { "{", "}", "X", "Y", "=" };

                    char[] dizi1 = label1.Text.ToCharArray();
                    string y = "", x = "";
                    for (int i = 0; i < dizi1.Length; i++)
                    {
                        int a = 0;
                        for (int j = 0; j < dizi.Length; j++)
                        {
                            if (dizi1[i].ToString() == dizi[j])
                            {
                                continue;
                            }
                            a++;

                        }
                        if (a == 5)
                        {
                            if (dizi1[i].ToString() == ",")
                            {
                                x = y;
                                y = "";
                                continue;
                            }
                            y += dizi1[i];
                        }

                    }


                    /*   MessageBox.Show(x); MessageBox.Show(y);*/
                    Bitmap bmp = new Bitmap(pictureBox1.Image);
                    int res_x = bmp.Width;//resmin genişliği
                    int res_y = bmp.Height;//resmin yüksekligi
                    int pic_x = pictureBox1.Width;//picboxın genişliği  
                    int pic_y = pictureBox1.Height;//picboxın yüksekliği
                    int fark_x = res_x * int.Parse(x) / pic_x; //içler dışlar carpımı
                    /*            imlecin üstünde durdugu x koord.
                     picturboxın x i 250px  imlecin üstünde durdugu yer 50px olsun
                     * resmin genişliğide 600 px olsun
                     * 250 \/  50
                     * 600 /\  x  tir
                     * x = 120 dir yani imlecin fotograf uzerindeki durdugu yer                    
                    ayni islem y icinde gecerli
                     */
                    int fark_y = res_y * int.Parse(y) / pic_y;//içler dıslar caroımı

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
                    //fırca boyutları yapıcam orda bu sekil işime yarıyacak (dongu ile yap)
                    pictureBox1.Image = bmp;





                }
            }
            catch
            {

            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }
       bool cizim = false;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            cizim = true;
        }
     
        private void button1_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Image.Save(@"C:\Users\sadik\Desktop\"+"asdasd.png");
        }

        //mouse sol click tıkladıktan sonra clickten elini cekince olacaklar
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            cizim = false;
        }
    }
}
