using HMS.BLL.Intefaces;
using HMS.Entities;
using System.Collections.Generic;

namespace HMS.BLL
{
    public class UserBL : IUserBL
    {
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            users.Add(new User()
            {
                ID = 1001,
                Username = "Customer",
                Password = "Customer@1234",
                Role = "Customer"
            });

            users.Add(new User()
            {
                ID = 2001,
                Username = "Admin",
                Password = "Admin@1234"
            });

            return users;
        }
    }
}
