using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace AlienCharBuilderLogic
{
    public class PDFEditor
    {
        public static void InsertPicture(string fileWithPath, string pictureFile)
        {            
            var document = PdfReader.Open(fileWithPath, PdfDocumentOpenMode.Modify);
            var page = document.Pages[0];

            using (XGraphics gfx = XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Prepend))
            {
                int sigPosY = 100;
                int sigPosX = 100;
                using (var img = XImage.FromFile(pictureFile))
                {
                    gfx.DrawImage(img, sigPosX, sigPosY, 340, 340);
                }
            }
            document.Save(fileWithPath);

        }
    }
}
