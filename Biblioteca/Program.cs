using Biblioteca.Models;
using Biblioteca.Services;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var configuration = builder.Build();

string connectionString = configuration.GetConnectionString("ConexaoPadrao");

AutorService autorService = new AutorService(connectionString);
LivroService livroService = new LivroService(connectionString);

int opcao;
do
{
    Console.Clear();
    Console.WriteLine("==== MENU BIBLIOTECA ====");
    Console.WriteLine("1 - Cadastrar Autor");
    Console.WriteLine("2 - Listar Autores");
    Console.WriteLine("3 - Atualizar Autor");
    Console.WriteLine("4 - Remover Autor");
    Console.WriteLine("5 - Cadastrar Livro");
    Console.WriteLine("6 - Listar Livros com Autor");
    Console.WriteLine("7 - Atualizar Livro");
    Console.WriteLine("8 - Remover Livro");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");
    opcao = int.Parse(Console.ReadLine());

    try
    {
        switch (opcao)
        {
            case 1: CadastrarAutor(); break;
            case 2: ListarAutores(); break;
            case 3: AtualizarAutor(); break;
            case 4: RemoverAutor(); break;
            case 5: CadastrarLivro(); break;
            case 6: ListarLivrosComAutor(); break;
            case 7: AtualizarLivro(); break;
            case 8: RemoverLivro(); break;
            case 0: Console.WriteLine("Saindo..."); break;
            default: Console.WriteLine("Opção inválida!"); break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("\nErro: " + ex.Message);
    }

    if (opcao != 0)
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

} while (opcao != 0);

// ==== Funções de Autor ====

void CadastrarAutor()
{
    Console.WriteLine("\n== Cadastro de Autor ==");
    Console.Write("Nome: ");
    string nome = Console.ReadLine();
    Console.Write("Nacionalidade: ");
    string nacionalidade = Console.ReadLine();

    autorService.AdicionarAutor(nome, nacionalidade);
    Console.WriteLine("Autor cadastrado com sucesso!");
}

void ListarAutores()
{
    Console.WriteLine("\n== Lista de Autores ==");
    var autores = autorService.ListarAutores();
    foreach (var a in autores)
    {
        Console.WriteLine($"ID: {a.Id} | Nome: {a.Nome} | Nacionalidade: {a.Nacionalidade}");
    }
}

void AtualizarAutor()
{
    Console.WriteLine("\n== Atualizar Autor ==");
    Console.Write("ID do Autor: ");
    int id = int.Parse(Console.ReadLine());

    var autor = autorService.BuscarAutor(id);
    if (autor == null)
    {
        Console.WriteLine("Autor não encontrado.");
        return;
    }

    Console.Write("Novo Nome: ");
    autor.Nome = Console.ReadLine();
    Console.Write("Nova Nacionalidade: ");
    autor.Nacionalidade = Console.ReadLine();

    autorService.AtualizarAutor(autor);
    Console.WriteLine("Autor atualizado com sucesso!");
}

void RemoverAutor()
{
    Console.WriteLine("\n== Remover Autor ==");
    Console.Write("ID do Autor: ");
    int id = int.Parse(Console.ReadLine());

    autorService.RemoverAutor(id);
    Console.WriteLine("Autor removido com sucesso!");
}

// ==== Funções de Livro ====

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

    livroService.AdicionarLivro(titulo, genero, ano, autorId);
    Console.WriteLine("Livro cadastrado com sucesso!");
}

void ListarLivrosComAutor()
{

        Console.WriteLine("\n== Lista de Livros com Autores ==");

        // Chama o serviço que retorna os livros com autor
        var livros = livroService.ListarLivrosComAutor();

        // Exibe cada livro com seus dados
        foreach (var l in livros)
        {
            Console.WriteLine($"Título: {l.Titulo} | Gênero: {l.Genero} | Ano: {l.AnoPublicacao} | Autor: {l.NomeAutor} | Nacionalidade: {l.NacionalidadeAutor}");
        }
    }

void AtualizarLivro()
{
    Console.WriteLine("\n== Atualizar Livro ==");
    Console.Write("ID do Livro: ");
    int id = int.Parse(Console.ReadLine());

    var livro = livroService.BuscarLivro(id);
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

    livroService.AtualizarLivro(livro);
    Console.WriteLine("Livro atualizado com sucesso!");
}

void RemoverLivro()
{
    Console.WriteLine("\n== Remover Livro ==");
    Console.Write("ID do Livro: ");
    int id = int.Parse(Console.ReadLine());

    livroService.RemoverLivro(id);
    Console.WriteLine("Livro removido com sucesso!");
}

