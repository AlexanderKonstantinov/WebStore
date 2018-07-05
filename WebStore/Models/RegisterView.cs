using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class RegisterView
    {
        [Required(AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "RequiredErrorMessage")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "EmailErrorMessage")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "RequiredErrorMessage")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", 
            ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "IncorrectPassword")]
        public string ConfirmPassword { get; set; }
    }
}
