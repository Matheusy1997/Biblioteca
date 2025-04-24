using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    internal class Usuario
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int LivrosEmprestado { get; set; }
        public List<Livros> LivrosEmprestados { get; set; } = new List<Livros>();

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
                throw new Exception("Livro já emprestado para o usuário.");
            }
            // Verifica se o usuário já tem 3 livros emprestados
            if (LivrosEmprestado == 3)
            {
                throw new Exception("Limite de livros emprestados atingido.");
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
                throw new Exception("Livro não encontrado na lista de livros emprestados.");
            }
            else
            {
                // Remove o livro da lista de livros emprestados
                LivrosEmprestados.Remove(livro);
                LivrosEmprestado--;
            }
        }

        public override bool Equals(object? obj)
        {
            if(obj is Usuario usuario)
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
