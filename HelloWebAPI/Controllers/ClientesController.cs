using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HelloWebAPI.Models;

namespace HelloWebAPI.Controllers
{
    //[Route("api/[controller]")]
    public class ClientesController : ApiController
    {
        public IClientesRepositorio _repo { get; set; }

        public ClientesController (IClientesRepositorio repositorio)
        {
            _repo = repositorio;
        }

        //public ClientesController() { }

        [HttpGet]
        public IEnumerable<Cliente>obTerClientes()
        {
            return _repo.Buscar();
        }

        [HttpGet]
        public Cliente obterCliente(string Codigo)
        {
            return _repo.Buscar(Codigo);
        }

        [HttpPost]
        public HttpResponseMessage manterCliente([FromBody] Cliente cliente)
        {
            var response = Request.CreateResponse(HttpStatusCode.Accepted);
            if (cliente == null)
            {
                response = null;
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.StatusCode = HttpStatusCode.BadRequest;
            }
            else
            {
                _repo.Manter(cliente);

                response = null;
                response = Request.CreateResponse(HttpStatusCode.Created);
                response.StatusCode = HttpStatusCode.Created;

                string uri = Url.Link("Default", new { codigo = cliente.Codigo });
                response.Headers.Location = new Uri(uri);
            }

            return response;
                
        }
    }
}
