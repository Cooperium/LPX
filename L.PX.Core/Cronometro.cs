using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace L.PX.Core
{
    public class Cronometro: IDisposable 
    {
        private Int32 tempoRestante = 0;
        private Timer timer;

        public Int32 TempoRestante { get { return tempoRestante; } }

        public event EventHandler FimDoTempo;
        public event EventHandler Tick;

        private Cronometro()
        {
            timer = new Timer(new TimerCallback(decrementa), null, Timeout.Infinite, 1000);
        }

        public static Cronometro Build(int tempo)
        {
            if (tempo < 0)
                throw new ArgumentOutOfRangeException();

            return new Cronometro() { tempoRestante = tempo };
        }

        private void decrementa(object state)
        {
            
            if (tempoRestante <= 0)
            {
                Stop();
                tempoRestante = 0;

                if (FimDoTempo != null)
                    FimDoTempo(this, new EventArgs());
            }
            else
            {
                if (Tick != null)
                    Tick(this, new EventArgs());

                tempoRestante -= 1;
            }
        }

        public void Start()
        {
            timer.Change(0, 1000);
        }

        public void Stop()
        {
            timer.Change(Timeout.Infinite, 1000);
        }

        public void Dispose()
        {
            timer.Dispose();
        }
    }
}
