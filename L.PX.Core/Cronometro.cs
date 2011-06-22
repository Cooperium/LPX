//using System;
//using System.DateTime;

//private class DateTime()
//{
//   private DateTime GetStartTime()
//{
//    return DateTime.now;
//}

//private DateTime GetEndTime()
//{
//    return new DateTime();    
//}

//}


//public double seconds;
//protected void Page_Load(object sender, EventArgs e)
//{
//    seconds =((GetEndTime() - GetStarTime().TotalSeconds;
//}
//private DateTime GetStartTime()
//{
//    return DateTime.now;
//}

//private DateTime GetEndTime()
//{
//    return new DateTime();    
//}


////namespace L.PX.Core
////{
////    public class Cronometro: IDisposable 
////    {
////        private Int32 tempoRestante = 0;
////        private Timer timer;

////        public Int32 TempoRestante { get { return tempoRestante; } }

////        public event EventHandler FimDoTempo;
////        public event EventHandler Tick;

////        private Cronometro()
////        {
////            timer = new Timer(new TimerCallback(decrementa), null, Timeout.Infinite, 1000);
////        }

////        public static Cronometro Build(int tempo)
////        {
////            if (tempo < 0)
////                throw new ArgumentOutOfRangeException();

////            return new Cronometro() { tempoRestante = tempo };
////        }

////        private void decrementa(object state)
////        {
            
////            if (tempoRestante <= 0)
////            {
////                Stop();
////                tempoRestante = 0;

////                if (FimDoTempo != null)
////                    FimDoTempo(this, new EventArgs());
////            }
////            else
////            {
////                if (Tick != null)
////                    Tick(this, new EventArgs());

////                tempoRestante -= 1;
////            }
////        }

////        public void Start()
////        {
////            timer.Change(0, 1000);
////        }

////        public void Stop()
////        {
////            timer.Change(Timeout.Infinite, 1000);
////        }

////        public void Dispose()
////        {
////            timer.Dispose();
////        }
////    }
////}
