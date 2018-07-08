using System.ComponentModel.DataAnnotations;
using WebStore.Helpers;

namespace WebStore.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "RequiredErrorMessage"),
        StringLength(maximumLength: 200,
            MinimumLength = 2,
            ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "StringLengthErrorMessage")]
        [Display(Name = "DisplayFirstName",
            ResourceType = typeof(Resources.Resource))]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "RequiredErrorMessage"),
        Display(Name = "DisplaySecondName",
            ResourceType = typeof(Resources.Resource))]
        public string SecondName { get; set; }

        [Display(Name = "DisplayPatronomyc",
            ResourceType = typeof(Resources.Resource))]
        public string Patronymic { get; set; }

        [Display(Name = "DisplaySex",
            ResourceType = typeof(Resources.Resource))]
        public Gender Gender { get; set; }

        public string DisplayGenderEnumItem => Gender.GetEnumAttribute<DisplayAttribute>().Name;

        [Range(16,
            78,
            ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "RangeErrorMessage"),
        Display(Name = "DisplayAge",
            ResourceType = typeof(Resources.Resource))]
        public int Age { get; set; }

        [Display(Name = "DisplaySecretName",
            ResourceType = typeof(Resources.Resource))]
        public string SecretName { get; set; }

        [Display(Name = "DisplayPosition",
            ResourceType = typeof(Resources.Resource)),
        Required(AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "RequiredErrorMessage")]
        public string Position { get; set; }
    }
}
