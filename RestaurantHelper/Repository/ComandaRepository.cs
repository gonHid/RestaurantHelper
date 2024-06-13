using RestaurantHelper.IRepository;
using RestaurantHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RestaurantHelper.Repository
{
	internal class ComandaRepository : IGeneralRepository<Comanda>
	{
		public bool Add(Comanda comanda)
		{
			using (RestaurantContext contexto = new RestaurantContext())
			{
				try
				{
					contexto.Comandas.Add(comanda);
					contexto.SaveChanges();
					return true;
				}
				catch (Exception)
				{
					return false;
				}

			}
		}

		public bool Delete(Comanda comanda)
		{
			using (RestaurantContext contexto = new RestaurantContext())
			{
				try
				{
					contexto.Comandas.Remove(comanda);
					contexto.SaveChanges();
					return true;
				}
				catch (Exception)
				{
					return false;
				}

			}
		}

		public List<Comanda> GetAll()
		{
			using (RestaurantContext contexto = new RestaurantContext())
			{
				List<Comanda> lista = new List<Comanda>();
				try
				{
					lista = contexto.Comandas.ToList();
				}
				catch (Exception)
				{
                    MessageBox.Show("Error al obtener las comandas", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
				return lista;
			}
		}

		public Comanda GetById(int id)
		{
			using (RestaurantContext contexto = new RestaurantContext())
			{
                Comanda? encontrado = null;
				try
				{
					encontrado = contexto.Comandas.FirstOrDefault(mesa => mesa.Id == id);
				}
				catch (Exception)
				{
                    MessageBox.Show("Error al buscar la mesa", "Error", MessageBoxButton.OK, MessageBoxImage.Error); 
				}
				return encontrado != null ? encontrado : new Comanda { Id = 0 };
			}
		}

		public bool Update(Comanda comanda)
		{
			using (RestaurantContext contexto = new RestaurantContext())
			{
				try
				{
					var encontrado = contexto.Comandas.FirstOrDefault(m => m.Id == comanda.Id);
					if (encontrado != null)
					{
						encontrado.Id = comanda.Id;
						encontrado.Estado = comanda.Estado;
						encontrado.Fecha = comanda.Fecha;
						encontrado.UsuarioId = comanda.UsuarioId;
						encontrado.Estado = comanda.Estado;
                        encontrado.Observaciones = comanda.Observaciones;
                        encontrado.ValorFinal = comanda.ValorFinal;
                        encontrado.ValorTotal = comanda.ValorTotal;
                        encontrado.Propina = comanda.Propina;


                        return true;
					}
					return false;
				}
				catch (Exception)
				{
                    MessageBox.Show("Error al actualizar la informacion para la comanda", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
				return false;
			}
		}
	}
}
