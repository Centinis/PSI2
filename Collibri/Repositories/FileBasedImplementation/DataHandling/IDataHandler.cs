using Collibri.Dtos;

namespace Collibri.Repositories.DataHandling
{
    public interface IDataHandler
    {
        public List<T> GetAllItems<T>(ModelType type) where T : class, new();
        public void PostAllItems<T>(List<T> itemList, ModelType type) where T : class, new() ;
    }   
}