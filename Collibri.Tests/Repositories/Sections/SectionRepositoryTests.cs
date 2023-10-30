using Collibri.Models;
using Collibri.Repositories.DataHandling;
using Collibri.Repositories.FileBasedImplementation;

namespace Collibri.Tests.Repositories.Sections
{
    public class SectionRepositoryTests
    {
        [Theory]
        [ClassData(typeof(CreateSectionTestData))]
        void CreateSection_Should_ReturnSection_WhenNonExistent(
            Section section,
            Section? expected,
            List<Section> list)
        {   
            //Assign
            var dataHandler = new Mock<IDataHandler>();
            var repository = new FbSectionRepository(dataHandler.Object);
            dataHandler
                .Setup(x => x.GetAllItems<Section>(ModelType.Sections)).Returns(list);

            //Act
            var actual = repository.CreateSection(section);
            if (actual != null)
            {
                expected = section;
                expected.SectionId = actual.SectionId;
            }
            
            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(GetAllSectionsTestData))]
        public void GetAllSection_Should_ReturnListOfSections(
            int roomId,
            List<Section> list)
        {
            //Assign
            var dataHandler = new Mock<IDataHandler>();
            var repository = new FbSectionRepository(dataHandler.Object);
            dataHandler
                .Setup(x => x.GetAllItems<Section>(ModelType.Sections)).Returns(list);
            
            //Act
            var actual = repository.GetAllSections(roomId);
            
            //Assert
            Assert.Equal(list.Where(item => item.RoomId == roomId).AsEnumerable(), actual);
        }

        [Theory]
        [ClassData(typeof(UpdateSectionByIdTestData))]
        public void UpdateSectionById_Should_ReturnUpdatedSectionWhenExists(
            Section section,
            Section? expected,
            int sectionId,
            List<Section> list)
        {
            //Assign
            var dataHandler = new Mock<IDataHandler>();
            var repository = new FbSectionRepository(dataHandler.Object);
            dataHandler
                .Setup(x => x.GetAllItems<Section>(ModelType.Sections)).Returns(list);
            
            //Act
            var actual = repository.UpdateSectionById(section, sectionId);
            
            //Assert
            Assert.Equivalent(expected, actual);
        }
        
        [Theory]
        [ClassData(typeof(DeleteSectionByIdTestData))]
        public void DeleteSectionById_Should_ReturnDeletedSectionIfExists(
            int sectionId,
            Section? expected,
            List<Section> list)
        {
            //Assign
            var dataHandler = new Mock<IDataHandler>();
            var repository = new FbSectionRepository(dataHandler.Object);
            dataHandler
                .Setup(x => x.GetAllItems<Section>(ModelType.Sections)).Returns(list);
            
            //Act
            var actual = repository.DeleteSectionById(sectionId);

            //Assert
            Assert.Equivalent(expected, actual);
        }
    }
}

