using Collibri.Controllers;
using Collibri.Dtos;
using Collibri.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Collibri.Tests.Controllers
{
    public class RoomControllerTests
    {
        // Helper method to create a RoomController with a mock repository
        private RoomController CreateRoomController(Mock<IRoomRepository> mockRepo)
        {
            return new RoomController(mockRepo.Object);
        }

        [Fact]
        public void CreateRoom_ValidRoom_ReturnsOkResult()
        {
            // Arrange
            var mockRepo = new Mock<IRoomRepository>();
            var roomController = CreateRoomController(mockRepo);

            var roomToCreate = RoomControllerTestData.ValidRoom;
            mockRepo.Setup(repo => repo.CreateRoom(roomToCreate)).Returns(roomToCreate);

            // Act
            var result = roomController.CreateRoom(roomToCreate) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(roomToCreate, result.Value);
        }

        [Fact]
        public void CreateRoom_DuplicateRoom_ReturnsConflictResult()
        {
            // Arrange
            var mockRepo = new Mock<IRoomRepository>();
            var roomController = CreateRoomController(mockRepo);

            var existingRoom = RoomControllerTestData.ExistingRoom;
            mockRepo.Setup(repo => repo.CreateRoom(existingRoom)).Returns((RoomDTO)null);

            // Act
            var result = roomController.CreateRoom(existingRoom) as StatusCodeResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(409, result.StatusCode); // Conflict
        }
        
        // sutvarkyti testa pagal unit of work

        // [Fact]
        // public void GetAllRooms_RoomsExist_ReturnsOkResult()
        // {
        //     // Arrange
        //     var mockRepo = new Mock<IRoomRepository>();
        //     var roomController = CreateRoomController(mockRepo);
        //
        //     var rooms = RoomControllerTestData.RoomsExist;
        //     mockRepo.Setup(repo => repo.GetAllRooms()).Returns(rooms);
        //
        //     // Act
        //     var result = roomController.GetAllRooms() as OkObjectResult;
        //
        //     // Assert
        //     Assert.NotNull(result);
        //     Assert.Equal(200, result.StatusCode);
        //     Assert.Equal(rooms, result.Value);
        // }

        [Fact]
        public void UpdateRoom_ExistingRoom_ReturnsOkResult()
        {
            // Arrange
            var mockRepo = new Mock<IRoomRepository>();
            var roomController = CreateRoomController(mockRepo);

            var existingRoomId = RoomControllerTestData.ExistingRoomId;
            var updatedRoom = RoomControllerTestData.UpdatedRoom;
            var existingRoom = RoomControllerTestData.ExistingRoom;

            mockRepo.Setup(repo => repo.UpdateRoom(existingRoomId, updatedRoom)).Returns(existingRoom);

            // Act
            var result = roomController.UpdateRoom(existingRoomId, updatedRoom) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(existingRoom, result.Value);
        }

        [Fact]
        public void UpdateRoom_NonExistentRoom_ReturnsNotFoundResult()
        {
            // Arrange
            var mockRepo = new Mock<IRoomRepository>();
            var roomController = CreateRoomController(mockRepo);

            var nonExistentRoomId = RoomControllerTestData.NonExistentRoomId;
            var updatedRoom = RoomControllerTestData.UpdatedRoom;

            mockRepo.Setup(repo => repo.UpdateRoom(nonExistentRoomId, updatedRoom)).Returns((RoomDTO)null);

            // Act
            var result = roomController.UpdateRoom(nonExistentRoomId, updatedRoom) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode); // Not Found
        }

        // [Fact]
        // public void DeleteRoom_ExistingRoom_ReturnsNoContentResult()
        // {
        //     // Arrange
        //     var mockRepo = new Mock<IRoomRepository>();
        //     var roomController = CreateRoomController(mockRepo);
        //
        //     var existingRoomId = RoomControllerTestData.ExistingRoomId;
        //     var exisingRoom = RoomControllerTestData.ExistingRoom;
        //     exisingRoom.Id = existingRoomId;
        //
        //     mockRepo.Setup(repo => repo.DeleteRoom(existingRoomId)).Returns(exisingRoom);
        //
        //     // Act
        //     var result = roomController.DeleteRoom(existingRoomId) as OkResult;
        //
        //     // Assert
        //     Assert.Equal(200, result?.StatusCode);
        // }

        [Fact]
        public void DeleteRoom_NonExistentRoom_ReturnsNotFoundResult()
        {
            // Arrange
            var mockRepo = new Mock<IRoomRepository>();
            var roomController = CreateRoomController(mockRepo);

            var nonExistentRoomId = RoomControllerTestData.NonExistentRoomId;
            var notExistentRoom = null as RoomDTO;

            mockRepo.Setup(repo => repo.DeleteRoom(nonExistentRoomId)).Returns(notExistentRoom);

            // Act
            var result = roomController.DeleteRoom(nonExistentRoomId) as NotFoundResult;

            // Assert
            Assert.Equal(404, result.StatusCode); // Not Found
        }
    }
}