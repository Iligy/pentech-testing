using BenchmarkDatabase.Entities;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkTests.Repositories;

namespace BenchmarkTests.Tests
{
    [SimpleJob(RuntimeMoniker.Net60, baseline:true)]
    [SimpleJob(RuntimeMoniker.Net70)]
    public class DatabaseRepoTest
    {
        private readonly DatabaseRepo _repo;
        public DatabaseRepoTest()
        {
            _repo = new DatabaseRepo();
        }

        // Employee

        [Benchmark]
        public void IEnumerableGetTopTenHFIEmployee()
        {
            _repo.IEnumerableGetTopTenHFIEmployee();
        }


        [Benchmark]
        public void IQueryableGetTopTenHFIEmployee()
        {
            _repo.IQueryableGetTopTenHFIEmployee();
        }

        [Benchmark]
        public void IListGetTopTenHFIEmployee()
        {
            _repo.IListGetTopTenHFIEmployee();
        }

        [Benchmark]
        public void ICollectionTopTenHFIEmployee()
        {
            _repo.ICollectionTopTenHFIEmployee();
        }

        [Benchmark]
        public void ListTopTenHFIEmployee()
        {
            _repo.ListTopTenHFIEmployee();
        }

        // EmployeeNoAno

        [Benchmark]
        public void IEnumerableGetTopTenHFIEmployeeNoAnno()
        {
            _repo.IEnumerableGetTopTenHFIEmployeeNoAnno();
        }

        [Benchmark]
        public void IQueryableGetTopTenHFIEmployeeNoAnno()
        {
            _repo.IQueryableGetTopTenHFIEmployeeNoAnno();
        }

        [Benchmark]
        public void IListGetTopTenHFIEmployeeNoAnno()
        {
            _repo.IListGetTopTenHFIEmployeeNoAnno();
        }

        [Benchmark]
        public void ICollectionTopTenHFIEmployeeNoAnno()
        {
            _repo.ICollectionTopTenHFIEmployeeNoAnno();
        }

        [Benchmark]
        public void ListTopTenHFIEmployeeNoAnno()
        {
            _repo.ListTopTenHFIEmployeeNoAnno();
        }
    }
}
