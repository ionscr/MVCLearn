using System.ComponentModel.DataAnnotations;

namespace MVCLearn.Models
{
    public class AddAuthor
    {
        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First name")]
        [StringLength(20,MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last name")]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }
    }
}
