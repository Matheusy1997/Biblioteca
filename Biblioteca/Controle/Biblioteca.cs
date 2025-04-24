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
        public List<Livros> Livros { get; private set; } = new List<Livros>();
        public List<Usuario> Usuarios { get; private set; } = new List<Usuario>();
        public List<Autor> Autores { get; private set; }
        public List<Livros> LivrosEmprestados { get; set; }

        public void AdicionarLivro(Autor autor, Livros livro)
        {
            // Verifica se o livro já está na lista de livros
            if (Livros.Contains(livro))
            {
                throw new DomainException("Livro já cadastrado.");
            }
            // Verifica se o autor já está na lista de autores
            if (!Autores.Contains(autor))
            {
                throw new DomainException("Autor não cadastrado.");
            }
            // Verifica se o livro já foi publicado pelo autor
            if (autor.LivroExiste(livro))
            {
                throw new DomainException("Livro já publicado por este autor.");
            }
            // Adiciona o livro à lista de livros
            Livros.Add(livro);
            // Adiciona o livro à lista de livros publicados do autor
            autor.AdicionarLivro(livro);
        }
        public void AdicionarUsuario(Usuario usuario)
        {
            // Verifica se o usuário já está na lista de usuários
            if (Usuarios.Contains(usuario))
            {
                throw new DomainException("Usuário já cadastrado.");
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
                throw new DomainException("Autor já cadastrado.");
            }
            else
            {
                // Adiciona o autor à lista de autores
                Autores.Add(autor);
            }

        }

        // Método para remover um livro da lista de livros
        public void EmprestarLivro(Usuario usuario, Livros livro)
        {
            // Verifica se o usuário já está na lista de usuários
            if (!Usuarios.Contains(usuario))
            {
                throw new DomainException("Usuário não cadastrado.");
            }
            // Verifica se o livro já está na lista de livros
            if (!Livros.Contains(livro))
            {
                throw new DomainException("Livro não cadastrado.");
            }
            // Verifica se o livro já está emprestado
            if (usuario.LivrosEmprestados.Contains(livro))
            {
                throw new DomainException("Livro já emprestado para o usuário.");
            }
            // Verifica se o usuário já tem 3 livros emprestados
            if (usuario.LivrosEmprestados.Count == 3)
            {
                throw new DomainException("Limite de livros emprestados atingido.");
            }
            // Adiciona o livro à lista de livros emprestados do usuário
            usuario.AdicionarLivroEmprestado(livro);
            // Remove o livro da lista de livros disponíveis
            Livros.Remove(livro);
            // Adiciona o livro a lista de livros emprestado
            LivrosEmprestados.Add(livro);
        }

        // Método para devolver um livro
        public void DevolverLivro(Usuario usuario, Livros livro)
        {
            // Verifica se o usuário já está na lista de usuários
            if (!Usuarios.Contains(usuario))
            {
                throw new DomainException("Usuário não cadastrado.");
            }
            // Verifica se o livro já está na lista de livros emprestados do usuário
            if (!usuario.LivrosEmprestados.Contains(livro))
            {
                throw new DomainException("Livro não encontrado na lista de livros emprestados.");
            }
            // Verifica se o livro já foi devolvido
            if (LivrosEmprestados.Contains(livro))
            {
                throw new DomainException("Livro já devolvido.");
            }
            // Remove o livro da lista de livros emprestados do usuário
            usuario.RemoverLivroEmprestado(livro);
            // Remove o livro da lista de livros emprestados
            LivrosEmprestados.Remove(livro);
            // Adiciona o livro de volta à lista de livros disponíveis
            Livros.Add(livro);
        }

        // Método para listar todos os livros disponíveis
        public void ListarLivrosDisponiveis()
        {
            if (Livros.Count == 0)
            {
                throw new DomainException("Nenhum livro disponível.");
            }

            foreach (Livros livro in Livros)
            {
                Console.WriteLine(livro.ToString());
            }

        }

        // Método para listar todos os usuários cadastrados
        public void ListarUsuarios()
        {
            if (Usuarios.Count == 0)
            {
                throw new DomainException("Nenhum usuário cadastrado.");
            }

            foreach (Usuario usuario in Usuarios)
            {
                Console.WriteLine(usuario.ToString());
            }
        }

        // Método para listar todos os autores cadastrados
        public void ListarAutores()
        {
            if (Autores.Count == 0)
            {
                throw new DomainException("Nenhum autor cadastrado.");
            }

            foreach (Autor autor in Autores)
            {
                Console.WriteLine(autor.ToString());
            }

        }
    }
}
