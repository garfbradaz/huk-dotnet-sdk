using System;
using BenchmarkDotNet.Running;

namespace Hachette.API.SDK.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var runnerProduction = BenchmarkRunner.Run<GetProductsBenchmark>();
        }
    }
}