using Collibri.Dtos;
using Collibri.Models;

namespace Collibri.Tests.Repositories.Sections;

public class CreateDBSectionTestData : TheoryData<SectionDTO, SectionDTO?, List<Section>>
{
    public CreateDBSectionTestData()
    {
        //Correct input
        Add(new SectionDTO(0, 1, "Section1"), null, 
            new List<Section>
            {
                new Section { Id = 12345, RoomId = 1, SectionName = "Section2" },
                new Section { Id = 23456, RoomId = 1, SectionName = "Section3" }
            }
        );

// Correct input
        Add(new SectionDTO(0, 1, "Section1"), null,
            new List<Section>
            {
                new Section { Id = 12345, RoomId = 2, SectionName = "Section1" },
                new Section { Id = 23456, RoomId = 1, SectionName = "Section3" }
            }
        );

// Failing input
        Add(new SectionDTO(0, 1, "Section1"), null, 
            new List<Section>
            {
                new Section { Id = 12345, RoomId = 1, SectionName = "Section1" },
                new Section { Id = 23456, RoomId = 1, SectionName = "Section3" }
            }
        );
    }
    
    
}
public class GetAllDbSectionsTestData : TheoryData<int, List<Section>>
{
    public GetAllDbSectionsTestData()
    {
        Add(1, 
            new List<Section>
            {
                new Section { Id = 12345, RoomId = 1, SectionName = "Section1" },
                new Section { Id = 23456, RoomId = 1, SectionName = "Section3" }     
            }
        );
        Add(1, 
            new List<Section>
            {
                new Section { Id = 12345, RoomId = 1, SectionName = "Section2" },
                new Section { Id = 23456, RoomId = 1, SectionName = "Section3" }       
            }
        );
        Add(1, new List<Section>());
    }
}
public class UpdateDbSectionByIdTestData : TheoryData<SectionDTO, SectionDTO?, int, List<Section>>
{
    public UpdateDbSectionByIdTestData()
    {
        Add(new SectionDTO(0, 1, "Updated section"), 
            new SectionDTO(12345, 1, "Updated section"), 
            12345,
            new List<Section>
            {
                new Section { Id = 12345, RoomId = 1, SectionName = "Old section" },
                new Section { Id = 23456, RoomId = 1, SectionName = "Another section" }
            }
        );

        Add(new SectionDTO(0, 1, "Updated section"), null, 12345,
            new List<Section>
            {
                new Section { Id = 23456, RoomId = 1, SectionName = "Random section" },
                new Section { Id = 34567, RoomId = 1, SectionName = "Another section" }
            }
        );

        Add(new SectionDTO(0, 1, "Updated section"), null, 12345,
            new List<Section>()
        );
    }
}

public class DeleteDbSectionByIdTestData : TheoryData<int, SectionDTO?, List<Section>>
{
    public DeleteDbSectionByIdTestData()
    {
        //Correct input
        Add(123, new SectionDTO(123, 1, "SectionDTO to Delete"),
            new List<Section>
            {
                new Section { Id = 2974823, RoomId = 1, SectionName = "Other section" },
                new Section { Id = 123, RoomId = 1, SectionName = "SectionDTO to Delete" }
            }
        );
        //Failing input
        Add(123, null,
            new List<Section>
            {
                new Section { Id = 2974823, RoomId = 1, SectionName = "Other section" },
                new Section { Id = 2345, RoomId = 1, SectionName = "SectionDTO to Delete" }
            }
        );
        //Failing input
        Add(123, null, new List<Section>());
    }
}