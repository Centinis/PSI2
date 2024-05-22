using AutoMapper;
using Collibri.Data;
using Collibri.Dtos;
using Collibri.Models;
using Collibri.Repositories.DbImplementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit.Abstractions;

namespace Collibri.Tests.Repositories.Notes
{
    public class DbNoteRepositoryTests
    {
        private readonly ITestOutputHelper output;

        private readonly DbContextOptions<DataContext> _options;
        private readonly IMapper _mapper;

        public DbNoteRepositoryTests(ITestOutputHelper output)
        {
            this.output = output;
            // _options = new DbContextOptionsBuilder<DataContext>()
            //     .UseInMemoryDatabase(databaseName: "InMemoryDb")
            //     .ConfigureWarnings(warnings => warnings.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            //     .Options;
            //
            // var configuration = new MapperConfiguration(cfg =>
            // {
            //     cfg.AddProfile<Collibri.Repositories.DbImplementation.Mapper.AutoMapper>();
            // });
            //
            // _mapper = configuration.CreateMapper();
        }
        
        [Theory]
        [ClassData(typeof(DbCreateNoteTestData))]
        public void CreateNoteTest(
            NoteDTO note,
            NoteDTO? expected,
            List<Note> list
        )
        {
            var dataContext = new Mock<DataContext>();
            var profile = new Collibri.Repositories.DbImplementation.Mapper.AutoMapper();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            IMapper mapper = new Mapper(configuration);
            
            dataContext.Setup<DbSet<Note>>(x => x.Notes).ReturnsDbSet(list);
            
            var repository = new DbNoteRepository(dataContext.Object, mapper);
            
            
            var actual = repository.CreateNote(note);
            if (actual != null)
            {
                expected = note;
                expected.Id = note.Id;
            }
            
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(DbGetNoteTestData))]
        public void GetNoteTest(
            int id,
            Note? expected,
            List<Note> list
        )
        {
            var dataContext = new Mock<DataContext>();
            var profile = new Collibri.Repositories.DbImplementation.Mapper.AutoMapper();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            IMapper mapper = new Mapper(configuration);
            
            dataContext.Setup<DbSet<Note>>(x => x.Notes).ReturnsDbSet(list);
            
            var repository = new DbNoteRepository(dataContext.Object, mapper);

            var actual = repository.GetNote(id);
            
            Assert.Equivalent(mapper.Map<NoteDTO>(expected), actual);
        }

        [Theory]
        [ClassData(typeof(DbGetNotesInPostTestData))]
        public void GetNotesInPostTest(
            Guid postId,
            List<Note> expected,
            List<Note> list
        )
        {
            var dataContext = new Mock<DataContext>();
            var profile = new Collibri.Repositories.DbImplementation.Mapper.AutoMapper();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            IMapper mapper = new Mapper(configuration);
            
            dataContext.Setup<DbSet<Note>>(x => x.Notes).ReturnsDbSet(list);
            
            
            var repository = new DbNoteRepository(dataContext.Object, mapper);

            var actual = repository.GetAllNotesByPost(postId);
            
            Assert.Equivalent(mapper.Map<List<NoteDTO>>(expected), actual);
            
        }
        
        [Theory]
        [ClassData(typeof(DbDeleteNoteTestData))]
        public void DeleteNoteTest(
            int id,
            Note? expected,
            List<Note> list
        )
        {
            var dataContext = new Mock<DataContext>();
            var profile = new Collibri.Repositories.DbImplementation.Mapper.AutoMapper();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            IMapper mapper = new Mapper(configuration);
            
            dataContext.Setup<DbSet<Note>>(x => x.Notes).ReturnsDbSet(list);
            
            var repository = new DbNoteRepository(dataContext.Object, mapper);

            var actual = repository.DeleteNote(id);
            
            // output.WriteLine(expected.Id + " " + expected.Name + " " + expected.Text + " " + expected.PostId + " " + expected.Author + " " + expected.CreationDate + " " + expected.LastUpdatedDate);
            // output.WriteLine(actual.Id + " " + actual.Name + " " + actual.Text + " " + actual.PostId + " " + actual.Author + " " + actual.CreationDate + " " + actual.LastUpdatedDate);
            Assert.Equivalent(mapper.Map<NoteDTO>(expected), actual);
            Assert.DoesNotContain(mapper.Map<Note>(actual), list);
        }
    }
}

