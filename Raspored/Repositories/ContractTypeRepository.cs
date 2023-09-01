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

        public void AddContractType(ContractType contractType)
        {
            _context.ContractTypes.Add(contractType);
            _context.SaveChanges();
        }

        public void DeleteContractType(ContractType contractType)
        {
            _context.ContractTypes.Remove(contractType);
            _context.SaveChanges();
        }

        public IQueryable<ContractType> GetAllContractTypes()
        {
            return _context.ContractTypes.AsQueryable();
        }

        public ContractType GetContractType(int contractTypeId)
        {
            return _context.ContractTypes.FirstOrDefault(x => x.Id == contractTypeId);
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
