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
			if (totalAPagar <= 0) {
				return BadRequest("El total a Pagar no puede ser igual o menor a 0");
			}

			if (totalPagado < totalAPagar) {
				return BadRequest("El total pagado es menor al importe a pagar. Solicite al cliente completar el monto con el dinero faltante.");
			}

			Cambio cambio = new Cambio();

			return Ok(cambio);
		}
	}
}
