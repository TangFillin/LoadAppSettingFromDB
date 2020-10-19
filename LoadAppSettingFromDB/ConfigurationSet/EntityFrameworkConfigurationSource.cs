using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace LoadAppSettingFromDB.ConfigurationSet
{
    public class EntityFrameworkConfigurationSource : IConfigurationSource
    {
        private readonly Action<DbContextOptionsBuilder<ConfigurationsDbContext>> _action;
        private readonly DbContextOptionsBuilder<ConfigurationsDbContext> DbcontextOptionsBuilder = new DbContextOptionsBuilder<ConfigurationsDbContext>();

        public EntityFrameworkConfigurationSource(Action<DbContextOptionsBuilder<ConfigurationsDbContext>> action)
        {
            _action = action;
        }
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            _action.Invoke(DbcontextOptionsBuilder);
            return new EntityFrameworkConfigurationProvider(DbcontextOptionsBuilder.Options);
        }

        
    }
}
