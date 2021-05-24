using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerFurnitureApplication.MyException
{
    public class CustomException : Exception
    {
        public CustomException(String message) : base(message) { }
    }
}
