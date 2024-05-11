using System;
using System.Collections.Generic;

namespace RestaurantHelper.Models;

public partial class Mesa
{
    public int Id { get; set; }

    public int Estado { get; set; }

    public int ComandaActualId { get; set; }

    public virtual ICollection<Comanda> Comandas { get; set; } = new List<Comanda>();

    public virtual Comanda ComandaActual { get; set; } = null!;
}
