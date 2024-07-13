using CustomerRegistry.API.Models;
using CustomerRegistry.Domain.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CustomerRegistry.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IAuthenticate _authentication;
    private readonly IConfiguration _configuration;

    public TokenController(IAuthenticate authenticate, IConfiguration configuration)
    {
        _authentication = authenticate ?? throw new ArgumentException(nameof(authenticate));
        _configuration = configuration;
    }

    [HttpPost("LoginUser")]
    public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel userInfo)
    {
        var result = await _authentication.AuthenticateAsync(userInfo.Email, userInfo.Password);

        if (result)
        {
            return GenerateTokenAsync(userInfo);
            //return Ok($"User {userInfo.Email} login succesfully");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid Login attempt");
            return BadRequest(ModelState);
        }
    }

    private ActionResult<UserToken> GenerateTokenAsync(LoginModel userInfo)
    {
        // declarações do usuário
        var claims = new[]
        {
            new Claim("email", userInfo.Email),
            new Claim("meuvalor","qualquertexto"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // gerar chave privada para assinar o token
        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

        //gerar assinatura digital do token
        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

        //definir o tempo de expiração
        var expiration = DateTime.UtcNow.AddMinutes(10);

        //gerar o token
        JwtSecurityToken token = new JwtSecurityToken(
            //emissor
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
        );

        return new UserToken()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration
        };
    }
}
