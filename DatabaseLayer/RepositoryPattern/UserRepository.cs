using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelClasses;
using DatabaseLayer.Interfaces;

namespace DatabaseLayer.RepositoryPattern
{
    public class UserRepository : IUserRepository
    {
        //  [CustomValidation]
        public UserModel login(UserModel user)
        {
            using (var context = new MCQ_Quiz_DBEntities())
            {
                var data = context.tblUsers.Where(x => x.Email_ID == user.Email_ID && x.Password == user.Password).Select(x => new UserModel
                {
                    UserId = x.UserId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email_ID = x.Email_ID

                }).FirstOrDefault();
                if (data != null)
                {
                    return data;
                }

                return data;
            }
        }

        public int Register(UserModel user)
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


        public UserModel GetOneUser(int id)
        {
            using (var context = new MCQ_Quiz_DBEntities())
            {
                var data = context.tblUsers.Where(x => x.UserId == id).Select(x => new UserModel
                {

                    FirstName = x.FirstName,
                    MiIddleName = x.MiIddleName,
                    LastName = x.LastName,
                    BirthDate = x.BirthDate,
                    Email_ID = x.Email_ID,
                    Type = x.Type,
                    Password = x.Password,
                    City = x.City,
                    State = x.State,
                    Country = x.Country,
                    IsActive = x.IsActive

                }).FirstOrDefault();

                return data;
            }
        }

        public List<UserModel> GetAllUser()
        {
            using (var context = new MCQ_Quiz_DBEntities())
            {
                var data = context.tblUsers.Select(x => new UserModel
                {
                    UserId = x.UserId,
                    FirstName = x.FirstName,
                    MiIddleName = x.MiIddleName,
                    LastName = x.LastName,
                    BirthDate = x.BirthDate,
                    Email_ID = x.Email_ID,
                    Type = x.Type,
                    Password = x.Password,
                    City = x.City,
                    State = x.State,
                    Country = x.Country,
                    IsActive = x.IsActive

                }).ToList();

                return data;
            }
        }

    }
}
