using Flunt.Notifications;
using Flunt.Validations;

namespace CadastraCaminhao.Domain.Commands
{
    public class UserValidateAccessCommand : Notifiable, ICommand
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Login, "Login", "Login not be null.")
                    .IsNotNullOrEmpty(Password, "Password", "Password not be null.")
            );
        }
    }
}