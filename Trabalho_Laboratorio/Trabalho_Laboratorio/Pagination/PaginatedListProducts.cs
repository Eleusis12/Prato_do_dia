﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Trabalho_Laboratorio.Pagination

{
	public class PaginatedListProducts<T> : List<T>
	{
		public int PageIndex { get; private set; }
		public int TotalPages { get; private set; }

		public PaginatedListProducts(List<T> items, int count, int pageIndex, int pageSize)
		{
			PageIndex = pageIndex;
			TotalPages = (int)Math.Ceiling(count / (double)pageSize);

			this.AddRange(items);
		}

		public bool HasPreviousPage
		{
			get
			{
				return (PageIndex > 1);
			}
		}

		public bool HasNextPage
		{
			get
			{
				return (PageIndex < TotalPages);
			}
		}

		public static async Task<PaginatedListProducts<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
		{
			var count = await source.CountAsync();
			var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
			return new PaginatedListProducts<T>(items, count, pageIndex, pageSize);
		}
	}
}