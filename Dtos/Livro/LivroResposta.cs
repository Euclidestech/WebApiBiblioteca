using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Dtos.Livro
{
    public class LivroResposta
    {
        public int Id {get; set;}
         public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Autor { get; set; }
        public decimal Preco { get; set; }
        public string Status { get; set; }
    }
}