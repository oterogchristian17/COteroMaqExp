using System;
using System.Collections.Generic;

namespace DL;

public partial class Alimento
{
    public int IdAlimento { get; set; }

    public string Nombre { get; set; } = null!;

    public int Precio { get; set; }

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
