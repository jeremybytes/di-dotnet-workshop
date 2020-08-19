Dependency Injection in .NET [Full-Day Workshop]
============================
Loosely coupled code is easier to maintain, extend, and test. Dependency Injection (DI) help us get there. In this workshop, we'll see how interfaces can add "seams" to our code that makes it more flexible and maintainable. From there, we'll dig into loose coupling with Dependency Injection. DI doesn't have to be complicated. With just a few simple changes to our constructors or properties, we can have code that is easy to extend and test. After laying a good foundation, we'll take a closer look by diving into various DI patterns (such as constructor injection and property injection) as well as other patterns that help us handle interception and optional dependencies. Along the way, we'll see how DI helps us adhere to the SOLID principles in our code. We'll also we'll look at common stumbling blocks like dealing with constructor over-injection, managing static dependencies, and handling disposable dependencies. Throughout the day, we'll go hands-on with labs to give you a chance to put the concepts into action. If you're a C# developer who wants to get better with concepts like abstraction, loose coupling, extensibility, and unit testing, then this is the workshop for you.  

Prerequisites
-------------
To get the most out of the workshop, you should have an understanding of the basics of C# and object oriented programming (classes, inheritance, methods, and properties). No prior experience with dependency injection is necessary. Hardware & Software To participate in the hands-on portion, you will need a computer (Windows, macOS, or Linux) with the following installed:  
* **.NET Core 3.1 SDK**  
[https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)  
The .NET Core SDK (Software Development Kit) allows you to build .NET applications.  
* **Visual Studio Code**  
[https://code.visualstudio.com/download](https://code.visualstudio.com/download)  
This is a great all-around editor.  
* **VS Code C# Extension**  
[https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)  
This extension to Visual Studio Code adds syntax highlighing and code completion for C#.  
* **VS Code Live Share Extension Pack**  
[https://marketplace.visualstudio.com/items?itemName=MS-vsliveshare.vsliveshare-pack](https://marketplace.visualstudio.com/items?itemName=MS-vsliveshare.vsliveshare-pack)  
This extension to Visual Studio Code will allow you to connect to my development environment where we can share code and develop together.  

As an alternative, you can use **Visual Studio 2019** (any edition). No additional extensions are required. Live Share is built in to current versions of Visual Studio.  

Labs
----
These are the hands-on portions of the workshop. Labs can be completed with Visual Studio Code or Visual Studio 2019. All labs run on Windows, macOS, and Linux. Each lab consists of the following:

* **Labxx-Instructions** (Markdown)  
A markdown file containing the lab instructions. This includes the scenario, a set of goals, and step-by-step instructions.  
This can be viewed in on GitHub or in Visual Studio Code (just click the "Open Preview to the Side" button in the upper right corner).

* **Starter** (Folder)  
This folder contains the starting code for the lab.

* **Completed** (Folder)  
This folder contains the completed solution. If at any time, you get stuck during the lab, you can check this folder for a solution.

Other Demos
-----------  
The other folders contain samples that are shown during the lecture portions. This code is runnable with Visual Studio Code or Visual Studio 2019; however, these samples are Windows-only. The demos are as follows:

1. **Overview** MainDemo-Basics  
An overview of the what and why of dependency injection. Breaking tight coupling allows changing the data source, adding client-side caching, and making unit tests easier to implement. Example shows constructor injection.  
*PeopleViewer.Presentation/PeopleViewModel*  
*PeopleViewer/MainWindow.xaml.cs*  
*PeopleViewer/App.xaml.cs*

2. **Read-only Properties/Fields** MainDemo-Basics  
Shows the use of read-only properties and fields (set only on construction).  
*PeopleViewer.Presentation/PeopleViewModel*  
*PeopleViewer/MainWindow.xaml.cs*

3. **Guard Clauses** MainDemo-Basics  
Setting up guard clauses to make sure that proper values are provided for constructor parameters.  
*PeopleViewer.Presentation/PeopleViewModel*  
*PeopleViewer/MainWindow.xaml.cs*

4. **Constructor Injection** MainDemo-Basics  
Review of constructor injection (from #1).  
*PeopleViewer.Presentation/PeopleViewModel*  
*PeopleViewer/MainWindow.xaml.cs*  
*PeopleViewer/App.xaml.cs*  

5. **Property Injection** MainDemo-Basics  
Using property injection to have a good default value that can be swapped out for easier unit testing.  
*PeopleViewer.CSV/CSVReader.cs*  
*PersonReader.CSV.Tests*  

6. **Method Injection** MethodInjection
Using method injection to have potentially different behavior on each call of a method.  
*PeopleApplication/App.xaml.cs*  
*PeopleLibrary*  

7. **Decorators** MainDemo-Extended  
A look at adding functionality (such as caching or retry) to existing objects.  
*PersonReader.Decorators*  
*PeopleViewer/App.xaml.cs*  

8. **Static Dependency** StaticDependencies  
Dealing with statics by wrapping them in another object that can be injected and controlled for unit testing.  
*HouseControl.Library/Schedules/ITimeProvider.cs*  
*HouseControl.Library/Schedules/CurrentTimeProvider.cs*  
*HouseControl.Library.Tests*  

9. **Proxy** MainDemo-Extended  
Handling IDisposable by wrapping an object in a proxy.  
*PersonReader.SQL/SQLReader.cs*  
*PersonReader.SQL/SQLReaderProxy.cs*  

10. **.NET Core Container** MainDemo-Extended  
Looking at the built-in .NET Core dependency injection container.  
*PeopleService/Models/HardCodedPeopleProvider.cs*  
*PeopleService/Controllers/PeopleController.cs*  
*Startup.cs*  

11. **Ninject (Collection)** MethodInjection  
Registering collections of dependencies and resolving them with the Ninject dependency injection container.  
*PeopleApplication/App.xaml.cs*  

12. **Ninject (Auto-Registration)** MethodInjection  
Using reflection to auto-register types in assemblies with Ninject.  
*PeopleApplication/App.xaml.cs*  

13. **Autofac (General)** MainDemo-Basics  
Constructor injection using the Autofac dependency injection container.
*PeopleViewer.Autofac/App.xaml.cs*  

14. **Autofac (Decorator)** MainDemo-Basics  
Registering a decorator using Autofac.  
*PeopleViewer.Autofac/App.xaml.cs*  

15. **Autofac (Late Binding)** MainDemo-Basics  
Using Autofac to load dependencies at runtime based on configuration. This allows for dependencies to be swapped out without recompiling the application.  
*PeopleViewer.Autofac.LateBinding/App.xaml.cs*  
*PeopleViewer.Autofac.LateBinding/autofac.json*  

16. **Configuration Strings** MainDemo-Extended  
Handling configuration strings with a container can be tricky. This example shows how we can wrap a string in a custom type to make registering easier (this uses Ninject).  
*PersonReader.Service/ServiceReaderUri.cs*  
*PeopleViewer/App.xaml.cs*  

Additional Resources
--------------------
Links to articles, videos, and additional code samples:  
* [DI Why? Getting a Grip on Dependency Injection](http://www.jeremybytes.com/Demos.aspx#DI)   
* [Diving Deeper into Dependency Injection](http://www.jeremybytes.com/Demos.aspx#MoreDI)  

For more information, visit [jeremybytes.com](http://www.jeremybytes.com).