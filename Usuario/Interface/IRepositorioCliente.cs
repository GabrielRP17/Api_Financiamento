using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Usuario.Model;

namespace Usuario.Interface
{
    public interface IRepositorioCliente
    {
        public List<Cliente> BuscarTodos();
        public Cliente BuscarId(int id);
        public Cliente BuscarCPF(string CPF);
        public Cliente BuscarRG(string RG);
        public void AlterarCliente(Cliente Cli);
        public void InserirCliente(Cliente Cli);

    }
}
