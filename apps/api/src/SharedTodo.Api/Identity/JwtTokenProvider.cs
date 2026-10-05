namespace SharedTodo.Api.Identity;

public class JwtTokenProvider(IOptions<JwtOptions> options)
{
    private readonly JwtOptions _options = options.Value;
    private readonly JsonWebTokenHandler _handler = new();
    private readonly SigningCredentials _signingCredentials = new(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SecretKey)), SecurityAlgorithms.HmacSha256);

    public string GenerateAccessToken(ApplicationUser user)
    {
        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            ]),
            Issuer = _options.Issuer,
            Audience = _options.Audience,
            Expires = DateTime.UtcNow.AddMinutes(_options.AccessTokenExpirationMinutes),
            SigningCredentials = _signingCredentials,
        };

        return _handler.CreateToken(descriptor);
    }
}
