





**<Project Sdk="Microsoft.NET.Sdk">**



&#x20; **<PropertyGroup>**

&#x20;   **<TargetFramework>net10.0</TargetFramework>**

&#x20;   **<LangVersion>latest</LangVersion>**

&#x20;   **<ImplicitUsings>enable</ImplicitUsings>**

&#x20;   **<Nullable>enable</Nullable>**

&#x20;   **<IsPackable>false</IsPackable>**

&#x20; **</PropertyGroup>**



&#x20; **<ItemGroup>**

&#x20;   **<PackageReference Include="coverlet.collector" Version="6.0.4" />**

&#x20;   **<PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.14.0" />**

&#x20;   **<PackageReference Include="NUnit" Version="4.3.2" />**

&#x20;   **<PackageReference Include="NUnit.Analyzers" Version="4.7.0" />**

&#x20;   **<PackageReference Include="NUnit3TestAdapter" Version="5.0.0" />**

&#x20; **</ItemGroup>**



&#x20; **<ItemGroup>**

&#x20;   **<Using Include="NUnit.Framework" />**

&#x20; **</ItemGroup>**



&#x20; **<ItemGroup>**

&#x20;   **<ProjectReference Include="..\\FeeSystem\\FeeSystem.csproj" />**

&#x20; **</ItemGroup>**



**</Project>**









**using NUnit.Framework;**

**using FeeSystem;**

**\[TestFixture]**

**public class FeeCalculatorTests**

