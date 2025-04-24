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
        public List<Autor> Autores { get; set; }
        public Dictionary<Autor, List<Livros>> AutoresEhLivros { get; set; } = new Dictionary<Autor, List<Livros>>();
        public void AdicionarLivro(Autor autor, Livros livro)
        {
            // Verifica se o livro já está na lista de livros
            if (Livros.Contains(livro))
            {
                throw new Exception("Livro já cadastrado.");
            }
            else
            {
                // Adiciona o livro à lista de livros
                Livros.Add(livro);
                // Adiciona o livro à lista de livros do autor
                AutoresEhLivros[autor].Add(livro);
            }
        }
        public void AdicionarUsuario(Usuario usuario)
        {
            // Verifica se o usuário já está na lista de usuários
            if (Usuarios.Contains(usuario))
            {
                throw new Exception("Usuário já cadastrado.");
            }
            else
            {
                // Adiciona o usuário à lista de usuários
                Usuarios.Add(usuario);
            }
        }
        public void CadastrarAutor(Autor autor)
        {
            // Verifica se o autor já está na lista de autores
            if (Autores.Contains(autor))
            {
                throw new Exception("Autor já cadastrado.");
            }
            else
            {
                // Adiciona o autor à lista de autores
                Autores.Add(autor);
                // Adiciona o autor ao dicionário de autores e livros
                AutoresEhLivros.Add(autor, new List<Livros>());
            }  
               
        }
    }
}
