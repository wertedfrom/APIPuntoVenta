using APIPuntoVenta.Data;
using APIPuntoVenta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPuntoVenta.Repository
{
	public class TransaccionRepositoryEF : ITransaccionRepository
	{
		private readonly AppDbContext _db;

		public TransaccionRepositoryEF(AppDbContext db)
		{
			_db = db;
		}


		public Transaccion Add(Transaccion transaccion)
		{
			_db.Transacciones.Add(transaccion);
			_db.SaveChanges();
			return transaccion;
		}

		public Transaccion Find(Guid id)
		{
			return _db.Transacciones.FirstOrDefault(t => t.Id == id);
		}

		public List<Transaccion> GetAll()
		{
			return _db.Transacciones.OrderByDescending(t =>t.CreatedAt).ToList();
		}

		public void Remove(Guid id)
		{
			Transaccion transaccion = _db.Transacciones.FirstOrDefault(t => t.Id == id);
			_db.Transacciones.Remove(transaccion);
			_db.SaveChanges();
			return;
		}

		public Transaccion Update(Transaccion transaccion)
		{
			_db.Transacciones.Update(transaccion);
			_db.SaveChanges();
			return transaccion;
		}
	}
}
