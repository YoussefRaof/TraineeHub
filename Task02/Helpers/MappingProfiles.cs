using AutoMapper;
using Task02.Models;
using Task02.ViewModels;

namespace Task02.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, ProductCustViewModel>()
                   .ForMember(d => d.CustomerId, o => o.MapFrom(s => s.Id))
                   .ForMember(d => d.CustomerName, o => o.MapFrom(s => s.Name))
                   .ForMember(d => d.Products, o => o.MapFrom(s => s.Produdcts.Select(p => p.Name)))
                   .PreserveReferences();
        }
    }
}
