using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class AppSetting
    {
        public string AuthenticationKey { get; set; }
        public string ClientUrl { get; set; }
        public string AdminUrl { get; set; }
        public bool StackTrace { get; set; } //munculkan error response StackTrace
    }
}
