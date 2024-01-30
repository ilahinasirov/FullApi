using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Concrete.EntityFramework.Contexts;
using Dtos.UserDtos;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{


    public class UserManager : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal, IMapper mapper )
        {
            _userDal = userDal;
            _mapper = mapper;
        }
        public string Add(User user)
        {
            _userDal.Add(user);
            return Messages.UserAdded;
        }
        public string Update(User user)
        {
            _userDal.Update(user);
            return Messages.UserUpdated;
        }

        public string Delete(User user)
        {
            _userDal.Delete(user);
            return Messages.UserDeleted;

        }

        public string SoftDelete(int id)
        {
            _userDal.SoftDelete(id);
            return Messages.UserDeleted;
        }

        public List<User> GetAll()
        {
            return _userDal.GetAll().ToList();
        }

        public User GetUserById(int id)
        {
            return _userDal.Get(x=>x.Id == id);
        }

        public List<User> GetListByRole(int roleId)

        {
            return _userDal.GetAll(x=>x.Role.Id == roleId).ToList();
        }

        


        // We Can use this additional methods in Controllers if we need
        public string AddDto(UserToAddDto dto)
        {
            _userDal.AddDto(dto);
            return Messages.UserAdded;
            
        }

        public string UpdateDto(int id, UserToListDto dto)
        {
            _userDal.UpdateDto(id, dto);
            return Messages.UserUpdated;

        }

        public List<UserToListDto> GetListDto()
        {
            return _userDal.GetListDto().ToList();
        }

        public UserToListDto GetDto(int id)
        {
           return _userDal.GetDto(id);
        }

        
    }
}
