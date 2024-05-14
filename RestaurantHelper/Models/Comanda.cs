using RestaurantHelper.Models.Enums;
using System;
using System.Collections.Generic;

namespace RestaurantHelper.Models;

public partial class Comanda
{
    public int Id { get; set; }

    public int MesaId { get; set; }

    public DateOnly Fecha { get; set; }

    public int UsuarioId { get; set; }

    public EstadoComanda Estado { get; set; }

    public string? Observaciones { get; set; }

    public int ValorFinal { get; set; }

    public int ValorTotal { get; set; }

    public int Propina { get; set; }

    public virtual Mesa Mesa { get; set; } = null!;

    public virtual ICollection<Mesa> Mesas { get; set; } = new List<Mesa>();

    public virtual Usuario Usuario { get; set; } = null!;
}
