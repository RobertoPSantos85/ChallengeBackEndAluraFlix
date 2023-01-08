using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeBackEndAluraFlix.Data.Dto_s.Video
{
    public class CreateVideoDto
    {
        [Required(ErrorMessage = "O título deve ser informado.")]
        public string Titulo { get; set; }
        
        [Required(ErrorMessage = "Digite uma descrição!")]
        public string Descricao { get; set; }
       
        [Required(ErrorMessage = "Digite a url do video!")]
        public string Url { get; set; }
        [Required(ErrorMessage = "Informe o código da categoria.")]
        public int CategoriaId { get; set; }
    }
}
