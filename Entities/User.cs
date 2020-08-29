using System;
using Trululu.web.ViewModels;

namespace Trululu.web.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FisrtName { get; set; }

        public string Name { get; set; }

        public string Mail { get; set; }

        public string Phone { get; set; }

        public DateTime DateOfBirth { get; set; }
        
        public string Password { get; set; }

        public string Role { get; set; }

        public string Address { get; set; }

        public User()
        {
            this.Role = "ROLE_USER";
        }

        public User signUp(SignUpViewModel signUpViewModel)
        {
            this.FisrtName = signUpViewModel.FisrtName;
            this.Name = signUpViewModel.Name;
            this.Mail = signUpViewModel.Mail;
            this.Phone = signUpViewModel.Phone;
            this.DateOfBirth = signUpViewModel.DateOfBirth;
            this.Password = signUpViewModel.Password;
            this.Address = signUpViewModel.Address;

            return this;
        }
    }
}
