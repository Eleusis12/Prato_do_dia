using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trabalho_Laboratorio.Helpers.Enums;

namespace Trabalho_Laboratorio.BaseController
{
	public class BaseController : Controller
	{
		public void Notification(string message, NotificationType notificationType)
		{
			TempData["icon"] = notificationType.ToString();
			TempData["message"] = message;
		}

		public void Alert(string message, NotificationType notificationType)
		{
		}
	}
}