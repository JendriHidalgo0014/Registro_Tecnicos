using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Registro_Tecnicos.Models
{
	public class Sistemas
	{

		[Key]

		public int SistemaId { get; set; }

		public string Descripcion { get; set; }	

		public string Complejidad { get; set; }

	}
}
