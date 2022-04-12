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
        public byte? flag { get; set; } = null ; // 0 - path ||| 1 - file
        public int[] Size { get; set; }
        PictureConverter pictureConverter = new PictureConverter();
        


        public MainWindow()
        {
            InitializeComponent();
        }

        #region Menu-->General buttons
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
        #endregion


        #region Button event
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
                pictureConverter.Grayer(inputFile, outPath);
                MessageBox.Show("Finish!");

            }
            else if(flag == 1)
            {
                var inputFile = PathImage;
                string outPath = "";

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PNG|*.png|JPG|*.jpg|BMP|*.BMP";
                sfd.AddExtension = true;
                sfd.DefaultExt = "png";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    outPath = sfd.FileName;

                MessageBox.Show("Wait...");
                pictureConverter.Grayer(inputFile, outPath);
                MessageBox.Show("Finish!");
                
            }
            else
                MessageBox.Show("Выберите файл или папку");
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
                pictureConverter.Grayer(inputFile, outPath, Size);
                MessageBox.Show("Finish!");

            }
            else if (flag == 1)
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

                pictureConverter.Grayer(inputFile, outPath, Size);

                MessageBox.Show("Finish!");
            }
            else
                MessageBox.Show("Выберите файл или папку");
        }

        private void btnGoResize_Click(object sender, RoutedEventArgs e)
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
                pictureConverter.Resize(inputFile, outPath, Size);
                MessageBox.Show("Finish!");

            }
            else if (flag == 1)
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

                pictureConverter.Resize(inputFile, outPath, Size);

                MessageBox.Show("Finish!");

                PreviewResult pv = new PreviewResult(outPath);
                pv.ShowDialog();

            }
            else
                MessageBox.Show("Выберите файл или папку");
        }

        private void btnGoBlackWhite_Click(object sender, RoutedEventArgs e)
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
                pictureConverter.BW(inputFile, outPath);
                MessageBox.Show("Finish!");

            }
            else if (flag == 1)
            {
                var inputFile = PathImage;
                string outPath = "";

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PNG|*.png|JPG|*.jpg|BMP|*.BMP";
                sfd.AddExtension = true;
                sfd.DefaultExt = "png";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    outPath = sfd.FileName;

                MessageBox.Show("Wait...");
                pictureConverter.BW(inputFile, outPath);
                MessageBox.Show("Finish!");
            }
            else
                MessageBox.Show("Выберите файл или папку");
        }

        private void btnGoBlackWhiteWithResize_Click(object sender, RoutedEventArgs e)
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
                pictureConverter.BW(inputFile, outPath, Size);
                MessageBox.Show("Finish!");

            }
            else if (flag == 1)
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
                pictureConverter.BW(inputFile, outPath, Size);
                MessageBox.Show("Finish!");
            }
            else
                MessageBox.Show("Выберите файл или папку");
        }

        private void btnGoChange_Click(object sender, RoutedEventArgs e)
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
                pictureConverter.Change(inputFile, outPath);
                MessageBox.Show("Finish!");

            }
            else if (flag == 1)
            {
                var inputFile = PathImage;
                string outPath = "";

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PNG|*.png|JPG|*.jpg|BMP|*.BMP";
                sfd.AddExtension = true;
                sfd.DefaultExt = "png";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    outPath = sfd.FileName;

                MessageBox.Show("Wait...");
                pictureConverter.Change(inputFile, outPath);
                MessageBox.Show("Finish!");
            }
            else
                MessageBox.Show("Выберите файл или папку");
        }

        #endregion


    }

    
}
