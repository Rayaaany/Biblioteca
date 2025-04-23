using Biblioteca.Models;

public class Livro
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public int AnoPublicacao { get; set; }
    public int AutorId { get; set; } // <- ESSA LINHA AQUI É ESSENCIAL
    public string NomeAutor { get; set; } // opcional para JOIN
    public string NacionalidadeAutor { get; set; } // opcional para JOIN
    public Autor Autor { get; set; } // Objeto do autor (para exibir nome e nacionalidade)
}
