using System.ComponentModel.DataAnnotations;

namespace E_Tickets.Models
{
    public class Actor
    {
        [Key]
        public int  Id{ get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage ="Profile Picture is required")]
        public string ProfilePictureURL { get; set; }
        
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }
       
        
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]

        public string  Bio { get; set; }
       
        //Relations 

        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
