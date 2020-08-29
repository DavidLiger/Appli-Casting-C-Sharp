using System;
using System.Linq;
using Trululu.web.Entities;

namespace Trululu.web.Data
{
    public class UserRepository : IUserRepository
    {
        private TruluDbContext context = new TruluDbContext();

        public User FindById(int castingId)
        {
            return context.Users.FirstOrDefault(c => c.Id == castingId);
        }

        public User FindByAuth(string mail, string password)
        {
            return context.Users.FirstOrDefault(c => c.Mail == mail && c.Password == password);
        }

        public void Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
