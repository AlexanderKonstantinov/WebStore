using System.ComponentModel.DataAnnotations;

namespace WebStore.Models.Account
{
    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false,
             ErrorMessageResourceType = typeof(Resources.Resource),
             ErrorMessageResourceName = "RequiredErrorMessage"),
         EmailAddress(ErrorMessageResourceType = typeof(Resources.Resource),
             ErrorMessageResourceName = "EmailErrorMessage"),
         Display(Name = "DisplayEmail",
             ResourceType = typeof(Resources.Resource))]
        public string Email { get; set; }

        [MaxLength(256),
         Display(Name = "DisplayLogin",
             ResourceType = typeof(Resources.Resource))]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false,
             ErrorMessageResourceType = typeof(Resources.Resource),
             ErrorMessageResourceName = "RequiredErrorMessage"),
         DataType(DataType.Password),
         StringLength(maximumLength: 20,
             MinimumLength = 6,
             ErrorMessageResourceType = typeof(Resources.Resource),
             ErrorMessageResourceName = "StringLengthErrorMessage"),
         
         Display(Name = "DisplayPassword",
             ResourceType = typeof(Resources.Resource))]
        public string Password { get; set; }
        
        [DataType(DataType.Password),
         Compare(nameof(Password), 
             ErrorMessageResourceType = typeof(Resources.Resource),
             ErrorMessageResourceName = "IncorrectPassword"),
         Display(Name = "DisplayConfirmPassword",
             ResourceType = typeof(Resources.Resource))]
        public string ConfirmPassword { get; set; }
    }
}
