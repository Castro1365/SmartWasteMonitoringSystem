using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartWasteMonitoringSystem;

namespace SmartWasteMonitoringSystem.Tests;

[TestClass]
public class PinHasherTests
{
    [TestMethod]
    public void Hash_GivesSameResult_ForSamePin()
    {
        // Arrange
        var pin = "1234";

        // Act
        var hash1 = PinHasher.Hash(pin);
        var hash2 = PinHasher.Hash(pin);

        // Assert
        Assert.AreEqual(hash1, hash2, "Hash should be deterministic for the same PIN.");
    }

    [TestMethod]
    public void Verify_ReturnsTrue_ForCorrectPin()
    {
        // Arrange
        var pin = "1234";
        var hash = PinHasher.Hash(pin);

        // Act
        var ok = PinHasher.Verify(pin, hash);

        // Assert
        Assert.IsTrue(ok, "Verify should return true for the correct PIN.");
    }

    [TestMethod]
    public void Verify_ReturnsFalse_ForWrongPin()
    {
        // Arrange
        var correctHash = PinHasher.Hash("1234");

        // Act
        var ok = PinHasher.Verify("9999", correctHash);

        // Assert
        Assert.IsFalse(ok, "Verify should return false for a wrong PIN.");
    }
}
