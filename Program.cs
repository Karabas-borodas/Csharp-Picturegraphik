using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Csharp_Picturegraphik
{
    class Program
    {
        private const double Widse = 1.5;
        private const int MAXWDTH =350;

        [STAThread]
        static void Main(string[] args)
        {
            
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Images | *.bmp; *.png; *.jpg; *.JPEG "
            };
            Console.WriteLine(" Pleas Press ENTER");
            while (true)
            {
                Console.ReadLine();
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    continue;
                Console.Clear();
                var bitmap = new Bitmap(openFileDialog.FileName);
                bitmap = Resize(bitmap);
                bitmap.TogRaseScale();

                var convert = new Converter(bitmap);
                var rows = convert.Convert();

                foreach (var row in rows)
                {
                    Console.WriteLine(row);
                    

                }
                File.WriteAllLines("img.txt",rows.Select(r=>new string(r)));
                Console.SetCursorPosition(0,0);

               
            }
        }
        private static Bitmap Resize(Bitmap bitmap)
        {
           
            var NewHight = bitmap.Height / Widse * MAXWDTH / bitmap.Width;
            if (bitmap.Width > MAXWDTH || bitmap.Height > NewHight)
                bitmap = new Bitmap(bitmap, new Size(MAXWDTH, (int)NewHight));
            return bitmap;
        }
    }
}
