using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Registro_Tecnicos.Models
{
	public class Prestamos
	{

		[Key]

		public int PrestamoId { get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		public decimal Monto { get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		[RegularExpression(@"^\d+$", ErrorMessage = "El campo solo puede contener números.")]
		public int CantidadCuotas { get; set; }	




	}
}
