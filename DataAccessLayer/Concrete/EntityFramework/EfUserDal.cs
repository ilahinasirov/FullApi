using AutoMapper;
using Core.DataAccessLayer.EntityFramework;
using Core.Entities;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Contexts;
using Dtos.UserDtos;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User,ProjectContext>, IUserDal
    {
        private readonly IMapper _mapper;
        public EfUserDal(IMapper mapper)
        {
            _mapper = mapper;
        }


        public List<User> GetAll()
        {
            using (var context = new ProjectContext())
            {
                return context.Set<User>().Include(m => m.Role).ToList();

                // Burada User daxilinde Role class kimi oldugu uchun default olaraq Role-un melumatlarini getirmeyecek mene. Ona gore de Include() ile (Lazy Loading istifade ederek) useri chekdiyimde rolunda melumatlarinin gelmeyini temin edirem. 
                // Eger Userin icerisindeki Rolun-da icerisinde class olarsa meselen Permissions kimi onun da melumatlarini getirmek uchun ThenInclude() istifade edecem

                //meselen
                //return context.Set<User>().Include(m => m.Role).ThenInclude(p=>p.Permissions).ToList();
                // Yeni child-lar uchun Include parent-ler uchun ThenInclude
            }

        }
        public User GetUserById(int userId)
        {
            using (var context = new ProjectContext())
            {
                return context.Set<User>().SingleOrDefault(x => x.Id == userId);
            }
        }
        public void SoftDelete(int id)
        {
            using (var context = new ProjectContext())
            {
                var entity = context.Set<User>().SingleOrDefault(x => x.Id == id);
                entity.IsDeleted = true;
                context.SaveChanges();
                
                
            }
        }

        public List<User> GetListByRole(int roleId)

        {
            using (var context = new ProjectContext())
            {
                return context.Set<User>().Where(x=>x.Role.Id == roleId).ToList();
            }
        }

        public void AddDto(UserToAddDto dto)
        {
            using (var context = new ProjectContext())
            {
                var entity = _mapper.Map<UserToAddDto>(dto);
                context.Add(entity);
            }
            

        }

        public void UpdateDto(int id, UserToListDto dto)
        {
            using(var context = new ProjectContext())
            {
                User user = _mapper.Map<User>(dto);
                
                user.Id = id;
                context.Update(user);
            }
        }

        public List<UserToListDto> GetListDto()
        {
            using (var context = new ProjectContext())
            {
                var entities = context.Set<User>().ToList();
                return _mapper.Map<List<UserToListDto>>(entities);
            }
        }

        public UserToListDto GetDto(int id)
        {
            using (var context = new ProjectContext())
            {
                var entity = context.Set<User>().SingleOrDefault(x => x.Id == id);
                return _mapper.Map<UserToListDto>(entity);
            }
            
        }
    }
}
