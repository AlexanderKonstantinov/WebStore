using System;

namespace WebStore.Helpers.Exceptions
{
    public sealed class AlreadyExistException : Exception
    {
        public AlreadyExistException() : base("This entity already exist in database") { }
    }
}
