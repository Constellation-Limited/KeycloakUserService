namespace KeycloakUserService.Domain.Entities.Enums;

/// <summary>
/// Events that are occurring in keycloak.
/// </summary>
public enum KeycloakEventType : byte
{
    UserAdded = 0,
    UserUpdated = 1,
    UserDeleted = 2
}