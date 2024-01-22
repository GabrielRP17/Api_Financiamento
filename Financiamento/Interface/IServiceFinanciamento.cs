using Financiamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financiamento.Interface
{
    public interface IServiceFinanciamento
    {
        public List<FinanciamentoModelResponse> BuscarTodos();
        public FinanciamentoModelResponse BuscarPorId(int Id);
        public void InserirFinanciamento(FinanciamentoModelRequest fin);
        public void AlterarFinanciamento(FinanciamentoModelResponse fin);

    }
}
