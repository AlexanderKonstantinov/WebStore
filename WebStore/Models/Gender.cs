using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public enum Gender
    {
        [Display(Name = "мужской")]
        Man,
        [Display(Name = "женский")]
        Woman
    }
}
