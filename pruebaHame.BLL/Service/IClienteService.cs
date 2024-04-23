using pruebaHame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaHame.BLL.Service
{
    public interface IClienteService
    {
        Task<bool> insertarCliente(Cliente modelo);
        Task<bool> actualizarCliente(Cliente modelo);
        Task<bool> eliminarCliente(int id);
        Task<Cliente> obtenerCliente(int id);
        Task<IQueryable<Cliente>> obtenerTodosClientes();
        Task<Cliente> obtenerServiciosAsociadosCliente(int id);
        Task<IQueryable<Cliente>> obtenerServiciosClientesMorosos();
    }
}
