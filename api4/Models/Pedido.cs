using System;
using System.Collections.Generic;

namespace api4.Models;

public partial class Pedido
{
    public int Idpedido { get; set; }

    public int? Idproyecto { get; set; }

    public int? Idcliente { get; set; }

    public DateOnly? Fecha { get; set; }

    public int? Total { get; set; }

    public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; } = new List<DetallesPedido>();

    public virtual Cliente? IdclienteNavigation { get; set; }
}
