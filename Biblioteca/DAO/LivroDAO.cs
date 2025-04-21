using Biblioteca.Interfaces;
using Biblioteca.Models;
using Microsoft.Data.SqlClient;

namespace Biblioteca.DAO
{
    public class LivroDAO : ILivroDAO
    {
        private string _connectionString;

        public LivroDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Método para adicionar livro
        public void Adicionar(Livro livro)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Livro (Titulo, Genero, AnoPublicacao, AutorId) VALUES (@Titulo, @Genero, @AnoPublicacao, @AutorId)";

                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Titulo", livro.Titulo);
                command.Parameters.AddWithValue("@Genero", livro.Genero);
                command.Parameters.AddWithValue("@AnoPublicacao", livro.AnoPublicacao);
                command.Parameters.AddWithValue("@AutorId", livro.AutorId);

                con.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para atualizar livro
        public void Atualizar(Livro livro)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Livro SET Titulo = @Titulo, Genero = @Genero, AnoPublicacao = @AnoPublicacao, AutorId = @AutorId WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Id", livro.Id);
                command.Parameters.AddWithValue("@Titulo", livro.Titulo);
                command.Parameters.AddWithValue("@Genero", livro.Genero);
                command.Parameters.AddWithValue("@AnoPublicacao", livro.AnoPublicacao);
                command.Parameters.AddWithValue("@AutorId", livro.AutorId);

                con.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para buscar livro por ID
        public Livro BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Livro WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Id", id);

                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Livro()
                    {
                        Id = reader.GetInt32(0),
                        Titulo = reader.GetString(1),
                        Genero = reader.GetString(2),
                        AnoPublicacao = reader.GetInt32(3),
                        AutorId = reader.GetInt32(4)
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        // Método para deletar livro
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Livro WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Id", id);

                con.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para listar todos os livros
        public List<Livro> ListarTodos()
        {
            List<Livro> livros = new List<Livro>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Livro";

                SqlCommand command = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Livro livro = new Livro()
                    {
                        Id = reader.GetInt32(0),
                        Titulo = reader.GetString(1),
                        Genero = reader.GetString(2),
                        AnoPublicacao = reader.GetInt32(3),
                        AutorId = reader.GetInt32(4)
                    };

                    livros.Add(livro);
                }
            }

            return livros;
        }
    }
}

