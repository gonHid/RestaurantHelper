using Microsoft.VisualBasic.ApplicationServices;
using RestaurantHelper.Models;
using RestaurantHelper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantHelper.Services
{
	public class UsuarioService
	{
		private readonly UsuarioRepository _repository = new UsuarioRepository();
		public  Usuario GetUsuarioByIDAync(int id)
		{
			Usuario user = _repository.GetById(id);

			return user;
		}
	}
}
