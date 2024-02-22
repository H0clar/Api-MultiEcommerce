using System;
using System.Collections.Generic;

namespace api4.Models;

public partial class HistorialCliente
{
    public int Idhistorial { get; set; }

    public int? Idcliente { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Accion { get; set; }

    public virtual Cliente? IdclienteNavigation { get; set; }
}
