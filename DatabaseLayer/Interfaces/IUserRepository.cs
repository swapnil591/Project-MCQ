using ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Interfaces
{
    public interface IUserRepository
    {
        UserModel login(UserModel user);
        int Register(UserModel user);
        UserModel GetOneUser(int id);
        List<UserModel> GetAllUser();
    }
}
