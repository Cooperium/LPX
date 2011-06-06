using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L.PX.Core
{
    public class LanceProcessado
    {
        public Int32 Id { get; set; }
        public LanceStatus Status { get; set; }
        public Int32 NumeroLotesAtendidos { get; set; }
        public Leilao Leilao { get; set; }
        public Lance Lance { get; set; }
        public Decimal Valor { get; set; }
    }

    public enum LanceStatus
    {
        Atendido,
        ParcialmenteAtendido,
        NaoAtendido,
        Rejeitado
    }
}
