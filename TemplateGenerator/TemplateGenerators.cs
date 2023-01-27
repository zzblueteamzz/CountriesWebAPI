using Services.PDFServices;
using System.Text;

namespace TemplateGenerator
{
    public class TemplateGenerators: ITemplateGenerators
    {
        public readonly IPDFService _iPDFService;
        public TemplateGenerators(IPDFService iPDFService)
        {
           _iPDFService = iPDFService;
        }

        public  string GetHTMLString()
        {

            
            var Country = _iPDFService.PDfSample();
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>This is the generated PDF report!!!</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Country</th>
                                        <th>Population</th>
                                       
                                    </tr>");
            foreach (var emp in Country)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                   
                                  </tr>", emp.CountryName, emp.Population);
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }
    }
}