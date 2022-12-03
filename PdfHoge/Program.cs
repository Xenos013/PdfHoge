using System.Drawing;
using PdfiumViewer;

string path = "sample.pdf";
const int dpi = 96;
const int ppi = 72;
using (PdfDocument doc = PdfDocument.Load(path))
{
    for (var pageNum = 0; pageNum < doc.PageCount; pageNum++)
    {
        SizeF pageSize = doc.PageSizes[pageNum];
        int width = (int) (pageSize.Width * dpi / ppi);
        int height = (int) (pageSize.Height * dpi / ppi);
        Image image = doc.Render(pageNum, width, height, dpi, dpi, false);
        image.Save($"image{pageNum + 1}.jpg");
    }
}