using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWebAPI.Models
{
    public class ClientesRepositorio : IClientesRepositorio
    {
        static List<Cliente> ListaClientes = new List<Cliente>();

        public IEnumerable<Cliente> Buscar()
        {
            return ListaClientes;
        }

        public Cliente Buscar(string Codigo)
        {
            return ListaClientes.Where(e => e.Equals(Codigo)).FirstOrDefault();
        }

        public void Manter(Cliente item)
        {
            var itemManter = ListaClientes.SingleOrDefault(e => e.Codigo == item.Codigo);

            if (itemManter == null)
            {
                ListaClientes.Add(item);
            }
            else
            {
                itemManter.Codigo = item.Codigo;
                itemManter.Descricao = item.Descricao;
                itemManter.Contato = item.Contato;
                itemManter.DataCadastro = item.DataCadastro;
            }
        }

        public void Apagar(string Codigo)
        {
            var item = ListaClientes.SingleOrDefault(e => e.Codigo == Codigo);
            if (item != null)
                ListaClientes.Remove(item);
        }
    }
}