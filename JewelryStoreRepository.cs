using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Jewelry_Blazor_App
{
    public class JewelryStoreRepository
    {

        private readonly JewelryDbContext _db;

        public JewelryStoreRepository(JewelryDbContext db)
        {
            _db = db;
        }
        public List<JewelryStore> ReadStores()
        {
            return _db.Stores
                .Include(s => s.JewelryList)
                .ToList();
        }

        public List<string> GetUniqueMetals()
        {
            return _db.Jewelries
                .GroupBy(j => j.Metal)
                .Select(g => $"{g.Key}: {g.Count()}")
                .ToList();
        }

        public void AddJewelryToStore(int storeId, Jewelry jewelry)
        {
            var store = _db.Stores.Include(s => s.JewelryList).FirstOrDefault(s => s.Id == storeId);
            if (store != null)
            {
                store.JewelryList.Add(jewelry);
                _db.SaveChanges();
            }
        }

        public void AddStore(JewelryStore store)
        {
            _db.Stores.Add(store);
            _db.SaveChanges();
        }
        public void ClearDatabase()
        {
            _db.Jewelries.RemoveRange(_db.Jewelries);
            _db.Stores.RemoveRange(_db.Stores);
            _db.SaveChanges();
        }

        public void RemoveDuplicateStores()
        {
            var allStores = _db.Stores.ToList();

            var duplicates = allStores
                .GroupBy(s => s.Address.Trim().ToLower())
                .Where(g => g.Count() > 1)
                .SelectMany(g => g.Skip(1))
                .ToList();

            if (duplicates.Count > 0)
            {
                _db.Stores.RemoveRange(duplicates);
                _db.SaveChanges();
            }
        }
    }
}
