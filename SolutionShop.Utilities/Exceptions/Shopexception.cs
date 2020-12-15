using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionShop.Utilities.Exceptions
{
    public class Shopexception : Exception
    {
        public Shopexception()
            {
                
        }
        

        public Shopexception(string message)
            : base(message)
        {
        }

        public Shopexception(string message, Exception inner)
            : base(message, inner)  
        {
        }
    }
}
