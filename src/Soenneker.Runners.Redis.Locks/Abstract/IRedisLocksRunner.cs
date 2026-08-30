using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Runners.Redis.Locks.Abstract;

/// <summary>
/// Clears a known set of stale distributed Redis locks during controlled recovery.
/// </summary>
public interface IRedisLocksRunner
{
    /// <summary>
    /// Forcibly removes each supplied Redis lock without checking its ownership token.
    /// </summary>
    /// <param name="lockNames">Redis lock keys to remove.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task that completes when all supplied lock keys have been processed.</returns>
    Task ReleaseLocks(IEnumerable<string> lockNames, CancellationToken cancellationToken = default);
}
