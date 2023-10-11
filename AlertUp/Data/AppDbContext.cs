using Microsoft.EntityFrameworkCore;
using AlertUp.Model;

namespace AlertUp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tema>().ToTable("tb_temas");
            modelBuilder.Entity<Postagem>().ToTable("tb_postagens");
            modelBuilder.Entity<User>().ToTable("tb_usuarios");

                _ = modelBuilder.Entity<Postagem>()
                    .HasOne(_ => _.Tema)
                    .WithMany(t => t!.Postagem)
                    .HasForeignKey("TemaId")
                    .OnDelete(DeleteBehavior.Cascade);
                
                _ = modelBuilder.Entity<Postagem>()
                    .HasOne(_ => _.User)
                    .WithMany(t => t!.Postagem)
                    .HasForeignKey("UsuarioId")
                    .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Tema> Temas { get; set; } = null!;
        public DbSet<Postagem> Postagens { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var insertedEntries = this.ChangeTracker.Entries()
            .Where(x => x.State == EntityState.Added)
            .Select(x => x.Entity);

            foreach (var insertedEntry in insertedEntries)
            {

                if (insertedEntry is Auditable auditableEntity)
                {
                    auditableEntity.Data = new DateTimeOffset(DateTime.Now);
                }
            }

            var modifiedEntries = ChangeTracker.Entries()
            .Where(x => x.State == EntityState.Modified)
            .Select(x => x.Entity);

            foreach (var modifiedEntry in modifiedEntries)
            {

                if (modifiedEntry is Auditable auditableEntity)
                {
                    auditableEntity.Data = new DateTimeOffset(DateTime.Now);
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
