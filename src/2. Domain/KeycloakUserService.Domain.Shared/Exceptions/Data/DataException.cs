namespace KeycloakUserService.Domain.Shared.Exceptions.Data;

public class DataException : Exception
{
    /// <summary>
    /// Code of the exception
    /// </summary>
    public DataExceptionCode Code { get; }

    public DataException(DataExceptionCode code, string message, params (string, object?)[] exceptionDetails) : base(message)
    {
        Code = code;
    }
}