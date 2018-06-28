using System;

namespace WebStore.Models
{
    /// <summary>
    /// Employee database class
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }
        public Sex Sex { get; set; } // Женщины не поймут :)
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }
        public string SecretName { get; set; }
        public string Position { get; set; }

        public override string ToString() => $"{Id}\t{FirstName}\t{SecondName}\t{Patronymic}";
    }
}
