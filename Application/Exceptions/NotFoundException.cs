using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string msg) : base(msg) { }

        public NotFoundException() { }

        public NotFoundException(string name, object key)
            : base($"{name} - ({key}) tidak ditemukan")
        {
        }
    }
}