// <auto-generated />
using ChallengeBackEndAluraFlix.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChallengeBackEndAluraFlix.Migrations
{
    [DbContext(typeof(VideoContext))]
    partial class VideoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChallengeBackEndAluraFlix.Models.Categoria", b =>
                {
                    b.Property<int>("categoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("videoId")
                        .HasColumnType("int");

                    b.HasKey("categoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("ChallengeBackEndAluraFlix.Models.Video", b =>
                {
                    b.Property<int>("videoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("categoriaId")
                        .HasColumnType("int");

                    b.HasKey("videoId");

                    b.HasIndex("categoriaId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("ChallengeBackEndAluraFlix.Models.Video", b =>
                {
                    b.HasOne("ChallengeBackEndAluraFlix.Models.Categoria", "categoria")
                        .WithMany("videos")
                        .HasForeignKey("categoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categoria");
                });

            modelBuilder.Entity("ChallengeBackEndAluraFlix.Models.Categoria", b =>
                {
                    b.Navigation("videos");
                });
#pragma warning restore 612, 618
        }
    }
}
