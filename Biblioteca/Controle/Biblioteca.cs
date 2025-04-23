using Biblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Controle
{
    internal class Biblioteca
    {
        public List<Livros> Livros { get; set; } = new List<Livros>();
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public List<Autor> Autores { get; set; } = new List<Autor>();
        public void AdicionarLivro(Livros livro)
        {
            Livros.Add(livro);
        }
        public void AdicionarUsuario(Usuario usuario)
        {
            Usuarios.Add(usuario);
        }
        public void AdicionarAutor(Autor autor)
        {
            Autores.Add(autor);
        }
    }
}
