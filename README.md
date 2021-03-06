# RoadStatus
Application to display Tfl Road Status with severity descriptions.


# Build Instructions
Open Visual Studio 2017 and open this project by selecting from menu File->Open->Project/Solution. 

Navigate to the project folder and select the solution file (RoadStatus.sln). 

<b>Please add your ApiId and ApiKey under appSettings in config file of RoadStatus project ..\RoadStatus\App.config.</b>

Select Build -> Build Solution from menu.


# How to run the output
1)	DOS Command Prompt, VS Developer Command Prompt or Windows PowerShell can be used to run the output.
2)	Open any one of the Command Prompts mentioned in step 1 and navigate to the project folder which contains executable program - <b>RoadStatus.exe.</b>
3)	Execute the application by the following command

    * C:\..\RoadStatus\bin\Debug>RoadStatus.exe road - DOS and VS Developer Command Prompt
    * C:\..\RoadStatus\bin\Debug> .\RoadStatus.exe road – PowerShell

     a)	This command displays the output of the application. In the above command replace “road” with valid road name A2 as                     follows 
     
        C:\..\RoadStatus\bin\Debug>RoadStatus.exe A2 
        
        * Output         
          The status of the A2 is as follows
        	   Road Status is Good
        	   Road Status Description is No Exceptional Delays

     b)	Replace “road” with invalid road name A456 as follows
     
         C:\..\RoadStatus\bin\Debug> .\RoadStatus.exe A456
         
         * Output          
           A456 is not a valid road.

     c)	For empty input
         
         C:\..\RoadStatus\bin\Debug> .\RoadStatus.exe
         
         * Output          
           Input is invalid

     d)	In case of error
     
         * Output          
           Error: Description of error. Server response if any.

 4)	Enter the following command to check return code of the application
      
         C:\..\RoadStatus\bin\Debug>echo %errorlevel% - DOS and VS Developer Command Prompt
         C:\..\RoadStatus\bin\Debug> echo $lastexitcode – PowerShell

      This command displays return code of the application
    
         0 – Successful output (For valid road)
         1 – Result not found for input (For invalid road)
         2 – Invalid input (Input cannot be parsed)
         4 - Server error/ Cannot establish connection error 


# To Run Tests
In Visual Studio, all test cases of Test project “TestRoadStatus” can be run by simply selecting Test->Run->All Tests 
from menu. The outcome of all test results can be seen through Test Explorer in Visual Studio.

<b>Please add your ApiId and ApiKey under appSettings in config file of test project ..\TestRoadStatus\App.config before running the tests.</b>


# Assumptions
* Since the task requirement is for a simple command line client, the design of the application has been kept simple. But it can be extended to support and handle other types of requests as well which are explained under future enhancements below. 

* Error handling has been done in case of any authentication issue, json serialisation error or any other server connection issue. Also, relevant error description with server response (if any) will be returned as output. 


# Future Enhancements
* This application can be extended with more SOLID principles to enable handling multiple types of API request through different class implementation using Interface. Category of API request can be determined by endpoint passed in URL, like road, bikepoint and line.

* API calls made based on endpoint with parameters and API credential using Dependency injection that selects relevant class implementations at runtime to handle each response with specific formation of output.

* Transform App.config by using SlowCheetah package for Debug/Release configuration is useful when deployment is automated through CI/CD like TeamCity.

* Include Mail server configuration in log4net by SmtpAppender to enable email notification of fatal error.

# Notes
* As per instruction, ApiId and ApiKey have been removed from the config files.
