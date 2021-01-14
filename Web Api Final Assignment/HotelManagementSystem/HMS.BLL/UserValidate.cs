using System;
using System.Linq;

namespace HMS.BLL
{
    public class UserValidate
    {
        public static bool Login(string username, string password)
        {
            UserBL userBL = new UserBL();

            var users = userBL.GetUsers();

            return users.Any(user => user.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                                    && user.Password == password);
        }
    }
}
