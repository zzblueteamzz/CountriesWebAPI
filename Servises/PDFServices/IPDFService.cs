using Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PDFServices
{
    public   interface IPDFService
    {
        public ActionResult PDfSample();
    }
}
