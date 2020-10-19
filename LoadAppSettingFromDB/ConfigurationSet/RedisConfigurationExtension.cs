using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Text.Json;

namespace LoadAppSettingFromDB.ConfigurationSet
{
    public static class RedisConfigurationExtension
    {
        public static IConfigurationBuilder AddEntityFramework(this IConfigurationBuilder builder, Action<DbContextOptionsBuilder<ConfigurationsDbContext>> action)
            => builder.Add(new EntityFrameworkConfigurationSource(action));
        public static T ToObj<T>(this string strObj)
        {
            return JsonSerializer.Deserialize<T>(strObj);
        }
    }
}
