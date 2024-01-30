using Dtos.RoleDtos;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.UserDtos
{
    public class UserToAddDto
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        //public Role role { get; set; }
        public  RoleToAddDto Role { get; set; }
    }

}
