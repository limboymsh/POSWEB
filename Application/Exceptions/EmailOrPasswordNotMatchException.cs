using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class EmailOrPasswordNotMatchException : Exception
    {
        public EmailOrPasswordNotMatchException()
            : base($"Email atau Password salah")
        { }
    }
    public class EmailHasNotValidateException : Exception
    {
        public EmailHasNotValidateException()
            : base($"Email belum diverifikasi")
        { }
    }
}
