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

        /// <summary>
        /// Store data into a database grouped by Tinklas(Regionas) field and apply aggregation:
        /// Sum P + fields
        /// Sum P - fields
        /// </summary>
        public async Task AddData(List<ElectrycityDataModel> data)
        {
            var grouppedData = data.GroupBy(x => x.Tinklas).Select(x => new ElectrycityDataModel
            {
                Tinklas = x.Key,
                Pplus = x.Sum(s => s.Pplus),
                Pminus = x.Sum(_ => _.Pminus),
            }).ToList();





            if (grouppedData is not null)
                await _context.AddRangeAsync(grouppedData);


            await _context.SaveChangesAsync();
        }
    }
}
