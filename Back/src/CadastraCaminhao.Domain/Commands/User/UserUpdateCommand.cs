using Flunt.Notifications;
using Flunt.Validations;

namespace CadastraCaminhao.Domain.Commands
{
    public class UserUpdateCommand : Notifiable, ICommand
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Id, "Id", "Id not be null.")
                    .IsNotNullOrEmpty(Login, "Login", "Login not be null.")
                    .IsNotNullOrEmpty(Password, "Password", "Password not be null.")
                    .IsNotNullOrEmpty(Role.ToString(), "Role", "Role not be null.")
                    .IsNotNullOrEmpty(Name, "Name", "Name not be null.")
                    .IsNotNullOrEmpty(Email, "Email", "Email not be null.")
                    .IsEmail(Email, "Email", "Email not valid.")
            );
        }
    }
}
