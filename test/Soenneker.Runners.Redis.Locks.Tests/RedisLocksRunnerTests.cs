using Soenneker.Runners.Redis.Locks.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Runners.Redis.Locks.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class RedisLocksRunnerTests : HostedUnitTest
{
    private readonly IRedisLocksRunner _util;

    public RedisLocksRunnerTests(Host host) : base(host)
    {
        _util = Resolve<IRedisLocksRunner>(true);
    }

    [Test]
    public void Default()
    {

    }
}
