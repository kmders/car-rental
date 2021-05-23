using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class UserOperationClaim
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public User User { get; set; }
        public OperationClaim OperationClaim { get; set; }
    }
}
