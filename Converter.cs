﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Picturegraphik
{
    class Converter
    {
        private readonly Bitmap _bitmap;
        private readonly char[] asciitableRev = { '@', '#', 'S', '%', '?', '*','+', ':', ',', '.' };
        private readonly char[] asciitable = { '.', ',', ':', '+', '*', '?', '%', 'S', '#', '@' };
        public Converter(Bitmap bitmap)
        {
            _bitmap = bitmap;
        }
        public char[][] ConvertRev()
        {
            return Convert(asciitableRev);
        }
        public char[][] Convert()
        {
            return Convert(asciitable);
        }

        public char[][] Convert(char [] asciitable)
        {
            var result = new char[_bitmap.Height][];
           
            for (int y = 0; y< _bitmap.Height; y++)
            {

                result[y] = new char[_bitmap.Width];
                
                for (int x = 0; x < _bitmap.Width; x++)
                {
                    //int mapIndex = (int)Map(_bitmap.GetPixel(x, y).G, 0, 255, 0, asciitable.Length - 1);
                    int mapIndex = (int)Map(_bitmap.GetPixel(x, y).R, 0, 255, 0, asciitable.Length - 1);
                    result[y][x] = asciitable[mapIndex];
                }

                    
            }
            return result;


        }
        private float Map(float valueTopMap, float start1, float stop1, float start2, float stop2)
        {
            return ((valueTopMap - start1) / (stop1 - start1) * (stop2 - start2) + start2);
        }
    }
}
