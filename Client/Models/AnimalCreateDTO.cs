using System;
using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class AnimalCreateDTO
    {
        [Required(ErrorMessage = "Необходима кличка")]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Необходима дата прибытия")]
        public DateTime ArrivalDate { get; set; }

        [Required(ErrorMessage = "Необходима стоимость содержания")]
        public decimal MoneyNeededPerMonth { get; set; }

        public int? ShelterId { get; set; }
    }
}
