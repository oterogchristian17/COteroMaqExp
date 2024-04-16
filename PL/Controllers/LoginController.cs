using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            Dictionary<string, object> diccionario = BL.Usuario.GetByUserNamePassword(username, password);
            bool resultado = (bool)diccionario["Resultado"];

            if (resultado == true)//el metodo funciono
            {
                ML.Usuario usuario = (ML.Usuario)diccionario["Usuario"];

                if (usuario.UserName == username && usuario.Password == password)
                {
                        return RedirectToAction("Index", "Home");   
                }
                else
                {
                    ViewBag.Mensaje = "El usuario y/o contraseña no son válidos";
                    return PartialView("Modal");
                }
            }
            else
            {
                ViewBag.Mensaje = "El usuario y/o contraseña no son válidos";
                return PartialView("Modal");
            }
            return View();

        }
    }
}
