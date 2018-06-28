using System;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    /// <summary>
    /// Employee view class
    /// </summary>
    public class EmployeeView
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Не указано имя")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public Sex Sex { get; set; }
        [Range(16, 100, ErrorMessage = "Возраст должен находиться в пределах от 16 до 100 лет")]
        public int Age { get; set; }
        public string SecretName { get; set; }
        [Required(ErrorMessage = "Не указана должность")]
        public string Position { get; set; }

        public string FIO => $"{SecondName} {FirstName} {Patronymic}";

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
