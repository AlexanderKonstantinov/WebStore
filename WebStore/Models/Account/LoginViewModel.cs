using System.ComponentModel.DataAnnotations;

namespace WebStore.Models.Account
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "RequiredErrorMessage"),
         MaxLength(256)]
        public string EmailOrUserName { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "RequiredErrorMessage"),
         DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
