using Domain.DTOs;
using System.Security.Claims;

namespace Application.Services
{
    public interface IAuthenticationService
    {
        Response<ClaimsPrincipal> Register(UserRegisterDTO user);
        Response<ClaimsPrincipal> Login(UserLoginDTO user);
    }
}
