using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Moneda
    {
        public static Dictionary<int, int> CalcularBilletesYMonedas(decimal cantidad)
        {


            Dictionary<int, int> resultado = new Dictionary<int, int>();

            Dictionary<int, int> denominacionesBilletes;
            Dictionary<int, int> denominacionesMonedas;

            denominacionesBilletes = new Dictionary<int, int>
            {

                { 100, 0 },
                { 50, 0 },

            };

            denominacionesMonedas = new Dictionary<int, int>
            {
                { 10, 0 },

            };

            int cantidadCentavos = (int)cantidad;

            foreach (var denominacion in denominacionesBilletes.Keys)
            {
                int cantidadBilletes = cantidadCentavos / denominacion;

                if (cantidadBilletes > 0 && denominacionesBilletes.ContainsKey(denominacion))
                {
                    resultado[denominacion] = cantidadBilletes;
                    cantidadCentavos -= cantidadBilletes * denominacion;
                }
            }
            foreach (var denominacion in denominacionesMonedas.Keys)
            {
                int cantidadMonedas = cantidadCentavos / denominacion;
                if (cantidadMonedas > 0 && denominacionesMonedas.ContainsKey(denominacion))
                {
                    resultado[denominacion] = cantidadMonedas;
                    cantidadCentavos -= cantidadMonedas * denominacion;
                }
            }
            return resultado;
        }
    }
}
