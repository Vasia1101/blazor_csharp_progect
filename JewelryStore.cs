using System.ComponentModel.DataAnnotations.Schema;

namespace Jewelry_Blazor_App
{
    public class JewelryStore
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public List<Jewelry> JewelryList { get; set; } = new();
        [NotMapped]
        public string NewJewelryName { get; set; }
        [NotMapped]
        public string NewJewelryMetal { get; set; }
        [NotMapped]
        public double NewJewelryWeight { get; set; }
        [NotMapped]
        public double NewJewelryPrice { get; set; }
        [NotMapped]
        public bool ShowAddForm { get; set; }
        public double TotalPrice => JewelryList.Sum(j => j.Price);
    }
}
