using Microsoft.VisualBasic.ApplicationServices;
using RestaurantHelper.IRepository;
using RestaurantHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantHelper.Repository
{
    internal class UsuarioRepository : IGeneralRepository<Usuario>
    {
        public bool Add(Usuario usuario)
        {
            using (RestaurantContext contexto = new RestaurantContext())
            {
                try
                {
                    contexto.Add(usuario);
                    contexto.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
               
            }
        }

        public bool Delete(Usuario usuario)
        {
            using (RestaurantContext contexto = new RestaurantContext())
            {
                try
                {
                    contexto.Remove(usuario);
                    contexto.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }

        public List<Usuario> GetAll()
        {
            using (RestaurantContext contexto = new RestaurantContext())
            {
                List<Usuario> lista = new List<Usuario>();
                try
                {
                    lista = contexto.Usuarios.ToList(); 
                }
                catch (Exception)
                {
                   //DAR MENSAJE
                }
                return lista;
            }
        }

        public Usuario GetById(int id)
        {
            using (RestaurantContext contexto = new RestaurantContext())
            {
                Usuario encontrado = null;
                try
                {
                    encontrado = contexto.Usuarios.FirstOrDefault(user => user.Id == id);
                }
                catch (Exception)
                {
                   //DAR MENSAJE
                }
                return encontrado != null ? encontrado : new Usuario { Id = 0 };
            }
        }

        public bool Update(Usuario usuario)
        {
            using (RestaurantContext contexto = new RestaurantContext())
            {
                try
                {
                    var encontrado = contexto.Usuarios.FirstOrDefault(user => user.Id == usuario.Id);
                    if (encontrado!=null)
                    {
                        encontrado.Id = usuario.Id;
                        encontrado.Nombre = usuario.Nombre;
                        encontrado.Rut = usuario.Rut;
                        encontrado.Estado = usuario.Estado; 
                        encontrado.Password = usuario.Password;
                        encontrado.CategoriaId = usuario.CategoriaId;
                        encontrado.Comandas = usuario.Comandas;
                        
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    //DAR MENSAJE
                }
                return false;
            }
        }
    }
}
