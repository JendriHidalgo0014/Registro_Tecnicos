using Registro_Tecnicos.DAL;
using Registro_Tecnicos.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Registro_Tecnicos.Services
{
	public class TicketsService(IDbContextFactory<Context> DbContextFactory)
	{

		private async Task<bool> Existe(int TicketId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Tickets.AnyAsync(t => t.TicketId == TicketId);

		}

		private async Task<bool> Insertar(Tickets Tickets)
		{

			await using var context = await DbContextFactory.CreateDbContextAsync();
			context.Tickets.Add(Tickets);
			return await context.SaveChangesAsync() > 0;

		}


		public async Task<bool> Guardar(Tickets Tickets)
		{
			if (!await Existe(Tickets.TicketId))
			{
				return await Insertar(Tickets);
			}
			else
			{
				return await Modificar(Tickets);
			}
		}



		private async Task<bool> Modificar(Tickets Tickets)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			context.Update(Tickets);
			return await context.SaveChangesAsync() > 0;

		}

		public async Task<Tickets?> Buscar(int TicketId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Tickets
				.FirstOrDefaultAsync(t => t.TicketId == TicketId);
		}

		public async Task<bool> Eliminar(int TicketId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Tickets.Where(t => t.TicketId == TicketId)
				.ExecuteDeleteAsync() > 0;
		}

		public async Task<List<Tickets>> Listar(Expression<Func<Tickets, bool>> criterio)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Tickets.Where(criterio).ToListAsync();

		}


	}

}
