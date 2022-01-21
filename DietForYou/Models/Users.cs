using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DietForYou.Models
{
    public class Users
    {
        [Key]
        [Required]
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "O campo Marca é obrigatório")]
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O campo Marca é obrigatório")]
        public string Email { get; set; }
    }
}
