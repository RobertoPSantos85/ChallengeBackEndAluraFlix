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
    public class VideosController : ControllerBase
    {
        private VideoService serviceVideo;

        public VideosController(VideoService _videoService)
        {
            serviceVideo = _videoService;
        }

        [HttpPost]
        public IActionResult AdicionaVideo([FromBody] CreateVideoDto videoDto)
        {
            ReadVideoDto readDto = serviceVideo.AdicionaVideo(videoDto);
            
            return CreatedAtAction(nameof(RecuperaVideoPorId), new { Id = readDto.videoId }, readDto);

        }

        [HttpGet]
        public IActionResult RecuperaVideos([FromQuery] string titulo = null)
        {
            List<ReadVideoDto> readDto = serviceVideo.RecuperaVideos(titulo);
            if(readDto != null)
            {
                return Ok(readDto);
            }
            
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaVideoPorId(int id)
        {
            ReadVideoDto readDto = serviceVideo.RecuperaVideoPorId(id);
            if(readDto != null)
            {
                return Ok(readDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaVideo(int id, [FromBody] UpDateVideoDto novovideoDto)
        {
            ReadVideoDto readDto = serviceVideo.AtualizaVideo(id, novovideoDto);
            if(readDto != null)
            {
                return Ok("O video foi atualizado com sucesso.");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaVideo(int id)
        {
            ReadVideoDto readDto = serviceVideo.DeletaVideo(id);
            if(readDto != null)
            {
                return Ok("O video foi deletado com sucesso.");
            }
            return NoContent();
        }

    }
}
