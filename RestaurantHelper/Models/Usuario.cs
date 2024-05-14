using RestaurantHelper.Models.Enums;
using System;
using System.Collections.Generic;

namespace RestaurantHelper.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Rut { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public CategoriaUsuario CategoriaId { get; set; }

    public EstadoUsuario Estado { get; set; }

    public string Password { get; set; } = null!;

    public virtual ICollection<Comanda> Comandas { get; set; } = new List<Comanda>();
}
