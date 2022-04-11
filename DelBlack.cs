using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace ColorLib
{
    public class DelBlack
    {
        public int Boundary { get; set; } = 128;
        public int Height { get; set; }
        public int Width { get; set; }


        public Bitmap Delete(Bitmap img)
        {
            var result = new List<double>();

            var image = new Bitmap(img);
            var resizeImage = new Bitmap(image, new Size(image.Width, image.Height));


            Height = resizeImage.Height;
            Width = resizeImage.Width;

            for (int y = 0; y < resizeImage.Height; y++)
            {
                for (int x = 0; x < resizeImage.Width; x++)
                {
                    var pixel = resizeImage.GetPixel(x, y);
                    var value = Blacker(pixel);
                    resizeImage.SetPixel(x, y, value);

                }
            }
            
            return resizeImage;
        }

        private Color Blacker(Color pixel)
        {
            var Y = 0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B;
            int x = 140;
            int y = 14;
            int z = 110;
            if (pixel.R <= x | pixel.G <= y | pixel.B <= z)
            {
                return Color.White;
            }
            else
            {
                return pixel;
            }

        }

        public void Grayer(string inPath, string outPath)//Grayer single img (no Resize)
        {
            
            var image = new Bitmap(inPath);
            var newImage = new Bitmap(image, new Size(image.Width, image.Height));

            for (int y = 0; y < newImage.Height; y++)
            {
                for (int x = 0; x < newImage.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    double YY = 0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B;
                    int Y = Convert.ToInt32(YY);

                    newImage.SetPixel(x, y, Color.FromArgb(Y, Y, Y));
                }
            }
            newImage.Save(outPath);

        }
        //override Grayer
        public void Grayer(string[] FileInPath, string outPath)//Grayer all path
        {
            for (int i = 0; i < FileInPath.Length; i++)
            {
                var image = new Bitmap(FileInPath[i]);
                var newImage = new Bitmap(image, new Size(image.Width, image.Height));
                for (int y = 0; y < newImage.Height; y++)
                {
                    for (int x = 0; x < newImage.Width; x++)
                    {
                        Color pixel = image.GetPixel(x, y);
                        double YY = 0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B;
                        int Y = Convert.ToInt32(YY);

                        newImage.SetPixel(x, y, Color.FromArgb(Y, Y, Y));
                    }
                }
                newImage.Save($"{outPath}\\{i}.png");
            }
        }

        public void Grayer(string inPath, string outPath, int[] size)//Grayer single img with Resize
        {

            var image = new Bitmap(inPath);
            var newImage = new Bitmap(image, new Size(size[0], size[1]));
            

            for (int y = 0; y < newImage.Height; y++)
            {
                for (int x = 0; x < newImage.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    double YY = 0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B;
                    int Y = Convert.ToInt32(YY);

                    newImage.SetPixel(x, y, Color.FromArgb(Y, Y, Y));
                }
            }
            newImage.Save(outPath);
        }

        public void Grayer(string[] FileInPath, string outPath, int[] size)//Grayer all path
        {
            for (int i = 0; i < FileInPath.Length; i++)
            {
                var image = new Bitmap(FileInPath[i]);
                var newImage = new Bitmap(image, new Size(size[0], size[1]));
                for (int y = 0; y < newImage.Height; y++)
                {
                    for (int x = 0; x < newImage.Width; x++)
                    {
                        Color pixel = image.GetPixel(x, y);
                        double YY = 0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B;
                        int Y = Convert.ToInt32(YY);

                        newImage.SetPixel(x, y, Color.FromArgb(Y, Y, Y));
                    }
                }
                newImage.Save($"{outPath}\\{i}.png");
            }
        }

        public void GoVio(string pathIn, string pathOut)
        {
            var files = Directory.GetFiles(pathIn);
            for (int i = 0; i < files.Length; i++)
            {
                var img = new Bitmap(files[i]);
                var newImg = Violetted(img);
                newImg.Save($"{pathOut}\\{i}.png");
            }
        }
        public Bitmap Violetted(Bitmap img)
        {
            var image = new Bitmap(img);
            var resize = new Bitmap(image, new Size(image.Width, image.Height));

            Height = resize.Height;
            Width = resize.Width;
            var flag = false;
            for (int y = 0; y < resize.Height; y++)
            {
                for (int x = 0; x < resize.Width; x++)
                {
                    var pixel = resize.GetPixel(x, y);

                    if ((141 <= pixel.R & pixel.R <= 161) & (15 <= pixel.G & pixel.G <= 33) & (110 <= pixel.B & pixel.B <= 116))
                    {
                        flag = true;
                        var whiteImage = Delete(image);
                        resize = Convertt(whiteImage);
                        return resize;
                        
                    }
                    else
                    {
                        resize.SetPixel(x, y, Color.White);
                    }
                    

                }

            }
            
            return resize;
            

        }

        public Bitmap Convertt(Bitmap img)
        {
            var result = new List<double>();

            var image = new Bitmap(img);
            var resizeImage = new Bitmap(image, new Size(image.Width, image.Height));


            Height = resizeImage.Height;
            Width = resizeImage.Width;

            for (int y = 0; y < resizeImage.Height; y++)
            {
                for (int x = 0; x < resizeImage.Width; x++)
                {
                    var pixel = resizeImage.GetPixel(x, y);
                    var value = Brightness(pixel);
                    if (value == 0)
                    {
                        resizeImage.SetPixel(x,y,Color.Black);
                    }
                    else
                    {
                        resizeImage.SetPixel(x, y, Color.White);
                    }

                }
            }

            return resizeImage;
        }

        private int Brightness(Color pixel)
        {
            var result = 0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B;

            return result < Boundary ? 0 : 1;

        }


    }
}
