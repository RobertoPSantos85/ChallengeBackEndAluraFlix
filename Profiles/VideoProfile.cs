using AutoMapper;
using ChallengeBackEndAluraFlix.Data.Dto_s.Video;
using ChallengeBackEndAluraFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeBackEndAluraFlix.Profiles
{
    public class VideoProfile:Profile
    {
        public VideoProfile()
        {
            CreateMap<CreateVideoDto, Video>();
            CreateMap<Video, ReadVideoDto>();
            CreateMap<UpDateVideoDto, Video>();
        }
    }
}
