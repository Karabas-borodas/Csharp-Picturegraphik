using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Picturegraphik
{
    public static class Ext
    {
        public static void TogRaseScale(this Bitmap bitmap)
        {
            for (int y = 0; y <bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var pixel = bitmap.GetPixel(x, y);
                    int Avg = (pixel.R + pixel.B + pixel.G) / 3;
                    bitmap.SetPixel(x, y, Color.FromArgb (pixel.A, Avg, Avg, Avg));
                }

            }

        }
        
    }
}
