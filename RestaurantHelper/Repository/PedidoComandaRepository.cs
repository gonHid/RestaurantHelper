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
	internal class PedidoComandaRepository : IGeneralRepository<PedidoComanda>
	{
		public bool Add(PedidoComanda pedidoComanda)
		{
			using (RestaurantContext contexto = new RestaurantContext())
			{
				try
				{
					contexto.PedidosComanda.Add(pedidoComanda);
					contexto.SaveChanges();
					return true;
				}
				catch (Exception)
				{
					return false;
				}

			}
		}

		public bool Delete(PedidoComanda pedidoComanda)
		{
			using (RestaurantContext contexto = new RestaurantContext())
			{
				try
				{
					contexto.PedidosComanda.Remove(pedidoComanda);
					contexto.SaveChanges();
					return true;
				}
				catch (Exception)
				{
					return false;
				}

			}
		}

		public List<PedidoComanda> GetAll()
		{
			using (RestaurantContext contexto = new RestaurantContext())
			{
				List<PedidoComanda> lista = new List<PedidoComanda>();
				try
				{
					lista = contexto.PedidosComanda.ToList();
				}
				catch (Exception)
				{
                    MessageBox.Show("Error al obtener los pedidos de la comanda", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
				return lista;
			}
		}

		public PedidoComanda GetById(int id)//TABLA RELACIONAL - NO ENCONTRARA UN UNICO ITEM - NO USAR
		{
			using (RestaurantContext contexto = new RestaurantContext())
			{
                PedidoComanda? encontrado = null;
				try
				{
					encontrado = contexto.PedidosComanda.FirstOrDefault(p => p.ComandaId == id);
				}
				catch (Exception)
				{
                    MessageBox.Show("Error al un pedido unico de la comanda", "Error", MessageBoxButton.OK, MessageBoxImage.Error); 
				}
				return encontrado != null ? encontrado : new PedidoComanda { ComandaId = 0 };
			}
		}

		public bool Update(PedidoComanda comanda)//TABLA RELACIONAL - NO USAR ESTA LOGICA - ELIMINAR TODOS LOS ELEMENTOS RELACIONADOS 
												// Y RECREAR
		{
			using (RestaurantContext contexto = new RestaurantContext())
			{
				try
				{
					var encontrado = contexto.PedidosComanda.FirstOrDefault(m => m.ComandaId == comanda.ComandaId);
					if (encontrado != null)
					{
						encontrado.MenuId = comanda.MenuId;

                        return true;
					}
					return false;
				}
				catch (Exception)
				{
                    MessageBox.Show("Error al actualizar la informacion del pedido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
				return false;
			}
		}
	}
}
