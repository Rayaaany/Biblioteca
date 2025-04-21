using Biblioteca.Models;
using Biblioteca.Services;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var configuration = builder.Build();

// Obtenção da string de conexão
string connectionString = configuration.GetConnectionString("ConexaoDB");

AutorService autorService = new AutorService(connectionString);
LivroService livroService = new LivroService(connectionString);

int opcao;
do
{
    Console.Clear();
    Console.WriteLine("==== MENU BIBLIOTECA ====");
    Console.WriteLine("1 - Cadastrar Autor");
    Console.WriteLine("2 - Listar Autores");
    Console.WriteLine("3 - Editar Autor");
    Console.WriteLine("4 - Remover Autor");
    Console.WriteLine("5 - Buscar Autor por Nome");
    Console.WriteLine("6 - Cadastrar Livro");
    Console.WriteLine("7 - Listar Livros");
    Console.WriteLine("8 - Editar Livro");
    Console.WriteLine("9 - Remover Livro");
    Console.WriteLine("10 - Buscar Livro por Título");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");
    opcao = int.Parse(Console.ReadLine());

    try
    {
        switch (opcao)
        {
            case 1: CadastrarAutor(); break;
            case 2: ListarAutores(); break;
            case 3: EditarAutor(); break;
            case 4: RemoverAutor(); break;
            case 5: BuscarAutorPorNome(); break;
            case 6: CadastrarLivro(); break;
            case 7: ListarLivros(); break;
            case 8: EditarLivro(); break;
            case 9: RemoverLivro(); break;
            case 10: BuscarLivroPorTitulo(); break;
            case 0: Console.WriteLine("Saindo..."); break;
            default: Console.WriteLine("Opção inválida!"); break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("\nOcorreu um Erro: " + ex.Message);
    }

    if (opcao != 0)
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

} while (opcao != 0);


// === MÉTODOS ===

void CadastrarAutor()
{
    Console.WriteLine("\n== Cadastro de Autor ==");
    Console.Write("Nome: ");
    string nome = Console.ReadLine();
    Console.Write("Nacionalidade: ");
    string nacionalidade = Console.ReadLine();

    autorService.Inserir(new Autor { Nome = nome, Nacionalidade = nacionalidade });
    Console.WriteLine("Autor cadastrado com sucesso!");
}

void ListarAutores()
{
    Console.WriteLine("\n== Lista de Autores ==");
    List<Autor> autores = autorService.ListarTodos();
    foreach (var a in autores)
    {
        Console.WriteLine($"ID: {a.Id} | Nome: {a.Nome} | Nacionalidade: {a.Nacionalidade}");
    }
}

void EditarAutor()
{
    Console.WriteLine("\n== Editar Autor ==");
    Console.Write("ID do Autor: ");
    int id = int.Parse(Console.ReadLine());

    Autor autor = autorService.BuscarPorId(id);
    if (autor == null)
    {
        Console.WriteLine("Autor não encontrado.");
        return;
    }

    Console.Write("Novo Nome: ");
    autor.Nome = Console.ReadLine();
    Console.Write("Nova Nacionalidade: ");
    autor.Nacionalidade = Console.ReadLine();

    autorService.Editar(autor);
    Console.WriteLine("Autor atualizado com sucesso!");
}

void RemoverAutor()
{
    Console.WriteLine("\n== Remover Autor ==");
    Console.Write("ID do Autor: ");
    int id = int.Parse(Console.ReadLine());

    autorService.Remover(id);
    Console.WriteLine("Autor removido com sucesso!");
}

void BuscarAutorPorNome()
{
    Console.WriteLine("\n== Buscar Autor por Nome ==");
    Console.Write("Nome: ");
    string nome = Console.ReadLine();

    List<Autor> autores = autorService.BuscarPorNome(nome);
    foreach (var a in autores)
    {
        Console.WriteLine($"ID: {a.Id} | Nome: {a.Nome} | Nacionalidade: {a.Nacionalidade}");
    }
}

void CadastrarLivro()
{
    Console.WriteLine("\n== Cadastro de Livro ==");
    Console.Write("Título: ");
    string titulo = Console.ReadLine();
    Console.Write("Gênero: ");
    string genero = Console.ReadLine();
    Console.Write("Ano de Publicação: ");
    int ano = int.Parse(Console.ReadLine());
    Console.Write("ID do Autor: ");
    int autorId = int.Parse(Console.ReadLine());

    livroService.Inserir(new Livro
    {
        Titulo = titulo,
        Genero = genero,
        AnoPublicacao = ano,
        AutorId = autorId
    });

    Console.WriteLine("Livro cadastrado com sucesso!");
}

void ListarLivros()
{
    Console.WriteLine("\n== Lista de Livros ==");
    List<Livro> livros = livroService.ListarTodos();
    foreach (var l in livros)
    {
        Console.WriteLine($"ID: {l.Id} | Título: {l.Titulo} | Gênero: {l.Genero} | Ano: {l.AnoPublicacao} | Autor: {l.AutorNome} ({l.AutorNacionalidade})");
    }
}

void EditarLivro()
{
    Console.WriteLine("\n== Editar Livro ==");
    Console.Write("ID do Livro: ");
    int id = int.Parse(Console.ReadLine());

    Livro livro = livroService.BuscarPorId(id);
    if (livro == null)
    {
        Console.WriteLine("Livro não encontrado.");
        return;
    }

    Console.Write("Novo Título: ");
    livro.Titulo = Console.ReadLine();
    Console.Write("Novo Gênero: ");
    livro.Genero = Console.ReadLine();
    Console.Write("Novo Ano de Publicação: ");
    livro.AnoPublicacao = int.Parse(Console.ReadLine());
    Console.Write("Novo ID do Autor: ");
    livro.AutorId = int.Parse(Console.ReadLine());

    livroService.Editar(livro);
    Console.WriteLine("Livro atualizado com sucesso!");
}

void RemoverLivro()
{
    Console.WriteLine("\n== Remover Livro ==");
    Console.Write("ID do Livro: ");
    int id = int.Parse(Console.ReadLine());

    livroService.Remover(id);
    Console.WriteLine("Livro removido com sucesso!");
}

void BuscarLivroPorTitulo()
{
    Console.WriteLine("\n== Buscar Livro por Título ==");
    Console.Write("Título: ");
    string titulo = Console.ReadLine();

    List<Livro> livros = livroService.BuscarPorTitulo(titulo);
    foreach (var l in livros)
    {
        Console.WriteLine($"ID: {l.Id} | Título: {l.Titulo} | Gênero: {l.Genero} | Ano: {l.AnoPublicacao} | Autor: {l.AutorNome} ({l.AutorNacionalidade})");
    }
}