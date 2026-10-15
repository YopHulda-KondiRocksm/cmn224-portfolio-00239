&#x20;**CMN224 / CMP224 Software Engineering**

&#x20;**Week 04 – Unit Testing Workshop (NUnit)**



&#x20;**Project Overview**



This project was developed as part of the Week 04 Unit Testing Workshop for CMN224 / CMP224 Software Engineering. The purpose of this workshop is to demonstrate the application of software verification and validation through automated unit testing.



The project implements a simple fee management class called "FeeCalculator", which provides functionality for calculating a student's outstanding fee balance and determining whether a student is eligible to sit examinations based on fee payments. A comprehensive NUnit test suite has been developed to verify that the class behaves correctly under normal, boundary, and error conditions.





**Project Structure**



The project consists of two .NET projects located within the week04 directory. The "FeeSystem" project contains the application code under test, including the `FeeCalculator` class and its methods. The "FeeSystem.Tests" project contains the NUnit test suite used to verify the functionality of the FeeCalculator class. The test project references the FeeSystem project, allowing automated tests to be executed against the application code. Together, these projects demonstrate how unit testing can be used to validate software functionality and detect defects before deployment.



**Software Requirements**



Before building and running this project, ensure that the following software is installed on the system:



\- .NET SDK 10.0 or later

\- Git Bash or Command Prompt

\- Git (optional for version control)





&#x20;**Running the Unit Tests**



To execute the NUnit test suite, open Git "Bash" and navigate to the Week 04 directory:



cd Documents

cd cmn224-portfolio-202600239

cd week04





Run the tests using the following command:





dotnet test FeeSystem.Tests





The .NET test runner will automatically:



1\. Build the FeeSystem project.

2\. Build the FeeSystem.Tests project.

3\. Execute all available unit tests.

4\. Display the test results in the terminal.



A successful test run should produce output similar to the following:



**Test summary:**

Total: 8

Failed: 0

Succeeded: 8

Skipped: 0







**AI Declaration**



Microsoft Copilot was used to assist with the development of the source code for the FeeCalculator class, provide guidance on the creation of NUnit unit test cases, and support the drafting and refinement of the README documentation.



