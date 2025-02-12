using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{

    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // Adapter
    public class CustomerMapper
    {
        public Customer Map(CustomerDto dto)
        {
            return new Customer { Id = dto.Id, Name = $"{dto.FirstName} {dto.LastName}" };
        }

    }

    internal class CustomersController
    {

        public void Post(CustomerDto dto)
        {
            CustomerMapper mapper = new CustomerMapper();
            Customer customer = mapper.Map(dto);

        }
    }
}
