using System;
using System.Collections.Generic;
using System.Text;

namespace PittsburgheseTranslator.Exceptions
{
    public class WordNotFound : PgheseExceptions
    {
        public WordNotFound() : base("The word was not found.  Maybe it has a different spelling or maybe it is not in the dictionary yet\n" +
                    "Please try again or check the word list") { }
    }
}
