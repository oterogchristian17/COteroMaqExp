using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alimento
    {
        public static Dictionary<string, object> GetAll()
        {
            ML.Alimento prod = new ML.Alimento();
            string excepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Alimento", prod }, { "Exepcion", excepcion }, { "Resultado", false } };

            try
            {
                using (DL.CoteroMaquinaExpContext context = new DL.CoteroMaquinaExpContext())

                {
                    var registros =

                    //LINQ

                    (from Alimento in context.Alimentos
                     select new
                     {
                         IdAlimento = Alimento.IdAlimento,
                         Nombre = Alimento.Nombre,
                         Precio = Alimento.Precio

                     }).ToList();

                    if (registros != null)
                    {
                        prod.Alimentos = new List<Object>();
                        foreach (var registro in registros)
                        {
                            //Instanciar el objeto
                            ML.Alimento producto = new ML.Alimento();

                            producto.IdAlimento = registro.IdAlimento;
                            producto.Nombre = registro.Nombre;
                            producto.Precio = registro.Precio;

                            prod.Alimentos.Add(producto);
                        }
                        diccionario["Resultado"] = true;
                        diccionario["Usuario"] = prod;
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

        public static Dictionary<string, object> GetById(int idAlimento)
        {
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Excepcion", "" }, { "Resultado", false }, { "Alimento", null } };

            try
            {
                //AQUI CAMBIA EL USING A DL
                using (DL.CoteroMaquinaExpContext context = new DL.CoteroMaquinaExpContext())
                {

                    var registros = (from alimento in context.Alimentos
                                     where alimento.IdAlimento == idAlimento
                                     select new
                                     {
                                         IdAlimento = alimento.IdAlimento,
                                         Nombre = alimento.Nombre,
                                         Precio = alimento.Precio

                                     }).FirstOrDefault();

                    if (registros != null)
                    {
                        ML.Alimento alimento1 = new ML.Alimento();

                        alimento1.IdAlimento = registros.IdAlimento;
                        alimento1.Nombre = registros.Nombre;
                        alimento1.Precio = registros.Precio;

                        diccionario["Resultado"] = true;
                        diccionario["Alimento"] = alimento1;
                    }
              
                    else
                {

                }
            }
            }
            catch (Exception ex)
            {
                diccionario["Excepcion"] = ex;

            }
            return diccionario;
        }

    }
}
