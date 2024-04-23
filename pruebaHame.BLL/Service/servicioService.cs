using pruebaHame.DAL.Repositories;
using pruebaHame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaHame.BLL.Service
{
    public class servicioService : IServicioService
    {

        //inyeccion de deepencencia al context
        private readonly IGenericRepository<Servicio> _servicioRepo;

        //Constructor y le inyectamos la dependencia al InterfazGenericRepository
        public servicioService(IGenericRepository<Servicio> servicioRepo) 
        {
            _servicioRepo = servicioRepo;
        }

        public async Task<bool> delete(int id)
        {
            return await _servicioRepo.delete(id);
        }

        public async Task<Servicio> get(int id)
        {
            return await _servicioRepo.get(id);
        }

        public async Task<IQueryable<Servicio>> getAll()
        {
            return await _servicioRepo.getAll();
        }

        public async Task<bool> insert(Servicio modelo)
        {
            return await _servicioRepo.insert(modelo);
        }

        public async Task<bool> update(Servicio modelo)
        {
            return await _servicioRepo.update(modelo);
        }
    }
}
