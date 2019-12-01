using System;
using System.Web.Mvc;

namespace SistemaAF.Controllers
{
    public class HomeController : Controller
    {
        //Vista principal es Dashboard
        [Authorize(Roles ="Admin,Operativo")]
        public ActionResult Index() => RedirectToAction("Dashboard");
        [Authorize(Roles = "Admin,Operativo")]
        public ActionResult Dashboard() => View();

        //Agregar todas las Vistas parciales
        [Authorize(Roles = "Admin,Operativo")]
        public PartialViewResult NationalsView() => PartialView();
        [Authorize(Roles = "Admin,Operativo")]
        public PartialViewResult Foreign() => PartialView();
        [Authorize(Roles = "Admin")]
        public PartialViewResult Users() => PartialView();

        public ActionResult GetFile(string name, string type, string asset)
        {
            var file = string.Format(@"//SCHI-FS1ZSH\Facility Share\10. IT\5. Desarrollo\TestingFiles\{0}\{1}\{2}.pdf",
                                    asset, type, name);
            try
            {
                return File(file, "application/pdf");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}