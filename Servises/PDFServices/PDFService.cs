using Data.Context;
using Data.Models.Models;
using Data.ViewModels;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PDFServices
{
    public class PDFService: IPDFService
    {
        public readonly CountriesContext context;
        

        public PDFService(CountriesContext context)
        {
            this.context = context;
            
        }
    
        //public ActionResult PDfSample()
        //{
        //    List<PDFViewModel> models = new List<PDFViewModel>();    
        //    List<Country> countries = context.Countries.ToList();
        //    foreach (var country in countries)
        //    {
        //        var countryCharacteristics = context.CountriesCharacteristics.Where(c => c.Population == c.Population).FirstOrDefault().Population;
        //        PDFViewModel pDFViewModel = new PDFViewModel()
        //        {
        //            CountryName = country.CountryName,
        //            Population = countryCharacteristics,
        //        };
        //        models.Add(pDFViewModel);
        //        models.Sort();
        //        models.Reverse();
        //    }
        //    MemoryStream fs=new MemoryStream();
        //    Document document = new Document(PageSize.A4, 25, 25, 30, 30);
        //    document.AddTitle("The country with the biggest population");
        //    PdfWriter writer = PdfWriter.GetInstance(document, fs);
        //    document.Open();
        //    // Add a simple and wellknown phrase to the document in a flow layout manner  
        //    document.Add(new Paragraph("Hello World!"));
        //    // Close the document  
        //    document.Close();
        //    // Close the writer instance  
        //    writer.Close();
        //    // Always close open filehandles explicity  
        //    fs.Close();
        //    return File(fs);
        //}
    }
}
