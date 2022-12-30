using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Dtos.Usuario
{
    public class AtualizarRequisicao
    {
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public EnderecoCriarAtualizarRequisicao Endereco { get; set; }
    }
}