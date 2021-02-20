using System;
using System.Collections.Generic;
using System.Text;

namespace PittsburgheseTranslator.Exceptions
{
    public abstract class PgheseExceptions : Exception
    {
        public PgheseExceptions(string message) : base(message) { }
    }
}
