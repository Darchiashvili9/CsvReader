using System.ComponentModel.DataAnnotations;

namespace ElectricitydataStore.Models
{
    public class ElectrycityDataModel
    {
        [Key]
        public int Id { get; set; }
        public string Tinklas { get; set; } = null!;
        public string Pplus { get; set; } = null!;
        public string Pminus { get; set; } = null!;
    }
}
