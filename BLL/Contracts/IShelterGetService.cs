using Domain;
using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    public interface IShelterGetService
    {
        Task<IEnumerable<Shelter>> AsyncGet();

        Task<Shelter> AsyncGet(IShelterContainer shelter);
    }
}
