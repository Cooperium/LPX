using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace L.PX.Core
{
    public class User
    {
        [Key]
        public String Email { get; set; }
        public String NomeCompleto { get; set; }
        public String Empresa { get; set; }
        public String Telefone { get; set; }
    }
}
