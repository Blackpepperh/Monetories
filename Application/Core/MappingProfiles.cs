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
            CreateMap<SubCategory, SubCategoryDto>();
            CreateMap<AppUser, AppUserDto>();
            CreateMap<Transaction, TransactionDto>()
                .ForMember(dest => dest.SubCategory, opt => opt.MapFrom(src => src.SubCategory))
                .ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => src.AppUser));
            CreateMap<Currency, CurrencyDto>();
            CreateMap<Account, AccountDto>()
                .ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => src.AppUser))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency));

        }
    }
}