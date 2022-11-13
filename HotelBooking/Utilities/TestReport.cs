using System.Collections.Generic;

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using ExtentReport = AventStack.ExtentReports.ExtentReports;

using HotelBooking.TestObjects;


namespace HotelBooking.Utilities
{
    internal static class TestReport
    {
        internal static ExtentReport extentReport;
        internal static ExtentTest extentBDDTest;
        internal static ExtentTest extentBDDTestScenario;
        internal static ExtentTest extentBDDTestScenarioStep;

        internal static void InitializeTestReport()
        {
            extentReport = new ExtentReport();

            ExtentHtmlReporter extentHtmlReporter = new ExtentHtmlReporter(InputOutput.GetTestReportName());

            extentHtmlReporter.Config.ReportName = @"Hotel Booking Form Test Report";
            extentHtmlReporter.Config.DocumentTitle = @"Hotel Booking Form Test Report";
            extentHtmlReporter.Config.Encoding = @"UTF-8";

            extentReport.AttachReporter(extentHtmlReporter);
        }

        internal static void CreateTest(FeatureContext _featureContext)
        {
            extentBDDTest = extentReport.CreateTest<Feature>(_featureContext.FeatureInfo.Title, _featureContext.FeatureInfo.Description);
        }

        internal static void AddScenarioToTest(ScenarioContext _scenarioContext)
        {
            extentBDDTestScenario = extentBDDTest.CreateNode<Scenario>($"{_scenarioContext.ScenarioInfo.Title} [expand step results]");
        }

        internal static void AddScenarioStepToTest(ScenarioContext _scenarioContext)
        {
            switch (_scenarioContext.StepContext.StepInfo.StepDefinitionType)
            {
                case StepDefinitionType.Given:
                    extentBDDTestScenarioStep = extentBDDTestScenario.CreateNode<Given>($"Given: {_scenarioContext.StepContext.StepInfo.Text}");
                    return;
                case StepDefinitionType.When:
                    extentBDDTestScenarioStep = extentBDDTestScenario.CreateNode<When>($"When: {_scenarioContext.StepContext.StepInfo.Text}");
                    return;
                case StepDefinitionType.Then:
                    extentBDDTestScenarioStep = extentBDDTestScenario.CreateNode<Then>($"Then: {_scenarioContext.StepContext.StepInfo.Text}");
                    return;
                default:
                    extentBDDTestScenarioStep = extentBDDTestScenario.CreateNode<Given>($"Given: {_scenarioContext.StepContext.StepInfo.Text}");
                    return;
            }
        }

        internal static void AddScenarioStepTestResultToTest(ScenarioContext _scenarioContext)
        {
            switch (_scenarioContext.StepContext.Status)
            {
                case ScenarioExecutionStatus.OK:
                    extentBDDTestScenarioStep.Pass("PASS");
                    return;
                case ScenarioExecutionStatus.Skipped:
                    extentBDDTestScenarioStep.Skip("SKIPPED");
                    return;
                case ScenarioExecutionStatus.TestError:
                    extentBDDTestScenarioStep.Fail("FAIL");
                    return;
                case ScenarioExecutionStatus.BindingError:
                    extentBDDTestScenarioStep.Error("Binding Error");
                    return;
                case ScenarioExecutionStatus.UndefinedStep:
                    extentBDDTestScenarioStep.Error("Undefined Step");
                    return;
                case ScenarioExecutionStatus.StepDefinitionPending:
                    extentBDDTestScenarioStep.Info("No Step Definition Implemented");
                    return;
                default:
                    extentBDDTestScenarioStep.Error("Ambiguous Result");
                    return;
            }
        }

        internal static void AddTestResultToTest(ScenarioContext _scenarioContext)
        {
            switch (_scenarioContext.ScenarioExecutionStatus)
            {
                case ScenarioExecutionStatus.OK:
                    extentBDDTest.Pass("PASS");
                    return;
                case ScenarioExecutionStatus.Skipped:
                    extentBDDTest.Skip("SKIPPED");
                    return;
                case ScenarioExecutionStatus.TestError:
                    extentBDDTest.Fail("FAIL");
                    return;
                case ScenarioExecutionStatus.BindingError:
                    extentBDDTest.Error("Binding Error");
                    return;
                case ScenarioExecutionStatus.UndefinedStep:
                    extentBDDTest.Error("Undefined Step");
                    return;
                case ScenarioExecutionStatus.StepDefinitionPending:
                    extentBDDTest.Info("No Step Definition Implemented");
                    return;
                default:
                    extentBDDTest.Error("Ambiguous Result");
                    return;
            }
        }

        internal static void FinalizeTestReport()
        {
            extentReport.Flush();
        }
    }
}
