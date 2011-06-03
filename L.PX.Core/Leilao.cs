using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L.PX.Core
{
    public class Leilao
    {

        private decimal valorInicial = 0;
        
        public decimal ValorInicial { 
            get { 
                return valorInicial; 
            } 
            set { 
                valorInicial = value;
                ValorAtual = value; 
            } 
        }
        public decimal ValorAtual { get; private set; }
        public Int32 NumeroDeLotes { get;  set; }


        private List<Participante> participantes = new List<Participante>();
        private List<LanceProcessado> lancesProcessados = new List<LanceProcessado>();


        public LanceProcessado RecebeLance(Lance lance)
        {
            Participante participante = FindParticipante(lance.User);


            if (participante == null)
                throw new InvalidOperationException("Usuário não participa do leilao");

            LanceProcessado lanceProcessado = new LanceProcessado() { Lance = lance, Leilao = this, NumeroLotesAtendidos = 0, Status = LanceStatus.NaoAtendido, Valor = (ValorAtual + lance.Incremento) };

            lancesProcessados.Add(lanceProcessado);
            OrdenarLances();
            return FindLance(lance);
        }

        public LanceProcessado FindLance(Lance lance)
        {
            return lancesProcessados.Single(lp => lp.Lance == lance);
        }


        private void OrdenarLances()
        {
            lancesProcessados.ForEach(l => l.Status = LanceStatus.NaoAtendido);
            
            var query = from l in lancesProcessados group l by l.Lance.User into g select new { Usuario = g.Key, MaiorLance = g.Single(l => l.Valor == g.Max(lp => lp.Valor)) };
            Int32 lotesDisponiveis = NumeroDeLotes;

            foreach (var item in query)
            {
                if (lotesDisponiveis > 0)
                {
                    if (item.MaiorLance.Lance.NumeroDeLotes <= lotesDisponiveis)
                    {
                        item.MaiorLance.NumeroLotesAtendidos = item.MaiorLance.Lance.NumeroDeLotes;
                        item.MaiorLance.Status = LanceStatus.Atendido;
                        lotesDisponiveis -= item.MaiorLance.NumeroLotesAtendidos;
                    }
                    else
                    {
                        item.MaiorLance.NumeroLotesAtendidos = lotesDisponiveis;
                        item.MaiorLance.Status = LanceStatus.ParcialmenteAtendido;
                        lotesDisponiveis = 0;
                    }
                }
                else
                {
                    item.MaiorLance.NumeroLotesAtendidos = 0;
                    item.MaiorLance.Status = LanceStatus.NaoAtendido;
                }

            }
        }

        public void AddContratante(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            var contratante = Participante.Build(user, Papel.Contratante);
            participantes.Add(contratante);
        }

        public void AddParticipante(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            var participante = Participante.Build(user, Papel.Participante);
            participantes.Add(participante);
        }

        public Participante FindParticipante(User user)
        {
            return participantes.SingleOrDefault(p => p.Usuario == user); 
        }

        public LanceProcessado FindLanceProcessado(Lance lance)
        {
            return lancesProcessados.SingleOrDefault(l => l.Lance == lance);
        }

       
        public ICollection<LanceProcessado> ListaLancesDosUsuarios()
        {
                   return lancesProcessados; 

        }
        




    }
}
