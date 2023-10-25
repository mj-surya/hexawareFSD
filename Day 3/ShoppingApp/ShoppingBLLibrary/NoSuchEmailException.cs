using System.Runtime.Serialization;

namespace ShoppingBLLibrary
{
    [Serializable]
    internal class NoSuchEmailException : Exception
    {
        string message;
        public NoSuchEmailException()
        {
            message = "Please enter a valim email";
        }
        public override string Message => message;


    }
}