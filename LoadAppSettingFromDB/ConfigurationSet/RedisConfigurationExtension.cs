using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace LoadAppSettingFromDB.ConfigurationSet
{
    public static class RedisConfigurationExtension
    {
        public static IConfigurationBuilder AddEntityFramework(this IConfigurationBuilder builder, Action<DbContextOptionsBuilder<ConfigurationsDbContext>> action)
            => builder.Add(new EntityFrameworkConfigurationSource(action));
    }
}
