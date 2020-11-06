using System;
using System.Collections.Generic;
using System.Text;

namespace CMSSimple.BusinessLogic.Common
{
    public class HttpResponseException : Exception
    {
        public int Status { get; set; } = 500;

        public object Value { get; set; }
    }
}
