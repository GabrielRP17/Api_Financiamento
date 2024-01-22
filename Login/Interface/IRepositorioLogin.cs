using Login.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Interface
{
    public interface IRepositorioLogin
    {

        public List<Model.Login> BuscarTodos();
        public Model.Login BuscarPorId(int id);
        public Model.Login VerificarLogin(string emai,string senha);
        public Model.Login BuscarPorSenha(string Sen);
        public void AlterarLogin(Model.Login log);
        public void InserirLogin(Model.Login log);

    }
}
