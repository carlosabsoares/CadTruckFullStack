using Flunt.Notifications;
using Flunt.Validations;

namespace CadastraCaminhao.Domain.Commands
{
    public class UserInsertCommand : Notifiable, ICommand
    {
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
                    .IsNotNullOrEmpty(Login, "Login", "Login not be null.")
                    .IsNotNullOrEmpty(Password, "Password", "Password not be null.")
                    .IsNotNullOrEmpty(Name, "Name", "Name not be null.")
                    .IsEmail(Email, "Email", "Email not valid.")
            );
        }
    }
}
