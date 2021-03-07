using System;
using Domain;
using Domain.Models;
using System.Threading.Tasks;
using AutoFixture;
using BLL.Contracts;
using BLL.Implementation;
using DataAccess.Contracts;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BLLTest
{
    public class AnimalCreateServiceTest
    {
        [Test]
        public async Task CreateSuccess()
        {
            var animal = new AnimalUpdateModel();
            var expected = new Animal();
            var shelterGetService = new Mock<IShelterValidateService>();
            shelterGetService.Setup(x => x.AsyncValidateShelter(animal));
            var animalDataAccess = new Mock<IAnimalDataAccess>();
            animalDataAccess.Setup(x => x.AsyncInsert(animal)).ReturnsAsync(expected);
            var animalGetService = new AnimalCreateService(animalDataAccess.Object, shelterGetService.Object);

            var result = await animalGetService.AsyncCreate(animal);

            result.Should().Be(expected);
        }

        [Test]
        public async Task ThowsError()
        {
            var fixture = new Fixture();
            var animal = new AnimalUpdateModel();
            var expected = fixture.Create<string>();
            var shelterGetService = new Mock<IShelterValidateService>();
            shelterGetService
                .Setup(x => x.AsyncValidateShelter(animal))
                .Throws(new InvalidOperationException(expected));
            var animalDataAccess = new Mock<IAnimalDataAccess>();
            var animalGetService = new AnimalCreateService(animalDataAccess.Object, shelterGetService.Object);

            var action = new Func<Task>(() => animalGetService.AsyncCreate(animal));

            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            animalDataAccess.Verify(x => x.AsyncInsert(animal), Times.Never);
        }
    }
}
