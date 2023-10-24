using System.Runtime.Serialization;

namespace ShoppingBLLibrary
{
    [Serializable]
    internal class InValidUpdateActionException : Exception
    {
        string message;
        public InValidUpdateActionException()
        {
            message = "The action you have specified is not valid";
        }
        public override string Message => message;
    }
}