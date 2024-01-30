using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int Age { get; set; }

        public Role Role { get; set; }
    }
}
