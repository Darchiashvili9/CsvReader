using AutoMapper;
using ElectricitydataStore.Context;
using ElectricitydataStore.Models;

namespace ElectricitydataStore.Repository
{
    public class ElectrycityDataStoreRepository : IElectrycityDataStoreRepository
    {
        private readonly DataContext _context;

        public ElectrycityDataStoreRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddData(List<ElectrycityDataModel> data)
        {
            //Store data into a database grouped by Tinklas (Regionas) field and apply aggregation:
            // o Sum P + fields
            //o Sum P - fields

            var grouppedData = data.Where(e => e.Obt_Pavadinmas == "Butas");




            if (data is not null)
                await _context.AddRangeAsync(data);


            await _context.SaveChangesAsync();
        }
    }
}
