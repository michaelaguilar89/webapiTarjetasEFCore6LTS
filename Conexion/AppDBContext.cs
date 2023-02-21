using Microsoft.EntityFrameworkCore;
using WebApiTarjetas.Models;

namespace WebApiTarjetas.Conexion
{
	public class AppDBContext : DbContext
	{
		public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
		{
		}
		public DbSet<card> cards { get; set; }
	}
}
