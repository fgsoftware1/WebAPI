using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI_prog3.Models
{
    public partial class Cidade
    {
        public int IdCidade { get; set; }
        public string Nome { get; set; }
        public string Regiao { get; set; }
        public int IdPais { get; set; }

        public virtual Pais IdPaisNavigation { get; set; }
    }
}
