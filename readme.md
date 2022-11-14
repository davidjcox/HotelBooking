# Hotel Booking test project

The Hotel Booking test project uses SpecFlow and Selenium to evaluate functionality of the [Hotel booking form](http://hotel-test.equalexperts.io). 

***

#Getting Started

This test project is developed in C# targeting .Net Core, but is compatible with .Net Standard. It was developed and tested on Windows 10 with latest 
versions of the three major browsers: Chrome, Firefox, and Edge. The best experience is expected to be in that environment. Selenium depends on browser
drivers to manipulate the browser automation engines. This project employs WebDriverManager to manage driver versioning. It will download and configure
driver versions that match browser versions in the execution environment when it's possible to determine, otherwise it will download and configure the
latest driver version.

This test project is designed to be a self-contained deployment, so that it does not require installation, is not dependent on any particular deployment
location in the filesystem, and operates relative to itself. To execute it manually, save it to a location, open it in Visual Studio, and execute it
according to the following instructions.

#Build and Test

1. Open the project solution in Visual Studio
2. Right-click on the solution in Solution Explorer pane to open the context menu and select the **Restore NuGet Packages** option
	* it may not be necessary for the packages to be restored
	* package restore progress will will be communicated in the Output pane, even if restore is not needed
3. Build the solution by selecting the **Build Solution** option under the Visual Studio Build application menu
4. If it is not displayed, display the **Test Explorer** pane by selecting its option under the Visual Studio **View** application menu
5. In the **Test Explorer** pane, run tests by clicking a test run button
	* click the _Run All Tests In View_ button to run all tests
	* highlight a test grouping and click the _Run_ button to run tests in that group
	* highlight a single test in and click the _Run_ button to run that single test
6. Test progress and results will display in the **Test Explorer** pane
	* expand the tests in the pane to see individual test results
7. After tests complete, a test report will be generated in the project **TestReports** folder
	* switch to the **Solution Explorer** pane
	* expand the **TestReports** folder
	* right-click either the **index.html** or the **dashboard.html** file to open the context menu and select the **Open Containing Folder** option
	* right-click either file in file manager and open with browser of choice
	* it is possible to switch between the Dashboard and Tests by clicking the corresponding link in the upper left of either page