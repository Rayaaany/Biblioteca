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

        public void Inserir(Livro livro)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Livro (Titulo, Genero, AnoPublicacao, AutorId) VALUES (@Titulo, @Genero, @AnoPublicacao, @AutorId)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Titulo", livro.Titulo);
                cmd.Parameters.AddWithValue("@Genero", livro.Genero);
                cmd.Parameters.AddWithValue("@AnoPublicacao", livro.AnoPublicacao);
                cmd.Parameters.AddWithValue("@AutorId", livro.AutorId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Atualizar(Livro pLivro)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Livro SET Titulo = @Titulo, Genero = @Genero, AnoPublicacao = @AnoPublicacao, AutorId = @AutorId WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Titulo", pLivro.Titulo);
                cmd.Parameters.AddWithValue("@Genero", pLivro.Genero);
                cmd.Parameters.AddWithValue("@AnoPublicacao", pLivro.AnoPublicacao);
                cmd.Parameters.AddWithValue("@AutorId", pLivro.AutorId);
                cmd.Parameters.AddWithValue("@Id", pLivro.Id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Livro BuscarPorId(int pId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Livro WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", pId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Livro livro = new Livro()
                    {
                        Id = (int)reader["Id"],
                        Titulo = reader["Titulo"].ToString(),
                        Genero = reader["Genero"].ToString(),
                        AnoPublicacao = (int)reader["AnoPublicacao"],
                        AutorId = (int)reader["AutorId"]
                    };

                    // Preenche o autor do livro
                    livro.Autor = new AutorDAO(_connectionString).BuscarPorId(livro.AutorId);
                    return livro;
                }

                return null;
            }
        }

        public void Remover(int pId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Livro WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", pId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Livro> ListarComAutores()
        {
            List<Livro> lista = new List<Livro>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT l.Id, l.Titulo, l.Genero, l.AnoPublicacao, l.AutorId, a.Nome AS NomeAutor, a.Nacionalidade AS NacionalidadeAutor
                    FROM Livro l
                    INNER JOIN Autor a ON l.AutorId = a.Id";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Livro livro = new Livro()
                    {
                        Id = (int)reader["Id"],
                        Titulo = reader["Titulo"].ToString(),
                        Genero = reader["Genero"].ToString(),
                        AnoPublicacao = (int)reader["AnoPublicacao"],
                        AutorId = (int)reader["AutorId"]
                    };

                    // Preenche o autor do livro
                    livro.Autor = new Autor()
                    {
                        Id = livro.AutorId,
                        Nome = reader["NomeAutor"].ToString(),
                        Nacionalidade = reader["NacionalidadeAutor"].ToString()
                    };

                    lista.Add(livro);
                }
            }

            return lista;
        }
    }
}

