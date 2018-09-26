# RoadStatus
Tfl RoadStatus


# Build Instructions
Open Visual Studio 2017 and open this project by selecting from menu File->Open->Project/Solution and navigate to the project folder and select the solution file (RoadStatus.sln). Select Build -> Build Solution from menu or pressing F6.

# How to run the output
1)	DOS Command Prompt, VS Developer Command Prompt or Windows PowerShell can be used to run the output.
2)	Open any one of the Command Prompt mentioned in step 1 and navigate to the project folder which contains executable program which is RoadStatus.exe.
3)	Execute the application by the following command
    •	C:\..\RoadStatus\bin\Debug>RoadStatus.exe road - DOS and VS Developer Command
    •	C:\..\RoadStatus\bin\Debug> .\RoadStatus.exe road – PowerShell

     a)	This command displays output of the application. In the above command replace “road” with valid road name A2 as                         C:\..\RoadStatus\bin\Debug>RoadStatus.exe A2 for which output can be
        
        The status of the A2 is as follows
        	Road Status is Good
        	Road Status Description is No Exceptional Delays

     b)	Replace “road” with invalid road name A456 as C:\..\RoadStatus\bin\Debug> .\RoadStatus.exe A456 for which output can be
        
        A456 is not a valid road.

     c)	For empty input
      
        Input is invalid

     d)	In case of error
      
        Error: Description of error. More detail from server response.

 4)	Enter the following command to check return code of the application
      C:\..\RoadStatus\bin\Debug>echo %errorlevel% - DOS and VS Developer Command
      C:\..\RoadStatus\bin\Debug> echo $lastexitcode – PowerShell

      This command displays return code of the application
      0 – Successful output (For valid road)
      1 – Result not found for input (For invalid road)
      2 – Invalid input (Input cannot be parsed)
      4 - Server error/ Cannot establish connection error 


# To run tests
In Visual Studio, all test cases of Test project “TestRoadStatus” can be run by simply selecting Test->Run->All Tests 
from menu or pressing Ctrl + R + A. The outcome of all test results can be seen through Test Explorer in Visual Studio.

# Assumptions
Since the Console Application was mentioned to be simple in requirement, it is designed as simple. But it can be extended to support to handle other types of requests as well which I explained under future enhancements topic. 
Error handled with assumption of if in case of any authentication issue, json serialisation error or any other server connection issue. Also, relevant error description with server response (if any) will be as output. 

# Future enhancements
* This application can be extended with more SOLID principle to enable handling multiple types of API request through different class implementation using Interface. Category of API request can be determined by endpoint passed in URL, like road, bikepoint and line.

* API calls made based on endpoint with parameters and API credential using Dependency injection that selects relevant class implementations at runtime to handle each response with specific formation of output.

* Transform App.config by using SlowCheetah package for Debug/Release configuration is useful when deployment is automated through CI/CD like TeamCity.

* Include Mail server configuration in log4net by SmtpAppender to enable email notification of fatal error.
