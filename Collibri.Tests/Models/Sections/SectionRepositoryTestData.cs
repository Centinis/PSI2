using Collibri.Models.Sections;

namespace Collibri.Tests.Models.Sections
{
    public class CreateSectionTestData : TheoryData<Section, Section?, List<Section>>
    {
        public CreateSectionTestData() 
        {
            //Correct input
            Add(new Section(0, 1, "Section1"), null, 
                new List<Section>
                {
                    new Section(12345, 1, "Section2"),
                    new Section(23456, 1, "Section3")
                }
            );
            //Correct input
            Add(new Section(0, 1, "Section1"), null,
                new List<Section>
                {
                    new Section(12345, 2, "Section1"),
                    new Section(23456, 1, "Section3")
                }
            );
            //Failing input
            Add(new Section(0, 1, "Section1"), null, 
                new List<Section>
                {
                    new Section(12345, 1, "Section1"),
                    new Section(23456, 1, "Section3")
                }
            );
        }
    }

    public class GetAllSectionsTestData : TheoryData<int, List<Section>>
    {
        public GetAllSectionsTestData()
        {
            Add(1, 
                new List<Section>
                {
                    new Section(12345, 1, "Section1"),
                    new Section(23456, 1, "Section2")        
                }
            );
            Add(1, 
                new List<Section>
                {
                    new Section(12345, 1, "Section1"),
                    new Section(23456, 2, "Section2")        
                }
            );
            Add(1, new List<Section>());
        }
    }

    public class UpdateSectionByIdTestData : TheoryData<Section, Section?, int, List<Section>>
    {
        public UpdateSectionByIdTestData()
        {
            Add(new Section(0, 1, "Updated section"), new Section(12345, 1, "Updated section"), 12345,
                new List<Section>
                {
                    new Section(12345, 1, "Old section"),
                    new Section(23456, 1, "Another section")
                }
            );
            Add(new Section(0, 1, "Updated section"), null, 12345,
                new List<Section>
                {
                    new Section(23456, 1, "Random section"),
                    new Section(34567, 1, "Another section")
                }
            );
            Add(new Section(0, 1, "Updated section"), null, 12345, new List<Section>());
        }
    }

    public class DeleteSectionByIdTestData : TheoryData<int, Section?, List<Section>>
    {
        public DeleteSectionByIdTestData()
        {
            //Correct input
            Add(123, new Section(123, 1, "Section to Delete"),
                new List<Section>
                {
                    new Section(2974823, 1, "Other section"),
                    new Section(123, 1, "Section to Delete")
                }
            );
            //Failing input
            Add(123, null,
                new List<Section>
                {
                    new Section(2974823, 1, "Other section"),
                    new Section(2345, 1, "Section to Delete")
                }
            );
            //Failing input
            Add(123, null, new List<Section>());
        }
    }
}

