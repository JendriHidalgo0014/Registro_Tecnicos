using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Registro_Tecnicos.Models
{
	public class Tickets
	{
		[Key]
		public int TicketId { get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		public DateTime Fecha {  get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		public string Prioridad { get; set; }

		[ForeignKey("ClienteId")]
		public int ClienteId { get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		public string Asunto {  get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		public string TiempoInvertido { get; set; }

		[ForeignKey("TecnicoId")]

		public int TecnicoId { get; set; }	

	}
}
