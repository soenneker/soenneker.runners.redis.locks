[![](https://img.shields.io/nuget/v/soenneker.runners.redis.locks.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.runners.redis.locks/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.runners.redis.locks/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.runners.redis.locks/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.runners.redis.locks.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.runners.redis.locks/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.runners.redis.locks/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.runners.redis.locks/actions/workflows/codeql.yml)

# Soenneker.Runners.Redis.Locks

A DI-ready runner for clearing a known set of stale distributed Redis locks.

## Installation

```bash
dotnet add package Soenneker.Runners.Redis.Locks
```

## Registration

```csharp
using Soenneker.Runners.Redis.Locks.Registrars;

services.AddRedisLocksRunnerAsSingleton();
```

Scoped registration is also available:

```csharp
services.AddRedisLocksRunnerAsScoped();
```

Choose the lifetime that matches the service consuming the runner. The registrar also registers its Redis lock and Microsoft Teams dependencies with the same lifetime.

## Usage

```csharp
using Soenneker.Runners.Redis.Locks.Abstract;

public sealed class StartupRecovery(IRedisLocksRunner redisLocksRunner)
{
    public Task ClearStaleLocks(CancellationToken cancellationToken)
    {
        return redisLocksRunner.ReleaseLocks(
            ["jobs:import", "jobs:export"],
            cancellationToken);
    }
}
```

`ReleaseLocks` force-deletes each supplied Redis key without checking an ownership token. Use it only during controlled recovery when no valid owner can still be using those locks. It is not a substitute for releasing a normally acquired lock through its handle.

Keys are processed sequentially. Cancellation or a Redis failure stops processing and is propagated to the caller, so keys earlier in the sequence may already have been removed.
