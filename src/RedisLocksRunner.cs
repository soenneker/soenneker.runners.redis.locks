using Soenneker.Runners.Redis.Locks.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Soenneker.MsTeams.Util.Abstract;
using Soenneker.Redis.Lock.Abstract;
using Soenneker.Utils.BackgroundQueue.Abstract;
using System.Threading;

namespace Soenneker.Runners.Redis.Locks;

/// <inheritdoc cref="IRedisLocksRunner"/>
public sealed class RedisLocksRunner : Runner.Runner, IRedisLocksRunner
{
    private readonly IRedisLockUtil _redisLockUtil;

    public RedisLocksRunner(IRedisLockUtil redisLockUtil, ILogger<RedisLocksRunner> logger, IMsTeamsUtil msTeamsUtil, IBackgroundQueue backgroundQueue)
        : base(logger, msTeamsUtil, backgroundQueue)
    {
        _redisLockUtil = redisLockUtil;
    }

    public Task ReleaseLocks(IEnumerable<string> lockNames, CancellationToken cancellationToken = default)
    {
        return _redisLockUtil.UnlockAll(lockNames, cancellationToken);
    }
}
