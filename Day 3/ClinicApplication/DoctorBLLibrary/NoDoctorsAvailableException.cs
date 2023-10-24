using System.Runtime.Serialization;

namespace DoctorBLLibrary
{
    [Serializable]
    internal class NoDoctorsAvailableException : Exception
    {
        string message;
        public NoDoctorsAvailableException()
        {
            message = "No doctors are available currently";
        }

        public override string Message => message;

    }
}