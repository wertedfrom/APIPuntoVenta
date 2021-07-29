using APIPuntoVenta.Helpers;
using APIPuntoVenta.Models;
using APIPuntoVenta.Repository;
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
		private readonly ITransaccionRepository _transaccionRepository;

		public CobroController(ITransaccionRepository transaccionRepository)
		{
			_transaccionRepository = transaccionRepository;
		}

		[HttpGet("ObtenerTransacciones")]
		public ActionResult<List<Transaccion>> GetTransacciones()
		{
			return _transaccionRepository.GetAll();
		}

		[HttpPost("CobrarYCalcularCambio")]
		public ActionResult<Cambio> CobrarYCalcularCambio(decimal totalAPagar, decimal totalPagado)
		{
			if (totalAPagar <= 0)
			{
				return BadRequest("El total a Pagar no puede ser igual o menor a 0");
			}

			if (totalPagado < totalAPagar)
			{
				return BadRequest("El total pagado es menor al importe a pagar. Solicite al cliente completar el monto con el dinero faltante.");
			}

			decimal diferencia = totalPagado - totalAPagar;

			var cambio = CalculadorCambio.CalcularCambio(diferencia);
			
			var transaccion = new Transaccion
			{
				Id = Guid.NewGuid(),
				ImporteCompra = totalAPagar,
				ImportePago = totalPagado,
				Cambio = diferencia,
				MensajeCambio = cambio.message,
				CreatedAt = DateTime.Now
			};

			_transaccionRepository.Add(transaccion);

			return Ok(cambio);
		}

		
	}
}
