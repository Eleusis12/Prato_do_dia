using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Trabalho_Laboratorio.Data;

namespace Trabalho_Laboratorio
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
			//var host = CreateHostBuilder(args).Build();

			//using (var scope = host.Services.CreateScope())
			//{
			//	var services = scope.ServiceProvider;

			//	try
			//	{
			//		var context = services.GetRequiredService<ApplicationDbContext>();
			//		DbInitialiser.Initialize(context);
			//	}
			//	catch (Exception ex)
			//	{
			//		var logger = services.GetRequiredService<ILogger<Program>>();
			//		logger.LogError(ex, "An error ocurred while seeding the database.");
			//		throw;
			//	}
			//}

			//host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}