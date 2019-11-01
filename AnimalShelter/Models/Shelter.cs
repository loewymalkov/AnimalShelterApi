namespace AnimalShelter.Models
{
  public class Shelter
  {
    public int ShelterId { get; set; }
    [Required]
    [StringLength (20)]
    public string Name { get; set; }
    

  }
}