using System;
using System.Collections.Generic;

namespace api4.Models;

public partial class DetallesPedido
{
    public int IddetallePedido { get; set; }

    public int? Idpedido { get; set; }

    public int? Idproducto { get; set; }

    public int? Cantidad { get; set; }

    public int? PrecioUnitario { get; set; }

    public virtual Pedido? IdpedidoNavigation { get; set; }

    public virtual Producto? IdproductoNavigation { get; set; }
}
