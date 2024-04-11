using AutoMapper;
using Domain;
using Domain.DTOs;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<AppUser, AppUserDto>();
            CreateMap<Currency, CurrencyDto>();
            CreateMap<Account, AccountDto>()
                .ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => src.AppUser))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency));
            CreateMap<TransactionHeader, TransactionHeaderDto>();

        }
    }
}