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
        public void TestAdicaoUsuario()
        {
            var leilao = new Leilao();

            var user1 = new User() { Email = "cristianoaffa@hotmail.com" };

            leilao.AddContratante(user1);

            Assert.IsTrue(leilao.FindParticipante(user1).IsContratante  == true);

        }
    }
}
