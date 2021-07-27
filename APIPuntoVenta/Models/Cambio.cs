using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPuntoVenta.Models
{
	public class Cambio
	{
		public int BRL100 { get; set; }
		public int BRL50 { get; set; }
		public int BRL20 { get; set; }
		public int BRL10 { get; set; }
		public int R050 { get; set; }
		public int R010 { get; set; }
		public int R005 { get; set; }
		public int R001 { get; set; }

		public string message
		{
			get
			{
				string message = "Entregar ";
				return message;
			}
		}
	}
}
