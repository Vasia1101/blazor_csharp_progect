namespace Jewelry_Blazor_App
{
    public class Jewelry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Metal { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
        public int JewelryStoreId { get; set; }
        public JewelryStore JewelryStore { get; set; }
    }
}
