using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using L.PX.Core;
using L.PX.Core.Data;

namespace L.PX.Tests
{
    [TestClass]
    public class UserPersistence
    {


        [TestMethod]
        public void PersistUser()
        {
            var user = new User();
            user.Email = "pablo@lpx.com.br";
            user.Empresa = "Cemig";
            user.NomeCompleto = "Pablo Corrêa Fonseca";
            user.Telefone = "91023792";

            LpxDao dao = new LpxDao();
            dao.Users.Add(user);
            dao.SaveChanges();
            dao.Dispose();


            LpxDao dao2 = new LpxDao();
            var retrieved = dao2.Users.Single(u => u.Email == "pablo@lpx.com.br");

            Assert.AreEqual(user.NomeCompleto , retrieved.NomeCompleto);
            Assert.AreEqual(user.Email, retrieved.Email);

            dao2.Users.Remove(retrieved);
            dao2.SaveChanges();


        }
    }
}
