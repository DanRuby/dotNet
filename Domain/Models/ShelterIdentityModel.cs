using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ShelterIdentityModel : IShelterContainer
    {
        public int? ShelterId { get; }

        public ShelterIdentityModel(int Id)
        {
            ShelterId = Id;
        }
    }
}
