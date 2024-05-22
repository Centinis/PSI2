using Collibri.Dtos;
using Collibri.Repositories.DataHandling;
using Collibri.Repositories.FileBasedImplementation;

namespace Collibri.Tests.Repositories.Rooms
{
    public class RoomRepositoryTests
    {        
        [Fact]
        public void CreateRoom_Should_AddRoomToList()
        {
            // Arrange
            var dataHandlerMock = new Mock<IDataHandler>();
            var repository = new FbRoomRepository(dataHandlerMock.Object);
            var room = RoomRepositoryTestData.ValidRoom;

            // Act
            var createdRoom = repository.CreateRoom(room);

            // Assert
            Assert.NotNull(createdRoom);
            Assert.Equal(room.Id, createdRoom.Id);
            Assert.Equal(room.Name, createdRoom.Name);
        }

        [Fact]
        public void UpdateRoom_Should_UpdateExistingRoom()
        {
            // Arrange
            var dataHandlerMock = new Mock<IDataHandler>();
            var repository = new FbRoomRepository(dataHandlerMock.Object);
            dataHandlerMock.Setup(handler => handler.GetAllItems<RoomDTO>(ModelType.Rooms))
                .Returns(RoomRepositoryTestData.RoomsExist);

            // Act
            var existingRoom = RoomRepositoryTestData.ExistingRoom;
            var updatedRoom = RoomRepositoryTestData.UpdatedRoom;
            var result = repository.UpdateRoom(existingRoom.Id, updatedRoom);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedRoom.Id, result.Id);
            Assert.Equal(updatedRoom.Name, result.Name);
        }
        
        [Fact]
        public void DeleteRoom_Should_RemoveExistingRoomFromList_And_CallDataHandlerPostAllItems()
        {
            // Arrange
            var dataHandlerMock = new Mock<IDataHandler>();
            RoomRepositoryTestData.ExistingRoom.Id = 1;
            var roomList = new List<RoomDTO> { RoomRepositoryTestData.ExistingRoom };
            dataHandlerMock.Setup(handler => handler.GetAllItems<RoomDTO>(ModelType.Rooms))
                .Returns(roomList);

            var repository = new FbRoomRepository(dataHandlerMock.Object);

            // Act
            var result = repository.DeleteRoom(RoomRepositoryTestData.ExistingRoom.Id);

            // Assert
            Assert.NotNull(result);

            // Additional verification
            var deletedRoom = roomList.Find(room => room.Id == RoomRepositoryTestData.ExistingRoomId);
            Assert.Null(deletedRoom); 

            // Verify that PostAllItems method of IDataHandler was called with the updated roomList
            dataHandlerMock.Verify(handler => handler.PostAllItems(roomList, ModelType.Rooms), Times.Once);
        }

        [Fact]
        public void DeleteRoom_Should_NotRemoveNonExistentRoomFromList()
        {
            // Arrange
            var dataHandlerMock = new Mock<IDataHandler>();
            var repository = new FbRoomRepository(dataHandlerMock.Object);
            dataHandlerMock.Setup(handler => handler.GetAllItems<RoomDTO>(ModelType.Rooms))
                .Returns(RoomRepositoryTestData.RoomsExist);

            // Act
            var result = repository.DeleteRoom(RoomRepositoryTestData.NonExistentRoomId);

            // Assert
            Assert.Null(result);
        }
        
        // sutvarkyti testa pagal unit of work
        
        // [Fact]
        // public void GetAllRooms_Should_ReturnListOfRooms()
        // {
        //     // Arrange
        //     var expectedRooms = RoomRepositoryTestData.RoomsExist; 
        //     var dataHandlerMock = new Mock<IDataHandler>();
        //     dataHandlerMock.Setup(handler => handler.GetAllItems<RoomDTO>(ModelType.Rooms))
        //         .Returns(expectedRooms);
        //
        //     var repository = new FbRoomRepository(dataHandlerMock.Object);
        //
        //     // Act
        //     var actualRooms = repository.GetAllRooms();
        //
        //     // Assert
        //     Assert.NotNull(actualRooms);
        //     Assert.Equal(expectedRooms.Count, actualRooms.Count);
        //     Assert.Equivalent(expectedRooms, actualRooms);
        // }
    }
}
