using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionShop.Utilities.Constants
{
    public class SystemConstants
    {
        public const string MainConnectionString = "SolutionShopDatabase";
        public class AppSettings {
            public const string DefaultLanguageId = "DefaultLanguageId";
            public const string Token = "Token";
            public const string BaseAddress = "BaseAddress";
        }
        public class ProductSettings
        { 
            public const int NumberOfFeaturedProduct = 4;
            public const int NumberOfLastestProduct = 6;
        }
    }
}
