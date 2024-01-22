using Login.Interface;
using Login.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly IServiceLogin _login;
        public LoginController(IServiceLogin login)
        {
            _login = login;
        }

        [HttpGet]
        public IEnumerable<Model.Login> Get()
        {
            return _login.BuscarTodos();
        }

        [HttpGet("UsuarioId/{id}")]
        public Model.Login Get(int id)
        {
            return _login.BuscarPorId(id);
        }

        [HttpGet("VerificarUsuario/{id}")]
        public Model.Login GetVerificarLogin(string emai, string senha)
        {
            return _login.VerificarLogin(emai, senha);
        }

        [HttpGet("BuscarSenha/{id}")]
        public Model.Login GetSenha(string senha)
        {
            return _login.BuscarPorSenha(senha);
        }

        [HttpPut("AlterarUsuario/{id}")]

        public void Put (Model.Login usu)
        {
            _login.AlterarLogin(usu);  
        }

        [HttpPost("InserirUsuario{id}")]
        public void Post (Model.Login log)
        {
            _login.InserirLogin(log);  
        }

    }
}
