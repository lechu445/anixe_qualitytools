# Change Log

## v1.5.2
* dropped support for .NET below .NET 8.0
* updated dependencies
* reduced a string allocation in AssertHelper.AreXmlDocumentsEqual and AssertHelper.AreJsonObjectsSemanticallyEqual

## v1.5.0
* added BenchmarkRunner constructor parameter being config that allows to enable submenu for methods in benchmark class

## v1.4.0
* Added excludePaths param to AreJsonObjectsSemanticallyEqual

## v1.3.1
* Updated dependencies

## v1.2.4
* Add LoadTestFixture based on reflection for parameterless loading examples

## v1.2.3
* Add LoadTestFixture based on reflection for parameterless loading examples

## 1.2.2
* Add p field to graylog export

## 1.2.1
* Fix cannot use custom config in BenchmarkRunner in "all" mode

## 1.2.0
* Added GraylogExporter
* Removed Excel analyse file generating after run BenchmarkRunner
* Bump BenchmarkDotNet version to 0.11.5