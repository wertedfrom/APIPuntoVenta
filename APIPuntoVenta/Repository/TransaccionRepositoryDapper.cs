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
			
			db.Query<Transaccion>(sql, transaccion);
			return transaccion;
		}

		public Transaccion Find(Guid id)
		{
			var sql = "SELECT * FROM Transacciones WHERE Id = @Id";
			return db.Query<Transaccion>(sql, new { @Id = id }).Single();
		}

		public List<Transaccion> GetAll()
		{
			var sql = "SELECT * FROM Transacciones ORDER BY CreatedAt DESC;";
			return db.Query<Transaccion>(sql).ToList();
		}

		public void Remove(Guid id)
		{
			var sql = "DELETE * FROM Transacciones WHERE Id = @Id";
			db.Execute(sql, new { @Id = id });
			return;
		}

		public Transaccion Update(Transaccion transaccion)
		{
			var sql = "UPDATE transacciones "+
				"SET ImporteCompra = @ImporteCompra, ImportePago = @ImportePago, Cambio = @Cambio, MensajeCambio = @MensajeCambio, " +
				"CreatedAt = @CreatedAt WHERE Id = @Id";
			db.Execute(sql, transaccion);
			return transaccion;
		}
	}
}
