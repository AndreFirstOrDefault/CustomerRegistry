using AutoMapper;
using CustomerRegistry.Application.DTOs;
using CustomerRegistry.Domain.Entities;

namespace CustomerRegistry.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Customer, CustomerDTO>().ReverseMap();
    }
}
