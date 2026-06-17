namespace MyRecipeBook.Communication.Responses;

public class ResponseErrorJson
{
    public List<string> Errors { get; private set; }
    public ResponseErrorJson(List<string> errorsMessages) => Errors = errorsMessages;
    public ResponseErrorJson(string errorMessage) => Errors = [errorMessage];
}
