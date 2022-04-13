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
    /// Логика взаимодействия для EnterGlitchStep.xaml
    /// </summary>
    public partial class EnterGlitchStep : Window
    {
        public int GlitchStep = 255;
        public EnterGlitchStep()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            int step = Convert.ToInt16(txtboxStep.Text);
            GlitchStep = step;
            if (step >= 0 & step <= 255)
                this.Close();
            else
                MessageBox.Show("Неверное значение");
        }
    }
}
