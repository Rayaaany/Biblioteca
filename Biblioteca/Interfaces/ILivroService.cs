using Biblioteca.Models;
using System.Collections.Generic;

namespace Biblioteca.Interfaces
{
    public interface ILivroService
    {
        void AdicionarLivro(string titulo, string genero, int anoPublicacao, int autorId);
        void AtualizarLivro(Livro livro);
        Livro BuscarLivro(int id);
        List<Livro> ListarLivrosComAutor();
        void RemoverLivro(int id);
    }
}

