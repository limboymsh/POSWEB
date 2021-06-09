using System;

namespace WebUI.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AllowByPassApiAttribute :Attribute
    {
    }
}
