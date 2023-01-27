using Data.Context;
using Data.Models.Models;
using Data.ViewModels;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Document = iTextSharp.text.Document;

namespace Services.PDFServices
{
    public  class PDFService: IPDFService
    {
        public readonly CountriesContext context;
        

        public PDFService(CountriesContext context)
        {
            this.context = context;
            
        }

        public ActionResult PDfSample()
        {
            List<PDFViewModel> models = new List<PDFViewModel>();
            List<Country> countries = context.Countries.ToList();
            foreach (var country in countries)
            {
                CountryCharacteristic? countryCharacteristics = context.CountriesCharacteristics.Where(c => c.CountryId == country.Id).FirstOrDefault();
                PDFViewModel pDFViewModel = new PDFViewModel()
                {
                    CountryName = country.CountryName,
                    Population = countryCharacteristics?.Population??0,
                };
                models.Add(pDFViewModel);
                models.Sort((a,b)=>a.Population-b.Population);
                models.Reverse();
            }
            
           
            MemoryStream fs = new MemoryStream();
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            
            document.Open();
            PdfPTable table = new PdfPTable(2);
            foreach (var model in models)
            {
                table.AddCell(model.CountryName);
                table.AddCell($"{model.Population}");
              
            }
            
            document.Add(table);
            
            // Add a simple and wellknown phrase to the document in a flow layout manner  
            
            // Close the document  
            document.Close();
            // Close the writer instance  
            writer.Close();
            // Always close open filehandles explicity  
            
            FileStreamResult fileStream = new FileStreamResult(new MemoryStream(fs.ToArray()), "application/pdf");
            fileStream.FileDownloadName = "Statistics";
            return fileStream;
        }
    }
}
