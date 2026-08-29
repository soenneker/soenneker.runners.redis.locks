using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Runners.Redis.Locks.Abstract;

/// <summary>
/// A task runner that uses IRedisLockUtil to release a set of distributed Redis locks, typically when the application starts
/// </summary>
public interface IRedisLocksRunner
{
    /// <summary>
    /// Releases locks for the Redis Locks Runner.
    /// </summary>
    /// <param name="lockNames">lock Names to process.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task that completes when the release locks operation is complete.</returns>
    Task ReleaseLocks(IEnumerable<string> lockNames, CancellationToken cancellationToken = default);
}
