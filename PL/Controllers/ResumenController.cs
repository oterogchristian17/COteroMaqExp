using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class ResumenController : Controller
    {
        public IActionResult ResumenCompras()
        {
            Dictionary<string, object> resultado = BL.Venta.GetAll();
            bool correct = (bool)resultado["Resultado"];
            if (correct)
            {
                ML.Venta venta = (ML.Venta)resultado["Venta"];
                return View(venta);
            }
            return View();
        }
    }
}
