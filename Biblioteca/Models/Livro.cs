namespace Biblioteca.Models
{
    // Representa a entidade Livro
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public int AnoPublicacao { get; set; }
        public int AutorId { get; set; }

        // Propriedade para exibir informações do autor na listagem
        public string NomeAutor { get; set; } = string.Empty;
        public string NacionalidadeAutor { get; set; } = string.Empty;
    }
}

