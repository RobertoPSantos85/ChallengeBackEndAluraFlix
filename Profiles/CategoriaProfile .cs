using AutoMapper;
using ChallengeBackEndAluraFlix.Data.Dto_s.Categoria;
using ChallengeBackEndAluraFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeBackEndAluraFlix.Profiles
{
    public class CategoriaProfile:Profile
    {
        public CategoriaProfile()
        {
            CreateMap<CreateCategoriaDto, Categoria>();
            CreateMap<UpDateCategoriaDto, Categoria>();
            CreateMap<Categoria, ReadCategoriaDto>()
                .ForMember(Categoria => Categoria.videos, opts => opts
                .MapFrom(categoria => categoria.videos.Select
                (v => new { v.categoriaId, v.videoId, v.Titulo, v.Descricao, v.Url })));
            

        }
    }
}
