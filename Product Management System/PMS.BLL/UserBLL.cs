using PMS.DAL.Repository;
using PMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BLL
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserRepository _user;

        public UserBLL(IUserRepository user)
        {
            _user = user;
        }

        public UserEntity AuthenticateUser(UserEntity user)
        {
            return _user.AuthenticateUser(user);
        }

        public IEnumerable<UserEntity> GetAllUsers()
        {
            return _user.GetALLUsers();
        }
    }
}
