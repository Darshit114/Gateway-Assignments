using PMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BLL
{
    public interface IUserBLL
    {
        UserEntity AuthenticateUser(UserEntity user);
        IEnumerable<UserEntity> GetAllUsers();
    }
}
