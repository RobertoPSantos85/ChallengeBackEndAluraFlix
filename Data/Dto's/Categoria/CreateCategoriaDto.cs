using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeBackEndAluraFlix.Data.Dto_s.Categoria
{
    public class CreateCategoriaDto
    {
        
        
        [Required(ErrorMessage = "O título deve ser informado.")]
        public string Titulo { get; set; }
        
        [Required(ErrorMessage = "O preenchimento do campo é obrigatório.")]
        [RegularExpression(@"^[0-9A-F]{6}$", ErrorMessage = "Insira um valor hexadecimal para o campo.")]
        public string Cor { get; set; }

        public int videoId { get; set; }
        
    }
}
