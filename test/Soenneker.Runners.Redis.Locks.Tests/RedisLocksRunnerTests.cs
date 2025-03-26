using Soenneker.Runners.Redis.Locks.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Runners.Redis.Locks.Tests;

[Collection("Collection")]
public class RedisLocksRunnerTests : FixturedUnitTest
{
    private readonly IRedisLocksRunner _util;

    public RedisLocksRunnerTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IRedisLocksRunner>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
