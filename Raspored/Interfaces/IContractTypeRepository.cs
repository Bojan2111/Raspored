using Raspored.Models;
using System.Linq;

namespace Raspored.Interfaces
{
    public interface IContractTypeRepository
    {
        IQueryable<ContractType> GetAllContractTypes();
        ContractType GetContractType(int contractTypeId);
        void AddContractType(ContractType contractType);
        void UpdateContractType(ContractType contractType);
        void DeleteContractType(ContractType contractType);
    }
}
