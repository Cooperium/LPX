using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using L.PX.Core;

namespace L.PX.Tests
{
    [TestClass]
    public class TestLeilaoCore
    {
        private Leilao leilao = null;
        
        [TestInitialize]
        public void SetupTest1()
        {
  
        
        }

        [TestMethod]
        public void TestMethod1()
        {
            var leilao = new Leilao();

            var user1 = new User() { Email = "asd@12312.123123"};

            leilao.AddContratante(user1);

            Assert.IsTrue(leilao.FindParticipante(user1).papel == Leilao.Papel.Contratante);

        }

               [TestCleanup]
        public void SetupTest1()
        {

        
    }
}
