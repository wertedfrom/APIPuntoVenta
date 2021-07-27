using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
				List<string> mensajeAProducir = new List<string>();
				if (BRL100 > 0) mensajeAProducir.Add($"{BRL100} nota/s de R$100");
				if (BRL50 > 0) mensajeAProducir.Add($"{BRL50} nota/s de R$50");
				if (BRL20 > 0) mensajeAProducir.Add($"{BRL20} nota/s de R$20");
				if (BRL10 > 0) mensajeAProducir.Add($"{BRL10} nota/s de R$10");

				if (!mensajeAProducir.Any())
				{
					return "No hay cambio para devolver. El pago fue justo.";
				}

				if (mensajeAProducir.Count == 1)
				{
					return "Entregar " + mensajeAProducir[0];
				}
				else
				{
					string lastElementOfMessage = mensajeAProducir.ElementAt(mensajeAProducir.Count - 1);
					mensajeAProducir.RemoveAt(mensajeAProducir.Count - 1);
					string message = String.Join(", ", mensajeAProducir);
					return String.Concat(message, " e ", lastElementOfMessage);
				}
			}
		}
	}
}
