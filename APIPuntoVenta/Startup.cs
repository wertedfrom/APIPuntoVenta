using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using APIPuntoVenta.Data;
using APIPuntoVenta.Repository;

namespace APIPuntoVenta
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			
			//Usar la implementacion de repository deseada, actualmente usa DAPPER
			//services.AddScoped<ITransaccionRepository, TransaccionRepositoryEF>();
			services.AddScoped<ITransaccionRepository, TransaccionRepositoryDapper>();
			
			services.AddControllers();
			
			AddSwagger(services);
		}	

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Punto de Venta API V1");
			});

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}

		private void AddSwagger(IServiceCollection services)
		{
			services.AddSwaggerGen(options =>
			{
				var groupName = "v1";

				options.SwaggerDoc(groupName, new OpenApiInfo
				{
					Title = $"Punto de Venta API {groupName}",
					Version = groupName,
					Description = "Endpoints Punto de Venta API",
					Contact = new OpenApiContact
					{
						Name = "Totvs",
						Email = string.Empty,
						Url = new Uri("https://es.totvs.com/"),
					}
				});
			});
		}
	}
}
