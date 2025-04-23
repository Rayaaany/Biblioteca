namespace Biblioteca.Models
{
    public class Livro
    {
        public int Id { get; set; } // ID do livro
        public string Titulo { get; set; } = string.Empty; // Título do livro
        public string Genero { get; set; } = string.Empty; // Gênero literário
        public int AnoPublicacao { get; set; } // Ano da publicação
        public int AutorId { get; set; } // Chave estrangeira do autor

        // Propriedades adicionais para exibir dados do autor na listagem
        public string NomeAutor { get; set; } = string.Empty; // Nome do autor (JOIN)
        public string NacionalidadeAutor { get; set; } = string.Empty; // Nacionalidade (JOIN)
        public Autor Autor { get; set; } // Objeto do autor (para exibir nome e nacionalidade)
    }
}

