using Microsoft.AspNetCore.Mvc;
using pruebaHame.AplicacionWeb.Models;
using pruebaHame.AplicacionWeb.Models.ViewModels;
using pruebaHame.BLL.Service;
using pruebaHame.Models;
using System.Diagnostics;

namespace pruebaHame.AplicacionWeb.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;


        //propiedad privada para inyectar la instancias o Interfaces
        private readonly IClienteService _clienteService;
        private readonly IServicioService _servicioService;
        private readonly IServiciosAsociadosService _servicioAsociadosService;

        //Constructor recive Instancias como parametro
        public HomeController(IClienteService clienteServ, IServicioService servicioServ, IServiciosAsociadosService servicioAsociadosService)
        {
            _clienteService = clienteServ;
            _servicioService = servicioServ;
            _servicioAsociadosService = servicioAsociadosService;
        }

        public IActionResult Index()
        {
            return View();
        }
        //Metodos para CLientes =========================
        [HttpGet]
        public async Task<IActionResult> listarClientes()
        {
            IQueryable<Cliente> queryClienteSQL = await _clienteService.obtenerTodosClientes();
            List<VMCliente> lista =queryClienteSQL
                                                    .Select(c=>new VMCliente() {
                                                    IdCliente=c.IdCliente,
                                                    CodigoCliente=c.CodigoCliente,
                                                    FechaAltaCliente=c.FechaAltaCliente,    
                                                    NombreCliente=c.NombreCliente,
                                                    DireccionCliente=c.DireccionCliente,
                                                    CorreoCliente=c.CorreoCliente,  
                                                    TelefonoCliente=c.TelefonoCliente,
                                                    EstadoCliente=c.EstadoCliente,
                                                    
                                                    }).ToList();
            return StatusCode(StatusCodes.Status200OK,lista);
        }

        [HttpPost]
        public async Task<IActionResult> insertarCliente([FromBody] VMCliente modelo)
        {
            Cliente nuevoModelo = new Cliente()
            {
                NombreCliente = modelo.NombreCliente,
                CodigoCliente = modelo.CodigoCliente,
                FechaAltaCliente = DateTime.Today,
                DireccionCliente = modelo.DireccionCliente,
                TelefonoCliente = modelo.TelefonoCliente,
                EstadoCliente = "Activo"
            };
            bool respuesta = await _clienteService.insertarCliente(nuevoModelo);
            
            return StatusCode(StatusCodes.Status200OK, new {valor=respuesta});
        }

        [HttpPut]
        public async Task<IActionResult> actualizarCliente([FromBody] VMCliente modelo)
        {
            Cliente nuevoModelo = new Cliente()
            {
                IdCliente = modelo.IdCliente,
                NombreCliente = modelo.NombreCliente,
                CodigoCliente = modelo.CodigoCliente,
                //FechaAltaCliente = modelo.FechaAltaCliente,
                DireccionCliente = modelo.DireccionCliente,
                TelefonoCliente = modelo.TelefonoCliente,
                EstadoCliente = modelo.EstadoCliente,
            };
            bool respuesta = await _clienteService.actualizarCliente(nuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }
        [HttpDelete]
        public async Task<IActionResult> deleteCliente(int id)
        {
            
            bool respuesta = await _clienteService.eliminarCliente(id);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }


       //======================= Servicios =========================
        public IActionResult Privacy()
        {
            return View();
        }
        //Metodos para Servicios =========================
        [HttpGet]
        public async Task<IActionResult> listarServicios()
        {
            IQueryable<Servicio> queryServicioSQL = await _servicioService.getAll();
            List<VMServicio> lista = queryServicioSQL.Select(c => new VMServicio()
                                                    {
                                                        IdServicio = c.IdServicio ,
                                                        NombreServicio = c.NombreServicio ,
                                                        PeriodoServicio = c.PeriodoServicio ,
                                                        CostoServicio= c.CostoServicio ,
                                                        TipoServicio= c.TipoServicio ,
                                                        DetalleServicio= c.DetalleServicio ,
                                                        EstadoServicio  = c.EstadoServicio ,
                                                        
                                                    }).ToList();
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        public async Task<IActionResult> insertarServicio([FromBody] VMServicio modelo)
        {
            Servicio nuevoServicio = new Servicio()
            {
                NombreServicio= modelo.NombreServicio,
                PeriodoServicio= modelo.PeriodoServicio,
                CostoServicio= modelo.CostoServicio,
                TipoServicio= modelo.TipoServicio,
                DetalleServicio= modelo.DetalleServicio,
                EstadoServicio= "Activo"
                
            };
            bool respuesta = await _servicioService.insert(nuevoServicio);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpPut]
        public async Task<IActionResult> actualizarServicio([FromBody] VMServicio modelo)
        {
            Servicio nuevoModelo = new Servicio()
            {
                IdServicio= modelo.IdServicio,
                NombreServicio = modelo.NombreServicio,
                PeriodoServicio = modelo.PeriodoServicio,
                CostoServicio = modelo.CostoServicio,
                TipoServicio = modelo.TipoServicio,
                DetalleServicio = modelo.DetalleServicio,
                EstadoServicio = modelo.EstadoServicio
            };
            bool respuesta = await _servicioService.update(nuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }
        [HttpDelete]
        public async Task<IActionResult> deleteServicio(int id)
        {

            bool respuesta = await _servicioService.delete(id);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpGet]
        public async Task<IActionResult> listarServiciosAsociados()
        {
            IQueryable<ClienteServicio> queryServicioAsociadosSQL = await _servicioAsociadosService.getAll();
            List<VMServiciosAsociados> lista = queryServicioAsociadosSQL.Select(c => new VMServiciosAsociados()
            {
               
                IdClienteServicio=c.IdClienteServicio,
                IdClienteFk=c.IdClienteFk,
                IdServicioFk=c.IdServicioFk,
                TipoClienteServicio=c.TipoClienteServicio,
                EstadoClienteServicio=c.EstadoClienteServicio,
                DireccionClienteServicio=c.DireccionClienteServicio,
                UbicacionClienteServicio=c.UbicacionClienteServicio,
                VelocidadClienteServicio=c.VelocidadClienteServicio,
                PaqueteClienteServicio=c.PaqueteClienteServicio,
                DetallesClienteServicio=c.DetallesClienteServicio,
                ClienteAsociado = new VMCliente // Inicializa la instancia de VMCliente si es nulo
                {
                    IdCliente= c.IdClienteFkNavigation.IdCliente,
                    NombreCliente = c.IdClienteFkNavigation.NombreCliente // Asigna el valor a la propiedad NombreClienteServicio
                },
                ServicioAsociado = new VMServicio
                {
                    IdServicio=c.IdServicioFkNavigation.IdServicio,
                    NombreServicio=c.IdServicioFkNavigation.NombreServicio,
                    TipoServicio=c.IdServicioFkNavigation.TipoServicio,
                    CostoServicio=c.IdServicioFkNavigation.CostoServicio
                }





            }).ToList();
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpGet]
        public async Task<IActionResult> listarServiciosAsociadosCliente(int idCliente)
        {
            IQueryable<ClienteServicio> queryServicioAsociadosSQL = await _servicioAsociadosService.getAll();

            // Filtrar los servicios asociados al idCliente especificado
            queryServicioAsociadosSQL = queryServicioAsociadosSQL.Where(c => c.IdClienteFk == idCliente);

            List<VMServiciosAsociados> lista = queryServicioAsociadosSQL.Select(c => new VMServiciosAsociados()
            {
                IdClienteServicio = c.IdClienteServicio,
                IdClienteFk = c.IdClienteFk,
                IdServicioFk = c.IdServicioFk,
                TipoClienteServicio = c.TipoClienteServicio,
                EstadoClienteServicio = c.EstadoClienteServicio,
                DireccionClienteServicio = c.DireccionClienteServicio,
                UbicacionClienteServicio = c.UbicacionClienteServicio,
                VelocidadClienteServicio = c.VelocidadClienteServicio,
                PaqueteClienteServicio = c.PaqueteClienteServicio,
                DetallesClienteServicio = c.DetallesClienteServicio,
                ClienteAsociado = new VMCliente // Inicializa la instancia de VMCliente si es nulo
                {
                    IdCliente = c.IdClienteFkNavigation.IdCliente,
                    NombreCliente = c.IdClienteFkNavigation.NombreCliente // Asigna el valor a la propiedad NombreClienteServicio
                },
                ServicioAsociado = new VMServicio
                {
                    IdServicio = c.IdServicioFkNavigation.IdServicio,
                    NombreServicio = c.IdServicioFkNavigation.NombreServicio,
                    TipoServicio = c.IdServicioFkNavigation.TipoServicio,
                    CostoServicio = c.IdServicioFkNavigation.CostoServicio
                }
            }).ToList();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        public async Task<IActionResult> insertarServicioAsociado_Cliente([FromBody] VMServiciosAsociados modelo)
        {
            ClienteServicio nuevoServicioAsociado = new ClienteServicio()
            {
                IdClienteFk = modelo.IdClienteFk,
                IdServicioFk = modelo.IdServicioFk,
                TipoClienteServicio=modelo.TipoClienteServicio,
                EstadoClienteServicio = modelo.EstadoClienteServicio,
                DireccionClienteServicio= modelo.DireccionClienteServicio,
                UbicacionClienteServicio=modelo.UbicacionClienteServicio,
                VelocidadClienteServicio=modelo.VelocidadClienteServicio,
                PaqueteClienteServicio=modelo.PaqueteClienteServicio,
                DetallesClienteServicio=modelo.DetallesClienteServicio

            };
            bool respuesta = await _servicioAsociadosService.insert(nuevoServicioAsociado);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpDelete]
        public async Task<IActionResult> deleteServicioAsociado(int id)
        {

            bool respuesta = await _servicioAsociadosService.delete(id);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpPut]
        public async Task<IActionResult> actualizarServicioASociado([FromBody] VMServiciosAsociados modelo)
        {
            ClienteServicio nuevoModelo = new ClienteServicio()
            {
                IdClienteServicio = modelo.IdClienteServicio,
                IdClienteFk=modelo.IdClienteFk,
                IdServicioFk=modelo.IdServicioFk,  
                TipoClienteServicio=modelo.TipoClienteServicio,
                EstadoClienteServicio=modelo.EstadoClienteServicio,
                DireccionClienteServicio=modelo.DireccionClienteServicio,
                UbicacionClienteServicio=modelo.UbicacionClienteServicio,
                VelocidadClienteServicio=modelo.VelocidadClienteServicio,
                PaqueteClienteServicio=modelo.PaqueteClienteServicio,
                DetallesClienteServicio=modelo.DetallesClienteServicio
            };
            bool respuesta = await _servicioAsociadosService.update(nuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
