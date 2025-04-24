using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    internal class Autor
    {
        public string Nome { get; private set; }
        public string Nacionalidade { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Biografia { get; private set; }
        public List<Livros> LivrosPublicados { get; private set; } = new List<Livros>();

        // Construtor da classe Autor
        public Autor(string nome, string nacionalidade, DateTime dataNascimento, string biografia)
        {
            Nome = nome;
            Nacionalidade = nacionalidade;
            DataNascimento = dataNascimento;
            Biografia = biografia;
        }

        // Método para adicionar um livro à lista de livros publicados
        public void AdicionarLivro(Livros livro)
        {
            if (LivrosPublicados.Contains(livro))
                throw new DomainException("Livro já publicado por este autor.");
            else
                // Adiciona o livro à lista de livros publicados
                LivrosPublicados.Add(livro);
        }

        // Método para listar todos os livros publicados pelo autor
        public void ListarLivrosPublicados()
        {
            if (LivrosPublicados.Count == 0)
            {
                throw new DomainException("Nenhum livro publicado.");
            }

            foreach (Livros livro in LivrosPublicados)
            {
                Console.WriteLine(livro.ToString());
            }
        }

        public bool LivroExiste(Livros livro)
        {
            return LivrosPublicados.Contains(livro);
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Nacionalidade: {Nacionalidade}, Data de Nascimento: {DataNascimento.ToShortDateString()}, Biografia: {Biografia}";
        }

        public override int GetHashCode()
        {
            return Nome.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Autor autor)
            {
                return Nome.Equals(autor.Nome);
            }
            return false;
        }
    }
}
