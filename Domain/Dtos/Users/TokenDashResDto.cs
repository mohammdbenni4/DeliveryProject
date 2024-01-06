namespace Domain.Dtos.Users;

public class TokenDashResDto
{
    public TokenDashResDto()
    {
        
    }

    public TokenDashResDto(string accessToken, string refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }

    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}