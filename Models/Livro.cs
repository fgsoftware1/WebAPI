using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI_prog3.Models
{
    public partial class Livro
    {
        public int IdLivro { get; set; }
        public string Nome { get; set; }
        public string Isbn { get; set; }
        public int NumeroPaginas { get; set; }
        public int IdEditora { get; set; }

        public virtual Editora IdEditoraNavigation { get; set; }
    }
}
