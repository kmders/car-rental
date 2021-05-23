using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class OperationClaim
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
