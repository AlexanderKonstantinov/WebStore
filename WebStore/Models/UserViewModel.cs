using System;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{    
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "RequiredErrorMessage")]
        [StringLength(maximumLength: 20,
            MinimumLength = 2,
            ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "StringLengthErrorMessage")]
        [Display(Name = "DisplayLogin",
            ResourceType = typeof(Resources.Resource))]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "RequiredErrorMessage")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "EmailErrorMessage")]
        [Display(Name = "DisplayEmail",
            ResourceType = typeof(Resources.Resource))]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "RequiredErrorMessage")]
        [StringLength(maximumLength: 15,
            MinimumLength = 6,
            ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "StringLengthErrorMessage")]
        [DataType(DataType.Password)]
        [Display(Name = "DisplayPassword",
            ResourceType = typeof(Resources.Resource))]
        public string Password { get; set; }
    }
}
