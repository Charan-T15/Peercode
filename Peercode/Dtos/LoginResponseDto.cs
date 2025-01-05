namespace Peercode.Dtos;

public class LoginResponseDto
{
    public bool IsValidUser { get; set; }

    public string Token { get; set; }

    public static LoginResponseDto CreateNew(string token)
    {
        return new()
        {
            Token = token,
            IsValidUser = false
        };
    }

    public static LoginResponseDto CreateInValidLoginResponse()
    {
        return new()
        {
            IsValidUser = false,
        };
    }
}
