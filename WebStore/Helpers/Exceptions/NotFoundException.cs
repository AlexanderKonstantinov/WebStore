using System;

namespace WebStore.Helpers.Exceptions
{
    public sealed class NotFoundException : Exception
    {
        public NotFoundException() : base("This entity not found in database") { }
    }
}
