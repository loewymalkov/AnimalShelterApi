using System.ComponentModel.DataAnnotations;
namespace AnimalShelter.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        [Required]
        [StringLength (20)]
        public string Type { get; set; }

        [Required]
        [StringLength (20)]
        public string Name {get; set ;}
        [Required]
        [Range(1,25, ErrorMessage = "The age range must be between 1-25")]
        public int Age { get; set; }
        
       
    }
}