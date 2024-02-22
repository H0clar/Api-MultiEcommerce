using System;
using System.Collections.Generic;

namespace api4.Models;

public partial class ConfiguracionesTiendum
{
    public int Idconfiguracion { get; set; }

    public int? Idproyecto { get; set; }

    public string? NombreConfiguracion { get; set; }

    public string? ValorConfiguracion { get; set; }

    public virtual ProyectosEcommerce? IdproyectoNavigation { get; set; }
}
