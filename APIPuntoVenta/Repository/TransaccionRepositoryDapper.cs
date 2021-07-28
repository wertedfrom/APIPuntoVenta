using APIPuntoVenta.Data;
using APIPuntoVenta.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace APIPuntoVenta.Repository
{
	public class TransaccionRepositoryDapper : ITransaccionRepository
	{
		private IDbConnection db;

		public TransaccionRepositoryDapper(IConfiguration configuration)
		{
			this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
		}


		public Transaccion Add(Transaccion transaccion)
		{
			var sql = "INSERT INTO Transacciones (Id, ImporteCompra, ImportePago, Cambio, MensajeCambio, CreatedAt) " +
						"VALUES(@Id, @ImporteCompra, @ImportePago, @Cambio, @MensajeCambio, @CreatedAt);";
			
			return db.Query<Transaccion>(sql, new { 
				transaccion.Id,
				transaccion.ImporteCompra,
				transaccion.ImportePago,
				transaccion.Cambio,
				transaccion.MensajeCambio,
				transaccion.CreatedAt
			}).Single();
		}

		public Transaccion Find(Guid id)
		{
			var sql = "SELECT * FROM Transacciones WHERE Id = @Id";
			return db.Query<Transaccion>(sql, new { @Id = id }).Single();
		}

		public List<Transaccion> GetAll()
		{
			var sql = "SELECT * FROM Transacciones";
			return db.Query<Transaccion>(sql).ToList();
		}

		public void Remove(Guid id)
		{
			
			return;
		}

		public Transaccion Update(Transaccion transaccion)
		{
			
			return transaccion;
		}
	}
}
