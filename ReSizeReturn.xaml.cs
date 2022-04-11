using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для ReSizeReturn.xaml
    /// </summary>
    public partial class ReSizeReturn : Window
    {
        public int[] Size { get; set; }
        public ReSizeReturn()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (tbHeight.Text.Length != 0 & tbWidth.Text.Length != 0)
            {
                try { 
                    var width = Convert.ToInt32(tbWidth.Text);
                    var height = Convert.ToInt32(tbHeight.Text);

                    Size = new int[] { width, height };
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.Close();
        }
    }
}
