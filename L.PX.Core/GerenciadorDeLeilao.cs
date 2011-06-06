using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using L.PX.Core.Data;

namespace L.PX.Core
{
    public class GerenciadorDeLeilao
    {
        public static Leilao GetLeilao(Int32 id)
        {
            using (var dao = new LpxDao())
            {
                return dao.Leilao.SingleOrDefault(l => l.Id == id);
            }
        }
    }
}
