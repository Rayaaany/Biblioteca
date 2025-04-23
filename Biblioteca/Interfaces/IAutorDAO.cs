using Biblioteca.Models;

namespace Biblioteca.Interfaces
{
    public interface IAutorDAO
    {
        void Adicionar(Autor autor);
        void Atualizar(Autor autor);
        void Remover(int id);
        Autor BuscarPorId(int id);
        List<Autor> ListarTodos();
    }
}






