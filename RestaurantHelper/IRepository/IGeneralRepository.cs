using RestaurantHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantHelper.IRepository
{
    internal interface IGeneralRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }

}
