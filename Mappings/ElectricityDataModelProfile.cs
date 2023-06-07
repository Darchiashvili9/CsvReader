using AutoMapper;
using AutoMapper.Internal.Mappers;
using ElectricitydataStore.Models;
using System.ComponentModel;

namespace ElectricitydataStore.Mappings
{
    public class ElectricityDataModelProfile : Profile
    {
        public ElectricityDataModelProfile()
        {
            CreateMap<string, decimal>().ConvertUsing(s => Convert.ToDecimal(s));


            CreateMap<ElectricityModel, ElectrycityDataModel>()
                
                .ForMember(d => d.Pplus, opt => opt?.MapFrom(src => src.Pplus))
                .ForMember(d => d.Pminus, opt => opt?.MapFrom(src => src.Pminus));
               
        }


    }
}
