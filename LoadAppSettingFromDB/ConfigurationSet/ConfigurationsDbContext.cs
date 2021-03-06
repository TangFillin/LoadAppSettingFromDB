﻿using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace LoadAppSettingFromDB.ConfigurationSet
{
    public class ConfigurationsDbContext : DbContext
    {
        public ConfigurationsDbContext()
        {

        }
        public ConfigurationsDbContext(DbContextOptions<ConfigurationsDbContext> _dbContextOptions):base(_dbContextOptions)
        {

        }

        public DbSet<SystemConfig> SystemConfigs { get; set; }
    }
}