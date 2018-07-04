using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.Entities
{
    /// <summary>
    /// User database class
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
