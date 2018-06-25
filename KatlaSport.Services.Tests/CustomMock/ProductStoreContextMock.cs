using System;
using System.Threading;
using System.Threading.Tasks;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ProductStoreHive;

namespace KatlaSport.Services.Tests.CustomMock
{
    public class ProductStoreContextMock : IProductStoreHiveContext
    {
        public ProductStoreContextMock(IEntitySet<StoreHive> hives, IEntitySet<StoreHiveSection> sections, IEntitySet<StoreHiveSectionCategory> categories)
        {
            Hives = hives;
            Sections = sections;
            Categories = categories;
        }

        public IEntitySet<StoreHive> Hives { get; set; }

        public IEntitySet<StoreHiveSection> Sections { get; set; }

        public IEntitySet<StoreHiveSectionCategory> Categories { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return 0;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return 0;
        }
    }
}
