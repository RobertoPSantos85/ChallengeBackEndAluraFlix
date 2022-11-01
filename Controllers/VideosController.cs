using AutoMapper;
using ChallengeBackEndAluraFlix.Data;
using ChallengeBackEndAluraFlix.Data.Dto_s;
using ChallengeBackEndAluraFlix.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeBackEndAluraFlix.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideosController:ControllerBase
    {
        private VideoContext contexto;
        private IMapper mapa;

        public VideosController(VideoContext context, IMapper mapper)
        {
            contexto = context;
            mapa = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaVideo([FromBody] CreateVideoDto videoDto)
        {
            Video video = mapa.Map<Video>(videoDto);
            contexto.Videos.Add(video);
            contexto.SaveChanges();
            return CreatedAtAction(nameof(RecuperaVideoPorId), new { Id = video.Id }, video);

        }

        [HttpGet]
        public IEnumerable<Video> RecuperaVideos()
        {
            return contexto.Videos;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaVideoPorId(int id)
        {
            Video video = contexto.Videos.FirstOrDefault(videos => videos.Id == id);
            if(video != null)
            {
                ReadVideoDto videoDto = mapa.Map<ReadVideoDto>(video);             

                return Ok(video);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaVideo(int id, [FromBody] UpDateVideoDto novovideoDto)
        {
            Video video = contexto.Videos.FirstOrDefault(videos => videos.Id == id);
            if (video == null)
            {
                return NotFound();
            }
            mapa.Map(novovideoDto, video);
            contexto.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaVideo(int id)
        {
            Video video = contexto.Videos.FirstOrDefault(videos => videos.Id == id);
            if (video == null)
            {
                return NotFound();
            }
            contexto.Remove(video);
            contexto.SaveChanges();
            return NoContent();
        }
    }
}
