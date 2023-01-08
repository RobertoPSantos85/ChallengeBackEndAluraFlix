using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChallengeBackEndAluraFlix.Models
{
    public class Categoria
    {
        [Key]
        [Required(ErrorMessage = "Informe o código da categoria.")]
        public int categoriaId { get; set; }
       
        [Required(ErrorMessage = "O preenchimento do campo é obrigatório!")]
        public string Titulo { get; set; }
        
        [Required(ErrorMessage = "O preenchimento do campo cor é obrigátorio.")]
        [RegularExpression(@"^[0-9A-F]{6}$", ErrorMessage = "Insira um valor hexadecimal para o campo.")]
        public string Cor { get; set; }

        public int videoId { get; set; }
        
        public virtual List<Video> videos{ get; set; }
        
    }
}
