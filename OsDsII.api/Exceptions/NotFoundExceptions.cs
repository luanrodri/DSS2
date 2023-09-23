using System.Net;

namespace OsDsII.api.Exceptions
{
    public class NotFoundExceptions: BaseException
    {
        public NotFoundExceptions(string resource) :
            base(
                "ERROR:001",
                $"{resource} not found",
                HttpStatusCode.NotFound,
                StatusCodes.Status404NotFound,
                DateTimeOffset.UtcNow,
                null
                )
        { }

        public NotFoundExceptions(string message, Exception ex) :
           base(
               "ERROR:001",
               message,
               HttpStatusCode.NotFound,
               StatusCodes.Status404NotFound,
               DateTimeOffset.UtcNow,
               ex
               )
        { }


    }
}

