using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DietForYou.Models
{
    public class HistoricoUsersDados
    {
        [Key]
        [Required]
        public int IdHistoricoUsersDados { get; set; }

        [Required(ErrorMessage = "O campo IdUsuario é obrigatório")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O campo sexo é obrigatório")]
        public int IdSexo { get; set; }

        [Required(ErrorMessage = "O campo Atividade fisica é obrigatório")]
        public int IdDescricaoAtividadeFisica { get; set; }

        [Required(ErrorMessage = "O campo Peso  é obrigatório")]
        public double Peso { get; set; }

        [Required(ErrorMessage = "O campo Altura  é obrigatório")]
        public int Altura { get; set; }

        [Required(ErrorMessage = "O campo Idade  é obrigatório")]
        public int Idade { get; set; }

        public double Tmb { get; set; }
    }
}
