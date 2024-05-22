using AutoMapper;
using Collibri.Data;
using Collibri.Dtos;
using Collibri.Models;
using Collibri.Repositories.DbImplementation;
using Microsoft.EntityFrameworkCore;

namespace Collibri.Tests.Repositories.Posts
{
    public class DbPostRepositoryTests
    {
        [Theory]
        [ClassData(typeof(DbCreatePostTestData))]
        public void CreatePost_Should_ReturnCreatedPost(
            PostDTO postDto,
            int entitiesChanged,
            PostDTO expected,
            List<Post> list)
        {
            //Arrange
            var context = new Mock<DataContext>();
            var mapper = new Mock<IMapper>();
            var repository = new DbPostRepository(context.Object, mapper.Object);
            
            context.Setup<DbSet<Post>>(x => x.Posts).ReturnsDbSet(list);
            context.Setup(x => x.SaveChanges()).Returns(entitiesChanged);
            
            // //Act
            var actual = repository.CreatePost(postDto);
            
            //Assert
            Assert.Equivalent(expected.Description, actual.Description);
            Assert.Equivalent(expected.Title, actual.Title);
        }

        [Theory]
        [ClassData(typeof(DbGetAllPostsTestData))]
        public void GetAllPosts_Should_ReturnAllPostsBySection(
            List<Post> list,
            int sectionId,
            List<Post> expected)
        {
             //Assert
             var context = new Mock<DataContext>();
             var profile = new Collibri.Repositories.DbImplementation.Mapper.AutoMapper();
             var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
             IMapper mapper = new Mapper(configuration);
             var repository = new DbPostRepository(context.Object, mapper);
            
             context.Setup<DbSet<Post>>(x => x.Posts).ReturnsDbSet(list.AsEnumerable());
            
             //Act
             var actual = repository.GetAllPosts(sectionId);
            
             //Assert
             Assert.Equivalent(mapper.Map<List<PostDTO>>(expected), actual);
            // Assert.Null(null);
        }
        
        [Theory]
        [ClassData(typeof(DbUpdatePostTestData))]
        public void CreatePost_Should_ReturnUpdatedPost(
            PostDTO postDto,
            Guid postId,
            int entitiesChanged,
            PostDTO? expected,
            List<Post> list)
        {
            //Arrange
            var context = new Mock<DataContext>();
            var profile = new Collibri.Repositories.DbImplementation.Mapper.AutoMapper();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            IMapper mapper = new Mapper(configuration);
            var repository = new DbPostRepository(context.Object, mapper);
                
            context.Setup<DbSet<Post>>(x => x.Posts).ReturnsDbSet(list);
            context.Setup(x => x.SaveChanges()).Returns(entitiesChanged);
                
            //Act
            var actual = repository.UpdatePostById(postId, postDto);
                
            //Assert
            Assert.Equivalent(expected?.Description, actual?.Description);
            Assert.Equivalent(expected?.Title, actual?.Title);
        }
        
        [Theory]
        [ClassData(typeof(DbDeletePostTestData))]
        public void CreatePost_Should_ReturnDeletedPost(
            Guid postId,
            int entitiesChanged,
            PostDTO? expected,
            List<Post> list)
        {
            //Arrange
            var context = new Mock<DataContext>();
            var profile = new Collibri.Repositories.DbImplementation.Mapper.AutoMapper();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            IMapper mapper = new Mapper(configuration);
            var repository = new DbPostRepository(context.Object, mapper);
                
            context.Setup<DbSet<Post>>(x => x.Posts).ReturnsDbSet(list);
            context.Setup(x => x.SaveChanges()).Returns(entitiesChanged);
                
            //Act
            var actual = repository.DeletePostById(postId);
                
            //Assert
            Assert.Equivalent(expected?.Description, actual?.Description);
            Assert.Equivalent(expected?.Title, actual?.Title);
        }
    }   
}