﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace HotelBooking.FeatureFiles
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Book a hotel room")]
    public partial class BookAHotelRoomFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "HotelBooking.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "FeatureFiles", "Book a hotel room", @"	The Hotel booking form website accepts valid (complete and correct) bookings for a fictional hotel.
	It does not provide feedback on what constitutes a valid booking. It only adds a booking if its criteria are met.
	The user can infer certain requirements from experience: names must contain letters and a set of accepted special
	characters, prices must be decimal, booking dates must only be from present day into the future, and that check-in
	must occur before check-out", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create a valid hotel booking")]
        public void CreateAValidHotelBooking()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a valid hotel booking", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 10
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 11
 testRunner.Given("the user opens the Hotel booking form", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "Firstname",
                            "Surname",
                            "Price",
                            "Deposit",
                            "Checkin",
                            "Checkout"});
                table1.AddRow(new string[] {
                            "Charles",
                            "Xavier",
                            "357.9",
                            "true",
                            "today_+12_days",
                            "today_+17_days"});
#line 12
 testRunner.When("the user creates a valid booking", ((string)(null)), table1, "When ");
#line hidden
#line 15
 testRunner.Then("the booking should be added to the booking listing", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete a valid hotel booking")]
        public void DeleteAValidHotelBooking()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a valid hotel booking", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 18
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 19
 testRunner.Given("the user opens the Hotel booking form", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "Firstname",
                            "Surname",
                            "Price",
                            "Deposit",
                            "Checkin",
                            "Checkout"});
                table2.AddRow(new string[] {
                            "Max",
                            "Eisenhardt",
                            "753.1",
                            "false",
                            "today_+2_days",
                            "today_+7_days"});
#line 20
 testRunner.When("the user creates a valid booking", ((string)(null)), table2, "When ");
