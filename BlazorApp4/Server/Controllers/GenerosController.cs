﻿using BlazorApp4.Shared.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]

	public class GenerosController : ControllerBase
	{
		private readonly ApplicationDbContext context;

		public GenerosController(ApplicationDbContext context)
		{
			this.context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<Genero>>> Get()
		{
			return await context.Generos.ToListAsync();
		}

		[HttpPost]
		public async Task<ActionResult<int>> Post(Genero genero)
		{
			context.Add(genero);
			await context.SaveChangesAsync();
			return genero.Id;
		}
	}
}
