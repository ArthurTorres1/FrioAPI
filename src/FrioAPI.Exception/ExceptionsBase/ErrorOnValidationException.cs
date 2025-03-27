namespace FrioAPI.Exception.ExceptionsBase
{
    public class ErrorOnValidationException : FrioApiException
    {

        public List<string> Errors { get; set; }
        public ErrorOnValidationException(List<string> errorMessages)
        {
            Errors = errorMessages;
        }
    }
}
