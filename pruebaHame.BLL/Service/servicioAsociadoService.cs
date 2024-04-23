using pruebaHame.DAL.Repositories;
using pruebaHame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaHame.BLL.Service
{
    public class servicioAsociadoService : IServiciosAsociadosService
    {

        //inyeccion de deepencencia al context
        private readonly IGenericRepository<ClienteServicio> _servicioAsociadoRepo;

        //Constructor y le inyectamos la dependencia al InterfazGenericRepository
        public servicioAsociadoService(IGenericRepository<ClienteServicio> servicioAsociadoRepo)
        {
           _servicioAsociadoRepo = servicioAsociadoRepo;
        }
        public async Task<bool> delete(int id)
        {
            return await _servicioAsociadoRepo.delete(id);
        }

        public async Task<ClienteServicio> get(int id)
        {
            return await _servicioAsociadoRepo.get(id);
        }

        public async Task<IQueryable<ClienteServicio>> getAll()
        {
            return await _servicioAsociadoRepo.getAll();
        }

        public async Task<bool> insert(ClienteServicio modelo)
        {
            return await _servicioAsociadoRepo.insert(modelo);
        }

        public async Task<bool> update(ClienteServicio modelo)
        {
            return await _servicioAsociadoRepo.update(modelo);
        }
    }
}
