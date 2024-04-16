using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public  class Venta
    {
        public static Dictionary<string, object> GetAll()
        {
            ML.Venta vent = new ML.Venta();
            string excepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Venta", vent }, { "Exepcion", excepcion }, { "Resultado", false } };

            try
            {
                using (DL.CoteroMaquinaExpContext context = new DL.CoteroMaquinaExpContext())

                {
                    var registros = (from Venta in context.Venta
                                     join Alimento in context.Alimentos on Venta.IdAlimento equals Alimento.IdAlimento
                                     join Usuario in context.Usuarios on Venta.IdUsuario equals Usuario.IdUsuario
                                     select new
                                     {
                                         IdVenta = Venta.IdVenta,
                                         Fecha = Venta.Fecha,
                                         Nombre = Usuario.Nombre,
                                         ApellidoPaterno = Usuario.ApellidoPaterno,
                                         ApellidoMaterno = Usuario.ApellidoMaterno,
                                         Alimento = Alimento.Nombre,
                                         Precio = Alimento.Precio,
                                         MontoIngresado = Venta.MontoIngresado

                                     }).ToList();

                    if (registros != null)
                    {
                        vent.Ventas = new List<Object>();
                        foreach (var registro in registros)
                        {
                            //Instanciar el objeto
                            ML.Venta venta = new ML.Venta();

                            venta.IdVenta = registro.IdVenta;
                            venta.Fecha = registro.Fecha;
                            venta.Usuario = new ML.Usuario();
                            venta.Usuario.Nombre = registro.Nombre;
                            venta.Usuario.ApellidoPaterno = registro.ApellidoPaterno;
                            venta.Usuario.ApellidoMaterno = registro.ApellidoMaterno;

                            venta.Alimento = new ML.Alimento(); 
                            venta.Alimento.Nombre = registro.Alimento;
                            venta.Alimento.Precio = registro.Precio;
                            venta.MontoIngresado = registro.MontoIngresado;


                            vent.Ventas.Add(venta);
                        }
                        diccionario["Resultado"] = true;
                        diccionario["Usuario"] = vent;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }


        public static Dictionary<string, object> Add(ML.Venta venta)
        {

            venta.Fecha= DateTime.Now;

            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Excepcion", "" }, { "Resultado", false } };

            try
            {
                //AQUI CAMBIA EL USING A DL
                using (DL.CoteroMaquinaExpContext context = new DL.CoteroMaquinaExpContext())
                {

                    //AQUI CAMBIA LA SENTENCIA PARA LLAMAR AL STORE PROCEDURE
                    var filasAfectadas = context.Database.ExecuteSqlRaw($"AddVenta '{venta.Fecha}', '{venta.MontoIngresado}','{venta.Usuario.IdUsuario}','{venta.Alimento.IdAlimento}'");

                    //Validar si las filas fueron afectadas
                    if (filasAfectadas > 0)
                    {
                        diccionario["Resultado"] = true;
                    }
                    else
                    {
                        diccionario["Resultado"] = false;
                    }
                }
            }
            catch (Exception ex) //SI FALLÓ ALGO
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;

            }
            return diccionario;
        }
    }
}
