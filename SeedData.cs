using System.Linq;
namespace Jewelry_Blazor_App
{

    public static class SeedData
    {
        public static void Initialize(JewelryDbContext db)
        {
            if (db.Stores.Any())
            {
                return;
            }

            var store1 = new JewelryStore { Address = "Київ, вул. Перемоги, 10" };
            store1.JewelryList.Add(new Jewelry { Name = "Каблучка", Metal = "Срібло", Weight = 1.5, Price = 2000 });
            store1.JewelryList.Add(new Jewelry { Name = "Кулон", Metal = "Золото", Weight = 2.1, Price = 3500 });
            store1.JewelryList.Add(new Jewelry { Name = "Сережки", Metal = "Платина", Weight = 1.2, Price = 8000 });

            var store2 = new JewelryStore { Address = "Львів, вул. Городоцька, 45" };
            store2.JewelryList.Add(new Jewelry { Name = "Браслет", Metal = "Срібло", Weight = 3.3, Price = 2700 });
            store2.JewelryList.Add(new Jewelry { Name = "Каблучка", Metal = "Паладій", Weight = 2.0, Price = 5200 });

            var store3 = new JewelryStore { Address = "Одеса, просп. Шевченка, 12" };
            store3.JewelryList.Add(new Jewelry { Name = "Кулон", Metal = "Золото", Weight = 1.8, Price = 4100 });
            store3.JewelryList.Add(new Jewelry { Name = "Сережки", Metal = "Срібло", Weight = 2.6, Price = 1900 });

            var store4 = new JewelryStore { Address = "Дніпро, вул. Пушкіна, 19" };
            store4.JewelryList.Add(new Jewelry { Name = "Ланцюжок", Metal = "Титан", Weight = 4.2, Price = 2600 });
            store4.JewelryList.Add(new Jewelry { Name = "Каблучка", Metal = "Золото", Weight = 2.2, Price = 3700 });

            db.Stores.AddRange(store1, store2, store3, store4);
            db.SaveChanges();

        }
    }

}
