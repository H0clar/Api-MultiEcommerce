using System;
using System.Collections.Generic;

namespace api4.Models;

public partial class ProyectosEcommerce
{
    public int Idproyecto { get; set; }

    public string? Nombre { get; set; }

    public string? Url { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<ConfiguracionesTiendum> ConfiguracionesTienda { get; set; } = new List<ConfiguracionesTiendum>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
