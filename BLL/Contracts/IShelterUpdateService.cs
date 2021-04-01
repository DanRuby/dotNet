using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Models;

namespace BLL.Contracts
{
    public interface IShelterUpdateService
    {
        public Task<Shelter> AsyncUpdate(ShelterUpdateModel shelter);
    }
}
