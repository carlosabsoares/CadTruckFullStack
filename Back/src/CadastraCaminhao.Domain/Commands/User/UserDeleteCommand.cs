using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace CadastraCaminhao.Domain.Commands
{
    public class UserDeleteCommand : Notifiable, ICommand
    {
        public string Id { get; set; }

        public UserDeleteCommand(string id)
        {
            Id = id;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Id, "Id", "Id not be null.")
                    .IsTrue(Guid.TryParse(Id, out _), "Id", "This Id is not a valid guid.")
            );
        }
    }
}