using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class TransmissionType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Şanzıman Türü")]
        public string Name { get; set; }
    }
}
