using Microsoft.EntityFrameworkCore;

namespace DeviceManagement.Api.Models
{
    public class DeviceContext : DbContext
    {
        public DeviceContext(DbContextOptions<DeviceContext> options) : base(options) { }
        public DbSet<Device> Devices { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<DeviceAssignment> DeviceAssignments { get; set; }
    }
}
