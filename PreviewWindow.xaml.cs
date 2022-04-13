using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFConverter
{
    /// <summary>
    /// Логика взаимодействия для PreviewWindow.xaml
    /// </summary>
    public partial class PreviewWindow : Window
    {
        private int Width { get; set; }
        private int Height { get; set; }
        public PreviewWindow(string pathImg)
        {
            InitializeComponent();
            
            var img = new Bitmap(pathImg);
            Width = img.Width;
            Height = img.Height;
            prvWindow.Height = Height;
            prvWindow.Width = Width;
            prvCanvas.Height = Height;
            prvCanvas.Width = Width;


            cnvsImg.Source = new BitmapImage(new Uri(pathImg));
            cnvsImg.Height = prvCanvas.Height;
            cnvsImg.Width = prvCanvas.Height;
            cnvsImg.Stretch = Stretch.Fill;
        }
    }
}
