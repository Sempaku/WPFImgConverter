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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class PreviewResult : Window
    {
        public byte? WindowResult { get; set; } = null; // 0 - No ||| 1 - Yes
        public string ImagePath { get; set; } = null;
        public PreviewResult(string pathImg)
        {
            InitializeComponent();
            ImagePath = pathImg;
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            WindowResult = 1;
            
            PreviewWindow pv = new PreviewWindow(ImagePath);
            pv.Show();
            this.Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            WindowResult = 0;
            this.Close();
        }
    }
}
