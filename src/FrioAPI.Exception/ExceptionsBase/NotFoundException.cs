using System.Net;

namespace FrioAPI.Exception.ExceptionsBase
{
    public class NotFoundException : FrioApiException
    {
        public NotFoundException(string message) : base(message)
        {
            
        }

        public override int StatusCode => (int)HttpStatusCode.NotFound;

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
