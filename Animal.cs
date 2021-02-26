using System;
using Domain.Contracts;

namespace Domain
{
    public class Animal: IShelterContainer
    {
        public int Id { get; set; }
                
        public decimal MoneyNeededPerMonth { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; } 

        public DateTime ArrivalDate { get; set; }

        public Shelter Shelter { get; set; }

        public int? ShelterId => Shelter.Id;

    }
}
