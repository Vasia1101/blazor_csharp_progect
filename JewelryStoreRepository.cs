using System.Globalization;

namespace Jewelry_Blazor_App
{
    public class JewelryStoreRepository
    {
        public static List<JewelryStore> ReadStoresFromFile(string fileName)
        {
            var stores = new List<JewelryStore>();
            JewelryStore currentStore = null;
            foreach (var line in File.ReadAllLines(fileName))
            {
                if (line.StartsWith("Store:"))
                {
                    if (currentStore != null)
                        stores.Add(currentStore);
                    currentStore = new JewelryStore { Address = line.Substring(6).Trim() };
                }
                else if (!string.IsNullOrWhiteSpace(line) && currentStore != null)
                {
                    var parts = line.Split(',');
                    currentStore.JewelryList.Add(new Jewelry
                    {
                        Name = parts[0].Trim(),
                        Metal = parts[1].Trim(),
                        Weight = double.Parse(parts[2].Trim(), CultureInfo.InvariantCulture),
                        Price = double.Parse(parts[3].Trim(), CultureInfo.InvariantCulture)
                    });
                }
            }
            if (currentStore != null)
                stores.Add(currentStore);
            return stores;
        }

        public static void WriteUniqueMetals(List<JewelryStore> stores)
        {
            var metalCount = stores
                .SelectMany(s => s.JewelryList)
                .GroupBy(j => j.Metal)
                .Select(g => $"{g.Key}: {g.Count()}")
                .ToList();

            //File.WriteAllLines(outputFile, metalCount);
        }

    }
}
