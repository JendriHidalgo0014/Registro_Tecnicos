using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Registro_Tecnicos.Models
{
	public class Prestamos
	{

		[Key]

		public int PrestamoId { get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		[Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]

		public decimal Monto { get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		[RegularExpression(@"^\d+$", ErrorMessage = "El campo solo puede contener números.")]
		[Range(1, int.MaxValue, ErrorMessage = "Debe haber al menos 1 cuota")]
		public int CantidadCuotas { get; set; }


		[ForeignKey("PrestamoId")]
		public ICollection<PrestamosDetalle> PrestamosDetalle { get; set; } = new List<PrestamosDetalle>();

	}
}
