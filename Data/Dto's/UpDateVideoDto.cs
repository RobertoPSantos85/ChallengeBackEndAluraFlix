using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeBackEndAluraFlix.Data.Dto_s
{
    public class UpDateVideoDto
    {
        [Required(ErrorMessage = "O título deve ser informado.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Digite uma descrição!")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Digite a url do video!")]
        public string Url { get; set; }
    }
}
