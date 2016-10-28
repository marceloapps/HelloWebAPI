using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWebAPI.Models
{
    public interface IClientesRepositorio
    {
        IEnumerable<Cliente> Buscar();
        Cliente Buscar(string Codigo);
        void Manter(Cliente item);
        void Apagar(string Codigo);
    }
}