**{**

&#x20;   **\[Test]**

&#x20;   **public void OutstandingBalance\_NoPayments\_ReturnsFullFee()**

&#x20;     **{**

&#x20;       **// Arrange**

&#x20;       **var calc = new FeeCalculator();**

&#x20;       **var payments = new List<decimal>();**

&#x20;       **// Act**

&#x20;       **var result = calc.OutstandingBalance(600m, payments);**

&#x20;       **// Assert**

&#x20;       **Assert.That(result, Is.EqualTo(600m));**

&#x20;      **}**







**// Test 2: One partial payment of 200 leaves a balance of 400.**

**\[Test]**

**public void OutstandingBalance\_OnePartialPayment\_ReturnsCorrectBalance()**

&#x20;   **{**

&#x20;   **// Arrange** 

&#x20;   **var calc = new FeeCalculator(); //Create the fee calculator object.**

&#x20;   **var payments = new List<decimal> { 200m }; //Student paid 200 kina.**

&#x20;   **// Act**

&#x20;   **var result = calc.OutstandingBalance(600m, payments);//Calculate the outstanding balance.**

&#x20;   **// Assert**

&#x20;       **Assert.That(result, Is.EqualTo(400m)); //Balance should be 400 kina.**

&#x20;   **}**







**// Test 3: Multiple instalments totaling 500 leave a balance of 100.**

**\[Test]**

**public void OutstandingBalance\_MultipleInstallments\_ReturnsCorrectBalance()**

&#x20;    **{**

&#x20;     **// Arrange** 

&#x20;     **var calc = new FeeCalculator();// Create calculator object.**

&#x20;       **var payments = new List<decimal> { 200m, 200m, 100m };// Three instalment payments.**

&#x20;     **// Act**

&#x20;       **var result = calc.OutstandingBalance(600m, payments);// Calculate balance.**

&#x20;    **// Assert**

&#x20;       **Assert.That(result, Is.EqualTo(100m));// Balance should be 100.**

&#x20;   **}**







**// Test 4: Fee fully paid, so balance should be zero.**

**\[Test]**

**public void OutstandingBalance\_FullyPaid\_ReturnsZero()**

&#x20;      **{**

&#x20;      **// Arrange**

&#x20;      **var calc = new FeeCalculator();// Create calculator object.**

&#x20;      **var payments = new List<decimal> { 600m };// Full fee paid.**

&#x20;      **// Act**

&#x20;       **var result = calc.OutstandingBalance(600m, payments);// Calculate balance.**

&#x20;     **// Assert**

&#x20;       **Assert.That(result, Is.EqualTo(0m));// Balance should be zero.**

&#x20;   **}**





**// Test 5: Overpayment should result in a negative balance.**

**\[Test]**

**public void OutstandingBalance\_Overpaid\_ReturnsNegativeBalance()**

&#x20;    **{**

&#x20;     **// Arrange**

&#x20;     **var calc = new FeeCalculator();// Create calculator object.**

&#x20;     **var payments = new List<decimal> { 700m };// Student paid more than required.**

&#x20;    **// Act**

&#x20;    **var result = calc.OutstandingBalance(600m, payments);// Calculate balance.**

&#x20;    **// Assert**

&#x20;       **Assert.That(result, Is.EqualTo(-100m)); // Balance should be -100.**

&#x20;   **}**







**// Test 6: Negative fee should throw an ArgumentException.**

**\[Test]**

**public void OutstandingBalance\_NegativeFee\_ThrowsArgumentException()**

&#x20;       **{**

&#x20;       **// Arrange**

&#x20;      **var calc = new FeeCalculator();// Create calculator object.**

&#x20;      **var payments = new List<decimal>();// Empty payment list.**

&#x20;       **// Act and Assert**

&#x20;       **Assert.That(**



&#x20;       **() => calc.OutstandingBalance(-1m, payments),**

&#x20;      **Throws.ArgumentException);// Exception should be thrown.**

&#x20;   **}**





&#x20;**// Test 7: Paying exactly half the fee clears the student for exams.**

&#x20;**\[Test]**

**public void IsClearedForExams\_ExactlyHalfPaid\_ReturnsTrue()**

&#x20;      **{**



&#x20;       **// Arrange**

&#x20;      **var calc = new FeeCalculator();// create calculator object.**

&#x20;       **var payments = new List<decimal> { 300m };// Half the fee has been paid.**

&#x20;       **// Act**

&#x20;       **var result = calc.IsClearedForExams(600m, payments);// Check clearance status.**

&#x20;      **// Assert**

&#x20;       **Assert.That(result, Is.True);//sudent should be cleared.**

&#x20;   **}**





**// Test 8: One toea below half the fee does not clear the student for exams.**

**\[Test]**

**public void IsClearedForExams\_OneToeaUnderHalf\_ReturnsFalse()**

&#x20;   **{**

&#x20;   **// Arrange**

&#x20;   **var calc = new FeeCalculator();// create calculator object.**

&#x20;   **var payments = new List<decimal> { 299.99m };//slightly less than half paid.**

&#x20;   **// Act**

&#x20;   **var result = calc.IsClearedForExams(600m, payments);// Check clearance status.**

&#x20;  **//Assert**

&#x20;       **Assert.That(result, Is.False); // Student should not be cleared.**

&#x20;   **}**





**}**











**using System;**

**using System.Collections.Generic;**

**using System.Linq;**

**namespace FeeSystem;**



**public class FeeCalculator**

**{**

&#x20;   **// Returns what the student still owes for the term.**

&#x20;   **public decimal OutstandingBalance(**

&#x20;   **decimal termFee, IEnumerable<decimal> payments)**

&#x20;   **{**

&#x20;       **if (termFee < 0)**

&#x20;           **throw new ArgumentException("Fee cannot be negative");**

&#x20;       **var paid = payments.Sum();**

&#x20;       **return termFee - paid;**

&#x20;   **}**

&#x20;   **// Rule: must pay at least half the term fee to sit exams.**

&#x20;   **public bool IsClearedForExams(**

&#x20;   **decimal termFee, IEnumerable<decimal> payments)**

&#x20;   **{**

&#x20;       **var paid = payments.Sum();**

&#x20;       **return paid >= termFee / 2;**

&#x20;   **}**

**}**



