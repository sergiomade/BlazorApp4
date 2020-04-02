﻿using BlazorApp4.Shared.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Server
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			:base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<GeneroPelicula>().HasKey(x => new { x.GeneroId, x.PeliculaId });
			modelBuilder.Entity<PeliculaActor>().HasKey(x => new { x.PeliculaId, x.PersonaId });
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<GeneroPelicula> GenerosPelicula { get; set; }
		public DbSet<Genero> Generos { get; set; }
		public DbSet<Pelicula> Peliculas { get; set; }
		public DbSet<PeliculaActor> PeliculasActores { get; set; }
		public DbSet<Persona> Personas { get; set; }


	}
}
