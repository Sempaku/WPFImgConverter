using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Forms;
using ColorLib;
using MessageBox = System.Windows.MessageBox;

namespace WPFConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string[] PathFiles { get; set; }
        public string PathImage { get; set; }
        public byte flag { get; set; } // 0 - path ||| 1 - file
        public int[] Size { get; set; }
        PictureConverter picConverter = new PictureConverter();
        DelBlack delBlack = new DelBlack();
        public MainWindow()
        {
            InitializeComponent();


        }

        private void MenuItem_Click_EnterPath(object sender, RoutedEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    PathFiles = Directory.GetFiles(fbd.SelectedPath);
                    var path = fbd.SelectedPath;
                    System.Windows.Forms.MessageBox.Show("Найдено файлов: " + PathFiles.Length.ToString(), "Message");
                    txtblcPathTo.Text = $"Путь: {path}";
                    flag = 0;
                }
            }
        }

        private void MenuItem_Click_EnterFile(object sender, RoutedEventArgs e)
        {


            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PathImage = ofd.FileName;
                System.Windows.MessageBox.Show("Добавлено изображение " + PathImage, "Message");
                txtblcPathTo.Text = $"Путь: {PathImage}";
                flag = 1;
            }
        }

        private void btnGoGray_Click(object sender, RoutedEventArgs e)
        {
            if (flag == 0)
            {
                var inputFile = PathFiles;
                string outPath = "";

                var fbd = new FolderBrowserDialog();
                DialogResult result = fbd.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    outPath = fbd.SelectedPath;
                }

                MessageBox.Show("Wait...");
                delBlack.Grayer(inputFile, outPath);
                MessageBox.Show("Finish!");

            }
            else
            {
                var inputFile = PathImage;
                string outPath = "";

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PNG|*.png|JPG|*.jpg|BMP|*.BMP";
                sfd.AddExtension = true;
                sfd.DefaultExt = "png";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    outPath = sfd.FileName;

                /*ReSizeReturn wndSize = new ReSizeReturn();
                wndSize.ShowDialog();
                if (!wndSize.Activate())
                    Size = wndSize.Size;*/

                MessageBox.Show("Wait...");

                delBlack.Grayer(inputFile, outPath);

                MessageBox.Show("Finish!");




            }
        }

        private void btnGoGrayWithResize_Click(object sender, RoutedEventArgs e)
        {
            if (flag == 0)
            {
                var inputFile = PathFiles;
                string outPath = "";

                var fbd = new FolderBrowserDialog();
                DialogResult result = fbd.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    outPath = fbd.SelectedPath;
                }

                ReSizeReturn wndSize = new ReSizeReturn();
                wndSize.ShowDialog();
                if (!wndSize.Activate())
                    Size = wndSize.Size;

                MessageBox.Show("Wait...");
                delBlack.Grayer(inputFile, outPath, Size);
                MessageBox.Show("Finish!");

            }
            else
            {
                var inputFile = PathImage;
                string outPath = "";

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PNG|*.png|JPG|*.jpg|BMP|*.BMP";
                sfd.AddExtension = true;
                sfd.DefaultExt = "png";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    outPath = sfd.FileName;

                ReSizeReturn wndSize = new ReSizeReturn();
                wndSize.ShowDialog();
                if (!wndSize.Activate())
                    Size = wndSize.Size;

                MessageBox.Show("Wait...");

                delBlack.Grayer(inputFile, outPath, Size);

                MessageBox.Show("Finish!");
            }
        }


    }
}
