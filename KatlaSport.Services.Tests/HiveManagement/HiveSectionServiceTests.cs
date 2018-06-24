using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoFixture.Xunit2;
using KatlaSport.DataAccess.ProductStoreHive;
using KatlaSport.Services.HiveManagement;
using Moq;
using Xunit;

namespace KatlaSport.Services.Tests.HiveManagement
{
    public class HiveSectionServiceTests
    {
        [Fact]
        public async void GetHiveSectionAsyncSuccessfull()
        {
            var productContext = new Mock<IProductStoreHiveContext>();
            productContext.Setup(p => p.Hives).ReturnsEntitySet(new List<StoreHive>());

            var userContext = new Mock<IUserContext>();
            userContext.Setup(u => u.UserId).Returns(1);

            var service = new HiveSectionService(productContext.Object, userContext.Object);

            var sections = await service.GetHiveSectionsAsync();
            Assert.NotNull(sections);
        }

        public async void GetHiveSectionsNotEmpty()
        {
            var productContext = new Mock<IProductStoreHiveContext>();
            productContext.Setup(p => p.Hives).ReturnsEntitySet(new List<StoreHive>());

            var userContext = new Mock<IUserContext>();
            userContext.Setup(u => u.UserId).Returns(1);

            var service = new HiveSectionService(productContext.Object, userContext.Object);

            var sections = await service.GetHiveSectionsAsync();
            Assert.Empty(sections);
        }

        [Fact]
        public async void CreateHiveSectionSuccesFull()
        {
            var productContext = new Mock<IProductStoreHiveContext>();
            productContext.Setup(p => p.Hives).ReturnsEntitySet(new List<StoreHive>());

            var userContext = new Mock<IUserContext>();
            userContext.Setup(u => u.UserId).Returns(1);

            var service = new HiveSectionService(productContext.Object, userContext.Object);

            var createRequest = new UpdateHiveSectionRequest()
            {
                Name = "newHive",
                Id = 1,
                Code = "111341"
            };
            await service.CreateHiveSectionAsync(createRequest);
            Assert.NotNull(service.GetHiveSectionsAsync());
        }

        [Fact]
        public async void UpdateHiveSectionSuccessfull()
        {
            var productContext = new Mock<IProductStoreHiveContext>();
            productContext.Setup(p => p.Hives).ReturnsEntitySet(new List<StoreHive>());

            var userContext = new Mock<IUserContext>();
            userContext.Setup(u => u.UserId).Returns(1);

            var service = new HiveSectionService(productContext.Object, userContext.Object);

            var updateRequest = new UpdateHiveSectionRequest()
            {
                Id = 1,
                Code = "11",
                Name = "name"
            };

            await service.UpdateHiveSectionAsync(1, updateRequest);
        }

        [Fact]
        public async void SetStatusToHiveSectionSuccessfull()
        {
            var productContext = new Mock<IProductStoreHiveContext>();
            productContext.Setup(p => p.Hives).ReturnsEntitySet(new List<StoreHive>());

            var userContext = new Mock<IUserContext>();
            userContext.Setup(u => u.UserId).Returns(1);

            var service = new HiveSectionService(productContext.Object, userContext.Object);
            await service.SetStatusAsync(1, true);

            var hiveSection = await service.GetHiveSectionAsync(1);
            Assert.True(hiveSection.IsDeleted);
        }
    }
}
