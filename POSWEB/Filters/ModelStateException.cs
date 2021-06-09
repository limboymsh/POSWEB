using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace WebUI.Filters
{
    public class ModelStateException : Exception
    {
        public ModelStateDictionary ModelState { get; }

        public ModelStateException(ModelStateDictionary modelState)
        {
            ModelState = modelState;
        }
    }
}