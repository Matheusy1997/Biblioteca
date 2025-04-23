using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    internal class Livros : IComparable<Livros>
    {
        public string Titulo { get; set; }
        public string Subtítulo { get; set; }
        public int NumeroPaginas { get; set; }
        public string Genero { get; set; }
        public string Sinopse { get; set; }

        public Livros(string titulo, string subtítulo, int numeroPaginas, string genero, string sinopse)
        {
            Titulo = titulo;
            Subtítulo = subtítulo;
            NumeroPaginas = numeroPaginas;
            Genero = genero;
            Sinopse = sinopse;
        }

        public override string ToString()
        {
            return $"Título: {Titulo}, Subtítulo: {Subtítulo}, Número de Páginas: {NumeroPaginas}, Gênero: {Genero}, Sinopse: {Sinopse}";
        }

        public int CompareTo(Livros other)
        {
            return Titulo.CompareTo(other.Titulo);
        }

        public override int GetHashCode()
        {
            return Titulo.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if (obj is Livros livro)
            {
                return Titulo.Equals(livro.Titulo);
            }
            return false;
        }

    }
}
