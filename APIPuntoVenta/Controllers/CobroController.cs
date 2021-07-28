using APIPuntoVenta.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPuntoVenta.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CobroController : ControllerBase
	{
		[HttpGet]
		public string Get()
		{
			return "Llegue";
		}

		[HttpPost("CalcularCambio")]
		public ActionResult<Cambio> CalcularCambio(decimal totalAPagar, decimal totalPagado)
		{
			if (totalAPagar <= 0)
			{
				return BadRequest("El total a Pagar no puede ser igual o menor a 0");
			}

			if (totalPagado < totalAPagar)
			{
				return BadRequest("El total pagado es menor al importe a pagar. Solicite al cliente completar el monto con el dinero faltante.");
			}

			Cambio cambio = new Cambio();
			decimal diferencia = totalPagado - totalAPagar;
			decimal restante = diferencia;

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
				cambio.R050 = (int) (restante / (decimal)0.50);
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

			return Ok(cambio);
		}
	}
}
