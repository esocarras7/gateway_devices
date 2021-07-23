using Microsoft.EntityFrameworkCore;
using gateway_devices.Model;

namespace gateway_devices.Context
{
    public class GatewayDbContext : DbContext
    {
        public GatewayDbContext(DbContextOptions<GatewayDbContext> options)
        : base(options)
        {

        }

        public DbSet<Gateway> Gateways { get; set; }
        public DbSet<Device> Devices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}