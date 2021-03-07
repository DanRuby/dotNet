using System;
using System.Threading.Tasks;
using BLL.Implementation;
using DataAccess.Contracts;
using Domain;
using Domain.Contracts;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using AutoFixture;

namespace BLLTest
{
    public class Tests
    {
        [Test]
        public async Task DoesNotThrow()
        {
            var shelterContainer = new Mock<IShelterContainer>();
            var shelter = new Shelter();
            var dataAccess = new Mock<IShelterDataAccess>();
            dataAccess.Setup(x => x.AsyncGet(shelterContainer.Object)).ReturnsAsync(shelter);
            var service = new ShelterValidateService(dataAccess.Object);

            var action = new Func<Task>(() => service.AsyncValidateShelter(shelterContainer.Object));

            await action.Should().NotThrowAsync<Exception>();
        }

       [Test]
        public async Task DoesThrow()
        { 
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            var shelterContainer = new Mock<IShelterContainer>();
            shelterContainer.Setup(x => x.ShelterId).Returns(id);
            var dataAccess = new Mock<IShelterDataAccess>();
            dataAccess.Setup(x => x.AsyncGet(shelterContainer.Object)).ReturnsAsync((Shelter)null);
            var getService = new ShelterValidateService(dataAccess.Object);

            var action = new Func<Task>(() => getService.AsyncValidateShelter(shelterContainer.Object));

            await action.Should().ThrowAsync<InvalidOperationException>($"В базе не было найдено приюта с Id ={id}");
        }
    }
}