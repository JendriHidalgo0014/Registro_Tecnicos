using Microsoft.EntityFrameworkCore;
using Registro_Tecnicos.DAL;
using Registro_Tecnicos.Models;
using System.Linq.Expressions;

namespace Registro_Tecnicos.Services
{
	public class SistemasServices(IDbContextFactory<Context> DbContextFactory)
	{

		private async Task<bool> Existe(int SistemaId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Sistemas.AnyAsync(s => s.SistemaId == SistemaId);

		}

		private async Task<bool> Insertar(Sistemas Sistemas)
		{

			await using var context = await DbContextFactory.CreateDbContextAsync();
			context.Sistemas.Add(Sistemas);
			return await context.SaveChangesAsync() > 0;

		}


		public async Task<bool> Guardar(Sistemas Sistemas)
		{
			if (!await Existe(Sistemas.SistemaId))
			{
				return await Insertar(Sistemas);
			}
			else
			{
				return await Modificar(Sistemas);
			}
		}



		private async Task<bool> Modificar(Sistemas Sistemas)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			context.Update(Sistemas);
			return await context.SaveChangesAsync() > 0;

		}

		public async Task<Sistemas?> Buscar(int SistemaId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Sistemas
				.FirstOrDefaultAsync(s => s.SistemaId == SistemaId);
		}

		public async Task<bool> Eliminar(int SistemaId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Sistemas.Where(s => s.SistemaId == SistemaId)
				.ExecuteDeleteAsync() > 0;
		}

		public async Task<Sistemas?> BuscarDescripcion(string Descripcion)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Sistemas
				.FirstOrDefaultAsync(e => e.Descripcion == Descripcion);
		}
		public async Task<List<Sistemas>> Listar(Expression<Func<Sistemas, bool>> criterio)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Sistemas.Where(criterio).ToListAsync();

		}


	}
}
