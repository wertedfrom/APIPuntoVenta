using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPuntoVenta.Models
{
	public class Transaccion
	{
		public Guid Id { get; set; }
		public decimal ImporteCompra { get; set; }
		public decimal ImportePago { get; set; }
		public decimal Cambio { get; set; }
		public string MensajeCambio { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
