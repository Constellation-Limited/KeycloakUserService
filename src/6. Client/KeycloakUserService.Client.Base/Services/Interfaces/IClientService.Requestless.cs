namespace KeycloakUserService.Client.Base.Services.Interfaces;

public interface IClientService<TResponse> : IBaseClientService
{
    /// <summary>
    /// Execute service request.
    /// </summary>
    /// <param name="cancellationToken">Operation cancellation token</param>
    /// <returns>Deserialized response</returns>
    Task<TResponse?> ExecuteAsync(CancellationToken cancellationToken);
}