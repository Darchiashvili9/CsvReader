using System.ComponentModel.DataAnnotations;

namespace ElectricitydataStore.Models
{
    public class ElectrycityDataModel
    {
        [Key]
        public int Id { get; set; }
        public string Tinklas { get; set; } = null!;
        public decimal? Pplus { get; set; } = 0;
        public decimal? Pminus { get; set; } = 0;
    }
}
