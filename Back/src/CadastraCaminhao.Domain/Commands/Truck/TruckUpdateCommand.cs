﻿using CadastraCaminhao.Domain.Entities;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace CadastraCaminhao.Domain.Commands
{
    public class TruckUpdateCommand : Notifiable, ICommand
    {
        public string Id { get; set; }
        public int Model { get; set; }
        public int ModelYear { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }


        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Id, "Id", "Id not be null.")
                    .IsTrue(Guid.TryParse(Id, out _), "Id", "This Id is not a valid guid.")
                    .IsBetween(ModelYear, DateTime.Now.Year, (DateTime.Now.Year + 1), "ModelYear", "The model year must be the current year or the year after.")
                    .IsNotNullOrEmpty(Model.ToString(), "Model", "Model not be null.")
                    .IsTrue(EnumModel.IsDefined(typeof(EnumModel), Model), "Model", "Model not valid.")
            );
        }
    }
}