
using System.Collections.Generic;
using System.IO;

using System.Text;
using System.Threading.Tasks;
using System;
using Aspose.Pdf;
using System.Drawing.Printing;

namespace AsposeTest.Classes
{
    public class PDFContentWriter : IDisposable
    {
        private bool disposedValue;

        public async Task WritePDFContent(string htmlBody, string pdfFilePath)
        {

            #region ASPSOSE.PDF


            HtmlLoadOptions HtmlLoadoptions = new HtmlLoadOptions();

            // set the PageInfo,in Aspose.Pdf 1 inch = 72 points

            HtmlLoadoptions.PageInfo.Margin.Bottom = 0;
            HtmlLoadoptions.PageInfo.Margin.Top = 0;
            HtmlLoadoptions.PageInfo.Margin.Left = 6;
            HtmlLoadoptions.PageInfo.Margin.Right = 6;

            HtmlLoadoptions.PageInfo.IsLandscape = false;

           
            //8.5 x 11 US site reports only
            HtmlLoadoptions.PageInfo.Height = 792;
            HtmlLoadoptions.PageInfo.Width = 612;
           

            // set the PageInfo,in Aspose.Pdf 1 inch = 72 points


            var pdfFileName = Path.GetFileName(pdfFilePath);
            var pdfFileDirectoryName = Path.GetDirectoryName(pdfFilePath);

            // Create Directory If Doesn't exists
            if (!Directory.Exists(Path.GetDirectoryName(pdfFilePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(pdfFilePath));
            }

           

            // Load HTML into new document
            // convert string to stream

            byte[] byteArray = Encoding.UTF8.GetBytes(htmlBody);
           
            using (var stream = new MemoryStream(byteArray))
            {
                using (Document doc = new Document(stream, HtmlLoadoptions))
                {
                    doc.Save(Path.Join(pdfFileDirectoryName, pdfFileName));                   
                }
               
               stream.Close();
            }
            byteArray = null;



            await Task.CompletedTask;

            #endregion

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~PDFContentWriter()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
