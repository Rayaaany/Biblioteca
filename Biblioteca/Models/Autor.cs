namespace Biblioteca.Models;

// Representa o autor de um ou mais livros
public class Autor
{
    public int Id { get; set; } // ID único do autor
    public string Nome { get; set; } = string.Empty;// Nome completo do autor
    public string Nacionalidade { get; set; } = string.Empty; // Nacionalidade do autor
}


