using Financiamento.Interface;
using Financiamento.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Financiamento.Repositorio
{
    public class RepositorioFinanciamento : IRepositorioFinanciamento
    {
        public void AlterarFinanciamento(FinanciamentoModelResponse financiamento)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Financiamento;Integrated Security=True");

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("update Financiamento set FinanciamentoAmortizacao = @FinanciamentoAmortizacao , FinanciamentoFutureValue = @FinanciamentoFutureValue, FinanciamentoJuros = @FinanciamentoJuros, FinanciamentoPrestacao=@FinanciamentoPrestacao, FinanciamentoSaldoDevedor = @FinanciamentoSaldoDevedor, FinanciamentoTotalAmortizacao = @FinanciamentoTotalAmortizacao, FinanciamentoTotalJuros = @FinanciamentoTotalJuros, FinanciamentoTotalParcela = @FinanciamentoTotalParcela, ClienteId = @ClienteId, FinanciamentoValor = @FinanciamentoValor where ClienteId = @ClienteId", _conn);
                cmd.Parameters.AddWithValue("@FinanciamentoAmortizacao", financiamento.FinanciamentoAmortizacao);
                cmd.Parameters.AddWithValue("@FinanciamentoFutureValue", financiamento.FinanciamentoFutureValue );
                cmd.Parameters.AddWithValue("@FinanciamentoJuros", financiamento.FinanciamentoJuros);
                cmd.Parameters.AddWithValue("@FinanciamentoPrestacao", financiamento.FinanciamentoPrestacao);
                cmd.Parameters.AddWithValue("@FinanciamentoSaldoDevedor", financiamento.FinanciamentoSaldoDevedor);
                cmd.Parameters.AddWithValue("@FinanciamentoTotalAmortizacao", financiamento.FinanciamentoTotalAmortizacao);
                cmd.Parameters.AddWithValue("@FinanciamentoTotalJuros", financiamento.FinanciamentoTotalJuros);
                cmd.Parameters.AddWithValue("@FinanciamentoTotalParcela", financiamento.FinanciamentoTotalParcela);
                cmd.Parameters.AddWithValue("@Cliente", financiamento.ClienteId);
                cmd.Parameters.AddWithValue("@FinanciamentoValor", financiamento.FinanciamentoValor); 
                
                cmd.ExecuteNonQuery(); 
            }
            finally
            {
                _conn.Close(); 
            }
        }
        public FinanciamentoModelResponse BuscarPorId(int Id)
        {
            FinanciamentoModelResponse financiamento = new FinanciamentoModelResponse();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Financiamento;Integrated Security=True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("Select FinanciamentoAmortizacao, FinanciamentoFutureValue, FinanciamentoJuros, FinanciamentoPrestacao,FinanciamentoSaldoDevedor,FinanciamentoTotalAmortizacao,FinanciamentoTotalJuros,FinanciamentoTotalParcela,ClienteId,FinanciamentoValor from Financiamento where ClienteId =@ClienteId", _conn);
                cmd.Parameters.AddWithValue("@FinanciamentoId", Id);  
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    financiamento.FinanciamentoAmortizacao = Convert.ToDouble(dr["FinanciamentoAmortizacao"].ToString());
                    financiamento.FinanciamentoFutureValue = Convert.ToDouble(dr["FinanciamentoFutureValue"].ToString());
                    financiamento.FinanciamentoJuros = Convert.ToDouble(dr["FinanciamentoJuros"].ToString());
                    financiamento.FinanciamentoPrestacao = Convert.ToDouble(dr["FinanciamentoPrestacao"].ToString());
                    financiamento.FinanciamentoSaldoDevedor = Convert.ToDouble(dr["FinanciamentoSaldoDevedor"].ToString());
                    financiamento.FinanciamentoTotalAmortizacao = Convert.ToDouble(dr["FinanciamentoTotalAmortizacao"].ToString());
                    financiamento.FinanciamentoTotalJuros = Convert.ToDouble(dr["FinanciamentoTotalJuros"].ToString());
                    financiamento.FinanciamentoTotalParcela = Convert.ToDouble(dr["FinanciamentoTotalParcela"].ToString());
                    financiamento.ClienteId = Convert.ToInt32(dr["ClienteId"].ToString());
                    financiamento.FinanciamentoValor = Convert.ToDouble(dr["FinanciamentoValor"].ToString());
                }
            }
            finally
            {
                if(dr != null)
                {
                    dr.Close(); 
                }
                if(_conn != null)
                {
                    _conn.Close(); 
                }
            }
            return financiamento;
        }
        public List<FinanciamentoModelResponse> BuscarTodos()
        {
            FinanciamentoModelResponse financiamento = null;
            List<FinanciamentoModelResponse> ListFin = new List<FinanciamentoModelResponse>();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Financiamento;Integrated Security=True");
            SqlDataReader dr = null;

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("Select FinanciamentoAmortizacao, FinanciamentoFutureValue, FinanciamentoJuros, FinanciamentoPrestacao,FinanciamentoSaldoDevedor,FinanciamentoTotalAmortizacao,FinanciamentoTotalJuros,FinanciamentoTotalParcela,ClienteId,FinanciamentoValor from Financiamento", _conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                   
                    financiamento = new FinanciamentoModelResponse();
                    
                    financiamento.FinanciamentoAmortizacao= Convert.ToDouble(dr["FinanciamentoAmortizacao"].ToString());
                    financiamento.FinanciamentoFutureValue= Convert.ToDouble (dr["FinanciamentoFutureValue"].ToString());
                    //financiamento.FinanciamentoJuros = Convert.ToDouble(dr["FinanciamentoJuros"].ToString());
                    financiamento.FinanciamentoPrestacao = Convert.ToDouble(dr["FinanciamentoPrestacao"].ToString());
                    financiamento.FinanciamentoSaldoDevedor = Convert.ToDouble(dr["FinanciamentoSaldoDevedor"].ToString());
                    financiamento.FinanciamentoTotalAmortizacao = Convert.ToDouble(dr["FinanciamentoTotalAmortizacao"].ToString());
                    financiamento.FinanciamentoTotalJuros = Convert.ToDouble(dr["FinanciamentoTotalJuros"].ToString());
                    financiamento.FinanciamentoTotalParcela = Convert.ToDouble(dr["FinanciamentoTotalParcela"].ToString());
                    financiamento.ClienteId =Convert.ToInt32(dr["ClienteId"].ToString());
                    financiamento.FinanciamentoValor = Convert.ToDouble(dr["FinanciamentoValor"].ToString());   
                    
                    ListFin.Add(financiamento);
                } 
            }
            finally
            {
                if (dr!= null)
                {
                    dr.Close(); 
                }
                if(_conn != null)
                {
                    _conn.Close(); 
                }
            }
            return ListFin;
        }
        public void InserirFinanciamento(List<FinanciamentoModelResponse> fin)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Financiamento;Integrated Security=True");

            try
            {
                foreach(FinanciamentoModelResponse financiamento in fin)
                {
                    _conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into Financiamento (Financiamentojuros, FinanciamentoAmortizacao, FinanciamentoPrestacao, FinanciamentoSaldoDevedor, FinanciamentoFutureValue, FinanciamentoTotalParcela, FinanciamentoTotalAmortizacao,FinanciamentoTotalJuros, ClienteId, FinanciamentoValor) values (@Financiamentojuros,@FinanciamentoAmortizacao,@FinanciamentoPrestacao,@FinanciamentoSaldoDevedor,@FinanciamentoFutureValue,@FinanciamentoTotalParcela,@FinanciamentoTotalAmortizacao,@FinanciamentoTotalJuros,@ClienteId,@FinanciamentoValor) SELECT @@IDENTITY", _conn);
                    cmd.Parameters.AddWithValue("@FinanciamentoJuros", Convert.ToDecimal (financiamento.FinanciamentoJuros.ToString()));
                    cmd.Parameters.AddWithValue("@FinanciamentoAmortizacao",Convert.ToDecimal(financiamento.FinanciamentoAmortizacao.ToString()));
                    cmd.Parameters.AddWithValue("@FinanciamentoPrestacao",Convert.ToDecimal(financiamento.FinanciamentoPrestacao.ToString()));
                    cmd.Parameters.AddWithValue("@FinanciamentoSaldoDevedor", Convert.ToDecimal(financiamento.FinanciamentoSaldoDevedor.ToString()));
                    cmd.Parameters.AddWithValue("@FinanciamentoFutureValue", Convert.ToDecimal (financiamento.FinanciamentoFutureValue.ToString()));
                    cmd.Parameters.AddWithValue("@FinanciamentoTotalParcela", Convert.ToDecimal (financiamento.FinanciamentoTotalParcela.ToString()));
                    cmd.Parameters.AddWithValue("@FinanciamentoTotalAmortizacao", Convert.ToDecimal(financiamento.FinanciamentoTotalAmortizacao.ToString()));
                    cmd.Parameters.AddWithValue("@FinanciamentoTotalJuros", Convert.ToDecimal(financiamento.FinanciamentoTotalJuros.ToString()));
                    cmd.Parameters.AddWithValue("@ClienteId",Convert.ToInt32(financiamento.ClienteId.ToString()));
                    cmd.Parameters.AddWithValue("@FinanciamentoValor",Convert.ToDecimal(financiamento.FinanciamentoValor.ToString()));
                   //cmd.Parameters.AddWithValue("@FinanciamentoId", Convert.ToInt32(financiamento.FinanciamentoId.ToString()));  
                  

                   decimal teste= (decimal)cmd.ExecuteScalar();

                    _conn.Close();
                }
                 
            }
            finally
            {
                //_conn.Close();
            }
        }

    }
}
