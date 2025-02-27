using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Registro_Tecnicos.Models
{
	public class Prestamos
	{

		[Key]
		public int PrestamoId { get; set; }

		public decimal Monto { get; set; }

		public int CantidadCoutas { get; set; }



	}
}
