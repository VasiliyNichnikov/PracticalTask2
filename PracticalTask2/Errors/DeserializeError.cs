using System;

namespace PracticalTask2.Errors
{
    public class DeserializeError : Exception
    {
        public DeserializeError(string message): base(message)
        {
            
        }
    }
}