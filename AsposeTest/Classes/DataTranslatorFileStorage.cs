using AsposeTest.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;
using System.Threading.Tasks;
using System;
using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;

namespace AsposeTest.Classes
{
    public class DataTranslatorFileStorage : IDataTranslatorFileStorage
    {
        private readonly ILogger<DataTranslatorFileStorage> _logger;

        public DataTranslatorFileStorage( ILogger<DataTranslatorFileStorage> logger)
        {           
            _logger = logger;
        }
        public async Task<string> SavePDFFile(string htmlResponse)
        {
            string htmlString = @" <!DOCTYPE html>             <html lang=""""en"""">            
 <head>      
           <meta charset=""""UTF-8"""">                 <meta name=""""viewport"""" content=""""width=device-width, initial-scale=1.0"""">                 <title>Embed PDF</title>         
    </head>     
   <body>                 <h1>Embedded PDF Example</h1>          <embed src='C:\Temp\PGDX\test.pdf' type=""""application/pdf"""" >  <br /><br /> <span>More data, more data. </span>  <br /><br />    </body>             </html>         ";



            var FileFaultHandleRetryDelay = 5;
            var FileFaultHandleRetryCount = 5;
            try
            {
              //  var retryStrategy = new FixedInterval(FileFaultHandleRetryCount, TimeSpan.FromMilliseconds(FileFaultHandleRetryDelay));
             //   RetryPolicy retryPolicy = new RetryPolicy<FileTransientErrorDetectionStrategy>(retryStrategy);

                using (var pdfWriter = new PDFContentWriter())
                {
                    await pdfWriter.WritePDFContent(htmlString, @"D:\\Users\\vrajput\\Downloads\\Test\\test.pdf");
                    // await retryPolicy.ExecuteAsync(async () => await pdfWriter.WritePDFContent(htmlString, @"D:\\Users\\vrajput\\Downloads\\Test\\test.pdf")); // exceutes aysnchronously based on the retry policy defined
                }
            }
            catch (Exception ex)
            {
               
            }
           
            return htmlResponse;
        }
        /// <summary>
        /// Method defined for error detection strategy for transient fault handling
        /// </summary>
        internal class FileTransientErrorDetectionStrategy : ITransientErrorDetectionStrategy
        {
            public bool IsTransient(Exception ex)
            {
                if (ex is IOException)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
