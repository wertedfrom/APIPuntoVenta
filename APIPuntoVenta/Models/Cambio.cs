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

		public string Mensaje
		{
			get
			{
				List<string> mensajeAProducir = new List<string>();
				if (BRL100 > 0) mensajeAProducir.Add(String.Concat($"{BRL100} billete", ((BRL100 > 1) ? "s" : "")," de R$100"));
				if (BRL50 > 0) mensajeAProducir.Add(String.Concat($"{BRL50} billete", ((BRL50 > 1) ? "s" : "")," de R$50"));
				if (BRL20 > 0) mensajeAProducir.Add(String.Concat($"{BRL20} billete", ((BRL20 > 1) ? "s" : "")," de R$20"));
				if (BRL10 > 0) mensajeAProducir.Add(String.Concat($"{BRL10} billete", ((BRL10 > 1) ? "s" : "")," de R$10"));
				if (R050 > 0) mensajeAProducir.Add(String.Concat($"{R050} moneda",((R050 > 1)?"s":"")," de R$0.50"));
				if (R010 > 0) mensajeAProducir.Add(String.Concat($"{R010} moneda",((R010 > 1)?"s":"")," de R$0.10"));
				if (R005 > 0) mensajeAProducir.Add(String.Concat($"{R005} moneda",((R005 > 1)?"s":"")," de R$0.05"));
				if (R001 > 0) mensajeAProducir.Add(String.Concat($"{R001} moneda",((R001 > 1)?"s":"")," de R$0.01"));

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
					return String.Concat("Entregar ", message, " y ", lastElementOfMessage);
				}
			}
		}
	}
}
