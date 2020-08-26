using Microsoft.AspNetCore.Mvc;

namespace EderSilva.ProjetoEstudoBoilerPlate.Web.Controllers
{
    public class HomeController : ProjetoEstudoBoilerPlateControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}