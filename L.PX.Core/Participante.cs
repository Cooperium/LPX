using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace L.PX.Core
{
    public class Participante
    {
        [Key]
        public Int32 id { get; set; }

        public User Usuario { get; set; }
        public Papel papel { get; set; }
        public Leilao Leilao { get; set; }

        protected Participante() { }

        public static Participante Build(User usuario, Papel papel)
        {
            return new Participante() { papel = papel, Usuario = usuario };
        }

    }


    public enum Papel
    {
        Contratante,
        Participante,
    }

}
