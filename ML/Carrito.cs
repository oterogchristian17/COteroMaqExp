using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Carrito
    {
        public ML.Alimento Alimento { get; set; }
        public List<object> Productos { get; set; }
        public int Cantidad { get; set; }
        public decimal CostoTotal { get; set; }
    }
}
