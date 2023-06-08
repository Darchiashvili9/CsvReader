using AutoMapper;
using AutoMapper.Internal.Mappers;
using ElectricitydataStore.Models;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;

namespace ElectricitydataStore.Mappings
{
    public class ElectricityDataModelProfile : Profile
    {
        public ElectricityDataModelProfile()
        {


            CreateMap<ElectricityModel, ElectrycityDataModel>()
                .ForMember(d => d.Pplus, o => o.MapFrom(s => s.Pplus))
                .ForMember(d => d.Pminus, o => o.MapFrom(s => s.Pminus))
                .ForAllMembers(o => o.Condition((src, dest, value) => value != null));







            //CreateMap<ElectricityModel, ElectrycityDataModel>()

            //    .ForMember(d => d.Pplus, opt => opt?.MapFrom(src => string.IsNullOrWhiteSpace(src.Pplus.Length.ToString()) ? default(decimal) : decimal.Parse(src.Pplus)))

            //    .ForMember(d => d.Pminus, opt => opt?.MapFrom(src => string.IsNullOrWhiteSpace(src.Pminus.Length.ToString()) ? default(decimal) : decimal.Parse(src.Pminus)));

        }



    }
}
