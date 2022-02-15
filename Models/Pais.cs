using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI_prog3.Models
{
    public partial class Pais
    {
        public Pais()
        {
            Cidades = new HashSet<Cidade>();
        }

        public int IdPais { get; set; }
        public int Populacao { get; set; }
        public string Moeda { get; set; }

        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}
