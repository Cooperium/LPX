using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using L.PX.Core;

namespace L.PX.Tests
{
    [TestClass]
    public class TesteUsuarioCore
    {
        [TestMethod]
        public void TestaLances()
        {

            User usuario1 = new User(){
                Email = "cristianoaffa@hotmail.com",
                NomeCompleto = "Cristiano Affá Ferreira" 
            };

            User usuario2 = new User(){
                Email = "josesilva@hotmail.com",
                NomeCompleto = "José da Silva"
            };


            Leilao leilao = new Leilao(){
                ValorInicial = 100,
                NumeroDeLotes = 50
            };
            
            //lances do usuario1:
            Lance lance1 = Lance.Build(10,15,usuario1);
            Lance lance2 = Lance.Build(20,25,usuario1);
            Lance lance3 = Lance.Build(50,35,usuario1);

            //lances do usuario2:
            Lance lance4 = Lance.Build(60,45,usuario2);
            Lance lance5 = Lance.Build(25,5,usuario2);
            Lance lance6= Lance.Build(70,10,usuario2);
            
            //adicionando usuarios no leilao:
            leilao.AddParticipante(usuario1);
            leilao.AddParticipante(usuario2);

            //processando o primeiro lance:            
            LanceProcessado lp1 = leilao.RecebeLance(lance1);
            
            //o lance é atendido!
            Assert.IsTrue(lp1.Status == LanceStatus.Atendido);

            //processando o segundo lance:
            LanceProcessado lp2 = leilao.RecebeLance(lance2);
            Assert.IsTrue(lp2.Status == LanceStatus.Atendido);
            Assert.IsTrue(lp1.Status == LanceStatus.NaoAtendido);
        
            //processando o terceiro lance:
            LanceProcessado lp3 = leilao.RecebeLance(lance3);
            Assert.IsTrue(lp3.Status == LanceStatus.Atendido);
            Assert.IsTrue(lp2.Status == LanceStatus.NaoAtendido);
            Assert.IsTrue(lp1.Status == LanceStatus.NaoAtendido);

            /*
            //processando o quarto lance:
            LanceProcessado lp4 = leilao.RecebeLance(lance4);
            Assert.IsTrue(lp4.Status == LanceStatus.Atendido);
            Assert.IsTrue(lp3.Status == LanceStatus.ParcialmenteAtendido);
            Assert.IsTrue(lp2.Status == LanceStatus.NaoAtendido);
            Assert.IsTrue(lp1.Status == LanceStatus.NaoAtendido);
            */
        }
    }
}
