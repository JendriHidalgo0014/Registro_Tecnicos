using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Registro_Tecnicos.Models
{
	public class Tickets
	{
		[Key]
		public int TicketId { get; set; }

		public DateTime Fecha {  get; set; }

		public string Prioridad { get; set; }

		[ForeignKey("ClienteId")]
		public int ClienteId { get; set; }

		public string Asunto {  get; set; }

		public string Descripcion { get; set; }	

		public int TiempoInvertido { get; set; }

		[ForeignKey("TecnicoId")]

		public int TecnicoId { get; set; }	

	}
}
