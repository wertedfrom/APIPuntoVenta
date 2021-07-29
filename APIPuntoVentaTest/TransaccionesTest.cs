using APIPuntoVenta.Helpers;
using APIPuntoVenta.Models;
using APIPuntoVenta.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace APIPuntoVentaTest
{
	[TestClass]
	public class TransaccionesTest
	{

		[TestMethod]
		public void CalcularCambioConVueltoTest()
		{
			var diferencia = (decimal)172.75;

			var cambio = CalculadorCambio.CalcularCambio(diferencia);

			Assert.AreNotEqual(cambio.message, "No hay cambio para devolver. El pago fue justo.");
			Console.WriteLine("Mensaje: " + cambio.message);
		}

		[TestMethod]
		public void CalcularCambioSinVueltoTest()
		{
			var diferencia = (decimal)0;

			var cambio = CalculadorCambio.CalcularCambio(diferencia);

			Assert.AreEqual(cambio.message, "No hay cambio para devolver. El pago fue justo.");
			Console.WriteLine("Mensaje: " + cambio.message);
		}
	}
}
