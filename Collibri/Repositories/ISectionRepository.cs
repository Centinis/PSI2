using Collibri.Dtos;

namespace Collibri.Repositories
{
    public interface ISectionRepository
    {
        SectionDTO? CreateSection(SectionDTO section);

        IEnumerable<SectionDTO> GetAllSections(int roomId);

        SectionDTO? UpdateSectionById(SectionDTO section, int sectionId);

        SectionDTO? DeleteSectionById(int sectionId);
    }
}

