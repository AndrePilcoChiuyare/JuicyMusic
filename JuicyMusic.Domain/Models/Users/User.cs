namespace JuicyMusic.Domain
{
    using System.ComponentModel.DataAnnotations;
    using JuicyMusic.Domain.Records;

    public class User
    {
        internal User(string name, string email, UserRole role)
        {
            Name = name;
            Email = email;
            Role = role;
        }

        public static User Create(string name, string email, UserRole role)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.");

            if (string.IsNullOrWhiteSpace(email) || !new EmailAddressAttribute().IsValid(email))
                throw new ArgumentException("Email is not valid.");

            if (role == null)
                throw new ArgumentNullException("User role cannot be empty.");

            return new User(name, email, role);
        }

        public string Name { get; private set; }

        public string Email { get; private set; }

        //? Role as string or record/enum?
        public UserRole Role { get; private set; }

        //? Include hashed password?

        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.");

            if (Name == name)
                return;

            Name = name;
        }

        public void ChangeEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !new EmailAddressAttribute().IsValid(email))
                throw new ArgumentException("Email is not valid.");

            if (Email == email)
                return;

            Email = email;
        }

        public void ChangeRole(UserRole role)
        {
            Role = role;
        }
    }
}