#line hidden
#line 23
 testRunner.And("the user deletes that newly created booking", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 24
 testRunner.Then("the newly-created booking should be removed from the booking listing", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create multiple valid hotel bookings")]
        public void CreateMultipleValidHotelBookings()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create multiple valid hotel bookings", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 27
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 28
 testRunner.Given("the user opens the Hotel booking form", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "Firstname",
                            "Surname",
                            "Price",
                            "Deposit",
                            "Checkin",
                            "Checkout"});
                table3.AddRow(new string[] {
                            "Charles",
                            "Xavier",
                            "357.9",
                            "true",
                            "today_+12_days",
                            "today_+17_days"});
                table3.AddRow(new string[] {
                            "Max",
                            "Eisenhardt",
                            "753.1",
                            "false",
                            "today_+2_days",
                            "today_+7_days"});
                table3.AddRow(new string[] {
                            "James",
                            "Howlett",
                            "951",
                            "true",
                            "today_+32_days",
                            "today_+39_days"});
                table3.AddRow(new string[] {
                            "Scott",
                            "Summers",
                            "159",
                            "false",
                            "today_+0_days",
                            "today_+5_days"});
#line 29
 testRunner.When("the user creates multiple valid bookings", ((string)(null)), table3, "When ");
#line hidden
#line 35
 testRunner.Then("all newly-created bookings should be added to the booking listing", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete multiple valid hotel bookings")]
        public void DeleteMultipleValidHotelBookings()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete multiple valid hotel bookings", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 38
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 39
 testRunner.Given("the user opens the Hotel booking form", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "Firstname",
                            "Surname",
                            "Price",
                            "Deposit",
                            "Checkin",
                            "Checkout"});
                table4.AddRow(new string[] {
                            "Charles",
                            "Xavier",
                            "357.9",
                            "false",
                            "today_+12_days",
                            "today_+17_days"});
                table4.AddRow(new string[] {
                            "Max",
                            "Eisenhardt",
                            "753.1",
                            "true",
                            "today_+2_days",
                            "today_+7_days"});
                table4.AddRow(new string[] {
                            "James",
                            "Howlett",
                            "951",
                            "false",
                            "today_+32_days",
                            "today_+39_days"});
                table4.AddRow(new string[] {
                            "Scott",
                            "Summers",
                            "159",
                            "true",
                            "today_+0_days",
                            "today_+5_days"});
#line 40
 testRunner.When("the user creates multiple valid bookings", ((string)(null)), table4, "When ");
#line hidden
#line 46
 testRunner.And("the user deletes those newly-created valid bookings", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 47
 testRunner.Then("all newly-created bookings should be removed from the booking listing", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete the first of a block of multiple newly-created valid hotel bookings")]
        public void DeleteTheFirstOfABlockOfMultipleNewly_CreatedValidHotelBookings()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete the first of a block of multiple newly-created valid hotel bookings", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 50
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 51
 testRunner.Given("the user opens the Hotel booking form", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "Firstname",
                            "Surname",
                            "Price",
                            "Deposit",
                            "Checkin",
                            "Checkout"});
                table5.AddRow(new string[] {
                            "Charles",
                            "Xavier",
                            "357.9",
                            "true",
                            "today_+12_days",
                            "today_+17_days"});
                table5.AddRow(new string[] {
                            "Max",
                            "Eisenhardt",
                            "753.1",
                            "true",
                            "today_+2_days",
                            "today_+7_days"});
                table5.AddRow(new string[] {
                            "James",
                            "Howlett",
                            "951",
                            "flase",
                            "today_+32_days",
                            "today_+39_days"});
                table5.AddRow(new string[] {
                            "Scott",
                            "Summers",
                            "159",
                            "false",
                            "today_+0_days",
                            "today_+5_days"});
#line 52
 testRunner.When("the user creates multiple valid bookings", ((string)(null)), table5, "When ");
#line hidden
#line 58
 testRunner.And("the user deletes the first booking of multiple newly-created bookings", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 59
 testRunner.Then("the first booking of the multiple newly-created bookings should be removed from t" +
                        "he booking listing", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete a booking in the midst of a block of multiple newly-created valid hotel bo" +
            "okings")]
        public void DeleteABookingInTheMidstOfABlockOfMultipleNewly_CreatedValidHotelBookings()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a booking in the midst of a block of multiple newly-created valid hotel bo" +
                    "okings", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 62
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 63
 testRunner.Given("the user opens the Hotel booking form", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                            "Firstname",
                            "Surname",
                            "Price",
                            "Deposit",
                            "Checkin",
                            "Checkout"});
                table6.AddRow(new string[] {
                            "Charles",
                            "Xavier",
                            "357.9",
                            "false",
                            "today_+12_days",
                            "today_+17_days"});
                table6.AddRow(new string[] {
                            "Max",
                            "Eisenhardt",
                            "753.1",
                            "false",
                            "today_+2_days",
                            "today_+7_days"});
                table6.AddRow(new string[] {
                            "James",
                            "Howlett",
                            "951",
                            "true",
                            "today_+32_days",
                            "today_+39_days"});
                table6.AddRow(new string[] {
                            "Scott",
                            "Summers",
                            "159",
                            "true",
                            "today_+0_days",
                            "today_+5_days"});
#line 64
 testRunner.When("the user creates multiple valid bookings", ((string)(null)), table6, "When ");
#line hidden
#line 70
 testRunner.And("the user deletes one of the bookings in the midst of multiple newly-created booki" +
                        "ngs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 71
 testRunner.Then("the booking in the midst of the multiple newly-created bookings should be removed" +
                        " from the booking listing", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete the last of a block of multiple newly-created valid hotel bookings")]
        public void DeleteTheLastOfABlockOfMultipleNewly_CreatedValidHotelBookings()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete the last of a block of multiple newly-created valid hotel bookings", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 74
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 75
 testRunner.Given("the user opens the Hotel booking form", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                            "Firstname",
                            "Surname",
                            "Price",
                            "Deposit",
                            "Checkin",
                            "Checkout"});
                table7.AddRow(new string[] {
                            "Charles",
                            "Xavier",
                            "357.9",
                            "true",
                            "today_+12_days",
                            "today_+17_days"});
                table7.AddRow(new string[] {
                            "Max",
                            "Eisenhardt",
                            "753.1",
                            "false",
                            "today_+2_days",
                            "today_+7_days"});
                table7.AddRow(new string[] {
                            "James",
                            "Howlett",
                            "951",
                            "flase",
                            "today_+32_days",
                            "today_+39_days"});
                table7.AddRow(new string[] {
                            "Scott",
                            "Summers",
                            "159",
                            "true",
                            "today_+0_days",
                            "today_+5_days"});
#line 76
 testRunner.When("the user creates multiple valid bookings", ((string)(null)), table7, "When ");
#line hidden
#line 82
 testRunner.And("the user deletes the last booking of multiple newly-created bookings", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 83
 testRunner.Then("the last booking in the multiple newly-created bookings should be removed from th" +
                        "e booking listing", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create multiple duplicate valid hotel bookings")]
        public void CreateMultipleDuplicateValidHotelBookings()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create multiple duplicate valid hotel bookings", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 86
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 87
 testRunner.Given("the user opens the Hotel booking form", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                            "Firstname",
                            "Surname",
                            "Price",
                            "Deposit",
                            "Checkin",
                            "Checkout"});
                table8.AddRow(new string[] {
                            "Remy Etienne",
                            "LeBeau",
                            "9999",
                            "true",
                            "today_+212_days",
                            "today_+232_days"});
#line 88
 testRunner.When("the user creates multiple duplicate valid bookings", ((string)(null)), table8, "When ");
#line hidden
#line 91
 testRunner.Then("all newly-created duplicate bookings should be added to the booking listing", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete multiple duplicate valid hotel bookings")]
        public void DeleteMultipleDuplicateValidHotelBookings()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete multiple duplicate valid hotel bookings", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 94
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 95
 testRunner.Given("the user opens the Hotel booking form", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                            "Firstname",
                            "Surname",
                            "Price",
                            "Deposit",
                            "Checkin",
                            "Checkout"});
                table9.AddRow(new string[] {
                            "Remy Etienne",
                            "LeBeau",
                            "9999",
                            "false",
                            "today_+500_days",
                            "today_+600_days"});
#line 96
 testRunner.When("the user creates multiple duplicate valid bookings", ((string)(null)), table9, "When ");
#line hidden
#line 99
 testRunner.And("the user deletes those newly-created duplicate valid bookings", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 100
 testRunner.Then("all newly-created duplicate bookings should be removed from the booking listing", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
