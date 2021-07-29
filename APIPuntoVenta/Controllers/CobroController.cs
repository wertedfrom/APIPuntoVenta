using APIPuntoVenta.Helpers;
using APIPuntoVenta.Models;
using APIPuntoVenta.Repository;
using APIPuntoVenta.Services;
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
		private readonly CobroService _cobroService;
		private const int _DECIMALES_PERMITIDOS = 2;

		public CobroController(ITransaccionRepository transaccionRepository)
		{
			_transaccionRepository = transaccionRepository;
			_cobroService = new CobroService(_transaccionRepository);
		}

		[HttpGet("ObtenerTransacciones")]
		public ActionResult<List<Transaccion>> GetTransacciones()
		{
			return _transaccionRepository.GetAll();
		}

		[HttpPost("CobrarYCalcularCambio")]
		public ActionResult<Cambio> CobrarYCalcularCambio(decimal totalAPagar, decimal totalPagado)
		{
			if (!Calculador.MenosDeNDecimales(totalAPagar,_DECIMALES_PERMITIDOS) || !Calculador.MenosDeNDecimales(totalPagado,_DECIMALES_PERMITIDOS)) {
				return BadRequest($"Los importes no pueden tener más de {_DECIMALES_PERMITIDOS} decimales");
			}

			if (totalAPagar <= 0)
			{
				return BadRequest("El total a Pagar no puede ser igual o menor a 0");
			}

			if (totalPagado < totalAPagar)
			{
				return BadRequest("El total pagado es menor al importe a pagar. Solicite al cliente completar el monto con el dinero faltante.");
			}

			var cambio = _cobroService.CobrarYCalcularCambio(totalAPagar, totalPagado);

			return Ok(cambio);
		}

		
	}
}
