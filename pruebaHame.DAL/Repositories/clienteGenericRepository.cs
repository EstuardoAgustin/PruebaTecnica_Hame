using pruebaHame.DAL.DataContext;
using pruebaHame.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace pruebaHame.DAL.Repositories
{
    public class clienteGenericRepository : IGenericRepository<Cliente>
    {
        private readonly pruebaHAMEContext _dbcontext;
        public clienteGenericRepository(pruebaHAMEContext context) 
        {
            _dbcontext = context;
        }
        public async Task<bool> actualizarCliente(Cliente modelo)
        {
            _dbcontext.Clientes.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        

        public async Task<bool> eliminarCliente(int id)
        {
            Cliente cliente = _dbcontext.Clientes.First(c=>c.IdCliente == id);
            _dbcontext.Remove(cliente);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
        

       

        public async Task<bool> insertarCliente(Cliente modelo)
        {
            _dbcontext.Clientes.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<Cliente> obtenerCliente(int id)
        {
            return await _dbcontext.Clientes.FindAsync(id);
        }

        public async Task<IQueryable<Cliente>> obtenerTodosClientes()
        {
            //return await _dbcontext.Clientes.ToList();
            IQueryable<Cliente> queryContactoSQL = _dbcontext.Clientes;
            return queryContactoSQL;
        }

        //Metodo Genericos de la interfaz====================
        public Task<bool> insert(Cliente modelo)
        {
            throw new NotImplementedException();
        }
        public Task<bool> delete(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Cliente> get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Cliente>> getAll()
        {
            throw new NotImplementedException();
        }
        public Task<bool> update(Cliente modelo)
        {
            throw new NotImplementedException();
        }
    }
}
