using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL.Intefaces
{
    public interface IUserBL
    {
        List<User> GetUsers();
    }
}
