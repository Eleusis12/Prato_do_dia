﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho_Laboratorio.Models;

namespace Trabalho_Laboratorio.ViewModel
{
	public class AdminManageUsersViewModel
	{
		public IQueryable<Clientes> Clientes { get; set; }
		public Administrador Administrador { get; set; }
	}
}