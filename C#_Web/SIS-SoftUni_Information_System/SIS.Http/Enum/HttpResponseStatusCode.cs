using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Http.Enum
{
    public enum HttpResponseStatusCode
    {
       Ok = 200,
       Created = 201,
       Found = 302,
       SeeOther = 400,
       Unautorized = 401,
       Forbidden = 403,
       NotFound = 404,
       InternalServerError = 500
    }
}
