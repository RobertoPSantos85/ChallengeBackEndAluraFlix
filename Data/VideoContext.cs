using ChallengeBackEndAluraFlix.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeBackEndAluraFlix.Data
{
    public class VideoContext : DbContext
    {
        private DbContext vd;

        public VideoContext(DbContextOptions<VideoContext> vd) : base(vd)
        {
            this.Database.EnsureCreated();
        }

        public VideoContext()
        {
            DbContext _vd = vd;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
             builder.Entity<Video>()
                    .HasOne(video => video.categoria)
                    .WithMany(categoria => categoria.videos)
                    .HasForeignKey(video => video.categoriaId);
        }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
