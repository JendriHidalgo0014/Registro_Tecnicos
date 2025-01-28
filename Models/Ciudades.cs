using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Registro_Tecnicos.Models
{
	public class Ciudades
	{
		[Key]

		public int CiudadId { get; set; }

		public string CiudadNombre { get; set; }

	}
}
