using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Csharp_Picturegraphik
{
    class Program
    {
        private const double Widse = 1.5;

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
                    Console.Write(row);

                }
                Console.SetCursorPosition(0,0);

               
            }
        }
        private static Bitmap Resize(Bitmap bitmap)
        {
            var MaxWidth = 350;
            var NewHight = bitmap.Height / Widse * MaxWidth / bitmap.Width;
            if (bitmap.Width > MaxWidth || bitmap.Height > NewHight)
                bitmap = new Bitmap(bitmap, new Size(MaxWidth, (int)NewHight));
            return bitmap;
        }
    }
}
