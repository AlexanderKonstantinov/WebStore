using System;

namespace WebStore.Helpers
{
    public sealed class NotFoundException : Exception
    {
        public NotFoundException() : base("This entity not found in database") { }
    }
}
