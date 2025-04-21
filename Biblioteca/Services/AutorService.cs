using Biblioteca.Interfaces;
using Biblioteca.Models;

namespace Biblioteca.Services
{
    // Classe responsável pelas regras de negócio relacionadas ao Autor
    public class AutorService : IAutorService
    {
        private readonly IAutorDAO _autorDAO;

        // Construtor que injeta a dependência do DAO
        public AutorService(IAutorDAO autorDAO)
        {
            _autorDAO = autorDAO;
        }

        // Chama o DAO para inserir um novo autor
        public void Inserir(Autor autor)
        {
            _autorDAO.Inserir(autor);
        }

        // Chama o DAO para listar todos os autores
        public List<Autor> ListarTodos()
        {
            return _autorDAO.ListarTodos();
        }

        // Chama o DAO para editar um autor existente
        public void Editar(Autor autor)
        {
            _autorDAO.Editar(autor);
        }

        // Chama o DAO para remover um autor pelo ID
        public void Remover(int id)
        {
            _autorDAO.Remover(id);
        }

        // Chama o DAO para buscar autores pelo nome
        public List<Autor> BuscarPorNome(string nome)
        {
            return _autorDAO.BuscarPorNome(nome);
        }

        public void AdicionarAutor(string nome, string nacionalidade)
        {
            throw new NotImplementedException();
        }

        public List<Autor> ListarAutores()
        {
            throw new NotImplementedException();
        }

        public Autor BuscarAutor(int id)
        {
            throw new NotImplementedException();
        }

        public void AtualizarAutor(Autor autor)
        {
            throw new NotImplementedException();
        }

        public void RemoverAutor(int id)
        {
            throw new NotImplementedException();
        }

        public List<Autor> PesquisarAutorPorNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
