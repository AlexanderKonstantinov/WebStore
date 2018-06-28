
using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public enum Sex
    {
        [Display(Name = "мужской")]
        Man,
        [Display(Name = "женский")]
        Woman
    }
}
