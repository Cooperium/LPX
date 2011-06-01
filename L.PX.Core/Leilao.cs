using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L.PX.Core
{
    public class Leilao
    {
        private List<Participante> participantes = new List<Participante>();
        private List<LanceProcessado> lancesProcessados = new List<LanceProcessado>();

        public decimal ValorInicial { get; private set; }
        public Int32 NumeroDeLotes { get; private set; }

        public void AddContratante(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            var contratante = Participante.Build(user, Papel.Contratante);
            participantes.Add(contratante);
        }

        public Participante FindParticipante(User user)
        {
            return participantes.SingleOrDefault(p => p.user == user);
        }

        public void AddParticipante(User user)
        { }

        public LanceProcessado ProcessarLance(Lance lance)
        {
            throw new NotImplementedException();
            OrdenarLances();
        }

        /// <summary>
        /// Reclassifica todos os lances quanto ao status (Atendido, Parcialmente Atendido, Não Atendido) e atualiza o numero de lotes atendidos.
        /// </summary>
        private void OrdenarLances()
        {
            throw new NotImplementedException();
        }

        public ICollection<LanceProcessado> ListLancesByUsers()
        {
            throw new NotImplementedException();
        }

        public class Participante
        {
            public User user { get; private set; }
            public Papel papel { get; private set; }

            private Participante() { }

            public static Participante Build(User user, Papel papel)
            {
                return new Participante() { papel = papel, user = user };
            }
        }

        public class Lance
        {
            public decimal Incremento { get; private set; }
            public Int32 NumeroDeLotes { get; private set; }
            public User Usuario { get; private set; }

            private Lance() { }

            public static Lance Build(Decimal incremento, int numeroDeLotes, User usuario)
            {
                return new Lance() { Incremento = incremento, NumeroDeLotes = numeroDeLotes, Usuario = usuario };
            }
        }


        public class LanceProcessado
        {
            public Lance Lance { get; private set; }
            public LanceStatus Status { get; set; }
            public Int32 NumeroDeLotesAtendidos { get; set; }
        }

        public enum LanceStatus
        {
            Rejeitado,
            Atendido
        }

        public enum Papel
        {
            Contratante,
            Participante,
        }

    }
}
