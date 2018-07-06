using System.ComponentModel.DataAnnotations;

namespace WebStore.Models.Account
{
    public class LoginModel
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
    }
}
