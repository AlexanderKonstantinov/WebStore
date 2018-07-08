using System.ComponentModel.DataAnnotations;

namespace WebStore.Models.Account
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false,
             ErrorMessageResourceType = typeof(Resources.Resource),
             ErrorMessageResourceName = "RequiredErrorMessage"),
         MaxLength(256),
         Display(Name = "DisplayEmailOrUserName",
             ResourceType = typeof(Resources.Resource))]
        public string EmailOrUserName { get; set; }

        [Required(AllowEmptyStrings = false,
             ErrorMessageResourceType = typeof(Resources.Resource),
             ErrorMessageResourceName = "RequiredErrorMessage"),
         DataType(DataType.Password),
         Display(Name = "DisplayPassword",
             ResourceType = typeof(Resources.Resource))]
        public string Password { get; set; }

        [Display(Name = "DisplayRememberMe",
            ResourceType = typeof(Resources.Resource))]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
