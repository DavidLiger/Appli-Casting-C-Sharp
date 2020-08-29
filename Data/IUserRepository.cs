using System;
using Trululu.web.Entities;

namespace Trululu.web.Data
{
    public interface IUserRepository
    {
        public User FindById(int castingId);

        public User FindByAuth(string mail, string password);

        public void Add(User user);
    }
}
