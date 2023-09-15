using FakeItEasy;
using FluentAssertions;
using LibraryAPI.Controllers;
using LibraryAPI.DTOs;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LibraryAPI.Test
{
    public class BookControllerTests
    {
        private readonly IBooksService _service;

        public BookControllerTests()
        {
            _service = A.Fake<IBooksService>();
        }

        [Fact]
        public async Task TestGet()
        {
            // Arrange
            var booksmocked = new BooksGetDetailsResponse[]
            {
                new(){ Id = 1, Author = "autor", CreatedAt=DateTime.Now, Description ="blabla", Title = "naslov"},
                new(){ Id = 2, Author = "autor2", CreatedAt=DateTime.Now, Description ="blabla2", Title = "naslov2"}
            }.AsEnumerable();

            A.CallTo(() => _service.GetAsync()).Returns(booksmocked);
            var controller = new BooksController(_service);

            // Act
            var actionResult = await controller.Get();
            var result = actionResult.Result as OkObjectResult;
           

            // Assert
            actionResult.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
            

            Assert.Collection((result.Value as IEnumerable<BooksGetDetailsResponse>)!,
               r =>
               {
                   Assert.Equal(1, r.Id);
                   Assert.Equal("autor", r.Author);
                   Assert.Equal("naslov", r.Title);
               },
               r =>
               {
                   Assert.Equal(2, r.Id);
                   Assert.Equal("autor2", r.Author);
                   Assert.Equal("naslov2", r.Title);
               }
           );
        }

        [Fact]
        public async Task TestGetWithFakes()
        {
            // Arrange
            var books = A.Fake<IEnumerable<BooksGetDetailsResponse>>();
           
            A.CallTo(() => _service.GetAsync()).Returns(books);
            var controller = new BooksController(_service);

            // Act
            var actionResult = await controller.Get();
            var result = actionResult.Result;


            // Assert
            actionResult.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));

        }

        [Fact]
        public async Task TestGetDetailsOk()
        {
            // Arrange
            var booksmocked = new BooksGetDetailsResponse
            { 
                Id = 1, 
                Author = "autor", 
                CreatedAt=DateTime.Now, 
                Description ="blabla", 
                Title = "naslov"
            };

            A.CallTo(() => _service.GetDetailsAsync(1)).Returns(booksmocked);
            var controller = new BooksController(_service);

            // Act
            var actionResult = await controller.GetDetails(1);
            var result = actionResult.Result as OkObjectResult;

            // Assert
            actionResult.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));

            var value = result.Value as BooksGetDetailsResponse;
            
            Assert.Equal(1, value.Id);
            Assert.Equal("autor", value.Author);
            Assert.Equal("naslov", value.Title);
        }


        [Fact]
        public async Task TestGetDetailsNotFound()
        {
            // Arrange
            BooksGetDetailsResponse booksNull = null;

            A.CallTo(() => _service.GetDetailsAsync(5)).Returns(booksNull);
            var controller = new BooksController(_service);

            // Act
            var actionResult = await controller.GetDetails(5);
            var result = actionResult.Result;

            // Assert
            result.Should().BeOfType(typeof(NotFoundResult));

        }

    }
}
