using System;
using System.Collections.Generic;

namespace api4.Models;

public partial class Producto
{
    public int Idproducto { get; set; }

    public int? Idproyecto { get; set; }

    public int? Idcategoria { get; set; }

    public string? Nombre { get; set; }

    public int? Precio { get; set; }

    public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; } = new List<DetallesPedido>();

    public virtual CategoriasProducto? IdcategoriaNavigation { get; set; }

    public virtual ProyectosEcommerce? IdproyectoNavigation { get; set; }
}
