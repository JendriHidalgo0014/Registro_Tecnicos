using Registro_Tecnicos.DAL;
using Registro_Tecnicos.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Registro_Tecnicos.Services
{
	
		public class CiudadesService(IDbContextFactory<Context> DbContextFactory)
		{

			private async Task<bool> Existe(int CiudadId)
			{
				await using var context = await DbContextFactory.CreateDbContextAsync();
				return await context.Ciudades.AnyAsync(c => c.CiudadId == CiudadId);

			}

			private async Task<bool> Insertar(Ciudades Ciudades)
			{

				await using var context = await DbContextFactory.CreateDbContextAsync();
				context.Ciudades.Add(Ciudades);
				return await context.SaveChangesAsync() > 0;

			}


			public async Task<bool> Guardar(Ciudades Ciudades)
			{
				if (!await Existe(Ciudades.CiudadId))
				{
					return await Insertar(Ciudades);
				}
				else
				{
					return await Modificar(Ciudades);
				}
			}



			private async Task<bool> Modificar(Ciudades Ciudades)
			{
				await using var context = await DbContextFactory.CreateDbContextAsync();
				context.Update(Ciudades);
				return await context.SaveChangesAsync() > 0;

			}

			public async Task<Ciudades?> Buscar(int CiudadId)
			{
				await using var context = await DbContextFactory.CreateDbContextAsync();
				return await context.Ciudades
					.FirstOrDefaultAsync(c => c.CiudadId == CiudadId);
			}

			public async Task<bool> Eliminar(int CiudadId)
			{
				await using var context = await DbContextFactory.CreateDbContextAsync();
				return await context.Ciudades.Where(c => c.CiudadId == CiudadId)
					.ExecuteDeleteAsync() > 0;
			}

			public async Task<List<Ciudades>> Listar(Expression<Func<Ciudades, bool>> criterio)
			{
				await using var context = await DbContextFactory.CreateDbContextAsync();
				return await context.Ciudades.Where(criterio).ToListAsync();

			}


			public async Task<Ciudades?> BuscarNombres(string CiudadNombre)
			{
				await using var context = await DbContextFactory.CreateDbContextAsync();
				return await context.Ciudades
					.FirstOrDefaultAsync(e => e.CiudadNombre == CiudadNombre);
			}

		}
}

