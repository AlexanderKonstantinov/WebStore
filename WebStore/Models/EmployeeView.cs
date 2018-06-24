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

        public string FIO => $"{SecondName} {FirstName} {Patronymic}";

        public string Info => String.Format(
                "{0} {1} работает в нашей компании в течении {2} {3}. На данный момент {4} {5} {6}. Кодовое прозвище: \"{7}\".", 
                FirstName,
                Patronymic,
                WorkDuration.Days,
                WorkDuration.Days % 10 == 1 ? "дня" : "дней",
                IsMan ? "ему" : "ей",
                Age,
                Age % 10 > 0 && Age % 10 < 5 ? "года" : "лет",
                SecretName);

        public TimeSpan WorkDuration { get; }


        public EmployeeView(Employee employee)
        {
            Id = employee.Id;
            IsMan = employee.IsMan;
            FirstName = employee.FirstName;
            SecondName = employee.SecondName;
            Patronymic = employee.Patronymic;
            Age = employee.Age;
            SecretName = employee.SecretName;

            WorkDuration = DateTime.Now - employee.WorkBeginning;
        }
    }
}
