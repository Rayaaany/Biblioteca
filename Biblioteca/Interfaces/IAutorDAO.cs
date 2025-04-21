using Biblioteca.Models;
using System.Collections.Generic;

namespace Biblioteca.Interfaces
{
    public interface IAutorDAO
    {
        void Adicionar(Autor autor);
        List<Autor> Listar();
        Autor BuscarPorId(int id);
        void Atualizar(Autor autor);
        void Remover(int id);
        List<Autor> PesquisarPorNome(string nome);
    }
}




