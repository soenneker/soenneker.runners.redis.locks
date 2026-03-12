using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Runners.Redis.Locks.Abstract;

/// <summary>
/// A task runner that uses IRedisLockUtil to release a set of distributed Redis locks, typically when the application starts
/// </summary>
public interface IRedisLocksRunner
{
    Task ReleaseLocks(IEnumerable<string> lockNames, CancellationToken cancellationToken = default);
}