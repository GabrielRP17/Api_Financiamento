using Financiamento.Interface;
using Financiamento.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financiamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanciamentoController : ControllerBase
    {
        public readonly IServiceFinanciamento _financiamento;

        public FinanciamentoController(IServiceFinanciamento financiamento)
        {
            _financiamento = financiamento;
        }

        [HttpGet]
        public IEnumerable<FinanciamentoModelResponse> Get()
        {
            return _financiamento.BuscarTodos();
        }

        [HttpGet("BuscarId/{id}")]
        public FinanciamentoModelResponse Get(int id)
        {
            return _financiamento.BuscarPorId(id);
        }

        [HttpPut("AlterarFinanciamento")]
        public void Put(FinanciamentoModelResponse Fin)
        {
            _financiamento.AlterarFinanciamento(Fin);
        }

        [HttpPost("InserirFinanciamento")]
        public void Post(FinanciamentoModelRequest Fin)
        {
            _financiamento.InserirFinanciamento(Fin);
        }
        
    }
}
