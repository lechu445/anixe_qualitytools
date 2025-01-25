using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains;
using BenchmarkDotNet.Toolchains.Results;
using BenchmarkDotNet.Validators;
using System;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;

namespace Anixe.QualityTools.Test.Benchmark
{
  public static class MockFactory
  {
    public static Summary CreateSummary(Type benchmarkType, string[] result)
    {
      var runInfo = BenchmarkConverter.TypeToBenchmarks(benchmarkType);
      return new Summary(
          title: "MockSummary",
          reports: runInfo.BenchmarksCases.Select((benchmark, index) => CreateReport(benchmark, result[index])).ToImmutableArray(),
          hostEnvironmentInfo: new HostEnvironmentInfoBuilder().WithoutDotNetSdkVersion().Build(),
          resultsDirectoryPath: "",
          logFilePath: "",
          totalTime: TimeSpan.FromMinutes(1),
          cultureInfo: CultureInfo.InvariantCulture,
          validationErrors: [],
          columnHidingRules: []);
    }

    private static BenchmarkReport CreateReport(BenchmarkCase benchmarkCase, string result)
    {
      var generateResult = GenerateResult.Success(ArtifactsPaths.Empty, []);
      var buildResult = BuildResult.Success(generateResult);
      var resultLines = result.Replace("\r", "").Split('\n');
      var executeResult = new ExecuteResult(true, 0, 0, resultLines.Where(r => !r.StartsWith("//")).ToArray(), resultLines.Where(r => r.StartsWith("//")).ToArray(), [], launchIndex: 0);
      return new BenchmarkReport(
        true,
        benchmarkCase,
        generateResult,
        buildResult,
        [executeResult],
        []);
    }

    [LongRunJob]
    public class MockBenchmarkClass
    {
      [Benchmark] public void Foo() { }

      [Benchmark] public void Bar() { }
    }
  }
}
