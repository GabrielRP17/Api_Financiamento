using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financiamento.Model
{
    public class FinanciamentoModelRequest
    {
        public int ClienteId { get; set; }
        public int FinanciamentoId { get; set; }
        public double FinanciamentoValor { get; set; }
        public int FinanciamentoTotalParcela { get; set; }
        public double FinanciamentoTaxaDeJuros { get; set; }

        public FinanciamentoModelResponse financiamento { get; set; }

      

        //public double FinanciamentoJuros { get; set; }
        //public double FinanciamentoAmortizacao { get; set; }
        //public double FinanciamentoPrestacao { get; set; }
        //public double FinanciamentoSaldoDevedor { get; set; }
        //public double FinanciamentoFutureValue { get; set; }       
        //public double FinanciamentoTotalAmortizacao { get; set; }
        //public double FinanciamentoTotalJuros { get; set; }
    }
}
