using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Exceptions
{
    public class ModelStateException: Exception
    {
        public ModelStateDictionary ModelState { get; }

        public ModelStateException(ModelStateDictionary modelState)
        {
            ModelState = modelState;
        }
    }
}
