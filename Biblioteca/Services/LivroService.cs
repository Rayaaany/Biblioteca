using Biblioteca.DAO;
using Biblioteca.Interfaces;
using Biblioteca.Models;

namespace Biblioteca.Services
{
    public class LivroService : ILivroService
    {
        private LivroDAO _livroDAO;

        public LivroService(string connectionString)
        {
            _livroDAO = new LivroDAO(connectionString);
        }

        public void AdicionarLivro(string pTitulo, string pGenero, int pAnoPublicacao, int pAutorId)
        {
            if (string.IsNullOrWhiteSpace(pTitulo))
                throw new Exception("Título é obrigatório.");
            if (string.IsNullOrWhiteSpace(pGenero))
                throw new Exception("Gênero é obrigatório.");
            if (pAnoPublicacao <= 0)
                throw new Exception("Ano de publicação inválido.");

            var livro = new Livro
            {
                Titulo = pTitulo,
                Genero = pGenero,
                AnoPublicacao = pAnoPublicacao,
                AutorId = pAutorId
            };

            _livroDAO.Inserir(livro);
        }

        public void AtualizarLivro(Livro pLivro)
        {
            if (pLivro == null)
                throw new Exception("Livro inválido.");

            if (string.IsNullOrWhiteSpace(pLivro.Titulo))
                throw new Exception("Título é obrigatório.");

            _livroDAO.Atualizar(pLivro);
        }

        public Livro BuscarLivro(int pId)
        {
            return _livroDAO.BuscarPorId(pId);
        }

        public List<Livro> ListarLivrosComAutor()
        {
            return _livroDAO.ListarComAutores();
        }

        public void RemoverLivro(int pId)
        {
            Livro livro = _livroDAO.BuscarPorId(pId);

            if (livro == null)
                throw new Exception("O Livro não foi encontrado.");

            _livroDAO.Remover(pId);
        }
    }
}

