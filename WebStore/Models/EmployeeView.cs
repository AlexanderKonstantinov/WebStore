using System;

namespace WebStore.Models
{
    /// <summary>
    /// Employee view class
    /// </summary>
    public class EmployeeView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public bool IsMan { get; set; }
        public int Age { get; set; }
        public string SecretName { get; set; }
        public string Position { get; set; }

        public string FIO => $"{SecondName} {FirstName} {Patronymic}";

        public string Info => String.Format(
                "{0} {1} состоит в должности {2}. На данный момент {3} {4} {5}. Кодовое прозвище: \"{6}\".", 
                FirstName,
                Patronymic,
                Position,
                IsMan ? "ему" : "ей",
                Age,
                Age % 10 > 0 && Age % 10 < 5 ? "года" : "лет",
                SecretName);
    }
}
