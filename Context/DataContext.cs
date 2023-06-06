using ElectricitydataStore.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectricitydataStore.Context
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ElectrycityDataModel> Electrycity { get; set;}
    }
}
