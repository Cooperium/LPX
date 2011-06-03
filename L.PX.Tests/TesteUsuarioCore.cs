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
        public void TestMethod1()
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
                NumeroDeLotes = 10
            };
            
            Lance lance1 = Lance.Build(10,5,usuario1);

            Lance lance2 = Lance.Build(20,5,usuario1);

            Lance lance3 = Lance.Build(50,5,usuario1);
            
                



            Lance lance2 = new Lance(){
                I


          
                
           



            


        

        
        }
    }
}
