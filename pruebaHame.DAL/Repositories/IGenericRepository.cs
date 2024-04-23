using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaHame.DAL.Repositories
{
    public interface IGenericRepository<TEntityModel> where TEntityModel : class
    {

        Task<bool> insertarCliente(TEntityModel modelo);
        Task<bool> actualizarCliente(TEntityModel modelo);
        Task<bool> eliminarCliente(int id);
        Task<TEntityModel> obtenerCliente(int id);
        Task<IQueryable<TEntityModel>> obtenerTodosClientes();

        Task<bool> insert(TEntityModel modelo);
        Task<bool> update(TEntityModel modelo);
        Task<bool> delete(int id);
        Task<TEntityModel> get(int id);
        Task<IQueryable<TEntityModel>> getAll();
    }
}
