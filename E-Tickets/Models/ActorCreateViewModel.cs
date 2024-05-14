using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace E_Tickets.Models
{
    public class ActorCreateViewModel
    {
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture URL is required")]
        [Url(ErrorMessage = "Please enter a valid URL")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(100, ErrorMessage = "Full Name must be between 1 and 100 characters", MinimumLength = 1)]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }
    }

}
