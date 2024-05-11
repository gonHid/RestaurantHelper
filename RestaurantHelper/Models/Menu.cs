using System;
using System.Collections.Generic;

namespace RestaurantHelper.Models;

public partial class Menu
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Valor { get; set; }

    public string? Detalle { get; set; }

    public int CategoriaId { get; set; }

    public int Estado { get; set; }
}
