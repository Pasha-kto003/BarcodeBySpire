using Spire.Barcode;
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

namespace BarcodeBySpire
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnBarcodeClick(object sender, RoutedEventArgs e)
        {
            BarcodeSettings bs = new BarcodeSettings();

            bs.Type = BarCodeType.Code39;
            bs.Data = txtBarcode.Text;
            
            BarCodeGenerator generator = new BarCodeGenerator(bs);

            generator.GenerateImage().Save(@"C:\Users\User\source\repos\BarcodeBySpire\BarcodeBySpire\Code39Code.png");
            System.Drawing.Image image = generator.GenerateImage();
            pictureBox.Source = ConvertDrawingImageToWPFImage(image);
            string[] textArray = BarcodeScanner.Scan(@"C:\Users\User\source\repos\BarcodeBySpire\BarcodeBySpire\Code39Code.png", BarCodeType.Code39);
            scanBarcode.Text = textArray.ToString();
        }

        private ImageSource ConvertDrawingImageToWPFImage(System.Drawing.Image gdiImg)
        {
            Image img = new Image();

            //convert System.Drawing.Image to WPF image
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(gdiImg);
            IntPtr hBitmap = bmp.GetHbitmap();
            ImageSource WpfBitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            img.Source = WpfBitmap;
            img.Width = 403;
            img.Height = 145;
            img.Stretch = Stretch.Fill;
            return WpfBitmap;
        }
    }
}
