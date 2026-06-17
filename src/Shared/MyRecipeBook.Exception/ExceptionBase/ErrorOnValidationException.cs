namespace MyRecipeBook.Exception
{
    public class ErrorOnValidationException : MyRecipeBookException
    {
        private readonly List<string> _errorsMessages;
        public ErrorOnValidationException(List<string> errorsMessages)
        {
            _errorsMessages = errorsMessages;
        }

        public List<string> GetErrorsMessages() => _errorsMessages;
        

    }
}