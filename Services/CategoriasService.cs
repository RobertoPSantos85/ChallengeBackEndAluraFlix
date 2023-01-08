using AutoMapper;
using ChallengeBackEndAluraFlix.Data;
using ChallengeBackEndAluraFlix.Data.Dto_s.Categoria;
using ChallengeBackEndAluraFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeBackEndAluraFlix.Services
{
    public class CategoriasService
    {
        private VideoContext contexto;
        private IMapper mapa;

        public CategoriasService(VideoContext context, IMapper mapper)
        {
            contexto = context;
            mapa = mapper;
        }

        public ReadCategoriaDto AdicionaCategoria(CreateCategoriaDto categoriaDto)
        {
            Categoria categoria = mapa.Map<Categoria>(categoriaDto);
            contexto.Categorias.Add(categoria);
            contexto.SaveChanges();
            return mapa.Map<ReadCategoriaDto>(categoria);
        }

        public List<ReadCategoriaDto>RecuperaCategoria()
        {
            List<Categoria> categorias = contexto.Categorias.ToList();
            List<ReadCategoriaDto> readDto = mapa.Map<List<ReadCategoriaDto>>(categorias);
            return readDto;
        }

        public ReadCategoriaDto RecuperaCategoriaPorId(int id)
        {
            Categoria categoria = contexto.Categorias.FirstOrDefault(categoria => categoria.categoriaId == id);

            if (categoria != null)
            {
                ReadCategoriaDto categoriaDto = mapa.Map<ReadCategoriaDto>(categoria);

                return categoriaDto;
            }
            return null;
        }

        public ReadCategoriaDto AtualizaCategoria(int id, UpDateCategoriaDto novacategoriaDto)
        {
            Categoria categoria = contexto.Categorias.FirstOrDefault(categorias => categorias.categoriaId == id);
            if (categoria != null)
            {
                mapa.Map(novacategoriaDto, categoria);
                contexto.SaveChanges();
                ReadCategoriaDto readDto = mapa.Map<ReadCategoriaDto>(categoria);
                return readDto;
                
            }
            
            return null;

        }

        public ReadCategoriaDto DeletaCategoria(int id)
        {
            Categoria categoria = contexto.Categorias.FirstOrDefault(categorias => categorias.categoriaId == id);
            if (categoria != null)
            {
                contexto.Remove(categoria);
                contexto.SaveChanges();
            }
            return null;

        }
    }
}
