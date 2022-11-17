using Persistencia.Models;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class CrudDAO
    {
        // String de conexão com banco de dados sql server
        private static string stringConnection = @"Server=LOCALHOST\SQLEXPRESS;Database=DBWEB;Trusted_Connection=True;";
        
        public bool Insert(Cliente cliente)
        {
            SqlConnection connection = new SqlConnection(stringConnection);
            try
            {
                connection.Open();
                string query = "INSERT INTO CLIENTE (CPF, NOME) VALUES (@CPF, @NOME)";
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@CPF", cliente.CPF);
                    cmd.Parameters.AddWithValue("@NOME", cliente.Nome);
                    if (Convert.ToInt32(cmd.ExecuteNonQuery()) > 0)
                    {
                        connection.Close();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public List<Cliente> GetAll() {
            SqlConnection connection = new SqlConnection(stringConnection);
            List<Cliente> listaClientes = new List<Cliente>();
            try
            {
                connection.Open();
                string query = "SELECT ID, CPF, NOME FROM CLIENTE;";
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente()
                            {
                                Id = reader.GetInt32(0),
                                CPF = reader.GetInt64(1),
                                Nome = reader.GetString(2)
                            };
                            listaClientes.Add(cliente);
                        }
                    }
                }
                return listaClientes;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
