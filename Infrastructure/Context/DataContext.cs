
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<UserEntity>(options)
{
    public DbSet<AddressEntity> Addresses { get; set; }

    //public DbSet<UserEntity> Users { get; set; }
    public DbSet<FeatureEntity> Features { get; set; }
    public DbSet<FeatureItemEntity> FeaturesItems { get; set; }
    public DbSet<LightDarkSliderEntity> DarkLightSlider { get; set; }
    public DbSet<ToolsEntity> Tool { get; set; }
    public DbSet<ToolsItemEntity> ToolItems { get; set; }
}
