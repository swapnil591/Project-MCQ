using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelClasses;
using DatabaseLayer.Interfaces;

namespace DatabaseLayer.RepositoryPattern
{
    public class UserGroupRepository : IUserGroupRepository
    {
        public List<UserGroupModel> GetListOfUserGrp()
        {
            using (var context = new MCQ_Quiz_DBEntities())
            {

                var data = (from a in context.tblUsers
                            join b in context.tblUserGroups on a.UserId equals b.UserId
                            join c in context.tblRoles on b.RoleId equals c.RoleId
                            join d in context.tblQuizs on a.UserId equals d.CreatedBy
                            select new UserGroupModel
                            {
                                UserGrpId = b.UserGrpId,
                                User = a.FirstName + " " + a.LastName,
                                Quiz = d.Title,
                                Role = c.RoleName,
                                CreatedON = b.CreatedON,
                                UpdatedON = b.UpdatedON
                            }).ToList();


                //var data = context.tblUserGroups.Select(x => new UserGroupModel
                //{
                //    UserGrpId = x.UserGrpId,
                //    UserId = x.UserId,
                //    QuizId = x.QuizId,
                //    RoleId = (int)x.RoleId,
                //    CreatedON = x.CreatedON,
                //    UpdatedON = x.UpdatedON
                //}).ToList();

                return data;
            }
        }

        public int CreateUserGroup(UserGroupModel UGM)
        {
            try
            {
                using (var context = new MCQ_Quiz_DBEntities())
                {
                    tblUserGroup TUG = new tblUserGroup();

                    TUG.UserId = UGM.UserId;
                    TUG.QuizId = UGM.QuizId;
                    TUG.RoleId = UGM.RoleId;
                    TUG.CreatedON = UGM.CreatedON;
                    TUG.UpdatedON = UGM.UpdatedON;

                    context.tblUserGroups.Add(TUG);
                    context.SaveChanges();

                    return TUG.UserGrpId;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool EditUserGroup(UserGroupModel UGM)
        {
            try
            {
                using (var context = new MCQ_Quiz_DBEntities())
                {
                    var RecordToEdit = context.tblUserGroups.Where(x => x.UserGrpId == UGM.UserGrpId).FirstOrDefault();

                    RecordToEdit.RoleId = UGM.RoleId;
                    RecordToEdit.UpdatedON = UGM.UpdatedON;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<tblRole> GetAllRoles()
        {
            try
            {
                using (var context = new MCQ_Quiz_DBEntities())
                {
                    var data = context.tblRoles.ToList();
                    return data;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
