using System;
using System.Collections.Generic;

namespace RestaurantHelper.Models;

public partial class PedidoComanda
{
    public int MenuId { get; set; }

    public int ComandaId { get; set; }

    public virtual Comanda Comanda { get; set; } = null!;

    public virtual Menu Menu { get; set; } = null!;
}
