using AutoMapper;
using Collibri.Data;
using Collibri.Dtos;
using Collibri.Models;
using Collibri.Repositories.ExtensionMethods;

namespace Collibri.Repositories.DbImplementation
{
    public class DbSectionRepository : ISectionRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        public DbSectionRepository(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
            _mapper = mapper;
        }
    
        public SectionDTO? CreateSection(SectionDTO section)
        {
            if (_mapper.Map<List<SectionDTO>>(_context.Sections.ToList()).Any(sections => sections.Equals(section)))
            {
                return null;
            }

            section.Id = new int().GenerateNewId(_context.Sections.Select(x => x.Id).ToList());
            _context.Sections.Add(_mapper.Map<Section>(section));
            _context.SaveChanges();

            return section;
        }

        public IEnumerable<SectionDTO> GetAllSections(int roomId)
        {
            return _mapper.Map<List<SectionDTO>>(_context.Sections.ToList().Where(section => section.RoomId == roomId)).AsEnumerable();
        }

        public SectionDTO? UpdateSectionById(SectionDTO section, int sectionId)
        {
            var sectionToUpdate = _context.Sections.SingleOrDefault(x => x.Id == sectionId);
            
            //method 
            if (_context.Sections.Any(sections => sections.Equals(_mapper.Map<Section>(section))) || sectionToUpdate == null)
            {
                return null;
            }

            //updating contents of section part
            sectionToUpdate.SectionName = section.SectionName;
            _context.Sections.Update(sectionToUpdate);
            _context.SaveChanges();

            return _mapper.Map<SectionDTO>(sectionToUpdate);
        }

        public SectionDTO? DeleteSectionById(int sectionId)
        {
            var sectionToDelete = _context.Sections.SingleOrDefault(x => x.Id == sectionId);
            
            if(sectionToDelete == null)
            {
                return null;
            }

            _context.Sections.Remove(sectionToDelete);
            _context.SaveChanges();

            return _mapper.Map<SectionDTO>(sectionToDelete);
        }
    }
}