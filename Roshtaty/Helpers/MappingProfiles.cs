using AutoMapper;
using Roshtaty.Core.Entites;
using Roshtaty.DTOS;
using System.Runtime.InteropServices;

namespace Roshtaty.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CategorisToReturnDTO>().ForMember(d=> d.MainSystem, O=> O.MapFrom(S =>S.MainSystem.MainSystemName));
            CreateMap<Disease, DiseasesToReturnDTO>().ForMember(d => d.Category, O => O.MapFrom(S => S.Category.CategoryName));
            CreateMap<Active_Ingredient, ActiveIngridientsToReturnDTO>().ForMember(d => d.Disease, O => O.MapFrom(S => S.Disease.DiseaseName));
            CreateMap<Trades, TradesToReturnDTO>().ForMember(d => d.Active_Ingredient, O => O.MapFrom(S => S.Active_Ingredient.ActiveIngredientName));
            CreateMap<Prescription, PrescriptionToReturnDTO>().ReverseMap();
            CreateMap<Prescription, PhoneNumberInputDTO>().ReverseMap();

        }
    }

}
