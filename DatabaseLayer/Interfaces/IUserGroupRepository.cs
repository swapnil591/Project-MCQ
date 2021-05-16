using ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Interfaces
{
    public interface IUserGroupRepository
    {
        List<UserGroupModel> GetListOfUserGrp();
        int CreateUserGroup(UserGroupModel UGM);
        bool EditUserGroup(UserGroupModel UGM);
        List<tblRole> GetAllRoles();
    }
}
