using System.Drawing;
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows;
using Size = System.Drawing.Size;

namespace ColorLib
{
    public class PictureConverter
    {
        public int Boundary { get; set; } = 128;
        public int Height { get; set; }
        public int Width { get; set; }

        public void Resize(string imgPath, string pathOutputs, int[] size) //Resize all files in path
        {
            Bitmap img = new Bitmap(imgPath);            
            var resizeimg = new Bitmap(img, new Size(size[0], size[1]));
            resizeimg.Save($"{pathOutputs}");                      
        }

        public void Resize(string[] pathImgs, string pathOutputs, int[] size) //Resize all files in path
        {
            for (int i = 0; i < pathImgs.Length; i++)
            {
                Bitmap img = new Bitmap(pathImgs[i]);
                
                var resizeimg = new Bitmap(img, new Size(size[0], size[1]));
                resizeimg.Save($"{pathOutputs}\\img{i}.png");
            }
        }



        public double[] ConvertInDouble(Bitmap img)
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


        #region override Grayer
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
                    try
                    {
                        Color pixel = image.GetPixel(x, y);
                        double YY = 0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B;
                        int Y = Convert.ToInt32(YY);

                        newImage.SetPixel(x, y, Color.FromArgb(Y, Y, Y));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
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
        #endregion
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
                        resizeImage.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        resizeImage.SetPixel(x, y, Color.White);
                    }

                }
            }

            return resizeImage;
        }

        #region BW override
        public void BW(string inputFile, string outPath)
        {
            var img = new Bitmap(inputFile);
            var newImg = new Bitmap(img.Width, img.Height);

            for (int y = 0; y < newImg.Height; y++)
            {
                for (int x = 0; x < newImg.Width; x++)
                {
                    var pixel = img.GetPixel(x, y);
                    var value = Brightness(pixel);
                    if (value == 0)
                    {
                        newImg.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        newImg.SetPixel(x, y, Color.White);
                    }

                }
            }
            newImg.Save(outPath);
        }
        public void BW(string[] inputFiles, string outPath)
        {
            for (int i = 0; i < inputFiles.Length; i++)
            {
                var img = new Bitmap(inputFiles[i]);
                var newImg = new Bitmap(img.Width, img.Height);
                for (int y = 0; y < newImg.Height; y++)
                {
                    for (int x = 0; x < newImg.Width; x++)
                    {
                        var pixel = img.GetPixel(x, y);
                        var value = Brightness(pixel);
                        if (value == 0)
                        {
                            newImg.SetPixel(x, y, Color.Black);
                        }
                        else
                        {
                            newImg.SetPixel(x, y, Color.White);
                        }

                    }
                }
                newImg.Save(outPath);
            }
        }
        public void BW(string inputFile, string outPath, int[] size)
        {
            var img = new Bitmap(inputFile);
            var newImg = new Bitmap(size[0], size[1]);

            for (int y = 0; y < newImg.Height; y++)
            {
                for (int x = 0; x < newImg.Width; x++)
                {
                    var pixel = img.GetPixel(x, y);
                    var value = Brightness(pixel);
                    if (value == 0)
                    {
                        newImg.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        newImg.SetPixel(x, y, Color.White);
                    }

                }
            }
            newImg.Save(outPath);
        }
        public void BW(string[] inputFiles, string outPath, int[] size)
        {
            for (int i = 0; i < inputFiles.Length; i++)
            {
                var img = new Bitmap(inputFiles[i]);
                var newImg = new Bitmap(size[0], size[1]);
                for (int y = 0; y < newImg.Height; y++)
                {
                    for (int x = 0; x < newImg.Width; x++)
                    {
                        var pixel = img.GetPixel(x, y);
                        var value = Brightness(pixel);
                        if (value == 0)
                        {
                            newImg.SetPixel(x, y, Color.Black);
                        }
                        else
                        {
                            newImg.SetPixel(x, y, Color.White);
                        }

                    }
                }
                newImg.Save(outPath);
            }
        }
        #endregion
        
        //Delete
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

        public void Change(string inPath, string OutPath)
        {
            

            //var result = new List<double>();

            var image = new Bitmap(inPath);
            Height = image.Height;
            Width = image.Width;
            image = new Bitmap(image, new Size(Width,Height));
            var newImage = new Bitmap(Width, Height);

            image = WhiteBorder(image);

            for (int x = 0; x < image.Height; x++)
                for (int y = 0; y < image.Width; y++)
                {
                    var pixel = image.GetPixel(y,x);
                    if (pixel == Color.White)
                        continue;
                    else
                    {
                        if (pixel == Color.FromArgb(0, 0, 0))
                        {
                            newImage.SetPixel(y, x, Color.FromArgb(200, 200, 200));
                            newImage.SetPixel(y - 1, x, Color.FromArgb(200, 200, 200));
                            newImage.SetPixel(x,y - 1, Color.FromArgb(200, 200, 200));
                            newImage.SetPixel(x + 1, y, Color.FromArgb(200, 200, 200));
                            newImage.SetPixel(y, x + 1, Color.FromArgb(200, 200, 200));
                        }
                        else
                        {
                            newImage.SetPixel(y,x, pixel);
                        }
                    }



                }


            image.Save(OutPath);
        }

        public void Change(string[] inPathFiles, string OutPath)
        {
            /*Height = size[0];
            Width = size[1];*/

            //var result = new List<double>();
            for (int i = 0; i < inPathFiles.Length; i++)
            {
                var image = new Bitmap(inPathFiles[i]);
                var newImage = new Bitmap(image.Height, image.Width);

                image = WhiteBorder(image);

                for (int y = 0; y < image.Height; y++)
                    for (int x = 0; x < image.Width; x++)
                    {
                        var pixel = image.GetPixel(x, y);
                        if (pixel == Color.White)
                            continue;
                        else
                        {
                            if (pixel == Color.FromArgb(0, 0, 0))
                            {
                                newImage.SetPixel(x, y, Color.FromArgb(200, 200, 200));
                                newImage.SetPixel(x - 1, y, Color.FromArgb(200, 200, 200));
                                newImage.SetPixel(x, y - 1, Color.FromArgb(200, 200, 200));
                                newImage.SetPixel(x + 1, y, Color.FromArgb(200, 200, 200));
                                newImage.SetPixel(x, y + 1, Color.FromArgb(200, 200, 200));
                            }
                            else
                            {
                                newImage.SetPixel(x, y, pixel);
                            }
                        }
                    }
                image.Save(OutPath);
            }
            
        }

        /// <summary>
        /// Делает рамки изображения белыми
        /// </summary>
        /// <param name="image">Изображение Bitmap</param>
        /// <returns></returns>

        private Bitmap WhiteBorder(Bitmap image)
        {
            
            Bitmap whiteImage = new Bitmap(image,image.Width, image.Height);
            for (int x = 0; x < whiteImage.Height - 1; x++)
                for (int y = 0; y < whiteImage.Width - 1; y++)
                {
                    var pixel = whiteImage.GetPixel(y,x);
                    if ((x == 0 & (0 <= y - 1 & y <= Width - 1)) | (x == Height - 1 & (0 <= y & y <= Width - 1)) | (y == 0 & (0 <= x & x <= Width - 1)) | (y == Width - 1 & (0 <= x & x <= Width - 1)))
                    {
                        var white = Color.White;
                        whiteImage.SetPixel(y,x, white);
                    }
                    else
                    {
                        whiteImage.SetPixel(y,x, pixel);
                    }
                }

            return whiteImage;
        }

    }
}
