using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using qodev_authentication_services.utils.jwt;

namespace qodev_authentication_services.db;

public class DatabaseContext : IdentityDbContext<JWTIdentity>
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}