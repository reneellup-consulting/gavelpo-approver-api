namespace GavelMobilePoApprover.Contracts.Authentication;
public record AuthenticationResponse(
    Guid Id,
    string No,
    string Name,
    string Email,
    string Token);