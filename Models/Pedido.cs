using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Pedido
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public decimal Quantidade { get; set; }
        [Required]
        public decimal Subtotal { get; set; }

        public int LivrosId { get; set; }

        public List<Livro> Livros { get; set; }
        public Usuario Usuario { get; set; }

    }
}