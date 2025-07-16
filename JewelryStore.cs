namespace Jewelry_Blazor_App
{
    public class JewelryStore
    {
        public string Address { get; set; }
        public List<Jewelry> JewelryList { get; set; } = new List<Jewelry>();

        public int JewelryCount => JewelryList.Count;

        public double TotalPrice => JewelryList.Sum(j => j.Price);
    }
}
