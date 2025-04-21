using Biblioteca.Models;

namespace Biblioteca.Interfaces
{
    public interface ILivroDAO
    {
        void Adicionar(Livro livro);
        List<Livro> Listar();
        Livro BuscarPorId(int id);
        void Atualizar(Livro livro);
        void Remover(int id);
        List<Livro> PesquisarPorTitulo(string titulo);
    }
}