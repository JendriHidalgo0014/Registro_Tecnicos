using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Registro_Tecnicos.Models;


public class Tecnicos
{

	[Key]

	public int TecnicoId { get; set; }

	[Required(ErrorMessage = "Este campo es requerido")]
	[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo solo puede contener letras y espacios.")]


	public string Nombres { get; set; }

	[Required(ErrorMessage = "Este campo es requerido")]

	public int SueldoHora { get; set; }

}
