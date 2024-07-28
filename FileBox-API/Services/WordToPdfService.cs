using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using FileBox_API.Interfaces;

namespace FileBox_API.Services
{
    public class WordToPdfService : IWordToPdfService
    {
        public string ConvertWordToPdf(string path)
        {
            string pdfPath = Path.ChangeExtension(path, ".pdf");

            using (FileStream docStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (WordDocument wordDocument = new WordDocument(docStream, FormatType.Automatic))
                {
                    using (DocIORenderer renderer = new DocIORenderer())
                    {
                        using (PdfDocument pdfDocument = renderer.ConvertToPDF(wordDocument))
                        {
                            using (FileStream pdfStream = new FileStream(pdfPath, FileMode.Create, FileAccess.Write))
                            {
                                pdfDocument.Save(pdfStream);
                            }
                        }
                    }
                }
            }

            return pdfPath;
        }
    }
}
