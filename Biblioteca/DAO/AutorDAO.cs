using Biblioteca.Interfaces;
using Biblioteca.Models;
using Microsoft.Data.SqlClient;

namespace Biblioteca.DAO
{
    public class AutorDAO : IAutorDAO
    {
        private string _connectionString;

        public AutorDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Método para adicionar autor
        public void Adicionar(Autor autor)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Autor (Nome, Nacionalidade) VALUES (@Nome, @Nacionalidade)";

                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Nome", autor.Nome);
                command.Parameters.AddWithValue("@Nacionalidade", autor.Nacionalidade);

                con.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para atualizar autor
        public void Atualizar(Autor autor)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Autor SET Nome = @Nome, Nacionalidade = @Nacionalidade WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Id", autor.Id);
                command.Parameters.AddWithValue("@Nome", autor.Nome);
                command.Parameters.AddWithValue("@Nacionalidade", autor.Nacionalidade);

                con.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para buscar autor por ID
        public Autor BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Autor WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Id", id);

                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Autor()
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Nacionalidade = reader.GetString(2)
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        // Método para deletar autor
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Autor WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Id", id);

                con.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para listar todos os autores
        public List<Autor> ListarTodos()
        {
            List<Autor> autores = new List<Autor>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Autor";

                SqlCommand command = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Autor autor = new Autor()
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Nacionalidade = reader.GetString(2)
                    };

                    autores.Add(autor);
                }
            }

            return autores;
        }
    }
}
