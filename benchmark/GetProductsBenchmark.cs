using System;
using System.Net.Http;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.CsProj;
using Hachette.API.SDK.Common;

namespace Hachette.API.SDK.Benchmark
{
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public class GetProductsBenchmark
    {
        private class Config : ManualConfig
        {
            public Config()
            {
                var baseJob = Job.MediumRun.With(CsProjCoreToolchain.Current.Value);
                Add(baseJob.WithNuGet("Hachette.API.SDK", "0.2.0-CI-20181113-222416").WithId("0.2.0-CI-20181113-222416"));
            }
        }
        private  static RestClient client = new RestClient(new Security{
            DeveloperKey = "ssvRQ0E7OfFPSzZ29s4wGuwJHxHEmVfy"
        });

        [Benchmark]
        public async Task ObtainISBNInProduction()
        {
            Environment.SetEnvironmentVariable("hukRestClientEndpointType","production",EnvironmentVariableTarget.Process);
            CommonParameters parameters = new CommonParameters();
            parameters.Id = "9780297843320";
            var r = await client.GetAsync(parameters);
            return;
        }

    }

}