using System;
using System.ComponentModel.DataAnnotations;

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
        public Sex Sex { get; set; }

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



        public string Info => String.Format(
                "{0} {1} состоит в должности {2}. На данный момент {3} {4} {5}. Кодовое прозвище: \"{6}\".",
                FirstName,
                Patronymic,
                Position,
                Sex == Sex.Man ? "ему" : "ей",
                Age,
                Age % 10 > 0 && Age % 10 < 5 ? "года" : "лет",
                SecretName);
    }
}
