using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI_prog3.Models
{
    public partial class Editora
    {
        public Editora()
        {
            Livros = new HashSet<Livro>();
        }

        public int IdEditora { get; set; }
        public string Nome { get; set; }
        public int Ativo { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}
