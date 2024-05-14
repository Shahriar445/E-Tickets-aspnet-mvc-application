using System.ComponentModel.DataAnnotations;

namespace E_Tickets.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        [Display (Name ="Cinema Logo")]
        public string logo { get; set; }
        [Display(Name = "Cinema Name")]
        public string Name { get; set; }
        [Display(Name = "Descriptions")]
        public string Description { get; set; }

        // Relationshipos
        public List<Movie>Movies { get; set; }
    }
}
