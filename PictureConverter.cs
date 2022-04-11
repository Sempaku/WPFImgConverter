using System.Drawing;
using System;
using System.IO;
using System.Collections.Generic;

namespace ColorLib
{
    public class PictureConverter
    {
        public int Boundary { get; set; } = 128;
        public int Height { get; set; }

        internal void Resize(string pathImgs, string pathOutputs, int[] size) //Resize all files in path
        {
            
            string[] files = Directory.GetFiles(pathImgs);
            for(int i = 0; i < files.Length; i++)
            {
                Bitmap img = new Bitmap(files[i]);
                Console.WriteLine($"Take {i+1} img {files[i]} ");
                var resizeimg =new Bitmap(img, new Size(20,20));
                resizeimg.Save($"{pathOutputs}\\img{i}.png");
                Console.WriteLine($"{i+1} Img {files[i]} saved");
            }
        }

        public int Width { get; set; }


        public double[] Convert(Bitmap img)
        {
            var result = new List<double>();

            var image = new Bitmap(img);
            var resizeImage = new Bitmap(image, new Size(15, 15));


            Height = resizeImage.Height;
            Width = resizeImage.Width;

            for (int y = 0; y < resizeImage.Height; y++)
            {
                for (int x = 0; x < resizeImage.Width; x++)
                {
                    var pixel = resizeImage.GetPixel(x, y);
                    var value = Brightness(pixel);
                    result.Add(value);

                }
            }

            return result.ToArray();
        }

        private int Brightness(Color pixel)
        {
            var result = 0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B;

            return result < Boundary ? 0 : 1;

        }

        public void Save(string path, double[] pixels)
        {
            var image = new Bitmap(Width, Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    var color = pixels[y * Width + x] == 1 ? Color.White : Color.Black;
                    image.SetPixel(x, y, color);

                }
            }
            image.Save(path);
        }
    }
}
