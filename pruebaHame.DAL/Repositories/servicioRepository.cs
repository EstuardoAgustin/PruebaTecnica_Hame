using pruebaHame.DAL.DataContext;
using pruebaHame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaHame.DAL.Repositories
{
    public class servicioRepository : IGenericRepository<Servicio>
    {
        //inyeccion de deepencencia al context
        private readonly pruebaHAMEContext _dbcontex;
        
        //Constructor y le inyectamos la dependencia al context
        public servicioRepository(pruebaHAMEContext context) 
        {
            _dbcontex = context;
        }
        
        
        //Metodo Genericos de la interfaz
        public async Task<bool> insert(Servicio modelo)
        {
            _dbcontex.Servicios.Add(modelo);
            await _dbcontex.SaveChangesAsync();
            return true;
        }

        public async Task<bool> update(Servicio modelo)
        {
            _dbcontex.Servicios.Update(modelo);
            await _dbcontex.SaveChangesAsync(); 
            return true;
        }
        public async Task<bool> delete(int id)
        {
            Servicio servicioEliminar =_dbcontex.Servicios.Find(id);
            _dbcontex.Remove(servicioEliminar);
            await _dbcontex.SaveChangesAsync();
            return true;
        }

        public async Task<Servicio> get(int id)
        {
            return await _dbcontex.Servicios.FindAsync(id);
        }

        public async Task<IQueryable<Servicio>> getAll()
        {
            IQueryable<Servicio> queryServicioSQL=_dbcontex.Servicios;
            return queryServicioSQL;
        }



        //====Metodos Exclusivos Clientes===================
        public Task<bool> actualizarCliente(Servicio modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> eliminarCliente(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> insertarCliente(Servicio modelo)
        {
            throw new NotImplementedException();
        }

        public Task<Servicio> obtenerCliente(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Servicio>> obtenerTodosClientes()
        {
            throw new NotImplementedException();
        }

       
    }
}
