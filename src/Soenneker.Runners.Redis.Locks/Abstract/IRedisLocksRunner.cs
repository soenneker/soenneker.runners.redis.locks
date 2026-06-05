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
    /// Executes the release locks operation.
    /// </summary>
    /// <param name="lockNames">The lock names.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task ReleaseLocks(IEnumerable<string> lockNames, CancellationToken cancellationToken = default);
}