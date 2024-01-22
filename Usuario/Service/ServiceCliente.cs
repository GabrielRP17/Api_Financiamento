using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Usuario.Interface;
using Usuario.Model;

namespace Usuario.Service
{
    public class ServiceCliente : IServiceCliente
    {

        public readonly IRepositorioCliente _repositorio;
        public ServiceCliente (IRepositorioCliente repositorio)
        {
            _repositorio = repositorio;
        }


        public void AlterarCliente(Cliente Cli)
        {
            _repositorio.AlterarCliente(Cli);  
        }

        public Cliente BuscarCPF(string cpf)
        {
            return _repositorio.BuscarCPF(cpf);
        }

        public Cliente BuscarId(int id)
        {
            return _repositorio.BuscarId(id);  
        }

        public Cliente BuscarRG(string rg)
        {
            return _repositorio.BuscarRG(rg);  
        }

        public List<Cliente> BuscarTodos()
        {
            return _repositorio.BuscarTodos(); 
        }

        public void InserirCliente(Cliente Cli)
        {
            _repositorio.InserirCliente(Cli); 
        }
    }
}
