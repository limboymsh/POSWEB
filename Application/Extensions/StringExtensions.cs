using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string text) => string.IsNullOrEmpty(text);
        public static bool IsNullOrWhiteSpace(this string text) => string.IsNullOrWhiteSpace(text);
    }
}
