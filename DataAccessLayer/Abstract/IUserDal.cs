using Core.DataAccessLayer;
using Dtos.UserDtos;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {

        User GetUserById(int userId);
        void SoftDelete(int id);
        List<User> GetListByRole(int roleId);
        void AddDto(UserToAddDto dto);
        void UpdateDto(int id, UserToListDto dto);
        List<UserToListDto> GetListDto();
        UserToListDto GetDto(int id);

    }
}
