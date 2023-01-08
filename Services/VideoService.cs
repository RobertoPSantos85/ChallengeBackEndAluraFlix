using AutoMapper;
using ChallengeBackEndAluraFlix.Data;
using ChallengeBackEndAluraFlix.Data.Dto_s.Video;
using ChallengeBackEndAluraFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeBackEndAluraFlix.Services
{
    public class VideoService
    {
        private VideoContext contexto;
        private IMapper mapa;

        public VideoService(VideoContext context, IMapper mapper)
        {
            contexto = context;
            mapa = mapper;
        }

        public ReadVideoDto AdicionaVideo(CreateVideoDto videoDto)
        {
            Video video = mapa.Map<Video>(videoDto);
            contexto.Videos.Add(video);
            contexto.SaveChanges();
            return mapa.Map<ReadVideoDto>(video);
        }

        public List<ReadVideoDto> RecuperaVideos(string titulo)
        {
            List<Video> videos;
            if (titulo == null)
            {
                videos = contexto.Videos.ToList();
            }
            else
            {
                videos = contexto.Videos.Where(video => video.Titulo == titulo).ToList();
            }
            if (videos != null)
            {
                List<ReadVideoDto> readDto = mapa.Map<List<ReadVideoDto>>(videos);
                return readDto;
            }
            return null;
        }

        public ReadVideoDto RecuperaVideoPorId(int id)
        {
            Video video = contexto.Videos.FirstOrDefault(videos => videos.videoId == id);
            if (video != null)
            {
                ReadVideoDto videoDto = mapa.Map<ReadVideoDto>(video);

                return videoDto;
            }
            return null;
        }

        public ReadVideoDto AtualizaVideo(int id, UpDateVideoDto novovideoDto)
        {
            Video video = contexto.Videos.FirstOrDefault(videos => videos.videoId == id);
            if (video != null)
            {
                mapa.Map(novovideoDto, video);
                contexto.SaveChanges();
                ReadVideoDto readDto = mapa.Map<ReadVideoDto>(video);
                return readDto;
            }
            return null;
            
        }

        public ReadVideoDto DeletaVideo(int id)
        {
            Video video = contexto.Videos.FirstOrDefault(video => video.videoId == id);
            if (video != null)
            {
                contexto.Remove(video);
                contexto.SaveChanges();
            }
            return null;
        }
    }
}
