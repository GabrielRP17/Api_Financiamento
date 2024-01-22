using Login.Interface;
using Login.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Repositorio
{
    public class RepositorioLogin : IRepositorioLogin
    {
        public void AlterarLogin(Model.Login log)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Financiamento;Integrated Security=True");

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("update Login set LoginNome = @LoginNome Where LoginId = @LoginId", _conn);
                cmd.Parameters.AddWithValue("@LoginId", log.LoginId);
                cmd.Parameters.AddWithValue("@LoginNome", log.LoginNome.ToString());

                cmd.ExecuteNonQuery(); 
            }
            finally
            {
                _conn.Close(); 
            }
        }

        public Model.Login VerificarLogin(string emai,string senha)
        {

            Model.Login log = new Model.Login();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Financiamento;Integrated Security=True");
            SqlDataReader dr = null;

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("Select LoginId, LoginNome, LoginEmail, LoginSenha from Login", _conn);
                cmd.Parameters.AddWithValue("@LoginEmail", emai);
                cmd.Parameters.AddWithValue("@LoginSenha", senha);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    log = new Model.Login();
                    log.LoginEmail = dr["LoginEmail"].ToString();
                    log.LoginId = Convert.ToInt32(dr["LoginId"].ToString());
                    log.LoginNome = dr["LoginNome"].ToString();
                    log.LoginSenha = dr["LoginSenha"].ToString();
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
            return log;
        }

        public Model.Login BuscarPorId(int id)
        {
            Model.Login log = new Model.Login();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Financiamento;Integrated Security=True");
            SqlDataReader dr = null;

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("Select LoginId, LoginNome, LoginEmail, LoginSenha from Login", _conn);
                cmd.Parameters.AddWithValue("@LoginId", id);
                dr = cmd.ExecuteReader();
                
                while(dr.Read())
                {
                    log = new Model.Login();
                    log.LoginEmail = dr["LoginEmail"].ToString();
                    log.LoginId = Convert.ToInt32(dr["LoginId"].ToString());
                    log.LoginNome = dr["LoginNome"].ToString();
                    log.LoginSenha = dr["LoginSenha"].ToString();
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
            return log;
        }

        public Model.Login BuscarPorSenha(string Sen)
        {

            Model.Login log = new Model.Login();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Financiamento;Integrated Security=True");
            SqlDataReader dr = null;

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("Select LoginId, LoginNome, LoginEmail, LoginSenha from Login", _conn);
                cmd.Parameters.AddWithValue("@LoginSenha", Sen);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    log = new Model.Login();
                    log.LoginEmail = dr["LoginEmail"].ToString();
                    log.LoginId = Convert.ToInt32(dr["LoginId"].ToString());
                    log.LoginNome = dr["LoginNome"].ToString();
                    log.LoginSenha = dr["LoginSenha"].ToString();
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
            return log;
        }

        public List<Model.Login> BuscarTodos()
        {
            Model.Login log = null;
            List<Model.Login> ListLog = new List<Model.Login>();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Financiamento;Integrated Security=True");
            SqlDataReader dr = null;

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("Select LoginId,LoginNome,LoginEmail,LoginSenha from Login", _conn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    log = new Model.Login();
                    log.LoginEmail = dr["LoginEmail"].ToString();
                    log.LoginId = Convert.ToInt32(dr["LoginId"].ToString());
                    log.LoginNome = dr["LoginNome"].ToString();
                    log.LoginSenha = dr["LoginSenha"].ToString();
                    ListLog.Add(log);

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
            return ListLog; 
        }

        public void InserirLogin(Model.Login log)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Financiamento;Integrated Security=True");

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Login (LoginNome,LoginEmail,LoginSenha) values ( @LoginNome,@LoginEmail,@LoginSenha)", _conn);
                cmd.Parameters.AddWithValue("@LoginNome", log.LoginNome.ToString());
                cmd.Parameters.AddWithValue("@LoginEmail", log.LoginEmail.ToString());
                cmd.Parameters.AddWithValue("@LoginSenha", log.LoginSenha.ToString());

                cmd.ExecuteNonQuery(); 
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
