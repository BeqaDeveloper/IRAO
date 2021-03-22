using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRAO.API.Helpers
{
    public static class ModelStatus
    {
        public static List<string> GetModelStateErrors(this ModelStateDictionary modelState)
        {
            return modelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
        }
    }
}
