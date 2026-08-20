using NUnit.Framework;
using FeeSystem;
[TestFixture]
public class FeeCalculatorTests
{
    [Test]
    public void OutstandingBalance_NoPayments_ReturnsFullFee()
      {
        // Arrange
        var calc = new FeeCalculator();
        var payments = new List<decimal>();
        // Act
        var result = calc.OutstandingBalance(600m, payments);
        // Assert
        Assert.That(result, Is.EqualTo(600m));
       }



// Test 2: One partial payment of 200 leaves a balance of 400.
[Test]
public void OutstandingBalance_OnePartialPayment_ReturnsCorrectBalance()
    {
    // Arrange 
    var calc = new FeeCalculator(); //Create the fee calculator object.
    var payments = new List<decimal> { 200m }; //Student paid 200 kina.
    // Act
    var result = calc.OutstandingBalance(600m, payments);//Calculate the outstanding balance.
    // Assert
        Assert.That(result, Is.EqualTo(400m)); //Balance should be 400 kina.
    }



// Test 3: Multiple instalments totaling 500 leave a balance of 100.
[Test]
public void OutstandingBalance_MultipleInstallments_ReturnsCorrectBalance()
     {
      // Arrange 
      var calc = new FeeCalculator();// Create calculator object.
        var payments = new List<decimal> { 200m, 200m, 100m };// Three instalment payments.
      // Act
        var result = calc.OutstandingBalance(600m, payments);// Calculate balance.
     // Assert
        Assert.That(result, Is.EqualTo(100m));// Balance should be 100.
    }



// Test 4: Fee fully paid, so balance should be zero.
[Test]
public void OutstandingBalance_FullyPaid_ReturnsZero()
       {
       // Arrange
       var calc = new FeeCalculator();// Create calculator object.
       var payments = new List<decimal> { 600m };// Full fee paid.
       // Act
        var result = calc.OutstandingBalance(600m, payments);// Calculate balance.
      // Assert
        Assert.That(result, Is.EqualTo(0m));// Balance should be zero.
    }


// Test 5: Overpayment should result in a negative balance.
[Test]
public void OutstandingBalance_Overpaid_ReturnsNegativeBalance()
     {
      // Arrange
      var calc = new FeeCalculator();// Create calculator object.
      var payments = new List<decimal> { 700m };// Student paid more than required.
     // Act
     var result = calc.OutstandingBalance(600m, payments);// Calculate balance.
     // Assert
        Assert.That(result, Is.EqualTo(-100m)); // Balance should be -100.
    }



// Test 6: Negative fee should throw an ArgumentException.
[Test]
public void OutstandingBalance_NegativeFee_ThrowsArgumentException()
        {
        // Arrange
       var calc = new FeeCalculator();// Create calculator object.
       var payments = new List<decimal>();// Empty payment list.
        // Act and Assert
        Assert.That(

        () => calc.OutstandingBalance(-1m, payments),
       Throws.ArgumentException);// Exception should be thrown.
    }


 // Test 7: Paying exactly half the fee clears the student for exams.
 [Test]
public void IsClearedForExams_ExactlyHalfPaid_ReturnsTrue()
       {

        // Arrange
       var calc = new FeeCalculator();// create calculator object.
        var payments = new List<decimal> { 300m };// Half the fee has been paid.
        // Act
        var result = calc.IsClearedForExams(600m, payments);// Check clearance status.
       // Assert
        Assert.That(result, Is.True);//sudent should be cleared.
    }


// Test 8: One toea below half the fee does not clear the student for exams.
[Test]
public void IsClearedForExams_OneToeaUnderHalf_ReturnsFalse()
    {
    // Arrange
    var calc = new FeeCalculator();// create calculator object.
    var payments = new List<decimal> { 299.99m };//slightly less than half paid.
    // Act
    var result = calc.IsClearedForExams(600m, payments);// Check clearance status.
   //Assert
        Assert.That(result, Is.False); // Student should not be cleared.
    }


}