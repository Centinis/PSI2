using AutoMapper;
using Collibri.Data;
using Collibri.Dtos;
using Collibri.Models;
using Collibri.Repositories.DbImplementation;
using Microsoft.EntityFrameworkCore;
using Collibri.Repositories.DbImplementation.Mapper;

namespace Collibri.Tests.Repositories.Tags
{
    public class DbTagRepositoryTests
    {
        [Theory]
        [ClassData(typeof(DbTagRepositoryTestData.DbCreateTagTestData))]
        public void CreateTagTest(
            TagDTO tag,
            TagDTO? expected,
            List<Tag> list
        )
        {
            var dataContext = new Mock<DataContext>();
            var profile = new Collibri.Repositories.DbImplementation.Mapper.AutoMapper();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            IMapper mapper = new Mapper(configuration);
            
            dataContext.Setup<DbSet<Tag>>(x => x.Tags).ReturnsDbSet(list);
            
            var repository = new DbTagRepository(dataContext.Object, mapper);
            
            
            var actual = repository.CreateTag(tag);
            if (actual != null)
            {
                expected = tag;
                expected.Id = tag.Id;
            }
            
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(DbTagRepositoryTestData.DbGetAllTagsInRoomTestData))]
        public void GetAllTagsInRoomTest(
            int roomId,
            List<Tag> expected,
            List<Tag> list
        )
        {
            var dataContext = new Mock<DataContext>();
            var profile = new Collibri.Repositories.DbImplementation.Mapper.AutoMapper();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            IMapper mapper = new Mapper(configuration);
            
            dataContext.Setup<DbSet<Tag>>(x => x.Tags).ReturnsDbSet(list);
            
            var repository = new DbTagRepository(dataContext.Object, mapper);

            var actual = repository.GetAllTagsInRoom(roomId);
            
            Assert.Equivalent(mapper.Map<List<TagDTO>>(expected), actual);
        }

        [Theory]
        [ClassData(typeof(DbTagRepositoryTestData.DbDeleteTagTestData))]
        public void DeleteTagTest(
            Guid id,
            Tag? expected,
            List<Tag> list
        )
        {
            var dataContext = new Mock<DataContext>();
            var profile = new Collibri.Repositories.DbImplementation.Mapper.AutoMapper();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            IMapper mapper = new Mapper(configuration);
            
            dataContext.Setup<DbSet<Tag>>(x => x.Tags).ReturnsDbSet(list);
            
            var repository = new DbTagRepository(dataContext.Object, mapper);

            var actual = repository.DeleteTag(id);
            
            Assert.Equivalent(mapper.Map<TagDTO>(expected), actual);
        }
        
        [Theory]
        [ClassData(typeof(DbTagRepositoryTestData.DbUpdateTagTestData))]
        public void UpdateTagTest(
            Guid id,
            TagDTO? expected,
            List<Tag> list
        )
        {
            var dataContext = new Mock<DataContext>();
            var profile = new Collibri.Repositories.DbImplementation.Mapper.AutoMapper();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            IMapper mapper = new Mapper(configuration);
            
            dataContext.Setup<DbSet<Tag>>(x => x.Tags).ReturnsDbSet(list);
            
            var repository = new DbTagRepository(dataContext.Object, mapper);

            var actual = repository.UpdateTag(id, expected);
            
            Assert.Equivalent(expected, actual);
        }
    }
}

