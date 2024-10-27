using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Context;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly EcommerceSolutionDbContext _context;

        public CustomerRepository(EcommerceSolutionDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {            
            return await _context.Customers
                                 .Include(c => c.CustomerId) // Inclua a entidade ApplicationUser
                                 .ThenInclude(u => u)   // Inclua os endereços do ApplicationUser                                 
                                 .ToListAsync();
        }


        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
