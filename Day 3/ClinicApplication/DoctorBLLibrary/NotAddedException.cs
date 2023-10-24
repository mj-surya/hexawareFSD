using System.Runtime.Serialization;

namespace DoctorBLLibrary
{
    [Serializable]
    public class NotAddedException : Exception
    {
            string message;
            public NotAddedException()
            {
                message = "Doctor was not addedd.";
            }
            public override string Message => message;
    }
}