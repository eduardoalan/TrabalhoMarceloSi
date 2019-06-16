using System;
using System.Collections.Generic;

namespace MarceloAPI.Models
{
    public partial class Imovel
    {
        public int IdImovel { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Cep { get; set; }
        public int IdImobiliaria { get; set; }

        public virtual Imobiliaria IdImobiliariaNavigation { get; set; }
    }
}
