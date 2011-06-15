using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace L.PX.Core
{
    public class Leilao
    {
        [Key]
        [Display(AutoGenerateField = false)]
        public Int32 Id { get; set; }
        private decimal valorInicial = 0;
        public virtual List<Participante> Participantes { get; set; }
        public virtual List<LanceProcessado> LancesProcessados { get; set; }
        public decimal ValorAtual { get; private set; }
        public Int32 NumeroDeLotes { get; set; }
        public decimal ValorInicial
        {
            get
            {
                return valorInicial;
            }
            set
            {
                valorInicial = value;
                ValorAtual = value;
            }
        }

        public Leilao()
        {
            Participantes = new List<Participante>();
            LancesProcessados = new List<LanceProcessado>();
        }

        public LanceProcessado RecebeLance(Lance lance)
        {
            Participante participante = FindParticipante(lance.User);


            if (participante == null)
                throw new InvalidOperationException("Usuário não participa do leilao");

            LanceProcessado lanceProcessado = new LanceProcessado() { Lance = lance, Leilao = this, NumeroLotesAtendidos = 0, Status = LanceStatus.NaoAtendido, Valor = (ValorAtual + lance.Incremento) };

            LancesProcessados.Add(lanceProcessado);
            OrdenarLances();
            var lanceP = LancesProcessados.Single(lp => lp.Lance == lance);

            ValorAtual = lanceP.Valor;
            return lanceP;
        }


        private void OrdenarLances()
        {
            LancesProcessados.ForEach(l => l.Status = LanceStatus.NaoAtendido);

            var query = from l in LancesProcessados orderby l.Valor descending group l by l.Lance.User into g select new { Usuario = g.Key, MaiorLance = g.First(l => l.Valor == g.Max(lp => lp.Valor)) };

            Int32 lotesToGo = NumeroDeLotes;

            foreach (var item in query)
            {
                if (lotesToGo > 0)
                {
                    if (item.MaiorLance.Lance.NumeroDeLotes <= lotesToGo)
                    {
                        item.MaiorLance.NumeroLotesAtendidos = item.MaiorLance.Lance.NumeroDeLotes;
                        item.MaiorLance.Status = LanceStatus.Atendido;
                        lotesToGo -= item.MaiorLance.NumeroLotesAtendidos;
                    }
                    else
                    {
                        item.MaiorLance.NumeroLotesAtendidos = lotesToGo;
                        item.MaiorLance.Status = LanceStatus.ParcialmenteAtendido;
                        lotesToGo = 0;
                    }
                }
                else
                {
                    item.MaiorLance.NumeroLotesAtendidos = 0;
                    item.MaiorLance.Status = LanceStatus.NaoAtendido;
                }

                if (NumeroDeLotes == 0)
                {
                    item.MaiorLance.NumeroLotesAtendidos = 0;
                }
            }
        }

        public void AddContratante(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            var contratante = Participante.Build(user);
            contratante.IsContratante = true;
            contratante.Leilao = this;
            Participantes.Add(contratante);
        }

        public void AddParticipante(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            var participante = Participante.Build(user);
            participante.IsContratante = false;
            participante.Leilao = this;
            Participantes.Add(participante);
        }

        public Participante FindParticipante(User user)
        {
            return Participantes.SingleOrDefault(p => p.Usuario == user);
        }

        public LanceProcessado FindLanceProcessado(Lance lance)
        {
            return LancesProcessados.SingleOrDefault(l => l.Lance == lance);
        }


        public ICollection<LanceProcessado> ListaLancesDosUsuarios()
        {
            return LancesProcessados;

        }

        public ICollection<Participante> ListaParticipantes()
        {
            return Participantes;
        
        
        }



    }
}
