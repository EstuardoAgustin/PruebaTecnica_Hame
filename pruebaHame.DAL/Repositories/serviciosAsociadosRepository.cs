using Microsoft.EntityFrameworkCore;
using pruebaHame.DAL.DataContext;
using pruebaHame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaHame.DAL.Repositories
{
    public class serviciosAsociadosRepository : IGenericRepository<ClienteServicio>
    {
        //Creamos una variable para implementar  la variable de la conexion
        private readonly pruebaHAMEContext _dbcontext;
        public serviciosAsociadosRepository(pruebaHAMEContext context)
        {
            _dbcontext = context;
            
        }

        public async Task<bool> update(ClienteServicio modelo)
        {
            _dbcontext.ClienteServicios.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
        public async Task<ClienteServicio> get(int id)
        {
            return await _dbcontext.ClienteServicios.FindAsync(id);
        }

        public async Task<IQueryable<ClienteServicio>> getAll()
        {
            IQueryable<ClienteServicio> queryServicioAsociadoSQL=_dbcontext.ClienteServicios.Include(cs => cs.IdClienteFkNavigation).Include(sv => sv.IdServicioFkNavigation);
            return queryServicioAsociadoSQL;
        }

        public async Task<bool> insert(ClienteServicio modelo)
        {
            _dbcontext.ClienteServicios.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> delete(int id)
        {
            ClienteServicio eliminarAsociacionServicio = _dbcontext.ClienteServicios.Find(id);
            _dbcontext.Remove(eliminarAsociacionServicio);
            await _dbcontext.SaveChangesAsync();  
            return true;
        }
        //===== metodos exclusivos para Clientes ============
        public Task<bool> actualizarCliente(ClienteServicio modelo)
        {
            throw new NotImplementedException();
        }

       

        public Task<bool> eliminarCliente(int id)
        {
            throw new NotImplementedException();
        }

        

        public Task<bool> insertarCliente(ClienteServicio modelo)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteServicio> obtenerCliente(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<ClienteServicio>> obtenerTodosClientes()
        {
            throw new NotImplementedException();
        }

       
    }
}
