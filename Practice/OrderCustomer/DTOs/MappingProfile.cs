using AutoMapper;
using OrderCustomer.EF;

namespace OrderCustomer.DTOs
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerCreateDTO, Customer>();
            CreateMap<CustomerUpdateDTO, Customer>();

            CreateMap<Order, OrderDTO>();
            CreateMap<OrderCreateDTO, Order>();

        }

    }
}
