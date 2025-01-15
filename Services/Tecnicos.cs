using Registro_Tecnicos.DAL;
using Registro_Tecnicos.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Registro_Tecnicos.Services

{
	public class TecnicosService(IDbContextFactory<Context> DbContextFactory)
	{

		public async Task<bool> Guardar(Tecnicos tecnico)
		{
			if (!await Existe(tecnico.TecnicoId))
			{
				return await Insertar(tecnico);
			}
			else
			{
				return await Modificar(tecnico);
			}
		}

		private async Task<bool> Existe(int TecnicoId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Tecnicos.AnyAsync(t => t.TecnicoId == TecnicoId);

		}

		private async Task<bool> Insertar(Tecnicos tecnico)
		{

			await using var context = await DbContextFactory.CreateDbContextAsync();
			context.Tecnicos.Add(tecnico);
			return await context.SaveChangesAsync() > 0;

		}

		private async Task<bool> Modificar(Tecnicos tecnicos)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			context.Update(tecnicos);
			return await context.SaveChangesAsync() > 0;

		}

		public async Task<Tecnicos?> Buscar(int TecnicoId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Tecnicos.Include(t => t.TecnicoId)
				.FirstOrDefaultAsync(t => t.Id == TecnicoId);
		}

		public async Task<bool> Eliminar(int TecnicoId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Tecnicos.Where(t => t.TecnicoId == TecnicoId)
				.ExecuteDeleteAsync() > 0;
		}

		public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Tecnicos.Where(criterio).ToListAsync();

		}

	}
}
