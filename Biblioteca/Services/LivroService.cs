using Biblioteca.Interfaces;
using Biblioteca.Models;

namespace Biblioteca.Services
{
    // Classe responsável pelas regras de negócio relacionadas ao Livro
    public class LivroService : ILivroService
    {
        private readonly ILivroDAO _livroDAO;

        // Construtor que injeta a dependência do DAO
        public LivroService(ILivroDAO livroDAO)
        {
            _livroDAO = livroDAO;
        }

        // Chama o DAO para inserir um novo livro
        public void Inserir(Livro livro)
        {
            _livroDAO.Inserir(livro);
        }

        // Chama o DAO para listar todos os livros
        public List<Livro> ListarTodos()
        {
            return _livroDAO.ListarTodos();
        }

        // Chama o DAO para editar um livro existente
        public void Editar(Livro livro)
        {
            _livroDAO.Editar(livro);
        }

        // Chama o DAO para remover um livro pelo ID
        public void Remover(int id)
        {
            _livroDAO.Remover(id);
        }

        // Chama o DAO para buscar livros pelo título
        public List<Livro> BuscarPorTitulo(string titulo)
        {
            return _livroDAO.BuscarPorTitulo(titulo);
        }

        public void AdicionarLivro(string titulo, string genero, int anoPublicacao, int autorId)
        {
            throw new NotImplementedException();
        }

        public List<Livro> ListarLivros()
        {
            throw new NotImplementedException();
        }

        public Livro BuscarLivro(int id)
        {
            throw new NotImplementedException();
        }

        public void AtualizarLivro(Livro livro)
        {
            throw new NotImplementedException();
        }

        public void RemoverLivro(int id)
        {
            throw new NotImplementedException();
        }

        public List<Livro> PesquisarLivroPorTitulo(string titulo)
        {
            throw new NotImplementedException();
        }
    }
}

