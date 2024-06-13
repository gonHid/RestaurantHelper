using RestaurantHelper.Models;
using RestaurantHelper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantHelper.Services
{
	public class ComandaService
	{
		private readonly ComandaRepository _repository = new ComandaRepository();
		public Comanda GetComandaByID(int id)
		{
			Comanda comanda = _repository.GetById(id);

			return comanda;
		}

		public List<Comanda> GetAllComandas()
		{
			return _repository.GetAll();
		}

		public bool AddComanda(Comanda comanda)
		{
			List<Comanda> list = _repository.GetAll();

			if (list.Count != 0)
                comanda.Id = list.Max(c => c.Id) + 1;
			else
                comanda.Id = 1;

            comanda.Estado = Models.Enums.EstadoComanda.Iniciada;

			return _repository.Add(comanda);
		}

		public bool DeleteComanda(int id)//DELETE FISICO - NO USAR - ES PREFERIBLE HACERLO DE FORMA LOGICA
		{
			List<Comanda> list = _repository.GetAll();
			Comanda? comanda = list.Select(c1 => c1.Id == id) as Comanda;
			if (comanda != null)
			{
				return _repository.Delete(comanda);
			}
			return false;
		}
	}
}
