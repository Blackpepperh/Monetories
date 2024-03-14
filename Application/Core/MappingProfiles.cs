using Application.Categories;
using Application.SubCategories;
using Application.Transactions;
using Application.User;
using AutoMapper;
using Domain;

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

        }
    }
}