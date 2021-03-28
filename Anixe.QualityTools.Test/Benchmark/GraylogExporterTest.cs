﻿using System.IO;
using System.Text;
using Xunit;
using Anixe.QualityTools.Benchmark;
using BenchmarkDotNet.Loggers;

namespace Anixe.QualityTools.Test.Benchmark
{
  public class GraylogExporterTest
  {
    [Fact]
    public void Should_Export()
    {
      var consoleOutput = new StringBuilder();
      var consoleLogger = new SimpleConsoleLogger(consoleOutput);
      var summary = MockFactory.CreateSummary(typeof(MockFactory.MockBenchmarkClass));
      var subject = new GraylogExporter("some_product", "some_app", "somehost.com", 5558) { HostName = "SomeHost", Enabled = false };
      subject.ExportToFiles(summary, consoleLogger);
      Assert.Equal(File.ReadAllText("Benchmark/expected_console_output.txt"), consoleOutput.ToString(), ignoreLineEndingDifferences: true);
    }

    private class SimpleConsoleLogger : ILogger
    {
      private readonly StringBuilder output;

      public string Id => nameof(SimpleConsoleLogger);

      public int Priority => 0;

      public SimpleConsoleLogger(StringBuilder output)
      {
        this.output = output;
      }

      public void Write(LogKind logKind, string text)
      {
        this.output.Append(text);
      }

      public void Flush() { }

      public void WriteLine() => output.AppendLine();

      public void WriteLine(LogKind logKind, string text) => output.AppendLine(text);
    }
  }
}
