using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Usuario.Interface;
using Usuario.Model;

namespace Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public readonly IServiceCliente _service;
        public ClienteController(IServiceCliente service)
        {
            _service = service;
        }


        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return _service.BuscarTodos(); 
        }

        [HttpGet("ClienteId/{Id}")]
        public  Cliente Get(int Id)
        {
            return _service.BuscarId(Id);   
        }

        [HttpGet("ClienteCPF/{CPF}")]
        public Cliente GetCPF(string  CPF)
        {
            return _service.BuscarCPF(CPF);   
        }

        [HttpGet("ClienteRG/{RG}")]
        public Cliente GetRG (string RG)
        {
            return _service.BuscarRG(RG);  
        }

        [HttpPut("AlterarCliente")]

        public void Put (Cliente Cli)
        {
            _service.AlterarCliente(Cli);  
        }

        [HttpPost("InserirCliente")]

        public void post(Cliente Cli)
        {
            _service.InserirCliente(Cli);  
        }
    }
}
