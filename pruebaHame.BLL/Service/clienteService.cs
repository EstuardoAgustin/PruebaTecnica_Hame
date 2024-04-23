using pruebaHame.DAL.Repositories;
using pruebaHame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaHame.BLL.Service
{
    public class clienteService : IClienteService
    {
        private readonly IGenericRepository<Cliente> _clienteRepo;
        public clienteService(IGenericRepository<Cliente> clienteRepo) 
        { 
            _clienteRepo = clienteRepo;
        }
        public async Task<bool> actualizarCliente(Cliente modelo)
        {
            return await _clienteRepo.actualizarCliente(modelo);
        }

        public async Task<bool> eliminarCliente(int id)
        {
           return await _clienteRepo.eliminarCliente(id);
        }

        public async Task<bool> insertarCliente(Cliente modelo)
        {
            return await _clienteRepo.insertarCliente(modelo);
        }

        public async Task<Cliente> obtenerCliente(int id)
        {
            return await _clienteRepo.obtenerCliente(id);
        }

        public async Task<Cliente> obtenerServiciosAsociadosCliente(int id)
        {
            return await _clienteRepo.obtenerCliente(id); //aqui podemos manejar una logica de engocio diferente usando los datos resultantes
        }

        public async Task<IQueryable<Cliente>> obtenerServiciosClientesMorosos()
        {
            return await _clienteRepo.obtenerTodosClientes();
        }

        public async Task<IQueryable<Cliente>> obtenerTodosClientes()
        {
            return await _clienteRepo.obtenerTodosClientes();
        }
    }
}
