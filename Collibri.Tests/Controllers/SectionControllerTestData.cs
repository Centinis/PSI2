using Collibri.Dtos;

namespace Collibri.Tests.Controllers
{
    public class CreateSectionTestData : TheoryData<SectionDTO, SectionDTO?, int?>
    {
        public CreateSectionTestData()
        {
            //Correct input
            Add(new SectionDTO(0, 1, "NewSectionName"), new SectionDTO(123, 1, "NewSectionName"), 200);
            //Failing input
            Add(new SectionDTO(0, 1, "NewSectionName"), null, 409);
        }
    }

    public class GetAllSectionsTestData : TheoryData<int, IEnumerable<SectionDTO>>
    {
        public GetAllSectionsTestData()
        {
            //Correct input only
            Add(1,
                new List<SectionDTO>
                {
                    new SectionDTO(12345, 1, "Section1"),    
                    new SectionDTO(23456, 1, "Section2")    
                }.AsEnumerable()
            );
            Add(1, new List<SectionDTO>().AsEnumerable());
        }
    }

    public class UpdateSectionByIdTestData : TheoryData<SectionDTO, SectionDTO?, int, int>
    {
        public UpdateSectionByIdTestData()
        {
            //Correct input
            Add(new SectionDTO(0, 2, "Old name"), new SectionDTO(12345, 2, "New name"), 12345, 200);
            //Failing input
            Add(new SectionDTO(0, 2, "Old name"), null, 23456, 404);
        }
    }
    public class DeleteSectionByIdTestData : TheoryData<int, SectionDTO?, int>
    {
        public DeleteSectionByIdTestData()
        {
            //Correct input
            Add(123, new SectionDTO(2345, 123, "Deleted section"), 200);
            //Failing input
            Add(123, null, 404);
        }
    }
}

