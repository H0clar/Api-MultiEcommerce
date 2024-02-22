using System;
using System.Collections.Generic;

namespace api4.Models;

public partial class CategoriasProducto
{
    public int Idcategoria { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
