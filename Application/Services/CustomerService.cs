using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Identity;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public CustomerService(IRepository<Customer> customerRepository, UserManager<ApplicationUser> userManager)
        {
            _customerRepository = customerRepository;
            _userManager = userManager;
        }

        public async Task RegisterCustomerAsync(CustomerDTO customerDto, AddressDTO addressDto)
        {
            var user = new ApplicationUser
            {
                UserName = customerDto.Email,
                Email = customerDto.Email,
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                BirthDate = customerDto.BirthDate,
                Addresses = new List<Address>
                {
                    new Address
                    {
                        Street = addressDto.Street,
                        Number = addressDto.Number,
                        Complement = addressDto.Complement,
                        Neighborhood = addressDto.Neighborhood,
                        City = addressDto.City,
                        State = addressDto.State,
                        Country = addressDto.Country,
                        ZipCode = addressDto.ZipCode
                    }
                }
            };

            // Criar o ApplicationUser
            var result = await _userManager.CreateAsync(user, customerDto.Password);
            if (result.Succeeded)
            {
                // Criar o Customer vinculado ao ApplicationUser
                var customer = new Customer
                {
                    CustomerId = user.Id,
                };

                await _customerRepository.AddAsync(customer);
            }
        }
        
        [Authorize]
        public async Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync()
        {
            // Consultar diretamente o repositório de clientes e incluir os dados relacionados
            var customers = await _customerRepository.GetAllAsync(); // Não há mais necessidade de Include aqui

            // Usar LINQ para mapear os dados para CustomerDTO e AddressDTO
            var customerDTOs = customers.Select(customer => new CustomerDTO
            {
                FirstName = customer.ApplicationUser.FirstName,
                LastName = customer.ApplicationUser.LastName,
                Email = customer.ApplicationUser.Email,
                BirthDate = customer.ApplicationUser.BirthDate,
                Addresses = customer.ApplicationUser.Addresses.Select(a => new AddressDTO
                {
                    Street = a.Street,
                    Number = a.Number,
                    Complement = a.Complement,
                    Neighborhood = a.Neighborhood,
                    City = a.City,
                    State = a.State,
                    Country = a.Country,
                    ZipCode = a.ZipCode
                }).ToList() // Mapeia os endereços para o AddressDTO
            }).ToList();

            return customerDTOs;
        }

    }
}
