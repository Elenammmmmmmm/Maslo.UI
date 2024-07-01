using KR.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Maslo.API.Data
{
	public class AppDbContext : DbContext
	{
		public DbSet<Kros> Kros { get; set; }
		public DbSet<Category> Categories { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}
		
	}
}
