using APIPuntoVenta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPuntoVenta.Helpers
{
	public static class Calculador
	{
		public static decimal CalcularDiferencia(decimal totalPagado, decimal totalAPagar) { 
			return totalPagado - totalAPagar;
		}

		public static Cambio CalcularCambio(decimal diferencia)
		{

			decimal restante = diferencia;
			Cambio cambio = new Cambio();

			if (restante >= 100)
			{
				cambio.BRL100 = (int)restante / 100;
				restante -= (cambio.BRL100 * 100);
			}

			if (restante >= 50)
			{
				cambio.BRL50 = (int)restante / 50;
				restante -= (cambio.BRL50 * 50);
			}

			if (restante >= 20)
			{
				cambio.BRL20 = (int)restante / 20;
				restante -= (cambio.BRL20 * 20);
			}

			if (restante >= 10)
			{
				cambio.BRL10 = (int)restante / 10;
				restante -= (cambio.BRL10 * 10);
			}

			if (restante >= (decimal)0.50)
			{
				cambio.R050 = (int)(restante / (decimal)0.50);
				restante -= (decimal)(cambio.R050 * 0.50);
			}

			if (restante >= (decimal)0.10)
			{
				cambio.R010 = (int)(restante / (decimal)0.10);
				restante -= (decimal)(cambio.R010 * 0.10);
			}

			if (restante >= (decimal)0.05)
			{
				cambio.R005 = (int)(restante / (decimal)0.05);
				restante -= (decimal)(cambio.R005 * 0.05);
			}

			if (restante >= (decimal)0.01)
			{
				cambio.R001 = (int)(restante / (decimal)0.01);
				restante -= (decimal)(cambio.R001 * 0.01);
			}

			return cambio;
		}

		public static bool MenosDeNDecimales(decimal numero, int decimalesPermitidos)
		{
			return Decimal.Round(numero, decimalesPermitidos) == numero;
		}
	}
}
