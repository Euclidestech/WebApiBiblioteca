using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Exececoes
{
    public class ExececaoCpfExistente : Exception
    {
        public ExececaoCpfExistente() : base("ja existe esse cpf cadastrado")
        {

        }
        
    }
}