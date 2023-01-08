using AutoMapper;
using ChallengeBackEndAluraFlix.Data;
using ChallengeBackEndAluraFlix.Data.Dto_s.Categoria;
using ChallengeBackEndAluraFlix.Data.Dto_s.Video;
using ChallengeBackEndAluraFlix.Models;
using ChallengeBackEndAluraFlix.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeBackEndAluraFlix.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController:ControllerBase
    {
         private CategoriasService _serviceCategoria;
        
        public CategoriasController(CategoriasService categoriasService)
         {
            _serviceCategoria = categoriasService;
         }

       
        [HttpPost]
        public IActionResult AdicionaCategoria([FromBody] CreateCategoriaDto categoriaDto)
        {
            ReadCategoriaDto readDto = _serviceCategoria.AdicionaCategoria(categoriaDto);
            
            return CreatedAtAction(nameof(RecuperaCategoriaPorId), new { Id = readDto.categoriaId }, readDto);

        }

        [HttpGet]
        public IActionResult RecuperaCategoria()
        {
            List<ReadCategoriaDto> readDto = _serviceCategoria.RecuperaCategoria();
            if(readDto != null)
            {
                return Ok(readDto);
            }
            return NotFound();
            
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCategoriaPorId(int id)
        {
            ReadCategoriaDto readDto = _serviceCategoria.RecuperaCategoriaPorId(id);
            if(readDto != null)
            {
                return Ok(readDto);
            }
            
            return NotFound();
           
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCategoria(int id, [FromBody] UpDateCategoriaDto novacategoriaDto)
        {
            ReadCategoriaDto readDto = _serviceCategoria.AtualizaCategoria(id, novacategoriaDto);
            if(readDto != null)
            {
                return Ok("Categoria atualizada com sucesso.");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCategoria(int id)
        {
            ReadCategoriaDto readDto = _serviceCategoria.DeletaCategoria(id);
            if(readDto != null)
            {
                return Ok("Categoria excluída com sucesso.");
            }
            return NoContent();
        }
    }
}
