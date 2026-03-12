using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.MsTeams.Util.Registrars;
using Soenneker.Redis.Lock.Registrars;
using Soenneker.Runners.Redis.Locks.Abstract;

namespace Soenneker.Runners.Redis.Locks.Registrars;

/// <summary>
/// A task runner that uses IRedisLockUtil to release a set of distributed Redis locks, typically when the application starts
/// </summary>
public static class RedisLocksRunnerRegistrar
{
    /// <summary>
    /// Adds <see cref="IRedisLocksRunner"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddRedisLocksRunnerAsSingleton(this IServiceCollection services)
    {
        services.AddMsTeamsUtilAsSingleton().AddRedisLockUtilAsSingleton().TryAddSingleton<IRedisLocksRunner, RedisLocksRunner>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IRedisLocksRunner"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddRedisLocksRunnerAsScoped(this IServiceCollection services)
    {
        services.AddMsTeamsUtilAsScoped().AddRedisLockUtilAsScoped().TryAddScoped<IRedisLocksRunner, RedisLocksRunner>();

        return services;
    }
}