using System;
using System.Collections.Generic;

namespace DL;

public partial class Ventum
{
    public int IdVenta { get; set; }

    public DateTime Fecha { get; set; }

    public int? MontoIngresado { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdAlimento { get; set; }

    public virtual Alimento? IdAlimentoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
