using System;
using System.Collections.Generic;

namespace api4.Models;

public partial class Cliente
{
    public int Idcliente { get; set; }

    public int? Idproyecto { get; set; }

    public string? Nombre { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<HistorialCliente> HistorialClientes { get; set; } = new List<HistorialCliente>();

    public virtual ProyectosEcommerce? IdproyectoNavigation { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
