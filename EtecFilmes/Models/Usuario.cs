using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EtecFilmes.Models
{
    public class Usuario : IdentityUser
    {
        [StringLength(60)]
        public string Nome { get; set; }
        public int LimiteAlteracaoNomeUsuario { get; set; } = 10;

        public byte[] Avatar { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}
