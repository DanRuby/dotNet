using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    public interface IShelterDeleteService
    {
        public Task AsyncDelete(IShelterContainer shelterID);
    }
}
