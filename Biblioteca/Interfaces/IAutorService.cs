using Biblioteca.Models;

namespace Biblioteca.Interfaces
{
    public interface IAutorService
    {
        void AdicionarAutor(string nome, string nacionalidade);
        void AtualizarAutor(Autor autor);
        void RemoverAutor(int id);
        Autor BuscarAutor(int id);
        List<Autor> ListarAutores();
    }
}
