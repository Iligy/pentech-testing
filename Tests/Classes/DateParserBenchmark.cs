using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkTest.Classes
{
    [SimpleJob(RuntimeMoniker.Net70)]
    [SimpleJob(RuntimeMoniker.Net60, baseline:true)]
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class DateParserBenchmark
    {
        private DateTime dateTime = DateTime.Now;
        private static readonly DateParser Parser = new DateParser();

        [Benchmark(Baseline = true)]
        public void GetYearMonthDay()
        {
            Parser.GetYearMonthDay(dateTime);
        }

        [Benchmark]
        public void GetYearMonthDayConcat()
        {
            Parser.GetYearMonthDayConcat(dateTime);
        }

        [Benchmark]
        public void GetYearMonthDayWunschBasic()
        {
            Parser.GetYearMonthDayWunschBasic(dateTime);
        }

        [Benchmark]
        public void GetYearMonthDayWunschFullPower()
        {
            Parser.GetYearMonthDayWunschFullPower(dateTime);
        }
    }
}
