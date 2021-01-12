using AutoMapper;
using PMS.DAL.Database;
using PMS.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL.Repository
{
    using PMS = Product_Management_System_Entities;

    public class UserRepository : IUserRepository
    {
        private readonly PMS _context;

        public UserRepository(PMS context)
        {
            _context = context;
        }

        public UserEntity AuthenticateUser(UserEntity user)
        {
            var usr = _context.AuthenticateUser("admin_user@gmail.com", "admin@1234$");
            UserEntity _user = null;

            if (usr != null)
            {
                var iMapper = this.GetMapperInstance();
                
                
                foreach (var member  in usr.ToList())
                {
                    if(member.Email == user.Email && member.Password == user.Password)
                    {
                        User userRepo = iMapper.Map<AuthenticateUser_Result, User>(member);

                        _user = iMapper.Map<User, UserEntity>(userRepo);

                        return _user;
                    }
                }

                return _user;
            }

            return _user;
        }

        public IEnumerable<UserEntity> GetALLUsers()
        {
            List<User> users = (from user in _context.Users
                                orderby user.Id
                                select user).ToList();

            List<UserEntity> _users = new List<UserEntity>();

            var iMapper = this.GetMapperInstance();

            foreach (var usr in users)
            {
                var dest = iMapper.Map<User, UserEntity>(usr);

                _users.Add(dest);
            }

            return _users;
        }
        
        private IMapper GetMapperInstance()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserEntity>();
                cfg.CreateMap<AuthenticateUser_Result, User>();
            });

            IMapper iMapper = config.CreateMapper();

            return iMapper;
        }
    }
}
