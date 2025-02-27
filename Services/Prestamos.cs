using Microsoft.EntityFrameworkCore;
using Registro_Tecnicos.DAL;
using Registro_Tecnicos.Models;
using System.Linq.Expressions;

namespace Registro_Tecnicos.Services
{
	public class PrestamosService(IDbContextFactory<Context> DbContextFactory)
	{

		private async Task<bool> Existe(int PrestamoId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Prestamos.AnyAsync(p => p.PrestamoId == PrestamoId);

		}

		private async Task<bool> Insertar(Prestamos Prestamos)
		{

			await using var context = await DbContextFactory.CreateDbContextAsync();
			context.Prestamos.Add(Prestamos);
			return await context.SaveChangesAsync() > 0;

		}


		public async Task<bool> Guardar(Prestamos Prestamos)
		{
			if (!await Existe(Prestamos.PrestamoId))
			{
				return await Insertar(Prestamos);
			}
			else
			{
				return await Modificar(Prestamos);
			}
		}

		private async Task<bool> Modificar(Prestamos Prestamos)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			context.Update(Prestamos);
			return await context.SaveChangesAsync() > 0;

		}

		public async Task<Prestamos?> Buscar(int PrestamoId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Prestamos
				.FirstOrDefaultAsync(p => p.PrestamoId == PrestamoId);
		}

		public async Task<bool> Eliminar(int PrestamoId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Prestamos.Where(p => p.PrestamoId == PrestamoId)
				.ExecuteDeleteAsync() > 0;
		}

		public async Task<List<Prestamos>> Listar(Expression<Func<Prestamos, bool>> criterio)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Prestamos.Where(criterio).ToListAsync();

		}


	}
}
