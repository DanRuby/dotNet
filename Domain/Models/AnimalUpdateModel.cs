using System;
using Domain.Contracts;

namespace Domain.Models
{
    public class AnimalUpdateModel : IShelterContainer, IAnimalIdentity
    {
        public int Id { get; set; }


        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime ArrivalDate { get; set; }

        public int? ShelterId { get; set; }

       
    }
}
