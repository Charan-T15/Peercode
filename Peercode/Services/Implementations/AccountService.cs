using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Peercode.Core.Models;
using Peercode.Dtos;

namespace Peercode.Services.Implementations;

public class AccountService(
    UserManager<IdentityUser> userManager,
    IUserService userService,
    IMapper mapper, 
    IConfiguration configuration)
    : IAccountService
{
    public async Task RegisterUserAsync(RegisterDto registerDto)
    {
        var register = mapper.Map<Register>(registerDto);
        var identityResult = await this.CreateIdentityUser(register);
        await userService.AddUserAsync(register);
    }

    public async Task<LoginResponseDto> LoginUserAsync(LoginDto loginDto)
    {
        var login = mapper.Map<Login>(loginDto);
        var identityUser = await userManager.FindByNameAsync(login.Username);
        var isValidUser = identityUser != null && await userManager.CheckPasswordAsync(identityUser, login.Password);
        if (isValidUser)
        {
            var authclaims = this.GetClaims(identityUser!);
            var token = this.GetJwtToken(authclaims);
            return LoginResponseDto.CreateNew(token);
        }
        return LoginResponseDto.CreateInValidLoginResponse();
    }

    private async Task<IdentityResult> CreateIdentityUser(Register register)
    {
        var user = new IdentityUser(register.UserName);
        var result = await userManager.CreateAsync(user, register.Password);
        return result;
    }

    private string GetJwtToken(List<Claim> claims)
    {
       
        var jwtConfiguration = configuration.GetSection("Jwt");
        var securityToken = new JwtSecurityToken(
            issuer: jwtConfiguration.GetValue<string>("Issuer"),
            audience: null,
            claims: claims,
            notBefore: null,
            expires: DateTime.Now.AddMinutes(jwtConfiguration.GetValue<int>("Expiry")),
            signingCredentials: this.BuildSigningCredentials(jwtConfiguration.GetValue<string>("key")!)
            );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

    private SigningCredentials BuildSigningCredentials(string secretKey)
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        
        return new SigningCredentials(
            key: symmetricSecurityKey,
            algorithm: SecurityAlgorithms.HmacSha256
            );
    }

    private List<Claim> GetClaims(IdentityUser identityUser)
    {
        return
        [
            new (JwtRegisteredClaimNames.Sub, identityUser!.UserName!),
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        ];
    }
}
