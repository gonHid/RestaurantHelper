using RestaurantHelper.Models;
using RestaurantHelper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantHelper.Services
{
	public class MesaService
	{
		private readonly MesaRepository _repository = new MesaRepository();
		public Mesa GetMesaByID(int id)
		{
			Mesa mesa = _repository.GetById(id);

			return mesa;
		}

		public List<Mesa> GetAllMesas()
		{
			return _repository.GetAll();
		}

		public bool AddMesa()
		{
			List<Mesa> list = _repository.GetAll();
			Mesa mesa = new Mesa();

			if (list.Count == 0)
				mesa.Id = list.Max(m => m.Id) + 1;
			else
				mesa.Id = 1;

			mesa.Estado = Models.Enums.EstadoMesa.Libre;

			return _repository.Add(mesa);
		}

		public bool DeleteMesa()
		{
			List<Mesa> list = _repository.GetAll();
			Mesa? mesa = list.Select(m1 => m1.Id == list.Max(m2 => m2.Id)) as Mesa;
			if (mesa != null)
			{
				return _repository.Delete(mesa);
			}
			return false;
		}
	}
}
