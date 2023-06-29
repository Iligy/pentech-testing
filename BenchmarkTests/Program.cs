using BenchmarkDotNet.Running;
using BenchmarkTests.Repositories;
using BenchmarkTests.Tests;

BenchmarkRunner.Run<DatabaseRepoTest>();
//BenchmarkRunner.Run<InMemoryRepoTest>();