//using System;
//using System.Text;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using L.PX.Core;
//using System.Threading;
//using System.Diagnostics;

//namespace L.PX.Tests
//{
//    [TestClass]
//    public class CronometroTests
//    {
//       // private Cronometro cronometro = null;
//        private static int tempo = 5;
//        private static int tickCount = 0;
//        public bool exit = false;


//        [TestInitialize]
//        public void SetUp()
//        {

//            cronometro = Cronometro.Build(tempo);
//            cronometro.Tick += new EventHandler(cronometro_Tick);
//            cronometro.FimDoTempo += new EventHandler(cronometro_FimDoTempo);
//        }

//        void cronometro_FimDoTempo(object sender, EventArgs e)
//        {
//            exit = true;
//        }

//        private void cronometro_Tick(object sender, EventArgs e)
//        {
//            Debug.WriteLine(String.Format("tempo do cronometro: {0}, tick Count: {1}", cronometro.TempoRestante.ToString(), tickCount.ToString()));

//            tickCount += 1;
//        }

//        [TestMethod]
//        public void TestCronometro()
//        {
//            cronometro.Start();

//            while (true)
//            {
//                if (exit)
//                    break;
//            }

//            Assert.AreEqual(tempo, tickCount);
//        }
//    }
//}
