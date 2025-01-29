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

	}
}
