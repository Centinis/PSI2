using Collibri.Controllers;
using Collibri.Dtos;
using Collibri.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Collibri.Tests.Controllers
{
    public class SectionControllerTests
    {
        [Theory]
        [ClassData(typeof(CreateSectionTestData))]
        public void CreateSection_Should_ReturnSection_WhenNameNonexistent(
            SectionDTO section, 
            SectionDTO? methodResult, 
            int? statusCode)
        {   
            //Assign
            var repository = new Mock<ISectionRepository>();
            var controller = new SectionController(repository.Object);
            repository
                .Setup(x => x.CreateSection(section)).Returns(methodResult);
            
            //Act
            var actual = controller.CreateSection(section);
            
            //Assert
            if (methodResult == null)
            {
                Assert.IsType<ConflictResult>(actual);
                Assert.Equal(statusCode, ((ConflictResult)actual).StatusCode);
            }
            else
            {
                Assert.IsType<OkObjectResult>(actual);
                Assert.Equal(statusCode, ((OkObjectResult)actual).StatusCode);
            }
        }

        [Theory]
        [ClassData(typeof(GetAllSectionsTestData))]
        public void GetAllSections_Should_ReturnAllSections(
            int roomId,
            IEnumerable<SectionDTO> list)
        {
            //Assign
            var repository = new Mock<ISectionRepository>();
            var controller = new SectionController(repository.Object);
            repository
                .Setup(x => x.GetAllSections(roomId)).Returns(list);
            
            //Act
            var actual = controller.GetAllSections(roomId) as ObjectResult;
            
            //Assert
            Assert.IsType<List<SectionDTO>>(actual?.Value);
            Assert.Equal(list, actual.Value);
        }
        
        [Theory]
        [ClassData(typeof(UpdateSectionByIdTestData))]
        public void UpdateSectionById_Should_ReturnOkAndUpdatedSection_WhenExists(
            SectionDTO section,
            SectionDTO? updatedSection,
            int sectionId,
            int statusCode)
        {
            //Assign
            var repository = new Mock<ISectionRepository>();
            var controller = new SectionController(repository.Object);
            repository
                .Setup(x => x.UpdateSectionById(section, sectionId)).Returns(updatedSection);
            
            //Act
            var actual = controller.UpdateSectionById(sectionId, section);

            //Assert
            if (updatedSection == null)
            {
                Assert.IsType<NotFoundResult>(actual);
                Assert.Equal(statusCode, ((NotFoundResult)actual).StatusCode);
            }
            else
            {
                Assert.IsType<OkObjectResult>(actual);
                Assert.Equal(statusCode, ((OkObjectResult)actual).StatusCode);
                Assert.Equal(updatedSection, ((ObjectResult)actual).Value);
            }
        }
        
        [Theory]
        [ClassData(typeof(DeleteSectionByIdTestData))]
        public void DeleteSectionById_Should_ReturnDeletedSection_IfExists(
            int sectionId, 
            SectionDTO? section, 
            int statusCode)
        {
            //Assign
            var repository = new Mock<ISectionRepository>();
            var controller = new SectionController(repository.Object);
            repository
                .Setup(x => x.DeleteSectionById(sectionId)).Returns(section);

            //Act
            var actual = controller.DeleteSectionById(sectionId);

            //Assert
            if (section == null)
            {
                Assert.IsType<NotFoundResult>(actual);
                Assert.Equal(statusCode, ((NotFoundResult)actual).StatusCode);
            }
            else
            {
                Assert.IsType<OkObjectResult>(actual);
                Assert.Equal(statusCode, ((OkObjectResult)actual).StatusCode);
                Assert.Equal(section, ((ObjectResult)actual).Value);
            }
        }
    }
}
