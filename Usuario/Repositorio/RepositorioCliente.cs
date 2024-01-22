using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Usuario.Interface;
using Usuario.Model;

namespace Usuario.Repositorio
{
    public class RepositorioCliente : IRepositorioCliente
    {
        public void AlterarCliente(Cliente Cli)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Financiamento;Integrated Security=True");

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("Update Cliente set ClienteNome = @ClienteNome, ClienteCPF=@ClienteCPF, ClienteRG = @ClienteRG where ClienteId = @ClienteId", _conn);
                cmd.Parameters.AddWithValue("@ClienteId", Convert.ToInt32(Cli.ClienteId.ToString()));
                cmd.Parameters.AddWithValue("@ClienteNome", Cli.ClienteNome.ToString());
                cmd.Parameters.AddWithValue("@ClienteCPF", Cli.ClienteCPF.ToString().Replace(".", "").Replace("-",""));
                cmd.Parameters.AddWithValue("@ClienteRG", Cli.ClienteRG.ToString().Replace(".", "").Replace("-",""));

                cmd.ExecuteNonQuery();

            }
            finally
            {
                _conn.Close(); 
            }
        }

        public Cliente BuscarCPF(string CPF)
        {
            Cliente Cli = new Cliente();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Financiamento;Integrated Security=True");
            SqlDataReader dr = null;

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select ClienteId,ClienteNome,ClienteCPF,ClienteRG from Cliente where ClienteCPF=@ClienteCPF", _conn);
                cmd.Parameters.AddWithValue("@ClienteCPF", CPF);
                dr = cmd.ExecuteReader();


                while(dr.Read())
                {
                    Cli.ClienteId = Convert.ToInt32(dr["ClienteId"]);
                    Cli.ClienteCPF = dr["ClienteCPF"].ToString();
                    Cli.ClienteNome = dr["ClienteNome"].ToString();
                    Cli.ClienteRG = dr["ClienteRG"].ToString();
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (_conn != null)
                {
                    _conn.Close(); 
                }
            }
            return Cli;
        }

        public Cliente BuscarId(int id)
        {
            Cliente Cli = new Cliente();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Financiamento;Integrated Security=True");
            SqlDataReader dr = null; ;

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select ClienteId,ClienteNome,ClienteCPF,ClienteRG from Cliente where ClienteId = @ClienteId", _conn);
                cmd.Parameters.AddWithValue("@ClienteId", id);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Cli.ClienteCPF = dr["ClienteCPF"].ToString();
                    Cli.ClienteId = Convert.ToInt32(dr["ClienteId"].ToString());
                    Cli.ClienteNome = dr["ClienteNome"].ToString();
                    Cli.ClienteRG = dr["ClienteRG"].ToString();
                    
                }
            }
            finally
            {
                if(dr != null)
                {
                    dr.Close();
                }
                if (_conn != null)
                {
                    _conn.Close(); 
                }
            }
            return Cli;
        }

        public Cliente BuscarRG(string RG)
        {
            Cliente Cli = new Cliente();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Financiamento;Integrated Security=True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select ClienteId,ClienteNome,ClienteCPF,ClienteRG from Cliente where ClienteRG=@ClienteRG", _conn);
                cmd.Parameters.AddWithValue("@ClienteRG", RG);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Cli.ClienteCPF = dr["ClienteCPF"].ToString();
                    Cli.ClienteId = Convert.ToInt32(dr["ClienteId"].ToString());    
                    Cli.ClienteNome = dr["ClienteNome"].ToString();
                    Cli.ClienteRG = dr["ClienteRG"].ToString();
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
            return Cli;  
        }

        public List<Cliente> BuscarTodos()
        {
            Cliente Cli = null;
            List<Cliente> ListCli = new List<Cliente>();
            SqlConnection _conn = new SqlConnection (@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Financiamento;Integrated Security=True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select ClienteId,ClienteNome,ClienteCPF,ClienteRG from Cliente", _conn);
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    Cli = new Cliente();
                    Cli.ClienteCPF = dr["ClienteCPF"].ToString();
                    Cli.ClienteId = Convert.ToInt32(dr["ClienteId"].ToString());
                    Cli.ClienteNome = dr["ClienteNome"].ToString();
                    Cli.ClienteRG = dr["ClienteRG"].ToString();
                    ListCli.Add(Cli);  
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
            return ListCli;  

        }

        public void InserirCliente(Cliente Cli)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Financiamento;Integrated Security=True");

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Cliente (ClienteNome, ClienteCPF, ClienteRG) values ('@ClienteNome', '@ClienteCPF', '@ClienteRG')", _conn);

                cmd.Parameters.AddWithValue("@ClienteNome", Cli.ClienteNome.ToString());
                cmd.Parameters.AddWithValue("@ClienteCPF", Cli.ClienteCPF.ToString().Replace(".","").Replace("-",""));
                cmd.Parameters.AddWithValue("@ClienteRG", Cli.ClienteRG.ToString().Replace(".", "").Replace("-", ""));

                cmd.ExecuteNonQuery(); 
            }
            finally
            {
                _conn.Close();
            } 
        }
    }
}
