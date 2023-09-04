namespace KeycloakUserService.Client.Base.Services.Interfaces;

public interface IClientService<in TRequest, TResponse> : IBaseClientService
{
    /// <summary>
    /// Execute service request.
    /// </summary>
    /// <param name="request">Request data</param>
    /// <param name="cancellationToken">Operation cancellation token</param>
    /// <returns>Deserialized response</returns>
    Task<TResponse?> ExecuteAsync(TRequest request, CancellationToken cancellationToken);
}