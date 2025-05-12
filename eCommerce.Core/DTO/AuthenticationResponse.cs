namespace eCommerce.Core.DTO;

public record AuthenticationResponse(Guid UserID, string? Email, string? PersonName, string? Gender, string? Token, bool Success)
{
    //Parameterless constructor
    /// <summary>
    /// need to call the primary constructor from the parameterless constructor. This is constructor chaining
    /// </summary>
    public AuthenticationResponse() : this(default, default, default, default, default, default)
    {

    }
}
