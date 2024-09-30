using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Diagnostics;

namespace AlienCharBuilderLogic
{
    public class PDFEditor
    {
        public static void InsertPicture(string fileWithPath, string pictureFile)
        {            
            var document = PdfReader.Open(fileWithPath, PdfDocumentOpenMode.Modify);
            var page = document.Pages[0];

            XGraphics gfx = XGraphics.FromPdfPage(page);
            DrawImage(gfx, pictureFile, 700, 100, 75, 75);

            document.Save(fileWithPath);

        }        

        private static void DrawImage(XGraphics gfx, string jpegSamplePath, int x, int y, int width, int height)
        {
            XImage image = XImage.FromFile(jpegSamplePath);            
            gfx.DrawImage(image, x, y, width, height);
        }
    }
}
