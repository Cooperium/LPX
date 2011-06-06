using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L.PX.Core
{
    public class Lance
    {
        public Int32 Id { get; set; }
        public decimal Incremento { get; set; }
        public Int32 NumeroDeLotes { get; set; }
        public User User { get; set; }

        private Lance() { }

        public static Lance Build(Decimal incremento, int numeroDeLotes, User usuario)
        {
            return new Lance() { Incremento = incremento, NumeroDeLotes = numeroDeLotes, User = usuario };
        }


     
    }
}
