using Registro_Tecnicos.DAL;
using Registro_Tecnicos.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Registro_Tecnicos.Services
{
	public class ClientesService(IDbContextFactory<Context> DbContextFactory)
	{

		private async Task<bool> Existe(int ClienteId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Clientes.AnyAsync(c => c.ClienteId == ClienteId);

		}

		private async Task<bool> Insertar(Clientes Clientes)
		{

			await using var context = await DbContextFactory.CreateDbContextAsync();
			context.Clientes.Add(Clientes);
			return await context.SaveChangesAsync() > 0;

		}


		public async Task<bool> Guardar(Clientes Clientes)
		{
			if (!await Existe(Clientes.ClienteId))
			{
				return await Insertar(Clientes);
			}
			else
			{
				return await Modificar(Clientes);
			}
		}



		private async Task<bool> Modificar(Clientes Clientes)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			context.Update(Clientes);
			return await context.SaveChangesAsync() > 0;

		}

		public async Task<Clientes?> Buscar(int ClienteId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Clientes
				.FirstOrDefaultAsync(c => c.ClienteId == ClienteId);
		}

		public async Task<bool> Eliminar(int ClienteId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Clientes.Where(c => c.ClienteId == ClienteId)
				.ExecuteDeleteAsync() > 0;
		}

		public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Clientes.Where(criterio).ToListAsync();

		}


		public async Task<Clientes?> BuscarNombres(string Nombres)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Clientes
				.FirstOrDefaultAsync(e => e.Nombres == Nombres);
		}

		public async Task<Clientes?> BuscarRNC(int RNC)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Clientes
				.FirstOrDefaultAsync(e => e.RNC == RNC);
		}
	}
}
