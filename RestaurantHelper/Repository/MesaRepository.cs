using RestaurantHelper.IRepository;
using RestaurantHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantHelper.Repository
{
	internal class MesaRepository : IGeneralRepository<Mesa>
	{
		public bool Add(Mesa mesa)
		{
			using (RestaurantContext contexto = new RestaurantContext())
			{
				try
				{
					contexto.Mesas.Add(mesa);
					contexto.SaveChanges();
					return true;
				}
				catch (Exception)
				{
					return false;
				}

			}
		}

		public bool Delete(Mesa mesa)
		{
			using (RestaurantContext contexto = new RestaurantContext())
			{
				try
				{
					contexto.Mesas.Remove(mesa);
					contexto.SaveChanges();
					return true;
				}
				catch (Exception)
				{
					return false;
				}

			}
		}

		public List<Mesa> GetAll()
		{
			using (RestaurantContext contexto = new RestaurantContext())
			{
				List<Mesa> lista = new List<Mesa>();
				try
				{
					lista = contexto.Mesas.ToList();
				}
				catch (Exception)
				{
                    MessageBox.Show("Error al obtener las mesas", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
				return lista;
			}
		}

		public Mesa GetById(int id)
		{
			using (RestaurantContext contexto = new RestaurantContext())
			{
				Mesa? encontrado = null;
				try
				{
					encontrado = contexto.Mesas.FirstOrDefault(mesa => mesa.Id == id);
				}
				catch (Exception)
				{
                    MessageBox.Show("Error al buscar la mesa", "Error", MessageBoxButton.OK, MessageBoxImage.Error); 
				}
				return encontrado != null ? encontrado : new Mesa { Id = 0 };
			}
		}

		public bool Update(Mesa mesa)
		{
			using (RestaurantContext contexto = new RestaurantContext())
			{
				try
				{
					var encontrado = contexto.Mesas.FirstOrDefault(m => m.Id == mesa.Id);
					if (encontrado != null)
					{
						encontrado.Id = mesa.Id;
						encontrado.Estado = mesa.Estado;
						encontrado.Comandas = mesa.Comandas;
						encontrado.ComandaActual = mesa.ComandaActual;
						encontrado.ComandaActualId = mesa.ComandaActualId;

						return true;
					}
					return false;
				}
				catch (Exception)
				{
                    MessageBox.Show("Error al actualizar la informacion para la mesa", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
				return false;
			}
		}
	}
}
