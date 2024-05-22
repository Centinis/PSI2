using Collibri.Dtos;
using Collibri.Repositories.DataHandling;
using Collibri.Repositories.ExtensionMethods;

namespace Collibri.Repositories.FileBasedImplementation
{
    public class FbSectionRepository : ISectionRepository
    {
        private readonly IDataHandler _dataHandler;

        public FbSectionRepository(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }
        
        public SectionDTO? CreateSection(SectionDTO section)
        {
            var sectionList = _dataHandler.GetAllItems<SectionDTO>(ModelType.Sections);
            
            if (sectionList.Any(sections => sections.Equals(section)))
            {
                return null;
            }

            section.Id = new int().GenerateNewId(sectionList.Select(x => x.Id).ToList());
            sectionList.Add(section);
            
            _dataHandler.PostAllItems(sectionList, ModelType.Sections);
            
            return section;
        }

        public IEnumerable<SectionDTO> GetAllSections(int roomId)
        {
            var sectionList = _dataHandler.GetAllItems<SectionDTO>(ModelType.Sections);
            var queriedSection = sectionList.Where(section => section.RoomId == roomId);
            
            return queriedSection;
        }

        public SectionDTO? UpdateSectionById(SectionDTO newSection, int sectionId)
        {
            var sectionList = _dataHandler.GetAllItems<SectionDTO>(ModelType.Sections);
            var sectionToUpdate = sectionList.SingleOrDefault(x => x.Id == sectionId);
            
            //method 
            if (sectionList.Any(sections => sections.Equals(newSection)) || sectionToUpdate == null)
            {
                return null;
            }

            //updating contents of section part
            sectionToUpdate.SectionName = newSection.SectionName;
            _dataHandler.PostAllItems(sectionList, ModelType.Sections);
            
            return sectionToUpdate;
        }

        public SectionDTO? DeleteSectionById(int sectionId)
        {
            var sectionList = _dataHandler.GetAllItems<SectionDTO>(ModelType.Sections);
            var sectionToDelete = sectionList.SingleOrDefault(x => x.Id == sectionId);
            
            if(sectionToDelete == null || !sectionList.Remove(sectionToDelete))
            {
                return null;
            }
            
            _dataHandler.PostAllItems(sectionList, ModelType.Sections);
            
            return sectionToDelete;
        }
    }
}

