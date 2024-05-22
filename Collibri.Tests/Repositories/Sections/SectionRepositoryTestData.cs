using Collibri.Dtos;

namespace Collibri.Tests.Repositories.Sections
{
    public class CreateSectionTestData : TheoryData<SectionDTO, SectionDTO?, List<SectionDTO>>
    {
        public CreateSectionTestData() 
        {
            //Correct input
            Add(new SectionDTO(0, 1, "Section1"), null, 
                new List<SectionDTO>
                {
                    new SectionDTO(12345, 1, "Section2"),
                    new SectionDTO(23456, 1, "Section3")
                }
            );
            //Correct input
            Add(new SectionDTO(0, 1, "Section1"), null,
                new List<SectionDTO>
                {
                    new SectionDTO(12345, 2, "Section1"),
                    new SectionDTO(23456, 1, "Section3")
                }
            );
            //Failing input
            Add(new SectionDTO(0, 1, "Section1"), null, 
                new List<SectionDTO>
                {
                    new SectionDTO(12345, 1, "Section1"),
                    new SectionDTO(23456, 1, "Section3")
                }
            );
        }
    }

    public class GetAllSectionsTestData : TheoryData<int, List<SectionDTO>>
    {
        public GetAllSectionsTestData()
        {
            Add(1, 
                new List<SectionDTO>
                {
                    new SectionDTO(12345, 1, "Section1"),
                    new SectionDTO(23456, 1, "Section2")        
                }
            );
            Add(1, 
                new List<SectionDTO>
                {
                    new SectionDTO(12345, 1, "Section1"),
                    new SectionDTO(23456, 2, "Section2")        
                }
            );
            Add(1, new List<SectionDTO>());
        }
    }

    public class UpdateSectionByIdTestData : TheoryData<SectionDTO, SectionDTO?, int, List<SectionDTO>>
    {
        public UpdateSectionByIdTestData()
        {
            Add(new SectionDTO(0, 1, "Updated section"), new SectionDTO(12345, 1, "Updated section"), 12345,
                new List<SectionDTO>
                {
                    new SectionDTO(12345, 1, "Old section"),
                    new SectionDTO(23456, 1, "Another section")
                }
            );
            Add(new SectionDTO(0, 1, "Updated section"), null, 12345,
                new List<SectionDTO>
                {
                    new SectionDTO(23456, 1, "Random section"),
                    new SectionDTO(34567, 1, "Another section")
                }
            );
            Add(new SectionDTO(0, 1, "Updated section"), null, 12345, new List<SectionDTO>());
        }
    }

    public class DeleteSectionByIdTestData : TheoryData<int, SectionDTO?, List<SectionDTO>>
    {
        public DeleteSectionByIdTestData()
        {
            //Correct input
            Add(123, new SectionDTO(123, 1, "SectionDTO to Delete"),
                new List<SectionDTO>
                {
                    new SectionDTO(2974823, 1, "Other section"),
                    new SectionDTO(123, 1, "SectionDTO to Delete")
                }
            );
            //Failing input
            Add(123, null,
                new List<SectionDTO>
                {
                    new SectionDTO(2974823, 1, "Other section"),
                    new SectionDTO(2345, 1, "SectionDTO to Delete")
                }
            );
            //Failing input
            Add(123, null, new List<SectionDTO>());
        }
    }
}

