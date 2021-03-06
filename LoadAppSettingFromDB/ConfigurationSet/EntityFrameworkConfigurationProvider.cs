﻿using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LoadAppSettingFromDB.ConfigurationSet
{
    /// <summary>
    /// 从数据库读取配置
    /// </summary>
    public class EntityFrameworkConfigurationProvider : ConfigurationProvider
    {
        private readonly DbContextOptions<ConfigurationsDbContext> _dbContextOptions;

        public EntityFrameworkConfigurationProvider(DbContextOptions<ConfigurationsDbContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }
        public override void Load()
        {
            using (var dbContext = new ConfigurationsDbContext(_dbContextOptions))
            {
                var configurations = dbContext.SystemConfigs
                                                .AsNoTracking()
                                                .ToArray();
                if (configurations.Length == 0)
                {
                    return;
                }
                foreach (var configuration in configurations)
                {
                    Data[configuration.Key] = JsonSerializer.Serialize(configuration);
                    //Data[configuration.Key] = configuration.Value;
                }
            }
        }
    }
}
