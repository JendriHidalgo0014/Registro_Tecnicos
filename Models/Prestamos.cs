using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Registro_Tecnicos.Models
{
	public class Prestamos
	{

		[Key]

		public int PrestamoId { get; set; }

		public decimal Monto { get; set; }

		public int CantidadCuotas { get; set; }	




	}
}
