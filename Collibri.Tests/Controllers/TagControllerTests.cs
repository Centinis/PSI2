using Collibri.Controllers;
using Collibri.Dtos;
using Collibri.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Collibri.Tests.Controllers
{
    public class TagControllerTests
    {
        [Theory]
        [ClassData(typeof(TagControllerTestData.CreateTagTestData))]
        public void CreateTagTest(
            TagDTO tag,
            TagDTO expected)
        {
            var repository = new Mock<ITagRepository>();
            var controller = new TagController(repository.Object);
            repository
                .Setup(x => x.CreateTag(tag)).Returns(expected);
            
            var actual = controller.CreateTag(tag);
            
            Assert.IsType<OkObjectResult>(actual);
            Assert.Equivalent(expected, ((OkObjectResult)actual).Value);
        }
        
        [Theory]
        [ClassData(typeof(TagControllerTestData.GetAllTagsTestData))]
        public void GetAllTagsTest(
            int roomId,
            IEnumerable<TagDTO> list)
        {
            var repository = new Mock<ITagRepository>();
            var controller = new TagController(repository.Object);
            repository
                .Setup(x => x.GetAllTagsInRoom(roomId)).Returns(list);
            
            var actual = controller.GetAllTagsInRoom(roomId);

            Assert.IsType<OkObjectResult>(actual);
            Assert.Equivalent(list, ((OkObjectResult)actual).Value);
        }

        [Theory]
        [ClassData(typeof(TagControllerTestData.UpdateTagTestData))]
        public void UpdateTagTest(
            Guid tagId,
            TagDTO update,
            TagDTO? expected,
            int statusCode
        )
        {
            var repository = new Mock<ITagRepository>();
            var controller = new TagController(repository.Object);
            repository
                .Setup(x => x.UpdateTag(tagId, update)).Returns(expected);
            
            var actual = controller.UpdateTag(tagId, update);
            
            if (expected == null)
            {
                Assert.IsType<NotFoundResult>(actual);
                Assert.Equal(statusCode, ((NotFoundResult)actual).StatusCode);
            }
            else
            {
                Assert.IsType<OkObjectResult>(actual);
                Assert.Equal(statusCode, ((OkObjectResult)actual).StatusCode);
            }
        }
        
        [Theory]
        [ClassData(typeof(TagControllerTestData.DeleteTagTestData))]
        public void DeleteTagTest(
            Guid tagId,
            TagDTO? expected)
        {
            var repository = new Mock<ITagRepository>();
            var controller = new TagController(repository.Object);
            repository
                .Setup(x => x.DeleteTag(tagId)).Returns(expected);

            var actual = controller.DeleteTag(tagId);

            if (expected == null)
            {
                Assert.IsType<NotFoundResult>(actual);
            }
            else
            {
                Assert.IsType<OkObjectResult>(actual);
                Assert.Equivalent(expected, ((OkObjectResult)actual).Value);
            }
        }
    }
}

