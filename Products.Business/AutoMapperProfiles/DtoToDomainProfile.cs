
using AutoMapper;

public class DtoToDomainProfile : Profile
{

    public DtoToDomainProfile()
    {
        CreateMap<Products.Common.Dtos.ProductDto, Products.Business.Domain.Product>();
    }
}
