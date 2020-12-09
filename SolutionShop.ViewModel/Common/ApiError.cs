using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace SolutionShop.ViewModel.Common
{
    public class ApiError<T> : ApiResult<T>
    {
        public string[] ValiadationErrors { get; set; }
        public ApiError()
        {

        }
        public ApiError(string mes)
        {
            IsSuccessed = false;
            Message = mes;
        }
        public ApiError (string[] validationErrors)
        {
            IsSuccessed = false;
            ValiadationErrors = validationErrors;
        }
    }
}
