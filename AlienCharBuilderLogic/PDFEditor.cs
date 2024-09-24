using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace AlienCharBuilderLogic
{
    public class PDFEditor
    {
        public static void InsertPicture(PdfDocument document, string pictureFile)
        {
            var page = document.Pages[0];

            using (XGraphics gfx = XGraphics.FromPdfPage(page))
            {
                int sigPosY = 100;
                int sigPosX = 100;

                gfx.DrawImage(XImage.FromFile(pictureFile), sigPosX, sigPosY, 340, 340);
            }
        }
    }
}
