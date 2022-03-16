using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRatesBL.Models
{
    public partial class MovieRatesDBContext
    {
        public User GetUser(string userName,string pass)
        {
            return this.Users.Where(u => u.UserName == userName && u.Pass == pass).FirstOrDefault();
        }
        public void Register(User u)
        {
            this.Users.Add(u);
            this.SaveChanges();
        }
        public bool EmailExist(string email)
        {
            return this.Users.Count(u => u.Email == email) > 0;
        }
        public bool UserNameExist(string userName)
        {
            return this.Users.Count(u => u.UserName == userName) > 0;
        }
    }
}
