using Microsoft.EntityFrameworkCore;
using Raspored.Interfaces;
using Raspored.Models;
using System.Linq;

namespace Raspored.Repositories
{
    public class ContractTypeRepository : IContractTypeRepository
    {
        private readonly AppDbContext _context;

        public ContractTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddContractTypen(ContractType contractType)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteContractType(ContractType contractType)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ContractType> GetAllContractTypes()
        {
            throw new System.NotImplementedException();
        }

        public Position GetContractType(int contractTypeId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateContractType(ContractType contractType)
        {
            _context.Entry(contractType).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
