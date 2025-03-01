using Microsoft.EntityFrameworkCore;
using Registro_Tecnicos.Models;
using Registro_Tecnicos.DAL;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Internal;

namespace Registro_Tecnicos.Services
{
	public class PrestamosDetalleService(IDbContextFactory<Context> DbFactory)
	{
		private readonly Context _context;

		// Método para listar detalles de un préstamo con un criterio de búsqueda
		public async Task<List<PrestamosDetalle>> Listar(Expression<Func<PrestamosDetalle, bool>> criterio)
		{
			await using var context = await DbFactory.CreateDbContextAsync();
			return await context.PrestamosDetalle.Where(criterio).ToListAsync();
		}

		// Método para agregar detalles de un préstamo
		public async Task<bool> AgregarDetalle(int prestamoId, int cuotaNo, decimal valor, decimal balance)
		{
			await using var context = await DbFactory.CreateDbContextAsync();

			if (valor <= 0)
				throw new ArgumentException("Error, el valor de la cuota debe ser mayor que cero.");

			var detalle = new PrestamosDetalle
			{
				PrestamoId = prestamoId,
				CuotaNo = cuotaNo,
				Fecha = DateTime.Now.AddMonths(cuotaNo),
				Valor = valor,
				Balance = balance
			};

			context.PrestamosDetalle.Add(detalle);
			await context.SaveChangesAsync();
			return true;
		}

		// Método para eliminar detalles de un préstamo
		public async Task<bool> EliminarDetalles(int prestamoId)
		{
			await using var context = await DbFactory.CreateDbContextAsync();
			var detalles = await context.PrestamosDetalle
									   .Where(d => d.PrestamoId == prestamoId)
									   .ToListAsync();

			if (detalles.Any())
			{
				context.PrestamosDetalle.RemoveRange(detalles);
				await context.SaveChangesAsync();
				return true;
			}
			return false;
		}

		// Método para calcular cuotas basado en el monto y cantidad de cuotas
		public async Task<bool> CalcularCuotas(int prestamoId, decimal monto, int cantidadCuotas)
		{
			await using var context = await DbFactory.CreateDbContextAsync();

			if (cantidadCuotas <= 0 || monto <= 0)
				throw new ArgumentException("Error, el monto y la cantidad de cuotas deben ser mayores que cero.");

			// Eliminar cuotas previas
			await EliminarDetalles(prestamoId);

			decimal valorCuota = monto / cantidadCuotas;
			decimal balance = monto;

			List<PrestamosDetalle> nuevasCuotas = new();

			for (int i = 1; i <= cantidadCuotas; i++)
			{
				nuevasCuotas.Add(new PrestamosDetalle
				{
					PrestamoId = prestamoId,
					CuotaNo = i,
					Fecha = DateTime.Now.AddMonths(i),
					Valor = valorCuota,
					Balance = balance
				});
				balance -= valorCuota;
			}

			context.PrestamosDetalle.AddRange(nuevasCuotas);
			await context.SaveChangesAsync();
			return true;
		}
	}
}
