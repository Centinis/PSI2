using AutoMapper;
using Collibri.Data;
using Collibri.Dtos;
using Collibri.Repositories.DbImplementation;
using Collibri.Repositories.DbImplementation.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

public class DbRoomRepositoryTests
{
    private readonly DbContextOptions<DataContext> _options;
    private readonly IMapper _mapper;

    public DbRoomRepositoryTests()
    {
        _options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDb")
            .ConfigureWarnings(warnings => warnings.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<Collibri.Repositories.DbImplementation.Mapper.AutoMapper>();
        });

        _mapper = configuration.CreateMapper();
    }

    [Fact]
    public void CreateRoom_ShouldCreateRoomSuccessfully()
    {
        using (var context = new DataContext(_options))
        {
            // Arrange
            var unitOfWork = new UnitOfWork<DataContext>(context);
            var repository = new DbRoomRepository(unitOfWork, _mapper);

            var roomDto = new RoomDTO
            {
                Name = "Test Room",
                CreatorUsername = "TestUser",
            };

            if (!context.Database.IsInMemory())
            {
                unitOfWork.CreateTransaction();
            }

            // Act
            var createdRoom = repository.CreateRoom(roomDto);

            if (!context.Database.IsInMemory())
            {
                unitOfWork.Commit();
            }

            // Assert
            Assert.NotNull(createdRoom);
            Assert.Equal("Test Room", createdRoom.Name);
            Assert.Equal("TestUser", createdRoom.CreatorUsername);
        }
    }

    [Fact]
    public void GetRoomByCode_ShouldReturnRoom()
    {
        using (var context = new DataContext(_options))
        {
            // Arrange
            var unitOfWork = new UnitOfWork<DataContext>(context);
            var repository = new DbRoomRepository(unitOfWork, _mapper);

            var roomDto = new RoomDTO
            {
                Name = "Test Room",
                CreatorUsername = "TestUser",
            };

            var createdRoom = repository.CreateRoom(roomDto);

            // Act
            var retrievedRoom = repository.GetRoomByCode(createdRoom.InvitationCode);

            // Assert
            Assert.NotNull(retrievedRoom);
            Assert.Equal(createdRoom.InvitationCode, retrievedRoom.InvitationCode);
        }
    }

    [Fact]
    public void GetRoomsByUsername_ShouldReturnUserRooms()
    {
        using (var context = new DataContext(_options))
        {
            // Arrange
            var unitOfWork = new UnitOfWork<DataContext>(context);
            var repository = new DbRoomRepository(unitOfWork, _mapper);

            var roomDto = new RoomDTO
            {
                Name = "Test Room",
                CreatorUsername = "TestUser",
            };

            repository.CreateRoom(roomDto);

            // Act
            var userRooms = repository.GetRoomsByUsername("TestUser");

            // Assert
            Assert.NotNull(userRooms);
            Assert.NotEmpty(userRooms);
        }
    }

    [Fact]
    public void UpdateRoom_ShouldUpdateRoomSuccessfully()
    {
        using (var context = new DataContext(_options))
        {
            // Arrange
            var unitOfWork = new UnitOfWork<DataContext>(context);
            var repository = new DbRoomRepository(unitOfWork, _mapper);

            var roomDto = new RoomDTO
            {
                Name = "Test Room",
                CreatorUsername = "TestUser",
            };

            var createdRoom = repository.CreateRoom(roomDto);

            // Act
            createdRoom.Name = "Updated Room";
            var updatedRoom = repository.UpdateRoom(createdRoom.Id, createdRoom);

            // Assert
            Assert.NotNull(updatedRoom);
            Assert.Equal("Updated Room", updatedRoom.Name);
        }
    }

    [Fact]
    public void DeleteRoom_ShouldDeleteRoomSuccessfully()
    {
        using (var context = new DataContext(_options))
        {
            // Arrange
            var unitOfWork = new UnitOfWork<DataContext>(context);
            var repository = new DbRoomRepository(unitOfWork, _mapper);

            var roomDto = new RoomDTO
            {
                Name = "Test Room",
                CreatorUsername = "TestUser",
            };

            var createdRoom = repository.CreateRoom(roomDto);

            // Act
            var deletedRoom = repository.DeleteRoom(createdRoom.Id);

            // Assert
            Assert.NotNull(deletedRoom);
            Assert.Equal(createdRoom.Id, deletedRoom.Id);
        }
    }

}