using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    internal class Autor
    {
        public string Nome { get; set; }
        public string Nacionalidade { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Biografia { get; set; }
        public List<Livros> LivrosPublicados { get; set; } = new List<Livros>();

        public Autor(string nome, string nacionalidade, DateTime dataNascimento, string biografia)
        {
            Nome = nome;
            Nacionalidade = nacionalidade;
            DataNascimento = dataNascimento;
            Biografia = biografia;
        }

        public void AdicionarLivro(Livros livro)
        {
            if(LivrosPublicados.Contains(livro))
                throw new Exception("Livro já publicado por este autor.");
            else
                // Adiciona o livro à lista de livros publicados
                LivrosPublicados.Add(livro);
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
