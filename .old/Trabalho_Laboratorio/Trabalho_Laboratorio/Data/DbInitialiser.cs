using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho_Laboratorio.Data
{
	public class DbInitialiser
	{
		public static void Initialize(RestaurantesContext context)
		{
			// Assegura que a base de dados é criada automaticamente sem ter que recorrer ao comando "update-database"
			context.Database.EnsureCreated();

			return;
		}
	}
}