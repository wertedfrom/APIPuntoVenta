using APIPuntoVenta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPuntoVenta.Repository
{
	public interface ITransaccionRepository
	{
		Transaccion Find(Guid id);
		List<Transaccion> GetAll();
		Transaccion Add(Transaccion transaccion);
		Transaccion Update(Transaccion transaccion);
		void Remove(Guid id);
	}
}
