using Biblioteca.Models;
using System.Collections.Generic;

namespace Biblioteca.Interfaces
{
    public interface ILivroDAO
    {
        void Inserir(Livro livro);
        void Atualizar(Livro livro);
        Livro BuscarPorId(int id);
        void Remover(int id);
        List<Livro> ListarComAutores();
    }
}





