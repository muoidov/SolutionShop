using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionShop.ViewModel.Common
{
    public class ApiSuccessResult<T> : ApiResult<T>
    {
        public ApiSuccessResult(T rsobj)
        {
            IsSuccessed = true;
            Result = rsobj;
        }

        public ApiSuccessResult()
        {
            IsSuccessed = true;
        }
    }
}
