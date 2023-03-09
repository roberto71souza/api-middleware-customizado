using System;

namespace Web_Api_ToDo.Exceptions
{
    public class DbContextException : Exception
    {
        public DbContextException(string error) : base(error)
        {

        }
    }
}
