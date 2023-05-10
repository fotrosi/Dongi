using Dongi.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Dongi.Data;

public class DongiDbContext : AbpDbContext<DongiDbContext>
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Tx> Txs { get; set; }
    public DbSet<TxDetail> TxDetails { get; set; }

    public DongiDbContext(DbContextOptions<DongiDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own entities here */

        builder.Entity<Person>(b =>
        {
            b.ToTable("AppPersons");
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);

            //Define the relation
            b.HasMany(x => x.TxDetails)
                .WithOne(x => x.Person)
                .HasForeignKey(x => x.PersonId)
                .IsRequired();
        });

        builder.Entity<Tx>(b =>
        {
            b.ToTable("AppTxs");
            b.ConfigureByConvention(); //auto configure for the base class props

            //Define the relation
            b.HasMany(x => x.TxDetails)
                .WithOne(x => x.Tx)
                .HasForeignKey(x => x.TxId)
                .IsRequired();
        });

        builder.Entity<TxDetail>(b =>
        {
            b.ToTable("AppTxDetails");
            b.ConfigureByConvention(); //auto configure for the base class props
        });
    }
}
