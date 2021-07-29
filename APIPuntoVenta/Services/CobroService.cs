using APIPuntoVenta.Helpers;
using APIPuntoVenta.Models;
using APIPuntoVenta.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPuntoVenta.Services
{
	public class CobroService
	{
		private readonly ITransaccionRepository _transaccionRepository;

		public CobroService(ITransaccionRepository transaccionRepository)
		{
			_transaccionRepository = transaccionRepository;
		}

		public Cambio CobrarYCalcularCambio(decimal totalAPagar, decimal totalPagado)
		{
			decimal diferencia = Calculador.CalcularDiferencia(totalPagado, totalAPagar);

			var cambio = Calculador.CalcularCambio(diferencia);

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

			return cambio;
		}
	}
}
