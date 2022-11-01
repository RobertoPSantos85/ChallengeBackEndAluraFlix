using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeBackEndAluraFlix.Models
{
    public class Video
    {
        [Key]
        [Required (ErrorMessage = "O número de identificação é obrigatório.")]
        public int Id { get; set; }
        [Required (ErrorMessage = "O título deve ser informado.")]
        public string Titulo { get; set; }
        [Required (ErrorMessage = "Digite uma descrição!")]
        public string Descricao { get; set; }
        [Required (ErrorMessage = "Digite a url do video!")]
        public string Url { get; set; }
    }
}
