using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using PdfiumViewer;

namespace PdfHogeWpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        string path = "sample.pdf";
        const int dpi = 96 * 2;
        const int ppi = 72;
        int pageNum = 0;
        BitmapSource bitmapSource;
        using (PdfDocument doc = PdfDocument.Load(path))
        {
            SizeF pageSize = doc.PageSizes[pageNum];
            int width = (int) (pageSize.Width * dpi / ppi);
            int height = (int) (pageSize.Height * dpi / ppi);
            Bitmap bitmap = (Bitmap) doc.Render(pageNum, width, height, dpi, dpi, false);
            nint hBitmap = bitmap.GetHbitmap();
            bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(
                hBitmap, 
                nint.Zero, 
                Int32Rect.Empty, 
                BitmapSizeOptions.FromEmptyOptions());
        }
        image.Source = bitmapSource;
        this.Height = bitmapSource.Height;
        this.Width = bitmapSource.Width;
    }
}