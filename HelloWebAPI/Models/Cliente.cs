using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWebAPI.Models
{
    public class Cliente
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Contato { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}