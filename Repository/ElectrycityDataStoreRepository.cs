using AutoMapper;
using ElectricitydataStore.Context;
using ElectricitydataStore.Models;

namespace ElectricitydataStore.Repository
{
    public class ElectrycityDataStoreRepository : IElectrycityDataStoreRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ElectrycityDataStoreRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task AddData(List<ElectricityModel> data)
        {

            foreach (var item in data)
            {
                await _context.AddAsync(item);
            }


        }
    }
}
