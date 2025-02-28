using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Registro_Tecnicos.Models
{
	public class PrestamosDetalle
	{

		[Key]

		public int DetalleId { get; set; }

		[ForeignKey("PrestamoId")]
		public int PrestamoId { get; set; }
		public Prestamos Prestamos { get; set; } = null!;

		public int CuotaNo { get; set; }

		public DateTime Fecha { get; set; }

		public decimal Valor { get; set; }
		
		public decimal Balance { get; set; }	



	}
}
