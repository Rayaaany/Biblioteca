using Biblioteca.Models;

namespace Biblioteca.Interfaces
{
    public interface ILivroService
    {
        void AdicionarLivro(string titulo, string genero, int anoPublicacao, int autorId);
        List<Livro> ListarLivros();
        Livro BuscarLivro(int id);
        void AtualizarLivro(Livro livro);
        void RemoverLivro(int id);
        List<Livro> PesquisarLivroPorTitulo(string titulo);
    }
}
