[![](https://img.shields.io/nuget/v/soenneker.runners.redis.locks.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.runners.redis.locks/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.runners.redis.locks/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.runners.redis.locks/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.runners.redis.locks.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.runners.redis.locks/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.runners.redis.locks/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.runners.redis.locks/actions/workflows/codeql.yml)

# Soenneker.Runners.Redis.Locks

A task runner that uses IRedisLockUtil to release a set of distributed Redis locks, typically when the application starts.

> This is an automation runner, not a package intended for application consumption.

## What the runner does

- `IRedisLocksRunner.ReleaseLocks(lockNames, cancellationToken)` — Releases locks for the Redis Locks Runner.
- `RedisLocksRunnerRegistrar.AddRedisLocksRunnerAsSingleton(services)` — Adds `IRedisLocksRunner` as a singleton service.
- `RedisLocksRunnerRegistrar.AddRedisLocksRunnerAsScoped(services)` — Adds `IRedisLocksRunner` as a scoped service.

## What you get

- `IRedisLocksRunner` — A task runner that uses IRedisLockUtil to release a set of distributed Redis locks, typically when the application starts.
- `RedisLocksRunnerRegistrar` — A task runner that uses IRedisLockUtil to release a set of distributed Redis locks, typically when the application starts.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `RedisLocksRunnerRegistrar.AddRedisLocksRunnerAsSingleton(services)` | Adds `IRedisLocksRunner` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `RedisLocksRunnerRegistrar.AddRedisLocksRunnerAsScoped(services)` | Adds `IRedisLocksRunner` as a scoped service. | The same service collection, so additional registrations can be chained. |
