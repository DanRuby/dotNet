using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;

namespace BLL.Contracts
{
    public interface IAnimalDeleteService
    {
        public Task DeleteAsynnc(IAnimalIdentity animalId); 
    }
}
