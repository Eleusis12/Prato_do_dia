﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho_Laboratorio.Data
{
	public static class SeedRoles
	{
		public static void Seed(RoleManager<IdentityRole> roleManager)
		{
			if (roleManager.Roles.Any() == false)
			{
				roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
				roleManager.CreateAsync(new IdentityRole("Client")).Wait();
				roleManager.CreateAsync(new IdentityRole("Restaurant")).Wait();
			}
		}
	}
}