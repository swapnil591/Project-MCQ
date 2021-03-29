using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelClasses;

namespace DatabaseLayer.RepositoryPattern
{
    public class UserRepository
    {
        //  [CustomValidation]
        public static string login(UserModel user)
        {
            using (var context = new MCQ_Quiz_DBEntities())
            {
                var data = context.tblUsers.Where(x => x.Email_ID == user.Email_ID && x.Password == user.Password).FirstOrDefault();
                if (data != null)
                {
                    return data.FirstName + " " + data.LastName;
                }

                return "";
            }
        }

        public static int Register(UserModel user)
        {
            using (var context = new MCQ_Quiz_DBEntities())
            {
                var IfEmailAlreadyExists = context.tblUsers.Where(x => x.Email_ID == user.Email_ID).FirstOrDefault();

                if (IfEmailAlreadyExists == null)
                {
                    tblUser usertbl = new tblUser
                    {
                        FirstName = user.FirstName,
                        MiIddleName = user.MiIddleName,
                        LastName = user.LastName,
                        BirthDate = user.BirthDate,
                        Email_ID = user.Email_ID,
                        Type = user.Type,
                        Password = user.Password,
                        City = user.City,
                        State = user.State,
                        Country = user.Country,
                        IsActive = user.IsActive
                    };

                    context.tblUsers.Add(usertbl);
                    context.SaveChanges();

                    return usertbl.UserId;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
