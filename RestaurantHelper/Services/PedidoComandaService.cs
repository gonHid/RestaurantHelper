using RestaurantHelper.Models;
using RestaurantHelper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantHelper.Services
{
	public class PedidoComandaService
	{
		private readonly PedidoComandaRepository _repository = new PedidoComandaRepository();
		public List<PedidoComanda> GetPedidoComandaByID(int id)
		{
			List<PedidoComanda> pedidoComanda = new List<PedidoComanda>();
			List<PedidoComanda> list = _repository.GetAll();
			foreach (PedidoComanda pc in list)
			{
				if (id == pc.ComandaId)
				{
					pedidoComanda.Add(pc);
				}
			}

			return pedidoComanda;
		}

		public List<PedidoComanda> GetAllComandas()
		{
			return _repository.GetAll();
		}

		public bool AddPedidoComanda(List<PedidoComanda> pedidosComanda)
		{
			foreach (PedidoComanda pc in pedidosComanda)
			{
				try
				{
                    bool resultado = _repository.Add(pc);
                }
				catch (Exception ex)
				{
					return false;
				}
				
            }

			return true;
		}

		public bool DeletePedidoComanda(int idComanda)
		{
			List<PedidoComanda> list = _repository.GetAll();
			foreach (PedidoComanda pc in list)
			{
				if (idComanda == pc.ComandaId)
				{
                    try
                    {
                        _repository.Delete(pc);
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                   
                }
			}
			return false;
		}
	}
}
