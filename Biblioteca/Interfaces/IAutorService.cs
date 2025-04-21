using Biblioteca.Models;
using System.Collections.Generic;

namespace Biblioteca.Interfaces
{
    public interface IAutorService
    {
        void AdicionarAutor(string nome, string nacionalidade);
        List<Autor> ListarAutores();
        Autor BuscarAutor(int id);
        void AtualizarAutor(Autor autor);
        void RemoverAutor(int id);
        List<Autor> PesquisarAutorPorNome(string nome);
    }
}