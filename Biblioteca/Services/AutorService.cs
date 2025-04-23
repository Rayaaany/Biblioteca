using Biblioteca.DAO;
using Biblioteca.Interfaces;
using Biblioteca.Models;

namespace Biblioteca.Services
{
    public class AutorService : IAutorService
    {
        private AutorDAO _autorDAO;

        public AutorService(string connectionString)
        {
            _autorDAO = new AutorDAO(connectionString);
        }

        public void AdicionarAutor(string pNome, string pNacionalidade)
        {
            if (string.IsNullOrWhiteSpace(pNome) || string.IsNullOrWhiteSpace(pNacionalidade))
                throw new Exception("Nome e Nacionalidade são obrigatórios.");

            var autor = new Autor
            {
                Nome = pNome,
                Nacionalidade = pNacionalidade
            };

            _autorDAO.Adicionar(autor);
        }

        public void AtualizarAutor(Autor pAutor)
        {
            if (pAutor == null)
                throw new Exception("Autor inválido.");

            if (string.IsNullOrWhiteSpace(pAutor.Nome) || string.IsNullOrWhiteSpace(pAutor.Nacionalidade))
                throw new Exception("Nome e Nacionalidade são obrigatórios.");

            _autorDAO.Atualizar(pAutor);
        }

        public Autor BuscarAutor(int pId)
        {
            return _autorDAO.BuscarPorId(pId);
        }

        public List<Autor> ListarAutores()
        {
            return _autorDAO.ListarTodos();
        }

        public void RemoverAutor(int pId)
        {
            Autor autor = _autorDAO.BuscarPorId(pId);

            if (autor == null)
                throw new Exception("O Autor não foi encontrado.");

            _autorDAO.Remover(pId);
        }
    }
}
