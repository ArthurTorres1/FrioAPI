namespace FrioAPI.Exception.ExceptionsBase
{
    public abstract class FrioApiException : SystemException
    {
        protected FrioApiException(string message) : base(message)
        {
            
        }
    }
}
