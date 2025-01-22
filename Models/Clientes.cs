using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Registro_Tecnicos.Models
{
	public class Clientes
	{

		[Key]

		public int ClienteId { get; set; }

		public int TecnicoId { get; set; }

		public DateTime FechaIngreso { get; set; }

		public string Nombres { get; set; }

		public string Direccion {  get; set; }

		public int RNC {  get; set; }

		public decimal LimiteCredito { get; set; }

	}
}
