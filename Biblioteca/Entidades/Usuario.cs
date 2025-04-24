using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    internal class Usuario
    {
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public string CPF { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public int LivrosEmprestado { get; private set; }
        public List<Livros> LivrosEmprestados { get; private set; } = new List<Livros>();

        // Construtor da classe Usuario
        public Usuario(string nome, string endereco, string cPF, string telefone, string email, DateTime dataNascimento)
        {
            Nome = nome;
            Endereco = endereco;
            CPF = cPF;
            Telefone = telefone;
            Email = email;
            DataNascimento = dataNascimento;
            LivrosEmprestado = 0;
        }

        // Método para adicionar um livro à lista de livros emprestados
        public void AdicionarLivroEmprestado(Livros livro)
        {
            // Verifica se o livro já está na lista de livros emprestados
            if (LivrosEmprestados.Contains(livro))
            {
                throw new ArgumentException("Livro já emprestado para o usuário.");
            }
            // Verifica se o usuário já tem 3 livros emprestados
            if (LivrosEmprestado == 3)
            {
                throw new ArgumentException("Limite de livros emprestados atingido.");
            }
            else
            {
                // Incrementa o contador de livros emprestados se não tiver 3 livros emprestados
                LivrosEmprestado++;
                LivrosEmprestados.Add(livro);
            }

        }

        // Método para remover um livro da lista de livros emprestados
        public void RemoverLivroEmprestado(Livros livro)
        {
            if (!LivrosEmprestados.Contains(livro))
            {
                throw new ArgumentException("Livro não encontrado na lista de livros emprestados.");
            }
            else
            {
                // Remove o livro da lista de livros emprestados
                LivrosEmprestados.Remove(livro);
                LivrosEmprestado--;
            }
        }

        // Método para listar todos os livros emprestados
        public void ListarLivrosEmprestados()
        {
            if (LivrosEmprestados.Count == 0)
            {
                throw new ArgumentException("Nenhum livro emprestado.");
            }

            foreach (Livros livro in LivrosEmprestados)
            {
                Console.WriteLine(livro.ToString());
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is Usuario usuario)
            {
                return CPF.Equals(usuario.CPF);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return CPF.GetHashCode();
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Endereço: {Endereco}, CPF: {CPF}," +
                $" Telefone: {Telefone}, Email: {Email}," +
                $" Data de Nascimento: {DataNascimento.ToShortDateString()}," +
                $" Livros Emprestados: {LivrosEmprestado}";
        }
    }
}
