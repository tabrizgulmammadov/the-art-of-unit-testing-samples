using System.ComponentModel.Design.Serialization;

namespace LogAn.UnitTests;

public class FakeExtensionManager : IExtensionManager
{
    public bool WillBeValid = false;
    
    public bool IsValid(string fileName)
    {
        return WillBeValid;
    }
}