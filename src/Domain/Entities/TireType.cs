using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class TireType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Adı")]
        public string Name { get; set; }
    }
}
