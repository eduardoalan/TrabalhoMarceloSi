using System;
using System.Collections.Generic;

namespace MarceloAPI.Models
{
    public partial class Imobiliaria
    {
        public Imobiliaria()
        {
            Imovel = new HashSet<Imovel>();
        }

        public int IdImobiliaria { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Imovel> Imovel { get; set; }
    }
}
