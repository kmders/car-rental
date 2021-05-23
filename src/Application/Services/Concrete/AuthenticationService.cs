using Domain.Constants;
using Domain.DTOs;
using Domain.Entities;
using System.Collections.ObjectModel;
using System.Security.Claims;

namespace Application.Services.Concrete
{
    public class AuthenticationService : IAuthenticationService
    {
        private IUserService UserService { get; }
        private IHashService HashService { get; }
        private IUserOperationClaimService UserOperationClaimService { get; }
        private IAuthorizationService AuthorizationService { get; }

        public AuthenticationService(IUserService userService, IHashService hashService,
                                     IUserOperationClaimService userOperationClaimService,
                                     IAuthorizationService authorizationService)
        {
            UserService = userService;
            HashService = hashService;
            UserOperationClaimService = userOperationClaimService;
            AuthorizationService = authorizationService;
        }

        public Response<ClaimsPrincipal> Register(UserRegisterDTO user)
        {
            byte[] passwordHash, passwordSalt;
            HashService.Create(user.Password, out passwordHash, out passwordSalt);

            User userToCreate = new User
            {
                EMail = user.EMail,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                UserOperationClaim = new Collection<UserOperationClaim>()
                {
                    new UserOperationClaim
                    {
                        OperationClaimId = AuthenticationConstants.OperationClaims.User
                    }
                }
            };
            var response = UserService.Add(userToCreate);
            if(response.IsSuccess == false)
            {
                return Response<ClaimsPrincipal>.Fail(response.Message);
            }

            var claimsPrincipal = GetClaimsPrincipal(response.Data);
            return Response<ClaimsPrincipal>.Success("Kayıt başarılı", claimsPrincipal);
        }
        public Response<ClaimsPrincipal> Login(UserLoginDTO user)
        {
            var userToCheck = UserService.GetByEMail(user.EMail);
            if (userToCheck == null)
                return Response<ClaimsPrincipal>.Fail("Lütfen kullanıcı adı ve parola değerlerini kontrol ediniz");
            if (HashService.Verify(user.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt) == false)
                return Response<ClaimsPrincipal>.Fail("Lütfen kullanıcı adı ve parola değerlerini kontrol ediniz");

            var claimsPrincipal = GetClaimsPrincipal(userToCheck);

            return Response<ClaimsPrincipal>.Success("Giriş başarılı", claimsPrincipal);
        }

        private ClaimsPrincipal GetClaimsPrincipal(User user)
        {
            var operationClaims = UserOperationClaimService.GetClaims(user.Id);
            var claimsPrincipal = AuthorizationService.GetClaimsPrincipal(user, operationClaims);
            return claimsPrincipal;
        }

    }
}
