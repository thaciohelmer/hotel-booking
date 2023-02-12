
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Base
{
    public enum ErrorCodes
    {
        NOT_FOUND = 1,
        COULD_NOT_STORE_DATA = 2,
        INVALID_IDENTITY_DOCUMENT = 3,
        MISSING_REQUIRE_INFORMATION = 4,
        INVALID_EMAIL = 5,
    }

    public abstract class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ErrorCodes ErrorCode { get; set; }
    }
}
