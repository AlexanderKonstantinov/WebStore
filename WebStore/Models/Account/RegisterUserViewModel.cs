using System.ComponentModel.DataAnnotations;

namespace WebStore.Models.Account
{
    public class RegisterUserViewModel
    {
        [Required(AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "RequiredErrorMessage"),
         EmailAddress(ErrorMessageResourceType = typeof(Resources.Resource),
             ErrorMessageResourceName = "EmailErrorMessage")]
        public string Email { get; set; }

        [MaxLength(256)]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "RequiredErrorMessage"),
         DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DataType(DataType.Password),
         Compare(nameof(Password), 
            ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "IncorrectPassword")]
        public string ConfirmPassword { get; set; }
    }
}
