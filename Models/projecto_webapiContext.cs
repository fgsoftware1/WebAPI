#nullable disable

namespace WebAPI_prog3.Models
{
    public partial class projecto_webapiContext : DbContext
    {
        public projecto_webapiContext()
        {
        }

        public projecto_webapiContext(DbContextOptions<projecto_webapiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Editora> Editoras { get; set; }
        public virtual DbSet<Livro> Livros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=projecto_webapi", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.22-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<Editora>(entity =>
            {
                entity.HasKey(e => e.IdEditora)
                    .HasName("PRIMARY");

                entity.ToTable("editora");

                entity.Property(e => e.IdEditora)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Editora");

                entity.Property(e => e.Ativo).HasColumnType("int(1)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(75);
            });

            modelBuilder.Entity<Livro>(entity =>
            {
                entity.HasKey(e => e.IdLivro)
                    .HasName("PRIMARY");

                entity.ToTable("livro");

                entity.HasIndex(e => e.IdEditora, "FK_Editora");

                entity.Property(e => e.IdLivro)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Livro");

                entity.Property(e => e.IdEditora)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Editora");

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.NumeroPaginas)
                    .HasColumnType("int(5)")
                    .HasColumnName("Numero_Paginas");

                entity.HasOne(d => d.IdEditoraNavigation)
                    .WithMany(p => p.Livros)
                    .HasForeignKey(d => d.IdEditora)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Editora");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
