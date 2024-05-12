
using AutoMapper;

public class DomainToDtoProfile : Profile
{
    public DomainToDtoProfile()
    {
        CreateMap<Products.Business.Domain.Product, Products.Common.Dtos.ProductDto>();
    }
}

