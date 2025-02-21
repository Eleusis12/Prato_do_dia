﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Trabalho_Laboratorio.Helpers
{
	public static class InheritHelper
	{
		public static void FillProperties<T, Tbase>(this T target, Tbase baseInstance)
		where T : Tbase
		{
			Type t = typeof(T);
			Type tb = typeof(Tbase);
			PropertyInfo[] properties = tb.GetProperties();
			foreach (PropertyInfo pi in properties)
			{
				// Skip unreadable and writeprotected ones
				if (!pi.CanRead || !pi.CanWrite) continue;
				// Read value
				object value = pi.GetValue(baseInstance, null);
				// Get Property of target class
				PropertyInfo pi_target = t.GetProperty(pi.Name);
				// Write value to target
				pi_target.SetValue(target, value, null);
			}
		}
	}
}