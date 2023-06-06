using AutoMapper;
using ElectricitydataStore.Models;

namespace ElectricitydataStore.Mappings
{
    public class ElectricityDataModelProfile: Profile
    {
        public ElectricityDataModelProfile()
        {
            CreateMap<ElectricityModel, ElectrycityDataModel>();
        }
    }
}
