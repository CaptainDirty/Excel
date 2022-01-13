using Excel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Excel4ik = Microsoft.Office.Interop.Excel;

namespace Excel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new FormulasViewModel()
            {
                AlfaOgn = 24,
                Alfa1 = 1,
                Alfa2 = 0.2,
                C1 = 1,
                C2 = 8,
                X0 = 0.2,
                t1 = 900,
                t2 = 20,
                tmax = 40,
                AlfaRab = 500,
                AlfaNar = 100,
                Tolsh = 0.3
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(FormulasViewModel fvm)
        {
            Excel4ik.Application objExcel = null;
            Excel4ik.Workbook WorkBook = null;

            //try
            //{
            objExcel = new Excel4ik.Application();

            string fileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Book.xlsm");

            WorkBook = objExcel.Workbooks.Open(fileName, 0, false, 5, "", "", false, Excel4ik.XlPlatform.xlWindows, "", true, 0, true, false, false);

            Excel4ik.Worksheet WorkSheet = (Excel4ik.Worksheet)WorkBook.Sheets["Data"];
            WorkSheet.Range["B3"].Value2 = fvm.AlfaOgn;
            WorkSheet.Range["B4"].Value2 = fvm.Alfa1;
            WorkSheet.Range["B5"].Value2 = fvm.Alfa2;
            WorkSheet.Range["B7"].Value2 = fvm.C1;
            WorkSheet.Range["B8"].Value2 = fvm.C2;
            WorkSheet.Range["B9"].Value2 = fvm.X0;
            WorkSheet.Range["B11"].Value2 = fvm.t1;
            WorkSheet.Range["B12"].Value2 = fvm.t2;
            WorkSheet.Range["B13"].Value2 = fvm.tmax;
            WorkSheet.Range["B15"].Value2 = fvm.AlfaRab;
            WorkSheet.Range["B16"].Value2 = fvm.AlfaNar;
            WorkSheet.Range["B17"].Value2 = fvm.Tolsh;

            objExcel.GetType().InvokeMember("Run", System.Reflection.BindingFlags.Default | System.Reflection.BindingFlags.InvokeMethod,
            null, objExcel, new Object[] { "Оптимизация" });
            fvm.x1 = Math.Round(Convert.ToDouble(WorkSheet.Range["E5"].Value), 2);
            fvm.x2 = Math.Round(Convert.ToDouble(WorkSheet.Range["F5"].Value), 2);

            fvm.isShow = true;
            //}
            //catch
            //{

            //}
            return View(fvm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}