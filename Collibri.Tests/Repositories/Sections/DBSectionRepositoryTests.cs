using AutoMapper;
using Collibri.Data;
using Collibri.Dtos;
using Collibri.Models;
using Collibri.Repositories.DbImplementation;
using Microsoft.EntityFrameworkCore;
using Moq.EntityFrameworkCore;
using FileInfo = System.IO.FileInfo;

namespace Collibri.Tests.Repositories.Sections;

public class DBSectionRepositoryTests
{
    [Theory]
    [ClassData(typeof(CreateDBSectionTestData))]
    void CreateSection_Should_ReturnSection_WhenNonExistent(
        SectionDTO section,
        SectionDTO? expected,
        List<Section>? list)
    {
        var dataContext = new Mock<DataContext>();
        var profile = new Collibri.Repositories.DbImplementation.Mapper.AutoMapper();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
        IMapper mapper = new Mapper(configuration);

        dataContext.Setup<DbSet<Section>>(x => x.Sections).ReturnsDbSet(list);

        var repository = new DbSectionRepository(dataContext.Object, mapper);

        var actual = repository.CreateSection(section);
        if (actual != null)
        {
            expected = section;
            expected.Id = actual.Id;
        }
            
        //Assert
        Assert.Equal(expected, actual);
    }
    [Theory]
    [ClassData(typeof(GetAllDbSectionsTestData))]
    public void GetAllSection_Should_ReturnListOfSections(
        int roomId,
        List<Section> list)
    {
        //Assign
        var dataContext = new Mock<DataContext>();
        var profile = new Collibri.Repositories.DbImplementation.Mapper.AutoMapper();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
        IMapper mapper = new Mapper(configuration);

        dataContext.Setup<DbSet<Section>>(x => x.Sections).ReturnsDbSet(list);

        var repository = new DbSectionRepository(dataContext.Object, mapper);
        

        var actual = repository.GetAllSections(roomId);
        var gotten = list.Where(item => item.RoomId == roomId).AsEnumerable();
        Assert.Equivalent(mapper.Map<List<SectionDTO>>(gotten), actual);
    }
    
    [Theory]
    [ClassData(typeof(UpdateDbSectionByIdTestData))]
    public void UpdateSectionById_Should_ReturnUpdatedSectionWhenExists(
        SectionDTO section,
        SectionDTO? expected,
        int sectionId,
        List<Section> list)
    {
        //Assign
        var dataContext = new Mock<DataContext>();
        var profile = new Collibri.Repositories.DbImplementation.Mapper.AutoMapper();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
        IMapper mapper = new Mapper(configuration);

        dataContext.Setup<DbSet<Section>>(x => x.Sections).ReturnsDbSet(list);
        
        var repository = new DbSectionRepository(dataContext.Object, mapper);
            
        //Act
        var actual = repository.UpdateSectionById(section, sectionId);
            
        //Assert
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [ClassData(typeof(DeleteDbSectionByIdTestData))]
    public void DeleteSectionById_Should_ReturnDeletedSectionIfExists(
        int sectionId,
        SectionDTO? expected,
        List<Section> list)
    {
        //Assign
        var dataContext = new Mock<DataContext>();
        var profile = new Collibri.Repositories.DbImplementation.Mapper.AutoMapper();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
        IMapper mapper = new Mapper(configuration);

        dataContext.Setup<DbSet<Section>>(x => x.Sections).ReturnsDbSet(list);
        
        var repository = new DbSectionRepository(dataContext.Object, mapper);
            
        //Act
        var actual = repository.DeleteSectionById(sectionId);

        //Assert
        Assert.Equivalent(expected, actual);
    }
    
    
}