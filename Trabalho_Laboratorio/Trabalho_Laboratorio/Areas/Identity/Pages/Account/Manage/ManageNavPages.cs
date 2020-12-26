using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Trabalho_Laboratorio.Areas.Identity.Pages.Account.Manage
{
	public static class ManageNavPages
	{
		public static string IndexAdmin => "IndexAdmin";

		public static string IndexClient => "IndexClient";

		public static string IndexRestaurant => "IndexRestaurant";

		public static string Email => "Email";
		public static string Meals => "Pratos_Favoritos";
		public static string Restaurants => "Restaurantes_Favoritos";
		public static string Alertas => "Alertas";

		public static string ChangePassword => "ChangePassword";

		public static string DownloadPersonalData => "DownloadPersonalData";

		public static string DeletePersonalData => "DeletePersonalData";

		public static string ExternalLogins => "ExternalLogins";

		public static string PersonalData => "PersonalData";

		public static string TwoFactorAuthentication => "TwoFactorAuthentication";

		public static string IndexAdminNavClass(ViewContext viewContext) => PageNavClass(viewContext, IndexAdmin);

		public static string IndexClientNavClass(ViewContext viewContext) => PageNavClass(viewContext, IndexClient);

		public static string IndexRestaurantNavClass(ViewContext viewContext) => PageNavClass(viewContext, IndexRestaurant);

		public static string Alerts(ViewContext viewContext) => PageNavClass(viewContext, Alertas);

		public static string EmailNavClass(ViewContext viewContext) => PageNavClass(viewContext, Email);

		public static string FavoritesDishes(ViewContext viewContext) => PageNavClass(viewContext, Meals);

		public static string FavoritesRestaurants(ViewContext viewContext) => PageNavClass(viewContext, Restaurants);

		public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);

		public static string DownloadPersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, DownloadPersonalData);

		public static string DeletePersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, DeletePersonalData);

		public static string ExternalLoginsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ExternalLogins);

		public static string PersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, PersonalData);

		public static string TwoFactorAuthenticationNavClass(ViewContext viewContext) => PageNavClass(viewContext, TwoFactorAuthentication);

		private static string PageNavClass(ViewContext viewContext, string page)
		{
			var activePage = viewContext.ViewData["ActivePage"] as string
				?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
			return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
		}
	}
}