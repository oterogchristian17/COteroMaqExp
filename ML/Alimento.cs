using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ML
{
    public class Alimento
    {
        public Alimento() { }

        public Alimento(string nombre, int precio)
        {
            Nombre = nombre;
            Precio = precio;
        }
        public int IdAlimento { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }

        public List<object> Alimentos { get; set; }
    }
}
