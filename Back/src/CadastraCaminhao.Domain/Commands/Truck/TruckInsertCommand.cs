using CadastraCaminhao.Domain.Entities;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace CadastraCaminhao.Domain.Commands
{
    public class TruckInsertCommand : Notifiable, ICommand
    {
        public string Description { get; set; }
        public int Model { get; set; }
        public int ModelYear { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Description, "Description", "Description not be null.")
                    .IsNotNullOrEmpty(Model.ToString(), "Model", "Model not be null.")
                    .IsBetween(Model, 1, 2, "Model", "Model not valid.")
                    .IsBetween(ModelYear, DateTime.Now.Year, (DateTime.Now.Year + 1), "ModelYear", "The model year must be the current year or the year after.")
                );
        }
    }
}