using ElectricitydataStore.Models;

namespace ElectricitydataStore.Repository
{
    public interface IElectrycityDataStoreRepository
    {
        Task AddData(List<ElectrycityDataModel> data);
    }
}
