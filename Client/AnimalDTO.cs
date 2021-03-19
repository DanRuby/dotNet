using System;

namespace Client
{
    public class AnimalDTO
    {
        public int Id { get; set; }

        public decimal MoneyNeededPerMonth { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime ArrivalDate { get; set; }

        public ShelterDTO Shelter { get; set; }
    }
}
