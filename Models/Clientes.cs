using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Registro_Tecnicos.Models
{
	public class Clientes
	{

		[Key]

		public int ClienteId { get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]

		public DateTime FechaIngreso { get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo solo puede contener letras y espacios.")]
		public string Nombres { get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		public string Direccion {  get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		[RegularExpression(@"^\d+$", ErrorMessage = "El campo solo puede contener números.")]

		public int RNC {  get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		[RegularExpression(@"^\d+$", ErrorMessage = "El campo solo puede contener números.")]
		public decimal LimiteCredito { get; set; }

		[ForeignKey("TecnicoId")]
		public int TecnicoId { get; set; }
	}
}
