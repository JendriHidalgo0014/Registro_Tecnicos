using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Registro_Tecnicos.Models;


public class Tecnicos
{
	[Key]

	public int TecnicoId { get; set; }

	[Required(ErrorMessage = "Este campo es requerido")]

	public string Nombres { get; set; } = null!;

	public int SueldoHora { get; set; }

}
