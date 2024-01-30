using Dtos.UserDtos;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetUserById(int id);
        List<User> GetListByRole(int roleId);
        string Add(User user);
        string Update(User user);
        string Delete(User user);
        string SoftDelete(int id);


        string AddDto(UserToAddDto dto);
        string UpdateDto(int id, UserToListDto dto);
        List<UserToListDto> GetListDto();
        UserToListDto GetDto(int id);
    }
}
