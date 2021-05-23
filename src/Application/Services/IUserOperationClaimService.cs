using Domain.Entities;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IUserOperationClaimService
    {
        List<OperationClaim> GetClaims(int userId);
    }
}
