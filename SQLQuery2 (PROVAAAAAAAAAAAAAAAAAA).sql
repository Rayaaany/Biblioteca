-- Criar novo banco de dados
CREATE DATABASE Biblioteca;
GO

-- Usar o novo banco
USE Biblioteca;
GO

-- Criar tabela de autores
CREATE TABLE Autor (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL,
    Nacionalidade NVARCHAR(100)
);
GO

-- Criar tabela de livros com chave estrangeira
CREATE TABLE Livro (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Titulo NVARCHAR(150) NOT NULL,
    Genero NVARCHAR(100),
    AnoPublicacao INT,
    AutorId INT NOT NULL,
    CONSTRAINT FK_Livro_Autor FOREIGN KEY (AutorId) REFERENCES Autor(Id) ON DELETE CASCADE
);
GO

-- Inserir autores
INSERT INTO Autor (Nome, Nacionalidade)
VALUES ('Monteiro Lobato', 'Brasileiro');

INSERT INTO Autor (Nome, Nacionalidade)
VALUES ('Carolina Maria de Jesus', 'Brasileira');

-- Inserir livros relacionados aos autores
INSERT INTO Livro (Titulo, Genero, AnoPublicacao, AutorId)
VALUES ('O Picapau Amarelo', 'Infantil', 1939, 1);

INSERT INTO Livro (Titulo, Genero, AnoPublicacao, AutorId)
VALUES ('Quarto de Despejo', 'Autobiografia', 1960, 2);

SELECT * FROM Autor;
SELECT * FROM Livro;

SELECT 
    L.Titulo,
    L.Genero,
    L.AnoPublicacao,
    A.Nome AS Autor,
    A.Nacionalidade
FROM Livro L
INNER JOIN Autor A ON L.AutorId = A.Id;