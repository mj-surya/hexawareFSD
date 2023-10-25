using System.Runtime.Serialization;

namespace ShoppingBLLibrary
{
    [Serializable]
    internal class InvalidPasswordException : Exception
    {
        string message;
        public InvalidPasswordException()
        {
            message = "Please enter a valid email and password";
        }
        public override string Message => message;
    }
}