using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using L.PX.Core;
using L.PX.Core.Data;
using System.Data.Entity;

namespace L.PX.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<LpxDao>
    {
        protected override void Seed(LpxDao context)
        {
            var users = new List<User>
            {
                new User {Email = "cooperium@cooperium.com", NomeCompleto = "Cooperium",  Empresa = "Cemig", Telefone = "34223242"},
                new User {Email = "matheus@cooperium.com", NomeCompleto = "Matheus",  Empresa = "Legal", Telefone = "34252626"},
                new User {Email = "carlitos@cooperium.com", NomeCompleto = "Matheus",  Empresa = "Legal", Telefone = "34252626"},

            };

            var leilao = new Leilao { Id = 1, NumeroDeLotes = 100, ValorInicial = 100 };
            leilao.AddContratante(users[0]);
            leilao.AddParticipante(users[1]);
            leilao.AddParticipante(users[2]);

            users.ForEach(u => context.Users.Add(u));
            context.Leiloes.Add(leilao);
        }
    }
}