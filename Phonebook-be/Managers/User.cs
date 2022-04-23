using Phonebook_be.Models;
using Phonebook_be.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook_be.Managers
{
    public interface IUser
    {
        (Users user, string error) CreateUser(string name, string num);
        void DeleteUser(int id);
        List<Users> UserList();
        Users GetUserById(int id);
        void UpdateUser(Users user, Users newDetail);
    }

    public class User : IUser
    {
        private readonly IDatabaseContext db;
        public User(IDatabaseContext databaseContext)
        {
            db = databaseContext;
        }

        public (Users user, string error) CreateUser(string name, string num)
        {
            var user = new Users()
            {
                fullName = name,
                number = num,
            };
            db.Insert(user);
            return (user, null);
        }

        public List<Users> UserList()
        {
            var users = db.Query<Users>().ToList();
            return users;
        }

        public void DeleteUser(int id)
        {
            var department = db.Query<Users>().Where(a => a.userID == id).FirstOrDefault();
            db.Delete(department);
        }

        public Users GetUserById(int id)
        {
            var department = db.Query<Users>().Where(a => a.userID == id).FirstOrDefault();
            return department;
        }

        public void UpdateUser(Users user, Users newDetail)
        {
            user.fullName = newDetail.fullName;
            user.number = newDetail.number;
            db.Update(user);
        }

    }
}
