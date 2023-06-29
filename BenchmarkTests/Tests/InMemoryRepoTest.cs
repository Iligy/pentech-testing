using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkTests.Repositories;

namespace BenchmarkTests.Tests
{
    [SimpleJob(RuntimeMoniker.Net60, baseline: true)]
    [SimpleJob(RuntimeMoniker.Net70)]
    public class InMemoryRepoTest
    {
        private readonly InMemoryRepo _repo;
        public InMemoryRepoTest()
        {
            _repo = new InMemoryRepo();
        }

        [Benchmark]
        public void IEnumerableEmployeeLoopTest() 
        {
            _repo.IEnumerableEmployeeLoopTest();
        }

        [Benchmark]
        public void IQueryableEmployeeLoopTest()
        {
            _repo.IQueryableEmployeeLoopTest();
        }

        [Benchmark]
        public void IListLoopEmployeeTest()
        {
            _repo.IListLoopEmployeeTest();
        }

        [Benchmark]
        public void ICollectionEmployeeLoopTest()
        {
            _repo.ICollectionEmployeeLoopTest();
        }

        [Benchmark]
        public void ListLoopEmployeeTest()
        {
            _repo.ListLoopEmployeeTest();
        }

        [Benchmark]
        public void IEnumerableEmployeeNoAnoLoopTest()
        {
            _repo.IEnumerableEmployeeNoAnoLoopTest();
        }

        [Benchmark]
        public void IQueryableEmployeeNoAnoLoopTest()
        {
            _repo.IQueryableEmployeeNoAnoLoopTest();
        }

        [Benchmark]
        public void IListLoopEmployeeNoAnoTest()
        {
            _repo.IListLoopEmployeeNoAnoTest();
        }

        [Benchmark]
        public void ICollectionEmployeeNoAnoLoopTest()
        {
            _repo.ICollectionEmployeeNoAnoLoopTest();
        }

        [Benchmark]
        public void ListLoopEmployeeNoAnoTest()
        {
            _repo.ListLoopEmployeeNoAnoTest();
        }
    }
}
