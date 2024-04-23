using pruebaHame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaHame.BLL.Service
{
    public interface IServicioService
    {
        Task<bool> insert(Servicio modelo);
        Task<bool> update(Servicio modelo);
        Task<bool> delete(int id);
        Task<Servicio> get(int id);
        Task<IQueryable<Servicio>> getAll();
    }
}
