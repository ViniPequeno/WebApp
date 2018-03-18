using Microsoft.EntityFrameworkCore;

namespace DIego.Models
{
    public class Context : DbContext
	{

		public DbSet<Produto> Produtos { get; set; }
		public DbSet<Etiqueta> Etiquetas { get; set; }

		public Context(DbContextOptions<Context> options):base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Etiqueta>().HasKey(e=>e.Codigo);
			modelBuilder.Entity<Produto>().HasKey(p=>p.Codigo);
			//Mapeamento um-para-muitos
			modelBuilder.Entity<Etiqueta>()
			.HasOne(e => e.Produto)
			.WithMany(p => p.Etiquetas)
			.HasForeignKey(e => e.ProdutoId);
		}
		
	}

}
