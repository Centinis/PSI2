using System.Net;
using System.Text;
using System.Text.Json;
using Collibri.Data;
using Collibri.Dtos;
using Collibri.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Collibri.Tests.IntegrationTests.Posts
{
    public class PostControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public PostControllerIntegrationTests(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetPosts_EndpointReturnsSuccessAndCorrectContentType()
        {
            //Assign
            var sectionId = 1;
            var client = _factory.CreateClient();
            
            //Act
            var response = await client.GetAsync($"/v1/posts?sectiondId={sectionId}");
            var content = await response.Content.ReadAsStringAsync();
            
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CreatePost_ReturnsOkWithCreatedPost()
        {
            var postDto = new
            {
                id = Guid.NewGuid(),
                creatorUsername = "testCreator",
                title = "Test Post",
                sectionId = 1,
                likeCount = 0,
                dislikeCount = 0,
                description = "This is a test post.",
                creationDate = DateTime.UtcNow,
                lastUpdatedDate = DateTime.UtcNow,
            };
            
            var jsonContent = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(postDto),
                Encoding.UTF8,
                "application/json"
            );
            
            var client = _factory.CreateClient();

            var response = await client.PostAsync("/v1/posts", jsonContent);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        
        [Fact]
        public async Task CreatePost_ReturnsBadRequest()
        {
            var postDto = new
            {
                id = Guid.NewGuid(),
                creatorUsername = "testCreator",
                title = "Test Post",
                sectionId = 1,
                likeCount = 0,
                dislikeCount = 0,
                creationDate = DateTime.UtcNow,
                lastUpdatedDate = DateTime.UtcNow,
            };
            
            var jsonContent = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(postDto),
                Encoding.UTF8,
                "application/json"
            );
            
            var client = _factory.CreateClient();

            var response = await client.PostAsync("/v1/posts", jsonContent);
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        
        [Fact]
        public async Task UpdatePost_ReturnsOkRequestWithUpdatedPost()
        {
            var postDto = new
            {
                id = Guid.NewGuid(),
                creatorUsername = "testCreator",
                title = "Test Post",
                sectionId = 1,
                likeCount = 0,
                dislikeCount = 0,
                description = "This is a test post.",
                creationDate = DateTime.UtcNow,
                lastUpdatedDate = DateTime.UtcNow,
            };
            var postId = Guid.NewGuid();
            var jsonContent = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(postDto),
                Encoding.UTF8,
                "application/json"
            );
            
            var client = _factory.CreateClient();

            var response = await client.PostAsync($"/v1/posts?postId={postId}", jsonContent);
            
            var entry = JsonSerializer.Deserialize<PostDTO>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true, }
            );
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("Test Post", entry?.Title);
        }
        
        [Fact]
        public async Task DeletePost_ReturnsBadRequest()
        {
            var postId = Guid.NewGuid();
            
            var client = _factory.CreateClient();

            var response = await client.DeleteAsync($"/v1/posts?postId={postId}");
            
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }   
}