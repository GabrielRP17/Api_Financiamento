using Financiamento.Interface;
using Financiamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financiamento.Service
{
    public class ServiceFinanciamento : IServiceFinanciamento
    {

        public readonly IRepositorioFinanciamento _repositorio;

        public ServiceFinanciamento (IRepositorioFinanciamento repositorio)
        {
            _repositorio = repositorio;
        } 

        public void AlterarFinanciamento(FinanciamentoModelResponse fin)
        {
            _repositorio.AlterarFinanciamento(fin); 
        }

        public FinanciamentoModelResponse BuscarPorId(int Id)
        {
            return _repositorio.BuscarPorId(Id);  
        }

        public List<FinanciamentoModelResponse> BuscarTodos()
        {
            return _repositorio.BuscarTodos(); 
        }

        public void  InserirFinanciamento(FinanciamentoModelRequest financiamento)
        {
            ;
             _repositorio.InserirFinanciamento(CalculoSac(financiamento)); 
        }

        private List<FinanciamentoModelResponse> CalculoSac(FinanciamentoModelRequest financiamento)
        {
            List<FinanciamentoModelResponse> responseList = new List<FinanciamentoModelResponse>();
            FinanciamentoModelResponse response = null;
            double Juros = 0;
            double FutureValue = 0;
            double Amortizacao = 0;
            double Prestacao = 0;
            double SaldoDevedor = 0;
            double TotalParcela = 0;
            double TotalAmortizacao = 0;
            double TotalJuros =0;


            for (int x = 1; x <= financiamento.FinanciamentoTotalParcela; x++)
            {
                response= new FinanciamentoModelResponse();
                Juros = financiamento.FinanciamentoValor * (financiamento.FinanciamentoTaxaDeJuros);
                Amortizacao = financiamento.FinanciamentoValor / financiamento.FinanciamentoTotalParcela;
                Prestacao = Juros + Amortizacao;
                SaldoDevedor = financiamento.FinanciamentoValor - Amortizacao;
                TotalParcela =+ Prestacao;
                TotalAmortizacao =+ Amortizacao;
                TotalJuros =+ Juros;
                FutureValue =- Amortizacao;

                response.FinanciamentoPrestacao = Prestacao;
                response.FinanciamentoJuros = Juros;
                response.FinanciamentoFutureValue = FutureValue;
                response.FinanciamentoAmortizacao = Amortizacao;
                response.FinanciamentoSaldoDevedor = SaldoDevedor;
                response.FinanciamentoTotalAmortizacao = TotalAmortizacao;
                response.FinanciamentoTotalJuros = TotalJuros;
                response.FinanciamentoTotalParcela = TotalParcela;
                response.ClienteId = financiamento.ClienteId; 
                
                responseList.Add(response); 

            }



            return responseList; 
        }
    }
}
