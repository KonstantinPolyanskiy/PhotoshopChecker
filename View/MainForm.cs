using PhotoshopChecker.Service.Analyzer;
using PhotoshopChecker.Service.Analyzer.EXIF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoshopChecker.View
{
    public partial class MainForm : Form
    {
        JpegExifAnalyzer jpegExifAnalyzer = new JpegExifAnalyzer();
        PngExifAnalyzer pngExifAnalyzer = new PngExifAnalyzer();
        TifExifAnalyzer tifExifAnalyzer = new TifExifAnalyzer();


        public MainForm()
        {
            InitializeComponent();
        }

        private void SelectImageButton_Click(object sender, EventArgs e)
        {
            PhotoshopStatus photoshopStatus = PhotoshopStatus.Unknown;

            Helpers.ResultStatus resultStatus = Helpers.ResultStatus.Warning;

            string result = "неизвестный результат";

            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = Environment.SpecialFolder.Personal.ToString();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                // Выводим изображение в picture box
                ImagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                ImagePictureBox.Image = (Image)Image.FromFile(fileDialog.FileName);

                // Определяем формат файле и на основе него вызываем соотвествующий метод
                switch (Path.GetExtension(fileDialog.FileName).ToLower())
                {
                    case ".png":
                        photoshopStatus = pngExifAnalyzer.AnalyzeImage(fileDialog.FileName);
                        break;
                    case ".jpg":
                        photoshopStatus = jpegExifAnalyzer.AnalyzeImage(fileDialog.FileName);
                        break;
                    case ".tif":
                        photoshopStatus = tifExifAnalyzer.AnalyzeImage(fileDialog.FileName);
                        break;
                    default:
                        Helpers.SetFormattedResult("Неизвестный формат файла", ResultLabel, Helpers.ResultStatus.Warning);
                        break;
                }

                // В зависимости от того, был ли фотошоп определяем результат для вывода
                switch (photoshopStatus)
                {
                    case PhotoshopStatus.Unknown:
                        result = "не удалось определить редактирование";
                        resultStatus = Helpers.ResultStatus.Warning;
                        break;
                    case PhotoshopStatus.Original:
                        result = "редактирование не определено";
                        resultStatus = Helpers.ResultStatus.Good;
                        break;
                    case PhotoshopStatus.Photoshopped:
                        result = "файл был отредактирован";
                        resultStatus = Helpers.ResultStatus.Error;
                        break;
                }
            }

            Helpers.SetFormattedResult(result, ResultLabel, resultStatus);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
