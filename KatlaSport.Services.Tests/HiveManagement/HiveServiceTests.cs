using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using KatlaSport.DataAccess.ProductStoreHive;
using KatlaSport.Services.HiveManagement;
using KatlaSport.Services.Tests.CustomMock;
using Moq;
using Xunit;

namespace KatlaSport.Services.Tests.HiveManagement
{
    public class HiveServiceTests
    {
        [Fact]
        public async void GetHivesAsyncReturnsNotNull()
        {
            var productContext = new Mock<IProductStoreHiveContext>();
            productContext.Setup(p => p.Hives).ReturnsEntitySet(new List<StoreHive>());

            var userContext = new Mock<IUserContext>();
            userContext.Setup(u => u.UserId).Returns(1);

            var service = new HiveService(productContext.Object, userContext.Object);

            var hives = await service.GetHivesAsync();

            Assert.NotNull(hives);
        }

        [Fact]
        public async void GetHivesAsyncReturnsEmpty()
        {
            var productContext = new Mock<IProductStoreHiveContext>();
            productContext.Setup(p => p.Hives).ReturnsEntitySet(new List<StoreHive>());

            var userContext = new Mock<IUserContext>();
            userContext.Setup(u => u.UserId).Returns(1);

            var service = new HiveService(productContext.Object, userContext.Object);

            var hives = await service.GetHivesAsync();

            Assert.Empty(hives);
        }

        [Theory]
        [AutoMoqData]
        public async Task GetHiveAsync_TenItemReturned([Frozen] Mock<IProductStoreHiveContext> context, HiveService service, IFixture fixture)
        {
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var data = fixture.CreateMany<StoreHive>(10).ToList();
            context.Setup(c => c.Hives).ReturnsEntitySet(data);
            context.Setup(s => s.Sections).ReturnsEntitySet(new List<StoreHiveSection>());

            var hives = await service.GetHivesAsync();

            hives.Count.Should().Be(data.Count);
        }

        [Fact]
        public async void CreateHiveSuccesFull()
        {
            var productContext = new Mock<IProductStoreHiveContext>();
            productContext.Setup(p => p.Hives).ReturnsEntitySet(new List<StoreHive>());

            var userContext = new Mock<IUserContext>();
            userContext.Setup(u => u.UserId).Returns(1);

            var dbHive = new StoreHive
            {
                Id = 1,
                Code = "12314321"
            };

            var myProductMock =
                new ProductStoreContextMock(new FakeEntitySet<StoreHive>(new List<StoreHive> { dbHive }), null, null);

            var service = new HiveService(productContext.Object, userContext.Object);

            var createRequest = new UpdateHiveRequest
            {
                Name = "newHive",
                Address = "address",
                Code = "111341"
            };
            await service.CreateHiveAsync(createRequest);
            //Assert.NotNull(service.GetHivesAsync());
        }

        [Theory]
        [AutoMoqData]
        public async Task SetStatusAsync_SetDeletedInFirstItem([Frozen] Mock<IProductStoreHiveContext> context, HiveService service, IFixture fixture)
        {
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var hives = fixture.CreateMany<StoreHive>(10).ToList();
            hives.First().IsDeleted = false;
            context.Setup(s => s.Hives).ReturnsEntitySet(hives);
            context.Setup(s => s.Sections).ReturnsEntitySet(new List<StoreHiveSection>());

            await service.SetStatusAsync(hives.First().Id, true);
        }

        [Theory]
        [AutoMoqData]
        public async void DeleteHiveSuccessfull(IFixture fixture, HiveService service,
            [Frozen] Mock<IProductStoreHiveContext> productContext, [Frozen] Mock<IUserContext> userContext)
        {
            var hives = fixture.CreateMany<StoreHive>(5).ToList();
            productContext.Setup(p => p.Hives).ReturnsEntitySet(hives);

            await service.DeleteHiveAsync(1);
        }

        [Theory]
        [AutoMoqData]
        public async Task DeleteHiveAsync_RequestedResourceNotFoundExceptionThrown([Frozen] Mock<IProductStoreHiveContext> context, HiveService service)
        {
            context.Setup(s => s.Hives).ReturnsEntitySet(new StoreHive[] { });

            var exception = await Assert.ThrowsAsync<RequestedResourceNotFoundException>(
                () => service.DeleteHiveAsync(0));

            Assert.Equal(typeof(RequestedResourceNotFoundException), exception.GetType());
        }

        [Fact]
        public async void UpdateHiveSuccessfull()
        {
            var productContext = new Mock<IProductStoreHiveContext>();
            productContext.Setup(p => p.Hives).ReturnsEntitySet(new List<StoreHive>());

            var userContext = new Mock<IUserContext>();
            userContext.Setup(u => u.UserId).Returns(1);

            var service = new HiveService(productContext.Object, userContext.Object);

            var updateRequest = new UpdateHiveRequest
            {
                Address = "address",
                Code = "11",
                Name = "name"
            };

            await service.UpdateHiveAsync(1, updateRequest);
        }

        [Theory]
        [AutoMoqData]
        public async Task UpdateHiveSectionAsync_RequestedResourceNotFoundExceptionThrown([Frozen] Mock<IProductStoreHiveContext> context, HiveSectionService service, IFixture fixture)
        {
            context.Setup(s => s.Sections).ReturnsEntitySet(new StoreHiveSection[] { });

            var exception = await Assert.ThrowsAsync<RequestedResourceNotFoundException>(
                () => service.UpdateHiveSectionAsync(0, fixture.Create<UpdateHiveSectionRequest>()));

            Assert.Equal(typeof(RequestedResourceNotFoundException), exception.GetType());
        }

        [Fact]
        public async void SetStatusToHiveSuccessfull()
        {
            var productContext = new Mock<IProductStoreHiveContext>();
            productContext.Setup(p => p.Hives).ReturnsEntitySet(new List<StoreHive>());

            var userContext = new Mock<IUserContext>();
            userContext.Setup(u => u.UserId).Returns(1);

            var service = new HiveService(productContext.Object, userContext.Object);
            await service.SetStatusAsync(1, true);

            var hive = await service.GetHiveAsync(1);
            Assert.True(hive.IsDeleted);
        }
    }
}
