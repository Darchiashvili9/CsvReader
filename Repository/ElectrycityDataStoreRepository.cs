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

            var list = _mapper.Map<ElectrycityDataModel>(data);








            //Store data into a database grouped by Tinklas (Regionas) field and apply aggregation:
            // o Sum P + fields
            //o Sum P - fields

            var grouppedData = data.GroupBy(x => x.Tinklas).ToList();

         //   var pPlus=grouppedData.Sum(e=>e.ppl)




            if (data is not null)
                await _context.AddRangeAsync(data);


            await _context.SaveChangesAsync();
        }
    }
}
