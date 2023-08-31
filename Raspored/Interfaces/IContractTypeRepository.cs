using Raspored.Models;
using System.Linq;

namespace Raspored.Interfaces
{
    public interface IContractTypeRepository
    {
        IQueryable<ContractType> GetAllContractTypes();
        Position GetContractType(int contractTypeId);
        void AddContractTypen(ContractType contractType);
        void UpdateContractType(ContractType contractType);
        void DeleteContractType(ContractType contractType);
    }
}
