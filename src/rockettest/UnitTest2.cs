using Xunit;
using System;

public class RocketFileTests
{
    [Fact]
    public void TestRocketFileCreation()
    {
        // Arrange
        string name = "Falcon";
        DateOnly date = DateOnly.FromDateTime(DateTime.Now);
        int chanceOfFailure = 10;

        // Act
        var rocketFile = new RocketFile(name, date, chanceOfFailure);

        // Assert
        Assert.Equal(name, rocketFile.Name);
        Assert.Equal(date, rocketFile.Date);
        Assert.Equal(chanceOfFailure, rocketFile.ChanceOfFailure);
        Assert.Equal(Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(name)), rocketFile.KeyCode);
    }
}