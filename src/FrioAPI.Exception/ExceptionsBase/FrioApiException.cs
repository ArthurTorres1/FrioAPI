namespace FrioAPI.Exception.ExceptionsBase
{
    public abstract class FrioApiException : SystemException
    {
        protected FrioApiException(string message) : base(message)
        {
            
        }

        public abstract int StatusCode { get; }
        public abstract List<string> GetErrors();
    }
}
