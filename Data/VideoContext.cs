using ChallengeBackEndAluraFlix.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeBackEndAluraFlix.Data
{
    public class VideoContext:DbContext
    {
        public VideoContext(DbContextOptions<VideoContext> vd) : base(vd)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Video> Videos { get; set; }
    }
}
