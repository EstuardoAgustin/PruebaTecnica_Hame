using pruebaHame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaHame.BLL.Service
{
    public interface IServiciosAsociadosService
    {
        Task<bool> insert(ClienteServicio modelo);
        Task<bool> update(ClienteServicio modelo);
        Task<bool> delete(int id);
        Task<ClienteServicio> get(int id);
        Task<IQueryable<ClienteServicio>> getAll();
    }
}
