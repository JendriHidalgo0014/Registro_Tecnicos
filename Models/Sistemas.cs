using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Registro_Tecnicos.Models
{
	public class Sistemas
	{

		[Key]

		public int SistemaId { get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		public decimal Complejidad { get; set; }

	}
}
