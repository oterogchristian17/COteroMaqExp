using Microsoft.AspNetCore.Mvc;
using ML;

namespace PL.Controllers
{
    public class MaquinaController : Controller
    {

        public IActionResult MaquinaExpendedora()
        {
            Dictionary<string, object> resultado = BL.Alimento.GetAll();
            bool correct = (bool)resultado["Resultado"];
            if (correct)
            {
                ML.Alimento producto = (ML.Alimento)resultado["Alimento"];
                return View(producto);
            }
            return View();

        }

        [HttpGet]
        public ActionResult Carrito()
        {
            string productos = HttpContext.Session.GetString("Carrito");
            ML.Carrito carrito = new ML.Carrito();
            if (productos == null)
            {
                return View(carrito);
            }
            else
            {
                var ventaSession = Newtonsoft.Json.JsonConvert.DeserializeObject<List<object>>(HttpContext.Session.GetString("Carrito"));
                carrito.Productos = new List<object>();
                foreach (var obj in ventaSession)
                {
                    ML.Alimento objProducto = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Alimento>(obj.ToString());
                    carrito.Productos.Add(objProducto);
                }
                return View(carrito);
            }
        }

        [HttpGet]
        public ActionResult AgregarProducto(int idAlimento)
        {
            bool existe = false;
            ML.Carrito carrito = new Carrito();
            carrito.Productos = new List<object>();

            //if (HttpContext.Session.GetString("Carrito") == null)
            //{
                Dictionary<string, object> resultado = BL.Alimento.GetById(idAlimento);
                ML.Alimento alimento = (ML.Alimento)resultado["Alimento"];

                alimento.Cantidad = 1;

                carrito = new ML.Carrito();
                carrito.Productos = new List<object>();

                carrito.Productos.Add(alimento);
                //Serializar el carrito
                //Crear una sesion
                HttpContext.Session.SetString("Carrito", Newtonsoft.Json.JsonConvert.SerializeObject(carrito.Productos));

                return RedirectToAction("Carrito");
          
            }

        [HttpPost]
        public IActionResult AddVenta(ML.Venta venta)
        {
            Dictionary<string, object> resultado = BL.Venta.Add(venta);
            bool result = (bool)resultado["Resultado"];
            if (result)
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest((string)resultado["Resultado"]);
            }
        }



        //[HttpGet]
        //CalcularBilletesYMonedas
    }



    }






//}
//else
//{

//    Dictionary<string, object> resultado = BL.Alimento.GetById(idAlimento);
//    ML.Alimento alimento = (ML.Alimento)resultado["Alimento"];

//    alimento.Cantidad = 1;

//    carrito = new ML.Carrito();
//    carrito.Productos = new List<object>();

//    carrito.Productos.Add(alimento);
//    //Serializar el carrito
//    //Crear una sesion
//    HttpContext.Session.SetString("Carrito", Newtonsoft.Json.JsonConvert.SerializeObject(carrito.Productos));

//    return RedirectToAction("Carrito");

//var carritoSession = Newtonsoft.Json.JsonConvert.DeserializeObject<List<object>>(HttpContext.Session.GetString("Carrito"));
//foreach (var producto in carritoSession)
//{
//    ML.Alimento producto1 = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Alimento>(producto.ToString());
//    carrito.Productos.Add(producto1);
//}
//foreach (ML.Alimento product in carrito.Productos)
//{
//    if (idAlimento == product.IdAlimento)
//    {
//        existe = true;
//        //Aumentar cantidad
//        product.Cantidad += 1;
//        break;
//    }
//    else
//    {
//        existe = false;
//        //Lo tengo que agregar
//    }
//}
//if (existe == false)
//{

//    Dictionary<string, object> resultProducto = BL.Alimento.GetById(idAlimento);
//    ML.Alimento productoObj = (ML.Alimento)resultProducto["Alimento"];
//    productoObj.Cantidad = 1;
//    carrito.Productos.Add(productoObj);
//    HttpContext.Session.SetString("Carrito", Newtonsoft.Json.JsonConvert.SerializeObject(carrito.Productos));
//}
//else
//{
//    HttpContext.Session.SetString("Carrito", Newtonsoft.Json.JsonConvert.SerializeObject(carrito.Productos));
//}
//return RedirectToAction("Carrito");