using Serilog;
using System;
using System.IO;

namespace AsposeTest
{
    public class SetLicense
    {
        public static void Run()
        {
            // Set license for all APIs one by one
            // Initialize license object
            Aspose.Pdf.License pdfLicense = new Aspose.Pdf.License();
           
            try
            {
                var PDFLicenseName = "Aspose.PDF.NET.lic";               

                var PDFlicensePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, PDFLicenseName);
               

                // Set license
                pdfLicense.SetLicense(PDFlicensePath);
               
            }
            catch (Exception ex)
            {
                Log.Error($"License Initialization failed with exception - {ex}");
                throw new ArgumentNullException($"Initializing License Failed with Message - {ex.Message}");
            }
        }
    }
}
