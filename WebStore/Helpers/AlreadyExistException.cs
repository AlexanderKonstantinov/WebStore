using System;
using System.IO;

namespace WebStore.Helpers
{
    public sealed class AlreadyExistException : Exception
    {
        public AlreadyExistException() : base("This entity already exist in database") { }
    }
}
