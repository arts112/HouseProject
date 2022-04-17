using House.Core.Domain;
using House.Core.Dtos;
using System;
using System.Threading.Tasks;

namespace House.Core.ServiceInterface
{
    public interface IHouseService : IApplicationService
    {
        Task<Houses> Add(HouseDto dto);

        Task<Houses> Delete(Guid id);

        Task<Houses> Update(HouseDto dto);

        Task<Houses> GetAsync(Guid id);
    }
}
