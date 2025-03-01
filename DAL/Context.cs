using Registro_Tecnicos.Models;
using Microsoft.EntityFrameworkCore;

namespace Registro_Tecnicos.DAL
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options) : base(options) { }

		public DbSet<Tecnicos> Tecnicos { get; set; }

		public DbSet<Clientes> Clientes { get; set; }

		public DbSet<Tickets> Tickets { get; set; }

		public DbSet<Sistemas> Sistemas { get; set; }

		public DbSet<Prestamos> Prestamos { get; set; }

		public DbSet<PrestamosDetalle> PrestamosDetalle { get; set; }



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<PrestamosDetalle>().HasData(new List<PrestamosDetalle>());
			{
				new PrestamosDetalle { DetalleId = 1, PrestamoId = 1, CuotaNo = 1, Fecha = DateTime.Now, Valor = 100, Balance = 100 };
				new PrestamosDetalle { DetalleId = 2, PrestamoId = 1, CuotaNo = 2, Fecha = DateTime.Now, Valor = 100, Balance = 100 };
				new PrestamosDetalle { DetalleId = 3, PrestamoId = 1, CuotaNo = 3, Fecha = DateTime.Now, Valor = 100, Balance = 100 };
				new PrestamosDetalle { DetalleId = 4, PrestamoId = 1, CuotaNo = 4, Fecha = DateTime.Now, Valor = 100, Balance = 100 };
			}
		}

	}
}
