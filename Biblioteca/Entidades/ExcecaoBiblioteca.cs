using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    internal class ExcecaoBiblioteca : ApplicationException
    {
        public ExcecaoBiblioteca(string message) : base(message)
        {
        }
    }
}
