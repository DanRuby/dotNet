using Domain.Contracts;

namespace Domain.Models
{
    public class AnimalIdentityModel : IAnimalIdentity
    {
        public int Id { get; }

        public AnimalIdentityModel(int id)
        {
            Id = id;
        }
    }
}
