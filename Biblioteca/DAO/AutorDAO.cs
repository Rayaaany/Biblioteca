using Biblioteca.Interfaces;
using Biblioteca.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Biblioteca.DAO
{
    public class AutorDAO : IAutorDAO
    {
        private string _connectionString;

        public AutorDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Adicionar(Autor autor)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Autor (Nome, Nacionalidade) VALUES (@Nome, @Nacionalidade)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nome", autor.Nome);
                cmd.Parameters.AddWithValue("@Nacionalidade", autor.Nacionalidade);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Atualizar(Autor autor)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Autor SET Nome = @Nome, Nacionalidade = @Nacionalidade WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nome", autor.Nome);
                cmd.Parameters.AddWithValue("@Nacionalidade", autor.Nacionalidade);
                cmd.Parameters.AddWithValue("@Id", autor.Id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Remover(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Autor WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Autor BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Autor WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Autor()
                    {
                        Id = (int)reader["Id"],
                        Nome = reader["Nome"].ToString(),
                        Nacionalidade = reader["Nacionalidade"].ToString()
                    };
                }

                return null;
            }
        }

        public List<Autor> ListarTodos()
        {
            List<Autor> lista = new List<Autor>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Autor";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Autor autor = new Autor()
                    {
                        Id = (int)reader["Id"],
                        Nome = reader["Nome"].ToString(),
                        Nacionalidade = reader["Nacionalidade"].ToString()
                    };

                    lista.Add(autor);
                }
            }

            return lista;
        }
    }
}
