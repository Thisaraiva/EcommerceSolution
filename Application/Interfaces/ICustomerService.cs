using Application.DTOs;

namespace Application.Interfaces
{
    public interface ICustomerService
    {
        Task RegisterCustomerAsync(CustomerDTO userDto, AddressDTO addressDto);
        //Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync();
    }
}
